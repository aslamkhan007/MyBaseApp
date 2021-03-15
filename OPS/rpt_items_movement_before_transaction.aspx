<%@ Page Language="VB" MasterPageFile="MasterPage.master" AutoEventWireup="false" CodeFile="rpt_items_movement_before_transaction.aspx.vb" Inherits="OPS_rpt_items_movement_before_transaction" title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Assembly="eWorld.UI.Compatibility, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI.Compatibility" TagPrefix="cc1" %>


<%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td style="height: 21px" colspan="2">
                <asp:Label ID="Label1" runat="server" CssClass="labelcells" 
                    Text="Items Movement Report"></asp:Label>
            </td>
            <td style="height: 21px">
                &nbsp;</td>
            <td style="height: 21px">
                &nbsp;</td>
            <td style="height: 21px">
            </td>
            <td style="height: 21px">
                &nbsp;</td>
            <td style="height: 21px">
                &nbsp;</td>
            <td style="height: 21px">
                &nbsp;</td>
            <td style="height: 21px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px; height: 19px">
                <asp:Label ID="Label2" runat="server" Text="From Date"></asp:Label>
            </td>
            <td style="height: 19px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_datefrom" runat="server" 
                            CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
                            TargetControlID="txt_datefrom">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px">
                &nbsp;</td>
            <td style="height: 19px">
                <asp:Label ID="Label3" runat="server" Text="To Date"></asp:Label>
            </td>
            <td style="height: 19px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_dateto" runat="server" 
                            CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" 
                             TargetControlID="txt_dateto">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px">
                <asp:Label ID="Label4" runat="server" Text="Tran. No."></asp:Label>
            </td>
            <td style="height: 19px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txt_entryno" runat="server" AutoPostBack="True" 
                            CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 19px">
                
                <asp:LinkButton ID="lnk_fetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
                
            </td>
            <td style="height: 19px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8">
              <%--  <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>--%>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 

                            ConnectionString="Data Source=misdev;Initial Catalog=jctdev;Persist Security Info=True;User ID=itgrp;Password=power;Connect Timeout = 100000;" 
                            SelectCommand="SELECT * FROM jct_ops_items_movement_before_transaction_header"></asp:SqlDataSource>
                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                            <Report FileName="crpt_items_movement_before_transaction_issue_slip.rpt">
                            </Report>
                        </CR:CrystalReportSource>
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                            AutoDataBind="true" DisplayGroupTree="False" 
                            HasCrystalLogo="False" Height="50px" Width="350px" />
                            
                 <%--   </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 75px; height: 23px">
            </td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
                &nbsp;</td>
            <td style="height: 23px">
                &nbsp;</td>
            <td style="height: 23px">
            </td>
            <td style="height: 23px">
                &nbsp;</td>
            <td style="height: 23px">
                &nbsp;</td>
            <td style="height: 23px">
                &nbsp;</td>
            <td style="height: 23px">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

