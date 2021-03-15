Imports System.Data
Imports System.Data.SqlClient


Partial Class Default5
    Inherits System.Web.UI.Page

    Dim Obj As Connection = New Connection
Dim ObjFun As Functions= New Functions
    Public SqlPass As String
    Public flag As Boolean = False
    Public xcardno, Xpath1 As String
    Public Message As Integer = 0
    Public maxrows As Integer
    'Public count, count1 As Integer
    Public xempcode, xempcode1 As String
    Public save As Boolean = False
    Public ds As New DataSet
    Public confirmation As Boolean = False
    Public emailid As String



    Public Sub BindData()

        Try
            AdapterRecord()
            'SqlPass = " select Top 1 a.empcode,b.int_off,b.int_res,b.epb_off,b.epb_res,b.mobile,a.empname, a.cardno,replace(replace(a.desg,'<',' '),'>','') desg,a.dob,a.doj,left(E_mailId,len(e_mailid)-11) as e_mailid from jctdev..jct_empmast_base a ,jctdev..mistel b where  a.empcode=b.empcode and  a.deptcode='" + Mid(DDLDeptname.Text, 1, 4) + "' order by a.empname"
            SqlPass = " select top 1 empcode,cardno,deptcode,replace(replace(desg,'<',' '),'>','') desg ,empname,dob,doj,int_off,int_res,epb_off,epb_res, E_mailid       from  jct_emp_dept_hitesh       order by empname    "
            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

            If Dr.HasRows = True Then
                CmdMoveFirst.Enabled = False
                Cmdmovepre.Enabled = False
                cmdmovelast.Enabled = True
                CmdMoveNext.Enabled = True
                flag = Dr.HasRows
                Message = 1
                While Dr.Read()

                    Session("xempcode1") = Dr.Item("Empcode")
                    Me.txtempname.Text = Dr.Item("Empname")
                    Me.txtdesg.Text = IIf(Dr.Item("desg") Is System.DBNull.Value, "", Dr.Item("desg"))
                    Me.txtdob.Text = IIf(Dr.Item("dob") Is System.DBNull.Value, "", Dr.Item("dob"))
                    Me.txtdoj.Text = IIf(Dr.Item("doJ") Is System.DBNull.Value, "", Dr.Item("doJ"))
                    Me.txtintoff.Text = IIf(Dr.Item("INT_OFF") Is System.DBNull.Value, "", Dr.Item("INT_OFF"))
                    Me.txtextoff.Text = IIf(Dr.Item("INT_RES") Is System.DBNull.Value, "", Dr.Item("INT_RES"))
                    Me.txtepbxoff.Text = IIf(Dr.Item("EPB_OFF") Is System.DBNull.Value, "", Dr.Item("EPB_OFF"))
                    Me.txtepbxres.Text = IIf(Dr.Item("EPB_RES") Is System.DBNull.Value, "", Dr.Item("EPB_RES"))
                    ' Me.txtmobile.Text = IIf(Dr.Item("mobile") Is System.DBNull.Value, "", Dr.Item("mobile"))
                    Me.txtemailid.Text = IIf(Dr.Item("E_mailId") Is System.DBNull.Value, "", Dr.Item("E_mailId"))

                    xcardno = ""
                    xcardno = IIf(Dr.Item("cardno") Is System.DBNull.Value, "", Dr.Item("cardno"))
                    Dim fn As String = xcardno & ".jpg"
                    Me.PictureBox1.Visible = True
                    'Me.PictureBox1.ImageUrl = ("E:\\rajan-personal\jctdev-new-images\snaps\" & Trim(fn))
                    If xcardno = "" Then
                        PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\2.gif"
                    Else
                        PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\" & Trim(fn)
                    End If
                End While
            Else
                'SqlPass = "select Top 1 Empcode,empname ,cardno, replace(replace(desg,'<',' '),'>','') desg , dob , doj from jctdev..jct_empmast_base    where  deptcode='" + Mid(DDLDeptname.Text, 1, 4) + "' order by empname "
                SqlPass = "select  Top 1 empcode,cardno,replace(replace(desg,'<',' '),'>','') desg ,empname,dob,doj     from  jct_emp_dept_hitesh       order by empname    "
                If Dr.HasRows = True Then
                    CmdMoveFirst.Enabled = False
                    Cmdmovepre.Enabled = False
                    Message = 1
                    While Dr.Read()

                        Session("xempcode1") = Dr.Item("Empcode")
                        Me.txtempname.Text = Dr.Item("Empname")
                        Me.txtdesg.Text = Dr.Item("desg")
                        Me.txtdob.Text = Dr.Item("dob")
                        Me.txtdoj.Text = Dr.Item("doj")
                        Me.txtintoff.Text = ""
                        Me.txtextoff.Text = ""
                        Me.txtepbxoff.Text = ""
                        Me.txtepbxres.Text = ""
                        'Me.txtmobile.Text = ""
                        Me.txtemailid.Text = ""
                        xcardno = ""
                        xcardno = IIf(Dr.Item("cardno") Is System.DBNull.Value, "", Dr.Item("cardno"))
                        Dim fn As String = xcardno & ".jpg"
                        Me.PictureBox1.Visible = True
                        ' PictureBox1.ImageUrl = "E:\\rajan-personal\jctdev-new-images\snaps\" & Trim(fn)
                        If xcardno = "" Then
                            PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\" & " 2.gif"
                        Else
                            PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\" & Trim(fn)
                        End If

                    End While
                Else
                    PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\2.gif"
                End If


            End If
            Dr.Close()
            If Message <> 1 Then
                ClientScript.RegisterClientScriptBlock(Me.GetType, "scr", "<script language = javascript>alert('No Any Records For This Department')</script>")
                CmdMoveFirst.Enabled = False
                cmdmovelast.Enabled = False
                Cmdmovepre.Enabled = False
                CmdMoveNext.Enabled = False
                Me.txtempname.Text = ""
                Me.txtdesg.Text = ""
                Me.txtdob.Text = ""
                Me.txtdoj.Text = ""
                Me.txtintoff.Text = ""
                Me.txtextoff.Text = ""
                Me.txtepbxoff.Text = ""
                Me.txtepbxres.Text = ""
                'Me.txtmobile.Text = ""
                Me.txtemailid.Text = ""
                PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\2.jpg"
            End If
        Catch ex As Exception
            'MsgBox(" Errors :" & ex.Message, MsgBoxStyle.OkCancel)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
        Else
            Response.Redirect("~/login.aspx")
        End If
        If trim(Me.txtempname.Text) = trim(ObjFun.Get_empname(session("Empcode"), session("Companycode"))) Then
            Button1.enabled = True
        Else
            Button1.enabled = False
        End If

        If Not (Page.IsPostBack) Then
            SqlPass = "SELECT [DeptCode], [DeptName] FROM [DEPTMAST] ORDER BY [DEPTNAME]"
            ObjFun.FillList(DDLDeptname, SqlPass)

            'BindData()

            'Me.Button1.Attributes.Add("onclick", "if(confirm('Are u want to save')}{}else{ return }")

            'Button1.Attributes("onclick") = "javascript:confApprove();"
            Session("Count") = 0
            'DDLDeptname_SelectedIndexChanged(sender, e)
        End If

    End Sub

    'Protected Sub DDLDeptname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLDeptname.SelectedIndexChanged
    '    If (IsPostBack) Then
    '        Session("Count") = 0
    '        Session("xempcode1") = 0
    '        cmdmovelast.Enabled = True
    '        CmdMoveNext.Enabled = True
    '        BindData()
    '    End If
    'End Sub

    Private Sub AdapterRecord()

        SqlPass = "exec jctdev..jct_employee_dept_hosh '" & DDLDeptname.SelectedItem.Value & "','" & Session("CompanyCode") & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Dr.Close()
        '  Dim ds As DataSet = New DataSet()
        ds.Clear()
        Da.Fill(ds, "jctdev..jct_employee_dept")
        maxrows = ds.Tables("jctdev..jct_employee_dept").Rows.Count
        If maxrows = 1 Then
            CmdMoveNext.Enabled = False
            Cmdmovepre.Enabled = False
            CmdMoveFirst.Enabled = False
            cmdmovelast.Enabled = False
        End If
        Dr.Close()
    End Sub

    Private Sub AdapterRecordSelf()

        SqlPass = "exec jctdev..jct_employee_dept_hosh '" & Trim(Session("deptcode")) & "' "
        Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(SqlPass, Obj.Connection())
        Dr.Close()
        '  Dim ds As DataSet = New DataSet()
        ds.Clear()
        Da.Fill(ds, "jctdev..jct_employee_dept")
        maxrows = ds.Tables("jctdev..jct_employee_dept").Rows.Count
        If maxrows = 1 Then
            CmdMoveNext.Enabled = False
            Cmdmovepre.Enabled = False
            CmdMoveFirst.Enabled = False
            cmdmovelast.Enabled = False
        End If
        Dr.Close()
    End Sub

    Private Sub Navigation(ByVal i As Integer)

        Dim xcardno As String
        Try

            xempcode = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("EMPCODE")
            Session("xempcode1") = xempcode
            If ucase(Session("xempcode1")) = ucase(Session("Empcode")) Then
                Button1.Enabled = True
                Me.txtepbxoff.ReadOnly = False
                Me.txtepbxres.ReadOnly = False
                Me.txtextoff.ReadOnly = False
                Me.txtintoff.ReadOnly = False
                Me.txtemailid.ReadOnly = False
                'Me.txtmobile.ReadOnly = False


            Else
                Button1.Enabled = False
                Me.txtepbxoff.ReadOnly = True
                Me.txtepbxres.ReadOnly = True
                Me.txtextoff.ReadOnly = True
                Me.txtintoff.ReadOnly = True
                Me.txtemailid.ReadOnly = True
                'Me.txtmobile.ReadOnly = True

            End If
            Me.txtempname.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("Empname")

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("desg") Is System.DBNull.Value Then
                Me.txtdesg.Text = ""
            Else
                Me.txtdesg.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("desg")
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("dob") Is System.DBNull.Value Then
                Me.txtdob.Text = ""
            Else
                Me.txtdob.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("dob")
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("doj") Is System.DBNull.Value Then
                Me.txtdoj.Text = ""
            Else
                Me.txtdoj.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("doj")
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("INT_OFF") Is System.DBNull.Value Then
                Me.txtintoff.Text = 0
            Else
                Me.txtintoff.Text = CInt(ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("INT_OFF"))
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("INT_RES") Is System.DBNull.Value Then
                Me.txtextoff.Text = 0
            Else
                Me.txtextoff.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("INT_RES")
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("EPB_OFF") Is System.DBNull.Value Then
                Me.txtepbxoff.Text = 0
            Else
                Me.txtepbxoff.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("EPB_OFF")
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("EPB_RES") Is System.DBNull.Value Then
                Me.txtepbxres.Text = 0
            Else
                Me.txtepbxres.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("EPB_RES")
            End If

            'If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("mobile") Is System.DBNull.Value Then
            '    Me.txtmobile.Text = 0
            'Else
            '    Me.txtmobile.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("mobile")
            'End If

            'If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("mobile") Is System.DBNull.Value Then
            '    Me.txtmobile.Text = 0
            'Else
            '    Me.txtmobile.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("mobile")
            'End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("E_mailid") Is System.DBNull.Value Then
                Me.txtemailid.Text = ""
                'Me.txtemailid.Text =0 HITESH
            Else
                Me.txtemailid.Text = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("E_mailid")
            End If

            If ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("cardno") Is System.DBNull.Value Then

                PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\2.gif"
            Else
                xcardno = ""
                xcardno = ds.Tables("jctdev..jct_employee_dept").Rows(i).Item("cardno")

                If xcardno = "" Then
                    PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\2.gif"
                Else
                    Dim fn As String = xcardno & ".jpg"
                    Me.PictureBox1.Visible = True
                    'PictureBox1.ImageUrl = "E:\\rajan-personal\jctdev-new-images\snaps\" & Trim(fn)
                    PictureBox1.ImageUrl = "~\EmployeePortal\EmpImages\" & Trim(fn)
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub

    Private Sub CmdMoveFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdMoveFirst.Click
        Session("Count") = 0
        AdapterRecord()
        Navigation(0)
        CmdMoveFirst.Enabled = False
        Cmdmovepre.Enabled = False
        cmdmovelast.Enabled = True
        CmdMoveNext.Enabled = True
    End Sub
    Private Sub CmdMoveNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdMoveNext.Click

        If maxrows <= 0 Or save = True Then
            save = False
            AdapterRecord()
        End If
        Session("Count") = Session("Count") + 1
        If Session("Count") < maxrows - 1 Then
            Cmdmovepre.Enabled = True
            CmdMoveFirst.Enabled = True
            ' Session("Count") = Session("Count") + 1
        Else
            ' MsgBox("This is Last Record")
            CmdMoveNext.Enabled = False
            cmdmovelast.Enabled = False
            CmdMoveFirst.Enabled = True
            Cmdmovepre.Enabled = True
        End If
        Navigation(Session("Count"))
    End Sub

    Private Sub Cmdmovepre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Cmdmovepre.Click
        If maxrows <= 0 Or save = True Then
            save = False
            AdapterRecord()
        End If
        Session("Count") = Session("Count") - 1
        If Session("Count") > 0 Then
            CmdMoveNext.Enabled = True
            cmdmovelast.Enabled = True
            '  Session("Count") = Session("Count") - 1
        Else

            Cmdmovepre.Enabled = False
            CmdMoveFirst.Enabled = False
            CmdMoveNext.Enabled = True
            cmdmovelast.Enabled = True
        End If
        Navigation(Session("Count"))
    End Sub

    Private Sub cmdmovelast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdmovelast.Click
        AdapterRecord()

        Navigation(maxrows - 1)
        Session("Count") = maxrows - 1
        cmdmovelast.Enabled = False
        CmdMoveNext.Enabled = False
        Cmdmovepre.Enabled = True
        CmdMoveFirst.Enabled = True

    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtempname.text = "" Then
            ClientScript.RegisterClientScriptBlock(Me.GetType, "Scr", "<script language = javascript>alert('Employee Name Should Not Be Empty')</script>")
            Exit Sub
        End If
        'If confirmation = True Then
        ' Me.Button1.Attributes.Add("onclick", "return Confirm('Are u want to save ');")
        Try
            SqlPass = " select * from jctdev..mistel  where  empcode='" + Session("xempcode1") + "'"
            Dim Dr As SqlDataReader = Obj.FetchReader(SqlPass)

            If Dr.HasRows = True Then
                flag = Dr.HasRows
                Dr.Close()
            End If

            If Me.txtintoff.Text = "" Then
                Me.txtintoff.Text = 0
            End If

            If Me.txtextoff.Text = "" Then
                Me.txtextoff.Text = 0
            End If

            If Me.txtepbxres.Text = "" Then
                Me.txtepbxres.Text = 0
            End If

            If Me.txtepbxoff.Text = "" Then
                Me.txtepbxoff.Text = 0
            End If

            'If Me.txtemailid.Text = "" Then
            '    Me.txtemailid.Text = 0
            'End If

            'If Not (Page.IsPostBack) Then

            '  confirmation = Request.Form("JSApprResp").ToString()
            'If confirmation = True Then

            save = True
            If flag = True Then
                '''''Session("Loaction") changed to Session("CompanyCode") 
                'SqlPass = "update  jctdev..mistel set empcode='" & session("xempcode1") & "',name='" & Me.txtempname.Text & "',    designation='" & Me.txtdesg.Text & "',INT_OFF=' " & Me.txtintoff.Text & "',INT_RES='" & Me.txtextoff.Text & "',EPB_OFF=' " & Me.txtepbxoff.Text & "',EPB_RES='" & Me.txtepbxres.Text & "',MOBILE=' " & Me.txtmobile.Text & " ',E_mailId=' " & Trim(Me.txtemailid.Text) & Trim(Me.txtdomain.Text) & " ' where empcode= '" & session("xempcode1") & "'"
                'SqlPass = "update  jctdev..mistel set empcode='" & Session("xempcode1") & "',name='" & Me.txtempname.Text & "',    designation='" & Me.txtdesg.Text & "',INT_OFF=' " & Me.txtintoff.Text & "',INT_RES='" & Me.txtextoff.Text & "',EPB_OFF=' " & Me.txtepbxoff.Text & "',EPB_RES='" & Me.txtepbxres.Text & "' where empcode= '" & Session("xempcode1") & "'"
                SqlPass = "update  jctdev..mistel set empcode='" & Session("xempcode1") & "',name='" & Me.txtempname.Text & "',    designation='" & Me.txtdesg.Text & "',INT_OFF=' " & Me.txtintoff.Text & "',INT_RES='" & Me.txtextoff.Text & "',EPB_OFF=' " & Me.txtepbxoff.Text & "',EPB_RES='" & Me.txtepbxres.Text & "',E_mailId=' " & Trim(Trim(Me.txtemailid.Text) & "@jctltd.com") & " ', company_code='" & Session("CompanyCode") & " ' where empcode= '" & Session("xempcode1") & "'"
                Obj.FetchReader(SqlPass)
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Scr", "<script language = javascript>alert('Thanks For Update')</script>")

                confirmation = True
                Dr.Close()
                'DDLDeptname_SelectedIndexChanged(e, Nothing)
            Else
                Dr.Close()
                SqlPass = "insert into  jctdev..mistel(empcode,name,designation,INT_OFF,INT_RES,EPB_OFF,EPB_RES,E_mailid,company_code) VALUES('" & Session("xempcode1") & "','" & Trim(Me.txtempname.Text) & "','" & Trim(Me.txtdesg.Text) & "', " & Trim(Me.txtintoff.Text) & "," & Trim(Me.txtextoff.Text) & ", " & Trim(Me.txtepbxoff.Text) & "," & Trim(Me.txtepbxres.Text) & ",' " & Trim(Trim(Me.txtemailid.Text) & "@jctltd.com") & " ', '" & Session("CompanyCode") & " ') "
                ' SqlPass = "insert into  jctdev..mistel(empcode,name,designation,INT_OFF,INT_RES,EPB_OFF,EPB_RES) VALUES('" & Session("xempcode1") & "','" & Trim(Me.txtempname.Text) & "','" & Trim(Me.txtdesg.Text) & "', " & Trim(Me.txtintoff.Text) & "," & Trim(Me.txtextoff.Text) & ", " & Trim(Me.txtepbxoff.Text) & "," & Trim(Me.txtepbxres.Text) & ") "
                'SqlPass = "insert into  jctdev..mistel(empcode,name,designation,INT_OFF,INT_RES,EPB_OFF,EPB_RES,MOBILE,E_mailid) VALUES('" & session("xempcode1") & "','" & Trim(Me.txtempname.Text) & "','" & Trim(Me.txtdesg.Text) & "', " & Trim(Me.txtintoff.Text) & "," & Trim(Me.txtextoff.Text) & ", " & Trim(Me.txtepbxoff.Text) & "," & Trim(Me.txtepbxres.Text) & ",' " & Trim(Me.txtmobile.Text) & " ',' " & Trim(Trim(Me.txtemailid.Text) & Trim(Me.txtdomain.Text)) & " ') "
                Obj.FetchReader(SqlPass)
                ClientScript.RegisterClientScriptBlock(Me.GetType, "Scr", "<script language = javascript>alert('Thanks For Insertion')</script>")
                flag = True
                confirmation = True
                Dr.Close()
                ' DDLDeptname_SelectedIndexChanged(e, Nothing)
            End If
            'End If
            Button1.Enabled = False
            Me.txtepbxoff.ReadOnly = True
            Me.txtepbxres.ReadOnly = True
            Me.txtextoff.ReadOnly = True
            Me.txtintoff.ReadOnly = True
            Me.txtemailid.ReadOnly = True
        Catch ex As Exception

        Finally
            Obj.ConClose()
        End Try
        'End If


    End Sub

   

    Protected Sub DDLDeptname_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLDeptname.SelectedIndexChanged
        'AdapterRecord()
        BindData()
    End Sub
End Class
 