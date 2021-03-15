<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true"
    CodeFile="PerformanceReview.aspx.cs" Inherits="OPS_PerformanceReview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
                Performance Review</td>
            <td class="tableheader">
                &nbsp;</td>
        </tr>

        <tr>
            <td class="NormalText" style="width: 123px">
                Date From</td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
        
                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDateFrom">
                </cc1:CalendarExtender>
            </td>
            <td class="NormalText" style="width: 127px">
                Date To</td>
            <td>
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDateTo">
                </cc1:CalendarExtender>
               
            </td>
            <td>
                &nbsp;</td>
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
                                  <asp:UpdateProgress ID="UpdateProgress3" runat="server">
                      <ProgressTemplate>
                          <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/activity.gif" />
                      </ProgressTemplate>
                  </asp:UpdateProgress>
            
                
            </td>
            <td>
                <asp:LinkButton ID="lnkToExcel" runat="server" CssClass="buttonXL" 
                    onclick="lnkToExcel_Click" Height="32px" ToolTip="Export To Excel" 
                    Width="32px"></asp:LinkButton>
            
                
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Customer</td>
            <td class="NormalText" style="width: 152px">

                    <div id="divwidth" style="display:none;">   
                        </div>

                         <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                             CssClass="textbox" Width="200px" 
                        ontextchanged="txtCustomer_TextChanged"></asp:TextBox>
                         <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                             CompletionInterval="10" CompletionListCssClass="AutoExtender" 
                             CompletionListElementID="divwidth" 
                             CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                             CompletionListItemCssClass="AutoExtenderList" CompletionSetCount="20" 
                             MinimumPrefixLength="1" ServiceMethod="OPS_Customer" 
                             ServicePath="~/WebService.asmx" TargetControlID="txtCustomer">
                         </cc1:AutoCompleteExtender>

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
            <td>
                &nbsp;</td>
        </tr>
        </table>
        
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    
      <asp:Panel ID="pnlPerformance" CssClass="panelbg" runat="server">
    <table style="width: 100%;" class="tableback" border="1">
        <tr>
            <td class="NormalText" colspan="4">
                Performance Review</td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 197px">
                Total Sales FY 2012-13</td>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="lblTotalSales" runat="server"></asp:Label>
            </td>
            <td class="NormalText" style="width: 240px">
                Total Sales Profit </td>
            <td class="NormalText">
                <asp:Label ID="lblTotalSaleProfit" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 197px">
                Average Margin Achieved (%)</td>
            <td class="NormalText" style="width: 172px">
                <asp:Label ID="lblMargin" runat="server"></asp:Label>
            </td>
            <td class="NormalText" style="width: 240px">
                Average Margin FY 2012-13</td>
            <td class="NormalText">
                <asp:Label ID="lblAvgMarginYear" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
    </asp:Panel>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="lnkFetch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="rblSaleOrder" 
                EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>
  
    

    <table style="width:100%;">
        <tr>
            <td class="buttonbackbar">
                <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc">Fetch</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" align="right">
                &nbsp;</td>
        </tr>
        </table>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Panel ID="Panel2" runat="server" ScrollBars="Auto" Width="100%" CssClass="panelbg">
                <table style="width: 100%;" class="tableback">
                    <tr>
                        <td style="font-size: 10pt; font-weight: bold; width: 105px;">
                            <asp:Label ID="Label2" runat="server" Text="Detailed Data"></asp:Label>
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
                            <asp:GridView ID="grdPerformance" runat="server" EmptyDataText="No Data Available"
                                EnableModelValidation="True" Width="100%" AllowPaging="True" OnPageIndexChanging="grdPerformance_PageIndexChanging"
                                PageSize="20" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="Customer_Name" HeaderText="Customer" SortExpression="Customer_Name">
                                        <ItemStyle Width="150px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SalePersonName" HeaderText="Sale Person" SortExpression="SalePersonName">
                                    </asp:BoundField>
                                    <asp:HyperLinkField DataNavigateUrlFields="Order_No" DataNavigateUrlFormatString="QuotationPanel1.aspx?OrderNo={0}"
                                        HeaderText="Order No" NavigateUrl="~/OPS/QuotationPanel1.aspx" DataTextField="Order_No"
                                        SortExpression="Order_No" />
                                    <asp:BoundField DataField="Item_No" HeaderText="Item" ReadOnly="True" SortExpression="Item_No" />
                                    <asp:BoundField DataField="variant" HeaderText="variant" ReadOnly="True" SortExpression="variant" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" SortExpression="Quantity" />
                                    <asp:BoundField DataField="Invoice_No" HeaderText="Invoice" ReadOnly="True" SortExpression="Invoice_No" />
                                    <asp:BoundField DataField="invoice_dt" HeaderText="Invoice Date" ReadOnly="True"
                                        SortExpression="invoice_dt">
                                        <ItemStyle Width="100px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sales_price" HeaderText="Sale Price" ReadOnly="True" SortExpression="Sales_price" />
                                    <asp:BoundField DataField="Dnv_Cost" HeaderText="Dnv_Cost" SortExpression="Dnv_Cost"
                                        ReadOnly="True" />
                                    <asp:BoundField DataField="invoice_net_amt" HeaderText="Total Amount" SortExpression="invoice_net_amt"
                                        ReadOnly="True" />
                                </Columns>
                                <EditRowStyle CssClass="EditRowStyle" />
                                <HeaderStyle CssClass="HeaderStyle" />
                                <PagerStyle CssClass="PagerStyle" />
                                <RowStyle CssClass="RowStyle" />
                                <SelectedRowStyle CssClass="SelectedRowStyle" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
            <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>

     <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" 
                    RenderMode="Inline">
                    <ContentTemplate>   
     
                                
                          
    <asp:Panel ID="pnlSaleOrder" runat="server" CssClass="panelbg" Width="200px" Height="200px" style="display:none;"  ScrollBars="Vertical">
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
                        <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
                        
                    </Triggers>
    </asp:UpdatePanel>
    
</asp:Content>
