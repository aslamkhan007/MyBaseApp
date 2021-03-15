Imports System.Data
Imports System.Data.SqlClient
Partial Class Payroll_SalaryAdvanceReport
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim script As String
        Dim SqlPass As String = Nothing
        Try
            Dim Cmd As SqlCommand = New SqlCommand()
            SqlPass = "Jct_Payroll_SalaryAdvance_Report"
            Cmd = New SqlCommand(SqlPass, Obj.Connection())
            Cmd.CommandType = CommandType.StoredProcedure            
            Cmd.Parameters.Add("@Plant", SqlDbType.VarChar, 10).Value = ddlplant.SelectedItem.Value
            Cmd.Parameters.Add("@Location", SqlDbType.VarChar, 10).Value = ddllocation.SelectedItem.Value
            Cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = txtfromdate.Text
            Cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = txttodate.Text
            Cmd.Parameters.Add("@ReimbursementType", SqlDbType.VarChar, 25).Value = ddlReporttype.SelectedItem.Value
            Cmd.Parameters.Add("@Designation", SqlDbType.VarChar, 10).Value = ddldesignation.SelectedItem.Value            
            Cmd.Parameters.Add("@EmployeeCode", SqlDbType.VarChar, 10).Value = Session("EmpCode")            
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
            script = "alert('" & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script, True)
        Finally
            Obj.ConClose()
        End Try
    End Sub


    Protected Sub lnksave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnksave.Click
        BindData()
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
            Plantbind()
            Locationbind()
            Designationbind()
            AttendenceDate()
        End If
    End Sub
    Public Sub AttendenceDate()
        Dim origDT As DateTime = Convert.ToDateTime(System.DateTime.Now.ToShortDateString())
        origDT = New DateTime(origDT.Year, origDT.Month, 1).AddMonths(-1)
        txtfromdate.Text = Convert.ToDateTime(origDT).ToShortDateString()
        Dim lastDate As DateTime = New DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1)
        txttodate_CalendarExtender.SelectedDate = lastDate
    End Sub

    Protected Sub txtfromdate_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim origDT As DateTime = Convert.ToDateTime(txtfromdate.Text)
        Dim lastDate As DateTime = New DateTime(origDT.Year, origDT.Month, 1).AddMonths(1).AddDays(-1)
        txttodate_CalendarExtender.SelectedDate = lastDate
    End Sub

    Public Sub Plantbind()
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT plant_description,plant_code FROM jct_payroll_Plant_Master WHERE  STATUS='A' ORDER BY plant_code", Obj.Connection())
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
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT Location_description,Location_code FROM JCT_payroll_location_master WHERE  STATUS='A' and plant_code='" & ddlplant.SelectedItem.Value & "'", Obj.Connection())
        sqlCmd.CommandType = CommandType.Text
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        ddllocation.DataSource = ds
        ddllocation.DataTextField = "Location_description"
        ddllocation.DataValueField = "Location_code"
        ddllocation.DataBind()
    End Sub

    Public Sub Designationbind()
        Dim sqlCmd As SqlCommand = New SqlCommand("SELECT 'All' as  Designation_code,'All' as Desg_Long_Description Union SELECT Designation_code,Desg_Long_Description FROM JCT_payroll_designation_master WHERE  STATUS='A' order by Desg_Long_Description", Obj.Connection())
        sqlCmd.CommandType = CommandType.Text
        Dim da As SqlDataAdapter = New SqlDataAdapter(sqlCmd)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        ddldesignation.Items.Clear()
        ddldesignation.DataSource = ds
        ddldesignation.DataTextField = "Desg_Long_Description"
        ddldesignation.DataValueField = "Designation_code"
        ddldesignation.DataBind()
    End Sub

    Protected Sub ddlplant_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Locationbind()
    End Sub
    Protected Sub lnkexcel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lnkexcel0.Click
        GridViewExportUtil.Export("XL.xls", GridView1)
    End Sub

    Protected Sub lnkreset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkreset.Click
        Response.Redirect("SalaryAdvanceReport.aspx")
    End Sub
End Class


