<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeFile="asset_item_print.aspx.cs" Inherits="AssetMngmnt_asset_item_print" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
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
        height: 24px;
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
                 Jct Limited&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                 Process Manual&nbsp;&nbsp;
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
                        Font-Size="20pt" Text="a"></asp:Label>
                    <br />
                    </td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    ComputerType:</td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblcomptype" runat="server"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%;">
                    Dated :</td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblCurrentDate" runat="server"  font-weight="bold" 
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%; ">
                    IssuedTo:</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblissuedto" runat="server" font-weight="bold"  
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    Department :</td>
                <td style="width: 25%;">
                    <asp:Label ID="lbldept" runat="server" font-weight="bold"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%; ; ">
                    ModellNo:</td>
                <td style="width: 25%; ">
                    <asp:Label ID="lblmodelno" runat="server" font-weight="bold"  
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
                <td style="width: 25%;">
                    Jct SrNo:</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblsrno" runat="server" font-weight="bold"  Font-Names="Calibri" 
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; ">
                    Item Name:</td>
                <td style="width: 25%;">
                    <asp:Label ID="lblitemname" font-weight="bold" runat="server"  
                        Font-Names="Calibri" Font-Bold="True"></asp:Label>
                </td>
                <td style="text-align: right ">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right ">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            </table>
 <table style="width:100%;" style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
                <tr>
                    <td class="NormalText">
                        &nbsp;</td>
                </tr>
               
               </table>
           
      
       
           <table  style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" >
               <%--style="width:100%;"--%>
             
                <tr>
                <td>
                    <asp:DataList ID="DataList1" runat="server" 
                       onitemdatabound="DataList1_ItemDataBound" DataKeyField="asset_id" 
                        Width="100%">
                        <ItemTemplate>
                        <table>
                         <tr>
                         <td>
                         
                         <asp:Label ID="Labelhead" runat="server"   Text='<%# Eval("item_name") %>' 
                                 Font-Bold="True" Font-Names="Calibri" Font-Size="Large" 
                                 ForeColor="Black" ></asp:Label>
                        </td>
                       </tr>
                        <tr>
                        <td>
 
                            <asp:Panel ID="Panel1" runat="server" Width="900px">
                                <asp:GridView ID="GridView1" runat="server"  Width="100%"   BorderColor="Black" 
                                    onrowdatabound="GridView1_RowDataBound" Font-Names="Calibri" >
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px"/>
                                    <PagerStyle CssClass="Pageatyle" />
                                    <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px"/>
                                </asp:GridView>
                            </asp:Panel>
                            </td>

                            </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                  
                     </tr>
                 
                   </table>
                 
                   </div>
                   <table style="border: thin none #000000; width:950px; margin-right : auto; margin-left : auto;" 
            class="NormalText">
            <tr>
             <td Font-Names="Calibri">
             <h3>
                 &nbsp;</h3>
                 <h3>
                     <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Calibri" 
                         Font-Size="Large" Text="Accepted"></asp:Label>
                     <asp:CheckBox ID="CheckBox1" runat="server" />
             </h3>
             </td>
            </tr>
            <tr>
                <td Font-Names="Calibri">
                    <h3>
                        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Calibri" 
                            Font-Size="Large" Text="Rejected"></asp:Label>
                        &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; 
                        &nbsp;</h3>
                    </td>
            </tr>
            <tr>
                    <td class="style1">
                      <h3>
                      </h3>
                      <hr />

                    </td>
               

            </tr>
            <tr>
                <td  style="font-weight: bold;"   class="style1">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="Large" Text=" Card No:"></asp:Label>
                    _______________________________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label 
                        ID="Label3" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="Large" Text="Signature:"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp; ________________________________________</td>
            </tr>
            <tr>
                <td  style="font-weight: bold;"  class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td  style="font-weight: bold;"  class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td  style="font-weight: bold;"  class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
             <td>
             <hr />
             </td>
            </tr>
            <tr>
                <td class="style2" >
                <h3>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </h3>
                   </td>
            </tr>
            <tr>
                <td style="font-weight: bold;" Font-Names="Calibri" class="style1">
                    &nbsp;<asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" 
                        Text="For I.T Use:"></asp:Label>
                    ________________________________________________________________________________________________<br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td style="font-weight: bold;" class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                <h3>
                </h3>
                <hr />

                   </td>
            </tr>
            <tr>
                <td style="font-weight: bold;"  Font-Names="Calibri"class="style1">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    &nbsp;<asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Calibri" 
                        Font-Size="Large" Text="For Internal Use."></asp:Label>
                </td>
            </tr>
            <tr>
               <hr />

            </tr>
            </table>
             </form>
            </body>
            </html>
            
             <%--<td class="NormalText">--%>
                     <%--   <asp:GridView ID="GridView1" runat="server" Width="100%"   BorderColor="Black" 
                           
                            AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
                            EnableModelValidation="True" BorderStyle="Solid" ShowFooter="True" >
                           
                            <Columns>
                                <asp:BoundField DataField="item_name" HeaderText="Asset" InsertVisible="False" 
                                    ReadOnly="True" SortExpression="item_name" />
                                <asp:BoundField DataField="asset_type_name" HeaderText="AssetType" 
                                    SortExpression="asset_type_name" />
                                <asp:BoundField DataField="item_desc" HeaderText="ItemDescription" 
                                    SortExpression="item_desc" />
                           
                           <%-- </Columns>--%>

                         <%--  <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" 
                            BorderWidth="4px" Height="23px" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" />

                        </asp:GridView>--%>
                   

