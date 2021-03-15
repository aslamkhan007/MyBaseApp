<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MRPreviewPrintReport.aspx.cs" Inherits="OPS_MRPreviewPrintReport" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
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
        .style32
        {
            width: 17%;
            font-weight: bold;
        }
        .style33
        {
            width: 20%;
        }
        .style40
        {
            width: 17%;
            font-weight: bold;
            text-align: right;
        }
        .style43
        {
            width: 12%;
        }
        .style44
        {
            width: 16%;
        }
        .style45
        {
            text-align: left;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
  
    <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText">
           
            <tr>
                <td class="style32" align="left" 
                    style="font-family: Calibri; font-size: small;">
                
                    Dated :&nbsp;
                    <asp:Label ID="lblCurrentDate" runat="server" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                                
                    </td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="width: 25%; font-family: Calibri; font-size: small;" class="style45">
                    <strong style="text-align: left">Printed By:&nbsp;
                    
                    <asp:Label ID="lblPrintedBy" runat="server" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label> </strong></td>
            </tr>
           
            <tr>
                <td class="style32" align="left" 
                    style="font-family: Calibri; font-size: small;">
                
                    &nbsp;</td>
                <td style="text-align: center">
                    <h3>
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="20pt" Text="Material Return" style="font-size: medium"></asp:Label>
                        </h3></td>
                <td style="width: 25%; text-align: center;">
                    &nbsp;</td>
            </tr>
           
            </table>
            <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
            
        </table>
        <table style="border: thin none #000000; width: 950px; margin-right: auto; margin-left: auto;"
            class="NormalText">
       
           
            <tr>
                <td  class="style40" 
                    style="font-family: Calibri; font-size: small;" id="MR ID">
                    MR ID
                </td>
                <td class="style33">
                    <asp:Label ID="lblRequestID" runat="server" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: right" class="style43">
                    <b>
                    <asp:Label ID="Label3" runat="server" Text="MR No." Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                    </b>
                </td>
                <td style="text-align: left" >
                    <asp:Label ID="lblSerialNo" runat="server" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: right"
                    style="font-family: Calibri; font-size: small;" class="style44">
                    <b>
                    <asp:Label ID="Label6" runat="server" Text="MR Date" style="text-align: right"></asp:Label>
                    </b>
                </td>
                <td style="text-align: left">
                    <asp:Label ID="lblDate" runat="server"  Font-Names="Calibri" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style40" 
                    style="font-family: Calibri; font-size: small;">
                    <b>
                    <asp:Label ID="Label4" runat="server" Text="Customer"></asp:Label>
                    </b>
                </td>
                <td class="style33">
                    <asp:Label ID="lblCustomer" runat="server" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                </td>

                <td style="text-align: right">
                    <b>
                    <asp:Label ID="Label7" runat="server" Text="Raised By" Font-Names="Calibri" 
                        Font-Size="Small"></asp:Label>
                    </b>
                </td>

                <td style="text-align: left" >
                    <asp:Label ID="lblRaisedByEmpName" runat="server" Font-Names="Calibri" 
                        Font-Size="Small" style="text-align: left"></asp:Label>
                    &nbsp;
                </td>
                <td align="left" colspan="2"
                    style="font-family: Calibri; font-size: small; text-align: center;" 
                    class="style44">
                    <asp:Label ID="lblStatus" runat="server" Font-Names="Calibri" Font-Size="Small" 
                        style="text-align: right; font-weight: 700"></asp:Label>
                </td>
                
            </tr>
          
                       
            
            
           
            <tr>
                <td class="style40" 
                    style="font-family: Calibri; font-size: small;">
                    &nbsp;</td>
                <td class="style33">
                    &nbsp;</td>

                <td style="text-align: right">
                    &nbsp;</td>

                <td style="text-align: left" >
                    &nbsp;</td>
                <td align="left" class="style44" 
                    style="font-family: Calibri; font-size: small;">
                    &nbsp;</td>
                
            </tr>
          
                       
            
            
           
        </table>    
            <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
                <tr>
                    <td class="NormalText">
                        <strong style="font-family: Calibri">Return Details</strong></td>
                </tr>
                <tr>
                    <td class="NormalText" >


                      <asp:GridView ID="grdReturnDetail" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" onrowdatabound="grdReturnDetail_RowDataBound"
                        EnableModelValidation="True" EmptyDataText="No Record" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center"/>
                    </asp:GridView>

                                       
                         
                    </td>
                </tr>
                 <tr>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td class="NormalText">
                        <strong style="font-family: Calibri">Return Invoice Detail</strong></td>
                </tr>
                <tr>
                    <td class="NormalText" >


                    <asp:GridView ID="grdReturnInvoice" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" EmptyDataText="No Record" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center"/>
                    </asp:GridView>

                   
                         
                    </td>
                </tr>
                  
            </table>
   
    
<%--    </div>--%>
   
           
        <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
        <tr>
        <td>
            &nbsp;</td>
        </tr>
         
        <tr>
        <td>
            <strong style="font-family: Calibri">Authorization History</strong>
        </td>
        </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdHistory" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center"/>
                    </asp:GridView>
</td>
            </tr>
            <tr>
        <td>
            &nbsp;</td>
        </tr>
            <tr>
        <td>
            <strong style="font-family: Calibri">PPC authorization
        </strong>
        </td>
        </tr>
        
            <tr>
                <td>
                    <asp:GridView ID="grdPPCandLogAuth" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" EmptyDataText="No Record" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center" />
                    </asp:GridView>
</td>
            </tr>
             <tr>
        <td>
            &nbsp;</td>
        </tr>
             <tr>
        <td>
            <strong style="font-family: Calibri">Logistics authorization
        </strong>
        </td>
        </tr>
             <tr>
                <td>
                    <asp:GridView ID="grdLogisticAuth" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" EmptyDataText="No Record" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center" />
                    </asp:GridView>
</td>
            </tr>
             <tr>
        <td>
            &nbsp;</td>
        </tr>
             <tr>
        <td>
            <strong style="font-family: Calibri">Folding Observation</strong>
        </td>
        </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdFoldingObservation" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" EmptyDataText="No Record" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center" />
                    </asp:GridView>
</td>
            </tr>

              <tr>
        <td>
            &nbsp;</td>
        </tr>

              <tr>
        <td>
            <strong style="font-family: Calibri">New Order Detail</strong>
        </td>
        </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdOrderDetail" runat="server" Width="100%" 
                        AutoGenerateColumns="True" BorderColor="Black" BorderStyle="Solid" 
                        BorderWidth="1px" 
                        EnableModelValidation="True" EmptyDataText="No Record" 
                        Font-Names="Calibri" Font-Size="Small" >
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" HorizontalAlign="Center" />
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
                    &nbsp;:</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style30">
                    &nbsp;</td>
                <td class="style25">
                    &nbsp;</td>
            </tr>
        </table>
        <br />

        <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
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



