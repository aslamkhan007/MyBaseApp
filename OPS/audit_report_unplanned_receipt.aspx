<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="audit_report_unplanned_receipt.aspx.cs" Inherits="OPS_audit_report_unplanned_receipt" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table class="mytable">
    <tr>
        <td class="tableheader" colspan="4">
            GroupWise Unplanned Receipt</td>
    </tr>
    </table>
    <table  class="mytable">
    <tr>
        <td>
            Date From</td>
        <td style="width: 217px">
            <asp:TextBox ID="txtdatefrm" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
            <cc1:CalendarExtender ID="txtdatefrm_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtdatefrm">
            </cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                           <cc1:MaskedEditExtender ID="MEE6" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtdatefrm">
                                                </cc1:MaskedEditExtender>
        &nbsp;<cc1:MaskedEditValidator ID="MEV6" runat="server" ControlExtender="MEE6" ControlToValidate="txtdatefrm"
                                                    ValidationGroup="A" Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False" EmptyValueMessage="*"
                                                    TooltipMessage="DD/MM/YYYY" Width="114px">
                                                
                                                </cc1:MaskedEditValidator> 
        </td>
        <td>
            Date To</td>
        <td>
            <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox" Width="70px"></asp:TextBox>
            <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtdateto">
            </cc1:CalendarExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                          <cc1:MaskedEditValidator ID="MEV7" runat="server" ControlExtender="MEE7" ControlToValidate="txtdateto"
                                                    ValidationGroup="A" Display="Dynamic" InvalidValueMessage="Invalid" IsValidEmpty="False" EmptyValueMessage="*"
                                                    TooltipMessage="DD/MM/YYYY" Width="114px">
                                                
                                                </cc1:MaskedEditValidator>
                                                  <cc1:MaskedEditExtender ID="MEE7" runat="server" Mask="99/99/9999" MaskType="Date"
                                                    TargetControlID="txtdateto">
                                                </cc1:MaskedEditExtender>
                   
        </td>
    </tr>
    </table>
    <table class="mytable">
    <tr>
        <td colspan="4">
            <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                onclick="excel_Click" Width="32px" Visible="False"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td class="buttonbackbar" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                onclick="lnkfetch_Click" 
    ValidationGroup="A">Fetch</asp:LinkButton>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/loading.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Height="250px" ScrollBars="Both" 
                        Width="1050px">
                        <asp:GridView ID="grdDetail" runat="server" Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="GridHeader" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GridItem" />
                        </asp:GridView>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>

