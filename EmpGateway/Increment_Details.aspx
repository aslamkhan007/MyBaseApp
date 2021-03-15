<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Increment_Details.aspx.vb" Inherits="EmpGateway_Increment_Details" %>

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
        .style2
        {
            text-decoration: underline;
        }
        .table1 {
  border: solid thin black;
}

.table1 td {
  border: solid thin black;
}
    </style>
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
</head>




   
            <div ID="divmaster" class="noprint">
                <style media="print" type="text/css">

.noprint {
display: none;
}</style>



       


<div >




















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
                    <img alt="Logo" class="style1"  src="/fusionapps/EmpGateway/Image/JCTLogoCR.png" /></td>
                <td colspan="2" style="text-align: center">
                    <h3>Annexure </h3></td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblQuotationNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: center" colspan="2">
                   </td>
                <td style="width: 25%" class="labelcells">
                    <asp:Label ID="lblCurrentDate" runat="server"></asp:Label>
                </td>
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
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Employee Name :</td>
                <td style="width: 25%">
                    <asp:Label ID="lblEmpName" runat="server"></asp:Label>
                </td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Designation :</td>
                <td style="width: 25%">
                    <asp:Label ID="lblDesig" runat="server"></asp:Label>
                </td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    Salary Code:</td>
                <td style="width: 25%">
                    <asp:Label ID="lblSalCode" runat="server"></asp:Label>
                </td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 25%">
                    A. <span class="style2">Core Components</span></td>

                <td style="width: 25%">
                    </td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                    <hr /></td>
            </tr>
            <tr>
                <td colspan="4">
                    <table style="width:100%;">
                        <tr>
                            <td valign="top" width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr>
                                        <td width="35%">
                                            &nbsp;</td>
                                        <td align="center" colspan="2">
                                            EXISTING</td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            &nbsp;</td>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Basic</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lblBasic_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lblBasic_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            HRA</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_HRA_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_HRA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Colony Allowance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CA_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Personal Allowance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_PA_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_PA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Special Allowance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SA_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Transport Allowance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            ASA (in lieu of car)</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ASA_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ASA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Uniform Allowance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_UA_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_UA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box">
                                    <tr>
                                        <td align="center" colspan="2">
                                            REVISED (1-4-2018)</td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            Monthly</td>
                                        <td align="center">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lblBasic_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lblBasic_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_HRA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_HRA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_PA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_PA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ASA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ASA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_UA_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_UA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                        </tr>
                    </table>
                    </td>
            </tr>

            <tr>
                <td colspan="4">
                    <asp:Label ID="lblQuotationNo0" runat="server">Wherever HRA &amp; Colony Allowance both are mentioned, HRA is taken as the presumed value of the house given by the company.</asp:Label>
                </td>
            </tr>

            <tr>
                <td style="width: 25%">
                    B. <span class="style2">Retiral Benefits</span></td>
                <td colspan="3">
                    &nbsp;</td>
            </tr>

            <tr>
                <td colspan="4">
                    <table style="width:100%;">
                        <tr>
                            <td valign="top" width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr>
                                        <td width="35%">
                                            Company Contribution / Value</td>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Co&#39;s contribution to PF</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CPF_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CPF_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Gratuity</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Gratuity_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Gratuity_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            ESI</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ESI_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ESI_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Bonus</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Bonus_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Bonus_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Superannuation *</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SUP_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SUP_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box">
                                    <tr>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CPF_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_CPF_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Gratuity_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Gratuity_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ESI_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ESI_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Bonus_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Bonus_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SUP_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_SUP_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                        </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" align="left" colspan="4">
                    <asp:Label ID="lblSuper" runat="server" Text="*"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 25%; text-align: left;">
                    C. <span class="style2">Basket of Benefits</span></td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" valign="top">
                    <table style="width:100%;">
                        <tr>
                            <td width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr>
                                        <td width="35%">
                                            &nbsp;</td>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            LTA</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LTA_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LTA_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Medical Reimbusement</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_MedR_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_MedR_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Conveyance Reimbursement</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ConvRemb_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ConvRemb_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Driver&#39;s Salary</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_DrvSal_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_DrvSal_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Entertainment Reimbursement</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EntRemb_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EntRemb_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Tel. Reimbursement</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Tel_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Tel_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Vehicle Allowance &amp; Road Tax</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_VechRoad_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_VechRoad_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Co. Car Value</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_coCarVal_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_coCarVal_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Furniture Allowance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_E_Fur_All_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_E_Fur_All_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Fur. Maint. Allow</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_FurMaint_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_FurMaint_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box">
                                    <tr>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LTA_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LTA_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_MedR_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_MedR_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ConvRemb_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_ConvRemb_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_DrvSal_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_DrvSal_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EntRemb_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EntRemb_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Tel_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_Tel_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_VechRoad_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_VechRoad_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_coCarVal_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_coCarVal_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_R_Fur_All_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_TA_R_Fur_All_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_FurMaint_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_FurMaint_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    </table>
                            </td>
                        </tr>
                    </table>
                    </td>
            </tr>

            <tr>
                <td colspan="4">
                    
                    </td>
            </tr>

            <tr>
                <td colspan="4">
                    <table style="width:100%;">
                        <tr>
                            <td>
                                D. <span class="style2">Other Benefits</span></td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td colspan="4">
                     <table style="width:100%;">
                        <tr>
                            <td width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr>
                                        <td width="35%">
                                            Company Contribution / Value</td>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            GME Insurance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GMEI_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GMEI_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            GPA Insurance</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GPAI_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GPAI_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Group Term Policy</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GrpTP_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GrpTP_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            EDLI</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EDLI_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EDLI_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Leave Value</td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LeaveVal_E_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LeaveVal_E_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" align="center">
                                    <tr>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GMEI_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GMEI_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GPAI_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GPAI_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GrpTP_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_GrpTP_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EDLI_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_EDLI_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LeaveVal_R_M" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_LeaveVal_R_A" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    </table>
                            </td>
                        </tr>
                    </table></td>
            </tr>

            <tr>
                <td colspan="4">
                 <table style="width:100%;">
                        <tr>
                            <td width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr align="center">
                                        <td width="35%">
                                            Total (A+B+C+D)</td>
                                        <td width="15%">
                                            <asp:Label ID="lbl_TotalABCD_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:Label ID="lbl_TotalABCD_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box">
                                                                        
                                    <tr align="center">
                                        <td width="15%">
                                            <asp:Label ID="lbl_TotalABCD_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:Label ID="lbl_TotalABCD_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="600">
                                E. <span class="style2">Variable Pay</span></td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr>
                                        <td width="35%">
                                            &nbsp;</td>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            Variable Pay</td>
                                        <td align="center" width="15%">
                                            <asp:Label ID="lbl_VARPay_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" width="15%">
                                            <asp:Label ID="lbl_VarPay_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" align="center">
                                    <tr>
                                        <td align="center" width="15%">
                                            Monthly</td>
                                        <td align="center" width="15%">
                                            Annual</td>
                                    </tr>
                                    <tr>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_VarPay_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lbl_VarPay_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                                                        
                                    </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="600">
                                &nbsp;</td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="600">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box" >
                                    <tr align="center">
                                        <td width="35%">
                                            Total CTC</td>
                                        <td width="15%">
                                            <asp:Label ID="lbl_CTC_E_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:Label ID="lbl_CTC_E_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    </table>
                            </td>
                            <td width="5%">
                                &nbsp;</td>
                            <td valign="top">
                                <table style="margin: 0px; padding: 0px; width: 100%; display: table; border-collapse:collapse;" 
                                    class="table1" frame="box">
                                                                        
                                    <tr align="center">
                                        <td width="15%">
                                            <asp:Label ID="lbl_CTC_R_M" runat="server"></asp:Label>
                                        </td>
                                        <td width="15%">
                                            <asp:Label ID="lbl_CTC_R_A" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%">
                    &nbsp;</td>
            </tr>

            <tr>
                <td style="width: 25%; " class="style2">
                    Note :</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
            </tr>

            <tr>
                <td colspan="4">
                    a ) Bonus Shall be paid to eligible employees and the value mentioned may vary 
                    as per actual declaration by thecompany according to Bonus Act, 1965</td>
            </tr>

            <tr>
                <td colspan="4">
                    b) The Company&#39;s contribution to provident Fund @12% of Basic Salary</td>
            </tr>

            <tr>
                <td colspan="4">
                    c) The Gratuity shall be paid according to the provision of Payment of Gratuity 
                    Act, 1972</td>
            </tr>

            <tr>
                <td colspan="4">
                    d) For the employees drawing Basic Salary of Rs.21,001 /- pm &amp; above, the 
                    Company&#39;s contribution to Superannuation Scheme shall be @13% of Basic Drawn.</td>
            </tr>

            <tr>
                <td colspan="4">
                    e)&nbsp; The release of allowances &amp; reimbursements are subject to existing 
                    &quot;term &amp; conditions&quot; and Company Policy.</td>
            </tr>

            <tr>
                <td colspan="4">
                    f) Special Allowance, Transport Allowance & Medical Reimbursement has been merged into Personal Allowance w.e.f. 01.04.2018</td>
            </tr>

            <tr>
                <td colspan="4">
                    g)<b><span style="font-size:8.0pt;font-family:&quot;Tahoma&quot;,&quot;sans-serif&quot;;
mso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;color:black;
mso-ansi-language:EN-US;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">Variable Pay is subject 
                    to the Achievement of targets.</span></b></td>
            </tr>

            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>

            <tr>
                <td colspan="4">
                    Note : This is a computer generated document and does not need to be signed.</td>
            </tr>

            <tr>
                <td colspan="4">
                    &nbsp;</td>
            </tr>

            <tr>
                <td style="width: 25%; ">
                    &nbsp;</td>
                <td style="width: 25%; font-weight: bold;">
                    &nbsp;</td>
                <td style="text-align: right">
                    </td>
                <td style="width: 25%; ">
                    &nbsp;</td>
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
                    <%--  <asp:LinkButton ID="lblBack" runat="server" 
                        onclientclick="window.history.go(-1);return false;">Back</asp:LinkButton>--%>
                        <asp:button id="backButton" runat="server" text="Back" 
                        OnClientClick="JavaScript:window.history.back(1);return false;"></asp:button>
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
</div>
</html>
