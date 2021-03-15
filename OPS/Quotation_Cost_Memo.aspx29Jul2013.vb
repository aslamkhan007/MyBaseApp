Imports System.Data
Imports System.Data.SqlClient

Partial Class OPS_Quotation_Cost_Memo
    Inherits System.Web.UI.Page
    Dim ofn As New Functions

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        bind_data()
        calculate_shade_distributions()

    End Sub

    Protected Sub bind_data()

        Dim memo_no As String = Request.QueryString("memo_no")
        Dim sort_no As String = Request.QueryString("sort_no")
        Dim finish As String = Request.QueryString("finish")
        Dim printing As String = Request.QueryString("printing")
        Dim dyetype As String = Request.QueryString("dyetype")
        Dim peaching As String = Request.QueryString("peaching")
        Dim plant As String = Request.QueryString("plant")

        Dim sqlstr As String = "jct_costing_data_fetch '" & sort_no & "','" & memo_no & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        Try

            If dr.HasRows Then

                dr.Read()
                lblSortNo.Text = dr("sort_no").ToString
                lblMemoNo.Text = dr("mem_no").ToString
                lblMemoDt.Text = dr("date").ToString
                lblMixWarp.Text = dr("mxg_warp").ToString
                lblMixWeft.Text = dr("mxg_weft").ToString
                lblRateWarp.Text = dr("r_can_wp").ToString
                lblRateWeft.Text = dr("r_can_wf").ToString
                lblDescription.Text = dr("desc").ToString
                lblWPCount1.Text = dr("wp_coun").ToString
                lblWPCount2.Text = dr("wp_coun2").ToString
                lblWFCount1.Text = dr("wf_coun").ToString
                lblWFCount2.Text = dr("wf_coun2").ToString
                lblYarnDyedCov.Text = dr("yr_dyd").ToString
                lblReedLoom.Text = dr("reed").ToString
                lblPick.Text = dr("pick").ToString
                lblReedTable.Text = dr("tpick").ToString
                lblPickTab.Text = dr("pick").ToString
                lblFinishWidth.Text = dr("fn_wdth").ToString
                lblLoomSize.Text = dr("loom_code").ToString
                lblRPM.Text = dr("r_p_m").ToString
                lblWvgEff.Text = dr("eff").ToString
                lblProdLoomFin.Text = dr("fn_prodday").ToString
                lblProdLoomPkd.Text = dr("mtr_pkd").ToString
                lblYarnWtMtr.Text = dr("ywt_kg").ToString
                lblFinishWtMtr.Text = dr("ywt_sq").ToString
                lblValRecovery.Text = dr("arcv").ToString

                lblRawMaterial.Text = dr("raw_cost").ToString
                lblMfgCost.Text = dr("mfg_cost").ToString
                lblGryCost.Text = dr("gry_cost").ToString
                lblMndCost.Text = dr("mnd_cost").ToString
                lblPrcCost.Text = dr("prc_mcst").ToString
                lblDycCost.Text = dr("dyc_cost").ToString
                lblClpCost.Text = dr("clp_cost").ToString
                lblShrCost.Text = dr("shr_cost").ToString
                lblFinCost.Text = dr("cost_dnvm").ToString
                lblValLoss.Text = dr("val_ls").ToString
                lblSellExp.Text = dr("sel_ls").ToString
                lblSpinning.Text = dr("yrncst_mtr").ToString
                lblSize.Text = dr("sizcst_mtr").ToString
                lblSizing.Text = dr("sizexp_mtr").ToString
                lblDrawingIn.Text = dr("drwexp_mtr").ToString
                lblWeaving.Text = dr("wvgexp_mtr").ToString

                lblTotalCost.Text = dr("dnv_cst").ToString
                lblDnVCost.Text = dr("dnv_cst").ToString
                lblDEPCost.Text = dr("dep_cst").ToString
                lblFOHCost.Text = dr("foh_cst").ToString
                lblTotalCostMtr.Text = dr("cost_total").ToString

                lblDyesChemDyingCost.Text = dr("dyd_cst").ToString
                lblDyesChemPrintingCost.Text = dr("ptg_cst").ToString
                lblDyesChemFinishingCost.Text = dr("fin_cst").ToString
                lblSellingExpPerc.Text = dr("slex").ToString

                lblFinishType.Text = finish
                lblPrintingType.Text = printing
                lblDyeType.Text = dyetype
                lblPeachingType.Text = peaching

                dr.Close()

            End If

        Catch ex As Exception
            ofn.Alert(ex.Message)
        Finally

        End Try

        Try
            If Request.QueryString("finish") <> " " Then
                sqlstr = "JCT_OPS_Get_Finish_Cost '" & lblFinishType.Text & "'"
                Dim dr1 As SqlDataReader = ofn.FetchReader(sqlstr)
                If dr1.HasRows Then
                    dr1.Read()
                    lblFinishCharge.Text = dr1("Cost")
                End If
                dr1.Close()
            Else
                lblFinishCharge.Text = "0"
            End If

            'sqlstr = "select * from jct_ops_multi_master where '" & lblPrintingType.Text & "'"
            'Dim dr2 As SqlDataReader = ofn.FetchReader(sqlstr)
            'If dr2.HasRows Then
            '    dr2.Read()
            '    lblFinishCharge.Text = dr2("Cost")
            'End If
            'dr2.Close()

            If plant = "Taffeta" Then

                If lblPrintingType.Text = "Pigment" Then
                    lblPrintingCharge.Text = "10.00"
                ElseIf lblPrintingType.Text = "VAT DISCHARGE" Then
                    lblPrintingCharge.Text = "15.50"
                Else
                    lblPrintingCharge.Text = "0"
                End If

            ElseIf plant = "Cotton" Then

                If lblPrintingType.Text = "Pigment" Then
                    lblPrintingCharge.Text = "12.00"
                ElseIf lblPrintingType.Text = "VAT DISCHARGE" Then
                    lblPrintingCharge.Text = "17.00"
                Else
                    lblPrintingCharge.Text = "0"
                End If

            End If

        Catch ex As Exception
            ofn.Alert(ex.Message)
        End Try

    End Sub

    Protected Sub calculate_shade_distributions()

        Dim rfd_std, white_std, light_std, med_std, dark_std, ed_std As Double
        Dim sqlstr As String = "jctgen..jct_ops_shade_depth_rate"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        Try

            If dr.HasRows Then
                dr.Read()
                rfd_std = dr("rfd")
                white_std = dr("white")
                light_std = dr("light")
                med_std = dr("medium")
                dark_std = dr("dark")
                ed_std = dr("extra dark")

                dr.Close()
                If Val(lblDyesChemDyingCost.Text) = 0 Then
                    lblDygCostRFD.Text = Math.Round(rfd_std, 2)
                    lblDygCostWhite.Text = Math.Round(white_std, 2)
                Else

                    lblDygCostLight.Text = Math.Round(light_std, 2)
                    lblDygCostMed.Text = Math.Round(med_std, 2)
                    lblDygCostDark.Text = Math.Round(dark_std, 2)
                    lblDygCostED.Text = Math.Round(ed_std, 2)
                End If

                'Calc_DnV(rfd_std, white_std, light_std, med_std, dark_std, ed_std)
                Calculate_Dying_Cost_Diff(rfd_std, white_std, light_std, med_std, dark_std, ed_std)
                Calculate_Dying_Cost_Diff_Mtr()
                Calculate_Processing_Mc_Cost()
                Calculate_DyeChem_Cost()
                Calculate_Greigh_Cost()
                Calculate_FoldingPacking_Cost()
                Calculate_Finish_Charge()
                Calculate_Printing_Charge()
                Calculate_Peaching_Charge()
                Calculate_Sell_Exp()
                Calculate_Shrinkage_Distribution()
                Calculate_Value_Loss()

                Calc_DnV()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Calculate_Peaching_Charge()

        Dim peaching_charge As Single

        If lblPeachingType.Text = "Single" Then
            peaching_charge = 2.0
        ElseIf lblPeachingType.Text = "Double" Then
            peaching_charge = 3.5
        Else
            peaching_charge = 0.0
        End If

        lblPeachingCharge.Text = peaching_charge

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblPeachingChrgRFD.Text = peaching_charge
            lblPeachingChrgWhite.Text = peaching_charge
        Else
            lblPeachingChrgLight.Text = peaching_charge
            lblPeachingChrgMed.Text = peaching_charge
            lblPeachingChrgDark.Text = peaching_charge
            lblPeachingChrgED.Text = peaching_charge
        End If

    End Sub

    Protected Sub Calc_DnV()

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblFinalDnvRFD.Text = Val(lblGryCostRFD.Text) + Val(lblProcMcCostRFD.Text) + Val(lblDyeChemCostRFD.Text) + Val(lblFinishChrgRFD.Text) + Val(lblPrintingChrgRFD.Text) + Val(lblFoldCostRFD.Text) + Val(lblShrRFD.Text) + Val(lblValLossRFD.Text) + Val(lblSellExpRFD.Text) + Val(lblPeachingChrgRFD.Text)
            lblFinalDnvWhite.Text = Val(lblGryCostWhite.Text) + Val(lblProcMcCostWhite.Text) + Val(lblDyeChemCostWhite.Text) + Val(lblFinishChrgWhite.Text) + Val(lblPrintingChrgWhite.Text) + Val(lblFoldCostWhite.Text) + Val(lblShrWhite.Text) + Val(lblValLossWhite.Text) + Val(lblSellExpWhite.Text) + Val(lblPeachingChrgWhite.Text)

        Else
            lblFinalDnvLight.Text = Val(lblGryCostLight.Text) + Val(lblProcMcCostLight.Text) + Val(lblDyeChemCostLight.Text) + Val(lblFinishChrgLight.Text) + Val(lblPrintingChrgLight.Text) + Val(lblFoldCostLight.Text) + Val(lblShrLight.Text) + Val(lblValLossLight.Text) + Val(lblSellExpLight.Text) + Val(lblPeachingChrgLight.Text)
            lblFinalDnvMed.Text = Val(lblGryCostMed.Text) + Val(lblProcMcCostMed.Text) + Val(lblDyeChemCostMed.Text) + Val(lblFinishChrgMed.Text) + Val(lblPrintingChrgMed.Text) + Val(lblFoldCostMed.Text) + Val(lblShrMed.Text) + Val(lblValLossMed.Text) + Val(lblSellExpMed.Text) + Val(lblPeachingChrgMed.Text)
            lblFinalDnvDark.Text = Val(lblGryCostDark.Text) + Val(lblProcMcCostDark.Text) + Val(lblDyeChemCostDark.Text) + Val(lblFinishChrgDark.Text) + Val(lblPrintingChrgDark.Text) + Val(lblFoldCostDark.Text) + Val(lblShrDark.Text) + Val(lblValLossDark.Text) + Val(lblSellExpDark.Text) + Val(lblPeachingChrgDark.Text)
            lblFinalDnvExtraDark.Text = Val(lblGryCostED.Text) + Val(lblProcMcCostED.Text) + Val(lblDyeChemCostED.Text) + Val(lblFinishChrgED.Text) + Val(lblPrintingChrgED.Text) + Val(lblFoldCostED.Text) + Val(lblShrED.Text) + Val(lblValLossED.Text) + Val(lblSellExpED.Text) + Val(lblPeachingChrgED.Text)
        End If
        '    lblFinalDnvWhite.Text = Math.Round(dnv_wht, 2)
        '    lblFinalDnvLight.Text = Math.Round(dnv_lht, 2)
        '    lblFinalDnvMed.Text = Math.Round(dnv_med, 2)
        '    lblFinalDnvDark.Text = Math.Round(dnv_dark, 2)
        '    lblFinalDnvExtraDark.Text = Math.Round(dnv_ed, 2)

    End Sub

    'Protected Sub Calc_DnV(rfd_std As Double, white_std As Double, light_std As Double, med_std As Double, dark_std As Double, ed_std As Double)

    '    Dim dnv, dye_cst_kg, yrn_wt_mtr, val_rcv, shr, sel_exp As Double

    '    dnv = Val(lblDnVCost.Text)
    '    dye_cst_kg = Val(lblDyesChemDyingCost.Text)
    '    yrn_wt_mtr = Val(lblYarnWtMtr.Text)
    '    val_rcv = Val(lblValRecovery.Text)
    '    shr = 0.95
    '    sel_exp = 1 - Val(lblSellingExpPerc.Text) / 100

    '    Dim dnv_rfd, dnv_wht, dnv_lht, dnv_med, dnv_dark, dnv_ed As Double

    '    dnv_rfd = (dnv) + (rfd_std - dye_cst_kg) * yrn_wt_mtr / val_rcv / shr / sel_exp
    '    dnv_wht = (dnv) + (white_std - dye_cst_kg) * yrn_wt_mtr / val_rcv / shr / sel_exp
    '    dnv_lht = (dnv) + (light_std - dye_cst_kg) * yrn_wt_mtr / val_rcv / shr / sel_exp
    '    dnv_med = (dnv) + (med_std - dye_cst_kg) * yrn_wt_mtr / val_rcv / shr / sel_exp
    '    dnv_dark = (dnv) + (dark_std - dye_cst_kg) * yrn_wt_mtr / val_rcv / shr / sel_exp
    '    dnv_ed = (dnv) + (ed_std - dye_cst_kg) * yrn_wt_mtr / val_rcv / shr / sel_exp


    '    lblFinalDnvRFD.Text = Math.Round(dnv_rfd, 2)
    '    lblFinalDnvWhite.Text = Math.Round(dnv_wht, 2)
    '    lblFinalDnvLight.Text = Math.Round(dnv_lht, 2)
    '    lblFinalDnvMed.Text = Math.Round(dnv_med, 2)
    '    lblFinalDnvDark.Text = Math.Round(dnv_dark, 2)
    '    lblFinalDnvExtraDark.Text = Math.Round(dnv_ed, 2)

    'End Sub

    Protected Sub Calculate_Dying_Cost_Diff(rfd_std As Double, white_std As Double, light_std As Double, med_std As Double, dark_std As Double, ed_std As Double)

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblCostDiffRFD.Text = Math.Round(rfd_std - Val(lblDyesChemDyingCost.Text), 2)
            lblCostDiffWhite.Text = Math.Round(white_std - Val(lblDyesChemDyingCost.Text), 2)

        Else
            lblCostDiffLight.Text = Math.Round(light_std - Val(lblDyesChemDyingCost.Text), 2)
            lblCostDiffMed.Text = Math.Round(med_std - Val(lblDyesChemDyingCost.Text), 2)
            lblCostDiffDark.Text = Math.Round(dark_std - Val(lblDyesChemDyingCost.Text), 2)
            lblCostDiffED.Text = Math.Round(ed_std - Val(lblDyesChemDyingCost.Text), 2)
        End If
    End Sub

    Protected Sub Calculate_Dying_Cost_Diff_Mtr()

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblCostDiffMtrRFD.Text = Math.Round(lblCostDiffRFD.Text * lblYarnWtMtr.Text, 2)
            lblCostDiffMtrWhite.Text = Math.Round(lblCostDiffWhite.Text * lblYarnWtMtr.Text, 2)

        Else
            lblCostDiffMtrLight.Text = Math.Round(lblCostDiffLight.Text * lblYarnWtMtr.Text, 2)
            lblCostDiffMtrMed.Text = Math.Round(lblCostDiffMed.Text * lblYarnWtMtr.Text, 2)
            lblCostDiffMtrDark.Text = Math.Round(lblCostDiffDark.Text * lblYarnWtMtr.Text, 2)
            lblCostDiffMtrED.Text = Math.Round(lblCostDiffED.Text * lblYarnWtMtr.Text, 2)
        End If
    End Sub

    Protected Sub Calculate_Processing_Mc_Cost()
        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblProcMcCostRFD.Text = Val(lblPrcCost.Text)
            lblProcMcCostWhite.Text = Val(lblPrcCost.Text)
        Else
            lblProcMcCostLight.Text = Val(lblPrcCost.Text)
            lblProcMcCostMed.Text = Val(lblPrcCost.Text)
            lblProcMcCostDark.Text = Val(lblPrcCost.Text)
            lblProcMcCostED.Text = Val(lblPrcCost.Text)
        End If

    End Sub

    Protected Sub Calculate_DyeChem_Cost()

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblDyeChemCostRFD.Text = Val(lblDycCost.Text) + Math.Round(Val(lblCostDiffRFD.Text) * Val(lblYarnWtMtr.Text), 2)
            lblDyeChemCostWhite.Text = Val(lblDycCost.Text) + Math.Round(Val(lblCostDiffWhite.Text) * Val(lblYarnWtMtr.Text), 2)
        Else
            lblDyeChemCostLight.Text = Val(lblDycCost.Text) + Math.Round(Val(lblCostDiffLight.Text) * Val(lblYarnWtMtr.Text), 2)
            lblDyeChemCostMed.Text = Val(lblDycCost.Text) + Math.Round(Val(lblCostDiffMed.Text) * Val(lblYarnWtMtr.Text), 2)
            lblDyeChemCostDark.Text = Val(lblDycCost.Text) + Math.Round(Val(lblCostDiffDark.Text) * Val(lblYarnWtMtr.Text), 2)
            lblDyeChemCostED.Text = Val(lblDycCost.Text) + Math.Round(Val(lblCostDiffED.Text) * Val(lblYarnWtMtr.Text), 2)
        End If

    End Sub

    Protected Sub Calculate_Greigh_Cost()

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblGryCostRFD.Text = Val(lblGryCost.Text) + Val(lblMndCost.Text)
            lblGryCostWhite.Text = Val(lblGryCost.Text) + Val(lblMndCost.Text)
        Else
            lblGryCostLight.Text = Val(lblGryCost.Text) + Val(lblMndCost.Text)
            lblGryCostMed.Text = Val(lblGryCost.Text) + Val(lblMndCost.Text)
            lblGryCostDark.Text = Val(lblGryCost.Text) + Val(lblMndCost.Text)
            lblGryCostED.Text = Val(lblGryCost.Text) + Val(lblMndCost.Text)
        End If

    End Sub

    Protected Sub Calculate_FoldingPacking_Cost()

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblFoldCostRFD.Text = Val(lblClpCost.Text)
            lblFoldCostWhite.Text = Val(lblClpCost.Text)

        Else

            lblFoldCostLight.Text = Val(lblClpCost.Text)
            lblFoldCostMed.Text = Val(lblClpCost.Text)
            lblFoldCostDark.Text = Val(lblClpCost.Text)
            lblFoldCostED.Text = Val(lblClpCost.Text)

        End If

    End Sub

    Protected Sub Calculate_Finish_Charge()

        Dim fin_mc_cost As Double = 0
        Dim sqlstr As String = "jct_ops_get_finishing_machine_cost '" & Trim(lblFinishType.Text) & "'"
        Dim dr As SqlDataReader = ofn.FetchReader(sqlstr)
        Try
            If dr.HasRows Then
                dr.Read()
                fin_mc_cost = Val(dr("M/C_Cost"))
                lblFinishingMCCost.Text = fin_mc_cost
            End If
        Catch ex As Exception

        End Try

        'Added by Jatin on 14 Dec 2012 '

        If (Val(lblFinishCharge.Text) <> 0) Then

            Dim Diff As Double
            Diff = Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)
            Dim impactmtr As Double
            impactmtr = Diff * Val(lblYarnWtMtr.Text)
            'Dim TotalPerMtr As Double
            'TotalPerMtr = impactmtr + fin_mc_cost
            lblFinishCharge.Text = impactmtr
            lblFinishingMCCost.Text = fin_mc_cost
            ViewState("FinishCost") = lblFinishCharge.Text + fin_mc_cost
            Calculate_Finish_Charge_Final()

            'lblFinishCharge.Text = Val(lblFinishCharge.Text) + fin_mc_cost

            If Val(lblDyesChemDyingCost.Text) = 0 Then
                lblFinishChrgRFD.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                lblFinishChrgWhite.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)

            Else

                ' -- Commented by Jatin on 13 Dec 2012 to calculate the Finishing cost on the basis of excel sheet provided by Sunil Jain...

                'lblFinishChrgLight.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                'lblFinishChrgMed.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                'lblFinishChrgDark.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                'lblFinishChrgED.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)

                ' Added Code by Jatin

                lblFinishChrgLight.Text = Math.Round(Val(lblFinishCharge.Text), 2)
                lblFinishChrgMed.Text = Math.Round(Val(lblFinishCharge.Text), 2)
                lblFinishChrgDark.Text = Math.Round(Val(lblFinishCharge.Text), 2)
                lblFinishChrgED.Text = Math.Round(Val(lblFinishCharge.Text), 2)

            End If

        Else

            If Val(lblDyesChemDyingCost.Text) = 0 Then
                lblFinishChrgRFD.Text = 0
                lblFinishChrgWhite.Text = 0

            Else

                ' -- Commented by Jatin on 13 Dec 2012 to calculate the Finishing cost on the basis of excel sheet provided by Sunil Jain...

                'lblFinishChrgLight.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                'lblFinishChrgMed.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                'lblFinishChrgDark.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)
                'lblFinishChrgED.Text = Math.Round((Val(lblFinishCharge.Text) - Val(lblDyesChemFinishingCost.Text)) * Val(lblYarnWtMtr.Text), 2)

                ' Added Code by Jatin

                lblFinishChrgLight.Text = 0
                lblFinishChrgMed.Text = 0
                lblFinishChrgDark.Text = 0
                lblFinishChrgED.Text = 0

            End If
        End If


    End Sub

    ' Added By Jatin

    Protected Sub Calculate_Finish_Charge_Final()

        Dim ShrPer As Double = 5.0
        Dim ShrCost, Val_Loss, Sell_Exp As Decimal

        'lblFinishCharge.Text = (Val(lblFinishCharge.Text) / (100 - ShrPer)) * 100

        ShrCost = (Val(ViewState("FinishCost")) / (100 - ShrPer)) * 100

        ViewState("Shr_Cost") = ShrCost - ViewState("FinishCost")

        'lblFinishCharge.Text = Val(lblFinishCharge.Text) / Val(lblValRecovery.Text)

        Val_Loss = Val(ShrCost) / Val(lblValRecovery.Text)

        ViewState("Val_Loss") = Val_Loss - ShrCost

        'lblFinishCharge.Text = Val(lblFinishCharge.Text) / (100 - Val(lblSellingExpPerc.Text)) * 100
        Sell_Exp = Val(Val_Loss) / (100 - Val(lblSellingExpPerc.Text)) * 100

        lblFinishCharge.Text = Val(Sell_Exp)

        ViewState("Sell_Exp") = Val_Loss - ShrCost

        'Dim impact As Double = Val(lblFinishCharge.Text) - Val(ViewState("FinishCost"))

        'ViewState("FinishCost") = Val(ViewState("FinishCost")) + impact

    End Sub

    Protected Sub Calculate_Printing_Charge()

        'If Val(lblDyesChemDyingCost.Text) = 0 Then
        '    lblPrintingChrgRFD.Text = Val(lblPrintingCharge.Text)
        '    lblPrintingChrgWhite.Text = Val(lblPrintingCharge.Text)
        'Else

        '    lblPrintingChrgLight.Text = Val(lblPrintingCharge.Text)
        '    lblPrintingChrgMed.Text = Val(lblPrintingCharge.Text)
        '    lblPrintingChrgDark.Text = Val(lblPrintingCharge.Text)
        '    lblPrintingChrgED.Text = Val(lblPrintingCharge.Text)
        'End If

        ' Added by jatin to add printing cost on 22 Dec 2012
        Dim Diff As Double
        Dim impactmtr As Double
        Dim ShrPer As Double = 5.0
        Dim TotalPerMtr As Double
        Dim impact As Double
        Dim ShrCost, Val_Loss, Sell_Exp As Decimal

        If Val(lblPrintingCharge.Text) <> 0 Then

            Diff = Val(lblPrintingCharge.Text) - Val(lblDyesChemPrintingCost.Text)

            impactmtr = Diff '* Val(lblYarnWtMtr.Text)

            TotalPerMtr = impactmtr '+ Val(ViewState("fin_mc_cost"))
            lblPrintingCharge.Text = TotalPerMtr

            ShrCost = (Val(lblPrintingCharge.Text) / (100 - ShrPer)) * 100
            ViewState.Add("Shr_Cost", (ShrCost - Val(lblPrintingCharge.Text)))
            Val_Loss = Val(ShrCost) / Val(lblValRecovery.Text)
            ViewState.Add(("Val_Loss"), (Val_Loss - ShrCost))
            Sell_Exp = Val(Val_Loss) / (100 - Val(lblSellingExpPerc.Text)) * 100
            ViewState.Add(("Sell_Exp"), (Val_Loss - ShrCost))
            ViewState("PrintingCharge") = Val(Sell_Exp)
            'impact = Val(lblPrintingCharge.Text) - Val(ViewState("PrintingCharge"))
            'ViewState.Add(("PrintingCharge"), (Val(ViewState("PrintingCharge")) + impact))

            If Val(lblDyesChemDyingCost.Text) = 0 Then
                lblPrintingChrgRFD.Text = Val(ViewState("PrintingCharge"))
                lblPrintingChrgWhite.Text = Val(ViewState("PrintingCharge"))
            Else

                lblPrintingChrgLight.Text = Math.Round(Val(ViewState("PrintingCharge")), 2)
                lblPrintingChrgMed.Text = Math.Round(Val(ViewState("PrintingCharge")), 2)
                lblPrintingChrgDark.Text = Math.Round(Val(ViewState("PrintingCharge")), 2)
                lblPrintingChrgED.Text = Math.Round(Val(ViewState("PrintingCharge")), 2)

            End If
        Else


            If Val(lblDyesChemDyingCost.Text) = 0 Then
                lblPrintingChrgRFD.Text = 0
                lblPrintingChrgWhite.Text = 0
            Else


                lblPrintingChrgLight.Text = 0
                lblPrintingChrgMed.Text = 0
                lblPrintingChrgDark.Text = 0
                lblPrintingChrgED.Text = 0
            End If
        End If



    End Sub

    Protected Sub Calculate_Shrinkage_Distribution()

        Dim shrinkage_perc As Double = 1 - 0.95

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblShrRFD.Text = Val(lblShrCost.Text) + Math.Round(Val(lblCostDiffMtrRFD.Text) * shrinkage_perc, 2)
            lblShrRFD.Text = Math.Round(Val(lblShrRFD.Text) + Val(ViewState("Shr_Cost")) + Val(lblPeachingCharge.Text) * shrinkage_perc, 2)

            lblShrWhite.Text = Val(lblShrCost.Text) + Math.Round(Val(lblCostDiffMtrWhite.Text) * shrinkage_perc, 2)
            lblShrWhite.Text = Math.Round(Val(lblShrWhite.Text) + Val(ViewState("Shr_Cost") + Val(lblPeachingCharge.Text) * shrinkage_perc), 2)
        Else

            lblShrLight.Text = Val(lblShrCost.Text) + Math.Round(Val(lblCostDiffMtrLight.Text) * shrinkage_perc, 2)
            lblShrLight.Text = Math.Round(Val(lblShrLight.Text) + Val(ViewState("Shr_Cost") + Val(lblPeachingCharge.Text) * shrinkage_perc), 2)
            lblShrMed.Text = Val(lblShrCost.Text) + Math.Round(Val(lblCostDiffMtrMed.Text) * shrinkage_perc, 2)
            lblShrMed.Text = Math.Round(Val(lblShrMed.Text) + Val(ViewState("Shr_Cost") + Val(lblPeachingCharge.Text) * shrinkage_perc), 2)
            lblShrDark.Text = Val(lblShrCost.Text) + Math.Round(Val(lblCostDiffMtrDark.Text) * shrinkage_perc, 2)
            lblShrDark.Text = Math.Round(Val(lblShrDark.Text) + Val(ViewState("Shr_Cost") + Val(lblPeachingCharge.Text) * shrinkage_perc), 2)
            lblShrED.Text = Val(lblShrCost.Text) + Math.Round(Val(lblCostDiffMtrED.Text) * shrinkage_perc, 2)
            lblShrED.Text = Math.Round(Val(lblShrED.Text) + Val(ViewState("Shr_Cost") + Val(lblPeachingCharge.Text) * shrinkage_perc), 2)
        End If

        'lblShrRFD.Text = Math.Round(Val(lblCostDiffMtrRFD.Text) * shrinkage_perc, 2) '+ Math.Round(Val(lblFinishChrgRFD.Text) * shrinkage_perc, 2) + Math.Round(Val(lblPrintingChrgRFD.Text) * shrinkage_perc, 2)
        'lblShrWhite.Text = Math.Round(Val(lblCostDiffMtrWhite.Text) * shrinkage_perc, 2) '+ Math.Round(Val(lblFinishChrgWhite.Text) * shrinkage_perc, 2) + Math.Round(Val(lblPrintingChrgWhite.Text) * shrinkage_perc, 2)
        'lblShrLight.Text = Math.Round(Val(lblCostDiffMtrLight.Text) * shrinkage_perc, 2) '+ Math.Round(Val(lblFinishChrgLight.Text) * shrinkage_perc, 2) + Math.Round(Val(lblPrintingChrgLight.Text) * shrinkage_perc, 2)
        'lblShrMed.Text = Math.Round(Val(lblCostDiffMtrMed.Text) * shrinkage_perc, 2) '+ Math.Round(Val(lblFinishChrgMed.Text) * shrinkage_perc, 2) + Math.Round(Val(lblPrintingChrgMed.Text) * shrinkage_perc, 2)
        'lblShrDark.Text = Math.Round(Val(lblCostDiffMtrDark.Text) * shrinkage_perc, 2) '+ Math.Round(Val(lblFinishChrgDark.Text) * shrinkage_perc, 2) + Math.Round(Val(lblPrintingChrgDark.Text) * shrinkage_perc, 2)
        'lblShrED.Text = Math.Round(Val(lblCostDiffMtrED.Text) * shrinkage_perc, 2) '+ Math.Round(Val(lblFinishChrgED.Text) * shrinkage_perc, 2) + Math.Round(Val(lblPrintingChrgED.Text) * shrinkage_perc, 2)

    End Sub

    Protected Sub Calculate_Value_Loss()

        Dim val_recovery As Double = 1 - Val(lblValRecovery.Text)

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblValLossRFD.Text = Val(lblValLoss.Text) + Math.Round(Val(lblCostDiffMtrRFD.Text) * val_recovery, 2)
            lblValLossRFD.Text = Math.Round(Val(lblValLossRFD.Text) + Val(ViewState("Val_Loss")) + Val(lblPeachingCharge.Text) * val_recovery, 2)
            lblValLossWhite.Text = Val(lblValLoss.Text) + Math.Round(Val(lblCostDiffMtrWhite.Text) * val_recovery, 2)
            lblValLossWhite.Text = Math.Round(Val(lblValLossWhite.Text) + Val(ViewState("Val_Loss")) + Val(lblPeachingCharge.Text) * val_recovery, 2)
        Else
            lblValLossLight.Text = Val(lblValLoss.Text) + Math.Round(Val(lblCostDiffMtrLight.Text) * val_recovery, 2)
            lblValLossLight.Text = Math.Round(Val(lblValLossLight.Text) + Val(ViewState("Val_Loss")) + Val(lblPeachingCharge.Text) * val_recovery, 2)
            lblValLossMed.Text = Val(lblValLoss.Text) + Math.Round(Val(lblCostDiffMtrMed.Text) * val_recovery, 2)
            lblValLossMed.Text = Math.Round(Val(lblValLossMed.Text) + Val(ViewState("Val_Loss")) + Val(lblPeachingCharge.Text) * val_recovery, 2)
            lblValLossDark.Text = Val(lblValLoss.Text) + Math.Round(Val(lblCostDiffMtrDark.Text) * val_recovery, 2)
            lblValLossDark.Text = Math.Round(Val(lblValLossDark.Text) + Val(ViewState("Val_Loss")) + Val(lblPeachingCharge.Text) * val_recovery, 2)
            lblValLossED.Text = Val(lblValLoss.Text) + Math.Round(Val(lblCostDiffMtrED.Text) * val_recovery, 2)
            lblValLossED.Text = Math.Round(Val(lblValLossED.Text) + Val(ViewState("Val_Loss")) + Val(lblPeachingCharge.Text) * val_recovery, 2)
        End If

        'lblValLossRFD.Text = Math.Round(Val(lblCostDiffMtrRFD.Text) * val_recovery, 2) + Math.Round(Val(lblFinishChrgRFD.Text) * val_recovery, 2) + Math.Round(Val(lblPrintingChrgRFD.Text) * val_recovery, 2)
        'lblValLossWhite.Text = Math.Round(Val(lblCostDiffMtrWhite.Text) * val_recovery, 2) + Math.Round(Val(lblFinishChrgWhite.Text) * val_recovery, 2) + Math.Round(Val(lblPrintingChrgWhite.Text) * val_recovery, 2)
        'lblValLossLight.Text = Math.Round(Val(lblCostDiffMtrLight.Text) * val_recovery, 2) + Math.Round(Val(lblFinishChrgLight.Text) * val_recovery, 2) + Math.Round(Val(lblPrintingChrgLight.Text) * val_recovery, 2)
        'lblValLossMed.Text = Math.Round(Val(lblCostDiffMtrMed.Text) * val_recovery, 2) + Math.Round(Val(lblFinishChrgMed.Text) * val_recovery, 2) + Math.Round(Val(lblPrintingChrgMed.Text) * val_recovery, 2)
        'lblValLossDark.Text = Math.Round(Val(lblCostDiffMtrDark.Text) * val_recovery, 2) + Math.Round(Val(lblFinishChrgDark.Text) * val_recovery, 2) + Math.Round(Val(lblPrintingChrgDark.Text) * val_recovery, 2)
        'lblValLossED.Text = Math.Round(Val(lblCostDiffMtrED.Text) * val_recovery, 2) + Math.Round(Val(lblFinishChrgED.Text) * val_recovery, 2) + Math.Round(Val(lblPrintingChrgED.Text) * val_recovery, 2)

    End Sub

    Protected Sub Calculate_Sell_Exp()
        Dim selling_exp As Double
        selling_exp = lblSellingExpPerc.Text / 100

        If Val(lblDyesChemDyingCost.Text) = 0 Then
            lblSellExpRFD.Text = Val(lblSellExp.Text) + Math.Round(Val(lblCostDiffMtrRFD.Text) * selling_exp, 2)
            lblSellExpRFD.Text = Math.Round(Val(lblSellExpRFD.Text) + Val(ViewState("Sell_Exp")) + Val(lblPeachingCharge.Text) * selling_exp, 2)
            lblSellExpWhite.Text = Val(lblSellExp.Text) + Math.Round(Val(lblCostDiffMtrWhite.Text) * selling_exp, 2)
            lblSellExpWhite.Text = Math.Round(Val(lblSellExpWhite.Text) + Val(ViewState("Sell_Exp")) + Val(lblPeachingCharge.Text) * selling_exp, 2)
        Else

            lblSellExpLight.Text = Val(lblSellExp.Text) + Math.Round(Val(lblCostDiffMtrLight.Text) * selling_exp, 2)
            lblSellExpLight.Text = Math.Round(Val(lblSellExpLight.Text) + Val(ViewState("Sell_Exp")) + Val(lblPeachingCharge.Text) * selling_exp, 2)
            lblSellExpMed.Text = Val(lblSellExp.Text) + Math.Round(Val(lblCostDiffMtrMed.Text) * selling_exp, 2)
            lblSellExpMed.Text = Math.Round(Val(lblSellExpMed.Text) + Val(ViewState("Sell_Exp")) + Val(lblPeachingCharge.Text) * selling_exp, 2)
            lblSellExpDark.Text = Val(lblSellExp.Text) + Math.Round(Val(lblCostDiffMtrDark.Text) * selling_exp, 2)
            lblSellExpDark.Text = Math.Round(Val(lblSellExpDark.Text) + Val(ViewState("Sell_Exp")) + Val(lblPeachingCharge.Text) * selling_exp, 2)
            lblSellExpED.Text = Val(lblSellExp.Text) + Math.Round(Val(lblCostDiffMtrED.Text) * selling_exp, 2)
            lblSellExpED.Text = Math.Round(Val(lblSellExpED.Text) + Val(ViewState("Sell_Exp")) + Val(lblPeachingCharge.Text) * selling_exp, 2)
        End If
        'lblSellExpRFD.Text = Math.Round(Val(lblCostDiffMtrRFD.Text) * selling_exp, 2) + Math.Round(Val(lblFinishChrgRFD.Text) * selling_exp, 2) + Math.Round(Val(lblPrintingChrgRFD.Text) * selling_exp, 2)
        'lblSellExpWhite.Text = Math.Round(Val(lblCostDiffMtrWhite.Text) * selling_exp, 2) + Math.Round(Val(lblFinishChrgWhite.Text) * selling_exp, 2) + Math.Round(Val(lblPrintingChrgWhite.Text) * selling_exp, 2)
        'lblSellExpLight.Text = Math.Round(Val(lblCostDiffMtrLight.Text) * selling_exp, 2) + Math.Round(Val(lblFinishChrgLight.Text) * selling_exp, 2) + Math.Round(Val(lblPrintingChrgLight.Text) * selling_exp, 2)
        'lblSellExpMed.Text = Math.Round(Val(lblCostDiffMtrMed.Text) * selling_exp, 2) + Math.Round(Val(lblFinishChrgMed.Text) * selling_exp, 2) + Math.Round(Val(lblPrintingChrgMed.Text) * selling_exp, 2)
        'lblSellExpDark.Text = Math.Round(Val(lblCostDiffMtrDark.Text) * selling_exp, 2) + Math.Round(Val(lblFinishChrgDark.Text) * selling_exp, 2) + Math.Round(Val(lblPrintingChrgDark.Text) * selling_exp, 2)
        'lblSellExpED.Text = Math.Round(Val(lblCostDiffMtrED.Text) * selling_exp, 2) + Math.Round(Val(lblFinishChrgED.Text) * selling_exp, 2) + Math.Round(Val(lblPrintingChrgED.Text) * selling_exp, 2)

    End Sub

End Class
