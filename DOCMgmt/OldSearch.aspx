<%@ Page Title="" Language="VB" MasterPageFile="User_Screen.master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 107px;">
        <tr>
            <td class="tableheader" colspan="4">
                Search File</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label1" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                <asp:DropDownList runat="server" CssClass="combobox" Height="16px" 
                    Width="150px" ID="DrpDept" DataSourceID="SqlDataSource1" 
                    DataTextField="deptname" DataValueField="deptname">
                </asp:DropDownList>
            </td>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label17" runat="server" Text="Employee"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                <asp:TextBox ID="txtEmp" runat="server" CssClass="textbox" 
                    Width="169px"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="ACE2" runat="server" CompletionInterval="100" 
                    CompletionListCssClass="autocomplete_ListItem " MinimumPrefixLength="0" 
                    ServiceMethod="GetEmpName" ServicePath="WebService.asmx" 
                    TargetControlID="txtEmp">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label3" runat="server" Text="Date Added"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                <asp:TextBox ID="txtDate" runat="server" CssClass="textbox" 
                    Width="71px"></asp:TextBox>
                <cc1:CalendarExtender ID="CC3" runat="server" Format="MM/dd/yyyy" 
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells" style="width: 100px">
                <asp:Label runat="server" Text="File Type" ID="Label19"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
        <asp:TextBox ID="txtFileType" runat="server" CssClass="textbox" 
                                            Width="173px" AutoPostBack="True"></asp:TextBox>
        <cc1:AutoCompleteExtender ID="ACECatg0" runat="server" CompletionInterval="100" 
                                    CompletionListCssClass="autocomplete_ListItem " 
                                    MinimumPrefixLength="0" ServiceMethod="GetParentCatg" ServicePath="WebService.asmx" 
                                            TargetControlID="txtFileType">
                </cc1:AutoCompleteExtender>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label5" runat="server" Text="Key Info"></asp:Label>
            </td>
            <td class="textcells" colspan="3">
                <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" Width="451px" 
                    ID="txtKeyInfo" Font-Names="Verdana" Font-Size="8pt" Height="50px" 
                    Wrap="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 100px">
                <asp:Label ID="Label6" runat="server" Text="Pages Count"></asp:Label>
            </td>
            <td class="textcells" style="width: 150px">
                <asp:TextBox runat="server" Width="60px" ID="txtPgNo" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="labelcells" style="width: 100px">
                <asp:Label runat="server" Text="Amt Involved" ID="Label11"></asp:Label>
            </td>
            <td class="textcells" style="width: 250px">
                <asp:TextBox runat="server" CssClass="textbox" Width="64px" 
                    ID="txtAmt"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <table cellpadding="2" cellspacing="2" 
                    style="border: 2px solid #000000; width:100%;">
                    <tr>
                        <td class="labelcells" style="width: 17%">
                            <asp:Label runat="server" Text="File RefNo." ID="Label23"></asp:Label>
                        </td>
                        <td class="textbox" style="width: 25%">
                            <asp:TextBox runat="server" CssClass="textbox" ID="txtFileRef"></asp:TextBox>
                        </td>
                        <td class="labelcells" style="width: 16%">
                            <asp:Label runat="server" Text="File RefDate" ID="Label24"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="textbox" Width="65px" ID="txtRefDate"></asp:TextBox>
                            <cc1:CalendarExtender ID="CC4" runat="server" 
                                TargetControlID="txtRefDate">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <table cellpadding="2" cellspacing="2" 
                    style="border: 2px solid #000000; width:100%;">
                    <tr>
                        <td class="labelcells" style="width: 17%">
                            <asp:Label runat="server" Text="File Name" ID="Label25"></asp:Label>
                        </td>
                        <td class="textbox" style="width: 25%">
                            <asp:TextBox runat="server" CssClass="textbox" ID="txtFileName"></asp:TextBox>
                        </td>
                        <td class="labelcells" style="width: 16%">
                            <asp:Label runat="server" Text="File Description" ID="Label26"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFileDesc" runat="server" CssClass="textbox" Width="151px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="text-align: right;" colspan="4" align="right">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" colspan="4">
                <asp:Panel ID="PnlSearch" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table style="width:100%;">
                                <tr>
                                    <td colspan="4">
                                        <asp:DataList ID="DataList1" runat="server" BorderStyle="Groove" 
                                            BorderWidth="2px" RepeatColumns="3" RepeatDirection="Horizontal" Width="100%">
                                            <EditItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                                            <ItemTemplate>
                                                <table style="width: 100%; height: 39px;" class="panelcells">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Image ID="Image4" runat="server" ImageUrl='<%# eval("imgurl") %>' 
                                                                Width="16px" />
                                                            <cc1:HoverMenuExtender ID="HoverMenuExtender1" runat="server" PopDelay="5" 
                                                                PopupControlID="Panel3" PopupPosition="Left" TargetControlID="Image4">
                                                            </cc1:HoverMenuExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:HyperLink ID="LnkFile" runat="server" NavigateUrl='<%# eval("url") %>' 
                                                                Text='<%# eval("name") %>'></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Panel ID="Panel3" runat="server" 
                                                                BorderStyle="Groove" BorderWidth="3px" CssClass="panelcells">
                                                                <table style="width:100%;">
                                                                    <tr>
                                                                        <td class="gridheader">
                                                                            <asp:Label ID="Label27" runat="server" Text='<%# eval("name") %>'></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Image ID="Image5" runat="server" ImageUrl='<%# eval("imgurl") %>' />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td class="labelcells" style="width: 24%">
                                                    <asp:CheckBox ID="chkAll" runat="server" Text="All Files" AutoPostBack="True" />
                                                    <asp:CheckBox ID="chkCatgWise" runat="server" Text="Category Wise" 
                                                        AutoPostBack="True" />
                                                </td>
                                                <td width="60%" align="left">
                                                    <asp:LinkButton ID="LnkSearch" runat="server" CssClass="buttonc" 
                                                        BorderStyle="None">Search</asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:DataList ID="DataList2" runat="server" RepeatColumns="5" 
                                                    RepeatDirection="Horizontal">
                                                    <ItemTemplate>
                                                        <table align="center" border="1" 
                                                            
                                                            style="border-style: groove; border-color: #C0C0C0; width:100%; background-color: #CCCCCC;" 
                                                            class="panelcells">
                                                            <tr>
                                                                <td align="center" style="text-align: center">
                                                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# eval("lnk") %>' 
                                                                        Text='<%# eval("Catg") %>'></asp:HyperLink>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="text-align: center">
                                                                    (<asp:HyperLink ID="HyperLink2" runat="server" Text='<%# eval("cnt") %>'></asp:HyperLink>
                                                                    )</td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        </table>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    
        SelectCommand="select '' as deptname union select deptname from deptmast where company_code='jct00ltd' order by deptname">
                </asp:SqlDataSource>
</asp:Content>

