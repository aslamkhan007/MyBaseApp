<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="MyActions.aspx.vb" Inherits="Default6" title="My Action Area" %>

<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%">
        <tr>
            <td class="tableheader"   style="text-align:left" >
                <asp:Label ID="Label5" runat="server"   Text="My Action Area"  Width="328px"></asp:Label></td>
            <td class="tableheader"   style="text-align:left" >
                <asp:Label ID="Label7" runat="server" Text="Status:"></asp:Label></td>
            <td class="tableheader"   style="text-align:left" >
                <asp:DropDownList ID="DrpLvStatus" runat="server" AutoPostBack="True"  
                          Width="104px" CssClass="combobox">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>All</asp:ListItem>
                    <asp:ListItem>ReAssigned</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                    <asp:ListItem>Closed</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="3" class="buttonbackbar"   style="text-align:left" >
                <asp:Label ID="Label1" runat="server" Text="My External Tasks" Width="202px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3">
                <ew:collapsablepanel id="PnlExtTasks" CssClass="panelcells" runat="server" height="150px" scrollbars="Vertical" width="100%" CollapseImageUrl="Image/UPARROW.JPG" CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG">
                    <asp:GridView id="GridExtTask" runat="server"   CssClass="GridViewStyle" GridLines="None"    Width="100%"  >
                   <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
 </asp:GridView>




</ew:collapsablepanel>
            </td>
        </tr>
        <tr>
            <td   colspan="3" class="buttonbackbar"   style="text-align:left" >
                <asp:Label ID="Label3" runat="server" Text="My Internal Tasks"  Width="184px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" class="textcells">
                <ew:collapsablepanel id="PnlIntTasks" runat="server" CssClass="panelcells" height="150px" scrollbars="Vertical"
                    width="100%" CollapseImageUrl="Image/UPARROW.JPG" CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG">
                    <asp:GridView id="GridIntTask" runat="server"  CssClass="GridViewStyle" GridLines="None"    Width="100%"  >
                   <RowStyle CssClass="RowStyle" />

    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
</asp:GridView>
</ew:collapsablepanel>
            </td>
        </tr>
        <tr>
            <td   colspan="3" class="buttonbackbar"   style="text-align:left" >
                <asp:Label ID="Label4" runat="server" Text="Task(s) Assigned By Me" Width="184px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" class="textcells">
                <ew:collapsablepanel id="PnlAssgnBy" runat="server" height="150px" scrollbars="Vertical"
                    width="100%" CollapseImageUrl="Image/UPARROW.JPG" CollapserAlign="Left" ExpandImageUrl="Image/DNARROW.JPG">
                    <asp:GridView id="GrdAssBy" runat="server" GridLines="None"    CssClass="GridViewStyle">
            <RowStyle CssClass="RowStyle" />           
    <EmptyDataRowStyle CssClass="EmptyRowStyle" />

    <PagerStyle CssClass="PagerStyle" />

    <SelectedRowStyle CssClass="SelectedRowStyle" />

    <HeaderStyle CssClass="HeaderStyle" />

    <EditRowStyle CssClass="EditRowStyle" />

    <AlternatingRowStyle CssClass="AltRowStyle" />
                </asp:GridView>
                </ew:CollapsablePanel>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 115px">
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 115px">
            </td>
        </tr>
    </table>
</asp:Content>

