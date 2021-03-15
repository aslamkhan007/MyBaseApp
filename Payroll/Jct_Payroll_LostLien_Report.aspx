<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_LostLien_Report.aspx.cs" Inherits="Payroll_Jct_Payroll_LostLien_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                LostLein/Restore Report:
            </td>
        </tr>
        </tr>
      
        <tr>
            <td class="labelcells">
                 From Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" 
                    ></asp:TextBox>
                <cc1:CalendarExtender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:CalendarExtender>
            </td>
            <td class="labelcells">
                 To Date
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txteffto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteffto">
                </cc1:CalendarExtender>
            </td>
        </tr>
    
        <tr>
            <td class="NormalText">
            </td>
            <td class="NormalText">
            </td>
            <td class="NormalText">
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonXL" Height="32px" Width="32px"
                    OnClick="lnkexcel_Click"></asp:LinkButton>
            </td>
            <td class="NormalText">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" CausesValidation="False"
                    ValidationGroup="A" OnClick="lnkreset_Click">Reset</asp:LinkButton>
                <asp:LinkButton ID="lnkreset0" runat="server" CssClass="buttonc" CausesValidation="False"
                    ValidationGroup="A" onclick="lnkreset0_Click" >Back</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" EnableModelValidation="True" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="Griditem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>


