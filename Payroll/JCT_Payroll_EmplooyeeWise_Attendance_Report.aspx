<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="JCT_Payroll_EmplooyeeWise_Attendance_Report.aspx.vb" Inherits="Payroll_JCT_Payroll_EmplooyeeWise_Attendance_Report" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                Attendence Status:</td>
        </tr>
                                <tr>
            <td class="labelcells">
                Effective From
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtefffrm" runat="server" CssClass="textbox" AutoPostBack="True" ontextchanged="txtefffrm_TextChanged"
                    ></asp:TextBox>
                <cc1:calendarextender ID="txtefffrm_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txtefffrm">
                </cc1:calendarextender>
            </td>
            <td class="labelcells">
                Effective To
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txteffto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:calendarextender ID="txteffto_CalendarExtender" runat="server" Enabled="True"
                    TargetControlID="txteffto">
                </cc1:calendarextender>
            </td>
        </tr>
                <tr>
            <td class="buttonbackbar" colspan="4">                
                <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" OnClick="lnksave_Click"
                    ValidationGroup="A">Fetch</asp:LinkButton>
                
            </td>
        </tr>
        <tr>
            <td >
    <%--<asp:GridView ID="GridView1" runat="server"   Width="100%" 
                    PageSize="15"  CssClass="GridViewStyle"  GridLines="None" >
            <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>--%>
            </td>
        </tr>
    </table>
    <asp:GridView ID="GridView1" runat="server"   Width="100%" 
                    PageSize="15"  CssClass="GridViewStyle"  GridLines="None" >
            <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
    </asp:GridView>
  <div style="font-family :Tahoma; font-size : 8pt; color:Red ">
    
    </div>

</asp:Content>
