<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Quotation_Detail_Email.aspx.vb" Inherits="OPS_Quotation_Detail_Email" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />--%>
    <style type ="text/css">

    .labelcells
    {
	font-family: Tahoma;
	font-size: 8pt;
	font-weight: 700;
	/*background-image: url("../Image/Gradient2.PNG");*/
	background-color:Transparent;
	margin-top: auto;
	vertical-align: top;
	background-repeat: repeat-y;
	width : 150px;
	}

    .NormalText
    {
    font-family : Tahoma;
    font-size : 8pt;
    text-align : left;
    color : Black;
    display : block;
    }

    </style>

</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
    <div style="margin-top: 0px; margin-right: auto; margin-left: auto; font-family : Tahoma; font-size : 8pt;">
        <table style="border: thin none #000000; width: 950px; margin-right: auto; margin-left: auto; font-family : Tahoma; font-size : 8pt;"
            class="NormalText">
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td colspan="2" style="text-align: center">
                    <h3>
                        Quotation</h3>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>

            <tr>
                <td style="width: 25%">
                    Quotation Status :
                    <asp:Label ID="lblQuotationStatus" runat="server" CssClass="labelcells"></asp:Label>
                </td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    Quotation No :
                </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Dispatch Approval : <asp:Label ID="lblDispatchApproval" runat="server" 
                        CssClass="labelcells"></asp:Label>
                </td>
                <td style="text-align: center">
                    &nbsp;
                </td>
                <td style="text-align: right">
                    Dated :
                </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Approval Dt: <asp:Label ID="lblApprovalDt" runat="server" CssClass="labelcells"></asp:Label>
                &nbsp;</td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    Customer Name :
                </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Authorised By : <asp:Label ID="lblAuthorisedUser" runat="server" 
                        CssClass="labelcells"></asp:Label>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Customer Code :
                </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCustomerCode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Authorisation Dt: <asp:Label ID="lblAuthorisationDt" runat="server" 
                        CssClass="labelcells"></asp:Label>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Address :</td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    SO Requested : <asp:Label ID="lblSOReqStatus" runat="server" 
                        CssClass="labelcells"></asp:Label>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblCity" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblState" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Quotation Type : 
                    <asp:Label ID="lblQuotationType" runat="server" 
                        CssClass="labelcells"></asp:Label>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Brand :</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblBrand" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="color: #FF0000; font-weight: bold;">
                    PPC Remark :
                    <asp:Label ID="lblPPCRemarks" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="color: #FF0000; font-weight: bold;">
                    <asp:GridView ID="GridView6" runat="server" Width="100%" AutoGenerateColumns="False"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="SqlDataSource1"
                        EnableModelValidation="True" ShowFooter="True">
                        <Columns>
                            <asp:BoundField HeaderText="User Name" DataField="UserName">
                                <ItemStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Quotation NO" DataField="QuotationNo" />
                            <asp:BoundField DataField="Type" HeaderText="Stage" SortExpression="Type" />
                            <asp:BoundField HeaderText="Target Date (M-D-Y)" DataField="Target Date" DataFormatString="{0:MM/dd/yyyy}"  />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />
                            
                        </Columns>
                        <FooterStyle CssClass="NormalText" />
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                            Height="23px" CssClass="NormalText" HorizontalAlign="Center" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" CssClass="NormalText" />

                    </asp:GridView><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                        SelectCommand="jct_ops_Quotation_planning_email_report" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="quotation_no" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" class = "NormalText">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="dsItems"
                        EnableModelValidation="True" ShowFooter="True">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No." DataField="srno">
                                <ItemStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Item Code" DataField="Item_Code" />
                            <asp:BoundField DataField="Ramco_Item_Code" HeaderText="Ramco Item Code" 
                                ReadOnly="True" SortExpression="Ramco_Item_Code" />
                            <asp:BoundField HeaderText="Width" DataField="width" />
                            <asp:BoundField HeaderText="GSM" DataField="gsm" />
                            <asp:BoundField DataField="Shade" HeaderText="Shade" SortExpression="Shade" />
                            <asp:BoundField HeaderText="LabDip Ref." />
                            <asp:BoundField HeaderText="Unit Price" DataField="Sale_Price">
                                <FooterStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity">
                                <FooterStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM">
                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Currency" HeaderText="Currency" />
                            <asp:BoundField DataField="Theoretical_Margin" HeaderText="Margin %" />
                            <asp:BoundField HeaderText="Delivery Date" />
                            <asp:BoundField HeaderText="Destination" />
                        </Columns>
                        <FooterStyle CssClass="NormalText" />
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                            Height="23px" CssClass="NormalText" HorizontalAlign="Center" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" CssClass="NormalText" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    <asp:SqlDataSource ID="dsItems" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                        SelectCommand="jct_ops_get_quotation_print_items" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="quotation_no" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="dsPayTerms"
                        EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="pay_terms" HeaderText="Payment Terms" SortExpression="pay_terms"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField HeaderText="Discount" DataField="Discount">
                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Advance" />
                            <asp:BoundField HeaderText="Commission" DataField="commission" />
                            <asp:BoundField HeaderText="TT" />
                            <asp:BoundField HeaderText="LC" />
                            <asp:BoundField HeaderText="Bank" />
                            <asp:BoundField HeaderText="Agent Name"></asp:BoundField>
                            <asp:BoundField HeaderText="Agent Code" DataField="Agent" />
                        </Columns>
                        <FooterStyle CssClass="NormalText" />
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                            Height="23px" CssClass="NormalText" HorizontalAlign="Center" />
                        <RowStyle Height="30px" CssClass="NormalText" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: right;">
                    <asp:SqlDataSource ID="dsPayTerms" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                        SelectCommand="jct_ops_get_quotation_print_pay_terms" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="quotation_no" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="Amount" HeaderText="Finishing &amp; Packing Terms" SortExpression="Amount"
                                ReadOnly="True"></asp:BoundField>
                            <asp:BoundField HeaderText="Finish">
                                <ItemStyle HorizontalAlign="Right" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Length" />
                            <asp:BoundField HeaderText="Mode" />
                            <asp:BoundField HeaderText="Inspection Std." />
                            <asp:BoundField HeaderText="Other Conditions" />
                        </Columns>
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                            Height="23px" />
                        <RowStyle Height="30px" />
                    </asp:GridView>
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="font-weight: bold;">
                    DnV Details</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="dsCostingDetails"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="Shade" HeaderText="Shade"></asp:BoundField>
                                <asp:BoundField HeaderText="DnV Cost (Quotation)" DataField="DnV_Cost_Q" />
                                <asp:BoundField HeaderText="DnV Cost (Memo)" DataField="DnV_Cost_M" />
                                <asp:BoundField HeaderText="Memo No" DataField="Memo_No" />
                                <asp:BoundField HeaderText="Memo Date M-D-Y" DataField="Memo_Dt" 
                                    DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                            </Columns>
                            <FooterStyle CssClass="NormalText" />
                            <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                                Height="23px" CssClass="NormalText" />
                            <RowStyle Height="30px" CssClass="NormalText" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsCostingDetails" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="jct_ops_get_quotation_print_dnv_detail" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblQuotationNo" Name="quotation_no" PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="font-weight: bold;">
                    Delivery Schedule</td>
            </tr>
            <tr>
                <td colspan="4">
                        <asp:GridView ID="GridView5" runat="server" Width="100%" AutoGenerateColumns="False"
                            BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="dsDeliverySchedule"
                            EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="Shade" HeaderText="Shade"></asp:BoundField>
                                <asp:BoundField HeaderText="Quantity" DataField="Quantity" />
                                <asp:BoundField HeaderText="UOM" DataField="UOM" />
                                <asp:BoundField HeaderText="Dispatch Date M-D-Y" DataField="Dispatch_Date" 
                                    DataFormatString="{0:MM/dd/yyyy}" />
                                <asp:BoundField HeaderText="City" DataField="City"></asp:BoundField>
                                <asp:BoundField DataField="Country" HeaderText="Country" />
                            </Columns>
                            <FooterStyle CssClass="NormalText" />
                            <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                                Height="23px" CssClass="NormalText" />
                            <RowStyle Height="30px" CssClass="NormalText" />
                        </asp:GridView>
                        <asp:SqlDataSource ID="dsDeliverySchedule" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="jct_ops_get_quote_dispatch_sch" 
                            SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="lblQuotationNo" Name="Quotation_No" 
                                    PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%; font-weight: bold;">
                    Sale Person Remarks</td>
                <td style="font-weight: bold;" colspan="3">
                    <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="font-weight: bold;" colspan="4">
                    Sale Notes
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblSaleNotes" runat="server" Visible="False"></asp:Label>
                    <asp:TextBox ID="txtSaleNotes" runat="server" BorderStyle="None" CssClass="textbox"
                        Height="200px" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    &nbsp;</td>
                <td style="font-weight: bold; color: #FF0000;" colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    Price Validity
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td style="text-align: right">
                    Sample Cost
                </td>
                <td style="width: 25%; font-weight: bold;">
                    Min 500 Mtr
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    Freight
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td style="text-align: right">
                    Acceptance by Buyer
                </td>
                <td style="width: 25%; font-weight: bold;">
                    50% Additional
                </td>
            </tr>
            <tr>
                <td style="width: 25%;">
                    &nbsp;
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td style="text-align: right">
                </td>
                <td style="width: 25%;">
                    (If acceptable 100% Sample Qty., additional charges will be applicable 25% on Order
                    Price)
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table style="border: thin none #000000; width: 950px; margin-right: auto; margin-left: auto;"
            class="NormalText" cellspacing="0">
            <tr>
                <td style="width: 25%">
                    Other Terms: -
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; text-align: right; font-weight: bold;">
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="dsTermCond">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                <tr>
                                    <td style="width: 20px">
                                        <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("SrNo") %>'></asp:Label>
                                        .
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTermsConditions" runat="server" Text='<%# Eval("tc_desc") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="dsTermCond" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                        SelectCommand="jct_ops_get_quote_terms_conditions_detail" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="Quotation_No" PropertyName="Text"
                                Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    &nbsp;
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold;">
                    &nbsp;
                </td>
                <td style="font-weight: bold;">
                    &nbsp;
                </td>
                <td style="font-weight: bold">
                    &nbsp;
                </td>
                <td style="font-weight: bold;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Sales Executive Name :
                </td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Buyer&#39;s Name :
                </td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblCustomerName1" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Sales Team :
                </td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblSalesTeam" runat="server"></asp:Label>
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Designation :
                </td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Contact Person :
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Date :
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Contact Number :
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Time :
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Confirmation Date :
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Order Quantity (<asp:Label ID="lblUOM" runat="server"></asp:Label>
                    ) :
                </td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Total Amount :
                </td>
                <td style="border: 1px solid #000000;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    Authorised Signatory
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    <asp:LinkButton ID="lblBack" runat="server" OnClientClick="window.history.go(-1);return false;">Back</asp:LinkButton>
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 25%">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

