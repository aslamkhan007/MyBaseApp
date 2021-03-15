<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" CodeFile="asset_desc_master.aspx.cs" Inherits="AssetMngmnt_asset_desc_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table class="mytable">
    <tr>
        <td class="tableheader" colspan="4">
            Asset Description Master</td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px; height: 16px;">
            Asset Category</td>
        <td class="NormalText" style="width: 196px; height: 16px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlasssetcat" runat="server" AutoPostBack="True"  
                onselectedindexchanged="ddlasssetcat_SelectedIndexChanged" 
                CssClass="combobox">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
         
        </td>
        <td class="NormalText" colspan="2">
            <asp:Label ID="lblAssetNameID" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Asset Types</td>
        <td class="NormalText" style="width: 196px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlassettypes" runat="server" CssClass="combobox">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" style="width: 141px">
            &nbsp;</td>
      <%--  <td class="NormalText">
            <asp:DropDownList ID="ddlPrinterType" runat="server" CssClass="combobox"  Visible="False" onselectedindexchanged="ddlPrinterType_SelectedIndexChanged" AutoPostBack="True">
                <asp:ListItem>DMP</asp:ListItem>
                <asp:ListItem>DMP Line</asp:ListItem>
                <asp:ListItem>Inkjet</asp:ListItem>
                <asp:ListItem>Label</asp:ListItem>
                <asp:ListItem>Laser</asp:ListItem>
                <asp:ListItem>Psc</asp:ListItem>
                <asp:ListItem>Coloured Laser</asp:ListItem>
            </asp:DropDownList>
            </td>--%>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Asset Name</td>
        <td class="NormalText" style="width: 196px">
                 <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtassetname" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtassetname" Display="Dynamic" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" runat="server" visible="false" style="width: 141px">
            Asset Description</td>
        <td class="NormalText">
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtassetdesc" runat="server" CssClass="textbox" Height="50px" TextMode="MultiLine" Width="200px" Visible="False"></asp:TextBox>
             </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="height: 15px; width: 97px;">
            Date of Purchase</td>
        <td class="NormalText" style="height: 15px; width: 196px;">
                 <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtDOP" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:CalendarExtender ID="txtDOP_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtDOP">
            </cc1:CalendarExtender>
             </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" style="height: 15px; width: 141px;">
            Acquisition Date</td>
        <td class="NormalText" style="height: 15px">
                 <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtacquisitiondt" runat="server" CssClass="textbox"></asp:TextBox>
            <cc1:CalendarExtender ID="txtacquisitiondt_CalendarExtender" runat="server" 
                Enabled="True" TargetControlID="txtacquisitiondt">
            </cc1:CalendarExtender>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Manufacturer</td>
        <td class="NormalText" style="width: 196px">
                         <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                <ContentTemplate>
            <asp:DropDownList ID="ddlmanufacturer" runat="server" CssClass="combobox" 
                DataSourceID="SqlDataSource3" DataTextField="name" 
                DataValueField="id" AppendDataBoundItems="True">
                <asp:ListItem></asp:ListItem>
              
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT name,id from dbo.jct_asset_manufacturer_master WHERE status='A' and type='manufacturer' AND module_usedby = 'MIS'">
            </asp:SqlDataSource>
                         </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" style="width: 141px">
            State</td>
        <td class="NormalText">
              <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
            <asp:DropDownList ID="ddlstate" runat="server" 
                DataSourceID="SqlDataSource2" DataTextField="state_name" 
                DataValueField="state_id" CssClass="combobox" >
                
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT state_name,state_id FROM dbo.jct_asset_state_master WHERE status='A' AND module_usedby = 'MIS'">
            </asp:SqlDataSource>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Vendor </td>
        <td class="NormalText" style="width: 196px">
                 <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlvendor" visible="true" runat="server" 
                    DataSourceID="SqlDataSource24" DataTextField="name" 
                    DataValueField="name" CssClass="combobox" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
              <asp:SqlDataSource ID="SqlDataSource24" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT name FROM dbo.jct_asset_manufacturer_master WHERE status='A' and type='vendor' AND module_usedby = 'MIS'">
            </asp:SqlDataSource> 
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td class="NormalText" colspan="2">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Capital Item</td>
        <td class="NormalText" style="width: 196px">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
            <asp:DropDownList ID="ddlcapital" runat="server" CssClass="combobox">
                <asp:ListItem Value="-1" Text="  "></asp:ListItem>
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" style="width: 141px">
            Warranty(in Months)</td>
        <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtwarranty" runat="server" CssClass="textbox" Columns="5"></asp:TextBox>

                      <asp:RequiredFieldValidator ID="Reqwarranty" runat="server" 
                ControlToValidate="txtwarranty" Display="Dynamic" ErrorMessage="**" 
                ValidationGroup="A"></asp:RequiredFieldValidator>  
                    <cc1:FilteredTextBoxExtender
                     ID="Flt1" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtwarranty">
                    </cc1:FilteredTextBoxExtender>
                    </ContentTemplate>
                    </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="4">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
    DisplayAfter="100">
                        <progresstemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                        </progresstemplate>
                    </asp:UpdateProgress>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="buttonbackbar" colspan="4">
                        <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
            <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                onclick="lnksave_Click" ValidationGroup="A">Save</asp:LinkButton>
            <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                onclick="lnkupdate_Click" ValidationGroup="A">Update</asp:LinkButton>

                        <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkdel"
                            ConfirmText="Are u sure To Delete ?">
                        </cc1:ConfirmButtonExtender>

            <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                onclick="lnkdel_Click">Delete</asp:LinkButton>
            <asp:LinkButton ID="lnkresest" runat="server" CssClass="buttonc" 
                onclick="lnkresest_Click">Reset</asp:LinkButton>
                 </ContentTemplate>
                </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="4">
 
              <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" Height="200px" ScrollBars="Both">
                        <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                            onpageindexchanging="grdDetail_PageIndexChanging" 
                            onselectedindexchanged="grdDetail_SelectedIndexChanged" Width="100%">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GridItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    </asp:Panel>
        
         </ContentTemplate>
         </asp:UpdatePanel>
        </td>
    </tr>
</table>
</asp:Content>

