<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true" CodeFile="Jct_Payroll_Encashments_Reports_Home.aspx.cs" Inherits="Payroll_Jct_Payroll_Encashments_Reports_Home" %>


<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>
<%@ Register Assembly="obout_Show_Net" Namespace="OboutInc.Show" TagPrefix="obshow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                  Encashments Reports
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td colspan="2">
                <asp:DataList ID="DataList1" runat="server">
                    <ItemTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td class="labelcells">
                                    <asp:Image ID="Image1" runat="server" Height="17px" ImageUrl="~/Image/t.bmp" Width="22px" />
                                </td>
                                <%--<td align="center">--%>
                                <td class="FormatLeft">
                                    <asp:LinkButton ID="lnkemail" runat="server" OnClick="OnClickHandler" Text='<%# Eval("MenuName") %>'></asp:LinkButton>
                                </td>
                                <td width="200px" class="NormalText">
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
    <table class="mytable">
        <tr>
            <td class="buttonbackbar">
            </td>
        </tr>
    </table>
</asp:Content>


<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="100%" cellpadding="0" cellspacing="0" style="height: 100%">
        <tr>
            <td class="tableheader" colspan="2">
                Encashments Reports
            </td>
        </tr>
        <tr>
            <td id="=" align="left" style="width: 517px; height: 20px;" valign="top">
                <asp:Image ID="Image1" runat="server" Height="17px" ImageUrl="~/Image/t.bmp" Width="22px" />
                <asp:Image ID="Image13" runat="server" Height="16px" ImageUrl="~/Image/qm.bmp" Width="16px" />&nbsp;<asp:LinkButton
                    ID="LblPersonal" runat="server" Font-Size="8pt" ForeColor="Red" Height="16px"
                    Width="140px" Font-Names="Tahoma" PostBackUrl="Jct_Payroll_Conveyance_Report.aspx">Conveyance Report:</asp:LinkButton>
                <br />
                <asp:Image ID="Image2" runat="server" Height="17px" ImageUrl="~/Image/t.bmp" Width="22px" /><asp:Image
                    ID="Image14" runat="server" Height="16px" ImageUrl="~/Image/qm.bmp" Width="16px" />&nbsp;<asp:LinkButton
                        ID="LblQualification" runat="server" Font-Size="8pt" Height="17px" ForeColor="Red"
                        Font-Names="Tahoma" PostBackUrl="Jct_Payroll_Conveyance_Payment_Detail.aspx">Conveyance Payment Detail:</asp:LinkButton>
                <br />
                <asp:Image ID="Image3" runat="server" Height="17px" ImageUrl="~/Image/t.bmp" Width="22px" /><asp:Image
                    ID="Image15" runat="server" Height="16px" ImageUrl="~/Image/qm.bmp" Width="16px" />&nbsp;<asp:LinkButton
                        ID="LblExperience" runat="server" Font-Size="8pt" ForeColor="Red" Height="17px"
                        Width="125px" Font-Names="Tahoma" PostBackUrl="Jct_Payroll_Conveyance_Voucher_Report.aspx">Conveyance Voucher:</asp:LinkButton>
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>--%>
