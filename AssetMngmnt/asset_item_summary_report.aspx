<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="asset_item_summary_report.aspx.cs" Inherits="AssetMngmnt_asset_item_summary_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <table style="width: 100%" >
        <tr>
        <td>
            <asp:Panel ID="Panel2" runat="server" 
                    Visible="true" Width="400px">
    <asp:GridView ID="grdDetail" runat="server"
                    Width="100%" 
                  >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                       </asp:Panel>
                       </td>
                       <td>
                        <asp:Panel ID="Panel1" runat="server" 
                    Visible="true" Width="400px">
    <asp:GridView ID="grdDetail2" runat="server"
                    Width="100%" 
                  >
                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                        <RowStyle CssClass="GridItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                       </asp:Panel>
                       </td>
                       </tr>
                       </table>
</asp:Content>

