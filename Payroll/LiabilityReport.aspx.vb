Imports System.Data
Imports System.Data.SqlClient
Partial Class LiabilityReport
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim script As String
        Dim SqlPass As String = Nothing
        Try
            Dim Cmd As SqlCommand = New SqlCommand()
            SqlPass = "Jct_Payroll_Reimburs_Liability_Report"
            Cmd = New SqlCommand(SqlPass, Obj.Connection())
            Cmd.CommandType = CommandType.StoredProcedure
            'Cmd.Parameters.Add("@employeecode", SqlDbType.VarChar, 10).Value = Session("EmpCode")
            'Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = Convert.ToInt32("201809")
            'Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = "PLN-100"
            'Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = "LOC-100"
            'Cmd.Parameters.Add("@ReimbursmentType", SqlDbType.VarChar, 10).Value = "Scooter"

            Cmd.Parameters.Add("@YearMonth", SqlDbType.Int).Value = txttodate.Text
            Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value
            Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddllocation.SelectedItem.Value
            Cmd.Parameters.Add("@ReimbursmentType", SqlDbType.VarChar, 10).Value = ddlReporttype.SelectedItem.Value
            Cmd.Parameters.Add("@SalaryType", SqlDbType.VarChar, 7).Value = ddlSalaryType.SelectedItem.Text
            Dim Da As SqlDataAdapter = New SqlDataAdapter(Cmd)
            Dim ds As DataSet = New DataSet()
            Da.Fill(ds)
            GridView1.DataSource = ds.Tables(0)
            GridView1.DataBind()

            If ds.Tables(0).Rows.Count = 0 Then
                script = "alert('No Record Found');"
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Script, True)
                Return
            End If
        Catch ex As Exception
            script = "alert('Somethign went wrong... '" + ex.Message.ToString() + "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Protected Sub lnksave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnksave.Click
        Try
            BindData()
        Catch ex As Exception
            Dim script2 As String = "alert('" & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)
            Return
        Finally
            Obj.ConClose()
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not (Page.IsPostBack) Then
            'BindData()
            AttendenceDate()
            Plantbind()
            Locationbind()
        End If
    End Sub

    Public Sub AttendenceDate()
        Dim sqlqry As String = "Jct_Payroll_SalaryCal_Attendence_Month"
        Dim cmd As SqlCommand = New SqlCommand(sqlqry, obj.Connection())
        cmd.CommandType = CommandType.StoredProcedure
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        If dr.HasRows = True Then

            While dr.Read()
                txttodate.Text = dr("ToDate").ToString()
            End While
            dr.Close()

        End If
    End Sub
    Public Sub Plantbind()
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", obj.Connection())
        sqlCmd.CommandType = CommandType.Text
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        ddlplant.DataSource = ds
        ddlplant.DataTextField = "plant_description"
        ddlplant.DataValueField = "plant_code"
        ddlplant.DataBind()
    End Sub

    Public Sub Locationbind()
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" & ddlplant.SelectedItem.Value & "'", obj.Connection())
        sqlCmd.CommandType = CommandType.Text
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        ddllocation.DataSource = ds
        ddllocation.DataTextField = "Location_description"
        ddllocation.DataValueField = "Location_code"
        ddllocation.DataBind()
    End Sub

    Protected Sub ddlplant_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Locationbind()
    End Sub
    Protected Sub lnkexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkexcel0.Click
        GridViewExportUtil.Export("XL.xls", GridView1)
    End Sub

    Protected Sub lnkreset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkreset.Click
        Response.Redirect("LiabilityReport.aspx")
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Response.Redirect("Jct_Payroll_Conv_Reimb_Liablilty.aspx")
    End Sub
End Class

