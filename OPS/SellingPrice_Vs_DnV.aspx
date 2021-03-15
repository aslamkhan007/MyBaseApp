<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="SellingPrice_Vs_DnV.aspx.cs" Inherits="OPS_SellingPrice_Vs_DnV" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                <asp:Label ID="Label16" runat="server" Text="Selling price Vs DnV"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label17" runat="server" Text="Create/Amend Dt From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 123px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
              
            </td>
            <td class="NormalText" style="width: 73px">
                <asp:Label ID="Label18" runat="server" Text="Create/Amend Dt To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
             
            </td>
        </tr>
          <tr>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label21" runat="server" Text="Delivery Dt From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 123px">
                <asp:TextBox ID="txtDelDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDelDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDelDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 100px">
                <asp:Label ID="Label22" runat="server" Text="Delivery Dt To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtDelDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDelDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDelDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label23" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 123px">
                <asp:DropDownList ID="ddlPlant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>TAFFETA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 73px">
                <asp:Label ID="Label19" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtSort" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 95px">
                <asp:Label ID="Label20" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 123px">
                <asp:TextBox ID="txtOrderNo" runat="server" Columns="25" CssClass="textbox" 
                    MaxLength="25"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 73px">
                &nbsp;</td>
            <td class="NormalText">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" 
                    onclick="lnkExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
    </table>
    <table style="width:100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Width="1000px" ScrollBars="Auto">
                           <telerik:RadGrid ID="grdDetail" runat="server" CellSpacing="0" GridLines="None">
                            </telerik:RadGrid>
                            <%--<asp:GridView ID="grdDetail" runat="server" AllowPaging="True" 
                                EmptyDataText="No data Available" 
                                onpageindexchanging="grdDetail_PageIndexChanging" Width="100%" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="GridHeader" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>--%>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    
</asp:Content>

