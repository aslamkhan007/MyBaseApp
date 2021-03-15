<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="Calendar.aspx.vb" Inherits="Default4" title="Holiday Calendar" MaintainScrollPositionOnPostback="true" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td class="tableheader">
                Holiday Calendar</td>
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
    Note: Republic Day and Shri Krishan Janamashtami fall on Sunday. Holidays in lieu thereof 
    will be observed on 08.04.2014 and 14.04.2014 on account of Ram Navami and Baisakhi respectively.
    </div>

</asp:Content>

