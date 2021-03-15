<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="planning_summary_shortfall_report.aspx.cs" Inherits="OPS_planning_summary_shortfall_report" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                ShortFall Summary Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                Request ID</td>
            <td class="NormalText">
                <asp:TextBox ID="txtreqid" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">
                Reason</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlreason" runat="server" CssClass="combobox">

         
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Weaving</asp:ListItem>
                    <asp:ListItem>Weaving Prep</asp:ListItem>
                    <asp:ListItem>Shrinkage</asp:ListItem>
                    <asp:ListItem>Spinning</asp:ListItem>
                    <asp:ListItem>Processing</asp:ListItem>
                    <asp:ListItem>Planning</asp:ListItem>
                    <asp:ListItem>FOC</asp:ListItem>
                    <asp:ListItem>Burn</asp:ListItem>
                </asp:DropDownList>
      
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                DateFrom</td>
              <td class="NormalText" style="width: 170px; height: 25px;">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
              
                  <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                      Enabled="True" TargetControlID="txtDateFrom">
                  </cc1:CalendarExtender>
              
            </td>
            <td class="NormalText">
                DateTo</td>
            <td class="NormalText">
                <asp:TextBox ID="txtdateto" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdateto_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdateto">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Status</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlstatus" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="A">Authorized</asp:ListItem>
                    <asp:ListItem Value="P">Pending</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlplant" runat="server" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="COTTON">TAFFETA</asp:ListItem>
                    <asp:ListItem Value="COTTON">COTTON</asp:ListItem>
                </asp:DropDownList>
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
            <td class="buttonbackbar" colspan="4">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" 
                    ondatabinding="lnkfetch_Click" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="50" 
                            ondatabinding="lnkfetch_Click">
                            <ProgressTemplate>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkfetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" 
                    ondatabinding="lnkfetch_Click">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both" 
                            Width="950px">
                            <asp:GridView ID="grdDetail" runat="server" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="GirdItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

