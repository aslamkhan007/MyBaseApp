<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="outsourced_jobwork_reqauth.aspx.cs" Inherits="OPS_outsourced_jobwork_reqauth" %>

<%@ Register assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" namespace="System.Web.UI.WebControls" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
    <tr>
        <td class="tableheader" colspan="2">
            Job Work Freeze Request</td>
    </tr>
    <tr>
        <td class="BoundColumn_long" style="width: 155px">
            RequestID</td>
        <td>
            <asp:DropDownList ID="ddlreqid" runat="server" 
                DataSourceID="SqlDataSource1" DataTextField="reqid" DataValueField="reqid" 
                AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT  DISTINCT reqid FROM  jct_ops_outsourced_job_work  where status='A'">
            </asp:SqlDataSource>
        </td>
    </tr>
    <table class="mytable">
    <tr>
        <td colspan="2">
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="grdDetail" runat="server" Width="100%" 
                    EnableModelValidation="True">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <HeaderTemplate>
                                <asp:CheckBox ID="chksel" runat="server" AutoPostBack="True" 
                                    oncheckedchanged="chksel_CheckedChanged" Text="SelectAll" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="chk" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle CssClass="GridHeader" />
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>
    </table>
    <table class="mytable"
      <tr>
        <td colspan="2" class="buttonbackbar">
            <asp:LinkButton ID="lnkauth" runat="server" CssClass="buttonc" 
                onclick="lnkauth_Click" Visible="False">Authorize</asp:LinkButton>
          </td>
    </tr>
    </table>
</asp:Content>

