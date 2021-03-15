<%@ Page Title="" Language="C#" MasterPageFile="~/AssetMngmnt/MasterPage.master" AutoEventWireup="true" CodeFile="Furniture_Accepted_Pending_Report.aspx.cs" Inherits="AssetMngmnt_Furniture_Accepted_Pending_Report" %>

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
            <td class="tableheader" colspan="6">Asset Furniture Accepted / Pending :</td>
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
            <td class="NormalText" style="width: 115px"><%--Request Id--%>Report Type</td>
             <td class="NormalText" style="width: 122px">

                 <%--<asp:TextBox ID="txtRequestId" runat="server" AutoPostBack="true" 
                     CssClass="textbox" onkeyup="SetContextKey()" 
                     OnTextChanged="txtRequestId_TextChanged"></asp:TextBox>--%>

                 <telerik:RadComboBox ID="ddlReport" Runat="server" AutoPostBack="True" 
                    CssClass="combobox" EnableVirtualScrolling="True" 
                    Height="85px" onselectedindexchanged="ddlloc_SelectedIndexChanged">
                     <Items>
                         <telerik:RadComboBoxItem runat="server" Selected="True" Text="OverAll" 
                             Value="Y" />
                         <telerik:RadComboBoxItem runat="server" Text="ItemWise" Value="N" />
                     </Items>
                </telerik:RadComboBox>

            </td>
            <td class="NormalText" style="width: 115px">
                <asp:Label ID="lblLocation" runat="server" Text="EmployeeName" Visible="False"></asp:Label>
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
            <td class="NormalText" style="width: 115px">Status</td>
             <td class="NormalText" style="width: 122px">

                 <telerik:RadComboBox ID="ddlStatus" Runat="server" AutoPostBack="True" 
                    CssClass="combobox" EnableVirtualScrolling="True" 
                    Height="85px" onselectedindexchanged="ddlloc_SelectedIndexChanged">
                     <Items>
                         <telerik:RadComboBoxItem runat="server"  Text="Accepted" 
                             Value="0" />
                         <telerik:RadComboBoxItem runat="server" Text="Pending" Value="1" />
                         <telerik:RadComboBoxItem runat="server" Selected="True"  Text="All" Value="2" />
                     </Items>
                </telerik:RadComboBox>

            </td>
            <td class="NormalText" style="width: 115px">
                &nbsp;</td>
            <td class="NormalText">
                                     &nbsp;</td>
            <td class="NormalText">&nbsp;</td>
            <td class="NormalText">&nbsp;</td>
        </tr>
          <tr>
            <td class="NormalText" style="width: 97px">&nbsp;</td>
               
            <td class="NormalText" style="width: 115px">
                 &nbsp;</td>
            <td class="NormalText" >
                &nbsp;</td>
          
            <td class="NormalText">
                <asp:LinkButton ID="excel" runat="server" CssClass="buttonXL" Height="32px" 
                    onclick="excel_Click" Width="32px" ToolTip="Excel"></asp:LinkButton>
              </td>
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
                       <asp:GridView ID="grdDetail" runat="server" Width="100%" EmptyDataText="No Record Found ..."
                EnableModelValidation="True">
                <AlternatingRowStyle CssClass="GridAI" />
                <SelectedRowStyle CssClass="SelectedRowStyle" />
                <HeaderStyle CssClass="GridHeader" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>
                      </asp:Panel>
                                             </ContentTemplate>
                </asp:UpdatePanel>
</asp:Content>
