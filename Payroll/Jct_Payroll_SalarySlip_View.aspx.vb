Imports System.Data
Imports System.Data.SqlClient

Partial Class Payroll_Jct_Payroll_SalarySlip_View
    Inherits System.Web.UI.Page
    Dim value As Integer
    Dim Obj As Connection = New Connection
    Dim dr As sqldatareader
    Dim cmd As New sqlcommand
    Dim empcode As String, SqlPass As String

    Protected Sub DTP2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP2.SelectedIndexChanged

        Dim A, B, c As String

        ''for DTP1 
        A = DTP2.SelectedIndex + 1
        'DTP3.SelectedValue = Now.Year.ToString
        'B = DTP3.SelectedValue
        B = DTP3.TEXT


        If CInt(A) < 10 Then
            A = "0" + A
            c = Trim(B + A)
        Else
            c = Trim(B + A)
        End If

        ' BindData()
        Uniform.Text = ""
        Dim cmd As SqlCommand = New SqlCommand()
        'If (IsPostBack) Then
        If Session("Companycode") = "JCT00LTD" Then
            'SqlPass = "select replace(replace(desg,'<',' '),'>','') desg ,EMPNAME,DEPTCODE,MONTHYEAR,BANKCODE,BANKNO,PAN,ELECTRIC, " & _
            '    "Basic, PRESENT, Pl, Cl, SL, Absent, LWP, PD, " & _
            '    "SUBTOT_SAL, FDA, ADHWB_INC,STDPA,STDSPLALLO,SPLALLO,SPLALW_ARR,PA,ADL_ALW,PA_ARREAR,ADL_ARREAR ,Arrear, TOT_SAL, HRA,HRA_ARREAR,TRPT_ALLOW,TRPT_ARR,OTHER1,COLONY_ALW ,OTHER2,ELEC_ALLOW, GROSS_SAL, " & _
            '    "SAL_ADV,SADV_LOAN,CYC_ADV,FR_ADV,TEL_ADV,OTH_ADV,JCT_CAFE,STAFFEXP,MESS_EXP,SECURITY,CLUB,CLUB2,COUPON,LOAN_STOR,ROUNDOFF,CLAIMDED,  " & _
            '    "PF,FPF,VPF,PFLDED,LIC,TATA_AIG,ESI,RENT_RECV,LOAN_TWCC,CTD,RD,ABP_RD,IT,ECESS,SH_ECESS,OTHER3,OTHER4,PB_WELFARE,TOT_DED,NET_SAL ,ALW_2010,BP_ALW,NET_RENT,NET_CONCHG   " & _
            '    "FROM JCTDEV..EMPMAST WHERE   EMPCODE='" & Session("Empcode") & "' and MonthYear='" & c & "' "


            SqlPass = "Jct_Payroll_Salary_Slip"
            cmd = New SqlCommand(SqlPass, Obj.Connection())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session("Empcode")
            cmd.Parameters.Add("@yearmonth", SqlDbType.VarChar, 10).Value = c


        Else
            'SqlPass = "select replace(replace(desg,'<',' '),'>','') desg ,EMPNAME,DEPTCODE,MONTHYEAR,BANKCODE,BANKNO,PAN,ELECTRIC, " & _
            '   "Basic, PRESENT, Pl, Cl, SL, Absent, LWP, PD, " & _
            '   "SUBTOT_SAL, FDA, ADHWB_INC,STDPA,STDSPLALLO,SPLALLO,SPLALW_ARR,PA,ADL_ALW,PA_ARREAR,ADL_ARREAR ,Arrear, TOT_SAL, HRA,HRA_ARREAR,TRPT_ALLOW,TRPT_ARR,OTHER1,COLONY_ALW ,OTHER2,ELEC_ALLOW, GROSS_SAL, " & _
            '   "SAL_ADV,SADV_LOAN,CYC_ADV,FR_ADV,TEL_ADV,OTH_ADV,JCT_CAFE,STAFFEXP,MESS_EXP,SECURITY,CLUB,CLUB2,COUPON,LOAN_STOR,ROUNDOFF, CLAIMDED, " & _
            '   "PF,FPF,VPF,PFLDED,LIC,TATA_AIG,ESI,RENT_RECV,LOAN_TWCC,CTD,RD,ABP_RD,IT,ECESS,SH_ECESS,OTHER3,OTHER4,PB_WELFARE,TOT_DED,NET_SAL,ALW_2010,BP_ALW,NET_RENT,NET_CONCHG    " & _
            '   "FROM JCTDEV..empmasthosh WHERE   EMPCODE='" & Session("Empcode") & "' and MonthYear='" & c & "' "

            cmd = New SqlCommand("Jct_Payroll_Salary_Slip", Obj.Connection())
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Empcode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
            cmd.Parameters.Add("@yearmonth", SqlDbType.VarChar, 10).Value = c



        End If

        '"FROM SAVIOR..EMPMAST WHERE   EMPCODE='" & Me.EMPCODE.Text & "' and MonthYear='" & (Mid(Me.DTP1.Text, 1, 2) + Mid(Me.DTP1.Text, 4, 7)) & " ' "
        '"FROM SAVIOR..EMPMAST inner join savior..deptmast on empmast.deptcode=deptmast.deptcode  and  EMPCODE='" & Me.EMPCODE.Text & "'"

        'SPLALLO, SUBTOT_SAL, ELEC_ALLOW,
        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Dr As SqlDataReader
        Dr = cmd.ExecuteReader
        If Dr.HasRows = True Then
            Panel1.Visible = True
            'Me.Panel2.Visible = True
            While Dr.Read()

                If CInt(c) < 200809 Then

                    Try
                        'Button1.Visible = True

                        'for first group
                        Month.Text = DTP2.Text
                        Year.Text = DTP3.Text
                        Me.Empname.Text = Dr.Item("EMPNAME")
                        ' Me.DEPT.Text = dr.Item("DEPTNAME")
                        'Me.Dept.Text = Dr.Item("DEPTCODE")
                        'Me.MONTH.Text = IIf(dr.Item("MONTHYEAR") Is System.DBNull.Value, "", dr.Item("MONTHYEAR"))
                        Me.Desg.Text = IIf(Dr.Item("DESG") Is System.DBNull.Value, "", Trim(Dr.Item("DESG")))

                        If Dr.Item("BANKCODE") Is System.DBNull.Value And Dr.Item("BANKNO") Is System.DBNull.Value Then
                        Else
                            'Me.BcodeNo.Text = IIf(Dr.Item("BANKCODE") Is System.DBNull.Value, " ", Trim(Dr.Item("BANKCODE"))) & IIf(Dr.Item("BANKNO") Is System.DBNull.Value, " ", Trim(Dr.Item("BANKNO")))
                            Me.BcodeNo.Text = IIf(Dr.Item("BANKNO") Is System.DBNull.Value, "", Dr.Item("BANKNO"))
                        End If
                        Me.Pan.Text = IIf(Dr.Item("PAN") Is System.DBNull.Value, "", Dr.Item("PAN"))

                        'for second group
                        'Me.Basic.Text = IIf(Dr.Item("BASIC") = 0, "", Dr.Item("BASIC"))
                        ' Me.Da.Text = Dr.Item("SPLALLO")
                        'Me.SplDa.Text = IIf(Dr.Item("STD_ADHC") = 0, "", Dr.Item("STD_ADHC"))
                        'Me.Subtotal.Text = IIf(Val(Dr.Item("BASIC")) + Val(Dr.Item("STD_ADHC")) = 0, "", Dr.Item("BASIC")) + Val(Dr.Item("STD_ADHC"))
                        ' Me.totsal.Text = IIf(Dr.Item("STD_ADHC") = 0, "", Dr.Item("STD_ADHC"))
                        Me.daysattnd.Text = Dr.Item("present")
                        Me.Pl.Text = IIf(Dr.Item("PL") = 0, "", Dr.Item("PL"))
                        Me.Cl.Text = IIf(Dr.Item("CL") = 0, "", Dr.Item("CL"))
                        Me.SL.Text = IIf(Dr.Item("SL") = 0, "", Dr.Item("SL"))
                        Me.Absent.Text = IIf(Dr.Item("absent") = 0, "", Dr.Item("absent"))
                        Me.LWP.Text = IIf(Dr.Item("LWP") = 0, "", Dr.Item("LWP"))
                        Me.PaysDays.Text = IIf(Dr.Item("PD") = 0, "", Dr.Item("PD"))

                        'for third group

                        'aslam(changed) 
                        'Me.Salary.Text = IIf(Dr.Item("SUBTOT_SAL") = 0, "", Dr.Item("SUBTOT_SAL"))
                        Me.Salary.Text = IIf(Dr.Item("Basic") = 0, "", Dr.Item("Basic"))

                        Me.FDA.Text = IIf(Dr.Item("FDA") = 0, "", Dr.Item("FDA"))

                        'aslam commented to remove
                        'Me.WBADHOC.Text = IIf(Dr.Item("ADHWB_INC") = 0, "", Dr.Item("ADHWB_INC"))

                        'aslam commented to remove
                        'Me.perallow.Text = IIf(Val(Dr.Item("SPLALLO")) + Val(Dr.Item("SPLALW_ARR")) + Val(Dr.Item("ADL_ALW")) + Val(Dr.Item("ADL_ARREAR")) = 0, "", Val(Dr.Item("SPLALLO")) + Val(Dr.Item("SPLALW_ARR")) + Val(Dr.Item("ADL_ALW")) + Val(Dr.Item("ADL_ARREAR")))

                        'aslam new
                        Me.perallow.Text = IIf(Dr.Item("STDPA") = 0, "", Dr.Item("STDPA"))


                        Me.Arrear.Text = IIf(Dr.Item("ARREAR") = 0, "", Dr.Item("ARREAR"))

                        'aslam commented to change to remove hra arrear
                        'Me.HouseRent.Text = IIf(Val(Dr.Item("HRA")) + Val(Dr.Item("HRA_ARREAR")) = 0, "", Val(Dr.Item("HRA")) + Val(Dr.Item("HRA_ARREAR")))
                        Me.HouseRent.Text = IIf(Dr.Item("HRA") = 0, "", Dr.Item("HRA"))


                        'aslam commented to remove
                        'Me.lbl2.Text = IIf(Val(Dr.Item("TRPT_ALLOW") + Val(Dr.Item("TRPT_ARR"))) = 0, "", Dr.Item("TRPT_ALLOW") + Val(Dr.Item("TRPT_ARR")))


                        Me.othallow.Text = IIf(Dr.Item("other1") = 0, "", Dr.Item("other1"))

                        'aslam commented to change only to colony allownce and ignore others
                        'Me.ColonyElec.Text = IIf(Val(Dr.Item("COLONY_ALW")) + Val(Dr.Item("OTHER2")) + Val(Dr.Item("ELEC_ALLOW")) = 0, "", Val(Dr.Item("COLONY_ALW")) + Val(Dr.Item("OTHER2")) + Val(Dr.Item("ELEC_ALLOW")))
                        Me.ColonyElec.Text = IIf(Dr.Item("COLONY_ALW") = 0, "", Dr.Item("COLONY_ALW"))


                        'aslam commented to remove
                        'Me.LblBooks.Text = IIf(Dr.Item("BP_ALW") = 0, "", Dr.Item("BP_ALW"))

                        Me.GrossSal.Text = IIf(Dr.Item("GROSS_SAL") = 0, "", Dr.Item("GROSS_SAL"))

                        'for fourth group for deduction
                        'aslam commented to change field to SAL_ADV only
                        'Me.Salary1.Text = IIf(Val(Dr.Item("SAL_ADV") + Val(Dr.Item("SADV_LOAN"))) = 0, "", Val(Dr.Item("SAL_ADV") + Val(Dr.Item("SADV_LOAN"))))
                        Me.Salary1.Text = IIf(Dr.Item("SAL_ADV") = 0, "", Dr.Item("SAL_ADV"))

                        'aslam commented to remove
                        'Me.cyclerent.Text = IIf(Dr.Item("cyc_adv") = 0, "", Dr.Item("cyc_adv"))

                        'aslam commented to change to field FurnitureAllowance
                        'Me.FurRent.Text = IIf(Dr.Item("FR_ADV") = 0, "", Dr.Item("FR_ADV"))
                        'Me.FurRent.Text = IIf(Dr.Item("FurnitureAllowance") = 0, "", Dr.Item("FurnitureAllowance"))

                        Me.BankLoan.Text = IIf(Dr.Item("BankLoan") = 0, "", Dr.Item("BankLoan"))

                        'aslam commented to remove
                        'Me.TelChrg.Text = IIf(Dr.Item("tel_ADV") = 0, "", Dr.Item("tel_ADV"))


                        'for fifth group

                        'Me.Label1.Text = Val(Dr.Item("ELECTRIC"))

                        'aslam commented to change to field TeaCrg
                        'Me.lblBusTea.Text = Val(Dr.Item("OTH_ADV")) - Val(Dr.Item("ELECTRIC"))
                        Me.lblBusTea.Text = IIf(Dr.Item("TeaCrg") = 0, "", Dr.Item("TeaCrg"))

                        'aslam commented to change to field AdvanceStaffExp 
                        'Me.ADVSTAFFEXP.Text = IIf(Val(Dr.Item("STAFFEXP")) + Val(Dr.Item("MESS_EXP")) = 0, "", Val(Dr.Item("STAFFEXP")) + Val(Dr.Item("MESS_EXP")))
                        Me.AdvanceStaffExp.Text = IIf(Dr.Item("AdvanceStaffExp") = 0, "", Dr.Item("AdvanceStaffExp"))

                        'aslam commented to remove
                        'Me.SecuriDeposit.Text = IIf(Dr.Item("SECURITY") = 0, "", Dr.Item("SECURITY"))

                        'aslam commented to remove
                        'Me.Lblclaimded.Text = IIf(Dr.Item("CLAIMDED") = 0, "", Dr.Item("CLAIMDED"))

                        'aslam commented to change to field CLUB only
                        'Me.THAPARSTAFF.Text = IIf(Dr.Item("CLUB") + Dr.Item("CLUB2") = 0, "", Dr.Item("CLUB") + Dr.Item("CLUB2"))
                        'Me.THAPARSTAFF.Text = IIf(Dr.Item("CLUB") = 0, "", Dr.Item("CLUB"))


                        'aslam commented to remove
                        'Me.ABPINST.Text = IIf(Dr.Item("COUPON") = 0, "", Dr.Item("COUPON"))

                        'aslam commented to check
                        'Me.TWCSTORE.Text = IIf(Dr.Item("LOAN_STOR") Is System.DBNull.Value, 0, Dr.Item("LOAN_STOR"))

                        'aslam commented to remove
                        'Me.Round.Text = IIf(Dr.Item("ROUNDOFF") Is System.DBNull.Value, 0, Dr.Item("ROUNDOFF"))


                        'for SIXth group
                        'PF,FPF,VPF,PFLDED,LIC,ESI,RENT_RECV,LOAN_TWCC,CTD,RD,IT,ECESS,TOT_DED,NET_SAL

                        Me.PF.Text = IIf(Dr.Item("PF") = 0, "", Dr.Item("PF"))

                        'aslam commented to remove
                        'Me.FPF.Text = IIf(Dr.Item("FPF") = 0, "", Dr.Item("FPF"))

                        Me.VPF.Text = IIf(Dr.Item("VPF") = 0, "", Dr.Item("VPF"))
                        Me.PFLoan.Text = IIf(Dr.Item("PFLDED") = 0, "", Dr.Item("PFLDED"))

                        'aslam commented to change to field TATA_AIG only
                        'Me.LIC.Text = IIf(Val(Dr.Item("LIC")) + Val(Dr.Item("TATA_AIG")) = 0, "", Val(Dr.Item("LIC")) + Val(Dr.Item("TATA_AIG")))
                        Me.LIC.Text = IIf(Dr.Item("TATA_AIG") = 0, "", Dr.Item("TATA_AIG"))

                        Me.ESI.Text = IIf(Dr.Item("ESI") = 0, "", Dr.Item("ESI"))
                        Me.RentRece.Text = IIf(Dr.Item("RENT_RECV") = 0, "", Dr.Item("RENT_RECV"))
                        Me.TWCCSOCIETY.Text = IIf(Dr.Item("LOAN_TWCC") = 0, "", Dr.Item("LOAN_TWCC"))
                        Me.ProfessionalTax.Text = IIf(Dr.Item("ProfessionalTax") = 0, "", Dr.Item("ProfessionalTax"))

                        'aslam commented to remove
                        'Me.CTDRD.Text = IIf(Val(Dr.Item("CTD")) + Val(Dr.Item("RD")) + Val(Dr.Item("ABP_RD")) = 0, "", Val(Dr.Item("CTD")) + Val(Dr.Item("RD")) + Val(Dr.Item("ABP_RD")))

                        'aslam commented to change to field it only
                        'Me.IncomeTax.Text = IIf(Val(Dr.Item("IT")) + Val(Dr.Item("ECESS")) + Val(Dr.Item("SH_ECESS")) = 0, "", Val(Dr.Item("IT")) + Val(Dr.Item("ECESS")) + Val(Dr.Item("SH_ECESS")))
                        Me.IncomeTax.Text = IIf(Dr.Item("IT") = 0, "", Dr.Item("IT"))

                        'aslam commented to change to field OTHER3 only
                        'Me.OTH.Text = IIf(Val(Dr.Item("OTHER3")) + Val(Dr.Item("OTHER4")) + Val(Dr.Item("PB_WELFARE")) = 0, "", Val(Dr.Item("OTHER3")) + Val(Dr.Item("OTHER4")) + Val(Dr.Item("PB_WELFARE")))
                        Me.OTH.Text = IIf(Dr.Item("OTHER3") = 0, "", Dr.Item("OTHER3"))

                        'IT,ECESS,SH_ECESS,OTHERS3,OTHERS4,PB_WELFARE,
                        Me.totaldeductions.Text = IIf(Dr.Item("TOT_DED") = 0, "", Dr.Item("TOT_DED"))
                        Me.NetSalary.Text = Dr.Item("NET_SAL")
                        Me.display.Visible = False


                        'new fields
                        Me.VehicleCrg.Text = IIf(Dr.Item("VehicalStandCrg") = 0, "", Dr.Item("VehicalStandCrg"))
                        Me.electric.Text = IIf(Dr.Item("ELECTRIC") = 0, "", Dr.Item("ELECTRIC"))
                        Me.Messexpense.Text = IIf(Dr.Item("MESS_EXP") = 0, "", Dr.Item("MESS_EXP"))
                        Me.Medicine.Text = IIf(Dr.Item("MedicineCrg") = 0, "", Dr.Item("MedicineCrg"))
                        Me.Clubcrg.Text = IIf(Dr.Item("CLUB") = 0, "", Dr.Item("CLUB"))
                        Me.Internet.Text = IIf(Dr.Item("NET_RENT") = 0, "", Dr.Item("NET_RENT"))
                        Me.MedicalInsurance.Text = IIf(Dr.Item("GroupMedicalInsurnance") = 0, "", Dr.Item("GroupMedicalInsurnance"))
                        Me.LabourWelfare.Text = IIf(Dr.Item("LabourWelfareFund") = 0, "", Dr.Item("LabourWelfareFund"))


                    Catch ex As Exception

                    End Try


                Else



                    Try
                        'Button1.Visible = True

                        'for first group
                        Month.Text = DTP2.Text
                        Year.Text = DTP3.Text
                        Me.Empname.Text = Dr.Item("EMPNAME")


                        ' Me.DEPT.Text = dr.Item("DEPTNAME")
                        'Me.Dept.Text = Dr.Item("DEPTCODE")
                        'Me.MONTH.Text = IIf(dr.Item("MONTHYEAR") Is System.DBNull.Value, "", dr.Item("MONTHYEAR"))
                        Me.Desg.Text = IIf(Dr.Item("DESG") Is System.DBNull.Value, "", Trim(Dr.Item("DESG")))

                        If Dr.Item("BANKCODE") Is System.DBNull.Value And Dr.Item("BANKNO") Is System.DBNull.Value Then
                        Else
                            'Me.BcodeNo.Text = IIf(Dr.Item("BANKCODE") Is System.DBNull.Value, " ", Trim(Dr.Item("BANKCODE"))) & IIf(Dr.Item("BANKNO") Is System.DBNull.Value, " ", Trim(Dr.Item("BANKNO")))
                            Me.BcodeNo.Text = IIf(Dr.Item("BANKNO") Is System.DBNull.Value, "", Dr.Item("BANKNO"))
                        End If
                        Me.Pan.Text = IIf(Dr.Item("PAN") Is System.DBNull.Value, "", Dr.Item("PAN"))

                        'for second group
                        'Me.Basic.Text = IIf(Dr.Item("BASIC") = 0, "", Dr.Item("BASIC"))
                        ' Me.Da.Text = Dr.Item("SPLALLO")
                        'Me.SplDa.Text = IIf(Dr.Item("STD_ADHC") = 0, "", Dr.Item("STD_ADHC"))
                        'Me.Subtotal.Text = IIf(Val(Dr.Item("BASIC")) + Val(Dr.Item("STD_ADHC")) = 0, "", Dr.Item("BASIC")) + Val(Dr.Item("STD_ADHC"))
                        ' Me.totsal.Text = IIf(Dr.Item("STD_ADHC") = 0, "", Dr.Item("STD_ADHC"))
                        Me.daysattnd.Text = Dr.Item("present")
                        Me.Pl.Text = IIf(Dr.Item("PL") = 0, "", Dr.Item("PL"))
                        Me.Cl.Text = IIf(Dr.Item("CL") = 0, "", Dr.Item("CL"))
                        Me.SL.Text = IIf(Dr.Item("SL") = 0, "", Dr.Item("SL"))
                        Me.Absent.Text = IIf(Dr.Item("absent") = 0, "", Dr.Item("absent"))
                        Me.LWP.Text = IIf(Dr.Item("LWP") = 0, "", Dr.Item("LWP"))
                        Me.PaysDays.Text = IIf(Dr.Item("PD") = 0, "", Dr.Item("PD"))

                        'for third group

                        'aslam(changed) 
                        'Me.Salary.Text = IIf(Dr.Item("SUBTOT_SAL") = 0, "", Dr.Item("SUBTOT_SAL"))
                        Me.Salary.Text = IIf(Dr.Item("Basic") = 0, "", Dr.Item("Basic"))

                        Me.FDA.Text = IIf(Dr.Item("FDA") = 0, "", Dr.Item("FDA"))

                        'aslam commented to remove
                        'Me.WBADHOC.Text = IIf(Dr.Item("ADHWB_INC") = 0, "", Dr.Item("ADHWB_INC"))

                        'aslam commented to remove
                        'Me.perallow.Text = IIf(Val(Dr.Item("SPLALLO")) + Val(Dr.Item("SPLALW_ARR")) + Val(Dr.Item("ADL_ALW")) + Val(Dr.Item("ADL_ARREAR")) = 0, "", Val(Dr.Item("SPLALLO")) + Val(Dr.Item("SPLALW_ARR")) + Val(Dr.Item("ADL_ALW")) + Val(Dr.Item("ADL_ARREAR")))

                        'aslam new
                        Me.perallow.Text = IIf(Dr.Item("STDPA") = 0, "", Dr.Item("STDPA"))


                        'aslam commented to change pa to uniform allowance
                        'Me.Uniform.Text = IIf(Val(Dr.Item("PA")) + Val(Dr.Item("PA_ARREAR")) = 0, "", Val(Dr.Item("PA")) + Val(Dr.Item("PA_ARREAR")))
                        Me.Uniform.Text = IIf(Dr.Item("UniformAllowance") = 0, "", Dr.Item("UniformAllowance"))

                        Me.Arrear.Text = IIf(Dr.Item("ARREAR") = 0, "", Dr.Item("ARREAR"))

                        'aslam commented to change to remove hra arrear
                        'Me.HouseRent.Text = IIf(Val(Dr.Item("HRA")) + Val(Dr.Item("HRA_ARREAR")) = 0, "", Val(Dr.Item("HRA")) + Val(Dr.Item("HRA_ARREAR")))
                        Me.HouseRent.Text = IIf(Dr.Item("HRA") = 0, "", Dr.Item("HRA"))

                        'aslam commented to remove
                        'Me.lbl2.Text = IIf(Val(Dr.Item("TRPT_ALLOW") + Val(Dr.Item("TRPT_ARR"))) = 0, "", Dr.Item("TRPT_ALLOW") + Val(Dr.Item("TRPT_ARR")))

                        Me.othallow.Text = IIf(Dr.Item("other1") = 0, "", Dr.Item("other1"))

                        'aslam commented to change only to colony allownce and ignore others
                        'Me.ColonyElec.Text = IIf(Val(Dr.Item("COLONY_ALW")) + Val(Dr.Item("OTHER2")) + Val(Dr.Item("ELEC_ALLOW")) = 0, "", Val(Dr.Item("COLONY_ALW")) + Val(Dr.Item("OTHER2")) + Val(Dr.Item("ELEC_ALLOW")))
                        Me.ColonyElec.Text = IIf(Dr.Item("COLONY_ALW") = 0, "", Dr.Item("COLONY_ALW"))

                        'aslam commented to change field to LTAAllowance
                        'Me.LTAMED.Text = IIf(Dr.Item("ALW_2010") = 0, "", Dr.Item("ALW_2010"))
                        Me.LTAMED.Text = IIf(Dr.Item("LTAAllowance") = 0, "", Dr.Item("LTAAllowance"))

                        'aslam commented to remove
                        'Me.LblBooks.Text = IIf(Dr.Item("BP_ALW") = 0, "", Dr.Item("BP_ALW"))

                        Me.GrossSal.Text = IIf(Dr.Item("GROSS_SAL") = 0, "", Dr.Item("GROSS_SAL"))


                        'for fourth group for deduction
                        'aslam commented to change field to SAL_ADV only
                        'Me.Salary1.Text = IIf(Val(Dr.Item("SAL_ADV") + Val(Dr.Item("SADV_LOAN"))) = 0, "", Val(Dr.Item("SAL_ADV") + Val(Dr.Item("SADV_LOAN"))))
                        Me.Salary1.Text = IIf(Dr.Item("SAL_ADV") = 0, "", Dr.Item("SAL_ADV"))


                        'aslam commented to remove
                        'Me.cyclerent.Text = IIf(Dr.Item("cyc_adv") = 0, "", Dr.Item("cyc_adv"))

                        Me.AdvanceStaffExp.Text = IIf(Dr.Item("AdvanceStaffExp") = 0, "", Dr.Item("AdvanceStaffExp"))

                        'aslam commented to change to field FurnitureAllowance
                        'Me.FurRent.Text = IIf(Dr.Item("FR_ADV") = 0, "", Dr.Item("FR_ADV"))
                        'Me.FurRent.Text = IIf(Dr.Item("FurnitureAllowance") = 0, "", Dr.Item("FurnitureAllowance"))
                        Me.BankLoan.Text = IIf(Dr.Item("BankLoan") = 0, "", Dr.Item("BankLoan"))

                        'aslam new 
                        Me.FurRentallw.Text = IIf(Dr.Item("FurnitureAllowance") = 0, "", Dr.Item("FurnitureAllowance"))


                        'aslam commented to remove
                        'Me.TelChrg.Text = IIf(Dr.Item("tel_ADV") = 0, "", Dr.Item("tel_ADV"))


                        'for fifth group
                        'Me.Label1.Text = Val(Dr.Item("ELECTRIC"))

                        'aslam commented to change to field TeaCrg
                        'Me.lblBusTea.Text = Val(Dr.Item("OTH_ADV")) - Val(Dr.Item("ELECTRIC"))
                        Me.lblBusTea.Text = IIf(Dr.Item("TeaCrg") = 0, "", Dr.Item("TeaCrg"))


                        'aslam commented to change to field AdvanceStaffExp 
                        'Me.ADVSTAFFEXP.Text = IIf(Val(Dr.Item("STAFFEXP")) + Val(Dr.Item("MESS_EXP")) = 0, "", Val(Dr.Item("STAFFEXP")) + Val(Dr.Item("MESS_EXP")))
                        Me.AdvanceStaffExp.Text = IIf(Dr.Item("AdvanceStaffExp") = 0, "", Dr.Item("AdvanceStaffExp"))


                        'aslam commented to remove
                        'Me.SecuriDeposit.Text = IIf(Dr.Item("SECURITY") = 0, "", Dr.Item("SECURITY"))


                        'aslam commented to change to field CLUB only
                        'Me.THAPARSTAFF.Text = IIf(Dr.Item("CLUB") + Dr.Item("CLUB2") = 0, "", Dr.Item("CLUB") + Dr.Item("CLUB2"))
                        'Me.THAPARSTAFF.Text = IIf(Dr.Item("CLUB") = 0, "", Dr.Item("CLUB"))

                        'aslam commented to remove
                        'Me.ABPINST.Text = IIf(Dr.Item("COUPON") = 0, "", Dr.Item("COUPON"))

                        'aslam commented to check
                        'Me.TWCSTORE.Text = IIf(Dr.Item("LOAN_STOR") Is System.DBNull.Value, 0, Dr.Item("LOAN_STOR"))

                        'aslam commented to remove
                        'Me.Round.Text = IIf(Dr.Item("ROUNDOFF") Is System.DBNull.Value, 0, Dr.Item("ROUNDOFF"))

                        'aslam commented to check
                        'Me.LblIntConChr.text = IIf(Dr.Item("NET_CONCHG") = 0, "", Dr.Item("NET_CONCHG"))


                        'Me.LblIntRent.Text = IIf(Dr.Item("NET_RENT") = 0, "", Dr.Item("NET_RENT"))

                        'aslam commented to remove
                        'Me.Lblclaimded.Text = IIf(Dr.Item("CLAIMDED") Is System.DBNull.Value, 0, Dr.Item("CLAIMDED"))

                        'for SIXth group
                        'PF,FPF,VPF,PFLDED,LIC,ESI,RENT_RECV,LOAN_TWCC,CTD,RD,IT,ECESS,TOT_DED,NET_SAL
                        Me.PF.Text = IIf(Dr.Item("PF") = 0, "", Dr.Item("PF"))

                        'aslam commented to remove
                        'Me.FPF.Text = IIf(Dr.Item("FPF") = 0, "", Dr.Item("FPF"))

                        Me.VPF.Text = IIf(Dr.Item("VPF") = 0, "", Dr.Item("VPF"))
                        Me.PFLoan.Text = IIf(Dr.Item("PFLDED") = 0, "", Dr.Item("PFLDED"))

                        'aslam commented to change to field TATA_AIG only
                        'Me.LIC.Text = IIf(Val(Dr.Item("LIC")) + Val(Dr.Item("TATA_AIG")) = 0, "", Val(Dr.Item("LIC")) + Val(Dr.Item("TATA_AIG")))
                        Me.LIC.Text = IIf(Dr.Item("TATA_AIG") = 0, "", Dr.Item("TATA_AIG"))

                        Me.ESI.Text = IIf(Dr.Item("ESI") = 0, "", Dr.Item("ESI"))
                        Me.RentRece.Text = IIf(Dr.Item("RENT_RECV") = 0, "", Dr.Item("RENT_RECV"))
                        Me.TWCCSOCIETY.Text = IIf(Dr.Item("LOAN_TWCC") = 0, "", Dr.Item("LOAN_TWCC"))

                        Me.ProfessionalTax.Text = IIf(Dr.Item("ProfessionalTax") = 0, "", Dr.Item("ProfessionalTax"))

                        'aslam commented to remove
                        'Me.CTDRD.Text = IIf(Val(Dr.Item("CTD")) + Val(Dr.Item("RD")) + Val(Dr.Item("ABP_RD")) = 0, "", Val(Dr.Item("CTD")) + Val(Dr.Item("RD")) + Val(Dr.Item("ABP_RD")))

                        'aslam commented to change to field it only
                        'Me.IncomeTax.Text = IIf(Val(Dr.Item("IT")) + Val(Dr.Item("ECESS")) + Val(Dr.Item("SH_ECESS")) = 0, "", Val(Dr.Item("IT")) + Val(Dr.Item("ECESS")) + Val(Dr.Item("SH_ECESS")))
                        Me.IncomeTax.Text = IIf(Dr.Item("IT") = 0, "", Dr.Item("IT"))

                        'aslam commented to change to field OTHER3 only
                        'Me.OTH.Text = IIf(Val(Dr.Item("OTHER3")) + Val(Dr.Item("OTHER4")) + Val(Dr.Item("PB_WELFARE")) = 0, "", Val(Dr.Item("OTHER3")) + Val(Dr.Item("OTHER4")) + Val(Dr.Item("PB_WELFARE")))
                        Me.OTH.Text = IIf(Dr.Item("OTHER3") = 0, "", Dr.Item("OTHER3"))

                        'IT,ECESS,SH_ECESS,OTHERS3,OTHERS4,PB_WELFARE,
                        Me.totaldeductions.Text = IIf(Dr.Item("TOT_DED") = 0, "", Dr.Item("TOT_DED"))
                        Me.NetSalary.Text = Dr.Item("NET_SAL")
                        Me.display.Visible = False


                        'new fields
                        Me.VehicleCrg.Text = IIf(Dr.Item("VehicalStandCrg") = 0, "", Dr.Item("VehicalStandCrg"))
                        Me.electric.Text = IIf(Dr.Item("ELECTRIC") = 0, "", Dr.Item("ELECTRIC"))
                        Me.Messexpense.Text = IIf(Dr.Item("MESS_EXP") = 0, "", Dr.Item("MESS_EXP"))
                        Me.Medicine.Text = IIf(Dr.Item("MedicineCrg") = 0, "", Dr.Item("MedicineCrg"))
                        Me.Clubcrg.Text = IIf(Dr.Item("CLUB") = 0, "", Dr.Item("CLUB"))
                        Me.Internet.Text = IIf(Dr.Item("NET_RENT") = 0, "", Dr.Item("NET_RENT"))
                        Me.MedicalInsurance.Text = IIf(Dr.Item("GroupMedicalInsurnance") = 0, "", Dr.Item("GroupMedicalInsurnance"))
                        Me.LabourWelfare.Text = IIf(Dr.Item("LabourWelfareFund") = 0, "", Dr.Item("LabourWelfareFund"))

                    Catch ex As Exception

                    End Try
                End If
            End While
        Else
            Me.display.Visible = True
            Me.Panel1.Visible = False
            'Me.Panel2.Visible = False

            Me.display.Visible = True
            Me.display.Text = "*"
            Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('Record Not Found')</script>")
        End If
        Dr.Close()
        'End If



    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")



        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not Page.IsPostBack Then

            Timer1.Enabled = True

            '-----------Select Year and Month-------------------

            Obj.ConOpen()

            SqlPass = "select distinct max(monthyear),left(max(monthyear),4),datename(month,dateadd(month, convert(int,right(max(monthyear),2)) - 1, 0)) from empmast "
            cmd = New SqlCommand(SqlPass, Obj.Connection)
            dr = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                Me.DTP2.SelectedValue = dr(2)
                DTP3.Text = dr.Item(1)
            End If
            dr.Close()

            Obj.ConClose()

            '---------End Select Year and Month-----------------





            'DTP3.Text = Now.Year.ToString
            'DTP3.Text = "2011"
            DTP2_SelectedIndexChanged(sender, e)
        End If

        ' Me.Panel1.Visible = False
        '  Me.Panel2.Visible = False
        'Me.display.Visible = False
        'Me.Button1.Attributes.Add("onclick", "window.print();")
        'Me.ImageButton1.Attributes.Add("onclick", "JavaScript:printPartOfPage('print_area');")
        'onclick = "JavaScript:printPartOfPage('print_area');"
    End Sub
    Protected Sub DTP3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTP3.SelectedIndexChanged
        DTP2_SelectedIndexChanged(e, e)
    End Sub
    Public Sub BindData()
        Dim SqlPass = "select * from production..user_module_menus_mapping where mnuname='Salary Slip' and action='print' and uname='" & Session("Empcode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr.HasRows = True Then
            Panel3.Visible = True
        Else
            Panel3.Visible = False
        End If
        Dr.Close()
        Obj.ConClose()
    End Sub



    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
    End Sub
End Class



