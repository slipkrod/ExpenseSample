//--------------------------------------------------------------------------------
// Layered Architecture Sample: Expense Sample Application
// Developed by: Serena Yeoh
// 
// For updates, please visit http://www.codeplex.com/layersample
//--------------------------------------------------------------------------------
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

using System.ServiceModel;
using System.Messaging;

using ExpenseSample.Services;
using ExpenseSample.Business.Workflows;
using System.ServiceModel.Description;
using System.ServiceModel.Activities;

namespace ExpenseSample.Hosts.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost _svcHost = null;
            WorkflowServiceHost _wfSvcHost = null;

            try
            {
                Console.WriteLine("Starting Expense Host ...");

                _svcHost = LoadExpenseService();
                _wfSvcHost = LoadWorkflowService();

                DisplayWorkflowType();

                Console.WriteLine("\nExpense ConsoleHost started. Press any key to exit.\n\n");
                Console.Read();
            }
            catch 
            {
                Console.WriteLine("\nHost initialization has failed.");
                Console.WriteLine("Press any key to terminate.");
                Console.Read();
            }
            finally
            {
                if (_svcHost != null)
                    _svcHost.Close();

                if (_wfSvcHost != null)
                    _wfSvcHost.Close();
            }

        }

        private static ServiceHost LoadExpenseService()
        {
            ServiceHost svcHost = null;
            try
            {
                Console.Write("Loading Expense Service ... ");

                // Create Service Host.
                svcHost = new ServiceHost(typeof(ExpenseService));
                svcHost.Open();

                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError Loading Expense Service. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return svcHost;
        }

        private static WorkflowServiceHost LoadWorkflowService()
        {
            WorkflowServiceHost wfSvcHost = null;
            try
            {
                Console.Write("Loading Expense Workflow Service ... ");

                // Create WorkflowService Host.
                wfSvcHost = new WorkflowServiceHost(new ExpenseWorkflowService());
                wfSvcHost.Open();
                
                Console.WriteLine("Done!");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine();
                Console.WriteLine("\nError Loading Expense Workflow Service. ");
                Console.WriteLine("Unable to connect to Workflow Persistence Store. ");
                Console.WriteLine("\nPlease refer to the README.TXT for setup and installation instructions or check " + 
                                  "the connection string settings in the ConsoleHost configuration file.");

                Console.WriteLine("\nException : " + argEx.Message);
                throw argEx;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError Loading Expense Workflow Service. ");
                Console.WriteLine("Exception : " + ex.Message);
                throw ex;
            }

            return wfSvcHost;
        }
       
        //static void runtime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        //{
        //    Console.WriteLine(string.Format("WorkflowInstance : {0} Completed!", e.WorkflowInstance.InstanceId));
        //}

        //static void runtime_WorkflowTerminated(object sender, WorkflowTerminatedEventArgs e)
        //{
        //    Console.WriteLine(string.Format("WorkflowInstance : {0} Terminated!", e.WorkflowInstance.InstanceId));
        //    if (e.Exception != null)
        //    {
        //        Console.WriteLine("Exception thrown: " + e.Exception.Message);
        //    }
        //}

        //static void runtime_WorkflowPersisted(object sender, WorkflowEventArgs e)
        //{
        //    Console.WriteLine(string.Format("WorkflowInstance : {0} Persisted!", e.WorkflowInstance.InstanceId));
        //}

        /// <summary>
        /// Display what workflow type is being used.
        /// </summary>
        private static void DisplayWorkflowType()
        {
            //Console.Write("Workflow Type: ");
            //if (ConfigurationManager.AppSettings["WorkflowType"].ToString() == "StateMachine")
            //    Console.WriteLine("StateMachine");
            //else
            //    Console.WriteLine("Sequential");
        }

    }
}
