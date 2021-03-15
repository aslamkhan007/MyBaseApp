<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Final_Plan10.aspx.cs" Inherits="OPS_Planning_Final_Plan10" %>
<%@ Register Src="../FlashMessage.ascx" TagName="FlashMessage" TagPrefix="uc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<script type="text/javascript" language="javascript">

    function showDate(sender, args) {
        if (sender._textbox.get_element().value == "") {
            var todayDate = new Date();
            sender._selectedDate = todayDate;
        }
    }

</script>

<script type="text/javascript">
       function CurrentDateShowing(e) 
      {
           if (!e.get_selectedDate() || !e.get_element().value)
              e._selectedDate = (new Date()).getDateOnly();
     }     
      </script>
      <script type="text/javascript">
          function ChangeRowColor(row) {
              $("#" + row).css("backgroundColor", "#ffffda");
          }
      </script>
     
    
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="5">
                <asp:Label ID="Label1" runat="server" Text="Final Plan"></asp:Label>
                
                <asp:HiddenField ID="hdfWvgCompletionDt" runat="server" />
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 130px">
                <asp:Label ID="Label2" runat="server" Text="Effective From"></asp:Label>
            </td>
            <td class="NormalText" style="width: 133px">
                <asp:TextBox ID="txtEffecFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecFrom" 
                    onclientshowing="showDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtEffecFrom" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText" style="width: 82px">
                <asp:Label ID="Label3" runat="server" Text="Effective To"></asp:Label>
            </td>
            <td class="NormalText" style="width: 366px">
                <asp:TextBox ID="txtEffecTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtEffecTo_CalendarExtender" runat="server" 
                    TargetControlID="txtEffecTo"  onclientshowing="showDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtEffecTo" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 130px; height: 23px">
                <asp:Label ID="Label4" runat="server" Text="Select Plant"></asp:Label>
            </td>
            <td class="NormalText" style="width: 133px; height: 23px">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox" >
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="height: 23px; width: 82px;">
            </td>
            <td class="NormalText" style="height: 23px; width: 366px;">
            </td>
            <td class="NormalText" style="height: 23px">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 130px">
                <asp:Label ID="Label5" runat="server" Text="Cot/Syn"></asp:Label>
            </td>
            <td class="NormalText" style="width: 133px">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlCotSyn" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Synthetic</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlPlant" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 82px">
                &nbsp;</td>
            <td class="NormalText" style="width: 366px">
                &nbsp;</td>
            <td class="NormalText">
             
                        <asp:LinkButton ID="lnkToExcel" runat="server" CssClass="buttonXL" 
                            Height="32px" onclick="lnkToExcel_Click" ToolTip="Export To Excel" 
                            Width="32px"></asp:LinkButton>
                 
            </td>
        </tr>
     
        <tr>
            <td class="NormalText" style="width: 130px">
                <asp:Label ID="Label7" runat="server" Text="Reason / Comments"></asp:Label>
            </td>
            <td class="NormalText" style="width: 133px">
                <asp:DropDownList ID="ddlReason" runat="server" CssClass="combobox">
                </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 82px">
                &nbsp;</td>
            <td class="NormalText" style="width: 366px">
                <asp:HiddenField ID="hiddencolor" runat="server" Value="False" />
            </td>
            <td class="NormalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkGenerate" runat="server" CssClass="buttonc" 
                            onclick="lnkGenerate_Click" ValidationGroup="A">Generate Plan</asp:LinkButton>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click1">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click">Save</asp:LinkButton>
                        <asp:LinkButton ID="lnkSearch" runat="server" CssClass="buttonc" 
                            Visible="False">Search</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="5" style="height: 24px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFreeze" runat="server" CssClass="buttonc" 
                            onclick="lnkFreeze_Click">Freeze</asp:LinkButton>
                        <cc1:ConfirmButtonExtender ID="lnkFreeze_ConfirmButtonExtender" runat="server" 
                            ConfirmText="Are you sure you want to freeze this plan ?" 
                            TargetControlID="lnkFreeze">
                        </cc1:ConfirmButtonExtender>
                        <asp:LinkButton ID="lnkUnFreeze" runat="server" CssClass="buttonc" 
                            onclick="lnkUnFreeze_Click" Enabled="False">UnFreeze</asp:LinkButton>
                        <cc1:PopupControlExtender ID="lnkUnFreeze_PopupControlExtender" runat="server" 
                            TargetControlID="lnkUnFreeze" PopupControlID="Panel2">
                        </cc1:PopupControlExtender>
                     
                        <asp:LinkButton ID="lnkNewSort" runat="server" CssClass="buttonc" 
                            onclick="lnkNewSort_Click">New Sort</asp:LinkButton>
                        <asp:LinkButton ID="lnkClose0" runat="server" CssClass="buttonc">Close</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="5">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                  <uc1:FlashMessage id="FMsg" runat="server" EnableTheming="true" EnableViewState="true" FadeInDuration="2" FadeInSteps="2" FadeOutDuration="4" FadeOutSteps="2" Visible="true"></uc1:FlashMessage>
                </ContentTemplate>
                </asp:UpdatePanel>
              
              </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="5">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" 
                    AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="10">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loading.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
      
    </table>
       <table style="width: 100%;">
        <tr>
            <td class="NomalText">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td class="tableheader" style="color: #008080">
                                <asp:Image ID="ImgUnFreezed" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                                UnFreezed plan
                                <cc1:CollapsiblePanelExtender ID="cpe" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="ImgUnFreezed" Collapsed="False" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="ImgUnFreezed" ExpandDirection="Vertical" ExpandedImage="~/Image/minus.png"
                                    ImageControlID="ImgUnFreezed" ScrollContents="false" TargetControlID="Panel1" />
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" CssClass="panelbg" runat="server" ScrollBars="Auto" Width="100%">
                    <asp:GridView ID="GridView1" runat="server" CssClass="GridViewStyle" Width="100%" 
                    AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True" 
                         onrowdatabound="GridView1_RowDataBound" 
                         onselectedindexchanged="GridView1_SelectedIndexChanged" 
                         onpageindexchanging="GridView1_PageIndexChanging" PageSize="100" 
                            ShowFooter="True">
                    <HeaderStyle CssClass="gridheader" />
                        <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <Columns>
                                   <asp:TemplateField HeaderText="Update">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="Update" runat="server" AutoPostBack="True" 
                                                 Text="" oncheckedchanged="Update_CheckedChanged2" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Update" runat="server" 
                                                CssClass="combobox" />
                                            <br />
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
                                        <asp:TemplateField HeaderText="Order Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrderDate" runat="server" Text='<%# Eval("Order_Dt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shade">
                                       <ItemTemplate>
                                           <asp:Label ID="lblShade" runat="server" Text='<%# Eval("Shade") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    
                                   <asp:TemplateField HeaderText="Line Item">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItem" runat="server" Text='<%# Eval("order_srl_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sort">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSort" runat="server" Text='<%# Eval("item_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Variant">
                                       <ItemTemplate>
                                           <asp:Label ID="lblVariant" runat="server" Text='<%# Eval("variant") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Plant">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPlant" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Cloth Type">
                                       <ItemTemplate>
                                           <asp:Label ID="lblClothType" runat="server" Text='<%# Eval("cloth_type") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Req. Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqdt" runat="server" Text='<%# Eval("req_dt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Order Qty.">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrderQty" runat="server" Text='<%# Eval("req_qty") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Plan Qty.">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtPlanQty" runat="server" Columns="6" MaxLength="8" CssClass="textbox" 
                                               Text='<%# Eval("plan_qty") %>' AutoPostBack="True" 
                                               ontextchanged="txtPlanQty_TextChanged"></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    
                                   <asp:TemplateField HeaderText="Sizing">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtSizing" runat="server" Columns="6"  MaxLength="8"
                                               CssClass="textbox" Text='<%# Eval("Sizing") %>'></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Case Type">
                                       <ItemTemplate>
                                           <asp:DropDownList ID="ddlGreigh" CssClass="combobox" runat="server" 
                                               AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CaseType" 
                                               DataValueField="CaseType" 
                                               onselectedindexchanged="ddlGreigh_SelectedIndexChanged">
                                           </asp:DropDownList>

                                           <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                               ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                                               SelectCommand="Select '--Select--' as [CaseType] Union SELECT Distinct  [CaseType] FROM production..[JCT_Process_Greigh_Request_Variation] where GetDate() between Eff_from and Eff_To">
                                           </asp:SqlDataSource>

                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Greigh Req.">
                                       <ItemTemplate>
                                            <asp:TextBox ID="txtGreigh" runat="server" Columns="6"  MaxLength="8"
                                               CssClass="textbox" Text='<%# Eval("GreighReq") %>' ></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Shed">
                                       <ItemTemplate>
                                           <asp:UpdatePanel ID="UpdatePanel9" runat="server" RenderMode="Inline">
                                               <ContentTemplate>
                                                   <asp:TextBox ID="txtShed" runat="server" AutoPostBack="True" Columns="2"
                                                       CssClass="textbox" MaxLength="2" 
                                                       Text='<%# Eval("Shed") %>'></asp:TextBox>
                                               <asp:DropDownList ID="ddlShed" CssClass="combobox" runat="server" 
                                               AutoPostBack="True">
                                                   <asp:ListItem>Select</asp:ListItem>
                                                   <asp:ListItem Value="R">Rapier</asp:ListItem>
                                                   <asp:ListItem Value="A">Airjet</asp:ListItem>
                                                   <asp:ListItem Value="W">Waterjet</asp:ListItem>
                                                   <asp:ListItem Value="SA">Sulzer A</asp:ListItem>
                                                   <asp:ListItem Value="SB">Sulzer B</asp:ListItem>
                                                   <asp:ListItem Value="SC">Sulzer C</asp:ListItem>
                                                   <asp:ListItem Value="SD">Sulzer D</asp:ListItem>
                                                   <asp:ListItem Value="SE">Sulzer E</asp:ListItem>
                                           </asp:DropDownList>
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                           <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                               AssociatedUpdatePanelID="UpdatePanel9" DisplayAfter="10">
                                               <ProgressTemplate>
                                                   <asp:Image ID="Image2" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                               </ProgressTemplate>
                                           </asp:UpdateProgress>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="RPM">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtRPM" runat="server" Columns="4" MaxLength="5" CssClass="textbox" Text='<%# Eval("RPM") %>'></asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Efficiency">
                                       <ItemTemplate>
                                           <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                               <ContentTemplate>
                                                   <asp:TextBox ID="txtEfficiency" runat="server" Columns="3" CssClass="textbox" 
                                                       MaxLength="3" Text='<%# Eval("Efficiency") %>'></asp:TextBox>
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Loom Allot.">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtLoomAllot" runat="server" Columns="3" MaxLength="4"  AutoPostBack="true"
                                               CssClass="textbox" Text='<%# Eval("LoomAllot") %>' 
                                               ontextchanged="txtLoomAllot_TextChanged"> </asp:TextBox>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Wvg Days">
                                       <ItemTemplate>
                                           <asp:Label ID="lblWvgCompletionDt" runat="server" 
                                               Text='<%# Eval("WvgCompletionDate") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Reed">
                                       <ItemTemplate>
                                           <asp:TextBox ID="txtReed" runat="server" Columns="3" MaxLength="4"
                                               CssClass="textbox" Text='<%# Eval("Reed") %>' > </asp:TextBox>
                                         
                                         
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Tapperet">
                                       <ItemTemplate>
                                        <asp:TextBox ID="txtTapperet" runat="server" Columns="3" MaxLength="4"
                                               CssClass="textbox" Text='<%# Eval("Cam") %>' > </asp:TextBox>
                                         
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Save">
                                       <ItemTemplate>
                                           <asp:LinkButton ID="lnkSaveRow"  runat="server" onclick="lnkSaveRow_Click">Save</asp:LinkButton>
                                       </ItemTemplate>
                                   </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                </asp:Panel>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkGenerate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUnFreeze" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNewSort" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUnFreezePopUp" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
               
                
            </td>
        </tr>
        <tr>
            <td class="NomalText">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table style="width: 100%">
                        <tr>
                            <td class="tableheader" style="color: #008080">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Image/plus.png" Style="margin-right: 5px;" />
                                Freezed Plan
                                <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" AutoCollapse="False" AutoExpand="True"
                                    CollapseControlID="Image3" Collapsed="True" CollapsedImage="~/Image/plus.png"
                                    CollapsedSize="0" ExpandControlID="Image3" ExpandDirection="Vertical"
                                    ExpandedImage="~/Image/minus.png" ImageControlID="Image3" ScrollContents="false"
                                    TargetControlID="Panel3" />
                            </td>
                        </tr>
                    </table>
                <asp:Panel ID="Panel3" CssClass="panelbg" runat="server" ScrollBars="Auto" Width="100%">
                    <asp:GridView ID="grdFreezed" runat="server" CssClass="GridViewStyle" Width="100%" 
                    AutoGenerateColumns="False" EnableModelValidation="True" AllowPaging="True" 
                         onrowdatabound="grdFreezed_RowDataBound" 
                         onselectedindexchanged="GridView1_SelectedIndexChanged" 
                         onpageindexchanging="GridView1_PageIndexChanging" PageSize="10">
                    <HeaderStyle CssClass="gridheader" />
                        <PagerStyle CssClass="PagerStyle" />
                    <RowStyle CssClass="RowStyle" />
                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                    <Columns>
                              
                                   <asp:TemplateField HeaderText="Order No">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrdernoF" runat="server" Text='<%# Eval("order_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Line Item">
                                       <ItemTemplate>
                                           <asp:Label ID="lblLineItemF" runat="server" Text='<%# Eval("order_srl_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sort">
                                       <ItemTemplate>
                                           <asp:Label ID="lblSortF" runat="server" Text='<%# Eval("item_no") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Variant">
                                       <ItemTemplate>
                                           <asp:Label ID="lblVariantF" runat="server" Text='<%# Eval("variant") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Plant">
                                       <ItemTemplate>
                                           <asp:Label ID="lblPlantF" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Cloth Type">
                                       <ItemTemplate>
                                           <asp:Label ID="lblClothTypeF" runat="server" Text='<%# Eval("cloth_type") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Req. Date">
                                       <ItemTemplate>
                                           <asp:Label ID="lblReqdtF" runat="server" Text='<%# Eval("req_dt") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Order Qty.">
                                       <ItemTemplate>
                                           <asp:Label ID="lblOrderQtyF" runat="server" Text='<%# Eval("req_qty") %>'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Plan Qty.">
                                       <ItemTemplate>

                                          <asp:Label ID="txtPlanQtyF" runat="server" Text='<%# Eval("plan_qty") %>' ></asp:Label>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Sizing">
                                       <ItemTemplate>
                                        <asp:Label ID="txtSizingF" runat="server" Text='<%# Eval("Sizing") %>' ></asp:Label>
                                         </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sizing Done">
                                       <ItemTemplate>
                                         <asp:Label ID="lblSizingDone" runat="server" Text="0"></asp:Label>
                                        
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Prep.">
                                       <ItemTemplate>
                                        <asp:Label ID="lblGreigh" runat="server" Text="0"></asp:Label>
                                        </ItemTemplate>
                                   </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Status">
                                       <ItemTemplate>
                                          <asp:Label ID="lblStatus" runat="server" Text='Pending'></asp:Label>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                  
                                   <asp:TemplateField HeaderText="Shed">
                                       <ItemTemplate>
                                           <asp:UpdatePanel ID="UpdatePanel9" runat="server" RenderMode="Inline">
                                               <ContentTemplate>

                                                <asp:Label ID="txtShedF" runat="server" Text='<%# Eval("Shed") %>'></asp:Label>
                                                 
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                           <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
                                               AssociatedUpdatePanelID="UpdatePanel9" DisplayAfter="10">
                                               <ProgressTemplate>
                                                   <asp:Image ID="Image2" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                               </ProgressTemplate>
                                           </asp:UpdateProgress>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="RPM">
                                       <ItemTemplate>

                                         <asp:Label ID="txtRPMF" runat="server" Text='<%# Eval("RPM") %>'></asp:Label>
                                          
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Efficiency">
                                       <ItemTemplate>
                                           <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                               <ContentTemplate>

                                                 <asp:Label ID="txtEfficiencyF" runat="server" Text='<%# Eval("Efficiency") %>'></asp:Label>
                                                 
                                               </ContentTemplate>
                                           </asp:UpdatePanel>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Loom Allot.">
                                       <ItemTemplate>

                                         <asp:Label ID="txtLoomAllotF" runat="server" Text='<%# Eval("LoomAllot") %>'></asp:Label>

                                        
                                       </ItemTemplate>
                                   </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Days Left">
                                       <ItemTemplate>

                                        <asp:Label ID="lblWvgCompletionDtF" runat="server" Text='<%# Eval("WvgCompletionDate") %>'></asp:Label>

                                        
                                       </ItemTemplate>
                                   </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </asp:Panel>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkGenerate" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUnFreeze" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkNewSort" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowDataBound" />
                        <asp:AsyncPostBackTrigger ControlID="lnkUnFreezePopUp" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
               
                
            </td>
        </tr>

        </table>
    <table style="width: 100%;">
        <tr>
            <td class="NomalText">
                <asp:UpdatePanel ID="UpdPopUp" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server" CssClass="panelbg" Width="500px" style="display:none;">
                            <table style="width:100%;">
                                <tr>
                                    <td class="BoundColumn_Date">
                                        <asp:Label ID="Label8" runat="server" CssClass="labelcells" 
                                            Text="Please Enter Remark before unfreezing your plan."></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <table style="width:100%;">
                                <tr>
                                    <td class="BoundColumn" style="width: 16px">
                                        <asp:Label ID="Label9" runat="server" CssClass="labelcells" Text="Remarks"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="30px" 
                                            TextMode="MultiLine" 
                                            ToolTip="Please mention reason for unfreezing your freezed plan. " 
                                            Width="250px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                            ControlToValidate="txtRemarks" ErrorMessage="** Required" ValidationGroup="B"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="buttonbackbar" colspan="2">
                                        <asp:LinkButton ID="lnkUnFreezePopUp" runat="server" CssClass="buttonc" 
                                            onclick="lnkUnFreezePopUp_Click" ValidationGroup="B">UnFreeze</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkUnFreeze" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NomalText">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="NomalText">
                &nbsp;</td>
        </tr>
        </table>
    <asp:HiddenField ID="hdfRapierReed" runat="server" />
    <asp:HiddenField ID="hdfAirjetReed" runat="server" />
    <asp:HiddenField ID="hdfSulzerReed" runat="server" />
    <asp:HiddenField ID="hdfWaterjetCam" runat="server" />
    <asp:HiddenField ID="hdfAirjetCam" runat="server" />
    <asp:HiddenField ID="hdfSulzerCam" runat="server" />

</asp:Content>

