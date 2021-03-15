
Imports System.Data
Imports System.Data.SqlClient
Partial Class Default2
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String
    Dim ECode As String

    Public Sub BindData()
        'If Session("Location") = "JCT00LTD" Then
        
        If Session("Companycode") = "JCT00LTD" Then
            SqlPass = "exec JctDev..jct_Empg_Savior_Monthly_Leave_Detail '" & Session("Empcode") & "', " & Me.DropDownList1.SelectedItem.Text

            ' SqlPass = "exec JctDev..jct_Empg_Savior_Monthly_Leave_Detail '" & Session("Empcode") & "','2010' "
            'Else
            'SqlPass = "exec JctDev.. jct_Empg_Leavedetail_Hosh '" & Session("Empcode") & "', " & Now.Year.ToString
        End If

        'Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

        Try
            'If Dr.HasRows = True Then
            '    Dr.Close()
            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)
            GridView1.DataSource = ds
            GridView1.DataBind()

            'End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

       

    End Sub

    Protected Sub BindCompensatory()
        SqlPass = "exec JCT_USER_COMPENSATORY '" & Session("EmpCode").ToString & "'"

        Dim da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Try

            Dim ds As DataSet = New DataSet()
            ds.Clear()
            Da.Fill(ds)
            grdCompensatory.DataSource = ds
            grdCompensatory.DataBind()

            'End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Response.Cache.SetExpires(Now.AddSeconds(-1))
        'Response.Cache.SetNoStore()
        'Response.AppendHeader("Pragma", "no-cache")

        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not (Page.IsPostBack) Then
            If Session("Empcode") Is System.DBNull.Value Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "or", "<script language = javascript>alert('You Are On High Post')</script>")

            Else
                BindData()
                BindData1()
                BindCompensatory()
            End If

            '-----------------------Back to punch record--------------------------
            'If lcase(Session("Empcode")) = "r-03339" Then
            LinkButton12.visible = True

            If Request.QueryString.Get("trans1") = Nothing Then
                LinkButton12.PostBackUrl = "Punch.aspx"

            Else
                LinkButton12.text = "Back"
                LinkButton12.PostBackUrl = Nothing
                LinkButton12.OnClientClick = "javascript:window.history.go(-1);return false;"
            End If

            'Else
            '    LinkButton12.visible = False
            'End If


        End If
    End Sub
    ' Public Sub BindData1()
    '    ECode = Session("Empcode")
    'Dim Sqlpass = "select AutoId as ID, NatureLeave as Nature,Days,convert(char,leavefrom,103) as [ From ] ,convert(char,leaveto,103) as [ To ],TimeFrom as [Time From],TimeTo as [Time To], MainFlag as Status from jctdev..jct_empg_leave where   MainFlag in ('A','C','P') and EmpCode ='" & Trim(ECode) & "' order by autoid"
    ''  Dim SqlPass = "exec JctDev..Empg_Leave_STATUS " & Session("cardno") & ", " & Now.Year.ToString
    'Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
    'Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

    '   Try
    '      If Dr.HasRows = True Then
    '         Dr.Close()
    'Dim ds As DataSet = New DataSet()
    '           ds.Clear()
    '          Da.Fill(ds)
    '         GridView2.DataSource = ds
    '        GridView2.DataBind()
    '       Dr.Close()
    '  End If
    'Catch ex As Exception
    '' MsgBox(ex.Message)
    '   Finally
    '      Obj.ConClose()
    ' End Try
    'End Sub
    Public Sub BindData1()

        Dim SqlPass = "exec JctDev..jct_Empg_Leave_status '" & Session("Empcode") & "'"
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
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    ''Public Sub BindData1()

    ''    Dim SqlPass = "exec JctDev..Empg_Leave_STATUS " & Session("cardno") & ", " & Now.Year.ToString
    ''    Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
    ''    Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())

    ''    Try
    ''        If Dr.HasRows = True Then
    ''            Dr.Close()
    ''            Dim ds As DataSet = New DataSet()
    ''            ds.Clear()
    ''            Da.Fill(ds)
    ''            GridView2.DataSource = ds
    ''            GridView2.DataBind()
    ''            'Dr.Close()
    ''        End If
    ''    Catch ex As Exception
    ''        'MsgBox(ex.Message)
    ''    Finally
    ''        Obj.ConClose()
    ''    End Try

    ''End Sub

    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then

            Dim status As String = DataBinder.Eval(e.Row.DataItem, "Pending At")
            If Trim(status) = "Contact at 260/250(Pgw)" Then
                ' color the forecolor of the row red
                e.Row.ForeColor = Drawing.Color.Black
                e.Row.BackColor = Drawing.Color.IndianRed
            End If
        End If
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        BindData()
    End Sub

    Protected Sub grdCompensatory_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdCompensatory.PageIndexChanging
        grdCompensatory.PageIndex = e.NewPageIndex
        BindCompensatory()
    End Sub
End Class
