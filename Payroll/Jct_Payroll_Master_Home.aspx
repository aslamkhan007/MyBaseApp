﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="true"
    CodeFile="Jct_Payroll_Master_Home.aspx.cs" Inherits="Payroll_Jct_Payroll_Master_Home" %>

<%@ Register Assembly="FlashControl" Namespace="Bewise.Web.UI.WebControls" TagPrefix="Bewise" %>
<%@ Register Assembly="obout_Show_Net" Namespace="OboutInc.Show" TagPrefix="obshow" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Master Data
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
