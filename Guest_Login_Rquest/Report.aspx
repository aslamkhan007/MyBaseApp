<%@ Page Title="" Language="C#" MasterPageFile="~/Guest_Login_Rquest/Report.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Guest_Login_Rquest_Report" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="width: 80px">
                <asp:Label ID="Label1" runat="server" Text="Date From"></asp:Label>
            </td>
            <td style="width: 109px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td style="width: 126px">
                <asp:Label ID="Label2" runat="server" Text="Date To"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <asp:Label ID="Label3" runat="server" Text="Mobile No."></asp:Label>
            </td>
            <td style="width: 109px">
                <asp:TextBox ID="txtmobile" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtmobile_AutoCompleteExtender" runat="server" 
                    MinimumPrefixLength="1" ServiceMethod="GuestMobile" 
                    ServicePath="~/WebService.asmx" TargetControlID="txtmobile" 
                    UseContextKey="True" CompletionInterval="10">
                </cc1:AutoCompleteExtender>
            </td>
            <td style="width: 126px">
                <asp:Label ID="Label4" runat="server" Text="Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtName_AutoCompleteExtender" runat="server" 
                    MinimumPrefixLength="1" ServiceMethod="GuestName" 
                  ServicePath="~/WebService.asmx"  TargetControlID="txtName" 
                    CompletionInterval="10">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                <asp:Label ID="Label5" runat="server" Text="Company"></asp:Label>
            </td>
            <td style="width: 109px">
                <asp:TextBox ID="txtCompany" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtCompany_AutoCompleteExtender" runat="server" 
                    MinimumPrefixLength="1" ServiceMethod="GuestCompany" 
                    ServicePath="~/WebService.asmx"  TargetControlID="txtCompany" 
                    CompletionInterval="10">
                </cc1:AutoCompleteExtender>
            </td>
            <td style="width: 126px">
                <asp:Label ID="Label6" runat="server" Text="Visiting Employee"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtVisitingEmployee" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtVisitingEmployee_AutoCompleteExtender" 
                    runat="server" MinimumPrefixLength="1" ServiceMethod="Guest_VisitingEmployee" 
                    ServicePath="~/WebService.asmx"  TargetControlID="txtVisitingEmployee" 
                    CompletionInterval="10">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                &nbsp;</td>
            <td style="width: 109px">
                &nbsp;</td>
            <td style="width: 126px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <asp:Button ID="btnFetch" runat="server" CssClass="classbutton" Text="Fetch" 
                    onclick="btnFetch_Click" />
                <asp:Button ID="btnReset" runat="server" CssClass="classbutton" Text="Reset" />
                <asp:Button ID="btnBack" runat="server" CssClass="classbutton" Text="Back" 
                    PostBackUrl="~/Guest_Login_Rquest/Change_Password.aspx" />
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Left" Width="100%">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" 
                        AllowPaging="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                        EnableModelValidation="True" onpageindexchanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Guest Name" HeaderText="Guest Name" 
                                SortExpression="Guest Name" />
                            <asp:BoundField DataField="UserID" HeaderText="UserID" 
                                SortExpression="UserID" />
                            <asp:BoundField DataField="Password" HeaderText="Password" 
                                SortExpression="Password" />
                            <asp:BoundField DataField="RequestId" HeaderText="RequestId" 
                                SortExpression="RequestId" />
                            <asp:BoundField DataField="Security Code" HeaderText="Security Code" 
                                SortExpression="Security Code" />
                            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                            <asp:BoundField DataField="Mobile" HeaderText="Mobile" 
                                SortExpression="Mobile" />
                            <asp:BoundField DataField="IP" HeaderText="IP" SortExpression="IP" />
                            <asp:BoundField DataField="Company" HeaderText="Company" 
                                SortExpression="Company" />
                            <asp:BoundField DataField="Visiting Emlpoyee" HeaderText="Visiting Emlpoyee" 
                                SortExpression="Visiting Emlpoyee" />
                            <asp:BoundField DataField="Date Of Visit" HeaderText="Date Of Visit" 
                                ReadOnly="True" SortExpression="Date Of Visit" />
                            <asp:BoundField DataField="Stay Days" HeaderText="Stay Days" 
                                SortExpression="Stay Days" />
                            <asp:BoundField DataField="Purpose" HeaderText="Purpose" 
                                SortExpression="Purpose" />
                        </Columns>
                        <EditRowStyle CssClass="EditRowStyle" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="RowStyle" />
                        <SelectedRowStyle CssClass="SelectedRowStyle" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="Jct_Guest_Internet_Request_Report" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="txtDateFrom" DefaultValue="01/01/2012" 
                                Name="DateFrom" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtDateTo" DefaultValue="01/01/2020" 
                                Name="DateTo" PropertyName="Text" Type="DateTime" />
                            <asp:ControlParameter ControlID="txtmobile" DefaultValue="All" Name="Mobile" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtName" DefaultValue="All" Name="Name" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtCompany" DefaultValue="All" Name="Company" 
                                PropertyName="Text" Type="String" />
                            <asp:ControlParameter ControlID="txtVisitingEmployee" DefaultValue="All" 
                                Name="Visiting_Employee" PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td style="width: 80px">
                &nbsp;</td>
            <td style="width: 109px">
                &nbsp;</td>
            <td style="width: 126px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 80px">
                &nbsp;</td>
            <td style="width: 109px">
                &nbsp;</td>
            <td style="width: 126px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

