<%@ Page Title="" Language="VB" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="false" CodeFile="frm_raw_material_stock_report.aspx.vb" Inherits="OPS_frm_raw_material_stock_report" %>
<%@ Register Src="FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 64%; height: 379px;">
        <tr>
            <td colspan="2" style="height: 38px">
                <asp:Label ID="Label1" runat="server" Text="Raw Material Current Stock"></asp:Label>
            </td>
            <td style="height: 38px">
                &nbsp;</td>
            <td style="height: 38px">
                &nbsp;</td>
            <td style="height: 38px">
                &nbsp;</td>
            <td style="height: 38px">
                &nbsp;</td>
            <td style="height: 38px">
                &nbsp;</td>
            <td style="height: 38px" align="right">
                <asp:ImageButton ID="imb_close" runat="server" Height="16px" 
                    ImageUrl="~/Image/close24.png" />
            </td>
            <td style="height: 38px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" CssClass="labelcells" Text="Ware House" 
                    Width="70px"></asp:Label>
            </td>
            <td width="350" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_warehouse" runat="server" CssClass="combobox" 
                            Width="300px">
                        </asp:DropDownList>
                        <asp:ImageButton ID="imb_fetch" runat="server" Height="16px" 
                            ImageUrl="~/Image/searchBlueSmall.png" ToolTip="Fetch data" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:ImageButton ID="imb_excel" runat="server" Height="16px" 
                    ImageUrl="~/Image/XportXLFinal.png" ToolTip="Export to excel" 
                    Width="19px" ImageAlign="Left" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 8px">
                <asp:Label ID="Label4" runat="server" CssClass="labelcells" Text="Age wise"></asp:Label>
            </td>
            <td style="height: 8px">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="chk_agewise" runat="server" 
                            CssClass="labelcells" AutoPostBack="True" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
            </td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" Height="12px" 
                            ImageUrl="~/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td style="height: 8px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 8px">
                <asp:Label ID="Label5" runat="server" CssClass="labelcells" Text="Lot wise"></asp:Label>
            </td>
            <td style="height: 8px">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="chk_lotwise" runat="server" CssClass="labelcells" 
                            AutoPostBack="True" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
            <td style="height: 8px">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="8" style="height: 73px">
                <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" Height="300px" 
                    Width="650px">
                    <div id="AdjResultsDiv"
                         style=" width: 100%; height:300px; left: -1px; top: 0px;"> 
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" 
                                    Font-Bold="False">
                                    <HeaderStyle CssClass="GridHeader" />
                                <EmptyDataTemplate>
                                    Records not Available
                                </EmptyDataTemplate>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </asp:Panel>
            </td>
            <td style="height: 73px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 5px">
            </td>
            <td style="height: 5px">
            </td>
            <td style="height: 5px">
            </td>
            <td style="height: 5px">
            </td>
            <td style="height: 5px">
            </td>
            <td style="height: 5px">
            </td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="height: 5px">
                <asp:Label ID="Label3" runat="server" CssClass="labelcells" Text="Action" 
                    Visible="False"></asp:Label>
            </td>
            <td style="height: 5px" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                 <ContentTemplate>
                    <uc1:FlashMessage ID="FMsg" runat="server" EnableTheming="true" EnableViewState="true"
                         FadeInDuration="2" FadeInSteps="2" FadeOutDuration="2" FadeOutSteps="2" Visible="true" />
                  </ContentTemplate>
                </asp:UpdatePanel>
                </td>
            <td style="height: 5px">
                &nbsp;</td>
            <td style="height: 5px">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddl_action" runat="server" 
    CssClass="combobox" Visible="False">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
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
    </table>
</asp:Content>

