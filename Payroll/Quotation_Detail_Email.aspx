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
                        Leave Authorization</h3>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>

           <tr>
                <td style="width: 25%">
                    
                 Leave ID :
                    <asp:Label ID="lblLeaveId" runat="server" CssClass="labelcells"></asp:Label></td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                   
                </td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr> 
      <tr>
                <td style="width: 25%">
                    
                 Leave Status :
                    <asp:Label ID="lblStatus" runat="server" CssClass="labelcells"></asp:Label></td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                   
                </td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr> 
        <%--    <tr>
                <td style="width: 25%">
                   
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    Requester Code :
                </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblRequesterCode" runat="server"></asp:Label>
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
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Authorisation Dt:
                    <asp:Label ID="lblAuthorisationDt" runat="server" CssClass="labelcells"></asp:Label>
                </td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>--%>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%" class="labelcells">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td colspan="4" style="color: #FF0000; font-weight: bold;">
                    <asp:Label ID="lblPPCRemarks" runat="server"></asp:Label>
                     <hr />
                </td>
            </tr>
            <tr>
                <td colspan="4" style="color: #FF0000; font-weight: bold;">
               
                    <asp:GridView ID="GridView6" runat="server" Width="100%" AutoGenerateColumns="False"
                        BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" DataSourceID="SqlDataSource1"
                        EnableModelValidation="True" ShowFooter="True">
                        <Columns>
                            <%--<asp:BoundField HeaderText="Status" DataField="Status">
                                <ItemStyle Width="30px" />
                            </asp:BoundField>--%>
                            <asp:BoundField HeaderText="LeaveID" DataField="LeaveID" />
                            <asp:BoundField HeaderText="Leave Nature" DataField="LeaveNature" />
                            <asp:BoundField HeaderText="LeaveType" DataField="LeaveType" />
                            <asp:BoundField HeaderText="LeaveDate" DataField="LeaveDate" />
                            <asp:BoundField HeaderText="LeaveDays" DataField="LeaveDays" />
                            <asp:BoundField HeaderText="AppliedBy" DataField="RequesterName" />                                                        
                            <asp:BoundField HeaderText="Plant" DataField="Plant" />
                            <asp:BoundField HeaderText="ActionTakenBy" DataField="AuthrisedName" />
                            <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="Type" />
                            <%--<asp:BoundField HeaderText="Target Date (M-D-Y)" DataField="Target Date" DataFormatString="{0:MM/dd/yyyy}"  />
                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" />--%>
                            
                        </Columns>
                        <FooterStyle CssClass="NormalText" />
                        <HeaderStyle BackColor="#DDDDDD" BorderColor="Black" BorderStyle="Double" BorderWidth="4px"
                            Height="23px" CssClass="NormalText" HorizontalAlign="Center" />
                        <RowStyle Height="30px" BorderColor="Black" BorderStyle="Solid" 
                            BorderWidth="1px" CssClass="NormalText" />

                    </asp:GridView><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:misjctdev %>"
                        SelectCommand="Jct_Payroll_Leave_Auth_Report" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="lblLeaveId" Name="AutoId" PropertyName="Text" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                     
                </td>
               
            </tr>
            <tr>
                <td colspan="4">
                            <p>
                This is a system generated mail and sent through Online Employee Portal mail management 
                system. Please donot reply.<br/>
                Thank You
      </p>
                    <hr />
                </td>
            </tr>
            </table>

    </div>
     
    </form>
</body>
</html>

