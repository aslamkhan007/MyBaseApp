<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" EnableEventValidation="false" CodeFile="SaleOrderAdjustment10.aspx.cs" Inherits="OPS_SaleOrderAdjustment10" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


<table style="width: 100%;">
   <tr>
   <td class="tableheader">
   Sale Order Adjustment
   </td>
   </tr>
    <tr>
    <td colspan="2">
    <div style="border: 1px solid #CCCCCC; padding: 10px;">
        <table style="width: 100%;">
        <tr>
            <td class="rowElem" style="width: 84px">
                <asp:Label ID="Label16" runat="server" CssClass="NormalText" Text="Select Year"></asp:Label>
            </td>
            <td class="rowElem" style="width: 130px">
                <asp:DropDownList ID="ddlYear" runat="server" CssClass="combobox">
                   <asp:ListItem Value="2012">2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="BoundColumn_Date" style="width: 79px">
                <asp:Label ID="Label18" runat="server" CssClass="NormalText" Text="Order No"></asp:Label>
            </td>
            <td class="rowElem">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtOrderNo" runat="server" Columns="17" CssClass="textbox" 
                            MaxLength="18"></asp:TextBox>
                              <asp:ImageButton ID="ImageButton2" runat="server" Height="16px"  ToolTip="Search Weaved Orders"
                            ImageUrl="~/Image/search_new.png" Width="16px" />
                            <cc1:ModalPopupExtender ID="ImageButton2_ModalPopupExtender" runat="server" 
                                        DropShadow="True" PopupControlID="pnlSearchorders" TargetControlID="ImageButton2" 
                                        BackgroundCssClass="modalBackground" CancelControlID="btnClose">
                                    </cc1:ModalPopupExtender>
                    </ContentTemplate>
                    <Triggers>
               
                          <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grdSearchOrders" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        
        <tr>
            <td class="rowElem" style="width: 84px">
                <asp:Label ID="Label19" runat="server" CssClass="NormalText" Text="Subject"></asp:Label>
            </td>
            <td class="rowElem" style="width: 130px">
                <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Enabled="False">Greigh Transfer</asp:TextBox>
            </td>
            <td class="BoundColumn_Date" style="width: 79px">
                <asp:Label ID="Label17" runat="server" CssClass="NormalText" 
                    Text="Select Month" Visible="False"></asp:Label>
            </td>
            <td class="rowElem">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="combobox" 
                            Visible="False">
                            <asp:ListItem value="00">Choose Month</asp:ListItem>
                            <asp:ListItem Value="01">Jan</asp:ListItem>
                            <asp:ListItem value="02">Feb</asp:ListItem>
                            <asp:ListItem value="03">March </asp:ListItem>
                            <asp:ListItem value="04">April</asp:ListItem>
                            <asp:ListItem value="05">May</asp:ListItem>
                            <asp:ListItem value="06">June</asp:ListItem>
                            <asp:ListItem value="07">July</asp:ListItem>
                            <asp:ListItem value="08">August</asp:ListItem>
                            <asp:ListItem value="09">September</asp:ListItem>
                            <asp:ListItem value="10">October</asp:ListItem>
                            <asp:ListItem value="11">November</asp:ListItem>
                            <asp:ListItem value="12">December</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                
                </asp:UpdatePanel>
            </td>
        </tr>
        
        </table>
        <table style="width: 100%;">
        
        <tr>
            <td class="rowElem" style="width: 84px">
                <asp:Label ID="Label20" runat="server" CssClass="NormalText" Text="Remarks"></asp:Label>
            </td>
            <td class="rowElem">
                <asp:TextBox ID="txtRemarks" runat="server" CssClass="textbox" Height="40px" 
                    TextMode="MultiLine" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtRemarks" ErrorMessage="**Field Required" 
                    ValidationGroup="A"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="2">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkReset" runat="server" CssClass="buttonc" 
                            onclick="lnkReset_Click">Reset</asp:LinkButton>

                             <asp:LinkButton ID="lnkCheckStatus" runat="server" CssClass="buttonc" 
                            onclick="lnkCheckStatus_Click"> Check Status</asp:LinkButton>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>

        </table>
        <table style="width: 100%;">
        <tr>
            <td class="rowElem">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="grd" runat="server" Width="100%" EnableModelValidation="True" 
                                onselectedindexchanged="grd_SelectedIndexChanged1">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                   
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>

        </table>
        <p>
        </p>
        <table style="width: 100%;">
        <tr>
            <td class="rowElem">
                  <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:GridView ID="GridView1" runat="server" Width="100%" 
                                AutoGenerateColumns="False" EnableModelValidation="True" 
                                onrowcommand="GridView1_RowCommand" 
                               >
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Remove" 
                                                ImageUrl="~/Image/Icons/close.png" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Order No">
                                        <ItemTemplate>
                                     
                                        
                                                    <asp:TextBox ID="txtOrdNo" runat="server" Columns="18" MaxLength="18" 
                                                        Text='<%# Eval("Orderno") %>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                        ControlToValidate="txtOrdNo" Display="Dynamic" ErrorMessage="**" 
                                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                                    <asp:ImageButton ID="imgRefresh" runat="server" 
                                                        ImageUrl="~/Image/refresh-icon.gif" CommandName="Refresh" 
                                                         />
                                               
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sort">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblSort" runat="server"    Text='<%# Eval("Sort") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Line Item">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblLineItem" runat="server"    Text='<%# Eval("LineItem") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                       <asp:TemplateField HeaderText="Shade">
                                        <ItemTemplate>
                                          
                                                    <asp:Label ID="lblShade" runat="server"    Text='<%# Eval("Shade") %>'></asp:Label>
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Sale Price">
                                        <ItemTemplate>
                                         
                                                 <asp:Label ID="lblSalesPrice" runat="server"    Text='<%# Eval("SalesPrice") %>'></asp:Label>
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                         
                                                 <asp:Label ID="lblQty" runat="server"    Text='<%# Eval("Qty") %>'></asp:Label>
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Select Type">
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlCaseType" CssClass="combobox" runat="server" 
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
                                    <asp:TemplateField HeaderText="Greigh Req">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGreighReq" runat="server" Text="0"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Greigh Adjust">
                                        <ItemTemplate>
                                         
                                                    <asp:TextBox ID="txtAdjust" runat="server" Columns="10" MaxLength="10"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                        ControlToValidate="txtAdjust" Display="Dynamic" ErrorMessage="**" 
                                                        ValidationGroup="A"></asp:RequiredFieldValidator>
                                                
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="lnkAddRow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="grd" EventName="SelectedIndexChanged" />
                    
                        <asp:AsyncPostBackTrigger ControlID="GridView1" EventName="RowCommand" />
                    </Triggers>
                </asp:UpdatePanel>
                
                </td>
        </tr>
         </table>
             <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>      
                        <asp:Panel ID="pnlButtons" Visible="false"  runat="server">
          <table style="width:100%">
        <tr>  
     
            <td class="buttonbackbar">
          
                 
                            <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" Height="22px" 
                                OnClick="lnkSave_Click" ValidationGroup="A">Send Request</asp:LinkButton>
                            <cc1:ConfirmButtonExtender ID="lnkSave_ConfirmButtonExtender" runat="server" 
                                ConfirmText="Submitting the data will forward your request to planning.!! Are you sure you want to make adjustment ?" 
                                TargetControlID="lnkSave">
                            </cc1:ConfirmButtonExtender>
                            <asp:LinkButton ID="lnkAddRow" runat="server" CssClass="buttonc" 
                                OnClick="lnkAddRow_Click">Add Row</asp:LinkButton>
                            <asp:LinkButton ID="lnkPopUp" runat="server" Visible="false" OnClick="lnkPopUp_Click">LinkButton</asp:LinkButton>
                            <cc1:ModalPopupExtender ID="lnkPopUp_ModalPopupExtender" runat="server" BackgroundCssClass="modalBackground"
                                CancelControlID="btnCancel" OkControlID="btnSubmit" PopupControlID="pnlPopUp"
                                TargetControlID="lnkPopUp">
                            </cc1:ModalPopupExtender>
                   
                
               
                
                </td>    
                   
        </tr>

        </table>
          </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="grd" EventName="SelectedIndexChanged" />
                       
                        </Triggers>
                    </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress2" runat="server" 
            AssociatedUpdatePanelID="UpdatePanel6" DisplayAfter="100">
            <ProgressTemplate>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/load.gif" />
            </ProgressTemplate>
        </asp:UpdateProgress>
     
        
        </div>
        </td>
        </tr>
        </table>
    
     <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlCheckStatus" runat="server" Visible="false">
            <asp:GridView ID="grdCheckStatus" runat="server" Width="100%">
                <AlternatingRowStyle CssClass="GridAI" />
                <HeaderStyle CssClass="GridHeader" />
                <RowStyle CssClass="GridItem" />
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="lnkCheckStatus" EventName="Click" />
             <asp:AsyncPostBackTrigger ControlID="lnkSave" EventName="Click" />
              <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:Panel ID="pnlSearchorders" runat="server" CssClass="panelbg" Width="400px"   Style="display:none;"
            ScrollBars="Vertical" Height="250px">
            <table style="width:100%;">
            <tr>
                    <td class="tableheader">
                        <asp:Label ID="Label21" runat="server" Text="Search Sale Order"></asp:Label>
                    </td>
                    </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="NormalText" style="width: 78px">
                        <asp:Label ID="Label22" runat="server" Text="Sort No"></asp:Label>
                    </td>
                    <td class="NormalText">
                        <asp:TextBox ID="txtSortNo" runat="server" Columns="10" CssClass="textbox" 
                            MaxLength="10"></asp:TextBox>
                               <cc1:FilteredTextBoxExtender ID="txtSortNo_FilteredTextBoxExtender" 
                            runat="server" FilterType="Numbers" InvalidChars="0,1,2,3,4,5,6,7,8,9" 
                            TargetControlID="txtSortNo">
                        </cc1:FilteredTextBoxExtender>
                              (Only digits are allowed.. i.e. 38118 ,2229 )
                    </td>
                </tr>
                <tr>
                    <td class="NormalText" style="width: 78px">
                        &nbsp;</td>
                    <td class="NormalText">
                        <asp:Button ID="btnSearch" runat="server" onclick="btnSearch_Click" 
                            Text="Search" />
                        <asp:Button ID="btnClose" runat="server" Text="Close" />
                    </td>
                </tr>
            </table>
            <table style="width:100%;">
                <tr>
                    <td class="NormalText">
                        <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="grdSearchOrders" runat="server" EnableModelValidation="True" 
                                    onselectedindexchanged="grdSearchOrders_SelectedIndexChanged" Width="100%">
                                    <AlternatingRowStyle CssClass="GridAI" />
                                    <Columns>
                                        <asp:CommandField ShowSelectButton="True" />
                                    </Columns>
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridItem" />
                                    <SelectedRowStyle CssClass="SelectedRowStyle" />
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </asp:Panel>

</asp:Content>

