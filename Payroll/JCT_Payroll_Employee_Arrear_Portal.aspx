<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="JCT_Payroll_Employee_Arrear_Portal.aspx.vb" Inherits="Payroll_JCT_Payroll_Employee_Arrear_Portal" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                Arrear Detail:</td>
        </tr>
        <tr>
            <td >
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
            </td>
        </tr>
    </table>
  <div style="font-family :Tahoma; font-size : 8pt; color:Red ">
    
    </div>

</asp:Content>
