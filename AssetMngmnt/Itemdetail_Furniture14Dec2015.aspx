<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="Itemdetail_Furniture.aspx.cs" Inherits="AssetMngmnt_Itemdetail_Furniture" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type = "text/javascript">
    function SetContextKey() {
        $find('<%=txtEmployee_AutoCompleteExtender.ClientID%>').set_contextKey($get("<%=ddlloc.ClientID %>").value);
    }
</script>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="4">
                Furniture detail</td>
        </tr> 

        <tr>
            <td class="NormalText" style="width: 112px">
                Location</td>
            <td class="NormalText">

                <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

                 <telerik:RadComboBox ID="ddlloc" Runat="server"  Visible="true"  CssClass="combobox"
                    Height="85" EnableVirtualScrolling="true" ExpandDirection="Down"   
                     AutoPostBack="True" 
                onselectedindexchanged="ddlloc_SelectedIndexChanged">
                    </telerik:RadComboBox>

                <%--               <asp:DropDownList ID="ddlState" runat="server" DataSourceID="SqlDataSource13" 
                    DataTextField="state_desc" DataValueField="state_id" CssClass="combobox">
                </asp:DropDownList>--%><%--       <asp:DropDownList ID="ddlShadred" runat="server" CssClass="combobox">
                    <asp:ListItem>COTTON</asp:ListItem>
                    <asp:ListItem>TAFFETA</asp:ListItem>
                </asp:DropDownList>--%>

            </td>
            

                 <td class="NormalText">
                     SubLocation</td>
               <td  class="NormalText" runat="server" >
 
                   <telerik:RadComboBox ID="ddlSubloc" Runat="server" AutoPostBack="True" 
                       CssClass="combobox" DataTextField="location" 
                       DataValueField="location" EnableVirtualScrolling="true" ExpandDirection="Down" 
                       Height="85"  Visible="true" 
                       onselectedindexchanged="ddlSubloc_SelectedIndexChanged">
                   </telerik:RadComboBox>
 
                </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                <asp:Label ID="lblLocation" runat="server" Text="EmployeeCode" Visible="False"></asp:Label>
            </td>
            <td class="NormalText" style="width: 277px">

                <asp:TextBox ID="txtEmpCode" runat="server" CssClass="textbox" 
                    onkeyup = "SetContextKey()" Enabled="False" Visible="False" 
                    CausesValidation="True" ValidationGroup="mandatory" ></asp:TextBox>
                <%--                <asp:DropDownList ID="ddlCapital" runat="server" CssClass="combobox">
                    <asp:ListItem Value="1">YES</asp:ListItem>
                    <asp:ListItem Value="0">NO</asp:ListItem>
                </asp:DropDownList>--%>

                  <div id="divwidth" style="display:none;">   
                      <%--  </ContentTemplate>
                </asp:UpdatePanel>--%>

                       <cc1:autocompleteextender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
                            ServiceMethod="GetEmployeeDepartment_test" TargetControlID="txtEmpCode" 
                            CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList" UseContextKey="True">
                        </cc1:autocompleteextender>
                        
                        
                        </div>  


<%--                <asp:RequiredFieldValidator ID="ReqtxtAcqDt0" runat="server" 
                ControlToValidate="txtEmpCode" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>--%>


            </td>
            <td class="NormalText">
                
               
                &nbsp;</td>
            <td class="NormalText">
                <telerik:RadComboBox ID="ddlShadred" Runat="server" 
                    EnableVirtualScrolling="True" Height="70px" Visible="False">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" Text="COTTON" Value="COTTON" />
                        <telerik:RadComboBoxItem runat="server" Text="TAFFETA" Value="TAFFETA" />
                    </Items>
                </telerik:RadComboBox>
            </td>
        </tr>


        <tr>
            <td class="NormalText" style="width: 112px">
                Asset State</td>
            <td class="NormalText" style="width: 277px">
                <%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">--%><%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">--%>

                 <telerik:RadComboBox ID="ddlState" Runat="server"  Visible="true" 
                            Height="150" EnableVirtualScrolling="true" ExpandDirection="Down"  
                            DataSourceID="SqlDataSource13" DataTextField="state_desc" 
                            DataValueField="state_id">
                 </telerik:RadComboBox>

                <asp:SqlDataSource ID="SqlDataSource13" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT state_desc,state_id FROM jct_asset_state_master where Status='A' and module_Usedby = 'GEN' order by state_id ">
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">
                &nbsp;</td>
            <td class="NormalText">

               



<%--                <asp:TextBox ID="txtAcqDt" runat="server" Columns="12" CssClass="textbox" 
                    MaxLength="12" Width="70px"></asp:TextBox>

                <asp:RequiredFieldValidator ID="ReqtxtAcqDt" runat="server" 
                ControlToValidate="txtAcqDt" ErrorMessage="*" ValidationGroup="mandatory"></asp:RequiredFieldValidator>


                <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtAcqDt">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidator1" runat="server" 
                    ControlExtender="MEE1" ControlToValidate="txtAcqDt" Display="Dynamic" 
                    EmptyValueMessage="ENTER DATE!!" ErrorMessage="MEV1" 
                    InvalidValueMessage="INVALID DATE" TooltipMessage="MM/DD/YYYY" 
                    ValidationGroup="mandatory"></cc1:MaskedEditValidator>
                <cc1:CalendarExtender ID="txtacqdt_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtacqdt">
                </cc1:CalendarExtender>--%>



            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
                Remarks</td>
            <td class="NormalText" style="width: 277px">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="50px" 
                    TextMode="MultiLine" Columns="50" MaxLength="500"></asp:TextBox>
            </td>
            <td class="NormalText">
                
                CapitalItem</td>
            <td class="NormalText">

<%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">--%>

           <telerik:RadComboBox ID="ddlCapital" Runat="server" 
            Height="70px" EnableVirtualScrolling="True">
              <Items>
                  <telerik:RadComboBoxItem runat="server" Text="YES" 
                      Value="1" />
                  <telerik:RadComboBoxItem runat="server" Text="NO" 
                      Value="0" />
              </Items>
                 </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 112px">
     
         
              
     
         
               </td>
            <td class="NormalText" style="width: 277px">



            </td>
            <td class="NormalText" >
     
         
              
     
         
                &nbsp;</td>
           
            <td class="NormalText" >

                <asp:TextBox ID="txtDOP" runat="server" Columns="12" CssClass="textbox" 
                    MaxLength="12" Visible="False" Width="70px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtdop_CalendarExtender" runat="server" 
                    Enabled="True" TargetControlID="txtdop">
                </cc1:CalendarExtender>
                <cc1:MaskedEditExtender ID="MEE1" runat="server" Mask="99/99/9999" 
                    MaskType="Date" TargetControlID="txtDOP">
                </cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MEV1" runat="server" ControlExtender="MEE1" 
                    ControlToValidate="txtDOP" Display="Dynamic" EmptyValueMessage="ENTER DATE!!" 
                    ErrorMessage="MEV1" InvalidValueMessage="INVALID DATE" 
                    TooltipMessage="MM/DD/YYYY" ValidationGroup="mandatory"></cc1:MaskedEditValidator>

            </td>
           
        </tr>
        </table>
    <table class="mytable">
        <tr>
            <td class="NormalText">

          
                             <asp:UpdatePanel ID="UpdItemDetail" runat="server">
                    <ContentTemplate>

                           <asp:GridView ID="grdItemDetail" runat="server"  EnableModelValidation="True" Visible="False" >
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

             <%-- <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:test %>" SelectCommand="select  type_name  as item_desc,SrNo as item_id from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID and asset_type_name <>'Processor' union select type_name +', '+ type_description as item_desc,master_item_id as item_id from jct_asset_type_description where asset_type_id=@ASSET_TYPE_ID and status='A' order by type_name">--%>

                <asp:UpdatePanel id="UpdGrdDetail" runat="server">
                    <ContentTemplate>

                          <asp:GridView ID="grdDetail" runat="server" AutoGenerateColumns="False" 
                              EnableModelValidation="True" onrowdatabound="grdDetail_RowDataBound" 
                              onrowcommand="grdDetail_RowCommand">
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
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT ITEM_NAME AS ASSET, ASSET_ID  FROM JCT_ASSET_MASTER WHERE STATUS=@STATUS and module_usedby = 'GEN' ORDER BY ASSET_ID">
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
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT ASSET_TYPE_NAME ,ASSET_TYPE_ID FROM JCT_ASSET_TYPE_MASTER WHERE STATUS='A' AND ASSET_ID=@ASSET_ID ORDER BY ASSET_TYPE_NAME">
                                            <SelectParameters>
                                                <asp:ControlParameter ControlID="ddlAssetTypeGrid" Name="ASSET_ID" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ItemDescripction">
                                    <ItemTemplate>
                                        <telerik:RadComboBox ID="ddlItemDesc" Runat="server"  AutoPostBack="True"  
                                            Height="200" EnableVirtualScrolling="true" ExpandDirection="Down"  
                                           DataSourceID="SqlDataSource3" DataTextField="item_desc" 
                                            DataValueField="item_id">
                                        </telerik:RadComboBox>                                      
                                        <%--<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT TYPE_NAME + ',' + CONVERT(VARCHAR(20), quantity) + '-' + description AS item_desc , CONVERT(VARCHAR,a.SrNo) + '-'+ CONVERT(VARCHAR,b.id) AS item_id FROM   jct_asset_type_description AS a INNER JOIN jct_asset_manufacturer_master AS b ON a.manufacturer = b.id WHERE  a.status = @status AND b.status = @status AND asset_type_id = @ASSET_TYPE_ID ORDER BY TYPE_NAME ,b.description">--%>
                                            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>" SelectCommand="SELECT TYPE_NAME + ',' + CONVERT(VARCHAR(20), quantity) + '-' + description AS item_desc , CONVERT(VARCHAR, a.SrNo) + '-' + CONVERT(VARCHAR, b.id) + '$' + CONVERT(VARCHAR,a.asset_desc_id) AS item_id FROM   jct_asset_type_description AS a INNER JOIN jct_asset_manufacturer_master AS b ON a.manufacturer = b.id WHERE  a.status = @status AND b.status = @status AND asset_type_id = @ASSET_TYPE_ID ORDER BY TYPE_NAME ,b.description">
                                            <SelectParameters>
                                                <asp:Parameter DefaultValue="A" Name="status" Type="String" />
                                                <asp:ControlParameter ControlID="ddlAssetCatg" Name="ASSET_TYPE_ID" PropertyName="SelectedValue" />
                                            </SelectParameters>
                                        </asp:SqlDataSource>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="NoOfItems">
                              <ItemTemplate>
                                  <telerik:RadNumericTextBox ID="txtNoOfItems" runat="server" Width="80px" 
                                      InputType="Number" MaxLength="10" DataType="System.Int32" MinValue="1" 
                                      Culture="en-US" DbValueFactor="1" EmptyMessage="Invalid Quantity" 
                                      LabelWidth="32px" MaxValue="100" CausesValidation="True" 
                                      ValidationGroup="mandatory">
                                        <NumberFormat DecimalDigits="0" /> 
                                  </telerik:RadNumericTextBox>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                      ControlToValidate="txtNoOfItems" ErrorMessage="*" Display="Dynamic" 
                                      ValidationGroup="mandatory" ForeColor="#FF3300" SetFocusOnError="True" 
                                      ></asp:RequiredFieldValidator>
                            </ItemTemplate>
                               </asp:TemplateField>



                           <asp:TemplateField HeaderText="AllocationDate">
                              <ItemTemplate>





                                  <telerik:RadDatePicker ID="txtAcqDt" runat="server" DateFormat="MM/dd/yyyy" Width="100" DateInput-CausesValidation="True" DateInput-EmptyMessage="MM-DD-YY" MinDate="01/01/1940"  >
                                  </telerik:RadDatePicker>
                                     <asp:RequiredFieldValidator ID="ReqtxtAcqDt" runat="server" 
                                      ControlToValidate="txtAcqDt" ErrorMessage="*" Display="Dynamic" 
                                      ValidationGroup="mandatory" ForeColor="#FF3300" SetFocusOnError="True" 
                                      ></asp:RequiredFieldValidator>

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
                      
                <%--   <telerik:RadTextBox ID="txtNoOfItems1" runat="server" Width="80" 
                                      InputType="Number" MaxLength="10">
                                  </telerik:RadTextBox>--%>

                
      
                
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
                        <asp:LinkButton ID="lnksave" runat="server" CssClass="buttonc" 
                            ValidationGroup="mandatory" onclick="lnksave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>
                        <asp:LinkButton ID="lnkupdate" runat="server" CssClass="buttonc" 
                            onclick="lnkupdate_Click" ValidationGroup="mandatory">Update</asp:LinkButton>
                        <asp:LinkButton ID="lnkDelete" runat="server" CssClass="buttonc" 
                            onclick="lnkDelete_Click">Delete</asp:LinkButton>
                        <asp:LinkButton ID="lnkaddrow" runat="server" CssClass="buttonc" 
                            onclick="lnkaddrow_Click">AddRow</asp:LinkButton>
                        <asp:LinkButton ID="lnkDeallocate" runat="server" CssClass="buttonc" 
                            onclick="lnkDeallocate_Click" Visible="False">DeAllocate</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </td>
        </tr>
      
    </table>
            </asp:Content>
