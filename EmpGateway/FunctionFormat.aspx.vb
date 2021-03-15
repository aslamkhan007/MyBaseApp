Imports System.Data.SqlClient
Partial Class FunctionFormat
    Inherits System.Web.UI.Page
    Dim qry As String
    Dim obj As New Connection
    Dim cmd As New SqlCommand
    Dim dt As New Data.DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Session("empcode") = "N-02632"
        If (Session("Empcode").ToString <> "") Then
        Else
            Response.Redirect("~login.aspx")
        End If
        If IsPostBack = False Then
            Me.lblHeading.Text = Request.QueryString("FunctionName")
            GetFunctionWise(Trim(Me.lblHeading.Text))
            qry = "SELECT empname as Name,'Self' as Relationship,DATEDIFF(yy,dob,GETDATE()) as Age,'' as Meal,'p' AS seq FROM dbo.JCT_EmpMast_Base WHERE active='y' and empcode='" & Session("Empcode") & "' UNION SELECT upper(RelativeName), Relation,age,'' as Meal,'q' AS seq FROM dbo.JCT_Epor_Employee_Family_Dtl WHERE emp_code='" & Session("Empcode") & "' ORDER BY seq"
            grdbnd(qry, GrdFamily)
            qry = "SELECT ItemName,CONVERT(VARCHAR(20),Rate) + ' per ' + UOM AS RateUOM, UOM FROM JCT_Emp_Function_Requirement_Master WHERE status=''"
            grdbnd(qry, GrdReq)
        End If
    End Sub
    Private Sub grdbnd(ByVal qry As String, ByVal grd As GridView)

        Dim ds As New Data.DataSet
        Dim adp As New SqlDataAdapter(qry, obj.Connection)
        adp.Fill(ds)
        grd.DataSource = ds
        grd.DataBind()
        If grd Is GrdFamily Then
            ViewState("dtFm") = ds.Tables(0)
        ElseIf grd Is GrdReq Then
            ViewState("dtRq") = ds.Tables(0)
        End If

    End Sub

    Private Sub GetFunctionWise(ByVal FunctionName As String)
        Dim dr As SqlDataReader
        obj.ConOpen()
        qry = "select parametername, parametervalue from JCT_Emp_Function_Parameter_Master where functionname='" & FunctionName & "' and status=''"
        cmd = New SqlCommand(qry, obj.Connection)
        dr = cmd.ExecuteReader()
        If dr.HasRows = True Then
            While dr.Read
                If UCase(Trim(dr(0))) = "TO" Then
                    Me.lblDesg.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "TOOF" Then
                    Me.lblLoc.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "TOCITY" Then
                    Me.lblCity.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "NAME" Then
                    Me.lblOccasion.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "DATE" Then
                    Me.lblDate.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "VENUE" Then
                    Me.lblVenue.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "TIME" Then
                    Me.lblTime.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "MONTH" Then
                    Me.lblSalMonth.Text = dr(1)
                ElseIf UCase(Trim(dr(0))) = "NOTE" Then
                    Me.lblNote.Text = dr(1)
                End If
            End While
        End If
        obj.ConClose()
    End Sub
  
    Protected Sub LnkAddRow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkAddRow.Click
        dt = ViewState("dtFm")
        dt.Rows.Clear()
        Dim rw As Data.DataRow
        For i As Integer = 0 To Me.GrdFamily.Rows.Count - 1
            rw = dt.NewRow

            rw("Name") = CType(GrdFamily.Rows(i).FindControl("txtName"), TextBox).Text
            rw("Relationship") = CType(GrdFamily.Rows(i).FindControl("txtRelationship"), TextBox).Text
            rw("Age") = CType(GrdFamily.Rows(i).FindControl("txtAge"), TextBox).Text
            rw("Meal") = CType(GrdFamily.Rows(i).FindControl("DrpMeal"), DropDownList).SelectedItem.Text
            dt.Rows.Add(rw)
        Next
        Dim rw1 As Data.DataRow
        rw1 = dt.NewRow

        rw1("Name") = ""
        rw1("Relationship") = ""
        rw1("Age") = "0"
        rw1("Meal") = "Veg"

        dt.Rows.Add(rw1)
        Me.GrdFamily.DataSource = dt
        Me.GrdFamily.DataBind()
    End Sub

    Protected Sub GrdFamily_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdFamily.RowDeleting
        dt = ViewState("dtFm")
        dt.Rows.Clear()
        For i As Integer = 0 To Me.GrdFamily.Rows.Count - 1
            Dim rw As Data.DataRow
            rw = dt.NewRow
            rw("Name") = CType(GrdFamily.Rows(i).FindControl("txtName"), TextBox).Text
            rw("Relationship") = CType(GrdFamily.Rows(i).FindControl("txtRelationship"), TextBox).Text
            rw("Age") = CType(GrdFamily.Rows(i).FindControl("txtAge"), TextBox).Text
            rw("Meal") = CType(GrdFamily.Rows(i).FindControl("DrpMeal"), DropDownList).SelectedItem.Text
            dt.Rows.Add(rw)
        Next
        dt.Rows.RemoveAt(e.RowIndex)
        GrdFamily.DataSource = dt
        GrdFamily.DataBind()
        'addmore()
        For j As Integer = 0 To GrdFamily.Rows.Count - 1
            CType(GrdFamily.Rows(j).FindControl("txtName"), TextBox).Text = dt.Rows(j).Item("Name")
            CType(GrdFamily.Rows(j).FindControl("txtRelationship"), TextBox).Text = dt.Rows(j).Item("Relationship")
            CType(GrdFamily.Rows(j).FindControl("txtAge"), TextBox).Text = dt.Rows(j).Item("Age")
            CType(GrdFamily.Rows(j).FindControl("DrpMeal"), DropDownList).SelectedItem.Text = dt.Rows(j).Item("Meal")
        Next
        ViewState("dtFm") = dt

    End Sub

    Protected Sub LnkSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSubmit.Click
        Dim i As Integer
        Dim Name, Relationship, Age, Meal As String
        Dim Qty As Integer
        For i = 0 To GrdFamily.Rows.Count - 1
            Name = CType(GrdFamily.Rows(i).FindControl("txtName"), TextBox).Text
            Relationship = CType(GrdFamily.Rows(i).FindControl("txtRelationship"), TextBox).Text
            Age = CType(GrdFamily.Rows(i).FindControl("txtAge"), TextBox).Text
            Meal = CType(GrdFamily.Rows(i).FindControl("DrpMeal"), DropDownList).SelectedItem.Text

            obj.ConOpen()
            qry = "insert into  JCT_Emp_Function_Members (CompanyCode,EmpCode,FunctionName,	MemberName,Relationship,Age,Meal,HostIP,Status,EntryTime) VALUES ( '" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(Me.lblHeading.Text) & "','" & Name & "','" & Relationship & "'," & Age & ",'" & Meal & "','" & Request.ServerVariables("REMOTE_ADDR") & "','',getdate())"
            cmd = New SqlCommand(qry, obj.Connection)
            cmd.ExecuteNonQuery()
            obj.ConClose()
        Next


        For i = 0 To GrdReq.Rows.Count - 1
            Name = GrdReq.Rows(i).Cells(0).Text
            Qty = IIf(Trim(CType(GrdReq.Rows(i).FindControl("txtQty"), TextBox).Text) = "", 0, Trim(CType(GrdReq.Rows(i).FindControl("txtQty"), TextBox).Text))
            If Qty <> 0 Then
                obj.ConOpen()
                qry = "INSERT INTO JCT_Emp_Function_Requirement_Trans (CompanyCode,EmpCode,FunctionName,ItemName,Qty,HostIP,Status,EntryTime) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(Me.lblHeading.Text) & "','" & Name & "'," & Qty & ",'" & Request.ServerVariables("REMOTE_ADDR") & "','',getdate())"
                cmd = New SqlCommand(qry, obj.Connection)
                cmd.ExecuteNonQuery()
                obj.ConClose()
            End If
        Next
        FMsg.Message = "Form Submitted Successfully!!"
        FMsg.Display()
    End Sub
End Class
