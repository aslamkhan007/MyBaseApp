<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="PackingDelayStock.aspx.vb" Inherits="PackingDelayStock"
    Title="Packing Update Status Report" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
    <table style="width: 100%">
        <tr>
            <td class="tableheader" colspan="5">
                Packing Delay Reports
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td style="height: 11px; text-align: center;">
                <table  style="width:100%;">
                    <tr >
                        <td style="text-align: center; width: 81px;">
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="BtnGet" runat="server" BackColor="Black" 
    CssClass="ButtonBack" Text="Get"
                    ValidationGroup="A" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td style="text-align: left; width: 64px">
                            &nbsp;</td>
                        <td  style="text-align: left">
                                    &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 11px; text-align: center;">
                <br />
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <img alt="" src="../CostingSystemTest/Image/loading.gif" style="width: 70px; height: 10px" />
                        &nbsp;
                        <asp:Label ID="Label2" runat="server" ForeColor="#FF3300" Text="Please Wait..."></asp:Label>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
   
</asp:Content>
