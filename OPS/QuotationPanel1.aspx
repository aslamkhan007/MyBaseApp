<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="QuotationPanel1.aspx.cs" Inherits="OPS_QuotationPanel1" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Quotations Panel</td>
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
                Quotation Date From</td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 127px">
                Quotation Date To</td>
            <td>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Customer</td>
            <td class="NormalText" style="width: 152px">

                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtCustomer_TextChanged" Width="200px"></asp:TextBox>
  
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
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                    onclick="lnkFetch_Click">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                &nbsp;</td>
        </tr>
        </table>
    <table style="width:100%;" class="tableback">
        <tr>
            <td class="NormalText">

        <asp:Panel ID="pnlSearch"   CssClass="panelbg" style="display:none;"
                    runat="server" Width="600px" >
                    <table style="border-style: solid; border-width: thin; width:100%;">
                        <tr>
                            <td class="NormalText" colspan="2" align="justify">
                                <asp:Label ID="Label16" runat="server" Text="Search Customer" 
                                    Font-Size="Medium"></asp:Label>
                                <asp:ImageButton ID="imgClose" runat="server" ImageAlign="Right" 
                                    ImageUrl="~/Image/exit.png" />
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" style="width: 139px">
                                <asp:Label ID="Label17" runat="server" Text="Enter Customer Name"></asp:Label>
                            </td>
                            <td class="NormalText">
                                <asp:TextBox ID="txtCustSearch" runat="server" CssClass="textbox" 
                                    ToolTip="Enter any string to search for customer" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtCustSearch" ErrorMessage="**" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:ImageButton ID="imgSearch" runat="server" 
                                    ImageUrl="~/Image/search_new.png" onclick="ImageButton2_Click" 
                                    ToolTip="Click to search" Width="23px" ValidationGroup="A" />
                            </td>
                        </tr>
                        <tr>
                            <td class="NormalText" colspan="2">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="grdCustSearch" runat="server" CssClass="GridView" 
                                            EmptyDataText="No data found." EnableModelValidation="true" Height="100%" 
                                            onpageindexchanging="grdCustSearch_PageIndexChanging" 
                                            onselectedindexchanged="grdCustSearch_SelectedIndexChanged" PageSize="20" 
                                            Width="100%">
                                            <Columns>
                                                <asp:CommandField ShowSelectButton="True" />
                                            </Columns>
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <RowStyle CssClass="RowStyle" />
                                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                                        </asp:GridView>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="imgSearch" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="grdCustSearch" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        </table>
        
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
 <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="100%" CssClass="panelbg">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td style="font-size: 10pt; font-weight: bold; width: 105px;">
                                        <asp:Label ID="Label2" runat="server" Text="Finalized Quotes"></asp:Label>
                                    </td>
                                    <td style="font-size: 10pt; font-weight: bold">
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" DisplayAfter="10">
                                            <ProgressTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="NormalText">
                                        <asp:GridView ID="grdFinalizedQuote" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No Data Available" EnableModelValidation="True" Width="100%">
                                            <Columns>
                                                <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" 
                                                    DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" HeaderText="Detail" 
                                                    NavigateUrl="~/OPS/Quotation.aspx" Text="Detail" />
                                                <asp:BoundField DataField="Quotation_No" HeaderText="Quotation_No" 
                                                    SortExpression="Quotation_No" />
                                                <asp:BoundField DataField="Customer_Name" HeaderText="Customer" 
                                                    SortExpression="Customer_Name" />
                                                <asp:BoundField DataField="Description" HeaderText="Description" 
                                                    SortExpression="Description" />
                                                <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                                                    SortExpression="Shades" />
                                                <asp:BoundField DataField="Meters" HeaderText="Meters" ReadOnly="True" 
                                                    SortExpression="Meters" />
                                                <asp:BoundField DataField="Rev_No" HeaderText="Rev_No" ReadOnly="True" 
                                                    SortExpression="Rev_No" />
                                                <asp:BoundField DataField="Quotation Date" HeaderText="Quotation Date" 
                                                    ReadOnly="True" SortExpression="Quotation Date" />
                                                <asp:BoundField DataField="Finalized Date" HeaderText="Finalized Date" 
                                                    ReadOnly="True" SortExpression="Finalized Date" />
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
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
</asp:UpdatePanel>  
<table class="tableback" style="width:100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel5" runat="server" ScrollBars="Auto" Width="100%">
                        <table style="width: 100%;">
                            <tr>
                                <td style="font-size: 10pt; font-weight: bold; width: 20%;">
                                    <asp:Label ID="Label5" runat="server" Text="Hod Authorization Quotes"></asp:Label>
                                </td>
                                <td style="font-size: 10pt; font-weight: bold; width: 80%;">
                                    <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="10">
                                        <ProgressTemplate>
                                            <asp:Image ID="img_loading" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;">
                            <tr>
                                <td class="NormalText">
                                    <asp:GridView ID="grdHODAuth" runat="server" 
                                        AutoGenerateColumns="False" EmptyDataText="No Data Available" 
                                        EnableModelValidation="True" Width="100%" >
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" 
                                                DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" 
                                                HeaderText="Detail" Text="Detail" />
                                            <asp:BoundField DataField="Quotation_No" HeaderText="Quotation_No" 
                                                SortExpression="Quotation_No" />
                                            <asp:BoundField DataField="Customer_Name" HeaderText="Customer" 
                                                SortExpression="Customer_Name" />
                                            <asp:BoundField DataField="Sales_Person_Name" HeaderText="Sale Person" 
                                                SortExpression="Sales_Person_Name" />
                                            <asp:BoundField DataField="Item" HeaderText="Item" ReadOnly="True" 
                                                SortExpression="Item" />
                                            <asp:BoundField DataField="Dnv_Cost" HeaderText="Dnv Cost" ReadOnly="True" 
                                                SortExpression="Dnv_Cost" />
                                            <asp:BoundField DataField="Pref Sale Price" HeaderText="Pref Sale Price" ReadOnly="True" 
                                                SortExpression="Pref Sale Price" />
                                            <asp:BoundField DataField="Sale_Price" HeaderText="Sale_Price" 
                                                ReadOnly="True" SortExpression="Sale_Price" />
                                            <asp:BoundField DataField="Theoretical Margin %" HeaderText="Theoretical Margin %" 
                                                ReadOnly="True" SortExpression="Theoretical Margin %" />
                                                  <asp:BoundField DataField="Pref Margin %" HeaderText="Pref Margin %" 
                                                ReadOnly="True" SortExpression="Pref Margin %" />
                                            <asp:TemplateField HeaderText="Finalize Quote">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkFinalize" runat="server" CommandName="Auth">Authorize</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="lnkFinalize_ConfirmButtonExtender" 
                                                        runat="server" ConfirmText="Confirm Finalize quote ?" 
                                                        TargetControlID="lnkFinalize">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remove Quote">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandName="Delete">Cancel</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="lnkRemove_ConfirmButtonExtender" runat="server" 
                                                        ConfirmText="Cancel Quote ?" TargetControlID="lnkRemove">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
               
            </td>
        </tr>
        </table>
       
    <table class="tableback" style="width:100%;">
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Width="100%">
                        <table style="width: 100%;">
                            <tr>
                                <td style="font-size: 10pt; font-weight: bold; width: 107px;">
                                    <asp:Label ID="Label1" runat="server" Text="Indicative Quotes"></asp:Label>
                                </td>
                                <td style="font-size: 10pt; font-weight: bold">
                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" DisplayAfter="10">
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
                                    <asp:GridView ID="grdIndicativeQuote" runat="server" 
                                        AutoGenerateColumns="False" EmptyDataText="No Data Available" 
                                        EnableModelValidation="True" Width="100%" 
                                        onrowcommand="grdIndicativeQuote_RowCommand">
                                        <Columns>
                                            <asp:HyperLinkField DataNavigateUrlFields="Quotation_No" 
                                                DataNavigateUrlFormatString="Quotation_Main.aspx?quot={0}" HeaderText="Edit" Text="Edit" />
                                            <asp:BoundField DataField="Quotation_No" HeaderText="Quotation_No" 
                                                SortExpression="Quotation_No" />
                                            <asp:BoundField DataField="Customer_Name" HeaderText="Customer" 
                                                SortExpression="Customer_Name" />
                                            <asp:BoundField DataField="Description" HeaderText="Description" 
                                                SortExpression="Descripotion" />
                                            <asp:BoundField DataField="Shades" HeaderText="Shades" ReadOnly="True" 
                                                SortExpression="Shades" />
                                            <asp:BoundField DataField="Meters" HeaderText="Meters" ReadOnly="True" 
                                                SortExpression="Meters" />
                                            <asp:BoundField DataField="Rev_No" HeaderText="Rev_No" ReadOnly="True" 
                                                SortExpression="Rev_No" />
                                            <asp:BoundField DataField="Quotation Date" HeaderText="Quotation Date" 
                                                ReadOnly="True" SortExpression="Quotation Date" />
                                            <asp:BoundField DataField="Quote Validity" HeaderText="Quote Validity" 
                                                ReadOnly="True" SortExpression="Quote Validity" />
                                            <asp:TemplateField HeaderText="Finalize Quote">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkFinalize" runat="server" CommandName="Auth">Authorize</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="lnkFinalize_ConfirmButtonExtender" 
                                                        runat="server" ConfirmText="Confirm Finalize quote ?" 
                                                        TargetControlID="lnkFinalize">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remove Quote">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkRemove" runat="server" CommandName="Delete">Remove</asp:LinkButton>
                                                    <cc1:ConfirmButtonExtender ID="lnkRemove_ConfirmButtonExtender" runat="server" 
                                                        ConfirmText="Confirm Delete ?" TargetControlID="lnkRemove">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
               
            </td>
        </tr>
        </table>

    <table style="width: 100%;">
        <tr>
            <td class="NormalText">
               
               
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel3" runat="server" ScrollBars="Auto" Width="100%">
                        <table style="width: 100%;" class="tableback">
                            <tr>
                                <td style="font-size: 10pt; font-weight: bold; width: 112px;">
                                    <asp:Label ID="Label3" runat="server" Text="Samples"></asp:Label>
                                </td>
                                <td style="font-size: 10pt; font-weight: bold">
                                    <asp:UpdateProgress ID="UpdateProgress4" runat="server" DisplayAfter="10">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                            <table class="tableback" style="width: 100%;">
                                <tr>
                                    <td class="NormalText">
                                        <asp:GridView ID="grdSample" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No Data Available" EnableModelValidation="True" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="SAMPLE ORDER" HeaderText="SAMPLE ORDER" 
                                                    SortExpression="SAMPLE ORDER" />
                                                <asp:BoundField DataField="LINE ITEM" HeaderText="LINE ITEM" 
                                                    SortExpression="LINE ITEM" />
                                                <asp:BoundField DataField="ITEM NO" HeaderText="ITEM NO" 
                                                    SortExpression="ITEM NO" />
                                                <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" 
                                                    ReadOnly="true" SortExpression="DESCRIPTION" />
                                                <asp:BoundField DataField="SHADE" HeaderText="SHADE" ReadOnly="True" 
                                                    SortExpression="SHADE" />
                                                <asp:BoundField DataField="METERS" HeaderText="METERS" ReadOnly="True" 
                                                    SortExpression="METERS" />
                                                <asp:BoundField DataField="DnV" HeaderText="DnV" ReadOnly="True" 
                                                    SortExpression="DnV" />
                                                <asp:BoundField DataField="DnV ACTUAL" HeaderText="DnV ACTUAL" ReadOnly="True" 
                                                    SortExpression="DnV ACTUAL" />
                                                   <asp:BoundField DataField="STATUS" HeaderText="STATUS" ReadOnly="True" 
                                                    SortExpression="STATUS" />
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
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
                    
                </asp:UpdatePanel>
               
               
               </td>
        </tr>
        </table>
        <table style="width: 100%;">
        <tr>
            <td class="NormalText">
               
               
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Panel ID="Panel4" runat="server" ScrollBars="Auto" Width="100%">
                        <table style="width: 100%;" class="tableback">
                            <tr>
                                <td style="font-size: 10pt; font-weight: bold; width: 112px;">
                                    <asp:Label ID="Label4" runat="server" Text="Lab Dip Details"></asp:Label>
                                </td>
                                <td style="font-size: 10pt; font-weight: bold">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="10">
                                        <ProgressTemplate>
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                        </table>
                            <table class="tableback" style="width: 100%;">
                                <tr>
                                    <td class="NormalText">
                                        <asp:GridView ID="grdLabDip" runat="server" 
                                            EmptyDataText="No Data Available" EnableModelValidation="True" 
                                            Width="100%" AllowPaging="True" 
                                            onpageindexchanging="grdLabDip_PageIndexChanging">
                                            <HeaderStyle CssClass="GridHeader" />
                                            <PagerStyle CssClass="PagerStyle" />
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
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                    </Triggers>
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
