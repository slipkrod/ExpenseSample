<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ExpenseSample.UI.Web._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <h2>
        Submit Expense</h2>
    Welcome
    <asp:Label ID="userLabel" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:UpdatePanel ID="refreshPanel" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:Timer ID="refreshTimer" runat="server" Enabled="False" Interval="10000" OnTick="refreshTimer_Tick">
            </asp:Timer>
            <table>
                <tr>
                    <td>
                        Expense Date:
                    </td>
                    <td>
                        <asp:TextBox ID="expenseDate" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                    <td>
                        Amount:
                    </td>
                    <td>
                        <asp:TextBox ID="expenseAmount" runat="server" Width="100px">500</asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:CompareValidator ID="dateTypeValidation" runat="server" ControlToValidate="expenseDate"
                            ErrorMessage="Please enter a valid date." Operator="DataTypeCheck" Type="Date"
                            Display="Dynamic" ForeColor="Red"></asp:CompareValidator>
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="amountRequired" runat="server" ControlToValidate="expenseAmount"
                            Display="Dynamic" ErrorMessage="Please enter an amount." ForeColor="Red">Please enter an amount.</asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="amountTypeValidation" runat="server" ControlToValidate="expenseAmount"
                            Display="Dynamic" ErrorMessage="Amount must be numeric." Type="Double" 
                            Operator="DataTypeCheck" ForeColor="Red">Amount must be numeric.</asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td style="height: 23px">
                        Description:
                    </td>
                    <td style="height: 23px">
                        <asp:TextBox ID="description" runat="server" Width="300px">Expense submitted from the web</asp:TextBox>
                    </td>
                    <td class="style2">
                    </td>
                    <td style="height: 23px">
                        Category:
                    </td>
                    <td style="height: 23px">
                        <asp:DropDownList ID="category" runat="server" Width="106px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="submitButton" runat="server" OnClick="submitButton_Click" Text="Submit Expense" />
                    </td>
                    <td class="style1">
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="statusLabel" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;
            <table>
                <tr>
                    <td>
                    </td>
                    <td align="right">
                        <asp:CheckBox ID="autoRefresh" Text="Auto Refresh" AutoPostBack="true" runat="server"
                            OnCheckedChanged="autoRefresh_CheckedChanged" />
                        &nbsp;<asp:Button ID="refreshButton" runat="server" Text="Refresh" OnClick="refreshButton_Click"
                            CausesValidation="False" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="expenseGrid" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            AllowSorting="True" DataKeyNames="ExpenseID,WorkflowID" OnPageIndexChanging="expenseGrid_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        &nbsp;<asp:CheckBox ID="selectBox" runat="server" />&nbsp;
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ExpenseID" HeaderText="ID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Category" HeaderText="Category">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="Amount" HeaderText="Amount">
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ExpenseDate" HeaderText="Expense Date">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateSubmitted" HeaderText="Date Submitted">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateModified" HeaderText="Date Modified">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="AssignedTo" HeaderText="Assigned To">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="height: 28px; text-align: left">
                        &nbsp;<asp:Button ID="cancelButton" runat="server" Text="Cancel" CausesValidation="False"
                            OnClick="cancelButton_Click" Width="80px" />
                        <asp:Button ID="historyButton" runat="server" CausesValidation="False" OnClick="historyButton_Click"
                            Text="Approvals" Width="80px" />
                        <asp:Button ID="logButton" runat="server" CausesValidation="False" OnClick="logButton_Click"
                            Text="Transitions" Width="80px" />
                    </td>
                    <td style="height: 28px; text-align: right;">
                        &nbsp;<asp:Button ID="purgeButton" runat="server" Text="Reset database" OnClick="purgeButton_Click"
                            CausesValidation="False" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="infoLabel" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="reviewGrid" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ReviewID" HeaderText="ReviewID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Reviewer" HeaderText="Reviewer">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="IsApproved" HeaderText="IsApproved" ReadOnly="True">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:CheckBoxField>
                                <asp:BoundField DataField="DateApproved" HeaderText="Date Approved">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                        <asp:GridView ID="logGrid" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="LogID" HeaderText="LogID">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Status" HeaderText="Status">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DateCreated" HeaderText="Date Created">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
