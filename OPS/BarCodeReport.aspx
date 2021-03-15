<%@ Page Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false"
    CodeFile="BarCodeReport.aspx.vb" Inherits="BarCode" %>

 


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="DropDownCheckBoxes" Namespace="Saplin.Controls" TagPrefix="cc2" %>
<%@ Register Assembly="System.Web.DataVisualization" Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader" colspan="3">
                Bar Code&nbsp; Reports</td>
            <td style="font-weight: bold; font-size: 10pt" class="tableheader">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px; width: 96px;">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                    RepeatDirection="Horizontal" Width="192px">
                    <asp:ListItem Selected="True">Summary</asp:ListItem>
                    <asp:ListItem>Detail</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td class="NormalText" valign="top" style="width: 227px; height: 25px;">
                   &nbsp;</td>
            <td class="NormalText" valign="top" style="height: 25px; width: 51px;">
                &nbsp;</td>
            <td class="NormalText" valign="top" style="height: 25px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px; width: 96px;">
                From Date</td>
            <td class="NormalText" valign="top" style="width: 227px; height: 25px;">
                   <asp:UpdatePanel ID="From" runat="server" RenderMode="Inline">

                    <ContentTemplate>

                        <asp:TextBox  ID="txtFrDate" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" ></asp:TextBox>

                        
                          
                          <cc1:CalendarExtender
                                ID="CalFrom" runat="server" TargetControlID="txtFrDate" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                         
                      
                    </ContentTemplate>
                </asp:UpdatePanel>
                                           
                </td>
            <td class="NormalText" valign="top" style="height: 25px; width: 51px;">
                ToDate</td>
            <td class="NormalText" valign="top" style="height: 25px">
                <asp:UpdatePanel ID="To" runat="server" RenderMode="Inline">

                    <ContentTemplate>

                        <asp:TextBox  ID="txtToDate" TabIndex="3" runat="server" Width="70px"
                            CssClass="textbox" Enabled="True" MaxLength="8" ></asp:TextBox>
                   
                          
                          <cc1:CalendarExtender
                                ID="CalTo" runat="server" TargetControlID="txtToDate" Animated="False" Format="MM/dd/yyyy">
                            </cc1:CalendarExtender>
                      
                      
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="labelcells" style="height: 25px; width: 96px;">
                Godown</td>
            <td class="NormalText" valign="top" style="width: 227px; height: 25px;">
                   <asp:DropDownList ID="ddlGodown" runat="server">
                       <asp:ListItem>G-47</asp:ListItem>
                       <asp:ListItem>G-39</asp:ListItem>
                       <asp:ListItem>G-99</asp:ListItem>
                       <asp:ListItem>G-88</asp:ListItem>
                   </asp:DropDownList>
                                           
                </td>
            <td class="NormalText" valign="top" style="height: 25px; width: 51px;">
                &nbsp;</td>
            <td class="NormalText" valign="top" style="height: 25px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" Height="22px" Width="84px"
                    CausesValidation="False">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" Height="22px" Width="83px"
                    CausesValidation="False">To Excel</asp:LinkButton>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <%-- </asp:Panel>--%>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="grdStage" runat="server" AllowPaging="True" 
                                CssClass="GridViewStyle" GridLines="None" PageSize="50000" ShowFooter="True" 
                                Width="100%">
                                <RowStyle CssClass="RowStyle" />
                                <EmptyDataRowStyle CssClass="EmptyRowStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <EditRowStyle CssClass="EditRowStyle" />
                                <AlternatingRowStyle CssClass="AltRowStyle" />
                            </asp:GridView>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
               <%-- </asp:Panel>--%>
                &nbsp;
            </td>
        </tr>
    </table>
 
</asp:Content>
