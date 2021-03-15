Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Partial Class RPT2
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection, Cmd As SqlCommand, Dr As SqlDataReader, Ds As New DataSet
    Dim Obj2 As Functions = New Functions
    Dim SqlPass As String, Member_Budget, COLOR, Sql, L_M_code, SALES_PERSON_CODE, Flag, PERIOD_FROM, PERIOD_TO As String
    Dim Drp As DropDownList
    Dim Exists As Boolean = False
    Dim MaxRows As Integer, I As Integer = 0, Count As Integer
    Dim a As Boolean
    Dim rpt As ReportDocument
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack = True Then
            GetCompany()
            GetGuestHouse()
            'Me.DrpAccom.Items.Add("ALL")
            'Me.DrpAccom.Items.Add("YES")
            'Me.DrpAccom.Items.Add("NO")
          

            Me.DrpMeals.Items.Add("ALL")
            Me.DrpMeals.Items.Add("BREAKFAST")
            Me.DrpMeals.Items.Add("LUNCH")
            Me.DrpMeals.Items.Add("TEA/SNACKS")
            Me.DrpMeals.Items.Add("DINNER")
            'Me.Dateto.Text = "02-28-2010"
            'Me.Datefrom.Text = "02-01-2010"

        End If
        If Page.IsPostBack = True Then
            bindReport()
        End If
    End Sub
    Private Sub Page_Unload(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Unload
        If (Not rpt Is Nothing) Then
            If rpt.IsLoaded = True Then
                rpt.Close()
                rpt.Dispose()
            End If
        End If
    End Sub
    Private Sub GetCompany()
        Obj.ConOpen()
        SqlPass = "select CompanyCode,Companyname,Location from jctgen..JCT_Company_Master"
        Cmd = New SqlCommand(SqlPass, Obj.Connection)
        Dr = Cmd.ExecuteReader
        While Dr.Read
            Me.DdlComp.Items.Add(Dr(1) + " ~ " + Dr(2))
            Me.DdlComp.Items(DdlComp.Items.Count - 1).Value = Dr(0)
        End While
        Dr.Close()
        Obj.ConClose()
    End Sub
    Private Sub GetGuestHouse()
        Obj.ConOpen()
        SqlPass = "select guesthouse from Jct_Emp_Guest_Accom where Companycode='" & Me.DdlComp.SelectedValue & "' and status='A'"
        Cmd = New SqlCommand(SqlPass, Obj.Connection)
        Dr = Cmd.ExecuteReader
        Me.DdlAccomm.Items.Clear()
        Me.DdlAccomm.Items.Add("ALL")
        If Dr.HasRows Then
            While Dr.Read
                Me.DdlAccomm.Items.Add(Dr(0))
            End While
        End If
        Me.DdlAccomm.Items.Add("Other")
        Dr.Close()
        Obj.ConClose()
    End Sub
    Protected Sub bindReport()
        If Me.DrpAccom.SelectedItem.Text = "YES" Then
            SqlPass = "Select guest_phone,emp_desg,emp_dept,PersonNo,PersonAccDept,PersonAccName,employeee_name ,companycode ,name ,stayrequired ,accommodation ,Meals,convert(varchar(12),stdurationfrom,101) as [stdurationfrom],convert(varchar(12),stdurationto,101) as [stdurationto],Servedrinks ,tocharge ,food ,JCTian from jct_emp_guesthouse where stdurationfrom between  '" & Trim(Me.Datefrom.Text) & "' and '" & Trim(Me.Dateto.Text) & "' and employeee_name like '%" & Trim(Me.TxtBookedBy.Text) & "%' and name like '%" & Trim(Me.TxtName.Text) & "%' and companycode='" & Session("Companycode") & "' AND (ACCON_TYPE='" & Trim(Me.DdlAccomm.SelectedValue) & "' or '" & Trim(Me.DdlAccomm.SelectedValue) & "'='ALL') AND (FOOD='" & Trim(Me.RLFood.SelectedValue) & "' OR '" & Trim(Me.RLFood.SelectedValue) & "'='Both') AND (SERVEDRINKS='" & Trim(Me.RLDrink1.SelectedValue) & "' OR '" & Trim(Me.RLDrink1.SelectedValue) & "'='Both') AND (TOCHARGE='" & Trim(Me.RLCharge.SelectedValue) & "' OR '" & Trim(Me.RLCharge.SelectedValue) & "'='Both') AND (JCTIAN='" & Trim(Me.RadioButtonList6.SelectedValue) & "' OR '" & Trim(Me.RadioButtonList6.SelectedValue) & "'='Both') and authflag='A' and (stayrequired='" & Trim(Me.DrpAccom.SelectedValue) & "' or '" & Trim(Me.DrpAccom.SelectedValue) & "'='ALL')"
        ElseIf Me.DrpAccom.SelectedItem.Text = "NO" Then
            If Me.DrpMeals.SelectedItem.Text = "ALL" Then
                SqlPass = "Select guest_phone,emp_desg,emp_dept,PersonNo,PersonAccDept,PersonAccName,employeee_name ,companycode ,name ,stayrequired ,Meals,accommodation ,convert(varchar(12),stdurationfrom,101) as [stdurationfrom],convert(varchar(12),stdurationto,101) as [stdurationto],Servedrinks ,tocharge,food ,JCTian from jct_emp_guesthouse  where stdurationfrom between  '" & Trim(Me.Datefrom.Text) & "' and '" & Trim(Me.Dateto.Text) & "' and employeee_name like '%" & Trim(Me.TxtBookedBy.Text) & "%' and name like '%" & Trim(Me.TxtName.Text) & "%' and companycode='" & Session("Companycode") & "' AND (FOOD='" & Trim(Me.RLFood.SelectedValue) & "' OR '" & Trim(Me.RLFood.SelectedValue) & "'='Both') AND (SERVEDRINKS='" & Trim(Me.RLDrink1.SelectedValue) & "' OR '" & Trim(Me.RLDrink1.SelectedValue) & "'='Both') AND (TOCHARGE='" & Trim(Me.RLCharge.SelectedValue) & "' OR '" & Trim(Me.RLCharge.SelectedValue) & "'='Both') AND (JCTIAN='" & Trim(Me.RadioButtonList6.SelectedValue) & "' OR '" & Trim(Me.RadioButtonList6.SelectedValue) & "'='Both') and authflag='A' and (stayrequired='" & Trim(Me.DrpAccom.SelectedValue) & "' or '" & Trim(Me.DrpAccom.SelectedValue) & "'='ALL') "
            Else
                SqlPass = "Select guest_phone,emp_desg,emp_dept,PersonNo,PersonAccDept,PersonAccName,employeee_name ,companycode ,name,stayrequired ,accommodation ,Meals,Servedrinks ,tocharge ,food ,JCTian ,convert(varchar(12),stdurationfrom,101) as [stdurationfrom],convert(varchar(12),stdurationto,101) as [stdurationto] from jct_emp_guesthouse  where (upper(lunch)='" & Trim(Me.DrpMeals.SelectedValue) & "' or upper(breakfast)='" & Trim(Me.DrpMeals.SelectedValue) & "' or upper(dinner)='" & Trim(Me.DrpMeals.SelectedValue) & "' or upper(snacks)='" & Trim(Me.DrpMeals.SelectedValue) & "') and stdurationfrom between  '" & Trim(Me.Datefrom.Text) & "' and '" & Trim(Me.Dateto.Text) & "' and employeee_name like '%" & Trim(Me.TxtBookedBy.Text) & "%' and name like '%" & Trim(Me.TxtName.Text) & "%' and companycode='" & Session("Companycode") & "' AND (FOOD='" & Trim(Me.RLFood.SelectedValue) & "' OR '" & Trim(Me.RLFood.SelectedValue) & "'='Both') AND (SERVEDRINKS='" & Trim(Me.RLDrink1.SelectedValue) & "' OR '" & Trim(Me.RLDrink1.SelectedValue) & "'='Both') AND (TOCHARGE='" & Trim(Me.RLCharge.SelectedValue) & "' OR '" & Trim(Me.RLCharge.SelectedValue) & "'='Both') AND (JCTIAN='" & Trim(Me.RadioButtonList6.SelectedValue) & "' OR '" & Trim(Me.RadioButtonList6.SelectedValue) & "'='Both') and authflag='A' and (stayrequired='" & Trim(Me.DrpAccom.SelectedValue) & "' or '" & Trim(Me.DrpAccom.SelectedValue) & "'='ALL') "
            End If
        Else
            If Me.DrpMeals.SelectedItem.Text = "ALL" Then
                SqlPass = "Select guest_phone,emp_desg,emp_dept,PersonNo,PersonAccDept,PersonAccName,employeee_name,companycode,name,stayrequired,Meals,accommodation ,convert(varchar(12),stdurationfrom,101) as [stdurationfrom],convert(varchar(12),stdurationto,101) as [stdurationto],Servedrinks ,tocharge,food ,JCTian from jct_emp_guesthouse  where stdurationfrom between  '" & Trim(Me.Datefrom.Text) & "' and '" & Trim(Me.Dateto.Text) & "' and employeee_name like '%" & Trim(Me.TxtBookedBy.Text) & "%' and name like '%" & Trim(Me.TxtName.Text) & "%' and companycode='" & Session("Companycode") & "' AND (FOOD='" & Trim(Me.RLFood.SelectedValue) & "' OR '" & Trim(Me.RLFood.SelectedValue) & "'='Both') AND (SERVEDRINKS='" & Trim(Me.RLDrink1.SelectedValue) & "' OR '" & Trim(Me.RLDrink1.SelectedValue) & "'='Both') AND (TOCHARGE='" & Trim(Me.RLCharge.SelectedValue) & "' OR '" & Trim(Me.RLCharge.SelectedValue) & "'='Both') AND (JCTIAN='" & Trim(Me.RadioButtonList6.SelectedValue) & "' OR '" & Trim(Me.RadioButtonList6.SelectedValue) & "'='Both') and authflag='A' AND (ACCON_TYPE='" & Trim(Me.DdlAccomm.SelectedValue) & "' or '" & Trim(Me.DdlAccomm.SelectedValue) & "'='ALL') and (stayrequired='" & Trim(Me.DrpAccom.SelectedValue) & "' or '" & Trim(Me.DrpAccom.SelectedValue) & "'='ALL') "
            Else
                SqlPass = "Select guest_phone,emp_desg,emp_dept,PersonNo,PersonAccDept,PersonAccName,employeee_name,companycode,name,stayrequired ,accommodation,Meals,Servedrinks ,tocharge ,food ,JCTian ,convert(varchar(12),stdurationfrom,101) as [stdurationfrom],convert(varchar(12),stdurationto,101) as [stdurationto] from jct_emp_guesthouse  where (upper(lunch)='" & Trim(Me.DrpMeals.SelectedValue) & "' or upper(breakfast)='" & Trim(Me.DrpMeals.SelectedValue) & "' or upper(dinner)='" & Trim(Me.DrpMeals.SelectedValue) & "' or upper(snacks)='" & Trim(Me.DrpMeals.SelectedValue) & "') and stdurationfrom between  '" & Trim(Me.Datefrom.Text) & "' and '" & Trim(Me.Dateto.Text) & "' and employeee_name like '%" & Trim(Me.TxtBookedBy.Text) & "%' and name like '%" & Trim(Me.TxtName.Text) & "%' and companycode='" & Session("Companycode") & "' AND (FOOD='" & Trim(Me.RLFood.SelectedValue) & "' OR '" & Trim(Me.RLFood.SelectedValue) & "'='Both') AND (SERVEDRINKS='" & Trim(Me.RLDrink1.SelectedValue) & "' OR '" & Trim(Me.RLDrink1.SelectedValue) & "'='Both') AND (TOCHARGE='" & Trim(Me.RLCharge.SelectedValue) & "' OR '" & Trim(Me.RLCharge.SelectedValue) & "'='Both') AND (JCTIAN='" & Trim(Me.RadioButtonList6.SelectedValue) & "' OR '" & Trim(Me.RadioButtonList6.SelectedValue) & "'='Both') and authflag='A' AND (ACCON_TYPE='" & Trim(Me.DdlAccomm.SelectedValue) & "' or '" & Trim(Me.DdlAccomm.SelectedValue) & "'='ALL') and (stayrequired='" & Trim(Me.DrpAccom.SelectedValue) & "' or '" & Trim(Me.DrpAccom.SelectedValue) & "'='ALL') "
            End If
        End If

        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Dim ds As DataSet = New DataSet()
        Obj.ConClose()
        ds.Clear()
        Da.Fill(ds)
        '        Dim rpt As ReportDocument = New ReportDocument()
        rpt = New ReportDocument()
        rpt.Load(Server.MapPath("rptGuest.rpt"))
        rpt.SetDataSource(ds.Tables(0))
        CrystalReportViewer1.ReportSource = rpt
        rpt.SetParameterValue("FromDt", Datefrom.Text)
        rpt.SetParameterValue("ToDt", Dateto.Text)
        rpt.SetParameterValue("Company", UCASE(Session("Companycode")))
        CrystalReportViewer1.Height = 600
        CrystalReportViewer1.Width = 820

        'Dim CrExportOptions As ExportOptions
        'Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions()
        'Dim CrFormatTypeOptions As New ExcelFormatOptions
        'CrDiskFileDestinationOptions.DiskFileName = "c:\crystalExport.xls"
        'CrExportOptions = rpt.ExportOptions
        'With CrExportOptions
        '    .ExportDestinationType = ExportDestinationType.DiskFile
        '    .ExportFormatType = ExportFormatType.Excel
        '    .DestinationOptions = CrDiskFileDestinationOptions
        '    .FormatOptions = CrFormatTypeOptions
        'End With

        Obj.ConClose()
    End Sub
    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        'bindReport()
    End Sub
    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        Response.Redirect("default.aspx")
    End Sub
    Protected Sub CMDCLEAR_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CMDCLEAR.Click
        Me.TxtBookedBy.Text = ""
        Me.TxtName.Text = ""
        Me.DrpAccom.Text = "ALL"
        Me.DdlAccomm.SelectedItem.Text = "ALL"
        Me.DrpMeals.SelectedItem.Text = "ALL"
    End Sub
    Protected Sub DrpAccom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpAccom.SelectedIndexChanged
        If Me.DrpAccom.SelectedItem.Text = "YES" Then
            Me.DdlAccomm.Enabled = True
            Me.DrpMeals.Enabled = False
            Me.DrpMeals.Text = "ALL"
        ElseIf Me.DrpAccom.SelectedItem.Text = "NO" Then
            Me.DrpMeals.Enabled = True
            Me.DdlAccomm.Enabled = False
            Me.DdlAccomm.SelectedItem.Text = "ALL"
        Else
            Me.DdlAccomm.Enabled = True
            Me.DrpMeals.Enabled = True
        End If
    End Sub
End Class
