<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="jct_workercell_approval.aspx.cs" Inherits="OPS_jct_workercell_approval" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<head id="Head1" runat="server">
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

    .style1
    {
    }

    .style2
    {
        width: 25%;
        height: 23px;
    }

    </style>
    <title></title>

    </head>
<body style="font-family :Times New Roman";>
    <form id="form1" runat="server">
    <div>
    <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText">
            <tr>
             <td class="style1" colspan="6">
             <h3>
                 Jct Limited&nbsp;Phagwara&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 </h3>
             <hr />
             </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/OPS/Image/JCTLogoCR.png" 
                        Width="112px" Height="99px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="20pt" Text=" Mobile Approval Slip"></asp:Label>
                    <br />
                    </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td   style="width: 25%; " >
                    Empcode :</td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblEmpcode" runat="server"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%;">
                    TokenNo     :</td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblTokenNo" runat="server"  font-weight="bold" 
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    Deptcode:</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblDeptcode" runat="server" font-weight="bold"  
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    Enpname  :</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblEnpname" runat="server" font-weight="bold"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%; ; ">
                    Father Name:</td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblFatherName" runat="server" font-weight="bold"  
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%;">
                    DesgCode:</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblDesgCode" runat="server" font-weight="bold"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Shift:</td>
                <td class="style2">
                    <asp:Label ID="lblShift" runat="server" font-weight="bold"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td class="style2">
                    </td>
                <td class="style2">
                    </td>
                <td class="style2">
                    </td>
                <td class="style2">
                    </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    Vaild From   :</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblVaildFrom" runat="server" font-weight="bold"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%; ; ">
                    &nbsp;</td>
                <td style="width: 25%; ">
                    &nbsp;</td>
                <td style="width: 25%; ; ">
                    Vaild To:</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblVaildTo" runat="server" font-weight="bold"  
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="6">
             <hr />
                </td>
            </tr>
            </table>
                 
                   </div>
             </form>
            </body>
            </html>
            

