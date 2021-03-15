<%@ Page Language="C#" AutoEventWireup="true" CodeFile="materialReturnMail.aspx.cs" Inherits="OPS_MailContentPages_materialReturnMail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <%--<link href="../StyleSheets/table.css" rel="stylesheet" type="text/css" />--%>

<style type="text/css">

.datagrid table 
{
     border-collapse: collapse;
     text-align: left; width: 100%; 
}
 .datagrid 
 {
     font: normal 12px/150% Arial, Helvetica, sans-serif; 
     background: #fff; overflow: hidden; border: 1px solid #8C8C8C; 
     -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; 
     }
.datagridnew 
 {
     font: smaller 8px/150% Arial, Helvetica, sans-serif; 
     
     background: #fff; overflow: hidden; border: 1px solid #8C8C8C; 
     -webkit-border-radius: 3px; -moz-border-radius: 3px; border-radius: 3px; 
}

 .datagridnew table thead th 
 {
     background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
     background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
     background-color:#8C8C8C; color:#ffffff; 
     font-size: 15px; font-weight: bold;
      border-left: 1px solid #A3A3A3;
      text-align:center; 
     } 

 .datagrid table td, .datagrid table th { padding: 3px 10px;}
 .datagrid table thead th 
 {
     background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
     background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
     background-color:#8C8C8C; color:#ffffff; 
     font-size: 15px; font-weight: bold;
      border-left: 1px solid #A3A3A3;
      text-align:center; 
     } 
 .datagrid table thead th:first-child  
 {
     border: none; 
     }
 .datagrid table tbody td  
 {
     color: #7D7D7D; border-left: 1px solid #DBDBDB;
     font-size: 12px;font-weight:bold; 
     }
 .datagrid table tbody 
 .alt td { background: #EBEBEB; color: #7D7D7D; }
 
 .datagrid table tbody td:first-child { border-left: none; }.datagrid table tbody tr:last-child td { border-bottom: none; }
 .datagrid table tfoot td div  
 {
     border-top: 1px solid #8C8C8C;background: #EBEBEB;}  
     .datagrid table tfoot td { padding: 0; font-size: 12px }
  .datagrid table tfoot td div{ padding: 2px; }.
  datagrid table tfoot td ul { margin: 0; padding:0; list-style: none; text-align: right; }
  .datagrid table tfoot  li { display: inline; }
  .datagrid table tfoot li a  
  {
      text-decoration: none; display: inline-block; 
       padding: 2px 8px; margin: 1px;color: #F5F5F5;
       border: 1px solid #8C8C8C;-webkit-border-radius: 3px;
        -moz-border-radius: 3px; border-radius: 3px;
         background:-webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );background:-moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );filter:progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
         background-color:#8C8C8C; }
  .datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover  
  {
      text-decoration: none;border-color: #7D7D7D; color: #F5F5F5;
       background: none; background-color:#8C8C8C;
       }
       div.dhtmlx_window_active, div.dhx_modal_cover_dv { position: fixed !important; }

</style>

    <title>
    </title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="datagrid">
       
    <table>
    <thead>
    <tr> <th> <asp:Label ID="Label17" runat="server"   Text="MATERIAL RETURN GOODS DETAIL"> </asp:Label></th> </tr>
   
     <tr><th> <asp:Label ID="Label18" runat="server" style="text-align:center"  Text="Request ID: "></asp:Label> 
     <asp:Label ID="lblRequestID" runat="server"></asp:Label> </th></tr>
 
    </thead>

              
                </table>
                <hr />

                <table style="width:100%;">
                   
                    <thead>
                      <tr><th> <asp:Label ID="lbl" style="text-align:center" runat="server">Request Data ( By Marketing)</asp:Label></th>
                      <th> <asp:Label ID="lbl0" style="text-align:center" runat="server">Inspection Data</asp:Label></th> </tr>
                   </thead>
                    
                </table>
                <hr />
        <table>
        <tbody>
                    <tr>
               
                    <td >
                            <asp:Label ID="lbl1" runat="server">Party / Customer Name</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPartyName" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPartyName_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl2" runat="server">Invoice No</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceNo" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceNo_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lbl3" runat="server">Sort No</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblSortNo" runat="server"></asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblSortNo_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt">
                        <td >
                            MR No</td>
                        <td >
                            &nbsp;</td>
                        <td >
                            <asp:Label ID="lbmr" runat="server" Text="[lbMRnoins]"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:Label ID="lbl4" runat="server">Shade</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblShade" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblShade_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl5" runat="server">Invoice Qty</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceQty" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceQty_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:Label ID="lbl6" runat="server">Return Qty</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReturnQty" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbreturnqtyins" runat="server" Text="lbreturnqtyins"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl7" runat="server">No. of Rolls</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblRolls" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbrollsins" runat="server" Text="lbrollsins"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:Label ID="lbl8" runat="server">Reason</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblReason" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbReasonins" runat="server" Text="[lbReasonins]"></asp:Label>
                        </td>
                    </tr >
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl9" runat="server">Inspection Remarks</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInspectionRemarks" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lbinsremarks" runat="server" Text="[lbinsremarks]"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:Label ID="lbl10" runat="server">Invoice Date</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceDate" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblInvoiceDate_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl11" runat="server">Authorized Date</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAuthorizedDate" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAuthorizedDate_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:Label ID="lbl12" runat="server">Sales Person</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSalesPerson" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblSalesPerson_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl13" runat="server">Plant</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPlant" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblPlant_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Label ID="lbl14" runat="server">Freight Paid By</asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFreightPaidBy" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFreightPaidBy_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt">
                        <td >
                            <asp:Label ID="lbl15" runat="server">Freight Value</asp:Label>
                        </td>
                        <td >
                            <asp:Label ID="lblFreightValue" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblFreightValue_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td >
                            <asp:Label ID="lbl16" runat="server">Inspection Done By</asp:Label>
                        </td>
                        <td>
                           </td>
                        <td>
                            <asp:Label ID="lblInspectionDoneBy_ins" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr class="alt" >
                        <td >
                            Inspection Date</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lbinsdate" runat="server" Text="[lbinsdate]"></asp:Label>
                        </td>
                    </tr>
                    <tr >
                        <td colspan="3" >
                            &nbsp;</td>
                    </tr>

                    </tbody>
                         </table>
                          <hr />
                          <table>
                        <tbody>
                  <tr class="alt"> <td> <asp:Label ID="Label1"  runat="server"> Authorization History</asp:Label></td></tr>
                  </tbody>
                       </table>
                
                   <%--  <tr class="alt" ><td> <asp:Label ID="lbl17"  runat="server"> Authorization History</asp:Label></td>  </tr>--%>
             
                  
                    <table>
             
                    <tr >
                        <td colspan="3" >
                                <asp:GridView ID="grdAuthorizationHistory" runat="server" Width="100%" 
                                class="datagrid">
                                    <HeaderStyle CssClass="GridHeader" />
                                    <RowStyle CssClass="GridRow" />
                                </asp:GridView>
                      </td>
                    </tr>
           
                   
                        </table>
                       
               





                <table style="width:100%;">
            <tr>
                <td class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    This is a system generated mail and sent through OPS online mail management 
                    system. Please donot reply.</td>
            </tr>
            <tr>
                <td class="style1">
                    Thank you</td>
            </tr>
            </table>
    </div>
    </form>
</body>
</html>
