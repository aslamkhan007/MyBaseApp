Imports System.Data
Imports System.Data.SqlClient


Partial Class Default3
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim sum As Decimal = 0

    Public Sub BindData()
        Dim SqlPass = "select Months as [Month],monthyear AS [Year Month] ,isnull(ob,0) as [Opening Balance],isnull(ENTITLE,0)   as [Entitlement],ISNULL(last_reimb,0)  as [Last Reimbursement+ Dispensary],ISNULL(Curr_reimb,0) as [Current Reimbursement(Bill)],ISNULL(disp,0) as [Current Dispensary Cost],ISNULL(Balance,0) as [Available Balance] from jctdev..medmast where empcode='" & Session("Empcode") & "' ORDER BY monthyear DESC "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            Else
                Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('You are not entitled for medical !!')</script>")
            End If
        Catch ex As Exception
            Page.RegisterClientScriptBlock("scr", "<script language = javascript>alert('" & ex.Message & "!!')</script>")
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetExpires(Now.AddSeconds(-1))
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")
        If Not (Page.IsPostBack) Then

            ' Bind Year and Month Dropdown
            BindDropDown()
            BindData()
            BindData1()
        End If
    End Sub

    Public Sub BindDropDown()

        Dim year As String = System.DateTime.Now.Year
        Dim month As String = System.DateTime.Now.Month

        ddlYear.SelectedIndex = ddlYear.Items.IndexOf(ddlYear.Items.FindByValue(year.ToString()))

        If (ddlMonth.SelectedItem.Value < 10) Then

            ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue("0" + month.ToString()))
        Else

            ddlMonth.SelectedIndex = ddlMonth.Items.IndexOf(ddlMonth.Items.FindByValue(month.ToString()))

        End If

    End Sub

    Public Sub BindData1()

       
        Dim SqlPass = "exec JctDev..jct_staff_medical_store_medicine_consumption '" & Session("Empcode") & "' , '" + ddlMonth.SelectedItem.Value + "','" + ddlYear.SelectedItem.Value + "'"
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                GridView2.DataSource = ds
                GridView2.DataBind()
                'Dr.Close()
            Else
                GridView2.DataSource = Nothing
                GridView2.DataBind()
            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView2.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            sum = sum + Decimal.Parse(e.Row.Cells(6).Text)
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(2).Text = "Total"
            e.Row.Cells(6).Text = sum
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub ddlMonth_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlMonth.SelectedIndexChanged
        BindData1()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlYear.SelectedIndexChanged
        BindData1()
    End Sub
End Class
