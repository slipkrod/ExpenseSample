<%@ Page Title="Approve Expense" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Approver.aspx.cs" Inherits="ExpenseSample.UI.Web.Approver" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h2>
        Approve Expense</h2>
    <br />
    <br />
    <asp:UpdatePanel ID="refreshPanel" runat="server" ChildrenAsTriggers="true">
    <ContentTemplate>
    <asp:Timer ID="refreshTimer" runat="server" Enabled="False" Interval="10000" OnTick="refreshTimer_Tick">
    </asp:Timer>
    <table>
        <tr>
            <td>
                Role:
            </td>
            <td>
                <asp:DropDownList ID="roleBox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="roleBox_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td style="text-align: right">
                <asp:CheckBox ID="autoRefresh" runat="server" AutoPostBack="true" 
                    OnCheckedChanged="autoRefresh_CheckedChanged" Text="Auto Refresh" />
                &nbsp;<asp:Button ID="refreshButton" runat="server" CausesValidation="False" OnClick="refreshButton_Click"
                    Text="Refresh" Width="80px" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="expenseGrid" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    GridLines="None" AllowPaging="True" AllowSorting="True" DataKeyNames="ExpenseID, WorkflowID"
                    OnPageIndexChanging="expenseGrid_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="selectBox" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ExpenseID" HeaderText="ExpenseID" />
                        <asp:BoundField DataField="Employee" HeaderText="Employee" />
                        <asp:BoundField DataField="Category" HeaderText="Category" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" />
                        <asp:BoundField DataField="ExpenseDate" HeaderText="Expense Date" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:BoundField DataField="DateSubmitted" HeaderText="Date Submitted" />
                        <asp:BoundField DataField="DateModified" HeaderText="Date Modified" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                Remarks:
            </td>
            <td>
                <asp:TextBox ID="remarksBox" runat="server" Width="337px"></asp:TextBox>
            </td>
            <td>
            </td>
            <td style="height: 28px; text-align: right">
                &nbsp;<asp:Button ID="approveButton" runat="server" Text="Approve" OnClick="approveButton_Click"
                    Width="80px" />
                <asp:Button ID="rejectButton" runat="server" Text="Reject" OnClick="rejectButton_Click"
                    Width="80px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="statusLabel" runat="server"></asp:Label>
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
