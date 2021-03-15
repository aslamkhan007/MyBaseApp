<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Quotation_Preview.aspx.vb" Inherits="OPS_Quotation_Preview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 71px;
            height: 70px;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
</head>
<body style="margin:0px;">
    <form id="form1" runat="server">
    <div style="margin-top:0px; margin-right : auto; margin-left : auto;">
    
        <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText">
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%" rowspan="4">
                    <img alt="Logo" class="style1" longdesc="Logo" src="Image/JCTLogoCR.png" /></td>
                <td colspan="2" style="text-align: center">
                    <h3>Quotation</h3></td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    Quotation No :</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    Dated :
                    </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    Customer Name :</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    JCT Limited</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Customer Code :</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCustomerCode" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    G.T. Road, Phagwara - 144 - 401</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblAddress" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Punjab,
                    India</td>
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
                    Contact No. + (91) 1824 305 000 to 008</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Brand :</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblBrand" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Web Site: www.jct.co.in</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Offices/Plants:</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Bombay|Bangalore|Delhi|Hoshiarpur|Phagwara</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    </td>
                <td style="width: 25%">
                    </td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" DataSourceID="dsItems" 
                        EnableModelValidation="True" ShowFooter="True">
                        <Columns>
                            <asp:BoundField HeaderText="Sr. No." DataField="srno">
                            <ItemStyle Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Item Code" DataField="Item_Code" />
                            <asp:BoundField HeaderText="Width" DataField="width" />
                            <asp:BoundField HeaderText="GSM" DataField="gsm" />
                            <asp:BoundField DataField="Shade" HeaderText="Shade" SortExpression="Shade" />
                            <asp:BoundField HeaderText="LabDip Ref." />
                            <asp:BoundField HeaderText="Unit Price" DataField="Sale_Price" >
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                                SortExpression="Quantity">
                            <FooterStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UOM" HeaderText="UOM" SortExpression="UOM">
                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Currency" HeaderText="Currency" />
                            <asp:BoundField HeaderText="Delivery Date" />
                            <asp:BoundField HeaderText="Destination" />
                        </Columns>
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:GridView>
                    </td>
            </tr>

            <tr>
                <td style="width: 25%">
                    <asp:SqlDataSource ID="dsItems" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="jct_ops_get_quotation_print_items" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                           
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="quotation_no" 
                                PropertyName="Text" />
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
                    <asp:GridView ID="GridView2" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" DataSourceID="dsPayTerms" 
                        EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="pay_terms" HeaderText="Payment Terms" 
                                SortExpression="pay_terms" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Discount" DataField="Discount">
                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Advance" />
                            <asp:BoundField HeaderText="Commission" DataField="commission" />
                            <asp:BoundField HeaderText="TT" />
                            <asp:BoundField HeaderText="LC" />
                            <asp:BoundField HeaderText="Bank" />
                            <asp:BoundField HeaderText="Agent Name">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Agent Code" DataField="Agent" />
                        </Columns>
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" />
                    </asp:GridView>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: right;">
                    <asp:SqlDataSource ID="dsPayTerms" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="jct_ops_get_quotation_print_pay_terms" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                           
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="quotation_no" 
                                PropertyName="Text" />
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
                    <asp:GridView ID="GridView3" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" EnableModelValidation="True">
                        <Columns>
                            <asp:BoundField DataField="Amount" HeaderText="Finishing &amp; Packing Terms" 
                                SortExpression="Amount" ReadOnly="True">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Finish">
                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Length" />
                            <asp:BoundField HeaderText="Mode" />
                            <asp:BoundField HeaderText="Inspection Std." />
                            <asp:BoundField HeaderText="Other Conditions" />
                        </Columns>
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" />
                    </asp:GridView>
                    </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    Price Validity</td>
                <td style="width: 25%; font-weight: bold;">
                    15 Days</td>
                <td style="text-align: right">
                    Sample Cost</td>
                <td style="width: 25%; font-weight: bold;">
                    Min 500 Mtr</td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    Freight</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    Acceptance by Buyer</td>
                <td style="width: 25%; font-weight: bold;">
                    50% Additional</td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; ">
                    (If acceptable 100% Sample Qty., additional charges will be applicable 25% on 
                    Order Price)</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            </table>
        <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText" cellspacing="0">
            <tr>
                <td style="width: 25%">
                    Other Terms: -</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; text-align: right; font-weight: bold;">
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:DataList ID="DataList1" runat="server" DataSourceID="dsTermCond">
                        <ItemTemplate>
                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width: 20px">
                                        <asp:Label ID="lblSrNo" runat="server" Text='<%# Eval("SrNo") %>'></asp:Label>
                                        .</td>
                                    <td>
                                        <asp:Label ID="lblTermsConditions" runat="server" Text='<%# Eval("tc_desc") %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="dsTermCond" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                        SelectCommand="jct_ops_get_quote_terms_conditions_detail" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblQuotationNo" Name="Quotation_No" 
                                PropertyName="Text" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="font-weight: bold;">
                    For JCT Limited</td>
                <td style="font-weight: bold;">
                    &nbsp;</td>
                <td style="font-weight: bold">
                    Accepted By Buyer: -</td>
                <td style="font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Sales Executive Name :</td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
                &nbsp;</td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Buyer&#39;s Name :</td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblCustomerName1" runat="server"></asp:Label>
                &nbsp;</td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Designation :</td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                &nbsp;</td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Contact Person :</td>
                <td style="border: 1px solid #000000;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Date :</td>
                <td style="border: 1px solid #000000;">
                    &nbsp;</td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Contact Number :</td>
                <td style="border: 1px solid #000000;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Time :</td>
                <td style="border: 1px solid #000000;">
                    &nbsp;</td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Confirmation Date :</td>
                <td style="border: 1px solid #000000;">
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Order Quantity (<asp:Label ID="lblUOM" runat="server"></asp:Label>
                    ) :</td>
                <td style="border: 1px solid #000000;">
                    <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="border: 1px solid #000000; font-weight: bold;">
                    Total Amount :</td>
                <td style="border: 1px solid #000000;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    Authorised Signatory</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    <asp:LinkButton ID="lblBack" runat="server" 
                        onclientclick="window.history.go(-1);return false;">Back</asp:LinkButton>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
