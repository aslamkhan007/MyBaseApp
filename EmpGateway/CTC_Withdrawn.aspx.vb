Imports System.Data
Imports System.Data.SqlClient
Imports vb = Microsoft.VisualBasic

Partial Class CTC
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Public SqlPass As String, CurYear As String, HraType As Long, actual_total As String
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
            '   Response.Redirect("CTC.aspx")
            BindData()
        Else
            Response.Redirect("~/login.aspx")
        End If


        BindData()
        numCTC.Text = Math.Round(Val(Me.Bas.Text) + Val(Me.HRA.Text) + Val(Me.ColAll.Text) + Val(Me.PerAll.Text) + Val(Me.SpeAll.Text) + Val(Me.ConAll.Text) + Val(Me.PfcAll.Text) + Val(Me.Medical.Text) + Val(Me.EsiAll.Text) + Val(Me.Bonus.Text) + Val(Me.SupAll.Text) + Val(Me.EntAll.Text) + Val(Me.Others.Text) + Val(Me.LtaAll.Text) + Val(Me.NewCarAll.Text) + Val(Me.DriAll.Text) + Val(Me.Gratuity.Text))

    End Sub

    Public Sub BindData()

        'Comented on 13-July-2009 By Ashish Sharma  
        Dim SqlPass = "Select *  FROM JCTDEV..EMPMAST WHERE EMPCODE='" & Session("Empcode") & "' and MonthYear=(select max(monthyear) from empmast)   "
        'Dim SqlPass As String = "Select salarytype,HouseType,catg,isnull(BASIC,0) AS BASIC,isnull(COLONY_ALW,0) AS COLONY_ALW,ISNULL(STD_COLALW,0) AS STD_COLALW,ISNULL(PA,0) AS PA,ISNULL(STDSPLALLO,0) AS STDSPLALLO,ISNULL(STD_TRPT,0) AS STD_TRPT,ISNULL(CONV,0) AS CONV,ISNULL(CAR_ALOW,0) AS CAR_ALOW,ISNULL(ESINO,0) AS ESINO,GROSS_SAL,isnull(Stdpa,0) AS Stdpa,ISNULL(stdadl_alw,0) AS stdadl_alw,ISNULL(stdsplallo,0) AS stdsplallo,ISNULL(std_trpt,0) AS std_trpt,ISNULL(std_colalw,0)AS std_colalw,ISNULL(elec_allow,0) AS elec_allow,ISNULL(Trpt_arr,0) AS Trpt_arr,ISNULL(hra_arrear,0) AS hra_arrear,ISNULL(splalw_arr,0) AS splalw_arr,ISNULL(arrear,0) AS arrear FROM JCTDEV..EMPMAST" & _
        '" WHERE EMPCODE='" & Session("Empcode") & "' and MonthYear=(select max(monthyear) from empmast)"
        ''sqlpass = "select isnull(BASIC,0) as Basic, isnull(COLONY_ALW,0) as COLONY_ALW ,isnull(STDSPLALLO,0) as STDSPLALLO,isnull(STD_TRPT,0) as STD_TRPT,isnull(CONV,0) as CONV,isnull(CAR_ALOW,0) as CAR_ALOW,isnull(ESINO,0) as ESINO,isnull(HouseType,0) as HouseType,isnull(GROSS_SAL,0) as GROSS_SAL,isnull(Stdpa,0) as Stdpa,isnull(stdadl_alw,0) as stdadl_alw,isnull(std_colalw,0) as std_colalw,isnull(elec_allow,0) as elec_allow,isnull(PA,0) as pa,isnull(Trpt_arr,0) as Trpt_arr,isnull(hra_arrear,0) as hra_arrear,isnull(splalw_arr,0) as splalw_arr,isnull(arrear,0) as arrear,isnull(salarytype,0) as salarytype,catg from Empmast"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr.HasRows = True Then

            While Dr.Read()

                Try
                    Me.Bas.Text = IIf(Dr.Item("BASIC") = 0, "", Dr.Item("BASIC"))
                    Me.HRA.Text = Math.Round((Val(Me.Bas.Text) * 30) / 100)
                    If Not Dr.Item("COLONY_ALW") Is System.DBNull.Value Then
                        Me.ColAll.Text = Math.Round(Dr.Item("STD_COLALW"))
                    End If
                    ' Me.ColAll.Text = Math.Round(IIf(Dr.Item("COLONY_ALW") = 0, "", Dr.Item("COLONY_ALW")))
                    If Not Dr.Item("STDPA") Is System.DBNull.Value Then
                        Me.PerAll.Text = Math.Round(Dr.Item("STDPA")) + Math.Round(Dr.Item("BP_ALW"))
                    End If


                    Me.SpeAll.Text = Math.Round(Dr.Item("SPLALLO")) + Math.Round(Dr.Item("SPLALW_ARR")) + Math.Round(Dr.Item("PA")) + Math.Round(Dr.Item("PA_ARREAR")) + Math.Round(Dr.Item("ADL_ARREAR")) + Math.Round(Dr.Item("ALW_2010"))



                    Me.ConAll.Text = Math.Round(Dr.Item("STD_TRPT") + Dr.Item("CONV") + Dr.Item("CAR_ALOW"))

                    If Not Dr.Item("ESINO") Is System.DBNull.Value Then
                        Me.EsiAll.Text = Math.Round((Dr.Item("GROSS_SAL") * 4.75) / 100)
                    End If

                    '30th March 2009
                    '------------------------------
                    If Not Dr.Item("HouseType") Is System.DBNull.Value Then
                        If Dr.Item("HouseType") = "HR" Then
                            HraType = (Dr.Item("BASIC") * 30) / 100
                        End If

                    End If

                    actual_total = HraType + Dr.Item("BASIC") + Dr.Item("Stdpa") + Dr.Item("stdadl_alw") + Dr.Item("stdsplallo") + Dr.Item("std_trpt") + Dr.Item("std_colalw") + Dr.Item("elec_allow") + Dr.Item("ALW_2010") + Dr.Item("BP_ALW")
                    ' If Dr.Item("GROSS_SAL") - Dr.Item("Trpt_arr") - Dr.Item("hra_arrear") - Dr.Item("splalw_arr") - Dr.Item("arrear") >= 10000 Then
                    '------------------------------

                    If actual_total - Dr.Item("Trpt_arr") - Dr.Item("hra_arrear") - Dr.Item("splalw_arr") - Dr.Item("arrear") >= 15000 Then
                        If ((Dr.Item("CATG") = "MM2") Or (Dr.Item("CATG") = "MM1") Or (Dr.Item("CATG") = "SM1") Or (Dr.Item("CATG") = "SM2") Or (Dr.Item("CATG") = "SM3")) Then
                            If Dr.Item("BASIC") >= 15000 Then
                                Me.Medical.Text = Math.Round(15000 / 12)
                            Else
                                Me.Medical.Text = Math.Round(Dr.Item("BASIC") / 12)
                            End If
                        End If
                    End If

                    Me.PfcAll.Text = Math.Round(Dr.Item("BASIC") * 0.12)

                    If ((Dr.Item("CATG") = "MM2") Or (Dr.Item("CATG") = "MM1") Or (Dr.Item("CATG") = "SM1") Or (Dr.Item("CATG") = "SM2") Or (Dr.Item("CATG") = "SM3")) Then

                        Me.LtaAll.Text = Math.Round(Dr.Item("BASIC") / 12)

                    End If



                    If Dr.Item("Basic") <= 10000 Then

                        If Dr.Item("Basic") >= 3500 Then
                            Me.Bonus.Text = Math.Round((3500 * 12 * 8.33) / 100 / 12)
                            If Dr.Item("Basic") < 3500 Then
                                Me.Bonus.Text = Math.Round((Dr.Item("Basic") * 12 * 8.33) / 100 / 12)
                            End If
                        End If

                    End If

                    If Dr.Item("Basic") > 10000 Then
                        Me.SupAll.Text = Math.Round(((Dr.Item("Basic") * 12) * 0.13) / 12)
                    End If

                    If Not Dr.Item("stdadl_alw") Is System.DBNull.Value Then
                        Me.NewCarAll.Text = Math.Round(Dr.Item("stdadl_alw"))
                    End If


                    Me.Gratuity.Text = Math.Round((Dr.Item("Basic") * 4.8) / 100)

                Catch ex As Exception

                End Try

            End While
        End If
        Dr.Close()

    End Sub


    
    Protected Sub EntAll_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EntAll.TextChanged
        If IsNumeric(EntAll.Text) Then
            numCTC.Text = Math.Round(Val(Me.Bas.Text) + Val(Me.HRA.Text) + Val(Me.ColAll.Text) + Val(Me.PerAll.Text) + Val(Me.SpeAll.Text) + Val(Me.ConAll.Text) + Val(Me.PfcAll.Text) + Val(Me.Medical.Text) + Val(Me.EsiAll.Text) + Val(Me.Bonus.Text) + Val(Me.SupAll.Text) + Val(Me.EntAll.Text) + Val(Me.Others.Text) + Val(Me.LtaAll.Text) + Val(Me.NewCarAll.Text) + Val(Me.DriAll.Text) + Val(Me.Gratuity.Text))
        Else
            EntAll.Text = 0
        End If
    End Sub

    Protected Sub DriAll_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DriAll.TextChanged
        If IsNumeric(DriAll.Text) Then
            numCTC.Text = Math.Round(Val(Me.Bas.Text) + Val(Me.HRA.Text) + Val(Me.ColAll.Text) + Val(Me.PerAll.Text) + Val(Me.SpeAll.Text) + Val(Me.ConAll.Text) + Val(Me.PfcAll.Text) + Val(Me.Medical.Text) + Val(Me.EsiAll.Text) + Val(Me.Bonus.Text) + Val(Me.SupAll.Text) + Val(Me.EntAll.Text) + Val(Me.Others.Text) + Val(Me.LtaAll.Text) + Val(Me.NewCarAll.Text) + Val(Me.DriAll.Text) + Val(Me.Gratuity.Text))
        Else
            DriAll.Text = 0
        End If
    End Sub

    Protected Sub Others_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Others.TextChanged
        If IsNumeric(Others.Text) Then
            numCTC.Text = Math.Round(Val(Me.Bas.Text) + Val(Me.HRA.Text) + Val(Me.ColAll.Text) + Val(Me.PerAll.Text) + Val(Me.SpeAll.Text) + Val(Me.ConAll.Text) + Val(Me.PfcAll.Text) + Val(Me.Medical.Text) + Val(Me.EsiAll.Text) + Val(Me.Bonus.Text) + Val(Me.SupAll.Text) + Val(Me.EntAll.Text) + Val(Me.Others.Text) + Val(Me.LtaAll.Text) + Val(Me.NewCarAll.Text) + Val(Me.DriAll.Text) + Val(Me.Gratuity.Text))
        Else
            Others.Text = 0
        End If
    End Sub
End Class


