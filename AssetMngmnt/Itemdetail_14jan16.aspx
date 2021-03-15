<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="Itemdetail.aspx.cs" Inherits="AssetMngmnt_Itemdetail" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="5">
                Item detail</td>
        </tr> 

        <tr>
            <td class="NormalText" style="width: 112px">
                Location </td>
            <td class="NormalText">
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:DropDownList ID="ddlloc" runat="server" Visible="true"
                    CssClass="combobox" DataSourceID="SqlDataSource30" 
                    DataTextField="location" DataValueField="ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource30" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="Select -1 as Id,'' as location Union SELECT ID,location FROM jct_asset_location_master WHERE STATUS='A' AND module_usedby='MIS'  order by ID">
                </asp:SqlDataSource>
            </td>

            <td class="NormalText">
                 <asp:Label ID="Label20" runat="server" Text="Computer Type"></asp:Label>
            </td>
                 <td class="NormalText" style="width: 112px">
                     <asp:DropDownList ID="ddlSelectAsset" runat="server" CssClass="combobox">
                         <asp:ListItem>Desktop</asp:ListItem>
                         <asp:ListItem>Laptop</asp:ListItem>
                         <asp:ListItem>Server</asp:ListItem>
                     </asp:DropDownList>
               
            </td>
               <td class="NormalText" style="width: 112px" runat="server" visible="false">
                <asp:SqlDataSource ID="SqlDataSource11" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                       SelectCommand="SELECT vendor FROM dbo.jct_asset_manufacturer_master WHERE status='A'">
                </asp:SqlDataSource>
                Asset<telerik:RadComboBox ID="ddlAsset" Runat="server"
                 DataSourceID="SqlDataSource11" DataTextField="item_name" 
                    DataValueField="asset_id" AutoPostBack="True" 
                    onselectedindexchanged="ddlAsset_SelectedIndexChanged">
                </telerik:RadComboBox>
                </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                Empcode</td>
            <td class="NormalText" style="width: 277px">
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%><%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="textbox" OnTextChanged="txtEmpCode_TextChanged"></asp:TextBox>

                  <div id="divwidth" style="display:none;">   
                            <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
                            ServiceMethod="GetEmployeeDepartment" TargetControlID="txtEmpCode" 
                            CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList">
                        </cc1:AutoCompleteExtender></div>  


<%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
            <td class="NormalText" style="width: 141px" >
                &nbsp;</td>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                    Visible="False">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
               
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>


        <tr>
            <td class="NormalText" style="width: 112px">
                Asset State</td>
            <td class="NormalText" style="width: 277px">
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:DropDownList ID="ddlState" runat="server" DataSourceID="SqlDataSource13" 
                    DataTextField="state_desc" DataValueField="state_id" CssClass="combobox">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource13" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT state_desc,state_id FROM jct_asset_state_master where Status='A' AND module_usedby='MIS'">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 141px">
                Plant</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlShadred" runat="server" CssClass="combobox">
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>TAFFETA</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                Item Name</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtItemName" runat="server" CssClass="textbox" Columns="50" 
                    MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtItemName" ErrorMessage="*" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 141px">
                ComputerName</td>
            <td class="NormalText">
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>
                <asp:TextBox ID="txtComputerName" runat="server" CssClass="textbox" 
                    Columns="50" MaxLength="50" OnTextChanged="txtComputerName_TextChanged"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtComputerName" Display="Dynamic" ErrorMessage="*" 
                    ValidationGroup="mandatory"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
              </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                Item Description</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtItemDescription" runat="server" CssClass="textbox" Height="50px" 
                    TextMode="MultiLine" Columns="50" MaxLength="500"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                CapitalItem</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlCapital" runat="server" CssClass="combobox">
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="0">NO</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                ModelNo</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtModelNo" runat="server" CssClass="textbox" Columns="50" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                JCT Sr.No</td>
            <td class="NormalText">
                <asp:TextBox ID="txtJctsrno" runat="server" CssClass="textbox" OnTextChanged="txtJctsrno_TextChanged"></asp:TextBox>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                Sr.No</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtsrno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 141px">
                Vendor Name</td>
            <td class="NormalText">
    
                <asp:UpdatePanel id="Updvendor" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                         <asp:DropDownList ID="ddlvendor" visible="true" runat="server" 
                    DataSourceID="SqlDataSource24" DataTextField="name" 
                    DataValueField="name" CssClass="combobox" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
              <asp:SqlDataSource ID="SqlDataSource24" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT name FROM dbo.jct_asset_manufacturer_master WHERE status='A' and type='vendor' AND module_usedby='MIS'">
                </asp:SqlDataSource> 
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                DOP</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtDOP" runat="server" CssClass="textbox" Columns="12" 
                    MaxLength="12"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdop_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdop">
                </cc1:CalendarExtender>
            </td>
              <td class="NormalText" runat="server" visible="true" style="width: 112px">
                  Manufacturer</td>
            <td class="NormalText" >
                   <asp:UpdatePanel id="UpdManufacturer" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                <asp:DropDownList ID="ddlManufacturer" visible="true" runat="server" 
                    DataSourceID="SqlDataSource23" DataTextField="name" 
                    DataValueField="id" CssClass="combobox">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
              <asp:SqlDataSource ID="SqlDataSource23" runat="server" 
                ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                SelectCommand="SELECT '' AS name ,'' AS [id] UNION  SELECT name,[id] from dbo.jct_asset_manufacturer_master WHERE status='A' and type='Manufacturer' AND module_usedby='MiS'">
            </asp:SqlDataSource> 
            </ContentTemplate>
                       <Triggers>
                           <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                       </Triggers>
            </asp:UpdatePanel>
         
            </td>
           
            <td class="NormalText" >
                &nbsp;</td>
           
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                AcquisitionDate</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtAcqDt" runat="server" CssClass="textbox" Columns="12" 
                    MaxLength="12"></asp:TextBox>
                <cc1:CalendarExtender ID="txtacqdt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtacqdt">
                </cc1:CalendarExtender>
            </td>
             <td class="NormalText" style="width: 112px">
                 IP Address</td>
               <td class="NormalText">
                   <asp:TextBox ID="txtIP" runat="server" CssClass="textbox" OnTextChanged="txtIP_TextChanged"></asp:TextBox>
            </td>
               <td class="NormalText">
                   &nbsp;</td>
        </tr>
        <tr  runat="server" visible="false">
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="Label18" runat="server" Text="Printer Type"></asp:Label>
            </td>
            <td class="NormalText" style="width: 277px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPrinterType" runat="server" AutoPostBack="True" CssClass="combobox" OnSelectedIndexChanged="ddlPrinterType_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>DMP</asp:ListItem>
                            <asp:ListItem>DMP Line</asp:ListItem>
                            <asp:ListItem>Inkjet</asp:ListItem>
                            <asp:ListItem>Label</asp:ListItem>
                            <asp:ListItem>Laser</asp:ListItem>
                            <asp:ListItem>Psc</asp:ListItem>
                            <asp:ListItem>Coloured Laser</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
             <td class="NormalText" style="width: 112px">
                 &nbsp;</td>
               <td class="NormalText">
                   &nbsp;</td>
               <td class="NormalText">
                   &nbsp;</td>
        </tr>
        <tr  runat="server" visible="false">
            <td class="NormalText" style="width: 112px; height: 16px;">
                <asp:Label ID="Label19" runat="server" Text="Select Printer"></asp:Label>
            </td>
            <td class="NormalText" style="width: 277px; height: 16px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="combobox">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkReset" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
             <td class="NormalText" style="width: 112px; height: 16px;">
                <asp:Label ID="Label21" runat="server" Text="Printer description"></asp:Label>
            </td>
               <td class="NormalText">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox ID="txtPrinterDesc" runat="server" CssClass="textbox" Height="40px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlPrinterType" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                   </td>
               <td class="NormalText">
                   </td>
        </tr>
        <tr  runat="server" visible="false">
            <td class="NormalText" colspan="1">
                Shared</td>
            <td class="NormalText">
                <asp:DropDownList ID="ddlshared" runat="server" CssClass="combobox">
                    <asp:ListItem>Printer</asp:ListItem>
                    <asp:ListItem>Scanner</asp:ListItem>
                </asp:DropDownList>
            </td>
                <td class="NormalText">
                    Shared User</td>
                <td class="NormalText">
                    <asp:TextBox ID="txtshareduser" runat="server" CssClass="textbox" Height="40px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
                <td class="NormalText">
                &nbsp;</td>
        </tr>
        </table>
    <table class="mytable">
        <tr>
            <td class="NormalText">

                <asp:UpdatePanel ID="UpdItemDetail" runat="server">
                    <ContentTemplate>

                           <asp:GridView ID="grdItemDetail" runat="server"  EnableModelValidation="True" Visible="False" OnRowCommand="grdItemDetail_RowCommand">
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="GridHeader" />
                    <RowStyle CssClass="GridItem" />
                     <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                       <asp:CheckBox runat="server" ID="chkRemove" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                         </Columns>
                </asp:GridView>

                    </ContentTemplate>
                </asp:UpdatePanel>
             
                
            </td>
        </tr>
        <tr>
            <td class="NormalText">

             <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

                <asp:UpdatePanel id="UpdGrdDetail" runat="server">
                    <ContentTemplate>

                          <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" EnableModelValidation="True" onrowcommand="grdDetail_RowCommand" onrowdatabound="grdDetail_RowDataBound ">
                            <AlternatingRowStyle CssClass="GridAI" />
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" ImageUrl="~/Image/Icons/close.png" onclick="ImageButton1_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AssetType">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlAssetTypeGrid" Runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="ASSET" DataValueField="ASSET_ID" EnableCheckAllItemsCheckBox="True" OnSelectedIndexChanged="ddlAssetType_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT ITEM_NAME AS ASSET, ASSET_ID  FROM JCT_ASSET_MASTER WHERE STATUS=@STATUS  AND module_usedby= 'Mis' ORDER BY ASSET_ID">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AssetCategory">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlAssetCatg" Runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="ASSET_TYPE_NAME" DataValueField="ASSET_TYPE_ID" OnSelectedIndexChanged="ddlAssetCatg_SelectedIndexChanged">
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT ASSET_TYPE_NAME ,ASSET_TYPE_ID FROM JCT_ASSET_TYPE_MASTER WHERE STATUS='A' AND ASSET_ID=@ASSET_ID ORDER BY ASSET_TYPE_NAME">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlAssetTypeGrid" Name="ASSET_ID" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemDescripction">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlItemDesc" Runat="server"  AutoPostBack="True"  Height="200" EnableVirtualScrolling="true" ExpandDirection="Down"  CheckBoxes="True" DataSourceID="SqlDataSource3" DataTextField="item_desc" DataValueField="item_id" EnableCheckAllItemsCheckBox="True">
                                        </telerik:RadComboBox>
                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="A" Name="status" Type="String" />
                                                <asp:ControlParameter ControlID="ddlAssetCatg" Name="ASSET_TYPE_ID" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                      
                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

                
      
                
            </td>
        </tr>
        
        </table>
    
    <table class="mytable">
        <tr>
            <td class="NormalText">
                
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>

        <table style="width:100%">
        <tr>
            <td class="buttonbackbar">

                <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" onclick="lnksave_Click" ValidationGroup="mandatory">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" onclick="LinkButton1_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" onclick="lnkupdate_Click">Update</asp:LinkButton>

                                <cc1:ConfirmButtonExtender
                                ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkDelete" ConfirmText="Are u sure To Delete ?" >
                            </cc1:ConfirmButtonExtender>

                        <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" OnClick="lnkDelete_Click" Visible="False">Delete</asp:LinkButton>
                        <asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc" onclick="lnkaddrow_Click">AddRow</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
      
    </table>
            </asp:Content>

