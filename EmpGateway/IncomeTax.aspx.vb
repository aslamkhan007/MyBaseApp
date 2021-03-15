Imports System.Data.SqlClient
Imports System.net.Mail.MailMessage
Imports System.net.Mail.SmtpClient
Imports System.Data


Partial Class IncomeTax
    Inherits System.Web.UI.Page
    Dim Obj As New Connection
    Dim Check As Boolean = False
    Dim Con As String
    ' Public Gender As String, Senior As String
    Dim Cmd As New SqlCommand
    Dim Saving As Double, Handi As Double
    Dim Tax1, Tax2 As Double
    Public Sub BindData()

        Dim SqlPass = "Select  Empcode,SEX,SENIOR_CIT,GTDSSAL,GHRA,GBALANCE,GSUB,GINCOME,OTHINCOME,GGROSS,GPF,TAX_INCOME,GTAX,GECESS,GSHECESS,TOTAL_TAX,GTAX_DED from jctdev..tax where empcode='" & Session("Empcode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

        If Dr.HasRows = True Then

            While Dr.Read()
                Session("Senior") = Dr.Item("SENIOR_CIT")
                Session("Gender") = Dr.Item("SEX")
                Me.TxtGtdSsal.Text = Dr.Item("GTDSSAL")
                Me.TxtGhra.Text = Dr.Item("GHRA")
                Me.TxtGsub.Text = Dr.Item("GSUB")
                Me.TxtGincome.Text = Dr.Item("GINCOME")
                Me.TxtOthIncome.Text = Dr.Item("OTHINCOME")

                If TxtOthIncome.Text = "" Then
                    TxtOthIncome.Text = "0"
                End If

                If Txt7a.Text = "" Then
                    Txt7a.Text = "0"
                End If

                If Txt8a.Text = "" Then
                    Txt8a.Text = "0"
                End If

                If Txt8b.Text = "" Then
                    Txt8b.Text = "0"
                End If

                If Txt8c.Text = "" Then
                    Txt8c.Text = "0"
                End If

                If Txt8d.Text = "" Then
                    Txt8d.Text = "0"
                End If

                Me.TxtGGross.Text = Dr.Item("GGROSS")
                Me.TxtGpf.Text = Dr.Item("GPF")
                Me.TxtTax_Income.Text = Dr.Item("TAX_INCOME")
                ' Me.TxtGtax.Text = Dr.Item("GTAX")
                ' Me.TXTGecess.Text = Dr.Item("GECESS")
                ' Me.txtGSHECESS.Text = Dr.Item("GSHECESS")
                ' Me.TxtTotal_Tax.Text = Dr.Item("TOTAL_TAX")
                Me.TxtGtax_ded.Text = Dr.Item("GTAX_DED")
            End While
            Dr.Close()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        If (Session("Empcode").ToString <> "") Then

        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not IsPostBack = True Then
            BindData()
        End If
    End Sub
    Protected Sub TxtOthIncome_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOthIncome.TextChanged
        If TxtOthIncome.AutoPostBack = True Then
            TxtGGross.Text = Val(TxtGincome.Text) + Val(TxtOthIncome.Text)
            Txt7a_TextChanged(e, Nothing)
        End If
    End Sub
    Protected Sub Txt7a_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt7a.TextChanged
        If Txt7a.AutoPostBack = True Then

            Saving = Val(TxtGpf.Text) + Val(Txt7a.Text)

            If Saving > 100000 Then
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('Cloumn Number a)& b) of Sr.No. 7  Not more than 100000')</script>")
                Txt7a.Focus()
            Else
                TxtTax_Income.Text = Val(TxtGGross.Text) - Saving - Val(Txt8a.Text) - Val(Txt8b.Text) - Val(Txt8c.Text) - Val(Txt8d.Text)


                If Val(TxtTax_Income.Text) > 160000 Then

                    If Session("Gender") = "M" Then
                        Tax1 = (Val(TxtTax_Income.Text) - 160000) * 0.1

                    ElseIf Val(TxtTax_Income.Text) > 190000 Then

                        If Session("Gender") = "F" Then
                            Tax1 = (Val(TxtTax_Income.Text) - 190000) * 0.1

                        ElseIf Val(TxtTax_Income.Text) > 240000 Then

                            If Session("Senior") = "Y" Then
                                Tax1 = (Val(TxtTax_Income.Text) - 240000) * 0.1
                            End If

                        End If

                    End If
                    TxtGtax.Text = Math.Round(Tax1, 0)
                    Check = True

                End If

                If Val(TxtTax_Income.Text) > 500000 Then

                    If Session("Gender") = "M" Then
                        Tax1 = 34000
                    ElseIf Session("Gender") = "F" Then
                        Tax1 = 31000
                    ElseIf Session("Senior") = "Y" Then
                        Tax1 = 26000
                    End If

                    'If Session("Senior") <> "Y" Then
                    Tax2 = (Val(TxtTax_Income.Text) - 500000) * 0.2
                    'Else
                    'Tax2 = (Val(TxtTax_Income.Text) - 225000) * 0.2
                    'End If

                    TxtGtax.Text = Math.Round(Tax1 + Tax2, 0)
                    Check = True
            End If


                If Val(TxtTax_Income.Text) > 800000 Then

                    If Session("Gender") = "M" Then
                        Tax1 = 94000
                    ElseIf Session("Gender") = "F" Then
                        Tax1 = 91000
                    ElseIf Session("Senior") = "Y" Then
                        Tax1 = 86000
                    End If


                    Tax2 = (Val(TxtTax_Income.Text) - 800000) * 0.3
                    TxtGtax.Text = Math.Round(Tax1 + Tax2, 0)
                    Check = True
                End If


                If Check = True Then
                    TXTGecess.Text = Math.Round(Val(TxtGtax.Text) * 0.02, 0)
                    txtGSHECESS.Text = Math.Round(Val(TxtGtax.Text) * 0.01, 0)
                    TxtTotal_Tax.Text = Math.Round(Val(Val(TxtGtax.Text)) + Val(TXTGecess.Text) + Val(txtGSHECESS.Text), 0)
                    TxtPerMonth.Text = Math.Round(Val(TxtTotal_Tax.Text) / 12, 0)
                    Check = False
                Else
                    TXTGecess.Text = ""
                    txtGSHECESS.Text = ""
                    TxtTotal_Tax.Text = ""
                    TxtPerMonth.Text = ""
                    TxtGtax.Text = ""
                    Check = False
                End If
            End If
        End If
    End Sub
    Protected Sub Txt8a_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt8a.TextChanged
        If Txt8a.AutoPostBack = True Then
            If Val(Txt8a.Text) > 15000 Then
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('Please 8)a  Not more than 15000')</script>")
                Txt8a.Text = ""
                Txt8a.Focus()
            Else
                Txt7a_TextChanged(e, Nothing)
            End If
        End If
    End Sub
    Protected Sub Txt8b_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt8b.TextChanged
        If Txt8b.AutoPostBack = True Then
            If Val(Txt8b.Text) > 75000 Then
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('Please 8)b  Not more than 75000')</script>")
                Txt8b.Text = ""
                Txt8b.Focus()
            Else
                Txt7a_TextChanged(e, Nothing)
            End If
        End If
    End Sub
    Protected Sub Txt8c_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt8c.TextChanged
        If Txt8c.AutoPostBack = True Then
            If Val(Txt8c.Text) > 75000 Then
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('Please 8)c  Not more than 75000')</script>")
                Txt8c.Text = ""
                Txt8c.Focus()
            Else
                Txt7a_TextChanged(e, Nothing)
            End If
        End If
    End Sub
    Protected Sub Txt8d_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txt8d.TextChanged
        If Txt8d.AutoPostBack = True Then
            Txt7a_TextChanged(e, Nothing)
        End If
    End Sub
End Class

