<%@ Page Title="" Language="C#" MasterPageFile="~/OPS/MasterPage.master" AutoEventWireup="true" CodeFile="FutureOrdersQuotations.aspx.cs" Inherits="OPS_FutureOrdersQuotations" %>


<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width:100%;">
        <tr>
            <td class="tableheader" colspan="4">
               Order-Quotation Panel</td>
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
                Order Dt From</td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtOrderDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                   <cc1:CalendarExtender ID="txtOrderDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtOrderDateFrom">
                </cc1:CalendarExtender>
               
            </td>
            <td class="NormalText" style="width: 127px">
                Order Dt To</td>
            <td>
                <asp:TextBox ID="txtOrderDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                  <cc1:CalendarExtender ID="txtOrderDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtOrderDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="NormalText" style="width: 123px">
                Delivery Dt From</td>
            <td class="NormalText" style="width: 152px">
                <asp:TextBox ID="txtDelDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                   <cc1:CalendarExtender ID="txtDelDateFrom_CalendarExtender" runat="server" 
                    TargetControlID="txtDelDateFrom">
                </cc1:CalendarExtender>
               
            </td>
            <td class="NormalText" style="width: 127px">
                Delivery Dt To</td>
            <td>
                <asp:TextBox ID="txtDelDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                  <cc1:CalendarExtender ID="txtDelDateTo_CalendarExtender" runat="server" 
                    TargetControlID="txtDelDateTo">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr >
            <td class="NormalText" style="width: 123px">
                Customer</td>
            <td class="NormalText" style="width: 152px">
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
            <ContentTemplate>
              <div id="divwidth" style="display:none;">   
                        </div>

                        <asp:TextBox ID="txtCustomer" runat="server" AutoPostBack="True" 
                            CssClass="textbox" ontextchanged="txtCustomer_TextChanged" Width="200px"></asp:TextBox>
  
                        <cc1:AutoCompleteExtender ID="txtCustomer_AutoCompleteExtender" runat="server" 
                            CompletionInterval="10" CompletionSetCount="20" MinimumPrefixLength="1" 
                            ServiceMethod="OPS_Customer"   CompletionListCssClass="AutoExtender" 
                            ServicePath="~/WebService.asmx" 
                            CompletionListElementID="divwidth" 
                            CompletionListHighlightedItemCssClass="AutoExtenderHighlight" 
                            CompletionListItemCssClass="AutoExtenderList"
                            TargetControlID="txtCustomer">
                        </cc1:AutoCompleteExtender>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
            </Triggers>
                        </asp:UpdatePanel>
                  
                        
            </td>
            <td class="NormalText" style="width: 127px">
                Order No</td>
            <td>
               
         <asp:TextBox ID="txtOrderNo" runat="server" CssClass="textbox"  
                   EnableViewState="False"></asp:TextBox>
             
            
            </td>
        </tr>
        <tr>
            <td class="buttonbackbar" colspan="4">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:LinkButton ID="lnkFetch" runat="server" CssClass="buttonc" 
                            onclick="lnkFetch_Click">Fetch</asp:LinkButton>
                   
                    </ContentTemplate>
                
                </asp:UpdatePanel>
                     <asp:LinkButton ID="lnlExcel" runat="server" CssClass="buttonc" 
                            onclick="lnlExcel_Click">Excel</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="NormalText" colspan="4">
                <asp:UpdateProgress ID="UpdateProgress6" runat="server">
                    <ProgressTemplate>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Image/load.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </td>
        </tr>
        </table>
        
       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>

                  <asp:Panel ID="pnlAll" runat="server" ScrollBars="Auto" Width="100%"  CssClass="panelbg" Visible="false">

                     
                       <asp:Panel ID="pnlFutureOrders" runat="server" ScrollBars="Auto" Width="100%" Height="200px" CssClass="panelbg" >
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td style="font-size: 10pt; font-weight: bold; width: 158px;">
                                        <asp:Label ID="Label5" runat="server" Text="Order List"></asp:Label>
                                        <asp:ImageButton ID="imgOrders" runat="server" 
                                            ImageUrl="~/Image/refresh-icon.gif" onclick="imgOrders_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton3" runat="server" 
                                            ImageUrl="~/Image/excelsmall.jpg" onclick="ImageButton3_Click" />
                                    </td>
                                    <td style="font-size: 10pt; font-weight: bold">
                                        <asp:UpdateProgress ID="UpdateProgress5" runat="server" DisplayAfter="10">
                                            <ProgressTemplate>
                                                <asp:Image ID="imgFutureOrders" runat="server" ImageUrl="~/OPS/Image/loadingNew.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                            </table>
                            <table style="width: 100%;">
                                <tr>
                                    <td class="NormalText">
                                        <asp:GridView ID="grdFutureOrders" runat="server" AutoGenerateColumns="False" 
                                            EmptyDataText="No Data Available" EnableModelValidation="True" 
                                            Width="100%" Height="100%" 
                                            onselectedindexchanged="grdFutureOrders_SelectedIndexChanged">
                                            <Columns>

                                                     <asp:CommandField ShowSelectButton="True" />

                                             <asp:BoundField DataField="Customer" HeaderText="Customer" 
                                                    SortExpression="Customer" />
                                                <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" 
                                                    SortExpression="OrderNo" />
                                                       <asp:BoundField DataField="QuotationNo" HeaderText="QuotationNo" 
                                                    SortExpression="QuotationNo" />
                                                <asp:BoundField DataField="Sort" HeaderText="Sort" 
                                                    SortExpression="Sort" />
                                             
                                                <asp:BoundField DataField="LineItem" HeaderText="LineItem" ReadOnly="True" 
                                                    SortExpression="LineItem" />
                                                <asp:BoundField DataField="ReqQty" HeaderText="ReqQty" ReadOnly="True" 
                                                    SortExpression="ReqQty" />
                                                      <asp:BoundField DataField="DnV" HeaderText="DnV" ReadOnly="True" 
                                                    SortExpression="DnV" />
                                                     <asp:BoundField DataField="SP" HeaderText="Sale Price" ReadOnly="True" 
                                                    SortExpression="SP" />
                                                        <asp:BoundField DataField="Currency" HeaderText="Currency" ReadOnly="True" 
                                                    SortExpression="Currency" />
                                                    <asp:BoundField DataField="ExchangeRate" HeaderText="ExchangeRate" ReadOnly="True" 
                                                    SortExpression="ExchangeRate" />
                                                <asp:BoundField DataField="OrderDt" HeaderText="OrderDt" ReadOnly="True" 
                                                    SortExpression="OrderDt" />
                                                <asp:BoundField DataField="DeliveryDt" HeaderText="DeliveryDt" 
                                                    ReadOnly="True" SortExpression="DeliveryDt" />
                                                      <asp:BoundField DataField="OrderType" HeaderText="OrderType" 
                                                    ReadOnly="True" SortExpression="OrderType" />
                                                <asp:BoundField DataField="OrderStatus" HeaderText="OrderStatus" 
                                                    ReadOnly="True" SortExpression="OrderStatus" />
                                                 <asp:BoundField DataField="Status" HeaderText="Status" 
                                                    ReadOnly="True" SortExpression="Status" />
                                                     <asp:HyperLinkField DataNavigateUrlFields="OrderNo,LineItem" 
                                                         DataNavigateUrlFormatString="~/OPS/DispatchDetails.aspx?OrderNo={0}&LineItem={1}" 
                                                         HeaderText="Dispatch" NavigateUrl="~/OPS/DispatchDetails.aspx" 
                                                         Text="Dispatch" Target="_blank" />
                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                            <SelectedRowStyle CssClass="SelectedRowStyle" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                     

                   
                      
                <asp:Panel ID="pnlAuthQuotes" runat="server" ScrollBars="Auto" Width="100%" CssClass="panelbg"  
                        Height="200px">
                            <table style="width: 100%;" class="tableback">
                                <tr>
                                    <td style="font-size: 10pt; font-weight: bold; width: 207px;">
                                        <asp:Label ID="Label2" runat="server" Text="Authorized Quotes"></asp:Label>
                                        <asp:ImageButton ID="imgQuotations" runat="server" 
                                            ImageUrl="~/Image/refresh-icon.gif" onclick="imgQuotations_Click" />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton4" runat="server" 
                                            ImageUrl="~/Image/excelsmall.jpg" onclick="ImageButton4_Click" />
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
                                            EmptyDataText="No Data Available" EnableModelValidation="True" 
                                            Width="100%" Height="100%" onrowdatabound="grdFinalizedQuote_RowDataBound">
                                            <Columns>
                                             
                                                <asp:BoundField DataField="OrderNo" HeaderText="OrderNo" 
                                                    SortExpression="OrderNo" />
                                                <asp:BoundField DataField="QuotationNo" HeaderText="QuotationNo" 
                                                    SortExpression="QuotationNo" />
                                             
                                                <asp:BoundField DataField="ItemType" HeaderText="ItemType" 
                                                    SortExpression="ItemType" />
                                                <asp:BoundField DataField="ItemCode" HeaderText="ItemCode" ReadOnly="True" 
                                                    SortExpression="ItemCode" />
                                                <asp:BoundField DataField="QuotDt" HeaderText="QuotDt" ReadOnly="True" 
                                                    SortExpression="QuotDt" />
                                                <asp:BoundField DataField="DispatchDt" HeaderText="DispatchDt" 
                                                    ReadOnly="True" SortExpression="DispatchDt" />
                                                       <asp:BoundField DataField="Currency" HeaderText="Currency" 
                                                    ReadOnly="True" SortExpression="Currency" />
                                                    <asp:BoundField DataField="ExchangeRate" HeaderText="ExchangeRate" 
                                                    ReadOnly="True" SortExpression="ExchangeRate" />
                                                    <asp:BoundField DataField="DnV" HeaderText="Dnv" 
                                                    ReadOnly="True" SortExpression="DnV" />
                                                    <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" 
                                                    ReadOnly="True" SortExpression="SalePrice" />
                                                     <asp:BoundField DataField="MarginPerc" HeaderText="MarginPerc" 
                                                    ReadOnly="True" SortExpression="MarginPerc" />
                                                     <asp:BoundField DataField="UnitMargin" HeaderText="UnitMargin" 
                                                    ReadOnly="True" SortExpression="UnitMargin" />
                                                     <asp:BoundField DataField="NetUnitMargin" HeaderText="NetUnitMargin" 
                                                    ReadOnly="True" SortExpression="NetUnitMargin" />

                                            </Columns>
                                            <HeaderStyle CssClass="GridHeader" />
                                            <RowStyle CssClass="GridItem" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                      
                 
 
                  </asp:Panel>
               
            </ContentTemplate>
        <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtCustomer" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtOrderNo" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesTeam" 
                            EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="ddlSalesPerson" 
                            EventName="SelectedIndexChanged" />
                              <asp:AsyncPostBackTrigger ControlID="lnkFetch" 
                            EventName="Click" />
                              <asp:AsyncPostBackTrigger ControlID="imgOrders" 
                            EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="imgQuotations" 
                            EventName="Click" />
                            
                              <asp:AsyncPostBackTrigger ControlID="grdFutureOrders" 
                            EventName="SelectedIndexChanged" />
                             <asp:PostBackTrigger ControlID="ImageButton4" />        
                             <asp:PostBackTrigger ControlID="ImageButton3" />        
                    </Triggers>
</asp:UpdatePanel>  

       
       
   
</asp:Content>
