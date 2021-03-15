<%@ Page Title="" Language="VB" MasterPageFile="~/User_Screen.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 650px; height: 107px;" border="2">
        <tr>
            <td class="tableheader" colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 81px">
                <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="textcells" width="30%">
                <asp:DropDownList runat="server" CssClass="combobox" Height="16px" 
                    Width="138px" ID="DrpDept" DataSourceID="SqlDataSource1" 
                    DataTextField="deptname" DataValueField="deptname">
                </asp:DropDownList>
            </td>
            <td class="labelcells" width="20%">
                <asp:Label ID="Label2" runat="server" Text="Employee"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox ID="txtEmp" runat="server" CssClass="textbox" Height="16px" 
                    Width="161px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="ACE1" runat="server" CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                    ServiceMethod="GetEmpName" ServicePath="WebService.asmx" 
                    TargetControlID="txtEmp">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 81px">
                <asp:Label ID="Label3" runat="server" Text="Date Added"></asp:Label>
            </td>
            <td class="textcells" width="30%">
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" Height="16px" 
                    Width="82px"></asp:TextBox>
                <cc1:CalendarExtender ID="CC2" runat="server" Format="MM/dd/yyyy" 
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells" width="20%">
                <asp:Label runat="server" Text="File Type" ID="Label4"></asp:Label>
            </td>
            <td class="textcells">
        <asp:TextBox ID="txtFileType" runat="server" CssClass="textbox" Height="16px" 
                                            Width="173px" AutoPostBack="True"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="ACECatg" runat="server" CompletionInterval="100" 
                                    CompletionListCssClass="autocomplete_ListItem " 
                                    MinimumPrefixLength="0" ServiceMethod="GetParentCatg" ServicePath="WebService.asmx" 
                                            TargetControlID="txtFileType">
        </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 81px">
                <asp:Label ID="Label5" runat="server" Text="Key Info"></asp:Label>
            </td>
            <td class="textcells" colspan="3" width="30%">
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" Width="365px" 
                    ID="txtKeyInfo" Font-Names="Verdana" Font-Size="8pt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 81px">
                <asp:Label ID="Label6" runat="server" Text="Pages Count"></asp:Label>
            </td>
            <td class="textcells" width="30%">
                <asp:TextBox runat="server" CssClass="textbox" Width="75px" ID="txtPgNo"></asp:TextBox>
            </td>
            <td class="labelcells" width="20%">
                <asp:Label runat="server" Text="Amt Involved" ID="Label11"></asp:Label>
            </td>
            <td class="textcells">
                <asp:TextBox runat="server" CssClass="textbox" Height="16px" Width="105px" 
                    ID="txtAmt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <table border="2" cellpadding="2" cellspacing="2" style="width:100%;">
                    <tr>
                        <td class="labelcells" style="width: 20%">
                            <asp:Label runat="server" Text="File RefNo." ID="Label12"></asp:Label>
                        </td>
                        <td class="textbox" style="width: 30%">
                            <asp:TextBox runat="server" CssClass="textbox" ID="txtFileRef"></asp:TextBox>
                        </td>
                        <td class="labelcells" style="width: 19%">
                            <asp:Label runat="server" Text="File RefDate" ID="Label13"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="textbox" Width="73px" ID="txtRefDate"></asp:TextBox>
                            <cc1:CalendarExtender ID="CC1" runat="server" 
                                TargetControlID="txtRefDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <table border="2" cellpadding="2" cellspacing="2" style="width:100%;">
                    <tr>
                        <td class="labelcells" width="20%">
                            <asp:Label runat="server" Text="File Name" ID="Label14"></asp:Label>
                        </td>
                        <td class="textbox" width="30%">
                            <asp:TextBox runat="server" CssClass="textbox" ID="txtFileName"></asp:TextBox>
                        </td>
                        <td class="labelcells" width="20%">
                            <asp:Label runat="server" Text="File Description" ID="Label15"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFileDesc" runat="server" CssClass="textbox" Width="151px" 
                                Height="16px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 81px">
                &nbsp;</td>
            <td class="textcells" width="30%">
                &nbsp;</td>
            <td class="labelcells" width="20%">
                <asp:LinkButton ID="LnkSearch" runat="server" CssClass="buttonc" 
                    Height="23px" Width="83px">Search</asp:LinkButton>
            </td>
            <td class="textcells">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <asp:Panel ID="PnlSearch" runat="server">
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 81px; height: 23px">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select deptname from deptmast where company_code='jct00ltd' order by deptname">
                </asp:SqlDataSource>
            </td>
            <td class="textcells" width="30%" style="height: 23px">
                </td>
            <td class="labelcells" width="20%" style="height: 23px">
                </td>
            <td class="textcells" style="height: 23px">
                </td>
        </tr>
    </table>
</asp:Content>

