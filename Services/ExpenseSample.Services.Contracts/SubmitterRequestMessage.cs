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
using System.ServiceModel;
using ExpenseSample.Business.Entities;

namespace ExpenseSample.Services.Contracts
{
    [MessageContract(IsWrapped=false)]
    public class SubmitterRequestMessage
    {
        [MessageHeader]
        public Guid CorrelationID { get; set; }

        [MessageBodyMember]
        public Expense Expense { get; set; }

    }
}
