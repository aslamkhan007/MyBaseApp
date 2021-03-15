Imports System.Data
Imports System.Data.SqlClient
Imports vb = Microsoft.VisualBasic

Partial Class PF
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Public SqlPass As String, CurYear As String
    Public D As Date, LoanDate As Date
    Public LoanMonth, LoanYear As Long
    Public Rate As Double
    Public Exist As Boolean = False



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not (Page.IsPostBack) Then

            'SqlPass = "Select 'X' from production..user_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname left outer join jctdev..JCT_Menu_Form_Mapping c on b.mnuname=c.mnuname where a.module ='employee gateway' and uname='" & Session("Empcode") & "' and page_name='~/'" & " union select 'X' from production..role_module_menus_mapping a inner join production..modules_menu_master b on a.module=b.module and a.mnuname=b.mnuname inner join production..role_user_mapping e on a.role=e.role left outer join jctdev..JCT_Menu_Form_Mapping c on b.mnuname=c.mnuname  where a.module ='employee gateway' and uname='" & Trim(Session("Empcode")) & "' and page_name='~/pf.aspx'"
            'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
            'If Dr.HasRows = False Then
            '    Response.Redirect("Login.aspx")
            'End If
            'Dr.Close()
            'Obj.ConClose()

            CheckYear()
            IntRate()
            CheckLoan()
            OpeBal()
            BindData()

        End If

    End Sub
    Public Sub CheckYear()
        D = Now()

        'D = "03/31/2009"
        If (D.Month <= 12 And D.Month >= 4) Then

            Apr.Text += " " & Mid(D.Year, 3, 4)
            May.Text += " " & Mid(D.Year, 3, 4)
            Jun.Text += " " & Mid(D.Year, 3, 4)
            Jul.Text += " " & Mid(D.Year, 3, 4)
            Aug.Text += " " & Mid(D.Year, 3, 4)
            Sep.Text += " " & Mid(D.Year, 3, 4)
            Oct.Text += " " & Mid(D.Year, 3, 4)
            Nov.Text += " " & Mid(D.Year, 3, 4)
            Dec.Text += " " & Mid(D.Year, 3, 4)
            Jan.Text += " " & "0" & Mid(D.Year, 3, 4) + 1
            Feb.Text += " " & "0" & Mid(D.Year, 3, 4) + 1
            Mar.Text += " " & "0" & Mid(D.Year, 3, 4) + 1

        ElseIf D.Month <= 3 Then
            Apr.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            May.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Jun.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Jul.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Aug.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Sep.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Oct.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Nov.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Dec.Text += " " & "0" & Mid(D.Year, 3, 4) - 1
            Jan.Text += " " & Mid(D.Year, 3, 4)
            Feb.Text += " " & Mid(D.Year, 3, 4)
            Mar.Text += " " & Mid(D.Year, 3, 4)
        End If

    End Sub
    Public Sub BindData()
        'JCTDEV..nrefln c
        '        Dim SqlPass = "select a.*,b.* from JCTDEV..pfm2008 a,JCTDEV..pfstaff B where a.Empcode=b.EMPCODE   and a.Empcode='" & Session("Empcode") & "' "
        Dim SqlPass = "select * from JCTDEV..pfstaff where Empcode='" & Session("Empcode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()

                    'Me.FinalFPOBal.Text = Dr.Item("FPEAMT")
                    ''---Me.FPFMonth.Text = Dr.Item("EPSAPR") + Dr.Item("EPSMAY") + Dr.Item("EPSJUN") + Dr.Item("EPSJUL") + Dr.Item("EPSAUG") + Dr.Item("EPSSEP") + Dr.Item("EPSOCT") + Dr.Item("EPSNOV") + Dr.Item("EPSDEC") + Dr.Item("EPSJAN") + Dr.Item("EPSFEB") + Dr.Item("EPSMAR2")
                    Me.FPFMonth.Text = IIf(Dr.Item("EPSAPR") Is System.DBNull.Value, "0", Dr.Item("EPSAPR")) + IIf(Dr.Item("EPSMAY") Is System.DBNull.Value, "0", Dr.Item("EPSMAY")) + IIf(Dr.Item("EPSJUN") Is System.DBNull.Value, "0", Dr.Item("EPSJUN")) + IIf(Dr.Item("EPSJUL") Is System.DBNull.Value, "0", Dr.Item("EPSJUL")) + IIf(Dr.Item("EPSAUG") Is System.DBNull.Value, "0", Dr.Item("EPSAUG")) + IIf(Dr.Item("EPSSEP") Is System.DBNull.Value, "0", Dr.Item("EPSSEP")) + IIf(Dr.Item("EPSOCT") Is System.DBNull.Value, "0", Dr.Item("EPSOCT")) + IIf(Dr.Item("EPSNOV") Is System.DBNull.Value, "0", Dr.Item("EPSNOV")) + IIf(Dr.Item("EPSDEC") Is System.DBNull.Value, "0", Dr.Item("EPSDEC")) + IIf(Dr.Item("EPSJAN") Is System.DBNull.Value, "0", Dr.Item("EPSJAN")) + IIf(Dr.Item("EPSFEB") Is System.DBNull.Value, "0", Dr.Item("EPSFEB")) + IIf(Dr.Item("EPSMAR2") Is System.DBNull.Value, "0", Dr.Item("EPSMAR2"))
                    Me.FinalFPF.Text = Val(Me.FinalFPOBal.Text) + Val(Me.FPFMonth.Text)
                    ''-----------------------------------------------------------------------------
                    '' Header
                    ''-----------------------------------------------------------------------------
                    'Me.EmpName.Text = Dr.Item("EMPNAME")
                    'Me.FatName.Text = Dr.Item("FTHNAME")
                    'If Dr.Item("PFJDT") Is System.DBNull.Value Then
                    'Else
                    '    Me.TxtDojs.Text = Dr.Item("PFJDT")
                    '    Me.TxtDojp.Text = Dr.Item("PFJDT")
                    'End If

                    'If Dr.Item("SRJDT") Is System.DBNull.Value Then
                    'Else
                    '    Me.TxtDojs.Text = Dr.Item("SRJDT")
                    'End If



                    'If Dr.Item("NOMNM") Is System.DBNull.Value Then
                    'Else
                    '    Me.TxtNominee.Text = Dr.Item("NOMNM")
                    'End If
                    'Me.TxtPfVpfNo.Text = Dr.Item("PFNO") & "/" & Dr.Item("FPFNO")
                    ''-----------------------------------------------------------------------------
                    '' Opening Balance
                    ''-----------------------------------------------------------------------------
                    ''PF Contribution
                    'Me.ConOwnOBal.Text = Math.Round(Dr.Item("PFOAMT"), 2)
                    'Me.ConEmpOBal.Text = Math.Round(Dr.Item("PFEAMT"), 2)
                    ''PF Intrest
                    'Me.IntOwnObal.Text = Math.Round(Dr.Item("PFOINT"), 2)
                    'Me.IntEmpOBal.Text = Math.Round(Dr.Item("PFEINT"), 2)
                    ''PF VPF Intrest
                    'Me.VpfOwnOBal.Text = Math.Round(Dr.Item("VPFAMT"), 2)
                    'Me.VpfEmpOBal.Text = Math.Round(Dr.Item("VPFINT"), 2)

                    'Me.VpfOBal.Text = Math.Round(Dr.Item("VPFAMT")) + Math.Round(Dr.Item("VPFINT"), 2)

                    'Me.AmtOwnOBal.Text = Math.Round(Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text), 2)
                    'Me.AmtEmpOBal.Text = Math.Round(Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text), 2)
                    '-----------------------------------------------------------------------------

                    ' Check For 12 Month April To March
                    '-----------------------------------------------------------------------------




                    If Dr.Item("PFAPR") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Dr.Item("PFAPR")

                        'PF Intrest Own
                        Me.ConEmpApril.Text = Dr.Item("PFRAPR")

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Dr.Item("VPFAPR")


                        If LoanMonth = 4 And Exist = True Then
                            Me.IntOwnApril.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpApril.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpApril.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            'Pricipal Amount

                            Me.AmtOwnApril.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR"), 2)
                            Me.AmtEmpApril.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR"), 2)
                        Else
                            Me.IntOwnApril.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) * Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpApril.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) * Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpApril.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            'Pricipal Amount
                            Me.AmtOwnApril.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR"), 2)
                            Me.AmtEmpApril.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR"), 2)
                        End If
                    End If

                    Me.VpfApril.Text = Math.Round(Val(Me.VpfOwnApril.Text) + Val(Me.VpfEmpApril.Text), 2)
                    '-----------------------------------------------------------------------------


                    If Dr.Item("PFMAY") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))

                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))

                        If LoanMonth <= 5 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnMay.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpMay.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpMay.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnMay.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY"), 2)
                            Me.AmtEmpMay.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY"), 2)
                        Else
                            Me.IntOwnMay.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpMay.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpMay.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnMay.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY"), 2)
                            Me.AmtEmpMay.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY"), 2)
                        End If

                        Me.VpfMay.Text = Math.Round(Val(Me.VpfOwnMay.Text) + Val(Me.VpfEmpMay.Text), 2)
                    End If

                    '-----------------------------------------------------------------------------


                    If Dr.Item("PFJUN") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))

                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))


                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))


                        If LoanMonth <= 6 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnJune.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpJune.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpJune.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnJune.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN"), 2)
                            Me.AmtEmpJune.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN"), 2)

                        Else
                            Me.IntOwnJune.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpJune.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpJune.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnJune.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN"), 2)
                            Me.AmtEmpJune.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN"), 2)

                        End If
                        Me.VpfJune.Text = Math.Round(Val(Me.VpfOwnJune.Text) + Val(Me.VpfEmpJune.Text), 2)

                    End If




                    If Dr.Item("PFJUL") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))

                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))

                        If LoanMonth <= 7 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnJuly.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpJuly.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpJuly.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnJuly.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL"), 2)
                            Me.AmtEmpJuly.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL"), 2)
                        Else
                            Me.IntOwnJuly.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpJuly.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpJuly.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnJuly.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL"), 2)
                            Me.AmtEmpJuly.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL"), 2)
                        End If


                        Me.VpfJuly.Text = Math.Round(Val(Me.VpfOwnJuly.Text) + Val(Me.VpfEmpJuly.Text), 2)
                    End If


                    If Dr.Item("PFAUG") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))

                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))


                        If LoanMonth <= 8 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnAug.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpAug.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpAug.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnAug.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG"), 2)
                            Me.AmtEmpAug.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG"), 2)
                        Else
                            Me.IntOwnAug.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpAug.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpAug.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnAug.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG"), 2)
                            Me.AmtEmpAug.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG"), 2)
                        End If


                        Me.VpfAug.Text = Math.Round(Val(Me.VpfOwnAug.Text) + Val(Me.VpfEmpAug.Text), 2)
                    End If



                    If Dr.Item("PFSEP") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))

                        If LoanMonth <= 9 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnSep.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpSep.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpSep.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnSep.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP"), 2)
                            Me.AmtEmpSep.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP"), 2)
                        Else
                            Me.IntOwnSep.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpSep.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpSep.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnSep.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP"), 2)
                            Me.AmtEmpSep.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP"), 2)
                        End If

                        Me.VpfSep.Text = Math.Round(Val(Me.VpfOwnSep.Text) + Val(Me.VpfEmpSep.Text), 2)
                    End If




                    If Dr.Item("PFOCT") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        Me.ConOwnOct.Text = Math.Round(Dr.Item("PFOCT"))

                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        Me.ConEmpOct.Text = Math.Round(Dr.Item("PFROCT"))

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))
                        Me.VpfOwnOct.Text = Math.Round(Dr.Item("VPFOCT"))


                        If LoanMonth <= 10 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnOct.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpOct.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpOct.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnOct.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT"), 2)
                            Me.AmtEmpOct.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT"), 2)
                        Else
                            Me.IntOwnOct.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpOct.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpOct.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnOct.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT"), 2)
                            Me.AmtEmpOct.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT"), 2)
                        End If

                        Me.VpfOct.Text = Math.Round(Val(Me.VpfOwnOct.Text) + Val(Me.VpfEmpOct.Text), 2)
                    End If


                    If Dr.Item("PFNOV") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        Me.ConOwnOct.Text = Math.Round(Dr.Item("PFOCT"))
                        Me.ConOwnNov.Text = Math.Round(Dr.Item("PFNOV"))
                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        Me.ConEmpOct.Text = Math.Round(Dr.Item("PFROCT"))
                        Me.ConEmpNov.Text = Math.Round(Dr.Item("PFRNOV"))
                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))
                        Me.VpfOwnOct.Text = Math.Round(Dr.Item("VPFOCT"))
                        Me.VpfOwnNov.Text = Math.Round(Dr.Item("VPFNOV"))

                        If LoanMonth <= 11 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnNov.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpNov.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpNov.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnNov.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV"), 2)
                            Me.AmtEmpNov.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV"), 2)
                        Else
                            Me.IntOwnNov.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpNov.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpNov.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnNov.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV"), 2)
                            Me.AmtEmpNov.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV"), 2)
                        End If

                        Me.VpfNov.Text = Math.Round(Val(Me.VpfOwnNov.Text) + Val(Me.VpfEmpNov.Text), 2)
                    End If


                    If Dr.Item("PFDEC") > 0 Then
                        'PF Contribution Own
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        Me.ConOwnOct.Text = Math.Round(Dr.Item("PFOCT"))
                        Me.ConOwnNov.Text = Math.Round(Dr.Item("PFNOV"))
                        Me.ConOwnDec.Text = Math.Round(Dr.Item("PFDEC"))


                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        Me.ConEmpOct.Text = Math.Round(Dr.Item("PFROCT"))
                        Me.ConEmpNov.Text = Math.Round(Dr.Item("PFRNOV"))
                        Me.ConEmpDec.Text = Math.Round(Dr.Item("PFRDEC"))



                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))
                        Me.VpfOwnOct.Text = Math.Round(Dr.Item("VPFOCT"))
                        Me.VpfOwnNov.Text = Math.Round(Dr.Item("VPFNOV"))
                        Me.VpfOwnDec.Text = Math.Round(Dr.Item("VPFDEC"))

                        If LoanMonth <= 12 And LoanMonth >= 4 And Exist = True Then
                            Me.IntOwnDec.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpDec.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpDec.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnDec.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC"), 2)
                            Me.AmtEmpDec.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC"), 2)
                        Else
                            Me.IntOwnDec.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpDec.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpDec.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnDec.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC"), 2)
                            Me.AmtEmpDec.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC"), 2)
                        End If

                        Me.VpfDec.Text = Math.Round(Val(Me.VpfOwnDec.Text) + Val(Me.VpfEmpDec.Text), 2)
                    End If

                    If Dr.Item("PFJAN") > 0 Then
                        'PF Contribution Own
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        Me.ConOwnOct.Text = Math.Round(Dr.Item("PFOCT"))
                        Me.ConOwnNov.Text = Math.Round(Dr.Item("PFNOV"))
                        Me.ConOwnDec.Text = Math.Round(Dr.Item("PFDEC"))
                        Me.ConOwnJan.Text = Math.Round(Dr.Item("PFJAN"))

                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        Me.ConEmpOct.Text = Math.Round(Dr.Item("PFROCT"))
                        Me.ConEmpNov.Text = Math.Round(Dr.Item("PFRNOV"))
                        Me.ConEmpDec.Text = Math.Round(Dr.Item("PFRDEC"))
                        Me.ConEmpJan.Text = Math.Round(Dr.Item("PFRJAN"))

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))
                        Me.VpfOwnOct.Text = Math.Round(Dr.Item("VPFOCT"))
                        Me.VpfOwnNov.Text = Math.Round(Dr.Item("VPFNOV"))
                        Me.VpfOwnDec.Text = Math.Round(Dr.Item("VPFDEC"))
                        Me.VpfOwnJan.Text = Math.Round(Dr.Item("VPFJAN"))

                        If (LoanMonth <= 12 And LoanMonth >= 4 Or LoanMonth = 1) And Exist = True Then
                            Me.IntOwnJan.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpJan.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpJan.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV") + Dr.Item("VPFDEC"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnJan.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN"), 2)
                            Me.AmtEmpJan.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN"), 2)
                        Else
                            Me.IntOwnJan.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpJan.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpJan.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV") + Dr.Item("VPFDEC")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnJan.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN"), 2)
                            Me.AmtEmpJan.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN"), 2)
                        End If

                        Me.VpfJan.Text = Math.Round(Val(Me.VpfOwnJan.Text) + Val(Me.VpfEmpJan.Text), 2)
                    End If



                    If Dr.Item("PFFEB") > 0 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        Me.ConOwnOct.Text = Math.Round(Dr.Item("PFOCT"))
                        Me.ConOwnNov.Text = Math.Round(Dr.Item("PFNOV"))
                        Me.ConOwnDec.Text = Math.Round(Dr.Item("PFDEC"))
                        Me.ConOwnJan.Text = Math.Round(Dr.Item("PFJAN"))
                        Me.ConOwnFeb.Text = Math.Round(Dr.Item("PFFEB"))


                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        Me.ConEmpOct.Text = Math.Round(Dr.Item("PFROCT"))
                        Me.ConEmpNov.Text = Math.Round(Dr.Item("PFRNOV"))
                        Me.ConEmpDec.Text = Math.Round(Dr.Item("PFRDEC"))
                        Me.ConEmpJan.Text = Math.Round(Dr.Item("PFRJAN"))
                        Me.ConEmpFeb.Text = Math.Round(Dr.Item("PFRFEB"))


                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))
                        Me.VpfOwnOct.Text = Math.Round(Dr.Item("VPFOCT"))
                        Me.VpfOwnNov.Text = Math.Round(Dr.Item("VPFNOV"))
                        Me.VpfOwnDec.Text = Math.Round(Dr.Item("VPFDEC"))
                        Me.VpfOwnJan.Text = Math.Round(Dr.Item("VPFJAN"))
                        Me.VpfOwnFeb.Text = Math.Round(Dr.Item("VPFFEB"))

                        If (LoanMonth <= 12 And LoanMonth >= 4 Or LoanMonth <= 2) And Exist = True Then
                            Me.IntOwnFeb.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpFeb.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpFeb.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV") + Dr.Item("VPFDEC") + Dr.Item("VPFJAN"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnFeb.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN") + Dr.Item("PFFEB"), 2)
                            Me.AmtEmpFeb.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN") + Dr.Item("PFRFEB"), 2)
                        Else
                            Me.IntOwnFeb.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.IntEmpFeb.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                            Me.VpfEmpFeb.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV") + Dr.Item("VPFDEC") + Dr.Item("VPFJAN")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                            Me.AmtOwnFeb.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN") + Dr.Item("PFFEB"), 2)
                            Me.AmtEmpFeb.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN") + Dr.Item("PFRFEB"), 2)
                        End If

                        Me.VpfFeb.Text = Math.Round(Val(Me.VpfOwnFeb.Text) + Val(Me.VpfEmpFeb.Text), 2)
                    End If


                    'If Dr.Item("PFMAR2") > 0 Then
                    If D.Month = 3 Then
                        'PF Contribution Own
                        Me.ConOwnApril.Text = Math.Round(Dr.Item("PFAPR"))
                        Me.ConOwnMay.Text = Math.Round(Dr.Item("PFMAY"))
                        Me.ConOwnJune.Text = Math.Round(Dr.Item("PFJUN"))
                        Me.ConOwnJuly.Text = Math.Round(Dr.Item("PFJUL"))
                        Me.ConOwnAug.Text = Math.Round(Dr.Item("PFAUG"))
                        Me.ConOwnSep.Text = Math.Round(Dr.Item("PFSEP"))
                        Me.ConOwnOct.Text = Math.Round(Dr.Item("PFOCT"))
                        Me.ConOwnNov.Text = Math.Round(Dr.Item("PFNOV"))
                        Me.ConOwnDec.Text = Math.Round(Dr.Item("PFDEC"))
                        Me.ConOwnJan.Text = Math.Round(Dr.Item("PFJAN"))
                        Me.ConOwnFeb.Text = Math.Round(Dr.Item("PFFEB"))
                        Me.ConOwnMar.Text = Math.Round(Dr.Item("PFMAR2"))


                        'PF Contribution Emp
                        Me.ConEmpApril.Text = Math.Round(Dr.Item("PFRAPR"))
                        Me.ConEmpMay.Text = Math.Round(Dr.Item("PFRMAY"))
                        Me.ConEmpJune.Text = Math.Round(Dr.Item("PFRJUN"))
                        Me.ConEmpJuly.Text = Math.Round(Dr.Item("PFRJUL"))
                        Me.ConEmpAug.Text = Math.Round(Dr.Item("PFRAUG"))
                        Me.ConEmpSep.Text = Math.Round(Dr.Item("PFRSEP"))
                        Me.ConEmpOct.Text = Math.Round(Dr.Item("PFROCT"))
                        Me.ConEmpNov.Text = Math.Round(Dr.Item("PFRNOV"))
                        Me.ConEmpDec.Text = Math.Round(Dr.Item("PFRDEC"))
                        Me.ConEmpJan.Text = Math.Round(Dr.Item("PFRJAN"))
                        Me.ConEmpFeb.Text = Math.Round(Dr.Item("PFRFEB"))
                        Me.ConEmpMar.Text = Math.Round(Dr.Item("PFRMAR2"))

                        'PF Vpf Own
                        Me.VpfOwnApril.Text = Math.Round(Dr.Item("VPFAPR"))
                        Me.VpfOwnMay.Text = Math.Round(Dr.Item("VPFMAY"))
                        Me.VpfOwnJune.Text = Math.Round(Dr.Item("VPFJUN"))
                        Me.VpfOwnJuly.Text = Math.Round(Dr.Item("VPFJUL"))
                        Me.VpfOwnAug.Text = Math.Round(Dr.Item("VPFAUG"))
                        Me.VpfOwnSep.Text = Math.Round(Dr.Item("VPFSEP"))
                        Me.VpfOwnOct.Text = Math.Round(Dr.Item("VPFOCT"))
                        Me.VpfOwnNov.Text = Math.Round(Dr.Item("VPFNOV"))
                        Me.VpfOwnDec.Text = Math.Round(Dr.Item("VPFDEC"))
                        Me.VpfOwnJan.Text = Math.Round(Dr.Item("VPFJAN"))
                        Me.VpfOwnFeb.Text = Math.Round(Dr.Item("VPFFEB"))
                        Me.VpfOwnMar.Text = Math.Round(Dr.Item("VPFMAR2"))

                        If (LoanMonth <= 12 And LoanMonth >= 4 Or LoanMonth <= 3) And Exist = True Then
                            If (Dr.Item("PFMAR2")) > 0 Then
                                Me.IntOwnMar.Text = Math.Round(((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text)) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + (Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN") + Dr.Item("PFFEB"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                                Me.IntEmpMar.Text = Math.Round(((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text)) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + (Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN") + Dr.Item("PFRFEB"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                                Me.VpfEmpMar.Text = Math.Round(((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text)) - (Val(Me.VpfOwnNonRefLoan.Text) + Val(Me.VpfIntNonRefLoan.Text)) + (Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV") + Dr.Item("VPFDEC") + Dr.Item("VPFJAN") + Dr.Item("VPFFEB"))) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                                Me.AmtOwnMar.Text = Math.Round(Val(Me.AmtOwnOBal.Text) - (Val(Me.ConOwnNonRefLoan.Text) + Val(Me.IntOwnNonRefLoan.Text)) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN") + Dr.Item("PFFEB") + Dr.Item("PFMAR2"), 2)
                                Me.AmtEmpMar.Text = Math.Round(Val(Me.AmtEmpOBal.Text) - (Val(Me.ConEmpNonRefLoan.Text) + Val(Me.IntEmpNonRefLoan.Text)) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN") + Dr.Item("PFRFEB") + Dr.Item("PFRMAR2"), 2)
                            End If
                        Else
                            If (Dr.Item("PFMAR2")) > 0 Then
                                Me.IntOwnMar.Text = Math.Round((Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN") + Dr.Item("PFFEB")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                                Me.IntEmpMar.Text = Math.Round((Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN") + Dr.Item("PFRFEB")) * Val(Me.TxtRate.Text) / 12 / 100, 2)
                                Me.VpfEmpMar.Text = Math.Round((Val(Me.VpfOwnOBal.Text) + Val(Me.VpfEmpOBal.Text) + Dr.Item("VPFAPR") + Dr.Item("VPFMAY") + Dr.Item("VPFJUN") + Dr.Item("VPFJUL") + Dr.Item("VPFAUG") + Dr.Item("VPFSEP") + Dr.Item("VPFOCT") + Dr.Item("VPFNOV") + Dr.Item("VPFDEC") + Dr.Item("VPFJAN") + Dr.Item("VPFFEB")) * Val(Me.TxtRate.Text) / 12 / 100, 2)

                                Me.AmtOwnMar.Text = Math.Round(Val(Me.AmtOwnOBal.Text) + Dr.Item("PFAPR") + Dr.Item("PFMAY") + Dr.Item("PFJUN") + Dr.Item("PFJUL") + Dr.Item("PFAUG") + Dr.Item("PFSEP") + Dr.Item("PFOCT") + Dr.Item("PFNOV") + Dr.Item("PFDEC") + Dr.Item("PFJAN") + Dr.Item("PFFEB") + Dr.Item("PFMAR2"), 2)
                                Me.AmtEmpMar.Text = Math.Round(Val(Me.AmtEmpOBal.Text) + Dr.Item("PFRAPR") + Dr.Item("PFRMAY") + Dr.Item("PFRJUN") + Dr.Item("PFRJUL") + Dr.Item("PFRAUG") + Dr.Item("PFRSEP") + Dr.Item("PFROCT") + Dr.Item("PFRNOV") + Dr.Item("PFRDEC") + Dr.Item("PFRJAN") + Dr.Item("PFRFEB") + Dr.Item("PFRMAR2"), 2)
                            End If

                            ' Me.VpfMar.Text = Math.Round(Val(Me.VpfOwnMar.Text) + Val(Me.VpfEmpMar.Text), 2) Jaswal Sir 23/March/2009
                        End If
                        Me.VpfMar.Text = Math.Round(Val(Me.VpfOwnMar.Text) + Val(Me.VpfEmpMar.Text), 2)
                    End If


                    '                    End If
                End While
                'PF Contribution
                Me.ConOwnTotal.Text = Val(Me.ConOwnOBal.Text) + Val(Me.ConOwnApril.Text) + Val(Me.ConOwnMay.Text) + Val(Me.ConOwnJune.Text) + Val(Me.ConOwnJuly.Text) + Val(Me.ConOwnAug.Text) + Val(Me.ConOwnSep.Text) + Val(Me.ConOwnOct.Text) + Val(Me.ConOwnNov.Text) + Val(Me.ConOwnDec.Text) + Val(Me.ConOwnJan.Text) + Val(Me.ConOwnFeb.Text) + Val(Me.ConOwnMar.Text)
                Me.ConEmpTotal.Text = Val(Me.ConEmpOBal.Text) + Val(Me.ConEmpApril.Text) + Val(Me.ConEmpMay.Text) + Val(Me.ConEmpJune.Text) + Val(Me.ConEmpJuly.Text) + Val(Me.ConEmpAug.Text) + Val(Me.ConEmpSep.Text) + Val(Me.ConEmpOct.Text) + Val(Me.ConEmpNov.Text) + Val(Me.ConEmpDec.Text) + Val(Me.ConEmpJan.Text) + Val(Me.ConEmpFeb.Text) + Val(Me.ConEmpMar.Text)
                'Grand Total
                Me.ConOwnGTotal.Text = Val(Me.ConOwnTotal.Text) - Val(Me.ConOwnNonRefLoan.Text)
                Me.ConEmpGTotal.Text = Val(Me.ConEmpTotal.Text) - Val(Me.ConEmpNonRefLoan.Text)
                '-------------------------------------------
                'Pf Intrest
                Me.IntOwnTotal.Text = Val(Me.IntOwnObal.Text) + Val(Me.IntOwnApril.Text) + Val(Me.IntOwnMay.Text) + Val(Me.IntOwnJune.Text) + Val(Me.IntOwnJuly.Text) + Val(Me.IntOwnAug.Text) + Val(Me.IntOwnSep.Text) + Val(Me.IntOwnOct.Text) + Val(Me.IntOwnNov.Text) + Val(Me.IntOwnDec.Text) + Val(Me.IntOwnJan.Text) + Val(Me.IntOwnFeb.Text) + Val(Me.IntOwnMar.Text)
                Me.IntEmpTotal.Text = Val(Me.IntEmpOBal.Text) + Val(Me.IntEmpApril.Text) + Val(Me.IntEmpMay.Text) + Val(Me.IntEmpJune.Text) + Val(Me.IntEmpJuly.Text) + Val(Me.IntEmpAug.Text) + Val(Me.IntEmpSep.Text) + Val(Me.IntEmpOct.Text) + Val(Me.IntEmpNov.Text) + Val(Me.IntEmpDec.Text) + Val(Me.IntEmpJan.Text) + Val(Me.IntEmpFeb.Text) + Val(Me.IntEmpMar.Text)

                'Grand Total
                Me.IntOwnGTotal.Text = Val(Me.IntOwnTotal.Text) - Val(Me.IntOwnNonRefLoan.Text)
                Me.IntEmpGTotal.Text = Val(Me.IntEmpTotal.Text) - Val(Me.IntEmpNonRefLoan.Text)

                '------------------------------------------

                'Principal Amount
                'Me.AmtOwnTotal.Text = Val(Me.AmtOwnOBal.Text) + Val(Me.AmtOwnApril.Text) + Val(Me.AmtOwnMay.Text) + Val(Me.AmtOwnJune.Text) + Val(Me.AmtOwnJuly.Text) + Val(Me.AmtOwnAug.Text) + Val(Me.AmtOwnSep.Text) + Val(Me.AmtOwnOct.Text) + Val(Me.AmtOwnNov.Text) + Val(Me.AmtOwnDec.Text) + Val(Me.AmtOwnJan.Text) + Val(Me.AmtOwnFeb.Text) + Val(Me.AmtOwnMar.Text)
                'Me.AmtEmpTotal.Text = Val(Me.AmtEmpOBal.Text) + Val(Me.AmtEmpApril.Text) + Val(Me.AmtEmpMay.Text) + Val(Me.AmtEmpJune.Text) + Val(Me.AmtEmpJuly.Text) + Val(Me.AmtEmpAug.Text) + Val(Me.AmtEmpSep.Text) + Val(Me.AmtEmpOct.Text) + Val(Me.AmtEmpNov.Text) + Val(Me.AmtEmpDec.Text) + Val(Me.AmtEmpJan.Text) + Val(Me.AmtEmpFeb.Text) + Val(Me.AmtEmpMar.Text)

                'VPF
                Me.VpfOwnTotal.Text = Val(Me.VpfOwnOBal.Text) + Val(Me.VpfOwnApril.Text) + Val(Me.VpfOwnMay.Text) + Val(Me.VpfOwnJune.Text) + Val(Me.VpfOwnJuly.Text) + Val(Me.VpfOwnAug.Text) + Val(Me.VpfOwnSep.Text) + Val(Me.VpfOwnOct.Text) + Val(Me.VpfOwnNov.Text) + Val(Me.VpfOwnDec.Text) + Val(Me.VpfOwnJan.Text) + Val(Me.VpfOwnFeb.Text) + Val(Me.VpfOwnMar.Text)
                Me.VpfEmpTotal.Text = Val(Me.VpfEmpOBal.Text) + Val(Me.VpfEmpApril.Text) + Val(Me.VpfEmpMay.Text) + Val(Me.VpfEmpJune.Text) + Val(Me.VpfEmpJuly.Text) + Val(Me.VpfEmpAug.Text) + Val(Me.VpfEmpSep.Text) + Val(Me.VpfEmpOct.Text) + Val(Me.VpfEmpNov.Text) + Val(Me.VpfEmpDec.Text) + Val(Me.VpfEmpJan.Text) + Val(Me.VpfEmpFeb.Text) + Val(Me.VpfEmpMar.Text)

                Me.VpfTotal.Text = Val(Me.VpfOBal.Text) + Val(Me.VpfApril.Text) + Val(Me.VpfMay.Text) + Val(Me.VpfJune.Text) + Val(Me.VpfJuly.Text) + Val(Me.VpfAug.Text) + Val(Me.VpfSep.Text) + Val(Me.VpfOct.Text) + Val(Me.VpfNov.Text) + Val(Me.VpfDec.Text) + Val(Me.VpfJan.Text) + Val(Me.VpfFeb.Text) + Val(Me.VpfMar.Text)

                'VPF GRAND TOTAL
                Me.VpfOwnGTotal.Text = Val(Me.VpfOwnTotal.Text) - Val(Me.VpfOwnNonRefLoan.Text)
                Me.VpfEmpGTotal.Text = Val(Me.VpfEmpTotal.Text) - Val(Me.VpfIntNonRefLoan.Text)

                Me.FinalAmount.Text = Math.Round(Val(Me.ConOwnGTotal.Text) + Val(Me.ConEmpGTotal.Text) + Val(Me.IntOwnGTotal.Text) + Val(Me.IntEmpGTotal.Text) + Val(Me.VpfEmpGTotal.Text) + Val(Me.VpfOwnGTotal.Text))
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try
    End Sub

    Public Sub IntRate()

        If (D.Month <= 12 And D.Month >= 4) Then
            CurYear = Trim(D.Year & "-" & (D.Year + 1))
        ElseIf D.Month <= 3 Then
            CurYear = Trim((D.Year - 1) & "-" & D.Year)
        End If

        Dim SqlPass = "select Rate From Jctdev..Jct_Empg_Rate where CurrentYear= '" & CurYear & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()
                    Me.TxtRate.Text = Dr.Item("Rate")
                End While

            End If
        Catch ex As Exception

        Finally
            Dr.Close()
            Obj.ConClose()
        End Try
        'Me.TxtRate.Text = 8.5

    End Sub

    Public Sub CheckLoan()

        'CurYear = "2007-2008"
        Dim SqlPass = "Select LSANCNO,LSANCDT,LAMTOWN,LAMTEMP,LINTOWN,LINTEMP,VPFAMT,VPFINT,Month(LSANCDT) as LoanMonth,Year(LSANCDT) as LoanYear  from JCTDEV..nrefln where Empcode='" & Session("Empcode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try
            If Dr.HasRows = True Then
                While Dr.Read()

                    If (Dr.Item("LoanMonth") <= 12 And Dr.Item("LoanMonth") >= 4) And Mid(CurYear, 1, 4) = Dr.Item("LoanYear") Or (Dr.Item("LoanMonth") <= 3 And Mid(CurYear, 6, 9) = Dr.Item("LoanYear")) Then
                        Exist = True
                        LoanMonth = Dr.Item("LoanMonth")
                        LoanYear = Dr.Item("LoanYear")
                        Me.ConOwnNonRefLoan.Text = Math.Round(Dr.Item("LAMTOWN"))
                        Me.ConEmpNonRefLoan.Text = Math.Round(Dr.Item("LAMTEMP"))
                        Me.IntOwnNonRefLoan.Text = Math.Round(Dr.Item("LINTOWN"))
                        Me.IntEmpNonRefLoan.Text = Math.Round(Dr.Item("LINTEMP"))
                        Me.LoanNo.Text = Dr.Item("LSANCNO")
                        Me.LoanTakenDate.Text = Dr.Item("LSANCDT")
                        Me.VpfOwnNonRefLoan.Text = Math.Round(Dr.Item("VPFAMT"))
                        Me.VpfIntNonRefLoan.Text = Math.Round(Dr.Item("VPFINT"))
                    Else
                        Exist = False
                    End If


                End While
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try

    End Sub
    Public Sub OpeBal()
        'JCTDEV..nrefln c
        Dim SqlPass = "select * from JCTDEV..pfm2008 where Empcode='" & Session("Empcode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Try

            If Dr.HasRows = True Then

                While Dr.Read()

                    Me.FinalFPOBal.Text = Dr.Item("FPEAMT")

                    ' Me.FPFMonth.Text = IIf(Dr.Item("EPSAPR") Is System.DBNull.Value, "0", Dr.Item("EPSAPR")) + IIf(Dr.Item("EPSMAY") Is System.DBNull.Value, "0", Dr.Item("EPSMAY")) + IIf(Dr.Item("EPSJUN") Is System.DBNull.Value, "0", Dr.Item("EPSJUN")) + IIf(Dr.Item("EPSJUL") Is System.DBNull.Value, "0", Dr.Item("EPSJUL")) + IIf(Dr.Item("EPSAUG") Is System.DBNull.Value, "0", Dr.Item("EPSAUG")) + IIf(Dr.Item("EPSSEP") Is System.DBNull.Value, "0", Dr.Item("EPSSEP")) + IIf(Dr.Item("EPSOCT") Is System.DBNull.Value, "0", Dr.Item("EPSOCT")) + IIf(Dr.Item("EPSNOV") Is System.DBNull.Value, "0", Dr.Item("EPSNOV")) + IIf(Dr.Item("EPSDEC") Is System.DBNull.Value, "0", Dr.Item("EPSDEC")) + IIf(Dr.Item("EPSJAN") Is System.DBNull.Value, "0", Dr.Item("EPSJAN")) + IIf(Dr.Item("EPSFEB") Is System.DBNull.Value, "0", Dr.Item("EPSFEB")) + IIf(Dr.Item("EPSMAR2") Is System.DBNull.Value, "0", Dr.Item("EPSMAR2"))
                    ' Me.FinalFPF.Text = Val(Me.FinalFPOBal.Text) + Val(Me.FPFMonth.Text)
                    '-----------------------------------------------------------------------------
                    ' Header
                    '-----------------------------------------------------------------------------
                    Me.EmpName.Text = Dr.Item("EMPNAME")

                    If Dr.Item("FTHNAME") Is System.DBNull.Value Then
                        Me.FatName.Text = ""
                    Else
                        Me.FatName.Text = Dr.Item("FTHNAME")
                    End If

                    If Dr.Item("PFJDT") Is System.DBNull.Value Then
                    Else
                        Me.TxtDojs.Text = Dr.Item("PFJDT")
                        Me.TxtDojp.Text = Dr.Item("PFJDT")
                    End If

                    If Dr.Item("SRJDT") Is System.DBNull.Value Then
                    Else
                        Me.TxtDojs.Text = Dr.Item("SRJDT")
                    End If



                    If Dr.Item("NOMNM") Is System.DBNull.Value Then
                    Else
                        Me.TxtNominee.Text = Dr.Item("NOMNM")
                    End If
                    Me.TxtPfVpfNo.Text = Dr.Item("PFNO") & "/" & Dr.Item("FPFNO")
                    '-----------------------------------------------------------------------------
                    ' Opening Balance
                    '-----------------------------------------------------------------------------
                    'PF Contribution
                    Me.ConOwnOBal.Text = Math.Round(Dr.Item("PFOAMT"), 2)
                    Me.ConEmpOBal.Text = Math.Round(Dr.Item("PFEAMT"), 2)
                    'PF Intrest
                    Me.IntOwnObal.Text = Math.Round(Dr.Item("PFOINT"), 2)
                    Me.IntEmpOBal.Text = Math.Round(Dr.Item("PFEINT"), 2)
                    'PF VPF Intrest
                    Me.VpfOwnOBal.Text = Math.Round(Dr.Item("VPFAMT"), 2)
                    Me.VpfEmpOBal.Text = Math.Round(Dr.Item("VPFINT"), 2)

                    Me.VpfOBal.Text = Math.Round(Dr.Item("VPFAMT")) + Math.Round(Dr.Item("VPFINT"), 2)

                    Me.AmtOwnOBal.Text = Math.Round(Val(Me.ConOwnOBal.Text) + Val(Me.IntOwnObal.Text), 2)
                    Me.AmtEmpOBal.Text = Math.Round(Val(Me.ConEmpOBal.Text) + Val(Me.IntEmpOBal.Text), 2)

                End While

            End If

        Catch ex As Exception
            Exit Sub
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try

    End Sub


End Class




'Hard Code for Checking Purpose
'If ((3 <= 12 And 3 >= 4) And 2007 = 2007) Or (3 <= 3 And 2008 = 2008) Then
'    Exist = True
'    LoanMonth = 3
'    LoanYear = 2008
'Else
'    Exist = False
'End If