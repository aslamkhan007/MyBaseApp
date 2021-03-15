<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="asset_history_report.aspx.cs" Inherits="AssetMngmnt_asset_history_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
               Asset History Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                Asset Type</td>
           <td class="NormalText" style="width: 196px">
            <asp:DropDownList ID="ddlassettype" runat="server" CssClass="combobox"  DataSourceID="SqlDataSource4"
                AutoPostBack="True" onselectedindexchanged="ddlassettype_SelectedIndexChanged"
                DataTextField="asset_type_name" DataValueField="asset_type_id" 
                   AppendDataBoundItems="True">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT b.asset_type_name,b.asset_type_id FROM dbo.jct_asset_type_master b JOIN jct_asset_master a ON a.asset_id=b.asset_id and a.status=b.status   WHERE  a.status='A'">
           
            </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                <asp:Label ID="lbitemId" runat="server" Text="Item ID" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtitemID" runat="server" CssClass="textbox" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Jct SrNo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtsrno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Computer Name</td>
            <td class="NormalText">
                <asp:TextBox ID="txtcompname" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Date From</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdatefrm" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdatefrm_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdatefrm">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText">
                Date To</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
              <td class="NormalText" colspan="4" >
                  <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both" 
                      Width="950px">
                      <asp:GridView ID="grdDetail" runat="server"  OnRowDataBound="grdDetail_RowDataBound" 
                    Width="100%">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <HeaderStyle CssClass="HeaderStyle" />
                          <PagerStyle CssClass="PageStyle" />
                          <RowStyle CssClass="GirdItem" />
                      </asp:GridView>
                  </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>

