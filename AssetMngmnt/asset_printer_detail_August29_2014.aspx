<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="asset_printer_detail.aspx.cs" Inherits="AssetMngmnt_asset_printer_detail" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Printer/Scanner/Network Items</td>
        </tr>
        <tr>
            <td class="NormalText">
                Asset Type</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlassettype" runat="server" AutoPostBack="True" CssClass="combobox" onselectedindexchanged="ddlassettype_SelectedIndexChanged">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem Value="55">Printer</asp:ListItem>
                            <asp:ListItem Value="71">Scanner</asp:ListItem>
                            <asp:ListItem Value="72">NetworkItems</asp:ListItem>
                            <asp:ListItem Value="73">Conference Phone</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             <td class="NormalText" style="width: 141px">
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                         <asp:Label ID="lblPrinterType" runat="server" Text="Printer Type" Visible="False"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="ddlassettype" EventName="SelectedIndexChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
        </td>
        <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlPrinterType" runat="server" CssClass="combobox" Visible="False">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>DMP</asp:ListItem>
                        <asp:ListItem>DMP Line</asp:ListItem>
                        <asp:ListItem>Inkjet</asp:ListItem>
                        <asp:ListItem>Label</asp:ListItem>
                        <asp:ListItem>Laser</asp:ListItem>
                        <asp:ListItem>Psc</asp:ListItem>
                        <asp:ListItem>Coloured Laser</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblSrNo" runat="server" Visible="False"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlassettype" EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="grdDetail" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                ItemID</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtitemno" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="txtitemno" ErrorMessage="Cannot be Blank" 
                            ValidationGroup="A"></asp:RequiredFieldValidator>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             <td class="NormalText" style="width: 141px">
                 &nbsp;</td>
  
                  <td class="NormalText" >
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px" Visible="False"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                State</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="True" 
                    CssClass="combobox" DataSourceID="SqlDataSource4" DataTextField="state_desc" 
                    DataValueField="state_id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:jctdevConnectionString %>" 
                    SelectCommand="SELECT  state_desc,state_id  FROM dbo.jct_asset_state_master WHERE status='A'">
                </asp:SqlDataSource>
            </td>
             <td class="NormalText" style="width: 141px">
                 <asp:UpdatePanel ID="UpdatePanel14" runat="server" UpdateMode="Conditional">
                     <ContentTemplate>
                         <asp:Label ID="lblPrinteroption" runat="server" Text="PrinterOption" 
                             Visible="False"></asp:Label>
                     </ContentTemplate>
                     <Triggers>
                         <asp:AsyncPostBackTrigger ControlID="ddlassettype" EventName="SelectedIndexChanged" />
                     </Triggers>
                 </asp:UpdatePanel>
        </td>
        <td class="NormalText">
            <asp:UpdatePanel ID="UpdatePanel15" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:DropDownList ID="ddloption" runat="server" AutoPostBack="True" 
                        CssClass="combobox" Visible="False">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>IndividualPrinter</asp:ListItem>
                        <asp:ListItem>NetworkPrinter</asp:ListItem>
                    </asp:DropDownList>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlassettype" 
                        EventName="SelectedIndexChanged" />
                    <asp:AsyncPostBackTrigger ControlID="grdDetail" 
                        EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Serial No.</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtitem_name" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                Model </td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtmodel" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Description</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" ToolTip="Please enter item desc. In case of Network  Items Ports can be defined." Width="200px"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                Location</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlloc" runat="server" CssClass="combobox" DataSourceID="SqlDataSource1" DataTextField="deptloc" DataValueField="deptloc">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT DISTINCT deptloc  FROM  dbo.jct_asset_item_details WHERE status='a' order by deptloc  "></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                JctSrNo/MachineID</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtmachineid" runat="server" CssClass="textbox"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                Vendor</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlvendor" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="combobox" DataSourceID="SqlDataSource2" DataTextField="description" DataValueField="description">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT  description  FROM dbo.jct_asset_manufacturer_master  WHERE type='Vendor'  AND status='A' order by description"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                Manufacturer</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlmanufactuer" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="combobox" DataSourceID="SqlDataSource3" DataTextField="description" DataValueField="description">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT  description  FROM dbo.jct_asset_manufacturer_master  WHERE type='Manufacturer'  AND status='A' order by description"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText">
                DOP</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtdop" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtdop_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtdop">
                        </cc1:CalendarExtender>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkadd" runat="server" CssClass="buttonc" 
                            onclick="lnkadd_Click" ValidationGroup="A">Add</asp:LinkButton>
                        <asp:LinkButton ID="lnkupd" runat="server" CssClass="buttonc" 
                            onclick="lnkupd_Click" ValidationGroup="A">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" onclick="lnkdel_Click">Delete</asp:LinkButton>
                        <asp:LinkButton ID="lnkreset" runat="server" CssClass="buttonc" onclick="lnkreset_Click" style="height: 22px">Reset</asp:LinkButton>
                       
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:LinkButton ID="lnkexcel" runat="server" CssClass="buttonc" 
                            onclick="lnkexcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server" Height="300px" ScrollBars="Vertical">
                            <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                                onselectedindexchanged="grdDetail_SelectedIndexChanged" 
                                SelectedRowStyle-CssClass="GridRowGreen" Width="100%">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PageStyle" />
                                <RowStyle CssClass="GirdItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlassettype" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="lnkadd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkdel" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkreset" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkupd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>

