<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="SetPriority_WeavePlan.aspx.cs" Inherits="OPS_SetPriority_WeavePlan" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader">
                <asp:Label ID="Label16" runat="server" Text="Set Priority To Planned Orders"></asp:Label>
            </td>
        </tr>
    </table>

    <table style="width:100%;">
        <tr>
            <td class="NormalText" style="width: 123px">
                Priority Date From</td>
            <td class="NormalText" style="width: 211px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 127px">
                Priority Date To</td>
            <td>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Sales Team</td>
            <td class="NormalText" style="width: 211px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" 
                            CssClass="combobox" 
                            onselectedindexchanged="ddlSalesTeam_SelectedIndexChanged1" >
                        </asp:DropDownList>
                     
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel4" 
                    runat="server" DisplayAfter="100">
                    <ProgressTemplate>
                        <asp:Image ID="Image1" ImageUrl="~/Image/loadingNew.gif" runat="server" />
                    </ProgressTemplate>
                
                </asp:UpdateProgress>
            </td>
            <td class="NormalText" style="width: 127px">
                Sales Person</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlSalesPerson_SelectedIndexChanged1" >
                        </asp:DropDownList>
                      
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Customer</td>
            <td class="NormalText" style="width: 211px">
                <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox"  Width="200px" 
                    ontextchanged="txtCustomer_TextChanged1"></asp:TextBox>
                      
  
                    <div id="divwidth" style="display:none;">   
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
                        </div>
            </td>
            <td class="NormalText" style="width: 127px">
                Order No</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox" 
                                    AutoPostBack="True" EnableViewState="False" 
                        ontextchanged="txtOrderNo_TextChanged"></asp:TextBox>
                           
                    <cc1:PopupControlExtender ID="PopupControlExtender1" runat="server" 
                                    PopupControlID="pnlSaleOrder" TargetControlID="txtOrderNo" 
                                    Position="Bottom">
                    </cc1:PopupControlExtender>
            
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                <asp:Label ID="Label18" runat="server" Text="Sort No"></asp:Label>
            </td>
            <td class="NormalText" style="width: 211px">

                        <asp:TextBox ID="txtSortNo" runat="server" AutoPostBack="True" 
                            CssClass="textbox"></asp:TextBox>
                                <cc1:PopupControlExtender ID="PopupControlExtender2" runat="server" 
                                    PopupControlID="pnlSortNo" TargetControlID="txtSortNo" 
                                    Position="Bottom">
                    </cc1:PopupControlExtender>
            </td>
            <td class="NormalText" style="width: 127px">
                <asp:Label ID="Label17" runat="server" Text="Select Plan Month"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlPlanMonth" runat="server" AutoPostBack="True" 
                    DataSourceID="SqlDataSource1" DataTextField="yearmonth" 
                    DataValueField="yearmonth">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                    SelectCommand="SELECT distinct [yearmonth] FROM [JCT_OPS_MONTHLY_PLANNING] WHERE (([Mode] = @Mode) AND ([status] IS NULL)) ORDER BY [yearmonth] DESC">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="Freezed" Name="Mode" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Plant</td>
            <td class="NormalText" style="width: 211px">

                        <asp:DropDownList ID="ddlPlant" runat="server" AutoPostBack="True" 
                            CssClass="combobox">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>Cotton</asp:ListItem>
                            <asp:ListItem>Taffeta</asp:ListItem>
                        </asp:DropDownList>
            </td>
            <td class="NormalText" style="width: 127px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                        <asp:LinkButton ID="lnkFetchPriority" runat="server" CssClass="buttonc" 
                            onclick="lnkFetchPriority_Click">Fetch Priority</asp:LinkButton>
                        <asp:LinkButton ID="lnkPreview" runat="server" CssClass="buttonc" 
                            onclick="lnkPreview_Click">Preview</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdateProgress ID="UpdateProgress4" 
                    AssociatedUpdatePanelID="UpdatePanel11" runat="server" DisplayAfter="100">
                <ProgressTemplate>
                    <asp:Image ID="Image4" ImageUrl="~/Image/loadingNew.gif"  runat="server" />
                </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
 <asp:Panel ID="pnlPlannedOrders" runat="server" ScrollBars="Auto" Visible="false" Width="100%" CssClass="panelbg">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td style="font-size: 10pt; font-weight: bold; width: 105px;">
                                        <asp:Label ID="Label2" runat="server" Text="Planned Orders"></asp:Label>
                                    </td>
                                    <td style="font-size: 10pt; font-weight: bold">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="10">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="NormalText">
                                        <asp:GridView ID="grd" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No Data Available" EnableModelValidation="True" 
                                            Width="100%" onselectedindexchanged="grd_SelectedIndexChanged" 
                                            onrowdatabound="grd_RowDataBound">
                                            <Columns>
                                              <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Image ID="img" ImageUrl="~/Image/AvailabilityFalse.png" runat="server" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chb" runat="server" AutoPostBack="True" 
                                                    CssClass="combobox" oncheckedchanged="Chb_CheckedChanged" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
                                                <asp:BoundField DataField="ORDERNO" HeaderText="ORDER NO" SortExpression="ORDERNO" />
                                                <asp:BoundField DataField="SORTNO" HeaderText="SORT" SortExpression="SORTNO" />
                                                <asp:BoundField DataField="LINEITEM" HeaderText="LINE ITEM" ReadOnly="True" SortExpression="LINEITEM" />
                                                <asp:BoundField DataField="Shade" HeaderText="Shade" ReadOnly="True" SortExpression="Shade" />
                                                <asp:BoundField DataField="ORDERQTY" HeaderText="ORDERQTY" ReadOnly="True" SortExpression="ORDERQTY" />
                                                <asp:BoundField DataField="PLANQTY" HeaderText="PLANQTY" ReadOnly="True" SortExpression="PLANQTY" />
                                                <asp:BoundField DataField="GreighReq" HeaderText="Greigh Req" ReadOnly="True" SortExpression="GreighReq" />
                                                <asp:BoundField DataField="ORDER_REQ_DT" HeaderText="ORDER REQDT" ReadOnly="True"
                                                    SortExpression="ORDER_REQ_DT" />
                                                <asp:BoundField DataField="GREIGH_REQ_DT" HeaderText="GREIGH REQDT" ReadOnly="True"
                                                    SortExpression="GREIGH_REQ_DT" />
                                                <asp:BoundField DataField="EXPECTED_DELIVERY_DT" HeaderText="EXPECTED DELIVERY" ReadOnly="True"
                                                    SortExpression="EXPECTED_DELIVERY_DT" />
                                                <asp:BoundField DataField="SHED" HeaderText="SHED" ReadOnly="True" SortExpression="SHED" />
                                                <asp:BoundField DataField="LOOMS" HeaderText="LOOMS" ReadOnly="True" SortExpression="LOOMS" />
                                                <asp:BoundField DataField="DAYS" HeaderText="DAYS" ReadOnly="True" SortExpression="DAYS" />
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
</ContentTemplate>
  <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
                    </Triggers>
</asp:UpdatePanel>


<asp:UpdatePanel ID="UpdatePanel5" runat="server">
                <ContentTemplate>
 <asp:Panel ID="pnlPrioritisedOrders" runat="server" ScrollBars="Auto" Visible="false" Width="100%" CssClass="panelbg">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td style="font-size: 10pt; font-weight: bold; width: 165px;">
                                        <asp:Label ID="Label1" runat="server" Text="Prioritise Orders"></asp:Label>
                                    </td>
                                    <td style="font-size: 10pt; font-weight: bold">
                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="10">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" 
                                                    />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="NormalText">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No Data Available" EnableModelValidation="True" 
                                            Width="100%">
                                            <Columns>
                                               <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="img" ImageUrl="~/OPS/Image/iPhone_Delete_icon.png" 
                                                    runat="server" onclick="img_Click" />
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtPriority" Columns="3"  Text='<%# Eval("Priority") %>' 
                                                    CssClass="textbox" runat="server" AutoPostBack="True" 
                                                    ontextchanged="txtPriority_TextChanged"></asp:TextBox>
                                               
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                    ControlToValidate="txtPriority" ErrorMessage="*" ValidationGroup="A"></asp:RequiredFieldValidator>
                                            </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:BoundField DataField="Customer" HeaderText="Customer" SortExpression="Customer" />
                                                <asp:BoundField DataField="ORDERNO" HeaderText="ORDER NO" SortExpression="ORDERNO" />
                                                <asp:BoundField DataField="SORTNO" HeaderText="SORT" SortExpression="SORTNO" />
                                                <asp:BoundField DataField="LINEITEM" HeaderText="LINE ITEM" ReadOnly="True" SortExpression="LINEITEM" />
                                                <asp:BoundField DataField="Shade" HeaderText="Shade" ReadOnly="True" SortExpression="Shade" />
                                                <asp:BoundField DataField="ORDERQTY" HeaderText="ORDERQTY" ReadOnly="True" SortExpression="ORDERQTY" />
                                                <asp:BoundField DataField="PLANQTY" HeaderText="PLANQTY" ReadOnly="True" SortExpression="PLANQTY" />
                                                <asp:BoundField DataField="GreighReq" HeaderText="Greigh Req" ReadOnly="True" SortExpression="GreighReq" />
                                                <asp:BoundField DataField="ORDER_REQ_DT" HeaderText="ORDER REQDT" ReadOnly="True"
                                                    SortExpression="ORDER_REQ_DT" />
                                                <asp:BoundField DataField="GREIGH_REQ_DT" HeaderText="GREIGH REQDT" ReadOnly="True"
                                                    SortExpression="GREIGH_REQ_DT" />
                                                <asp:BoundField DataField="EXPECTED_DELIVERY_DT" HeaderText="EXPECTED DELIVERY" ReadOnly="True"
                                                    SortExpression="EXPECTED_DELIVERY_DT" />
                                                <asp:BoundField DataField="SHED" HeaderText="SHED" ReadOnly="True" SortExpression="SHED" />
                                                <asp:BoundField DataField="LOOMS" HeaderText="LOOMS" ReadOnly="True" SortExpression="LOOMS" />
                                                <asp:BoundField DataField="DAYS" HeaderText="DAYS" ReadOnly="True" SortExpression="DAYS" />
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
</ContentTemplate>
  <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtSortNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                           
                             <asp:AsyncPostBackTrigger ControlID="lnkFetchPriority" EventName="Click" />
                    </Triggers>
</asp:UpdatePanel>

         <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>    
    <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" Width="200px" style="display:none;"  ScrollBars="Vertical">
        <asp:RadioButtonList ID="rblSaleOrder" CssClass="textbox" runat="server" 
            onselectedindexchanged="rblSaleOrder_SelectedIndexChanged" 
            AutoPostBack="True" >
        </asp:RadioButtonList>
    </asp:Panel>
    </ContentTemplate>
    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>    
    <asp:Panel ID="pnlSortNo" runat="server" CssClass="panelbg" Width="200px" style="display:none;"  ScrollBars="Vertical">
        <asp:RadioButtonList ID="rblSortNo" CssClass="textbox" runat="server" 
            
            AutoPostBack="True" >
        </asp:RadioButtonList>
    </asp:Panel>
    </ContentTemplate>
    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                             <asp:AsyncPostBackTrigger ControlID="txtOrderNo" 
                            EventName="TextChanged" />
                              <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
    </asp:UpdatePanel>
    <table style="width: 100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkSave" runat="server" CssClass="buttonc" 
                            onclick="lnkSave_Click" ValidationGroup="A">Save Priority</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>

</asp:Content>

