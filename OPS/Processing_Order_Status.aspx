<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="Processing_Order_Status.aspx.cs" Inherits="OPS_Processing_Order_Status" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Processing Order Status</td>
        </tr>
         <tr>
            <td class="NormalText" style="width: 123px">
                Date From</td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>

                <cc1:calendarextender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:calendarextender>
            </td>
            <td class="NormalText" style="width: 127px">
                Date To</td>
            <td>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:calendarextender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:calendarextender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Sales Team</td>
            <td class="NormalText" style="width: 152px">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesTeam" runat="server" AutoPostBack="True" 
                            CssClass="combobox" onselectedindexchanged="ddlSalesTeam_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="NormalText" style="width: 127px">
                Sales Person</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlSalesPerson" runat="server" CssClass="combobox" 
                            AutoPostBack="True" 
                            onselectedindexchanged="ddlSalesPerson_SelectedIndexChanged">
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
            <td class="NormalText" style="width: 152px">

                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtCustomer_TextChanged" Width="200px"></asp:TextBox>
  
                    <div id="divwidth" style="display:none;">   
                        <cc1:autocompleteextender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:autocompleteextender>
                        </div>
            </td>
            <td class="NormalText" style="width: 127px">
                Order No</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                                <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"  
                    ontextchanged="txtOrderNo_TextChanged" AutoPostBack="True" EnableViewState="False"></asp:TextBox>
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
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
    <table style="width:100%;">
    <tr>
    <td class="NormalText">
        <asp:Label ID="Label16" runat="server" Text="Processing Scheduled Orders "></asp:Label>
     </td>

    </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel1" runat="server">
                            <asp:GridView ID="GridView1" runat="server" Width="100%" 
                                AutoGenerateColumns="False" EnableModelValidation="True" 
                                style="margin-top: 1px">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OrderNo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("orderno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line Item">
                                        <ItemTemplate>
                                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cloth Type">
                                        <ItemTemplate>
                                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("Blend") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ReqQty">
                                        <ItemTemplate>
                                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PlanQTY">
                                        <ItemTemplate>
                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("PlanQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Issued Mtrs">
                                        <ItemTemplate>
                                            <asp:Label ID="Label24" runat="server" Text='<%# Eval("IssuedMtrs") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sale Person">
                                        <ItemTemplate>
                                            <asp:Label ID="Label25" runat="server" Text='<%# Eval("SalePerson") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
        <table style="width:100%;">
    <tr>
    <td class="NormalText">
        <asp:Label ID="Label1" runat="server" 
            Text="Orders Running Beyond Schedule Date"></asp:Label>
     </td>

    </tr>
        <tr>
            <td class="NormalText">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel2" runat="server">
                            <asp:GridView ID="GridView2" runat="server" Width="100%" 
                                AutoGenerateColumns="False" EnableModelValidation="True" 
                                style="margin-top: 1px">
                                <AlternatingRowStyle CssClass="GridAI" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <asp:Label ID="Label17" runat="server" Text='<%# Eval("Customer") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OrderNo">
                                        <ItemTemplate>
                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("orderno") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <asp:Label ID="Label19" runat="server" Text='<%# Eval("Item") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Line Item">
                                        <ItemTemplate>
                                            <asp:Label ID="Label20" runat="server" Text='<%# Eval("LineItem") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Blend">
                                        <ItemTemplate>
                                            <asp:Label ID="Label21" runat="server" Text='<%# Eval("Blend") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ReqQty">
                                        <ItemTemplate>
                                            <asp:Label ID="Label22" runat="server" Text='<%# Eval("ReqQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PlanQTY">
                                        <ItemTemplate>
                                            <asp:Label ID="Label23" runat="server" Text='<%# Eval("PlanQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Schedule Date">
                                     <ItemTemplate>
                                            <asp:Label ID="Label32" runat="server" Text='<%# Eval("ScheduleDt") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dyeing Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="Label27" runat="server" Text='<%# Eval("DyeingQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Finished Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="Label28" runat="server" Text='<%# Eval("FinishedQty") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Finished On">
                                       
                                        <ItemTemplate>
                                            <asp:Label ID="Label24" runat="server" Text='<%# Eval("FinishedOn") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Dyed On">
                                        <ItemTemplate>
                                            <asp:Label ID="Label29" runat="server" Text='<%# Eval("DyedOn") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OverDue">
                                        <ItemTemplate>
                                            <asp:Label ID="Label30" runat="server" Text='<%# Eval("OverDue") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Expected Delivery">
                                        <ItemTemplate>
                                            <asp:Label ID="Label31" runat="server" Text='<%# Eval("ExpectedDeilvery") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="GridHeader" />
                                <RowStyle CssClass="GridItem" />
                            </asp:GridView>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>

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
</asp:Content>

