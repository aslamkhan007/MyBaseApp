<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="asset_printer_report.aspx.cs" Inherits="AssetMngmnt_asset_printer_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Printer/Scanner Report</td>
        </tr>
        <tr>
            <td class="NormalText">
                Asset Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlassettype" runat="server" AutoPostBack="True" CssClass="combobox" onselectedindexchanged="ddlassettype_SelectedIndexChanged">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem Value="55">Printer</asp:ListItem>
                            <asp:ListItem Value="71">Scanner</asp:ListItem>
                            <asp:ListItem Value="72">NetworkItems</asp:ListItem>
                            <asp:ListItem Value="73">Conference Phone</asp:ListItem>
                        </asp:DropDownList></td>
            <td class="NormalText">
                Manufacturer</td>
            <td class="NormalText">
                 <asp:DropDownList ID="ddlmanufactuer" runat="server" 
                     AppendDataBoundItems="True" AutoPostBack="True" CssClass="combobox" 
                     DataSourceID="SqlDataSource3" DataTextField="description" 
                     DataValueField="description" 
                     onselectedindexchanged="ddlmanufactuer_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            
                    SelectCommand="SELECT  description  FROM dbo.jct_asset_manufacturer_master  WHERE type='Manufacturer'  AND status='A' AND module_usedby = 'mis' order by description"></asp:SqlDataSource>
                    </td>
        </tr>
        <tr>
            <td class="NormalText">
                Printer/scanner Type</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlprintertype" runat="server" CssClass="combobox" 
                    DataSourceID="SqlDataSource1" DataTextField="Column1" 
                    DataValueField="Column1">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT  DISTINCT ISNULL(printer_type,'')  FROM  jct_asset_printer_scanner_network WHERE STATUS='A'">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                location</td>
            <td class="NormalText">
                    <asp:DropDownList ID="ddlloc" runat="server" Visible="true"
                    CssClass="combobox" DataSourceID="SqlDataSource30" 
                    DataTextField="location" DataValueField="ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource30" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="Select -1 as Id,'' as location Union SELECT ID,location FROM jct_asset_location_master WHERE STATUS='A' AND module_usedby = 'mis' order by ID">
                </asp:SqlDataSource></td>
        </tr>
        <tr>
            <td class="NormalText">
                Model</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlmodel" runat="server" CssClass="combobox" 
                    AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                Asset State</td>
            <td class="NormalText">
               <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDataSource4" DataTextField="state_desc" 
                    DataValueField="state_id" AppendDataBoundItems="True">
                   <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>" 
                    SelectCommand="SELECT  state_desc,state_id  FROM dbo.jct_asset_state_master WHERE status='A' AND module_usedby = 'mis'">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Printer ID</td>
            <td class="NormalText">
                &nbsp;&nbsp;
                <asp:TextBox ID="txtjctmachineid" runat="server" CssClass="textbox"></asp:TextBox>
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                                        <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click">Fetch</asp:LinkButton>
                     
                   </ContentTemplate>
                </asp:UpdatePanel>
<%--                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                onclick="lnkexcel_Click">Excel</asp:LinkButton>   --%>    
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
              <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Both">
                            <asp:GridView ID="grdDetail" runat="server" 
                              
                                SelectedRowStyle-CssClass="GridRowGreen" Width="100%" 
                                onselectedindexchanged="grdDetail_SelectedIndexChanged">
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

