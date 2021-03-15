<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="News.aspx.vb" Inherits="Default6" title="JCt News" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                <table style="width: 85%">
                    <tr>
                        <td colspan="2" class="tableheader">
                            <asp:Label ID="Label1" runat="server" Text="JCT News" Width="75px"></asp:Label></td>
                    </tr>
                    <tr>
                        <td class="labelcells" style="width: 11%">
                            <asp:Label ID="Label2" runat="server" Text="Department" Width="72px"></asp:Label></td>
                        <td class="textcells">
                <asp:DropDownList ID="DDL1" runat="server" AutoPostBack="True" DataSourceID="Department"
                    DataTextField="deptname" DataValueField="deptname" Width="291px" CssClass="combobox">
                </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td  class="labelcells" style="width: 11%" >
                            <asp:Label ID="Label3" runat="server" Text="News Type" Width="67px"></asp:Label></td>
                        <td class="textcells">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="190px" AutoPostBack="True">
                    <asp:ListItem Value="0" Selected="True">Internal</asp:ListItem>
                    <asp:ListItem Value="1">External</asp:ListItem>
                </asp:RadioButtonList></td>
                    </tr>
                    <tr>
                        <td style="width: 11%; height: 15px;
                            text-align: left" valign="top" class="labelcells">
                            <asp:Label ID="Label4" runat="server"  
                                 Text="List of News" Width="69px"></asp:Label></td>
                        <td >
                            <asp:Panel ID="Panel1" runat="server" CssClass="panelcells" Height="100px" HorizontalAlign="Left" Width="100%"   ScrollBars="Vertical">
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" valign="top">
                            &nbsp;</td>
                    </tr>
                </table>
    <asp:SqlDataSource ID="Department" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
        
                    SelectCommand="select distinct a.DEPartment + ' - ' + b.DEPTNAME AS 'deptname' from jctdev..jct_empg_news a , JCTDEV.. DEPTMAST b where (Company_Code = @cc) and a.department=b.deptcode &#13;&#10;" 
                    ProviderName="<%$ ConnectionStrings:misjctdev.ProviderName %>">
           
                    <SelectParameters>
                        <asp:SessionParameter Name="cc" SessionField="Companycode" />
                    </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>


