<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PreviewMaterialrequest.aspx.cs" Inherits="OPS_PreviewMaterialrequest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .style14
        {
            font-family : Tahoma;
            font-size : 8pt;
            font-weight : bold;
            text-align : left;
            color : Black;
            display : block;
            margin-left: 0px;
            width: 117px;
        }
        .style17
        {
            font-family : Tahoma;
            font-size : 8pt;
            font-weight : bold;
            text-align : left;
            color : Black;
            display : block;
            margin-left: 0px;
            }
        .style19
        {
            font-family : Tahoma;
            font-size : 8pt;
            font-weight : bold;
            text-align : left;
            color : Black;
            display : block;
            margin-left: 0px;
            width: 69px;
        }
        .style20
        {
            font-family : Tahoma;
            font-size : 8pt;
            font-weight : bold;
            text-align : left;
            color : Black;
            display : block;
            margin-left: 0px;
            width: 221px;
        }
        .style21
        {
            font-family : Tahoma;
            font-size : 8pt;
            font-weight : bold;
            text-align : left;
            color : Black;
            display : block;
            margin-left: 0px;
            width: 84px;
        }
        .style24
        {
            width: 560px;
        }
        .style25
        {
        }
        .style26
        {
            width: 60px;
        }
        .style30
        {
            width: 592px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
                    <h3>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="20pt" Text="Material Return Request"></asp:Label>
                    </h3></td>
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
                    SanctionNote No :</td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblRequestID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    G.T. Road, Phagwara - 144 - 401</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Dated :</td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Punjab,
                    India</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    RaisedBy&nbsp; Name:</td>
                <td style="width: 25%; font-weight: bold;">
                    <asp:Label ID="lblRaisedByEmpName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Contact No. + (91) 1824 305 000 to 008</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Status :</td>
                <td style="width: 25%">
                    <asp:Label ID="lblStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Web Site: www.jct.co.in</td>
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
                    Offices/Plants:</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Bombay|Bangalore|Delhi|Hoshiarpur|Phagwara</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            </table>
            <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
            <tr>
                <td align="center" style="width:100%;">
                    &nbsp;</td>
            </tr>
        </table>
            <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
                <tr>
                    <td class="style14">
                        <asp:Label ID="Label2" runat="server" Text="MR No."></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:Label ID="lblSerialNo" runat="server"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:Label ID="Label6" runat="server" Text="MR Date" Visible="False"></asp:Label>
                    </td>
                    <td class="style17">
                        <asp:Label ID="lblDate" runat="server" Visible="False"></asp:Label>
                    </td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style20">
                        &nbsp;</td>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style17">
                        &nbsp;</td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        <asp:Label ID="Label3" runat="server" Text="Customer"></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:Label ID="lblCustomer" runat="server"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:Label ID="Label10" runat="server" Text="Location"></asp:Label>
                    </td>
                    <td class="style17" colspan="4">
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style20">
                        &nbsp;</td>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style17">
                        &nbsp;</td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        <asp:Label ID="Label4" runat="server" Text="Gr No"></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:Label ID="lblGrNo" runat="server"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:Label ID="Label7" runat="server" Text="GR Date"></asp:Label>
                    </td>
                    <td class="style17">
                        <asp:Label ID="lblGrDate" runat="server"></asp:Label>
                    </td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style20">
                        &nbsp;</td>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style17">
                        &nbsp;</td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        <asp:Label ID="Label5" runat="server" Text="Freight To Be Paid"></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:Label ID="lblFreightBy" runat="server"></asp:Label>
                    </td>
                    <td class="style21">
                        <asp:Label ID="Label8" runat="server" Text="Transport"></asp:Label>
                    </td>
                    <td class="style17">
                        <asp:Label ID="lblTransport" runat="server"></asp:Label>
                    </td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        <asp:Label ID="Label9" runat="server" Text="Freight Value"></asp:Label>
                    </td>
                    <td class="style20">
                        <asp:Label ID="lblFreightValue" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblFreightBy0" runat="server">(In Rupees)</asp:Label>
                    </td>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style17">
                        &nbsp;</td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14">
                        &nbsp;</td>
                    <td class="style20">
                        &nbsp;</td>
                    <td class="style21">
                        &nbsp;</td>
                    <td class="style17">
                        &nbsp;</td>
                    <td class="style19">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
            </table>
            <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
                <tr>
                    <td class="NormalText">
                        RETURN DETAILS</td>
                </tr>
                <tr>
                    <td class="NormalText">
                        <asp:GridView ID="GridView1" runat="server" Width="100%"   BorderColor="Black" 
                           
                            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                            EnableModelValidation="True" BorderStyle="Solid" ShowFooter="True" 
                            onrowdatabound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="SrNo" HeaderText="SrNo" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="SrNo" />
                                <asp:BoundField DataField="Item" HeaderText="Item" 
                                    SortExpression="Item" />
                                <asp:BoundField DataField="InvoiceNo" HeaderText="InvoiceNo" 
                                    SortExpression="InvoiceNo" />
                                <asp:BoundField DataField="InvoiceQty" HeaderText="InvoiceQty" 
                                    ReadOnly="True" SortExpression="InvoiceQty" />
                                        <asp:BoundField DataField="ReturnQty" HeaderText="ReturnQty" 
                                    ReadOnly="True" SortExpression="ReturnQty" />
                                        <asp:BoundField DataField="Bales/Rolls" HeaderText="Bales/Rolls" 
                                    ReadOnly="True" SortExpression="Bales/Rolls" />
                                <asp:BoundField DataField="Date" HeaderText="Invoice Date" ReadOnly="True" 
                                    SortExpression="Date" />
                                <asp:BoundField DataField="Reason" HeaderText="Reason" 
                                    SortExpression="Reason" />
                                <asp:BoundField DataField="SalePrice" HeaderText="SalePrice" />
                                <asp:BoundField DataField="ValueInvolved" HeaderText="ValueInvolved" />
                            </Columns>

                           <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" />

                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:misjctdev %>" 
                            SelectCommand="SELECT DISTINCT [sr_no] as SrNo, [item_no] as Item, [invoice_no] as [InvoiceNo],CONVERT(NUMERIC(10,2), [invoice_qty]) AS [InvoiceQty],ret_qty as [ReturnQty] ,   BALES  as [Bales/Rolls],Convert(varchar, [tran_date],103) as Date, [reason] as Reason,ISNULL(SalePrice,0) AS SalePrice,ISNULL(ValueInvolved,0) ValueInvolved FROM [jct_ops_material_request] WHERE (([mr_status] = @mr_status) AND ([gr_no] IS NOT NULL) AND ([gr_transport] IS NOT NULL) AND (RequestID = @ID)) ORDER BY [sr_no]">
                              <%--SelectCommand="SELECT DISTINCT [sr_no] as SrNo, [item_no] as Item, [invoice_no] as [InvoiceNo],CONVERT(NUMERIC(10,2), [invoice_qty]) AS [InvoiceQty],ret_qty as [ReturnQty] , case when Logistics_BaleNo is null then bales else Logistics_baleNo end as [Bales/Rolls],Convert(varchar, [tran_date],103) as Date, [reason] as Reason FROM [jct_ops_material_request] WHERE (([mr_status] = @mr_status) AND ([gr_no] IS NOT NULL) AND ([gr_transport] IS NOT NULL) AND (RequestID = @ID)) ORDER BY [sr_no]">--%>
                            <SelectParameters>
                                <asp:Parameter DefaultValue="A" Name="mr_status" Type="String" />
                                <asp:QueryStringParameter Name="ID" QueryStringField="ID" Type="Int32" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                  <tr>
                    <td class="NormalText">
                        <asp:Label ID="Label11" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text="(The Quantities ( i.e Return Qty ,No. of Rolls etc  )  mentioned in the above list are tentative and actual will be calculated once the material will be examined by warehouse department.)"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
            </table>
            <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
                <tr>
                    <td class="NormalText">
                       
                          
                            HANDLING INSTRUCTIONS :<br />
                            <br />
                            <asp:Label ID="lblInstructions" runat="server"></asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblInstructions0" runat="server">To Take back in Mill.</asp:Label>
                            <br />
                            <br />
                            <asp:Label ID="lblInstructions1" runat="server">Mr. Ramesh to Issue Credit Note</asp:Label>
                          
                    </td>
                </tr>
                <tr>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="NormalText">
                       
                            LIST OF ENCLOSURES :<br />
                            <br />
                        <asp:Label ID="lblEnclosures" runat="server"></asp:Label>
                       
                    </td>
                </tr>
                </table>

        
    
    </div>
   
           
        <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
        <tr>
        <td>
            &nbsp;</td>
        </tr>
        <tr>
        <td>
        Authorization History
        </td>
        </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridView2" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" EmptyDataText="No Record" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" />
                    </asp:GridView>
</td>
            </tr>
            </table>
    <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style30">
                    &nbsp;</td>
                <td class="style25">
                    <asp:Label ID="lblSerialNo0" runat="server">Finally Approved By</asp:Label>
                    &nbsp;:</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style30">
                    &nbsp;</td>
                <td class="style25">
                    <asp:Label ID="lblApproval" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <br />

        <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
            <tr>
                <td class="style26">
                    CC :</td>
                <td class="style24">
                    Costing, Warehouse, Administration,Marketing</td>
                <td class="style25">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style26">
                    &nbsp;</td>
                <td class="style24">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>

    </form>
</body>
</html>
