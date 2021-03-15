<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Jct_Payroll_Gratuity_Voucher_Print_Wage.aspx.vb" Inherits="Payroll_Jct_Payroll_Gratuity_Voucher_Print_Wage" %>


<%@ Register Assembly="eWorld.UI, Version=2.0.6.2393, Culture=neutral, PublicKeyToken=24d65337282035f2"
    Namespace="eWorld.UI" TagPrefix="ew" %>
<style type="text/css">
        table {
            border-collapse: collapse;
            border-spacing: 0;
            width: 100%;
            border: 0.2em solid #ddd;
            font-weight: 500;
        }

        th, td {
            text-align: left;
            padding: 0.2em;
        }

       

        tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        tr:nth-child(-n+4) td:nth-child(2n+1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(5) {
            background-color: #b9b9b0;
        }

        tr:nth-child(6) {
            background-color: #b9b9b0;
        }

        tr:nth-child(7) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(8) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(9) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(10) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(11) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(12) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(13) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(14) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(15) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(16) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(17) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(18) td:nth-child(1) {
            background-color: #b9b9b0;
        }


        tr:nth-child(19) td:nth-child(1) {
            background-color: #b9b9b0;
        }

        tr:nth-child(20) td:nth-child(1) {
            background-color: #b9b9b0;
        }

tr:nth-child(21) td:nth-child(n+1) {
    background-color: #b9b9b0;
}
   

         tr:nth-child(23)  {
         background-color: #b2efc1;
            color:green;
             font-weight: 600;
        }




        tr:nth-child(24) {
   
     background-color: #C29B0E;
     font-weight: 600;
        }
        tr:nth-child(25) {
   
     background-color: #C29B0E;
     font-weight: 600;
        }
    </style>
<body>
    <form id="form1" runat="server">
    <div id="printDiv">
        <div class="tableheader" style="text-align: center; font-size: larger;">
            JCT LIMITED 
        </div>
        <div class="tableheader" style="text-align: center; font-size:smallER">
            LOCATION:<asp:Label ID="Label121" runat="server" Text=""></asp:Label>
        </div>
        <div class="tableheader" style="text-align: center; font-size: smallER;">
            GRATUITY CALCULATION FORM CUM PAYMENT VOUCHER
        </div>
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label40" runat="server" Text="Employee Code"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="EmpName" runat="server" Text="  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label41" runat="server" Text="Token No"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="FatName" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Name"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="TxtDojs" runat="server" Text="  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label3" runat="server" Text="Father Name :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="TxtNominee" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Department       :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="TxtDojp" runat="server" Text="  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label4" runat="server" Text="Designation."></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="TxtPfVpfNo" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Gratuity No                   :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="TxtRate" runat="server" Text="  "></asp:Label>
                    </td>
                    <td colspan="2">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label22" runat="server" Text="Leaving Reason                   :"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label23" runat="server" Text="  "></asp:Label>
                    </td>
                    <td colspan="2">
                        <asp:Label ID="Label24" runat="server" Text="Leaving Date"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label25" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Period Of Entitlement"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="Days"></asp:Label>:
                        <asp:Label ID="Label9" runat="server" Text=" "></asp:Label>
                    </td>
                  
                   <td colspan="2">
                        <asp:Label ID="Label10" runat="server" Text="Month"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Text=" "></asp:Label>
                    </td>
                    <td>
                     <asp:Label ID="Label6" runat="server" Text="Year"></asp:Label>:
                        <asp:Label ID="Label26" runat="server" Text=" "></asp:Label>
                    </td>
                    
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" Text="Date Of Leaving Service"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:Label ID="ConEmpOBal" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Apr" runat="server" Text="Date OF Joining Service"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:Label ID="ConEmpApril" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="May" runat="server" Text="Service Period"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:Label ID="ConEmpMay" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Jun" runat="server" Text="Basic"></asp:Label>
                    </td>
                     <td>
                        <asp:Label ID="ConEmpJune" runat="server" Text="  "></asp:Label>
                    </td>
             
                      <td colspan="2">
                        <asp:Label ID="IntOwnJune" runat="server" Text="ServiceYr:"></asp:Label>                        
                        <asp:Label ID="IntEmpJune" runat="server" Text=""></asp:Label>
                    </td>                   
                     <td>
                        <asp:Label ID="AmtOwnJune" runat="server" Text="Gratuity Rate"></asp:Label>:
                        <asp:Label ID="AmtEmpJune" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Jul" runat="server" Text="Gratuity Amount"></asp:Label>
                    </td>
                    <td colspan="4">
                        <asp:Label ID="ConEmpJuly" runat="server" Text="  "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Label ID="Aug" runat="server" Text="Amount Should Be Shown In Words"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="5">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Dec" runat="server" Text="Prepared By:"></asp:Label>
                    </td>
                    
                     <td>
                        <asp:Label ID="Label46" runat="server" Text="Authorize Signatory."></asp:Label>
                        
                    </td>
                    <td>
                       
                    </td>
                    <td colspan="2">                      
                        <asp:Label ID="Label47" runat="server" Text="GENERAL MANAGER (L & IR )" Width="250"></asp:Label>                      
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <br />
    </div>
    </form>
</body>

