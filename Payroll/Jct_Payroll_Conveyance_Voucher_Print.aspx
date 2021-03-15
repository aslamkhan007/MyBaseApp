<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Jct_Payroll_Conveyance_Voucher_Print.aspx.cs"
    Inherits="Payroll_Jct_Payroll_Conveyance_Voucher_Print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


<style type="text/css" media="print">
@page {
    size: auto;   /* auto is the initial value */
    margin: 0;  /* this affects the margin in the printer settings */
}
</style>

    <style type="text/css">
        .datagrid table
        {
            border-collapse: collapse;
            text-align: left;
            width: 100%;
        }
        .datagrid
        {
            font: normal 12px/150% Arial, Helvetica, sans-serif;
            background: #fff;
            overflow: hidden;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
        .datagridnew
        {
            font: smaller 8px/150% Arial, Helvetica, sans-serif;
            background: #fff;
            overflow: hidden;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
        }
        
        .datagridnew table thead th
        {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
            color: #ffffff;
            font-size: 15px;
            font-weight: bold;
            border-left: 1px solid #A3A3A3;
            text-align: center;
        }
        
        .datagrid table td, .datagrid table th
        {
            padding: 3px 10px;
        }
        .datagrid table thead th
        {
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
            color: #ffffff;
            font-size: 15px;
            font-weight: bold;
            border-left: 1px solid #A3A3A3;
            text-align: center;
        }
        .datagrid table thead th:first-child
        {
            border: none;
        }
        .datagrid table tbody td
        {
            color: #7D7D7D;
            border-left: 1px solid #DBDBDB;
            font-size: 12px;
            font-weight: bold;
        }
        .datagrid table tbody .alt td
        {
            background: #EBEBEB;
            color: #7D7D7D;
        }
        
        .datagrid table tbody td:first-child
        {
            border-left: none;
        }
        .datagrid table tbody tr:last-child td
        {
            border-bottom: none;
        }
        .datagrid table tfoot td div
        {
            border-top: 1px solid #8C8C8C;
            background: #EBEBEB;
        }
        .datagrid table tfoot td
        {
            padding: 0;
            font-size: 12px;
        }
        .datagrid table tfoot td div
        {
            padding: 2px;
        }
        . datagrid table tfoot td ul
        {
            margin: 0;
            padding: 0;
            list-style: none;
            text-align: right;
        }
        .datagrid table tfoot li
        {
            display: inline;
        }
        .datagrid table tfoot li a
        {
            text-decoration: none;
            display: inline-block;
            padding: 2px 8px;
            margin: 1px;
            color: #F5F5F5;
            border: 1px solid #8C8C8C;
            -webkit-border-radius: 3px;
            -moz-border-radius: 3px;
            border-radius: 3px;
            background: -webkit-gradient( linear, left top, left bottom, color-stop(0.05, #8C8C8C), color-stop(1, #7D7D7D) );
            background: -moz-linear-gradient( center top, #8C8C8C 5%, #7D7D7D 100% );
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#8C8C8C', endColorstr='#7D7D7D');
            background-color: #8C8C8C;
        }
        .datagrid table tfoot ul.active, .datagrid table tfoot ul a:hover
        {
            text-decoration: none;
            border-color: #7D7D7D;
            color: #F5F5F5;
            background: none;
            background-color: #8C8C8C;
        }
        div.dhtmlx_window_active, div.dhx_modal_cover_dv
        {
            position: fixed !important;
        }
        
        .style1
        {
        }
        
        </style>
    <title></title>

    </head>
    <body style="font-family :Times New Roman";>
    <form id="form1" runat="server">
    <div>
    <table style="border: thin none #000000; width:1000px; margin-right : auto; margin-left : auto;" 
            class="NormalText">
        <tr>
            <td class="style1" colspan="4">
                <h3>
                    Jct Limited&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</h3>
                <hr />
            </td>
            <td class="style1">
                    
                      <asp:Label ID="Label10" runat="server" font-weight="bold"  Font-Names="Calibri" 
                    Font-Size="Large"    Text="Print Date:"></asp:Label>
                    <asp:Label ID="lblPrintdate" runat="server" Font-Bold="True" 
                     Font-Size="Large"   Font-Names="Calibri" font-weight="bold"></asp:Label>
                </td>
        </tr>
          <tr>
                <td colspan="4">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/JCTLogoCR.png" 
                        Width="135px" Height="110px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="20pt" Text="Conveyance Reimbursement Slip"></asp:Label>
                    <br />
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                  
                    <asp:Label ID="Label11" runat="server"  Font-Names="Calibri" 
                         Font-Size="X-Large" Font-Bold="False" style="text-decoration: underline">Accounts Department:</asp:Label>

                    </td>
            </tr>
                <tr>
                <td colspan="5">
                  
                    &nbsp;</td>
            </tr>
                <tr>
                <td colspan="5">
                  
                    <asp:Label ID="Label13" runat="server"  Font-Names="Calibri" 
                         Font-Size="X-Large" Font-Bold="False">Please Reimburse following expenses incurred by me for co&#39;s work during the period-</asp:Label>
                    </td>
            </tr>
            <tr>
                <td colspan="5">
                  
                    <asp:Label ID="Label14" runat="server"  Font-Names="Calibri" 
                         Font-Size="X-Large" Font-Bold="False">From Date:</asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblFromp" runat="server" font-weight="bold"  
                 Font-Size="Large"       Font-Names="Calibri" Font-Bold="True"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  
                    <asp:Label ID="Label15" runat="server"  Font-Names="Calibri" 
                         Font-Size="X-Large" Font-Bold="False">To Date:</asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblTodatep" runat="server" font-weight="bold"  
                 Font-Size="Large"       Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
            </tr>
          <%--  <tr>
                <td style="width: 05%; ">
                  
                    <asp:Label ID="Label2" runat="server"  Font-Names="Calibri" 
                         Font-Size="X-Large" Font-Bold="False">Plant:</asp:Label>
                    </td>
                <td style="width: 15%; ">
                    <asp:Label ID="lblPlant" runat="server"  Font-Names="Calibri" 
                        Font-Bold="True" Font-Size="Large"></asp:Label>
                </td>
               <td style="width: 15%;">
                    &nbsp;</td>
                <td style="width: 20%; ">
                    
                                        <asp:Label ID="Label7" runat="server"  font-weight="bold" 
                    Font-Size="X-Large"    Font-Names="Calibri" Text="Location:"></asp:Label>
                        
                    </td>
                
                <td style="width: 20%; ">
                    <asp:Label ID="lblLocation" runat="server"  font-weight="bold"  
                     Font-Size="Large"   Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
                
            </tr>--%>


            <tr>
                <td colspan="5">
                  
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                  
                    &nbsp;</td>
            </tr>


            <tr>

                    <td style="width: 15%; ; ">
                    

                     <asp:Label ID="Label9" runat="server" font-weight="bold"  Font-Names="Calibri" 
                     Font-Size="X-Large"  Text="EmployeeCode:"></asp:Label>

                    </td>
                <td style="width: 25%; ">
                    
                    <asp:Label ID="lblEmployeecode" runat="server" font-weight="bold"  Font-Names="Calibri" 
                     Font-Size="Large"   Font-Bold="True"></asp:Label>
                    
                </td>
                
               <td style="width: 15%; ">
                    &nbsp;</td>
                <td style="width: 25%; ">
                    
                    
<asp:Label ID="Label6" runat="server" font-weight="bold"  
                     Font-Size="X-Large"   Font-Names="Calibri" Text="EmployeeName:"></asp:Label>

                    </td>
            
                <td style="width: 25%; font-weight: bold;">
                    
                    <asp:Label ID="lblEmployeeName" runat="server" font-weight="bold"  
                    Font-Size="Large"    Font-Names="Calibri" Font-Bold="True"></asp:Label>
                    
                    </td>
            
            </tr>

           <tr>
           <td style="width: 05%; ">
                    
                    <asp:Label ID="Label5" runat="server" font-weight="bold"  
                   Font-Size="X-Large"     Font-Names="Calibri"  Text="Department:"></asp:Label>
                    </td>
                <td style="width: 15%;">
                    <asp:Label ID="lblDepartment" runat="server" font-weight="bold"  
                 Font-Size="Large"       Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>

                <td style="width: 15%; ">
                    &nbsp;</td>
                <td style="width: 25%;">
                  
                     <asp:Label ID="Label8" runat="server" font-weight="bold"  Font-Names="Calibri" 
                  Font-Size="X-Large"     Text="Designation:"></asp:Label>
                    </td>
        
               <%-- <td style="width: 15%;">
                    &nbsp;</td>
                <td style="width: 25%;">
                    &nbsp;</td>--%>
                <td style="width: 25%;">
                    <asp:Label ID="lbldesignation" runat="server" font-weight="bold"  Font-Names="Calibri" 
                     Font-Size="Large"   Font-Bold="True"></asp:Label>
                </td>
        
            </tr>
            
            <tr>
                <td style="width: 15%">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="width: 15%">
                    &nbsp;</td>
                <td style="width: 25%; ">
                    
                      &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>

            </table>
        <table style="width: 100%;" style="border: thin none #000000; width: 1000px; margin-right: auto;
            margin-left: auto;">
            <tr>
                <td class="NormalText">
                    &nbsp;
                </td>
            </tr>
        </table>
        <table style="border: thin none #000000; width: 1000px; margin-right: auto; margin-left: auto;">
            <%--style="width:100%;"--%>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <td>
                            <%--<asp:Panel ID="Panel1" runat="server" Width="775px">--%>
                            <asp:Panel ID="Panel1" runat="server" Width="1000px">
                                <asp:GridView ID="GridView1" runat="server" Width="100%" BorderColor="Black" OnRowDataBound="GridView1_RowDataBound"
                                    Font-Names="Calibri" Font-Size="Large">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                                        Height="30px" />
                                    <PagerStyle CssClass="PageStyle" />
                                    <RowStyle Height="40px" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <table style="border: thin none #000000; width: 1000px; margin-right: auto; margin-left: auto;"
        class="NormalText">
        <tr>
            <td >
                <h3>
                </h3>
            </td>
        </tr>
        <tr>
            <td >
                <h3>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </h3>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
        </tr>

        <tr>
            <td >
                &nbsp;
            </td>
        </tr>
   
       
      
        
          <tr>
            <td >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
        </tr>
        <tr>
        <td >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
         <tr>
            <td >
                &nbsp;
            </td>
        </tr>
       
       
            <tr>
            <td >
                &nbsp;
            </td>
        </tr>
           <tr>
            <td >
                &nbsp;
            </td>
        </tr>
           <tr>
            <td >
                &nbsp;
            </td>
        </tr>
           <tr>
            <td >
                &nbsp;
            </td>
        </tr>
           <tr>
            <td >
                &nbsp;
            </td>
        </tr>
                <tr>
            <td >
                &nbsp;
            </td>
        </tr>

                        <tr>
            <td >
                &nbsp;
            </td>
        </tr>

                        <tr>
            <td >
                &nbsp;
            </td>
        </tr>

                        <tr>
            <td >
                &nbsp;
            </td>
        </tr>

                     
                <tr>
            <td >
                &nbsp;
            </td>
        </tr>
        <tr>
            <td >
                <h3>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </h3>
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold;" class="style1">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Large"
                    Text="Date:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; ___________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri"
                    Font-Size="Large" Text="Signature:"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp; ___________________
            </td>
        </tr>

<%--        <tr>
            <td style="font-weight: bold;" font-names="Calibri" class="style1">
                &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri"
                    Font-Size="Large" Text="For I.T Use:"></asp:Label>
                ________________________________________________________________________________________________<br />
                <br />
                <br />
                <br />
            </td>
        </tr>--%>
        <tr>
            <td>
                <h3>
                </h3>
                <hr />
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold;" font-names="Calibri" class="style1">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <hr />
        </tr>
    </table>
    </form>
    </body>
</html>
