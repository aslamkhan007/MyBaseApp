Imports System.Data
Imports System.Net
Imports System.Data.SqlClient
Imports System.Web.Services
Partial Class EmpGateway_VehicleMaster
    Inherits System.Web.UI.Page
    Dim ofn As New Functions
    Protected Sub btnIns_Click(sender As Object, e As System.EventArgs) Handles btnIns.Click
        Dim cn As New Connection
        Try
            Dim sql As String = "Jct_Gatway_Vehicle_Master"
            Dim cmd As New SqlCommand(sql, cn.Connection)
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.Add("UserCode", SqlDbType.VarChar, 16).Value = Session("EmpCode").ToString
            cmd.Parameters.Add("VEHICLE_Name", SqlDbType.VarChar, 20).Value = txtVehicleName.Text
            cmd.Parameters.Add("VEHICLES_Type", SqlDbType.VarChar, 15).Value = txtVehicleType.Text
            cmd.Parameters.Add("VEHICLE_No", SqlDbType.VarChar, 20).Value = txtVehicleNo.Text
            cmd.Parameters.Add("VEHICLE_Make", SqlDbType.VarChar, 30).Value = txtVehicleMake.Text
            cmd.Parameters.Add("VEHICLE_Model", SqlDbType.VarChar, 16).Value = txtVehicleModelNo.Text
            cmd.Parameters.Add("Purchase_Date", SqlDbType.VarChar, 16).Value = txtPurchaseDate.Text
            cmd.Parameters.Add("Eff_From", SqlDbType.VarChar, 16).Value = txtfrom.Text
            cmd.Parameters.Add("Eff_To", SqlDbType.VarChar, 16).Value = txtDateTo.Text
            cmd.Parameters.Add("PlateType", SqlDbType.VarChar, 16).Value = txtplate.Text
            cmd.Parameters.Add("Remarks", SqlDbType.VarChar, 16).Value = txtRemarks.Text
            cmd.ExecuteNonQuery()
            bindgrid()

        Catch ex As Exception
            ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('" + ex.Message.ToString + "');", True)
        End Try
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        bindgrid()
    End Sub
    Private Sub clear()

        txtVehicleName.Text = ""
        txtVehicleType.Text = ""
        txtVehicleNo.Text = ""
        txtVehicleMake.Text = ""
        txtfrom.Text = ""
        txtVehicleModelNo.Text = ""
        txtPurchaseDate.Text = ""
        txtRemarks.Text = ""
        txtDateTo.Text = ""
        txtplate.Text = ""
    End Sub
    Private Sub bindgrid()
        Dim cn As New Connection
        Dim cn1 As New Connection
        Dim cmd1 As SqlCommand
        Dim sqlstr As String = "jct_emp_GetMaster_Vehicle_Detail"
        cmd1 = New SqlCommand(sqlstr, cn1.Connection)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd1)
        Dim ds As DataSet = New DataSet()
        da.Fill(ds)
        grdvehicle.DataSource = ds.Tables(0)
        grdvehicle.DataBind()
    End Sub
End Class
