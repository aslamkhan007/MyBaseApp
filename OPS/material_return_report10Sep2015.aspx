<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="material_return_report.aspx.cs" Inherits="OPS_material_return_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Material Return Report</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
                    RepeatDirection="Horizontal" AutoPostBack="True">
                    <asp:ListItem Value="I" Selected="True">Invoive Date</asp:ListItem>
                    <asp:ListItem Value="R">Request Date</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lbdatefrm" runat="server" Text="Invoice Date From"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdatefrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrom_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrom">
                </cc1:CalendarExtender>
            </td>
            <td>
                <asp:Label ID="lbdateto" runat="server" Text="Invoice DateTo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td>
                Customer</td>
            <td>
                <asp:TextBox ID="txtcustomer"     runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="TextBox1_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" 
                            MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                </cc1:AutoCompleteExtender>
            </td>
            <td>
                Req Raised By</td>
            <td>
                <asp:TextBox ID="txtreqraised" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="TextBox2_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                            MinimumPrefixLength="1" ServiceMethod="GetEmployee_OPS" 
                            ServicePath="~/WebService.asmx" TargetControlID="txtreqraised">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td>
                Reason</td>
            <td>
                <asp:DropDownList ID="ddlreason" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="reason" 
                    DataValueField="reason" CssClass="combobox">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT '' AS reason UNION SELECT  REASON FROM JCT_OPS_SANCTION_NOTE_MATERIAL_RETURN_REASONS WHERE STATUS='A'">
                </asp:SqlDataSource>
            </td>
            <td>
                Status</td>
            <td>
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="C">Cancel</asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                    <asp:ListItem Value="D">Deleted</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                    onclick="lnkexcel_Click">Excel</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" 
                    onclick="lnkreset_Click">Reset</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="4">
              <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="400px">
                    <asp:GridView ID="grdDetail2" runat="server" 
                  
                      >
                          <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

