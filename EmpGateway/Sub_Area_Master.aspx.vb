Imports System.Data.SqlClient
Imports system.Data
Partial Class Default6
    Inherits System.Web.UI.Page
    Dim db As Connection = New Connection
    Dim sql As String
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim comp_code As String
    Dim empcode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not IsPostBack Then
            comp_code = Session("Companycode")
            Try
                sql = "select area from jct_emp_area_master where company_code='" & Session("Companycode") & "' order by area"
                Dim cn As SqlConnection
                cn = db.Connection
                da = New SqlDataAdapter(sql, cn)
                Dim dt As DataTable = New DataTable
                da.Fill(dt)

                ddlArea.DataSource = dt
                ddlArea.DataTextField = "area"
                ddlArea.DataValueField = "area"
                ddlArea.DataBind()
                ddlArea.Items.Add("")
                ddlArea.Text = ""

            Catch ex As Exception
                lblError.Text = ex.Message
            End Try
        End If
    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        If (Session("Empcode").ToString <> "") Then
            empcode = Session("Empcode")
        Else
            Response.Redirect("login.aspx")
        End If
        sql = "insert into jct_emp_sub_area_master (company_code,emp_code,area,subarea,status,eff_from) values('" & Session("Companycode") & "','" & empcode & "','" & Replace(ddlArea.SelectedValue, "'", "''") & "','" & Replace(txtSubArea.Text, "'", "''") & "','',getdate())"
        Try
            cmd = New SqlCommand(sql, db.Connection())
            db.ConOpen()
            Dim n As Integer = cmd.ExecuteNonQuery()
            If (n > 0) Then
                'lblError.ForeColor = Drawing.Color.Blue
                lblError.Text = "Record Saved Successfully"
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
        Finally
            db.ConClose()
        End Try
    End Sub
End Class
