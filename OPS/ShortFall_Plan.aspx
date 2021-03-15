<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="ShortFall_Plan.aspx.cs" Inherits="OPS_ShortFall_Plan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">





    <table style="width: 100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Plan Shortfall Order Quantities"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="display:none; height: 12px; font-weight: bold; font-size: 10pt; text-align: center; text-decoration: none; vertical-align: text-top;" 
                valign="baseline">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/OPS/Image/Tab_FinalPlanDisable.png" 
                    onclick="ImageButton1_Click" />
                <asp:ImageButton ID="ImageButton2" runat="server" 
                    ImageUrl="~/OPS/Image/Tab_PiorityDisable.png" />
                <asp:ImageButton ID="ImageButton3" runat="server" 
                    ImageUrl="~/OPS/Image/STab_Shortfall1.png" />
               </td>
        </tr>
        </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText" style="width: 93px">
                <asp:Label ID="Label17" runat="server" Text="Date From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 183px">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" TargetControlID="txtEffecFrom">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtEffecFrom" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 62px">
                <asp:Label ID="Label18" runat="server" Text="Date To"></asp:Label>
            </td>
            <td class="NormalText">
                <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" TargetControlID="txtEffecTo">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEffecTo" ErrorMessage="**"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                <asp:Label ID="Label19" runat="server" Text="Request From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 183px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlDept" runat="server" AutoPostBack="True" CssClass="combobox">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>Greigh Folding</asp:ListItem>
                            <asp:ListItem>Weaving</asp:ListItem>
                            <asp:ListItem>Processing</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 62px">
                &nbsp;
                <asp:Label ID="Label37" runat="server" Text="Plant"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                <asp:Label ID="lblOrderNo" runat="server" Text="Order No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 183px">
                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"></asp:TextBox>
            </td>
            <td class="NormalText" style="width: 62px">
                <asp:Label ID="lblOrderNo0" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText">
                &nbsp;
                <asp:TextBox ID="txtSortNo" runat="server" Columns="10" CssClass="textbox" 
                    MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 93px">
                &nbsp;</td>
            <td class="NormalText" style="width: 183px">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 62px">
                &nbsp;</td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc">Reset</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td class="tableheader" style="color: #008080">
                                    <asp:Image ID="ImgShortfall" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                                    Shortfall Orders
                                    <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True" 
                                        CollapseControlID="ImgShortfall" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                        CollapsedSize="0" ExpandControlID="ImgShortfall" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                        ImageControlID="ImgShortfall" ScrollContents="false" TargetControlID="Panel2" />
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="Panel2" CssClass="panelbg" runat="server" >
                    <asp:GridView ID="grdShortfall" runat="server" Width="100%"
                    AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True" 
                            ShowFooter="True" onrowcommand="grdShortfall_RowCommand" 
                                EmptyDataText="No Shortfall Request Pending." onpageindexchanging="grdShortfall_PageIndexChanging" 
                                >
                    <HeaderStyle CssClass="GridHeader" />
                        <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="GridItem" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                        <AlternatingRowStyle CssClass="GridAI" />
                    <Columns>
                                      <asp:TemplateField>
                                          <ItemTemplate>
                                              <asp:Image ID="img1" runat="server" ImageUrl="~/Image/AvailabilityFalse.png" 
                                                  Visible="False" />
                                              <asp:ImageButton ID="img" runat="server" 
                                                  ImageUrl="~/Image/AvailabilityFalse.png" onclick="img_Click" />&nbsp;&nbsp;
                                                  <cc1:ConfirmButtonExtender ID="btnConfirm" ConfirmText="Are Your Sure..??"  runat="server" TargetControlID="img" ></cc1:ConfirmButtonExtender>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Select">
                                          <ItemTemplate>
                                              <asp:LinkButton ID="lnkSelect" runat="server" CommandName="Select" 
                                                  CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" 
                                                  onclick="lnkSelect_Click" >Select</asp:LinkButton>
                                          </ItemTemplate>
                                      </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Customer">
                                       <ItemTemplate>
                                           <asp:Label ID="lblCustomer" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Order No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrderno" runat="server" Text='<%# Eval("order_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Line Item">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItem" runat="server" Text='<%# Eval("order_srl_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shade">
                                       <ItemTemplate>
                                           <asp:Label ID="lblShade" runat="server" Text='<%# Eval("Shade") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Sort">
                                       <ItemTemplate>
                                             <asp:Label ID="lblSort" runat="server" Text='<%# Eval("item_no") %>' ></asp:Label>
                                       
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Weaving Sort">
                                       <ItemTemplate>
                                             <asp:Label ID="lblWeavingSort" runat="server" Text='<%# Eval("WeavingSort") %>' ></asp:Label>
                                       
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Order Qty.">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("req_qty") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                <asp:TemplateField HeaderText="ShortFall">
                                        <ItemTemplate>
                                          <asp:Label ID="txtShortfall" runat="server" Text='<%# Eval("Shortfall") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                          <asp:Label ID="txtRemarks" runat="server" Text='<%# Eval("Remarks") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="TransID">
                                        <ItemTemplate>
                                          <asp:Label ID="lblTransID" runat="server" Text='<%# Eval("TransID") %>' ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                 
            
                </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <table style="width: 100%">
                            <tr>
                                <td class="tableheader" style="color: #008080">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                                    Plan Shortfall Orders
                                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" AutoCollapse="False" AutoExpand="True" 
                                        CollapseControlID="Image2" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                        CollapsedSize="0" ExpandControlID="Image2" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                        ImageControlID="Image2" ScrollContents="false" TargetControlID="pnlShortfall" />
                                </td>
                            </tr>
                        </table>
                        <asp:Panel ID="pnlShortfall"  runat="server" Visible="false" >
                            <asp:FormView ID="frvShortfall" runat="server" Width="36%" CssClass="panelbg" 
                                onitemcommand="frvShortfall_ItemCommand">
                           
                                <ItemTemplate>
                                  <table style="width:100%;">
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label17" runat="server" Text="Customer"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblCustomer" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label18" runat="server" Text="Order No"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblOrder" runat="server" Text='<%# Eval("order_no") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label19" runat="server" Text="Order Sort"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblSort" runat="server" Text='<%# Eval("item_no") %>'></asp:Label>
                                </td>
                            </tr>
                                      <tr>
                                          <td class="NormalText" style="width: 176px">
                                              <asp:Label ID="Label35" runat="server" Text="Line Item"></asp:Label>
                                          </td>
                                          <td class="NormalText">
                                              <asp:Label ID="lblLineItem" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                          </td>
                                      </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label20" runat="server" Text="Weaving Sort"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:TextBox ID="txtWeavingSort" runat="server" Columns="6" CssClass="textbox" AutoPostBack="false"
                                        MaxLength="6" Text='<%# Eval("WeavingSort") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label21" runat="server" Text="Delivery Date"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblDeliveryDate" runat="server" Text='<%# Eval("req_dt") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label22" runat="server" Text="Expetced Delivery Date"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:TextBox ID="txtExpectedDelivery" runat="server" CssClass="textbox" 
                                        Text='<%# Eval("ac_req_dt") %>' AutoPostBack="True" 
                                        ontextchanged="txtExpectedDelivery_TextChanged"></asp:TextBox>
                                   
                                    <cc1:CalendarExtender ID="txtExpectedDelivery_CalendarExtender" runat="server" 
                                        TargetControlID="txtExpectedDelivery">
                                    </cc1:CalendarExtender>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label23" runat="server" Text="Expected Greigh Date"></asp:Label>
                                </td>
                                <td class="NormalText">
                                  <asp:TextBox ID="txtGreighDate" CssClass="textbox" runat="server"  
                                        Text='<%# Eval("Grey_Req_Dt") %>' AutoPostBack="True"></asp:TextBox>
                                    <cc1:CalendarExtender ID="txtGreighDate_CalendarExtender" runat="server" 
                                        TargetControlID="txtGreighDate">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label24" runat="server" Text="Order Qty"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("req_qty") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label25" runat="server" Text="Total Greigh Req." ></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblGreighReq" runat="server" Text='<%# Eval("GreighReq") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label26" runat="server" Text="Greigh Produced"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblGreighProduced" runat="server" 
                                        Text='<%# Eval("Greigh_Produced") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px; height: 17px;">
                                    <asp:Label ID="Label27" runat="server" Text="Shortfall (mtrs)"></asp:Label>
                                </td>
                                <td class="NormalText" style="height: 17px">
                                    <asp:Label ID="lblShortfall" runat="server" Text='<%# Eval("Shortfall") %>'></asp:Label>
                                </td>
                            </tr>
                                      <tr style="display:none;">
                                          <td class="NormalText" style="width: 176px; height: 17px;">
                                              <asp:Label ID="Label37" runat="server" Text="CaseType"></asp:Label>
                                          </td>
                                          <td class="NormalText" style="height: 17px">
                                              
                                              <asp:DropDownList ID="ddlGreigh" CssClass="combobox" runat="server" 
                                               AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="CaseType" 
                                               DataValueField="CaseType" 
                                               onselectedindexchanged="ddlGreigh_SelectedIndexChanged">
                                           </asp:DropDownList>

                                           <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                               ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                               SelectCommand="Select '--Select--' as [CaseType] Union SELECT Distinct  [CaseType] FROM production..[JCT_Process_Greigh_Request_Variation] where GetDate() between Eff_from and Eff_To">
                                           </asp:SqlDataSource>

                                              </td>
                                      </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px; height: 25px;">
                                    <asp:Label ID="Label28" runat="server" Text="Mtrs to Re-Produce"></asp:Label>
                                </td>
                                <td class="NormalText" style="height: 25px">
                                    <asp:TextBox ID="txtMtrsReProduced" runat="server" Columns="6" 
                                        CssClass="textbox" MaxLength="10" Text='<%# Eval("Shortfall") %>' 
                                        AutoPostBack="True" ontextchanged="txtMtrsReProduced_TextChanged"></asp:TextBox>
                                    <asp:Label ID="Label33" runat="server" Text="mtrs"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label29" runat="server" Text="Greigh Adj"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:TextBox ID="txtGreighAdj" runat="server" Columns="6" CssClass="textbox" 
                                        MaxLength="10" Text='<%# Eval("GreighAdj") %>' AutoPostBack="True" 
                                        ontextchanged="txtGreighAdj_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                                      <tr>
                                          <td class="NormalText" style="width: 176px">
                                              <asp:Label ID="Label34" runat="server" Text="Sizing"></asp:Label>
                                          </td>
                                          <td class="NormalText">
                                              <asp:TextBox ID="txtSizing" runat="server" Columns="6" CssClass="textbox" 
                                                  MaxLength="10" Text='<%# Eval("Sizing") %>'></asp:TextBox>
                                          </td>
                                      </tr>
                                      <tr>
                                          <td class="NormalText" style="width: 176px">
                                              <asp:Label ID="Label36" runat="server" Text="Total Greigh Req"></asp:Label>
                                          </td>
                                          <td class="NormalText">
                                              <asp:TextBox ID="txtTotalGreighRequired" runat="server" Columns="6" 
                                                  CssClass="textbox" MaxLength="10" Text='<%# Eval("Shortfall") %>'></asp:TextBox>
                                          </td>
                                      </tr>
                            <tr  >
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label30" runat="server" Text="Shed"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:DropDownList ID="ddlShed" runat="server" AutoPostBack="True" 
                                        CssClass="combobox" DataSourceID="SqlDataSource1" 
                                        DataTextField="PARAMETER" DataValueField="PARAMETER_CODE" 
                                        onselectedindexchanged="ddlShed_SelectedIndexChanged" 
                                        SelectedValue='<%# Eval("Shed") %>'>
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                        SelectCommand="Select '--Select--' as [PARAMETER_CODE],'--Select--'  [PARAMETER] union SELECT  [PARAMETER_CODE],[PARAMETER] FROM [jct_ops_multi_master] WHERE (([Status] = @Status) AND ([PARENT_CATEGORY] = @PARENT_CATEGORY)) ORDER BY [PARAMETER]">
                                        <SelectParameters>
                                            <asp:Parameter DefaultValue="A" Name="Status" Type="String" />
                                            <asp:Parameter DefaultValue="ShedDays" Name="PARENT_CATEGORY" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label31" runat="server" Text="Looms"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:TextBox ID="txtLooms" runat="server" Columns="3" CssClass="textbox" 
                                        MaxLength="3" Text='<%# Eval("LoomAllot") %>' AutoPostBack="True" 
                                        ontextchanged="txtLooms_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    <asp:Label ID="Label32" runat="server" Text="Wvg Days"></asp:Label>
                                </td>
                                <td class="NormalText">
                                    <asp:Label ID="lblWvgDays" runat="server" 
                                        Text='<%# Eval("WvgCompletionDays") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="buttonbackbar" colspan="2">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="lnkSubmit" runat="server" CssClass="buttonc" 
                                                onclick="lnkSubmit_Click" CommandName="Submit">Submit</asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="NormalText" style="width: 176px">
                                    &nbsp;</td>
                                <td class="NormalText">
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="100">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/load.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                                </ItemTemplate>
                           
                            </asp:FormView>
                </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="grdShortfall" 
                            EventName="RowCommand" />
                      
                        <asp:AsyncPostBackTrigger ControlID="frvShortfall" EventName="ItemCommand" />
                      
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table> 
    
</asp:Content>
