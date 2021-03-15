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
    Public OldCode As String = Nothing

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
            OpeBal()
        End If

    End Sub

    Public Sub OpeBal()
        Dim sql As String = "Jct_Payroll_Gratuity_Voucher_Print"
        Dim cmd As SqlCommand = New SqlCommand(sql, Obj.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        'cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = ViewState("YEARMONTH")
        'cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = ViewState("empcode")
        cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = "201904"
        cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = "r-03584"
        Dim Dr As SqlDataReader = cmd.ExecuteReader()
        Try
            If Dr.HasRows = True Then

                While Dr.Read()

                    If Dr.Item("EmployeeCode") Is System.DBNull.Value Then
                        Me.EmpName.Text = ""
                    Else
                        Me.EmpName.Text = Dr.Item("EmployeeCode")
                    End If


                    'If Dr.Item("FatName") Is System.DBNull.Value Then
                    '    Me.FatName.Text = ""
                    'Else
                    '    Me.FatName.Text = Dr.Item("FatName")
                    'End If


                    If Dr.Item("EmployeeName") Is System.DBNull.Value Then
                        Me.TxtDojs.Text = ""
                    Else
                        Me.TxtDojs.Text = Dr.Item("EmployeeName")
                    End If


                    If Dr.Item("FatherHusbandName") Is System.DBNull.Value Then
                        Me.TxtNominee.Text = ""
                    Else
                        Me.TxtNominee.Text = Dr.Item("FatherHusbandName")
                    End If


                    If Dr.Item("Department_Long_Description") Is System.DBNull.Value Then
                        Me.TxtDojp.Text = ""
                    Else
                        Me.TxtDojp.Text = Dr.Item("Department_Long_Description")
                    End If


                    If Dr.Item("Desg_Long_description") Is System.DBNull.Value Then
                        Me.TxtPfVpfNo.Text = ""
                    Else
                        Me.TxtPfVpfNo.Text = Dr.Item("Desg_Long_description")
                    End If

                    If Dr.Item("GratuityNo") Is System.DBNull.Value Then
                        Me.TxtRate.Text = ""
                    Else
                        Me.TxtRate.Text = Dr.Item("GratuityNo")
                    End If


                    If Dr.Item("LeavingReason") Is System.DBNull.Value Then
                        Me.Label23.Text = ""
                    Else
                        Me.Label23.Text = Dr.Item("LeavingReason")
                    End If


                    If Dr.Item("DOleaving") Is System.DBNull.Value Then
                        Me.Label25.Text = ""
                    Else
                        Me.Label25.Text = Dr.Item("DOleaving")
                    End If

                    If Dr.Item("SrvDays") Is System.DBNull.Value Then
                        Me.Label9.Text = ""
                    Else
                        Me.Label9.Text = Dr.Item("SrvDays")
                    End If


                    If Dr.Item("SrvMth") Is System.DBNull.Value Then
                        Me.Label11.Text = ""
                    Else
                        Me.Label11.Text = Dr.Item("SrvMth")
                    End If


                    If Dr.Item("SrvYr") Is System.DBNull.Value Then
                        Me.Label26.Text = ""
                    Else
                        Me.Label26.Text = Dr.Item("SrvYr")
                    End If


                    If Dr.Item("DOleaving") Is System.DBNull.Value Then
                        Me.ConEmpOBal.Text = ""
                    Else
                        Me.ConEmpOBal.Text = Dr.Item("DOleaving")
                    End If


                    If Dr.Item("DOJ") Is System.DBNull.Value Then
                        Me.ConEmpApril.Text = ""
                    Else
                        Me.ConEmpApril.Text = Dr.Item("DOJ")
                    End If


                    If Dr.Item("Basic") Is System.DBNull.Value Then
                        Me.ConEmpJune.Text = ""
                    Else
                        Me.ConEmpJune.Text = Dr.Item("Basic")
                    End If

                    If Dr.Item("SrvYr") Is System.DBNull.Value Then
                        Me.IntEmpJune.Text = ""
                    Else
                        Me.IntEmpJune.Text = Dr.Item("SrvYr")
                    End If


                    If Dr.Item("GratuityRate") Is System.DBNull.Value Then
                        Me.AmtEmpJune.Text = ""
                    Else
                        Me.AmtEmpJune.Text = Dr.Item("GratuityRate")
                    End If


                    If Dr.Item("GratuityAmount") Is System.DBNull.Value Then
                        Me.ConEmpJuly.Text = ""
                    Else
                        Me.ConEmpJuly.Text = Dr.Item("GratuityAmount")
                    End If

                    'Me.VpfEmpOBal.Text = Math.Round(Dr.Item("VPFInt"), 2)
                End While

            Else
                Dim script As String = "alert(No data available!!');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
                Return
            End If
        Catch ex As Exception
            Exit Sub
        Finally
            Dr.Close()
            Obj.ConClose()
        End Try
    End Sub

End Class

