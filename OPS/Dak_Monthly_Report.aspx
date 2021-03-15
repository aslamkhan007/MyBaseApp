<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Dak_Monthly_Report.aspx.cs" Inherits="OPS_Dak_Monthly_Report" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Dak Monthly Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                From Date</td>
            <td class="NormalText">
                
                <asp:TextBox ID="txtFrom" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtFrom">
                </cc1:CalendarExtender>
                
            </td>
            <td class="NormalText">
                ToDate</td>
            <td class="NormalText">
          

                

             

                 
                <asp:TextBox ID="txtTo" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
                <cc1:CalendarExtender ID="txtTo_CalendarExtender" runat="server" 
                    TargetControlID="txtTo">
                </cc1:CalendarExtender>
          

                

             

                 
        </tr>
        <tr>
            <td class="NormalText">
                Dak&nbsp; Status</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlDakStatus" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem Value="False">Pending</asp:ListItem>
                    <asp:ListItem Value="True">Recieved</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                </td>
            <td class="NormalText">
                </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                    onclick="lnkexcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
              <%--<asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="200px">--%>
                <asp:GridView ID="grdDetail" runat="server"  
                    Width="100%" AllowPaging="True" 
                    onpageindexchanging="grdDetail_PageIndexChanging" PageSize="15" 
                     >
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            <%--</asp:Panel>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

