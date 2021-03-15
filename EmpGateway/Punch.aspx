<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false"
    CodeFile="Punch.aspx.vb" Inherits="Punch" Title="Punch Record" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
// <!CDATA[



// ]]>
    </script>

    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label1" runat="server" Text="Punch Record"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <table style="width:100%;">
                    <tr>
                        <td colspan="4">
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </cc1:ToolkitScriptManager>
                        </td>
                        <td style="width: 335px">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td CLASS="labelcells">
                            Date From</td>
                        <td CLASS="textcells">
                <ew:CalendarPopup ID="LeaveFrom" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="80px" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
                        </td>
                        <td CLASS="labelcells">
                            Date To</td>
                        <td CLASS="textcells">
                <ew:CalendarPopup ID="LeaveTo" runat="server" Culture="English (United Kingdom)"
                    Text="..." Width="80px" CssClass="textbox">
                    <ClearDateStyle BackColor="#E0E0E0" />
                    <DayHeaderStyle BackColor="OrangeRed" />
                    <MonthYearSelectedItemStyle BackColor="Silver" />
                    <TodayDayStyle BackColor="#FFC0C0" />
                    <MonthHeaderStyle BackColor="Gray" />
                    <GoToTodayStyle BackColor="#E0E0E0" />
                </ew:CalendarPopup>
                        </td>
                        <td CLASS="textcells">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtEmpName" runat="server" CssClass="textbox" MaxLength="30" 
                            Width="100%" AutoPostBack="True"></asp:TextBox>
                            <asp:TextBox ID="txtDeptEmpName" runat="server" CssClass="textbox" MaxLength="30" 
                            Width="100%" AutoPostBack="True"></asp:TextBox>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100"
                            CompletionListCssClass="autocomplete_ListItem " ContextKey="JCT00LTD" MinimumPrefixLength="0"
                            ServiceMethod="GetEmployeeName" ServicePath="~/WebService.asmx" 
                            TargetControlID="txtEmpName" FirstRowSelected="True">
                        </cc1:AutoCompleteExtender>
                        <cc1:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100"
                            CompletionListCssClass="autocomplete_ListItem " ContextKey="JCT00LTD" MinimumPrefixLength="0"
                            ServiceMethod="GetDeptEmployeeName" ServicePath="~/WebService.asmx" 
                            TargetControlID="txtDeptEmpName" FirstRowSelected="True">
                        </cc1:AutoCompleteExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>


                        </td>
                        <td>
                <asp:Button ID="BtnGet" runat="server" Text="View Report" CssClass="ButtonBack" BackColor="Black" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="panelcells">
                
              <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                      GridLines="None" Width="100%" CssClass="GridViewStyle" 
        AutoGenerateColumns="False" PageSize="31">
                 
    <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

                    <Columns>
                        <asp:BoundField DataField="Date" HeaderText="Date (MM/DD/YYYY)" />
                        <asp:BoundField DataField="I Punch" HeaderText="I Punch" />
                        <asp:BoundField DataField="II Punch" HeaderText="II Punch" />
                        <asp:BoundField DataField="III Punch" HeaderText="III Punch" />
                        <asp:BoundField DataField="IV Punch" HeaderText="IV Punch" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                       <asp:TemplateField HeaderText="Apply Leave">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server"   CommandName="Select"
                                    >Apply Leave</asp:LinkButton>
                                <asp:Label ID="Lblapplied" runat="server" ForeColor="Maroon" Text="Applied"></asp:Label>
                                &nbsp;<asp:LinkButton ID="Leave_Status" runat="server" 
                                    PostBackUrl="Default2.aspx" ToolTip="Click Here To See Leave Status">(Check 
                                Leave Status)</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />


                </asp:GridView>
            </td>
        </tr>
        
    </table>
     
</asp:Content>
