<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="AssetFurnitureReport.aspx.cs" Inherits="AssetMngmnt_AssetFurnitureReport" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type = "text/javascript">
    function SetContextKey() {
        $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlloc.ClientID %>").value);
    }
</script>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">Asset Furniture Report</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">Asset Category</td>
            <td class="NormalText" style="width: 122px">
                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>



<%--                <telerik:RadComboBox ID="ddlAssetCatg" runat="server" autopostback="True" 
                    datasourceid="SqlDataSource2" datatextfield="ASSET_TYPE_NAME" 
                    datavaluefield="ASSET_TYPE_ID" 
                    onselectedindexchanged="ddlAssetCatg_SelectedIndexChanged">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" />
                    </Items>
                </telerik:RadComboBox>--%>

                <telerik:RadComboBox ID="ddlAssetCatg" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource2" DataTextField="ASSET_TYPE_NAME" 
                    DataValueField="ASSET_TYPE_ID" onselectedindexchanged="ddlAssetCatg_SelectedIndexChanged" 
                    >

                   <Items>
                        <telerik:RadComboBoxItem runat="server" />
                    </Items>

                </telerik:RadComboBox>

                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="Select '' as Asset_type_Name,-1 as Asset_Type_ID  Union SELECT ASSET_TYPE_NAME ,ASSET_TYPE_ID FROM JCT_ASSET_TYPE_MASTER WHERE STATUS='A' AND ASSET_ID=22 ORDER BY Asset_type_Name">
                 <%--   <SelectParameters>
                        <asp:ControlParameter ControlID="ddlAssetType" Name="ASSET_ID" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>--%>
                </asp:SqlDataSource>

                                 </ContentTemplate>
                </asp:UpdatePanel>

            </td>
            <td class="NormalText" style="width: 115px">Item Description</td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <telerik:RadComboBox ID="ddlItemDesc" runat="server" 
                    datasourceid="SqlDataSource4" datatextfield="type_name" datavaluefield="SrNo">
                </telerik:RadComboBox>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="select '' as  type_name, -1 as srno union select distinct type_name,SrNo  from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="status" Type="String" />
                        <asp:ControlParameter ControlID="ddlAssetCatg" Name="ASSET_TYPE_ID" 
                            PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText"></td>
            <td class="NormalText">
             
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">

             Location</td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>

                <div id="divwidth" style="display:none;">
                </div>
<%--                  <telerik:RadComboBox ID="ddlloc" Runat="server" AutoPostBack="True" 
                      DataSourceID="SqlDataSource30" DataTextField="location" DataValueField="ID" 
                      EnableVirtualScrolling="True" ontextchanged="ddlloc_TextChanged">
                  </telerik:RadComboBox>
                  <asp:SqlDataSource ID="SqlDataSource30" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:test %>" 
                      SelectCommand="Select -1 as ID,'' as location Union SELECT ID,location FROM jct_asset_location_master WHERE STATUS='A' AND Module_usedby = 'GEN' order by ID">
                  </asp:SqlDataSource>
--%>
                 <telerik:RadComboBox ID="ddlloc" Runat="server" AutoPostBack="True" 
                    CssClass="combobox" EnableVirtualScrolling="true" ExpandDirection="Down" 
                    Height="85" onselectedindexchanged="ddlloc_SelectedIndexChanged" Visible="true">
                </telerik:RadComboBox>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">SubLocation</td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                <%-- <asp:DropDownList ID="ddldept" runat="server"
                    DataSourceID="SqlDataSource14" DataTextField="deptname"
                    DataValueField="deptcode" AppendDataBoundItems="True" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource14" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="SELECT deptname,deptcode   FROM DEPTMAST"></asp:SqlDataSource>--%>


                <%--   <telerik:RadDatePicker ID="txtFrom" Runat="server">
                </telerik:RadDatePicker>--%>
 
                   <telerik:RadComboBox ID="ddlSubloc" Runat="server" AutoPostBack="True" 
                    CssClass="combobox" EnableVirtualScrolling="True" Height="85px">
                    <Items>       
    <telerik:RadComboBoxItem runat="server"></telerik:RadComboBoxItem>     
                 </Items> 
                </telerik:RadComboBox>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText"></td>
            <td class="NormalText"></td>

        </tr>
        <tr>
            <td class="NormalText" style="width: 115px">Asset State</td>
             <td class="NormalText" style="width: 122px">
                                      <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>
                
<%--                  <asp:DropDownList ID="ddldept" runat="server" Visible="true"
                    CssClass="combobox" DataSourceID="SqlDataSource30" 
                    DataTextField="location" DataValueField="ID">
                </asp:DropDownList>--%>

         <telerik:RadComboBox ID="ddlassetstae" Runat="server" 
                  EnableVirtualScrolling="True" 
                  DataTextField="state_desc"
                  DataValueField="state_id"                  
                  Selected="True"
                  DataSourceID="SqlDataSource13">
                 </telerik:RadComboBox>


                <asp:SqlDataSource ID="SqlDataSource13" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Select '' as state_desc,-1 as state_id Union SELECT state_desc,state_id FROM jct_asset_state_master  where status='A' AND Module_usedby = 'GEN' order by state_id"></asp:SqlDataSource>
                    
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">
                <asp:Label ID="lblLocation" runat="server" Text="EmployeeCode" Visible="False"></asp:Label>
            </td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                    <ContentTemplate>


                <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="true" 
                    CssClass="textbox" onkeyup="SetContextKey()" 
                    OnTextChanged="txtempcode_TextChanged" Visible="False"></asp:TextBox>
                <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                    CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                    CompletionListElementID="divwidth" 
                    CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                    CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="5" 
                    MinimumPrefixLength="1" ServiceMethod="GetEmployeeDepartment_test" 
                    ServicePath="~/WebService.asmx" TargetControlID="txtempcode" 
                    UseContextKey="True">
                </cc1:AutoCompleteExtender>

                
                 </ContentTemplate>
                </asp:UpdatePanel>

            </td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText" style="width: 115px">Date From</td>
            <td class="NormalText">
                                     <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                    <ContentTemplate>
                <%-- <telerik:RadDatePicker ID="txtTo" Runat="server">
                </telerik:RadDatePicker>--%>
               <asp:TextBox ID="txtFrom" runat="server" Width="75px"></asp:TextBox> 
               
                <cc1:calendarextender ID="txtdop_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtFrom">
                </cc1:calendarextender>

                <cc1:MaskedEditExtender ID="MEE1" runat="server" MaskType="Date" 
                    Mask="99/99/9999" TargetControlID="txtFrom" >
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV1" runat="server" 
                    ControlExtender="MEE1" ControlToValidate="txtFrom" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV1" 
                InvalidValueMessage="INVALID DATE"  TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory"                         
                    ></cc1:MaskedEditValidator>
                
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 115px">Date To</td>
            <td class="NormalText" >
                                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                    <ContentTemplate>
                <%-- <asp:GridView ID="grdDetail" runat="server" Width="100%"  EmptyDataText="No Record Found ..."
                          EnableModelValidation="True" DataKeyNames="requestid" 
                          onrowdatabound="grdDetail_RowDataBound">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                          <HeaderStyle CssClass="GridHeader" />
                          <RowStyle CssClass="GridItem" />
                          <Columns>
                            
                 
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                                      <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                                      </cc1:ConfirmButtonExtender>
                                  </ItemTemplate>
                              </asp:TemplateField>
                            
                              <asp:HyperLinkField DataNavigateUrlFields="requestid" DataNavigateUrlFormatString="itemdetail.aspx?requestid={0}" Text="Modify" />
             
                              <asp:TemplateField>
                                  <ItemTemplate>
                           
                                          <img id="imgdiv<%# Eval("requestid") %>" alt="Click to show/hide  for detail <%# Eval("requestid") %>"
                                              width="9px" border="0" src="../Image/plus.png" />
                                     
                                       
                                      <div id="RequestID-<%# Eval("requestid") %>" Style="display: none"  position:"relative; left: 25px;">
                                          <asp:GridView ID="nestedGridView" runat="server" Width="50%"
                                              AutoGenerateColumns="False" DataKeyNames="asset_id,asset_type_id">
                                              <SelectedRowStyle CssClass="SelectedRowStyle" />
                                              <HeaderStyle CssClass="GridHeader" />
                                              <RowStyle CssClass="GridItem" />
                                              <AlternatingRowStyle CssClass="GridAI" />
                                              <Columns>
                                                  <asp:BoundField DataField="asset_type_name" HeaderText="Asset Type Name" />
                                                  <asp:BoundField DataField="item_desc" HeaderText="Item Description" />
                                              </Columns>
                                          </asp:GridView>
                                      </div>
                                  </ItemTemplate>
                              </asp:TemplateField>
                             </Columns>
                                 
                      </asp:GridView>--%>
              <asp:TextBox ID="txtTo" runat="server" Width="75px"></asp:TextBox>

             <cc1:calendarextender ID="Calendarextender1" runat="server" 
                    Enabled="True" TargetControlID="txtTo">
            </cc1:calendarextender>
                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" MaskType="Date" 
                    Mask="99/99/9999" TargetControlID="txtTo" >
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                    ControlExtender="MEE1" ControlToValidate="txtTo" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV1" 
                InvalidValueMessage="INVALID DATE"  TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory"                         
                    ></cc1:MaskedEditValidator>

                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
          
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText" style="width: 97px"><%--Report Type--%></td>
               <td class="NormalText">
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Visible="False">
                                            <asp:ListItem Selected="True">Individual</asp:ListItem>
                                            <asp:ListItem>Summary</asp:ListItem>
                                        </asp:RadioButtonList>
              </td>
            <td class="NormalText" style="width: 115px">&nbsp;</td>
            <td class="NormalText" >
                &nbsp;</td>
          
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText" style="width: 97px">&nbsp;</td>
               <td class="NormalText">
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                <telerik:RadComboBox ID="ddlAssetType" runat="server" autopostback="True" 
                    datasourceid="SqlDataSource1" datatextfield="ASSET" datavaluefield="ASSET_ID" 
                    enablecheckallitemscheckbox="True" Visible="False" 
                       >
                    <Items>
                        <telerik:RadComboBoxItem runat="server" />
                    </Items>
                </telerik:RadComboBox>
<%--                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:test %>"
                    SelectCommand="Select '' as Asset,-1 as Asset_ID Union SELECT ITEM_NAME AS ASSET, ASSET_ID  FROM JCT_ASSET_MASTER WHERE STATUS=@STATUS  AND Module_usedby = 'GEN'  ORDER BY ASSET_ID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>


                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT ITEM_NAME AS ASSET, ASSET_ID  FROM JCT_ASSET_MASTER WHERE STATUS=@STATUS  AND Module_usedby = 'GEN'  ORDER BY ASSET_ID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                                 </ContentTemplate>
                </asp:UpdatePanel>
              </td>
            <td class="NormalText" style="width: 115px">&nbsp;</td>
            <td class="NormalText" >
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px" ToolTip="Excel"></asp:LinkButton>
              </td>
          
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText" >
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <progresstemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </progresstemplate>
                </asp:UpdateProgress>
              </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                            <asp:UpdatePanel ID="Updbuttons" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc" 
                    onclick="lnkfetch_Click" ValidationGroup="mandatory">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="buttonc" 
                    Visible="False">Cancel</asp:LinkButton>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" Visible="False">Excel</asp:LinkButton>
                  <asp:LinkButton ID="lnkApproval" runat="server" CssClass="buttonc" 
                    Visible="False">Approval</asp:LinkButton>
                                       </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

      <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                     <%-- <asp:GridView ID="grdDetail" runat="server" Width="100%"  EmptyDataText="No Record Found ..."
                          EnableModelValidation="True" DataKeyNames="requestid" 
                          onrowdatabound="grdDetail_RowDataBound">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                          <HeaderStyle CssClass="GridHeader" />
                          <RowStyle CssClass="GridItem" />
                          <Columns>
                            
                 
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                                      <cc1:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server" ConfirmText="Are you sure ?" TargetControlID="lnkDelete">
                                      </cc1:ConfirmButtonExtender>
                                  </ItemTemplate>
                              </asp:TemplateField>
                            
                              <asp:HyperLinkField DataNavigateUrlFields="requestid" DataNavigateUrlFormatString="itemdetail.aspx?requestid={0}" Text="Modify" />
             
                              <asp:TemplateField>
                                  <ItemTemplate>
                           
                                          <img id="imgdiv<%# Eval("requestid") %>" alt="Click to show/hide  for detail <%# Eval("requestid") %>"
                                              width="9px" border="0" src="../Image/plus.png" />
                                     
                                       
                                      <div id="RequestID-<%# Eval("requestid") %>" Style="display: none"  position:"relative; left: 25px;">
                                          <asp:GridView ID="nestedGridView" runat="server" Width="50%"
                                              AutoGenerateColumns="False" DataKeyNames="asset_id,asset_type_id">
                                              <SelectedRowStyle CssClass="SelectedRowStyle" />
                                              <HeaderStyle CssClass="GridHeader" />
                                              <RowStyle CssClass="GridItem" />
                                              <AlternatingRowStyle CssClass="GridAI" />
                                              <Columns>
                                                  <asp:BoundField DataField="asset_type_name" HeaderText="Asset Type Name" />
                                                  <asp:BoundField DataField="item_desc" HeaderText="Item Description" />
                                              </Columns>
                                          </asp:GridView>
                                      </div>
                                  </ItemTemplate>
                              </asp:TemplateField>
                             </Columns>
                                 
                      </asp:GridView>--%>
                       <asp:GridView ID="grdDetail" runat="server" Width="100%"  EmptyDataText="No Record Found ..."  
                          onrowdatabound="grdDetail_RowDataBound" AutoGenerateColumns="False">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                          <HeaderStyle CssClass="GridHeader" />
                          <RowStyle CssClass="GridItem" /> 
                          <Columns>  
                            <asp:HyperLinkField DataNavigateUrlFields="requestid" DataNavigateUrlFormatString="Itemdetail_Furniture.aspx?requestid={0}" Text="Modify" />
                             <asp:BoundField DataField="Sr_no" HeaderText="Sr_no" />
                             <asp:BoundField DataField="sublocation" HeaderText="sublocation" />
                             <asp:BoundField DataField="Usercode" HeaderText="Asset Type Name" />
                             <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                             <asp:BoundField DataField="AssetCategory" HeaderText="AssetCategory" />
                             <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" />
                             <asp:BoundField DataField="NoOfItems" HeaderText="NoOfItems" />
                             
                        <%--     <asp:BoundField DataField="AllocationDate" HeaderText="AllocationDate" />--%>

                              <asp:TemplateField HeaderText="AllocationDate">
                                  <ItemTemplate>
                                      <asp:TextBox ID="txtunmapdate" runat="server" Columns="12" CssClass="textbox" Text='<%# Eval("AllocationDate") %>'
                                          MaxLength="12" Width="70px" ToolTip="MM/DD/YYYY "></asp:TextBox>
                                  </ItemTemplate>
                              </asp:TemplateField>

                              <asp:TemplateField HeaderText="Update">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImgSaveRecord" runat="server" CausesValidation="False" ImageUrl="~/Image/Icons/Action/document_save.png"
                                           Width="20" Height="20" onclick="ImgSaveRecord_Click"  />
                                  </ItemTemplate>
                              </asp:TemplateField>


                              <asp:BoundField DataField="RequestId" HeaderText="RequestId" />
                             <asp:BoundField DataField="Jointly" HeaderText="Jointly" />
                             <asp:BoundField DataField="TransNo" HeaderText="TransNo" />                             
                          </Columns>                                       
                      </asp:GridView>
                      </asp:Panel>
                                             </ContentTemplate>
                </asp:UpdatePanel>
</asp:Content>

