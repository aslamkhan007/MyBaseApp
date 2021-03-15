<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="asset_furn_desc_master.aspx.cs" Inherits="AssetMngmnt_asset_furn_desc_master" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table class="mytable">
    <tr>
        <td class="tableheader" colspan="5">
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
        <td class="NormalText" colspan="3">
            <asp:Label ID="lblid" runat="server" Text="AssetID" Visible="False"></asp:Label>
&nbsp;      <asp:Label ID="lblAssetNameID" runat="server" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Asset Types</td>
        <td class="NormalText" style="width: 196px">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlassettypes" runat="server" CssClass="combobox" >
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" style="width: 141px">
            Manufacturer</td>
        <%--     <td id="Td1" class="NormalText" runat="server" visible="false" style="width: 141px">
            Remarks</td>--%>
        <td class="NormalText" style="width: 141px">

                           <asp:UpdatePanel ID="Updatemanufacturer" runat="server">
                <ContentTemplate>
            <asp:DropDownList ID="ddlmanufacturer" runat="server" 
                AppendDataBoundItems="True" CssClass="combobox" DataSourceID="SqlDataSource1" 
                DataTextField="name" DataValueField="id">
               <%-- <asp:ListItem></asp:ListItem>--%>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
             SelectCommand="select name ,id from  jct_asset_manufacturer_master WHERE module_usedby='GEN' AND status='A'">                       
            </asp:SqlDataSource>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Quantity</td>
        <td class="NormalText" style="width: 196px">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtquantity" runat="server" Columns="5" CssClass="textbox" 
                MaxLength="4"></asp:TextBox>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtquantity" Display="Dynamic" ErrorMessage="**" 
                ValidationGroup="A"></asp:RequiredFieldValidator>  
                    <cc1:FilteredTextBoxExtender
                     ID="Flt1" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtquantity">
                    </cc1:FilteredTextBoxExtender>
                </ContentTemplate>
            </asp:UpdatePanel>

        </td>
   <%--     <td id="Td1" class="NormalText" runat="server" visible="false" style="width: 141px">
            Remarks</td>--%>
              <td class="NormalText" runat="server" style="width: 141px">
            Remarks</td>

              <td class="NormalText" runat="server" style="width: 141px">
                         <asp:UpdatePanel ID="UpdateRemarks" runat="server">
                <ContentTemplate>
            <asp:TextBox ID="txtremarks" runat="server" CssClass="textbox" 
                Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                </ContentTemplate>
                </asp:UpdatePanel>
        </td>

        <td class="NormalText">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="NormalText" style="width: 97px">
            Capital Item</td>
        <td class="NormalText" style="width: 196px">
           <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>

            <asp:DropDownList ID="ddlcapital" runat="server" CssClass="combobox">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="0">No</asp:ListItem>
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td class="NormalText" style="width: 141px">
            &nbsp;Asset&nbsp;
            State</td>
        <td class="NormalText" style="width: 141px">
                   <asp:UpdatePanel ID="Updateddlstate" runat="server">
                <ContentTemplate>

                        <asp:DropDownList ID="ddlstate" runat="server" 
                DataSourceID="SqlDataSource2" DataTextField="state_name" 
                DataValueField="state_id" CssClass="combobox" >
                
            </asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
            </td>
        <td class="NormalText">
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT state_name,state_id FROM dbo.jct_asset_state_master WHERE status='A' and module_usedby = 'GEN'">
            </asp:SqlDataSource>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="5">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
                    </td>
    </tr>
    <tr>
        <td class="buttonbackbar" colspan="5">
                        
                        <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
    
            <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                ValidationGroup="A" onclick="lnksave_Click">Save</asp:LinkButton>
            <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                ValidationGroup="A" onclick="lnkupdate_Click">Update</asp:LinkButton>
            <asp:LinkButton ID="lnkdel" runat="server" CssClass="buttonc" 
                ValidationGroup="A" onclick="lnkdel_Click">Delete</asp:LinkButton>
            <asp:LinkButton ID="lnkresest" runat="server" CssClass="buttonc" 
                onclick="lnkresest_Click">Reset</asp:LinkButton>
                                    </ContentTemplate>
                </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td class="NormalText" colspan="5">
        <asp:UpdatePanel ID="UpdGrid" runat="server">
                <ContentTemplate>
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="200px">
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateSelectButton="True" 
                    Width="100%" onselectedindexchanged="grdDetail_SelectedIndexChanged">
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

