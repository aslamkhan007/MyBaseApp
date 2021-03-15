<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Quotation_Cost_Memo.aspx.vb" Inherits="OPS_Quotation_Cost_Memo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cost Memo - Quotation - OPS</title>
    <link rel="stylesheet" type="text/css" href="../stylesheets/formatingsheet.css" />
    <link rel="stylesheet" type="text/css" href="../stylesheets/stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <table style="width:100%;">
            <tr>
                <td colspan="6" style="text-align: center">
                    <h3 style="font-family: 'trebuchet MS'"><asp:Label ID="lblCompany" runat="server" Text="JCT Limited Phagwara"></asp:Label></h3>
                </td>
            </tr>
            <tr>
                <td style="width: 17%">
                    &nbsp;</td>
                <td style="width: 17%">
                    &nbsp;</td>
                <td colspan="2" class="NormalText" 
                    style="text-align: center; font-size: 11pt; font-weight: bold;">
                    Cost Memo</td>
                <td style="width: 17%">
                    &nbsp;</td>
                <td style="width: 17%">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 17%" class="labelcells">
                    Memo No : </td>
                <td style="width: 17%" class="NormalText">
                    <asp:Label ID="lblMemoNo" runat="server"></asp:Label>
                </td>
                <td style="width: 17%" class="NormalText">
                    &nbsp;</td>
                <td style="width: 17%" class="labelcells">
                    &nbsp;</td>
                <td style="width: 17%" class="labelcells">
                    Memo
                    Date : </td>
                <td style="width: 17%" class="NormalText">
                    <asp:Label ID="lblMemoDt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    Mixing : </td>
                <td class="labelcells">
                    Warp</td>
                <td class="NormalText">
                    <asp:Label ID="lblMixWarp" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Validity Period:</td>
                <td class="NormalText">
                    1 Month</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Weft</td>
                <td class="NormalText">
                    <asp:Label ID="lblMixWeft" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Sort No : </td>
                <td class="NormalText">
                    <asp:Label ID="lblSortNo" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    Rate \ Candy \ Kg (Rs.) :</td>
                <td class="labelcells">
                    Warp</td>
                <td class="NormalText">
                    <asp:Label ID="lblRateWarp" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Weft</td>
                <td class="NormalText">
                    <asp:Label ID="lblRateWeft" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Description :</td>
                <td class="labelcells" colspan="2">
                    <asp:Label ID="lblDescription" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Warp Count 1</td>
                <td class="NormalText">
                    <asp:Label ID="lblWPCount1" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Warp Count 2</td>
                <td class="NormalText">
                    <asp:Label ID="lblWPCount2" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Weft Count 1</td>
                <td class="NormalText">
                    <asp:Label ID="lblWFCount1" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    Weft Count 2</td>
                <td class="NormalText">
                    <asp:Label ID="lblWFCount2" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    Cost / Mtr. (Rs.)</td>
                <td class="labelcells">
                    Mfg Cost Detail:</td>
                <td class="labelcells">
                    Exp./ Mtr. (Rs.)</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Yarn Dyed Coverage</td>
                <td class="NormalText">
                    <asp:Label ID="lblYarnDyedCov" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Raw Material</td>
                <td class="NormalText">
                    <asp:Label ID="lblRawMaterial" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Spinning</td>
                <td class="NormalText">
                    <asp:Label ID="lblSpinning" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    Reed \ Pick on Loom</td>
                <td class="NormalText">
                    <asp:Label ID="lblReedLoom" runat="server"></asp:Label>
                &nbsp;\
                    <asp:Label ID="lblPick" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    MFG Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblMfgCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Size</td>
                <td class="NormalText">
                    <asp:Label ID="lblSize" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    Reed \ Pick on Table</td>
                <td class="NormalText">
                    <asp:Label ID="lblReedTable" runat="server"></asp:Label>
                &nbsp;\
                    <asp:Label ID="lblPickTab" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    GRY Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblGryCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Sizing</td>
                <td class="NormalText">
                    <asp:Label ID="lblSizing" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    Finish Width</td>
                <td class="NormalText">
                    <asp:Label ID="lblFinishWidth" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    MND Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblMndCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Drawing - In</td>
                <td class="NormalText">
                    <asp:Label ID="lblDrawingIn" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    Loom Size</td>
                <td class="NormalText">
                    <asp:Label ID="lblLoomSize" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    PRC Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblPrcCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Weaving</td>
                <td class="NormalText">
                    <asp:Label ID="lblWeaving" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    R.P.M.</td>
                <td class="NormalText">
                    <asp:Label ID="lblRPM" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    DYC Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblDycCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Wvg. Efficiency</td>
                <td class="NormalText">
                    <asp:Label ID="lblWvgEff" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    CLP Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblClpCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    </td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells" style="width: auto">
                    Prod\Loom\Day Fin. Mtr.</td>
                <td class="NormalText">
                    <asp:Label ID="lblProdLoomFin" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    SHR Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblShrCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells" style="width: auto">
                    Prod\Loom\Day Pkd. Mtr.</td>
                <td class="NormalText">
                    <asp:Label ID="lblProdLoomPkd" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    FIN Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblFinCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Yarn Wt.\Mtr (Kg.)</td>
                <td class="NormalText">
                    <asp:Label ID="lblYarnWtMtr" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    VAL Loss</td>
                <td class="NormalText">
                    <asp:Label ID="lblValLoss" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Finish Wt.\Sqr. Mtr (Kg.)</td>
                <td class="NormalText">
                    <asp:Label ID="lblFinishWtMtr" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    SELL Exp</td>
                <td class="NormalText">
                    <asp:Label ID="lblSellExp" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Val Recovery</td>
                <td class="NormalText">
                    <asp:Label ID="lblValRecovery" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    <hr /></td>
            </tr>
            <tr>
                <td class="labelcells">
                    Cost / Mtr. (INR)</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    Total</td>
                <td class="NormalText">
                    <asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    DNV Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblDnVCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    DEP Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblDEPCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    FOH Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblFOHCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="6">
                    <hr /></td>
            </tr>
            <tr>
                <td class="labelcells">
                    Total Cost /Mtr (INR)</td>
                <td class="NormalText">
                    <asp:Label ID="lblTotalCostMtr" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells">
                    Dyes\Chem Cost (INR)</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    Dying/Kg :</td>
                <td class="NormalText" style="vertical-align: top">
                    <asp:Label ID="lblDyesChemDyingCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    <asp:Label ID="lblDyeType" runat="server"></asp:Label>
                </td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    Printing/Mtr :</td>
                <td class="NormalText" style="vertical-align: top">
                    <asp:Label ID="lblDyesChemPrintingCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    Finishing/Kgs :</td>
                <td class="NormalText" style="vertical-align: top">
                    <asp:Label ID="lblDyesChemFinishingCost" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Finish Type</td>
                <td class="NormalText">
                    <asp:Label ID="lblFinishType" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Finish Charge / Mtr</td>
                <td class="NormalText">
                    <asp:Label ID="lblFinishCharge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    &nbsp;</td>
                <td class="NormalText" style="vertical-align: top">
                    &nbsp;</td>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="labelcells">
                    Finishing M/C Cost</td>
                <td class="NormalText">
                    <asp:Label ID="lblFinishingMCCost" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    &nbsp;</td>
                <td class="NormalText" style="vertical-align: top">
                    &nbsp;</td>
                <td class="labelcells">
                    Peaching Type</td>
                <td class="NormalText">
                    <asp:Label ID="lblPeachingType" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Peaching Charge / Mtr</td>
                <td class="NormalText">
                    <asp:Label ID="lblPeachingCharge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    Selling Exp % :</td>
                <td class="NormalText">
                    <asp:Label ID="lblSellingExpPerc" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Printing Type</td>
                <td class="NormalText">
                    <asp:Label ID="lblPrintingType" runat="server"></asp:Label>
                </td>
                <td class="labelcells">
                    Printing Charge / Mtr</td>
                <td class="NormalText">
                    <asp:Label ID="lblPrintingCharge" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    Remark :</td>
                <td class="NormalText" colspan="5">
                    <asp:Label ID="lblRmk" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells" style="text-align: right">
                    &nbsp;</td>
                <td class="NormalText" colspan="5">
                    <asp:Label ID="lblRmk1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="labelcells">
                    &nbsp;</td>
                <td class="NormalText" colspan="5">
                    <asp:GridView ID="grdDyeChemCost" runat="server" AutoGenerateColumns="False" 
                        EnableModelValidation="True" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="RFD" HeaderText="RFD" ReadOnly="True" 
                                SortExpression="RFD" NullDisplayText="0" >
                            <ItemStyle Width="17%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="White" HeaderText="White" ReadOnly="True" 
                                SortExpression="White" NullDisplayText="0" >
                            <ItemStyle Width="17%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Light" HeaderText="Light" ReadOnly="True" 
                                SortExpression="Light" >
                            <ItemStyle Width="17%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Medium" HeaderText="Medium" ReadOnly="True" 
                                SortExpression="Medium" >
                            <ItemStyle Width="17%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Dark" HeaderText="Dark" ReadOnly="True" 
                                SortExpression="Dark">
                            <ItemStyle Width="17%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Xtra Dark" HeaderText="Xtra Dark" ReadOnly="True" 
                                SortExpression="Xtra Dark">
                            <ItemStyle Width="17%" />
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:jctgenConnectionString %>" 
                        SelectCommand="jct_ops_shade_depth_rate" SelectCommandType="StoredProcedure">
                    </asp:SqlDataSource>
                </td>
            </tr>
            </table>
        <table style="width:100%;" runat="server" visible="false">
            <tr>
                <td class="NormalText" 
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    &nbsp;</td>
                <td class="NormalText" 
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    RFD</td>
                <td class="NormalText" 
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    White</td>
                <td class="NormalText" 
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    Light</td>
                <td class="NormalText" 
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    Medium</td>
                <td class="NormalText" 
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    Dark</td>
                <td class="NormalText" 
                    
                    
                    
                    style="border-width: 1px; border-color: #000000; border-style: solid none solid none; font-weight: bold; text-align: right;">
                    Extra Dark</td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold;">
                    Dying Cost / Kg.</td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblDygCostRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblDygCostWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblDygCostLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblDygCostMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblDygCostDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblDygCostED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold;">
                    Diff
                    Dying Cost / Kg.</td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblCostDiffRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblCostDiffWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblCostDiffLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblCostDiffMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblCostDiffDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right;">
                    <asp:Label ID="lblCostDiffED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" 
                    
                    style="border-bottom-style: solid; border-width: 1px; border-color: #000000; font-weight: bold;">
                    Diff
                    Dying Cost / Mtr.</td>
                <td class="NormalText" 
                    style="border-width: 1px; border-color: #000000; text-align: right; border-bottom-style: solid;">
                    &nbsp;<asp:Label ID="lblCostDiffMtrRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" 
                    style="border-width: 1px; border-color: #000000; text-align: right; border-bottom-style: solid;">
                    &nbsp;<asp:Label ID="lblCostDiffMtrWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" 
                    style="border-width: 1px; border-color: #000000; text-align: right; border-bottom-style: solid;">
                    <asp:Label ID="lblCostDiffMtrLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" 
                    style="border-width: 1px; border-color: #000000; text-align: right; border-bottom-style: solid;">
                    <asp:Label ID="lblCostDiffMtrMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" 
                    style="border-width: 1px; border-color: #000000; text-align: right; border-bottom-style: solid;">
                    <asp:Label ID="lblCostDiffMtrDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" 
                    style="border-width: 1px; border-color: #000000; text-align: right; border-bottom-style: solid;">
                    <asp:Label ID="lblCostDiffMtrED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Gry Cost</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblGryCostRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblGryCostWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblGryCostLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblGryCostMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblGryCostDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblGryCostED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Processing M/C Cost</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblProcMcCostRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblProcMcCostWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblProcMcCostLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblProcMcCostMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblProcMcCostDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblProcMcCostED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Dye/Chemical Cost/Mtr</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblDyeChemCostRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblDyeChemCostWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblDyeChemCostLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblDyeChemCostMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblDyeChemCostDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblDyeChemCostED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Finish Upcharge</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinishChrgRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinishChrgWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinishChrgLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinishChrgMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinishChrgDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinishChrgED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Printing Cost</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPrintingChrgRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPrintingChrgWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPrintingChrgLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPrintingChrgMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPrintingChrgDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPrintingChrgED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Peaching Charge</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPeachingChrgRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPeachingChrgWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPeachingChrgLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPeachingChrgMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPeachingChrgDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblPeachingChrgED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Folding/Packing Cost</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFoldCostRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFoldCostWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFoldCostLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFoldCostMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFoldCostDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFoldCostED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Shrinkage Cost</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblShrRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblShrWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblShrLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblShrMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblShrDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblShrED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Value Loss</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblValLossRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblValLossWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblValLossLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblValLossMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblValLossDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblValLossED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Sell Exp</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblSellExpRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblSellExpWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblSellExpLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblSellExpMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblSellExpDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblSellExpED" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    Final DnV Cost</td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinalDnvRFD" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinalDnvWhite" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinalDnvLight" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinalDnvMed" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinalDnvDark" runat="server"></asp:Label>
                </td>
                <td class="NormalText" style="text-align: right">
                    <asp:Label ID="lblFinalDnvExtraDark" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="NormalText" style="font-weight: bold">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
                <td class="NormalText">
                    &nbsp;</td>
            </tr>
            </table>
    
    </div>
    </form>
</body>
</html>
