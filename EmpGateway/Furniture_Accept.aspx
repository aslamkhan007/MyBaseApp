<%@ Page Title="" Language="C#" MasterPageFile="MasterPage.master"
    AutoEventWireup="true" CodeFile="Furniture_Accept.aspx.cs" Inherits="AssetMngmnt_Furniture_Accept" %>
    
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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
            <td class="tableheader" colspan="6">
                Furniture Assets Acceptance:
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lblCurrentDate0" runat="server" Text="Location"></asp:Label>
            </td>
            <td class="labelcells">
                <%--<asp:BoundField DataField="Location" HeaderText="Location" />  --%>
                      
                    <asp:DropDownList ID="ddllocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox"  DataTextField="Sublocation" 
                    DataValueField="Sublocation" 
                    onselectedindexchanged="ddllocation_SelectedIndexChanged">
                </asp:DropDownList>
                  
            </td>
            <td class="NormalText">
                <asp:Label ID="lblCurrentDate1" runat="server" Text="SubLocation"></asp:Label>
            </td>
            <td class="NormalText">
                <%--<asp:BoundField DataField="Location" HeaderText="Location" />  --%>
           
                    <asp:DropDownList ID="ddlSublocation" runat="server" AutoPostBack="True" 
                    CssClass="combobox"  DataTextField="Sublocation" 
                    DataValueField="Sublocation">
                </asp:DropDownList>
                     
            </td>
            <td class="NormalText">
                <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="Department" runat="server" CssClass="labelcells"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText">
                <asp:Label ID="lblIssuedTo" runat="server" Text="Issued To"></asp:Label>
            </td>
            <td class="labelcells">
                <asp:Label ID="IssuedTo" runat="server"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblEmployeeCode" runat="server" Text="EmployeeCode"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="EmployeeCode" runat="server" CssClass="labelcells"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="lblRequestId" runat="server">Request Id</asp:Label>
            </td>
            <td class="NormalText">
                <asp:Label ID="RequestId" runat="server" CssClass="labelcells"></asp:Label>
            </td>        
        </tr>

                        <tr class="NormalText">
            <td class="NormalText" colspan="6">
               
                &nbsp;</td>
        </tr>


           <tr>
            <td class="NormalText" colspan="6">
                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="GrdRecordstatus" runat="server" Width="100%"  
                    Caption="Summary" CaptionAlign="Left" onselectedindexchanged="GrdRecordstatus_SelectedIndexChanged"
                    >
                    
                    <Columns>                                                                 
                                                                                                      
                    </Columns>
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GirdItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

                                <tr>
            <td class="NormalText" colspan="6">
               
            </td>
        </tr>
                <tr>
            <td class="NormalText" colspan="6">
                Items List:
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
             <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" Width="100%" 
                    AutoGenerateColumns="False" onrowdatabound="GridView1_RowDataBound">
                    <Columns>
                     
                       
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="chkRemoveALL" runat="server" AutoPostBack="True" oncheckedchanged="chkRemoveALL_CheckedChanged" 
                                    />
                            </HeaderTemplate>
                            <ItemTemplate>                            

                                <asp:CheckBox runat="server" ID="chkRemove" 
                                    oncheckedchanged="chkRemove_CheckedChanged" AutoPostBack="True" />
                            </ItemTemplate>
                        </asp:TemplateField>                  
                        <%--<asp:BoundField DataField="Location" HeaderText="Location" />  --%>

                         <asp:TemplateField HeaderText="SrNo">
                            <ItemTemplate>

                            <img alt = "" style="cursor: pointer" src="../Image/plus.png" />

                                <asp:Panel ID="pnlInnerGrid" runat="server" Style="display: none">
                                    <asp:GridView ID="InnerGridview" runat="server" CssClass="GirdItem">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                     <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px"/>
                                    <PagerStyle CssClass="Pageatyle" />
                                    <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px"/>
                                        <Columns>                                           
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("SrNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>   

                        
                      <asp:TemplateField HeaderText="Location">
                            <ItemTemplate>
                             <asp:Label ID="lblLocation" runat="server"  Text= '<%# Eval("Location") %>' ></asp:Label>                                                               
                            </ItemTemplate>
                        </asp:TemplateField>                                                                            

                        <asp:TemplateField HeaderText="SubLocation">
                            <ItemTemplate>
                             <asp:Label ID="lblSubLocation" runat="server"  Text= '<%# Eval("Sublocation") %>' ></asp:Label>                                 
                              <asp:HiddenField ID="H1RequestId" runat="Server" Value='<%# Eval("RequestId") %>' />                         
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="AssetType">
                            <ItemTemplate>
                             <asp:HiddenField ID="H1asset_id" runat="Server" Value='<%# Eval("asset_id") %>' />     
                                <asp:Label ID="lblAssetType" runat="server"  Text= '<%# Eval("AssetType") %>' ToolTip = '<%# Eval("asset_type_id") %>'  ></asp:Label>                                 
                                 
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="ItemDescription">
                            <ItemTemplate>
                                <asp:Label ID="lblItemDescription" runat="server" Text='<%# Eval("ItemDescription") %>' ToolTip = '<%# Eval("item_desc_id") %>'  ></asp:Label>                             
                                <asp:HiddenField ID="H1item_desc_value" runat="Server" Value='<%# Eval("item_desc_value") %>' />     
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TotalQty">
                            <ItemTemplate>
                                <asp:Label ID="lblTotalQty" runat="server" Text='<%# Eval("TotalQty") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

<%--                        <asp:TemplateField HeaderText="AllocationDate">
                            <ItemTemplate>
                                <asp:Label ID="lblAllocationDate" runat="server" Text='<%# Eval("AllocationDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:TemplateField HeaderText="AcceptedQty">
                            <ItemTemplate>
                                <asp:Label ID="lblAcceptedQty" runat="server" Text='<%# Eval("AcceptedQty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="PendingQty">
                            <ItemTemplate>
                                <asp:Label ID="lblPendingQty" runat="server" Text='<%# Eval("PendingQty") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Manufacturer">
                            <ItemTemplate>                            
                                <asp:Label ID="lblManufacturer" runat="server" Text='<%# Eval("ManufactureName") %>' ToolTip = '<%# Eval("manufactureId") %>'   ></asp:Label>
                                <%--<asp:HiddenField ID="H1manufacture" runat="Server" Value='<%# Eval("manufactureId") %>' />     --%>
                            </ItemTemplate>
                        </asp:TemplateField>


<%--                        <asp:TemplateField HeaderText="TransNo">
                            <ItemTemplate>
                                <asp:Label ID="lblTransNo" runat="server" Text='<%# Eval("TransNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>   --%>                                                                     
                        
                        <asp:TemplateField HeaderText="Qty Held">
                            <ItemTemplate>
                                <telerik:RadNumericTextBox ID="txtNoOfItems" runat="server" Width="40px" inputtype="Number"
                                    MaxLength="2" DataType="System.Int32" MinValue="1" Culture="en-US" 
                                    DbValueFactor="1" DbValue='<%# Convert.ToInt32(Eval("PendingQty")) %>'
                                    EmptyMessage="?" LabelWidth="32px" MaxValue="21" CausesValidation="True" 
                                    ValidationGroup="mandatory" Enabled="False" >
                                    <NumberFormat DecimalDigits="0" />
                                </telerik:RadNumericTextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNoOfItems"
                                    ErrorMessage="*" Display="Dynamic" ValidationGroup="mandatory" ForeColor="#FF3300"
                                    SetFocusOnError="True" Enabled="False"></asp:RequiredFieldValidator>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remarks">
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemarks" runat="server" Columns="12" CssClass="textbox" MaxLength="200"
                                    Width="120px" ValidationGroup="mandatory"></asp:TextBox>
                               <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRemarks"
                                    ErrorMessage="*" Display="Dynamic" ValidationGroup="mandatory" ForeColor="#FF3300"
                                    SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <AlternatingRowStyle CssClass="GridAI" />
                    <HeaderStyle CssClass="HeaderStyle" />
                    <PagerStyle CssClass="PageStyle" />
                    <RowStyle CssClass="GirdItem" />
                    <SelectedRowStyle CssClass="GridRowGreen" />
                </asp:GridView>
                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
               
                <asp:Label ID="lblMessage" runat="server" Visible="False"></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="6">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                <asp:LinkButton ID="lnkaccept" runat="server" CssClass="buttonc" 
                    OnClick="lnkaccept_Click" ValidationGroup="mandatory" Enabled="False" >Accept</asp:LinkButton>

                <cc1:ConfirmButtonExtender ID="lnkAccept_ConfirmButtonExtender" runat="server" 
                    ConfirmText="Are You Sure To Accept Checked Items ?" Enabled="True" TargetControlID="lnkaccept">
                </cc1:ConfirmButtonExtender>

                <asp:LinkButton ID="lnkRaiseConcern" runat="server" CssClass="buttonc" 
                            onclick="lnkRaiseConcern_Click" Enabled="False">Raise Concern</asp:LinkButton>
                <%--                        <asp:TemplateField HeaderText="AllocationDate">
                            <ItemTemplate>
                                <asp:Label ID="lblAllocationDate" runat="server" Text='<%# Eval("AllocationDate") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
            <asp:LinkButton ID="lnkresest" runat="server" CssClass="buttonc" 
                onclick="lnkresest_Click">Reset</asp:LinkButton>
                                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>



                <tr>
            <td  colspan="6">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound"
                Width="100%" DataKeyField="empcode">
                <HeaderTemplate>

            List of items Accepted:

         </HeaderTemplate>

                    <ItemTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LabeUserName" runat="server" Font-Bold="True" 
                                        Font-Names="Calibri" Font-Size="Large" Text='<%# Eval("empname") %>'></asp:Label>
                                        
                                        <%--Font-Names="Calibri" Font-Size="Large" Text='<%# Eval("empname") %>'></asp:Label>--%>
                                    <asp:Label ID="Labelhead" runat="server" Font-Bold="True" Font-Names="Calibri" 
                                        Font-Size="Large" ForeColor="Black" Text='<%# Eval("empcode") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Panel ID="Panel1" runat="server" Width="900px">
                                        <asp:GridView ID="GridAccepted" runat="server" Width="100%" BorderColor="Black" Font-Names="Calibri"
                                            EmptyDataText="Now Data Present!!!">
                                            <AlternatingRowStyle BackColor="#CCCCCC" />
                                            <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                                                Height="23px" />
                                            <PagerStyle CssClass="Pageatyle" />
                                            <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
                                 </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

          <tr>
            <td class="NormalText" colspan="6">
                              
               
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="6">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                    <%-- <asp:Panel ID="pnlgrid" Width="1000px" runat="server" Height="200px" ScrollBars="Horizontal">--%>
                        <asp:GridView ID="GrdConcernItems" runat="server" Width="100%" 
                            Caption="Raise Concern Items" CaptionAlign="Left" AllowPaging="True" 
                            onpageindexchanging="GrdConcernItems_PageIndexChanging" PageSize="7">
                            <Columns>
                            </Columns>
                            <AlternatingRowStyle CssClass="GridAI" />
                            <HeaderStyle CssClass="HeaderStyle" />
                            <PagerStyle CssClass="PageStyle" />
                            <RowStyle CssClass="GirdItem" />
                            <SelectedRowStyle CssClass="GridRowGreen" />
                        </asp:GridView>
                    <%--    </asp:Panel>--%>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        

    </table>
</asp:Content>
