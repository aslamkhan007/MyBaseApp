<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" Theme="OpsSkinFile" AutoEventWireup="false" CodeFile="Printing_Cost_Entry.aspx.vb" Inherits="OPS_Printing_Cost_Entry" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Printing Cost Entry</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 161px">
                <asp:Label ID="Label1" runat="server" Text="Printing Type"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPrintingType" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 161px">
                <asp:Label ID="Label2" runat="server" Text="Sort"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtSort" runat="server" Width="60px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="width: 161px">
                <asp:Label ID="Label3" runat="server" Text="Cost"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtCost" runat="server" MaxLength="7" Width="60px"></asp:TextBox>
                <cc1:FilteredTextBoxExtender ID="TxtCost_FilteredTextBoxExtender" 
                    runat="server" Enabled="True" TargetControlID="TxtCost" 
                    ValidChars="0123456789.">
                </cc1:FilteredTextBoxExtender>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
      
        <tr>
            <td align="center" class="tableback" colspan="4" style="text-align: center" 
                valign="middle">
                <asp:LinkButton ID="CmdApply" runat="server" CssClass="buttonc">Apply</asp:LinkButton>
            &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;">
        <tr>
            <td style="width: 161px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                        <asp:Panel ID="Panel2" runat="server" Height="300px" ScrollBars="Vertical" 
                            Width="98%">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                SelectCommand="SELECT  ParameterCode as Category,Sort ,Cost ,Convert(varchar(10),Eff_From,101) EffectiveFrom ,Convert(varchar(10),Eff_To,101) as EffectiveTo FROM JCt_OPS_Printing_Cost_TBL order by Sort">
                            </asp:SqlDataSource>
                          <%--  <asp:GridView ID="GrdDetail" runat="server" AlternatingRowStyle-CssClass="AltRowStyle"
                                AutoGenerateColumns="True" CssClass="GridViewStyle" EnableModelValidation="True"
                                FooterStyle-CssClass="SelectedRowStyle" GridLines="None" HeaderStyle-CssClass="HeaderStyle"
                                PagerStyle-CssClass="PagerStyle" RowStyle-CssClass="RowStyle" Width="100%">
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                                <FooterStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                            </asp:GridView>--%>
                              <asp:GridView ID="GrdDetail" runat="server" AlternatingRowStyle-CssClass="AltRowStyle"
                                AutoGenerateColumns="True"  EnableModelValidation="True"
                                 GridLines="None" 
                                 Width="100%">
                               
                            </asp:GridView>
                        </asp:Panel>
                    </td>
        </tr>
        <tr>
            <td style="width: 161px">
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

