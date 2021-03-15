<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="AssetReport.aspx.cs" Inherits="AssetManagment_AssetReport" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 
 <%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script src="Scripts/jquery.min.js"></script>  
<script type="text/javascript"> 
    $("[src*=plus]").live("click", function () {
        $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>")
        $(this).attr("src", "../Image/minus.png");
    });
    $("[src*=minus]").live("click", function () {
        $(this).attr("src", "../Image/plus.png");
        $(this).closest("tr").next().remove();
    });
</script>

    <table class="mytable">
        <tr>
            <td class="tableheader" colspan="6">Asset Report</td>
        </tr>
        <tr>
            <td class="NormalText">Asset type</td>
            <td class="NormalText">
                <telerik:radcombobox id="ddlAssetType" runat="server"
                    datasourceid="SqlDataSource1" onselectedindexchanged="ddlAssetType_SelectedIndexChanged"
                    datatextfield="ASSET" datavaluefield="ASSET_ID" autopostback="True"
                    enablecheckallitemscheckbox="True">
                     <Items>
                         <telerik:RadComboBoxItem runat="server" />
                     </Items>
                 </telerik:radcombobox>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Select '' as Asset,-1 as Asset_ID Union SELECT ITEM_NAME AS ASSET, ASSET_ID  FROM JCT_ASSET_MASTER WHERE STATUS=@STATUS ORDER BY ASSET_ID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="STATUS" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText">asset category</td>
            <td class="NormalText">
                <telerik:radcombobox id="ddlAssetCatg" runat="server"
                    datasourceid="SqlDataSource2" onselectedindexchanged="ddlAssetCatg_SelectedIndexChanged"
                    datatextfield="ASSET_TYPE_NAME"
                    datavaluefield="ASSET_TYPE_ID" autopostback="True">
                     <Items>
                         <telerik:RadComboBoxItem runat="server" />
                     </Items>
                 </telerik:radcombobox>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Select '' as Asset_type_Name,-1 as Asset_Type_ID  Union SELECT ASSET_TYPE_NAME ,ASSET_TYPE_ID FROM JCT_ASSET_TYPE_MASTER WHERE STATUS='A' AND ASSET_ID=@ASSET_ID ORDER BY ASSET_TYPE_ID">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="ddlAssetType" Name="ASSET_ID" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText"></td>
            <td class="NormalText">
             
            </td>
        </tr>
        <tr>
            <td class="NormalText">

                Item Description
            </td>
            <td class="NormalText">
                    <telerik:radcombobox id="ddlItemDesc" runat="server" datasourceid="SqlDataSource4"
                    datatextfield="type_name" datavaluefield="SrNo">
                                 </telerik:radcombobox>
                <asp:SqlDataSource ID="SqlDataSource4" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="select distinct type_name,SrNo  from jct_asset_type_master_detail where status=@status and asset_type_ID=@ASSET_TYPE_ID">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="A" Name="status" Type="String" />
                        <asp:ControlParameter ControlID="ddlAssetCatg" Name="ASSET_TYPE_ID" PropertyName="SelectedValue" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
            <td class="NormalText"></td>
            <td class="NormalText"></td>
            <td class="NormalText"></td>
            <td class="NormalText"></td>

        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">Asset State</td>
            <td class="NormalText" style="width: 122px">
                <asp:DropDownList ID="ddlassetstae" runat="server"
                    DataSourceID="SqlDataSource13" DataTextField="state_desc"
                    DataValueField="state_id" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource13" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="Select '' as state_desc,-1 as state_id Union SELECT state_desc,state_id FROM jct_asset_state_master  where status='A' and module_usedby='MIS' order by state_id"></asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 115px">EmpCode</td>
            <td class="NormalText">
                 <asp:TextBox ID="txtempcode" runat="server" AutoPostBack="true" CssClass="textbox" OnTextChanged="txtempcode_TextChanged"   ></asp:TextBox>

                  <div id="divwidth" style="display:none;">   
                            <cc1:AutoCompleteExtender ID="txtEmployee_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="5" MinimumPrefixLength="1" 
                            ServiceMethod="GetEmployeeDepartment" TargetControlID="txtempcode" 
                            CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList">
                        </cc1:AutoCompleteExtender></div>  
            </td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px; height: 21px;">Shared</td>
            <td class="NormalText" style="width: 122px; height: 21px;">
                <asp:DropDownList ID="ddlshared" runat="server" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Yes</asp:ListItem>
                    <asp:ListItem>No</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 115px; height: 21px;">ComputerName</td>
            <td class="NormalText" style="height: 21px">
                <asp:TextBox ID="txtcompname" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="height: 21px"></td>
            <td class="NormalText" style="height: 21px"></td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">ItemName</td>
            <td class="NormalText" style="width: 122px">
                <asp:TextBox ID="txtitemname" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 115px">Sr.no</td>
            <td class="NormalText">
                <asp:TextBox ID="txtsrno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">Location</td>
            <td class="NormalText" style="width: 122px">
                  <asp:DropDownList ID="ddldept" runat="server" Visible="true"
                    CssClass="combobox" DataSourceID="SqlDataSource30" 
                    DataTextField="location" DataValueField="ID">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource30" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="Select -1 as ID,'' as location Union SELECT ID,location FROM jct_asset_location_master WHERE STATUS='A' order by ID">
                </asp:SqlDataSource>
               <%-- <asp:DropDownList ID="ddldept" runat="server"
                    DataSourceID="SqlDataSource14" DataTextField="deptname"
                    DataValueField="deptcode" AppendDataBoundItems="True" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource14" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="SELECT deptname,deptcode   FROM DEPTMAST"></asp:SqlDataSource>--%>
            </td>
            <td class="NormalText" style="width: 115px">Computer Type</td>
            <td class="NormalText">
                   <asp:DropDownList ID="ddlComputerType" runat="server" AppendDataBoundItems="True" CssClass="combobox">
                    <asp:ListItem Selected="True"></asp:ListItem>
                    <asp:ListItem>Desktop</asp:ListItem>
                    <asp:ListItem>Laptop</asp:ListItem>
                    <asp:ListItem>Server</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">Manufacturer</td>
            <td class="NormalText" style="width: 122px">
                <asp:DropDownList ID="ddlmanufacturer" runat="server" CssClass="combobox"
                    DataSourceID="SqlDataSource3" DataTextField="name"
                    DataValueField="id" AppendDataBoundItems="True">
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                    SelectCommand="SELECT name,id from dbo.jct_asset_manufacturer_master WHERE status='A' and type='manufacturer' order by id"></asp:SqlDataSource>
            </td>
            <td class="NormalText" style="width: 115px">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 80px">ModelNo</td>
            <td class="NormalText" style="width: 122px">
                <asp:TextBox ID="txtmodelno" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 115px">Capital Item</td>
            <td class="NormalText">
                <telerik:radcombobox id="ddlCapitalItem" runat="server">
                    <Items>
                        <telerik:RadComboBoxItem runat="server" />
                        <telerik:RadComboBoxItem runat="server" Text="Yes" Value="1" />
                        <telerik:RadComboBoxItem runat="server" Text="No" Value="0" />
                    </Items>
                </telerik:radcombobox>
            </td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText" style="width: 97px">Date From</td>
            <td class="NormalText" style="width: 122px">
                <telerik:RadDatePicker ID="txtFrom" Runat="server">
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText" style="width: 115px">Date To</td>
            <td class="NormalText" id="txtTo">
                <telerik:RadDatePicker ID="txtTo" Runat="server">
                </telerik:RadDatePicker>
            </td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                <asp:LinkButton ID="lnkfetch" runat="server" CssClass="buttonc"
                    OnClick="lnkfetch_Click">Fetch</asp:LinkButton>
                <asp:LinkButton ID="lnkCancel" runat="server" CssClass="buttonc">Cancel</asp:LinkButton>
                <asp:LinkButton ID="lnkExcel" runat="server" CssClass="buttonc" OnClick="ExportToExcel">Excel</asp:LinkButton>
                  <asp:LinkButton ID="lnkApproval" runat="server" CssClass="buttonc" OnClick="lnkApproval_Click">Approval</asp:LinkButton>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">
                      <asp:GridView ID="grdDetail" runat="server" Width="100%"  EmptyDataText="No Record Found ..."
                          EnableModelValidation="True" DataKeyNames="requestid" 
                          onrowdatabound="grdDetail_RowDataBound" OnSelectedIndexChanged="grdDetail_SelectedIndexChanged" OnRowCommand="grdDetail_RowCommand" OnRowDeleting="grdDetail_RowDeleting">
                          <AlternatingRowStyle CssClass="GridAI" />
                          <SelectedRowStyle CssClass="SelectedRowStyle" />
                          <HeaderStyle CssClass="GridHeader" />
                          <RowStyle CssClass="GridItem" />
                          <Columns>
                            
                              <asp:TemplateField HeaderText="E-mail">
                                  <ItemTemplate>
                                      <asp:LinkButton ID="lnkemail" runat="server" BorderStyle="None" 
                                          CommandName="Sendmail" CssClass="emailicon" Height="16px" Width="16px" 
                                          onclick="lnkemail_Click" Enabled="False"></asp:LinkButton>
                                  </ItemTemplate>
                              </asp:TemplateField>
                            
                        <asp:HyperLinkField HeaderText="Preview"  Text="Preview"  DataNavigateUrlFields="RequestID" 
                                      DataNavigateUrlFormatString="asset_item_print.aspx?requestid={0}"
                                        DataTextField="RequestID" DataTextFormatString="Preview" Target="_blank" />
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
                                 
                      </asp:GridView>
                      </asp:Panel>
</asp:Content>

