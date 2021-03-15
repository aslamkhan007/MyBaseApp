<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SanctionNote_Preview.aspx.vb" Inherits="OPS_SanctionNote_Preview" EnableEventValidation = "false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">




.buttonPDF
{
    background-image : url('../Image/ExportPdf.png');
    background-repeat:no-repeat;
    width : 32px;
    height:32px;
    
}



    </style>
</head>
<body>
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
                <div>
                    <%--<img alt="Logo" class="style1" longdesc="Logo" src="JCTLogoCR.png" /></div>--%>
                    </td>
                <td colspan="2" style="text-align: center">
                    <h3>SanctionNote</h3></td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    SanctionNote No :</td>
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
                    RaisedBy&nbsp; Name:</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblRaisedByEmpName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    JCT Limited</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;Code:</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblRaisedByCode" runat="server"></asp:Label>
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
                    <asp:Label ID="lblDepartment" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Punjab,
                    India</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Status :</td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Contact No. + (91) 1824 305 000 to 008</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Printed On :</td>
                <td style="width: 25%">
                    <asp:Label ID="lblPrintedOn" runat="server"></asp:Label>
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
            </table>
        <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText">
            <tr>
                <td style="width: 105px">
                    &nbsp;</td>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 105px">
                    <strong>Subject </strong>:</td>
                <td colspan="3">
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="LblDescription" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
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
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px"  
                        EnableModelValidation="True" ShowFooter="True">
                      <%--  <Columns>
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
                        </Columns>--%>
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:GridView>
                    </td>
            </tr>

            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
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
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True">
                        <%--<Columns>
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
                        </Columns>--%>
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" />
                    </asp:GridView>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: right;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
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
                <td colspan="4">
                    &nbsp;</td>
            </tr>
            </table>
        <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText" cellspacing="0">
            <tr>
                <td style="width: 25%">
                    Other Terms(If Any): -</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; text-align: right; font-weight: bold;">
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
                <asp:LinkButton ID="cmdXportPDF" runat="server" CssClass="buttonPDF" 
                    Height="32px" onclick="cmdXportPDF_Click" Width="32px"></asp:LinkButton>
                </td>
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
