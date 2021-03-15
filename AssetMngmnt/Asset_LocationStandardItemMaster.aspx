<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="Asset_LocationStandardItemMaster.aspx.cs" Inherits="AssetMngmnt_Asset_LocationStandardItemMaster" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="2">
                Locationwise Standard Items Master</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Location</td>
            <td class="NormalText">
                <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
       <telerik:RadComboBox ID="ddlloc" Runat="server"  Visible="true"  CssClass="combobox"
                    Height="85" EnableVirtualScrolling="true" ExpandDirection="Down"   
                     AutoPostBack="True" 
                onselectedindexchanged="ddlloc_SelectedIndexChanged">
                    </telerik:RadComboBox>
                        
<%--                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">
                Sublocation</td>
            <td class="NormalText">
                <%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>

                        <telerik:RadComboBox ID="ddlSubloc" Runat="server" AutoPostBack="True" 
                            CssClass="combobox" DataTextField="location" DataValueField="location" 
                            EnableVirtualScrolling="true" ExpandDirection="Down" Height="85" 
                    Visible="true" onselectedindexchanged="ddlSubloc_SelectedIndexChanged">
                        </telerik:RadComboBox>

<%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">--%>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                            <asp:UpdatePanel id="UpdGrdDetail" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" 
                    EnableModelValidation="True" onrowcommand="grdDetail_RowCommand" 
                    onrowdatabound="grdDetail_RowDataBound">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" 
                                    ImageUrl="~/Image/Icons/close.png" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AssetType">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="ddlAssetTypeGrid" Runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSource1" DataTextField="ASSET" DataValueField="ASSET_ID" 
                                    EnableCheckAllItemsCheckBox="True" 
                                    onselectedindexchanged="ddlAssetTypeGrid_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                    SelectCommand="SELECT ITEM_NAME AS ASSET, ASSET_ID  FROM JCT_ASSET_MASTER WHERE STATUS=@STATUS and module_usedby = 'GEN' ORDER BY ASSET_ID">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="AssetCategory">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="ddlAssetCatg" Runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSource2" DataTextField="ASSET_TYPE_NAME" 
                                    DataValueField="ASSET_TYPE_ID" 
                                    onselectedindexchanged="ddlAssetCatg_SelectedIndexChanged">
                                </telerik:RadComboBox>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                    SelectCommand="SELECT ASSET_TYPE_NAME ,ASSET_TYPE_ID FROM JCT_ASSET_TYPE_MASTER WHERE STATUS='A' AND ASSET_ID=@ASSET_ID ORDER BY ASSET_TYPE_NAME">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="ddlAssetTypeGrid" Name="ASSET_ID" 
                                            PropertyName="SelectedValue" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ItemDescripction">
                            <ItemTemplate>
                                <telerik:RadComboBox ID="ddlItemDesc" Runat="server" AutoPostBack="True" 
                                    DataSourceID="SqlDataSource3" DataTextField="item_desc" 
                                    DataValueField="item_id" EnableVirtualScrolling="true" ExpandDirection="Down" 
                                    Height="200">
                                </telerik:RadComboBox>
                                       <%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">--%>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                    SelectCommand="SELECT  TYPE_NAME AS item_desc ,SrNo  AS item_id FROM  jct_asset_type_description  WHERE   status = @status AND asset_type_id = @ASSET_TYPE_ID ORDER BY TYPE_NAME">
                                 <%--  SelectCommand="SELECT TYPE_NAME + ',' + CONVERT(VARCHAR(20), quantity) + '-' + description AS item_desc , CONVERT(VARCHAR,a.SrNo) + '-'+ CONVERT(VARCHAR,b.id) AS item_id FROM   jct_asset_type_description AS a INNER JOIN jct_asset_manufacturer_master AS b ON a.manufacturer = b.id WHERE  a.status = @status AND b.status = @status AND asset_type_id = @ASSET_TYPE_ID ORDER BY TYPE_NAME ,b.description">--%>                                    
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="A" Name="status" Type="String" />
                                                <asp:ControlParameter ControlID="ddlAssetCatg" Name="ASSET_TYPE_ID" 
                                                    PropertyName="SelectedValue" />
                                            </SelectParameters>
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="txtNoOfItems" runat="server" 
                                    CausesValidation="True" Culture="en-US" DataType="System.Int32" 
                                    DbValueFactor="1" EmptyMessage="Invalid Quantity" InputType="Number" 
                                    LabelWidth="32px" MaxLength="10" MaxValue="100" MinValue="1" 
                                    ValidationGroup="mandatory" Width="80px">
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtNoOfItems" Display="Dynamic" ErrorMessage="*" 
                                    ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
<%--                        <asp:TemplateField HeaderText="AllocationDate">
                            <ItemTemplate>
                                <telerik:RadDatePicker ID="txtAcqDt" runat="server" DateFormat="MM/dd/yyyy" 
                                    DateInput-CausesValidation="True" DateInput-EmptyMessage="MM-DD-YY" 
                                    MinDate="01/01/1940" Width="100">
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="ReqtxtAcqDt" runat="server" 
                                    ControlToValidate="txtAcqDt" Display="Dynamic" ErrorMessage="*" 
                                    ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="mandatory"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </EmptyDataTemplate>
                    <HeaderStyle CssClass="GridHeader" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="Griditem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
                </ContentTemplate>

                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="2">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkApply" runat="server" CssClass="buttonc" 
                             ValidationGroup="A" onclick="lnkApply_Click">Apply</asp:LinkButton>
                        

                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" onclick="lnkReset_Click" 
                            >Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc" 
                            onclick="lnkaddrow_Click">AddRow</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td  class="NormalText" colspan="2">
                            <asp:UpdatePanel ID="UpdateRecordgrid" runat="server">
                    <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server" Height="350px" ScrollBars="Both" 
                    Width="900px">
                    <asp:GridView ID="GridView1" runat="server" 
              
    Width="100%" AutoGenerateColumns="False" onrowcommand="GridView1_RowCommand">

                    <Columns>
                            <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                            <asp:ImageButton ID="ImgDelRows" runat="server" CausesValidation="True"  
                             ImageUrl="~/Image/Icons/close.png"   commandname="deleterow" ValidationGroup = '<%# "Group_" + Container.DataItemIndex %>' />
                            </ItemTemplate>
                            </asp:TemplateField>
                                <asp:BoundField DataField="SrNo" HeaderText="SrNo" />
                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                <asp:BoundField DataField="Sublocation" HeaderText="Sublocation" />
                                <asp:BoundField DataField="AssetType" HeaderText="AssetType" />
                                <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" />  
                                <asp:BoundField DataField="No_of_items" HeaderText="Quantity" /> 
                                <asp:BoundField DataField="Created_date" HeaderText="Create Date" />  
                                <asp:TemplateField HeaderText="Remarks" >                             
                            <ItemTemplate>
                   <asp:TextBox ID="txtremarks" runat="server" Columns="12" CssClass="textbox"  
                    MaxLength="12"  Width="70px" ValidationGroup = '<%# "Group_" + Container.DataItemIndex %>' CausesValidation="True"></asp:TextBox>


                                    <asp:RequiredFieldValidator ID="Req1" runat="server" 
                ControlToValidate="txtremarks" ErrorMessage="*" ValidationGroup = '<%# "Group_" + Container.DataItemIndex %>'></asp:RequiredFieldValidator>


                        </ItemTemplate>
                         </asp:TemplateField>                          
                        </Columns>

                        <AlternatingRowStyle CssClass="GridAI" />
                        <HeaderStyle CssClass="HeaderStyle" />
                        <PagerStyle CssClass="PageStyle" />
                        <RowStyle CssClass="GirdItem" />
                        <SelectedRowStyle CssClass="GridRowGreen" />
                    </asp:GridView>
                </asp:Panel>
                                          
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    
</asp:Content>

