<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="AssetMasters.aspx.cs" Inherits="AssetMngmnt_AssetMasters" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
    <tr>
        <td class="tableheader" colspan="4">
            Asset Master</td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Asset Category</td>
        <td class="NormalText" style="width: 196px">
            <asp:DropDownList ID="ddlasssetcat" runat="server" AutoPostBack="True" 
                DataSourceID="SqlDataSource1" DataTextField="item_name" 
                DataValueField="asset_id" 
                onselectedindexchanged="ddlasssetcat_SelectedIndexChanged" 
                CssClass="combobox">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT item_name,asset_id FROM dbo.jct_asset_master where status='A'">
            </asp:SqlDataSource>
        </td>
        <td class="NormalText" colspan="2">
            <asp:Label ID="lblAssetNameID" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Asset</td>
        <td class="NormalText" style="width: 196px">
            <asp:DropDownList ID="ddlassettype" runat="server" CssClass="combobox"  DataSourceID="SqlDataSource4"
                AutoPostBack="True" onselectedindexchanged="ddlassettype_SelectedIndexChanged"
                DataTextField="asset_type_name" DataValueField="asset_type_id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT b.asset_type_name,b.asset_type_id FROM dbo.jct_asset_type_master b JOIN jct_asset_master a ON a.asset_id=b.asset_id and a.status=b.status   WHERE  a.status='A' and a.asset_id =@asset_id">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlasssetcat" Name="asset_id" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:SqlDataSource>
        </td>
        <td class="NormalText" style="width: 141px">
            <asp:Label ID="lblPrinterType" runat="server" Text="Printer Type" Visible="False"></asp:Label>
        </td>
        <td class="NormalText">
            <asp:DropDownList ID="ddlPrinterType" runat="server" CssClass="combobox"  Visible="False" onselectedindexchanged="ddlPrinterType_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>DMP</asp:ListItem>
                <asp:ListItem>DMP Line</asp:ListItem>
                <asp:ListItem>Inkjet</asp:ListItem>
                <asp:ListItem>Label</asp:ListItem>
                <asp:ListItem>Laser</asp:ListItem>
                <asp:ListItem>Psc</asp:ListItem>
                <asp:ListItem>Coloured Laser</asp:ListItem>
            </asp:DropDownList>
            </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Asset Name</td>
        <td class="NormalText" style="width: 196px">
            <asp:TextBox ID="txtassetname" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtassetname" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
        </td>
        <td class="NormalText" style="width: 141px">
            Asset Description</td>
        <td class="NormalText">
            <asp:TextBox ID="txtassetdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtassetdesc" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="height: 15px; width: 97px;">
            Date of Purchase</td>
        <td class="NormalText" style="height: 15px; width: 196px;">
            <asp:TextBox ID="txtDOP" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:CalendarExtender ID="txtDOP_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtDOP">
            </cc1:CalendarExtender>
        </td>
        <td class="NormalText" style="height: 15px; width: 141px;">
            Acquisition Date</td>
        <td class="NormalText" style="height: 15px">
            <asp:TextBox ID="txtacquisitiondt" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:CalendarExtender ID="txtacquisitiondt_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtacquisitiondt">
            </cc1:CalendarExtender>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Manufacturer</td>
        <td class="NormalText" style="width: 196px">
            <asp:DropDownList ID="ddlmanufacturer" runat="server" CssClass="combobox" 
                DataSourceID="SqlDataSource3" DataTextField="name" 
                DataValueField="id">
              
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT name,id from dbo.jct_asset_manufacturer_master WHERE status='A' and type='manufacturer'">
            </asp:SqlDataSource>
        </td>
        <td class="NormalText" style="width: 141px">
            State</td>
        <td class="NormalText">
            <asp:DropDownList ID="ddlstate" runat="server" 
                DataSourceID="SqlDataSource2" DataTextField="state_name" 
                DataValueField="state_id" CssClass="combobox" >
                
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT state_name,state_id FROM dbo.jct_asset_state_master WHERE status='A'">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Capital Item</td>
        <td class="NormalText" style="width: 196px">
            <asp:DropDownList ID="ddlcapital" runat="server" CssClass="combobox">
                <asp:ListItem Value="-1" Text="  "></asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="NormalText" style="width: 141px">
            Warranty(in Months)</td>
        <td class="NormalText">
            <asp:TextBox ID="txtwarranty" runat="server" CssClass="textbox" Columns="5"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="buttonbackbar" colspan="4">
            <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                onclick="lnksave_Click" ValidationGroup="A">Save</asp:LinkButton>
            <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>
            <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                onclick="lnkdel_Click" ValidationGroup="A">Delete</asp:LinkButton>
            <asp:LinkButton ID="lnkresest" runat="server" CssClass="buttonc" 
                onclick="lnkresest_Click">Reset</asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="4">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both">
                <asp:GridView ID="grdDetail" runat="server" 
    AllowPaging="True" AutoGenerateSelectButton="True" Width="100%" 
                    onselectedindexchanged="GridView1_SelectedIndexChanged" 
                    onpageindexchanging="grdDetail_PageIndexChanging">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
            </asp:Panel>
        </td>
    </tr>
</table>
</asp:Content>

