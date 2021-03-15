Imports System
Imports System.Data
Imports System.Data.SqlClient
Partial Class Emp_Home
    Inherits System.Web.UI.Page
    Dim WithEvents dlsNested As DataList = New DataList
    Dim WithEvents dlsEmpArea As DataList = New DataList
    Dim WithEvents lnkItem As LinkButton = New LinkButton
    Dim ofn As Functions = New Functions

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("Empcode") = "" Then
            Response.Redirect("Login.aspx")
        End If

        Dim sql As String = "select distinct case when web_flag = 'T' then 'Web Applications' " & _
        " when web_flag = 'R' then 'RAMCO ERP' when web_flag = 'W' then 'Other Apps' end 'data', Web_Flag from production..modules where web_flag <> '' order by web_flag"
        '"union select 'Others' 'data' union select 'Others2' 'data'"

        dlsRight.DataSource = ofn.FetchDS(sql) 'ds.Tables(0)
        dlsRight.DataBind()

        sql = "select 'My Area' 'data'"

        dlsLeft.DataSource = ofn.FetchDS(sql) 'ds.Tables(0)
        dlsLeft.DataBind()

        CType(Master.FindControl("lnkMyArea"), LinkButton).Visible = False

        sql = "select a.cardno, a.empname, a.deptcode, a.desg, isnull(b.mobile,'') as mobile, isnull(b.E_MailID,'') as E_MailID, Int_Off from jct_empmast_base a inner join mistel b on a.empcode = b.empcode " & _
            "where active = 'Y' and a.empcode = '" & Session("EmpCode") & "'"

        Dim dr As SqlDataReader = ofn.FetchReader(sql)

        dr.Read()
        lblName.Text = dr("empname")
        lblDept.Text = dr("deptcode")
        lblDesg.Text = dr("desg")
        lblMobile.Text = dr("mobile")
        lblEmail.Text = dr("e_mailid")
        lblExt.Text = dr("int_off")
        imgEmp.ImageUrl = "~\EmployeePortal\empimages\" & dr("cardno") & ".jpg"
        dr.Close()
        If Not Page.IsPostBack Then
            If Trim(lblMobile.Text) <> "" Then
                lblMobile.Visible = True
                lnkEditMobile.Visible = False
            Else
                lnkEditMobile.Text = "Add Mobile No."
                lblMobile.Visible = False
            End If
            If lblExt.Text <> 0 Then
                lblExt.Visible = True
                lnkEdit.Text = "Edit"
            Else
                lnkEdit.Text = "Add Ext. No"
                lblExt.Visible = False
            End If


        End If

    End Sub

    Protected Sub dlsLeft_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsLeft.ItemDataBound
        Dim qs As String = "" '"?" & "UserName=Jagdeep" & "App= "


        Dim sql As String
        If UCase(Session("Empcode")) = "R-03339" Or UCase(Session("Empcode")) = "J-0183" Or UCase(Session("Empcode")) = "N-02632" Then
            sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' union select 'Blog' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Blog.aspx" & qs & "' 'url' union select 'Pending Leaves' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Pending_Leaves.aspx" & qs & "' 'url'"
            'Check if Logged in Employee is entitled to authorise leaves or have subordinates who are entitled for the same
        ElseIf (ofn.CheckRecordExistInTransaction("select top 1 Resp_Emp from jct_emp_hod where resp_Emp = '" & Session("Empcode").ToString & "' and status is null")) Then 'Check if Logged in Employee is entitled to authorise leaves or have subordinates who are entitled for the same
            sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url' union select 'Pending Leaves' 'data', '~\Image\Buttons_Tabs\Ball_Blue.png' 'icon', 'Pending_Leaves.aspx" & qs & "' 'url' "
        Else
            sql = "select 'Consent Area' 'data', '~\Image\Buttons_Tabs\Ball_Green.png' 'icon' , 'EmpGateway/MyWorkArae.aspx" & qs & "' 'url'  union select 'Action Area' 'data', '~\Image\Buttons_Tabs\Ball_Red.png' 'icon', 'EmpGateway/MyActions.aspx" & qs & "' 'url'  union select 'Leave Status' 'data', '~\Image\Buttons_Tabs\Ball_Yellow.png' 'icon', 'EmpGateway/Default2.aspx" & qs & "' 'url'"
        End If

        Dim ds As DataSet = ofn.FetchDS(sql)

        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            dlsNested = CType(e.Item.FindControl("dlsEmpArea"), DataList)
            dlsNested.DataSource = ds.Tables(0)
            dlsNested.DataBind()
        End If

    End Sub

    Protected Sub dlsRight_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsRight.ItemDataBound

        Dim item As String = CType(e.Item.FindControl("hiddenfield1"), HiddenField).Value
        Dim sql As String
        sql = "jct_fap_user_modules '" & Session("Empcode") & "','" & item & "','" & DetectOS() & "'"
        Dim ds As DataSet = ofn.FetchDS(sql)
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

            dlsNested = CType(e.Item.FindControl("dlsNested"), DataList)
            dlsNested.DataSource = ds.Tables(0)
            dlsNested.DataBind()
        End If

    End Sub

    Protected Sub dlsEmpArea_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsEmpArea.ItemDataBound

        'Dim cn As SqlConnection = New SqlConnection(constr)
        'Dim sql As String = "select 'Image\Buttons_Tabs\Ball_Green.png' 'icon' union select 'Image\Buttons_Tabs\Ball_Red.png' 'icon' union select 'Image\Buttons_Tabs\Ball_Yellow.png' 'icon'"
        'Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
        'Dim ds As DataSet = New DataSet()
        'da.Fill(ds)

        'If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
        '    'Dim icon As Image = CType(e.Item.FindControl("imgIcon"), Image)
        '    dl1 = CType(e.Item.FindControl("dlsAppShrts"), DataList)
        '    dl1.DataSource = ds.Tables(0)
        '    dl1.DataBind()

        'End If

    End Sub

    Protected Sub dlsNested_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles dlsNested.ItemCommand

        ClientScript.RegisterClientScriptBlock(Me.GetType(), "scr", "<script language = 'javascript'>alert('Application not presently available')</script>")

    End Sub

    Protected Sub lnkItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkItem.Click

    End Sub

    Protected Sub dlsNested_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Protected Function DetectOS() As String
        Dim strAgent As String
        strAgent = Request.ServerVariables("HTTP_USER_AGENT")
        'Label14.Text = InStr(strAgent, "Windows98")

        'Label14.Text = InStr(strAgent, "Windows NT 6.1")

        'Commented for picking same path for old as well as new OSes------------------------
        'If InStr(strAgent, "Windows 98") > 0 Or InStr(strAgent, "Windows NT 5.0") > 0 Then
        'Return "O"
        'Else
        'Return "N"
        'End If
        '-----------------------------------------------------------------------------------
        Return "N"

    End Function

    Protected Sub dlsNested_ItemCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles dlsNested.ItemCreated

        Dim ctrl As HtmlGenericControl = CType(e.Item.FindControl("Item"), HtmlGenericControl)
        ctrl.Attributes.Add("onmouseover", "this.className = 'SelItem'")
        ctrl.Attributes.Add("onmouseout", "this.className = ''")

    End Sub
    Protected Sub EditRecord(ByVal lnk As LinkButton)
        If lnk.ID = "lnkEdit" Then
            If lnkEdit.Text = "Add Ext. No" Or lnkEdit.Text = "Edit" Then
                lblExt.Visible = False
                txtExt.Visible = True
                txtExt.Text = lblExt.Text
                lnkEdit.Text = "Update"
            Else
                Dim sql As String = "update mistel set int_off =" & txtExt.Text & " where  empcode='" & Session("EmpCode") & "' "
                ofn.UpdateRecord(sql)
                sql = "Select Int_Off from mistel where empcode='" & Session("EmpCode") & "'"
                lblExt.Text = ofn.FetchValue(sql)
                lblExt.Visible = True
                txtExt.Visible = False
                lnkEdit.Text = "Edit"
            End If
        ElseIf lnk.ID = "lnkEditMobile" Then
            If lnkEditMobile.Text = "Add Mobile No." Then
                lblMobile.Visible = False
                txtMobile.Visible = True
                lnkEditMobile.Text = "Update"
            Else

                '   lnkEditMobile.OnClientClick = "if(confirm('Are you sure you want to permanently update your mobile number ?'))"
                ' If Page.IsValid = True Then
                Dim sm As New SendMail
                Dim msg As String = "Your mobile number " & txtMobile.Text & " has been successfully updated in JCTs corporate database. Thanks for updating !!"
                Dim subject As String = "Mobile Number Resgistered."
                'Dim mobile As String = "Select mobile from mistel where mobile='" & txtMobile.Text & "'"
                'If ofn.FetchValue(mobile) = True Then
                '    If lblError.Visible = False Then
                '        lblError.Visible = True
                '    End If

                '    lblError.Text = "This number has been registered for another employee, Please enter your number."
                '    txtMobile.Text = ""
                'Else
                Dim sql As String = "update mistel set mobile='" & txtMobile.Text & "' where empcode='" & Session("EmpCode") & "' "
                ofn.UpdateRecord(sql)
                sm.SendSMS(Session("CompanyCode"), "", txtMobile.Text, msg, subject)
                sm.SendMail("jagdeep@jctltd.com", "dummy@jctltd.com", "Mobile Number Updated by " & Session("EmpCode") & " - " & lblName.Text, "Mobile Number Updated by " & Session("EmpCode") & " - " & lblName.Text & " to " & txtMobile.Text)
                sql = "Select mobile from mistel where  empcode='" & Session("EmpCode") & "'"
                lblMobile.Text = ofn.FetchValue(sql)
                lblMobile.Visible = True
                txtMobile.Visible = False
                lnkEditMobile.Visible = False
                ' Threading.Thread.Sleep(2000)
                UpdateProgress1.Visible = True
                '  End If
                ' Else
                ' CustomValidator1.ErrorMessage = "Invalid"
                '  End If

        End If
        End If
    End Sub

    Protected Sub lnkEditMobile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEditMobile.Click
        If lnkEditMobile.Text = "Update" Then
            Dim mobile As String = "Select mobile from mistel a  inner join jct_empmast_base b on a.empcode=b.empcode where mobile='" & Trim(txtMobile.Text) & "' and b.active='Y' "
            Dim a As Integer = txtMobile.Text.Length
            If txtMobile.Text.Length <> 10 Then
                lblError.Text = "Please Enter valid mobile number."
            ElseIf txtMobile.Text.StartsWith("0") Or txtMobile.Text.StartsWith("91") Then
                lblError.Text = "Donot use '0' or '+91' before mobile number."

            ElseIf ofn.FetchValue(mobile) = True Then
                If lblError.Visible = False Then
                    lblError.Visible = True
                End If
                lblError.Text = "This number has been registered for another employee, Please enter your number."
                txtMobile.Text = ""
                Exit Sub
                'txtMobile.Text = ""
            Else
                EditRecord(lnkEditMobile)
                lblError.Text = ""
            End If

        Else
            EditRecord(lnkEditMobile)
            lblError.Text = ""
        End If

    End Sub

    Protected Sub lnkEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkEdit.Click
        EditRecord(lnkEdit)
    End Sub

    'Protected Sub CustomValidator1_ServerValidate(ByVal source As Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles CustomValidator1.ServerValidate
    '    If txtMobile.Text.Length < 10 Then
    '        args.IsValid = False
    '    Else
    '        args.IsValid = True
    '    End If
    'End Sub
End Class
