﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExpenseSample.UI.Process.ExpenseWorkflowService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ExpenseWorkflowService.IExpenseWorkflowService")]
    public interface IExpenseWorkflowService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseWorkflowService/SubmitExpense", ReplyAction="http://tempuri.org/IExpenseWorkflowService/SubmitExpenseResponse")]
        ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage SubmitExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseWorkflowService/CancelExpense", ReplyAction="http://tempuri.org/IExpenseWorkflowService/CancelExpenseResponse")]
        ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage CancelExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseWorkflowService/ReviewExpense", ReplyAction="http://tempuri.org/IExpenseWorkflowService/ReviewExpenseResponse")]
        ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage ReviewExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseWorkflowService/ApproveExpense", ReplyAction="http://tempuri.org/IExpenseWorkflowService/ApproveExpenseResponse")]
        ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage ApproveExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IExpenseWorkflowService/DisburseExpense", ReplyAction="http://tempuri.org/IExpenseWorkflowService/DisburseExpenseResponse")]
        ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage DisburseExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class SubmitterRequestMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public System.Guid CorrelationID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ExpenseSample.Business.Entities.Expense Expense;
        
        public SubmitterRequestMessage() {
        }
        
        public SubmitterRequestMessage(System.Guid CorrelationID, ExpenseSample.Business.Entities.Expense Expense) {
            this.CorrelationID = CorrelationID;
            this.Expense = Expense;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ApproverRequestMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public System.Guid CorrelationID;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public ExpenseSample.Business.Entities.Expense Expense;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public ExpenseSample.Business.Entities.ExpenseReview Review;
        
        public ApproverRequestMessage() {
        }
        
        public ApproverRequestMessage(System.Guid CorrelationID, ExpenseSample.Business.Entities.Expense Expense, ExpenseSample.Business.Entities.ExpenseReview Review) {
            this.CorrelationID = CorrelationID;
            this.Expense = Expense;
            this.Review = Review;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IExpenseWorkflowServiceChannel : ExpenseSample.UI.Process.ExpenseWorkflowService.IExpenseWorkflowService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ExpenseWorkflowServiceClient : System.ServiceModel.ClientBase<ExpenseSample.UI.Process.ExpenseWorkflowService.IExpenseWorkflowService>, ExpenseSample.UI.Process.ExpenseWorkflowService.IExpenseWorkflowService {
        
        public ExpenseWorkflowServiceClient() {
        }
        
        public ExpenseWorkflowServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ExpenseWorkflowServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseWorkflowServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ExpenseWorkflowServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage SubmitExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage request) {
            return base.Channel.SubmitExpense(request);
        }
        
        public ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage CancelExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.SubmitterRequestMessage request) {
            return base.Channel.CancelExpense(request);
        }
        
        public ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage ReviewExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage request) {
            return base.Channel.ReviewExpense(request);
        }
        
        public ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage ApproveExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage request) {
            return base.Channel.ApproveExpense(request);
        }
        
        public ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage DisburseExpense(ExpenseSample.UI.Process.ExpenseWorkflowService.ApproverRequestMessage request) {
            return base.Channel.DisburseExpense(request);
        }
    }
}
