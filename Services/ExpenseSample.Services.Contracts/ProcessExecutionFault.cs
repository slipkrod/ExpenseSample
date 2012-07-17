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
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ExpenseSample.Services.Contracts
{
    [DataContract]
    public class ProcessExecutionFault
    {
        private string _message = string.Empty;

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public ProcessExecutionFault()
        {
            this._message = "Error executing Business Process on back-end.";
        }

        public ProcessExecutionFault(string message)
        {
            this._message = message;
        }

    }
}
