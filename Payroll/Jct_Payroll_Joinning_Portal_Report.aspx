<%@ Page Title="" Language="VB" MasterPageFile="~/Payroll/MasterPage.master" AutoEventWireup="false" CodeFile="Jct_Payroll_Joinning_Portal_Report.aspx.vb" Inherits="Payroll_Jct_Payroll_Joinning_Portal_Report" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="2"  class="tableheader" >
                <asp:Label ID="Label16" runat="server" Text="New Joinees"></asp:Label>
            </td>
        </tr>
        <tr>
            <td  class="NormalText" style="width: 85%" >
                <asp:DetailsView ID="DetailsView1" runat="server" AllowPaging="True" 
                     GridLines="None" CssClass="GridViewStyle" Width="100%">
                     <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:DetailsView>
            </td>
            <td colspan="1"  class="NormalText" style="width:15%" >
                <asp:Image ID="PictureBox1" runat="server" BorderStyle="None" Height="200px" ImageAlign="Middle"
                    ImageUrl="Image/2.JPG" Width="150px" /></td>
        </tr>
        </table>
</asp:Content>

