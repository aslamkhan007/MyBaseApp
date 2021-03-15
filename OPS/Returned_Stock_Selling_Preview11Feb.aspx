<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Returned_Stock_Selling_Preview.aspx.vb" Inherits="OPS_Returned_Stock_Selling_Preview" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 71px;
            height: 70px;
        }
        .labelcells
{
	font-family: Tahoma;
	font-size: 8pt;
	font-weight: bold;
	color: #555555;
	/*background-image: url("../Image/Gradient2.PNG");*/
	background-color:Transparent;
	margin-top: auto;	
	vertical-align: top;
	background-repeat: repeat-y;
	width: 150px;
}
.NormalText
{    
	font-family : Tahoma;
	font-size : 8pt;
    font-weight : bold;   
	text-align : left;
	color : Black;
	height : 16px;
	display : block;
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
                    <h3>Goods Re-Invoicing Request Detail</h3></td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    JCT Limited</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    G.T. Road, Phagwara - 144 - 401</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Request No :</td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Punjab,
                    India</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Dated :
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Contact No. + (91) 1824 305 000 to 008</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Request Raised By :</td>
                <td style="width: 25%">
                    <asp:Label ID="lblCustomerName" runat="server"></asp:Label>
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
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    This sanctionnote is pending for your approval</td>
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
                <td style="width: 25%">
                    Subject</td>
                <td colspan="3">
                    <asp:Label ID="lblSubject" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Description</td>
                <td colspan="3" rowspan="2" valign="top">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                    </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr /></td>
            </tr>
            <tr>
                <td colspan="4">
                    Request Includes these bales</td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" Width="100%" 
                        AutoGenerateColumns="False" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" DataSourceID="dsItems" 
                        EnableModelValidation="True" ShowFooter="True">
                        <Columns>
                            <asp:BoundField HeaderText="SanctionNoteID" DataField="SanctionNoteID" 
                                SortExpression="SanctionNoteID">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="BaleNo" DataField="BaleNo" 
                                SortExpression="BaleNo" />
                            <asp:BoundField HeaderText="SortNo" DataField="SortNo" 
                                SortExpression="SortNo" />
                            <asp:BoundField HeaderText="Variant" DataField="Variant" 
                                SortExpression="Variant" />
                            <asp:BoundField DataField="InvoicedIn" HeaderText="InvoicedIn" 
                                SortExpression="InvoicedIn" />
                            <asp:BoundField HeaderText="LastSoldOn" DataField="LastSoldOn" 
                                SortExpression="LastSoldOn" />
                            <asp:BoundField HeaderText="RequestRaisedOn" DataField="RequestRaisedOn" 
                                SortExpression="RequestRaisedOn" >
                            </asp:BoundField>
                            <asp:BoundField DataField="Qty" HeaderText="Qty" 
                                SortExpression="Qty">
                            </asp:BoundField>
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
                        SelectCommand="Jct_Ops_ReInvoicing_Request_Bale_Detail" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                           
                            <asp:QueryStringParameter Name="SanctionID" QueryStringField="SanctionID" 
                                Type="String" />
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
                            <asp:BoundField DataField="SortNo" HeaderText="SortNo" 
                                SortExpression="SortNo">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Variant" DataField="Variant" 
                                SortExpression="Variant">
                            </asp:BoundField>
                            <asp:BoundField HeaderText="LastSoldAt" DataField="LastSoldAt" ReadOnly="True" 
                                SortExpression="LastSoldAt" />
                            <asp:BoundField HeaderText="Proposed_SellingPrice" 
                                DataField="Proposed_SellingPrice" SortExpression="Proposed_SellingPrice" />
                            <asp:BoundField HeaderText="Qty" DataField="Qty" ReadOnly="True" 
                                SortExpression="Qty" />
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
                        SelectCommand="Jct_Ops_ReInvoicing_SanctionNote_Detail_Fetch" 
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                           
                            <asp:QueryStringParameter Name="SanctionID" QueryStringField="SanctionID" 
                                Type="String" />
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
                    This is a system genrated mail. Please do not respond or reply.</td>
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
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; text-align: right; font-weight: bold;">
                    </td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
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
