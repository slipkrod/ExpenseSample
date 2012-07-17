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
using System.Diagnostics;

using System.ServiceModel;
using System.ServiceProcess;
using ExpenseSample.Services;
using ExpenseSample.Business.Workflows;
using System.ServiceModel.Description;
using System.ServiceModel.Activities;


namespace ExpenseSample.Hosts.WindowsServiceHost
{
    public partial class WindowsServiceHost : ServiceBase
    {
        private ServiceHost _svcHost = null;
        private WorkflowServiceHost _wfSvcHost = null;

        public WindowsServiceHost()
        {
            InitializeComponent();
            this.ServiceName = "ExpenseSample V4.0 Windows Service Host";
            this.CanStop = true;
            this.CanPauseAndContinue = true;
            this.AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _svcHost = LoadExpenseService();
                _wfSvcHost = LoadWorkflowService();

            }
            catch
            {
                EventLog.WriteEntry("ExpenseSample",
                    "\nFailed to start ExpenseSample Windows Service Host.", EventLogEntryType.Error);
                throw;
            }
        }

        private ServiceHost LoadExpenseService()
        {
            ServiceHost svcHost = null;

            try
            {
                // Create Service Host.
                svcHost = new ServiceHost(typeof(ExpenseService));
                svcHost.Open();

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ExpenseSample",
                    "Unable to load ExpenseService.\n" +
                    "Please refer to the README.TXT for setup and installation instructions.\n" +
                    "Exception : " + ex.Message, EventLogEntryType.Error);

                throw ex;
            }
             
            return svcHost;
        }

        private WorkflowServiceHost LoadWorkflowService()
        {
            // Create Service Host.
            WorkflowServiceHost wfSvcHost = null;

            try
            {
                wfSvcHost = new WorkflowServiceHost(new ExpenseWorkflowService());
                wfSvcHost.Open();
            }
            catch (ArgumentException argEx)
            {
                EventLog.WriteEntry("ExpenseSample",
                        "\nError Loading Expense Workflow Service. " +
                        "Unable to connect to Workflow Persistence Store. " +
                        "\nPlease refer to the README.TXT for setup and installation instructions or check " +
                        "the connection string settings in the ConsoleHost configuration file." + 
                        "\nException : " + argEx.Message, EventLogEntryType.Error);
                throw argEx;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("ExpenseSample",
                    "Unable to load ExpenseWorkflowService.\n" +
                    "Exception : " + ex.Message, EventLogEntryType.Error);
                throw ex;
            }
            return wfSvcHost;
        }

        protected override void OnStop()
        {
            if (_svcHost != null)
                _svcHost.Close();

            if (_wfSvcHost != null)
                _wfSvcHost.Close();

            EventLog.WriteEntry("ExpenseSample",
                "\nExpenseSample Windows Service Host has been successfully stopped.",
                EventLogEntryType.Information);
        }
    }
}
