Imports System.Data.SqlClient
Imports System.IO
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

'Imports iTextSharp.text
'Imports iTextSharp.text.pdf

Partial Class Default4
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String
    Dim i As Integer
    Dim yr, dys As Integer
    Public dr As SqlDataReader
    Dim strFileName As String
    Dim c As String, empcode As String
  
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("Empcode").ToString <> "") Then
            empcode = Session("Empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not IsPostBack Then
            Me.LnkReply1.Visible = False
            Me.LnkReply2.Visible = False
            Me.LnkReply3.Visible = False
            Me.LnkReply4.Visible = False
            Me.LnkReply5.Visible = False
            ' Response.Write("")
            Me.PnlGrid.Collapsed = True
            Me.PnlHistory.Collapsed = True
            Me.PnlRec.Collapsed = True
            Me.txtHistory.Enabled = False
            Me.txtTaskNo.Enabled = False
            Me.DrpTaskStatus.Enabled = False
            Me.PnlReply.Collapsed = True
            Me.DrpPriority.Text = "Normal"
            Me.PnlReply.Enabled = False
            Me.DrpSelection.Visible = False
            Me.txtTaskNo.Visible = False
            'Me.cmdReAssign.Enabled = False
            obj.opencn()
            qry = "select task_type from JCT_OPS_Task_Type_Master where company_code='" & Session("Companycode") & "' and status='' order by task_type"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.DrpTaskType.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    Me.DrpTaskType.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()

            obj.opencn()
            qry = "select area from JCT_OPS_Area_Master where company_code='" & Session("Companycode") & "' and status='' order by area"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            Me.DrpArea.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    Me.DrpArea.Items.Add(Trim(dr.Item(0)))
                End While
            End If
            dr.Close()
            obj.closecn()

            DrpArea_SelectedIndexChanged(sender, e)
            If Request.QueryString.Get("reply") = 1 Or Request.QueryString.Get("reply") = 2 Then
                Me.LnkAssign.Visible = False
                Me.LnkReply.Visible = False
                Me.DrpSelection.Text = "Reply"
                obj.opencn()
                qry = "select * from jct_ops_task_log where company_code='" & Session("Companycode") & "' and task_no='" & Request.QueryString.Get("task") & "'"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read()
                        Me.DrpTaskType.Text = Trim(dr.Item("Task_Type"))
                        Me.DrpArea.Text = Trim(dr.Item("area"))
                        Me.DrpSubArea.SelectedValue = Trim(dr.Item("subarea"))
                        If Trim(dr.Item("trans_type")) <> "" Then
                            Me.DrpTranType.Text = dr.Item("trans_type")
                        End If
                        Me.DrpPriority.Text = Trim(dr.Item("task_priority"))
                        Me.DrpTaskStatus.Text = Trim(dr.Item("Task_status"))

                        If dr.Item("due_date") <> "01/01/1900" Then
                            Me.txtduedate.SelectedDate = Trim(dr.Item("due_date"))
                        End If
                        '  Me.ClDueDate.SelectedDate = Trim(dr.Item("due_date"))
                        Me.txtHistory.Text = Trim(dr.Item("history"))
                        Me.txtJobDescr.Text = Trim(dr.Item("job_descr"))
                        If dr.Item("task_ref_date") <> "01/01/1900" Then
                            Me.txtRefDate.SelectedDate = Trim(dr.Item("task_ref_date"))
                            ' Me.ClRefDate.SelectedDate = Trim(dr.Item("task_ref_date"))
                        End If
                        Me.txtSub.Text = Trim(dr.Item("subject"))
                        Me.txtTaskNo.Text = Trim(dr.Item("task_no"))
                        Me.txtTaskRef.Text = Trim(dr.Item("task_ref"))
                        Me.txtTransNo.Text = Trim(dr.Item("Tran_No"))
                    End While



                    Me.PnlGrid.Collapsed = False
                    Me.PnlHistory.Collapsed = False
                    Me.DrpTaskStatus.Enabled = True
                    Me.PnlReply.Collapsed = False
                    Me.PnlReply.Enabled = True
                    'Me.cmdCC.Enabled = False
                    'Me.cmdTo.Enabled = False
                    Me.cmdDel.Enabled = False
                    Me.ChkAuth.Enabled = False

                    Me.txtJobDescr.Enabled = False

                    Me.txtSub.Enabled = False
                    Me.txtTaskRef.Enabled = False
                    Me.txtTransNo.Enabled = False
                    Me.DrpArea.Enabled = False
                    Me.DrpPriority.Enabled = False
                    Me.DrpSubArea.Enabled = False
                    Me.DrpTaskType.Enabled = False
                    Me.DrpTranType.Enabled = False
                    Me.FlAttcAssn.Enabled = False
                    Me.cmdAttachAssn.Enabled = False
                    Me.cmdFetch.Enabled = False
                    'Me.cmdReAssign.Enabled = True


                Else
                    Response.Write("<script>alert('No such Task exists in Record..')</script>")
                    Exit Sub
                    dr.Close()
                    obj.closecn()
                End If
                dr.Close()
                obj.closecn()

                DrpSubArea_SelectedIndexChanged(Nothing, Nothing)
                cmdFetch_Click(sender, Nothing)
                Me.PnlGrid.Collapsed = True
                obj.opencn()
                qry = "select b.empcode + ':-' + b.empname from jct_ops_task_recepients a, jct_empmast_base b where a.company_code=b.company_code and a.company_code='" & Session("Companycode") & "' and a.recp_code=b.empcode and a.flag='t' and task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                Me.ChkTo.Items.Clear()
                If dr.HasRows = True Then
                    While dr.Read()
                        Me.ChkTo.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()

                obj.opencn()
                qry = "select b.empcode + ':-' + b.empname from jct_ops_task_recepients a, jct_empmast_base b where a.company_code=b.company_code and a.company_code='" & Session("Companycode") & "' and a.recp_code=b.empcode and a.flag='c' and task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                Me.ChkCC.Items.Clear()
                '  Me.ChkFrom.Items.Clear()
                If dr.HasRows = True Then
                    While dr.Read()
                        Me.ChkCC.Items.Add(dr.Item(0))
                    End While
                End If
                dr.Close()
                obj.closecn()
                Dim cnt As Integer
                obj.opencn()
                qry = "select * from JCT_OPS_Task_File_Dir where company_code='" & Session("Companycode") & "' and task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                cmd = New SqlCommand(qry, obj.cn)
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    While dr.Read()
                        If UCase(dr.Item("flag")) = "A" Then
                            Me.LnkAssign.Visible = True
                            Me.LnkAssign.Text = dr.Item("file_nm")
                            Me.LnkAssign.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\AssignTask") & Trim(Me.txtTaskNo.Text) & "/" & Trim(Me.LnkAssign.Text)
                        Else
                            cnt = cnt + 1
                            If cnt = 1 Then
                                Me.LnkReply1.Visible = True
                                Me.LnkReply1.Text = dr.Item("file_nm")
                                Me.LnkReply1.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\ReplyTask\") & Trim(Me.txtTaskNo.Text) & "/" & Trim(Me.LnkReply1.Text)
                            ElseIf cnt = 2 Then
                                Me.LnkReply2.Visible = True
                                Me.LnkReply2.Text = dr.Item("file_nm")
                                Me.LnkReply2.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\ReplyTask\") & Trim(Me.txtTaskNo.Text) & "/" & Trim(Me.LnkReply2.Text)
                            ElseIf cnt = 3 Then
                                Me.LnkReply3.Visible = True
                                Me.LnkReply3.Text = dr.Item("file_nm")
                                Me.LnkReply3.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\ReplyTask\") & Trim(Me.txtTaskNo.Text) & "/" & Trim(Me.LnkReply3.Text)
                            ElseIf cnt = 4 Then
                                Me.LnkReply4.Visible = True
                                Me.LnkReply4.Text = dr.Item("file_nm")
                                Me.LnkReply4.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\ReplyTask\") & Trim(Me.txtTaskNo.Text) & "/" & Trim(Me.LnkReply4.Text)
                            ElseIf cnt = 5 Then
                                Me.LnkReply5.Visible = True
                                Me.LnkReply5.Text = dr.Item("file_nm")
                                Me.LnkReply5.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\ReplyTask\") & Trim(Me.txtTaskNo.Text) & "/" & Trim(Me.LnkReply5.Text)
                            End If

                            'Dim lnknew As New HyperLink
                            'Me.LnkReply.ID = "lnkReply" & cnt
                            'lnknew.ID = "LnkReply"
                            'lnknew.Text = "LnkReply"
                            'Controls.Add(lnknew)

                        End If
                    End While
                End If
                dr.Close()
                obj.closecn()
                Me.txtReply.Focus()
            Else ''If Request.QueryString.Get("reply") = 2 Then
                '' Me.ChkAuth.Enabled = False
                Me.LnkAssign.Visible = False
            End If
            If Request.QueryString.Get("reply") = 2 Then
                Me.ChkAuth.Enabled = True
                Me.DrpTaskStatus.Items.Add("Cancelled")
            End If
            If Trim(Me.DrpTaskStatus.Text) = "Cancelled" Then
                Me.cmdSubmit.Enabled = False
            End If
        End If
    End Sub

    Protected Sub DrpArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpArea.SelectedIndexChanged
        obj.opencn()
        qry = "select subarea from JCT_OPS_Sub_Area_Master where company_code='" & Session("Companycode") & "' and area ='" & Trim(Me.DrpArea.Text) & "' and status='' order by subarea"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpSubArea.Items.Clear()
        If dr.HasRows = True Then
            While dr.Read()
                Me.DrpSubArea.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()
        DrpSubArea_SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub DrpSubArea_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpSubArea.SelectedIndexChanged
        obj.opencn()
        ' qry = "select e_mailID from JCT_OPS_Sub_Area_Responsibility a, savior..mistel b where a.res_emp= b.empcode and status = '' and resp_flag='R' and area='" & Trim(Me.DrpArea.Text) & "' and subarea='" & Trim(Me.DrpSubArea.Text) & "' "
        qry = "select a.empcode + ':-' + empname,'a' as seq from jct_empmast_base a, JCT_OPS_Area_Master b, deptmast c where a.company_code=b.company_code and b.company_code=c.company_code and b.company_code = '" & Session("Companycode") & "' and a.deptcode=b.area_code and a.deptcode=c.deptcode and a.active='y' and a.empcode not in (select res_emp from JCT_OPS_Sub_Area_Responsibility where company_code='" & Session("Companycode") & "' and status='' and area = '" & Trim(Me.DrpArea.Text) & "' and subarea='" & Trim(Me.DrpSubArea.Text) & "') and area='" & Trim(Me.DrpArea.Text) & "' union select empcode+ ':-' + empname , 'b' from jct_empmast_base where company_code = '" & Session("Companycode") & "' and active='y' and deptcode not in (select b.area_code from JCT_OPS_Area_Master b,  deptmast c where b.company_code=c.company_code and b.company_code = '" & Session("Companycode") & "' and b.area_code=c.deptcode and area='" & Trim(Me.DrpArea.Text) & "') order by seq,a.empcode + ':-' + empname"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.ChkFrom.Items.Clear()
        If dr.HasRows = True Then
            While dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                Else
                    Me.ChkFrom.Items.Add(Trim(dr.Item(0)))
                    Me.ChkFrom.Items(Me.ChkFrom.Items.Count - 1).Value = "N"
                End If

            End While
        End If
        dr.Close()
        obj.closecn()
        Me.ChkTo.Items.Clear()
        obj.opencn()
        qry = "select a.empcode + ':-' + empname from jct_empmast_base a, JCT_OPS_Sub_Area_Responsibility b where a.company_code=b.company_code and a.company_code = '" & Session("Companycode") & "' and a.empcode=res_emp and b.status='' and a.active='y' and area = '" & Trim(Me.DrpArea.Text) & "' and subarea='" & Trim(Me.DrpSubArea.Text) & "' and resp_flag='r' order by a.empcode + ':-' + empname"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                Else
                    Me.ChkTo.Items.Add(Trim(dr.Item(0)))
                    Me.ChkTo.Items(Me.ChkTo.Items.Count - 1).Value = "N"
                End If
            End While
        End If
        dr.Close()
        obj.closecn()
        Me.ChkCC.Items.Clear()
        obj.opencn()
        '      qry = "select a.empcode + ':-' + empname,'a' as seq from jct_empmast_base a, JCT_OPS_Area_Master b, deptmast c where a.deptcode=b.area_code and a.deptcode=c.deptcode and a.active='y' and a.empcode  in (select res_emp from JCT_OPS_Sub_Area_Responsibility where status='' and area = '" & Trim(Me.DrpArea.Text) & "' and subarea='" & Trim(Me.DrpSubArea.Text) & "' and resp_flag='o') order by seq,a.empcode + ':-' + empname"
        qry = "select a.empcode + ':-' + empname from jct_empmast_base a, JCT_OPS_Sub_Area_Responsibility b where a.company_code=b.company_code and a.company_code = '" & Session("Companycode") & "' and a.empcode=res_emp and b.status='' and a.active='y' and area = '" & Trim(Me.DrpArea.Text) & "' and subarea='" & Trim(Me.DrpSubArea.Text) & "' and resp_flag='o' order by a.empcode + ':-' + empname"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                Else
                    Me.ChkCC.Items.Add(Trim(dr.Item(0)))
                    Me.ChkCC.Items(Me.ChkCC.Items.Count - 1).Value = "N"
                End If

            End While
        End If
        dr.Close()
        obj.closecn()

        obj.opencn()
        qry = "select trans_type from JCT_OPS_Trans_Type_Mapping where company_code='" & Session("Companycode") & "'  and status='' and area='" & Trim(Me.DrpArea.Text) & "' and subarea='" & Trim(Me.DrpSubArea.Text) & "' "
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Me.DrpTranType.Items.Clear()
        If dr.HasRows = True Then
            While dr.Read()
                Me.DrpTranType.Items.Add(Trim(dr.Item(0)))
            End While
        End If
        dr.Close()
        obj.closecn()
    End Sub

    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        Dim ds As New Data.DataSet
        Dim drow As Data.DataRow

        Dim dt As New Data.DataTable
        Dim cl(11) As String
        Dim cust, po, shd As String
        obj.opencn()
        Me.PnlGrid.Collapsed = False
        qry = "exec JCT_Cust_invoice_dtl 'JCT00LTD','" & Me.txtTransNo.Text & "'"
        cmd = New SqlCommand(qry, obj.cn)
        cmd.CommandTimeout = 0
        dr = cmd.ExecuteReader

        Dim i As Integer
        cl(0) = "Invoice Date"
        cl(1) = "Customer Name"
        cl(2) = "Location"
        cl(3) = "Order No"
        cl(4) = "Shade"
        cl(5) = "Bale No"
        cl(6) = "Sort No"
        cl(7) = "Variant"
        cl(8) = "Class"
        cl(9) = "Meters"
        cl(10) = "Amount"

        For i = 0 To 10
            Dim dc As New Data.DataColumn
            dc.ColumnName = cl(i)
            dt.Columns.Add(dc)
        Next

        If dr.HasRows = True Then
            While dr.Read()
                drow = dt.NewRow()
                dt.Rows.Add(drow)
                If dt.Rows.Count = 1 Then
                    drow(0) = Trim(dr.Item(0))
                    drow(10) = Trim(dr.Item("invoice_net_amt"))
                End If
                drow(5) = Trim(dr.Item("lot_no"))
                drow(6) = Trim(dr.Item("item_no"))
                drow(7) = Trim(dr.Item("variant"))
                If dr.Item("class") Is System.DBNull.Value Then
                Else
                    drow(8) = Trim(dr.Item("class"))
                End If

                drow(9) = dr.Item("meters")

                If cust <> Trim(dr.Item("cust_name")) Then
                    drow(1) = Trim(dr.Item("cust_name"))
                    drow(2) = Trim(dr.Item("city")) & "," & Trim(dr.Item("state"))
                    cust = Trim(dr.Item("cust_name"))
                End If
                If cust <> Trim(dr.Item("cust_name")) Or po <> Trim(dr.Item("order_no")) Then
                    drow(3) = Trim(dr.Item("order_no"))
                    po = Trim(dr.Item("order_no"))
                End If
                If cust <> Trim(dr.Item("cust_name")) Or po <> Trim(dr.Item("order_no")) Or shd <> Trim(dr.Item("shade_design")) Then
                    drow(4) = Trim(dr.Item("shade_design"))
                    shd = Trim(dr.Item("shade_design"))
                End If
            End While
        End If

        GridTran.DataSource = dt
        GridTran.DataBind()
        dr.Close()
        obj.closecn()

    End Sub

    Public Function CheckFileName(ByVal c As String, ByVal Flag As Char)

        ''Flag 'A' while assigning task.. 'R' while replying
        obj.opencn()
        qry = "select * from JCT_OPS_Task_File_Dir a, jct_ops_task_log b where a.company_code=b.company_code and a.company_code = '" & Session("Companycode") & "' and a.task_no=b.task_no and a.emp_code=b.emp_code and a.flag='" & Flag & "' and a.file_nm='" & c & "' and a.task_no='" & Trim(Me.txtTaskNo.Text) & "'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
            Else
                CheckFileName = 1
            End If

        End If
        dr.Close()
        obj.closecn()

    End Function

    'Protected Sub CmdAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAssign.Click
    '    Dim strFileName As String = FileAssign.PostedFile.FileName
    '    Dim c As String = System.IO.Path.GetFileName(strFileName)
    '    If CheckFileName(c, "a") = 1 Then
    '        Response.Write("<script>alert('File with this name already exists in Directory. Please Rename File and try again..')</script>")
    '        Exit Sub
    '    End If


    '    ' Save uploaded file to server at C:\ServerFolder\
    '    Try
    '        obj.opencn()
    '        qry = "insert into JCT_OPS_Task_File_Dir values ('JCT00LTD','','" & Trim(Me.txtTaskNo.Text) & "','" & c & "','A',host_name(),getdate())"
    '        cmd = New SqlCommand(qry, obj.cn)
    '        cmd.ExecuteNonQuery()
    '        obj.closecn()
    '        'Response.Write("<script>alert('Reply Sent Successfully!!')</script>")
    '        FileAssign.PostedFile.SaveAs("C:\Inetpub\wwwroot\testweb\AssignTask\" + c)
    '        'MyFile.PostedFile.SaveAs("D:/" + c)

    '        lblSpan.Text = "Your File Uploaded Sucessfully at server as: " & c
    '    Catch Exp As Exception
    '        Response.Write(Exp.ToString())
    '        lblSpan.Text = "An Error occured. Please check the attached  file"
    '        'UploadDetails.visible = False
    '        'Span2.visible = False
    '    End Try
    'End Sub


    'Protected Sub cmdReply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdReply.Click
    '    Dim strFileName As String = FileAssign.PostedFile.FileName
    '    Dim c As String = System.IO.Path.GetFileName(strFileName)
    '    If CheckFileName(c, "r") = 1 Then
    '        Response.Write("<script>alert('File with this name already exists in Directory. Please Rename File and try again..')</script>")
    '        Exit Sub
    '    End If


    '    'Save uploaded file to server at C:\ServerFolder\
    '    Try
    '        obj.opencn()
    '        qry = "insert into JCT_OPS_Task_File_Dir values ('JCT00LTD','','" & Trim(Me.txtTaskNo.Text) & "','" & c & "','R',host_name(),getdate())"
    '        cmd = New SqlCommand(qry, obj.cn)
    '        cmd.ExecuteNonQuery()
    '        obj.closecn()
    '        'Response.Write("<script>alert('Reply Sent Successfully!!')</script>")
    '        FileAssign.PostedFile.SaveAs("C:\Inetpub\wwwroot\testweb\AssignTask\" + c)
    '        'MyFile.PostedFile.SaveAs("D:/" + c)

    '        lblSpan.Text = "Your File Uploaded Sucessfully at server as: " & c
    '    Catch Exp As Exception
    '        Response.Write(Exp.ToString())
    '        lblSpan.Text = "An Error occured. Please check the attached  file"
    '        'UploadDetails.visible = False
    '        'Span2.visible = False
    '    End Try
    'End Sub


    Protected Sub cmdTo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTo.Click
        For i = 0 To Me.ChkFrom.Items.Count - 1
            If i <= Me.ChkFrom.Items.Count - 1 Then
                If Me.ChkFrom.Items(i).Selected = True Then
                    Me.ChkTo.Items.Add(Me.ChkFrom.Items(i).Text)
                    Me.ChkFrom.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next
    End Sub


    Protected Sub cmdDel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDel.Click

        For i = 0 To Me.ChkTo.Items.Count - 1
            If i <= Me.ChkTo.Items.Count - 1 Then
                If Me.ChkTo.Items(i).Selected = True And Me.ChkTo.Items(i).Value <> "N" Then
                    Me.ChkFrom.Items.Add(Me.ChkTo.Items(i).Text)
                    Me.ChkTo.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next

        For i = 0 To Me.ChkCC.Items.Count - 1
            If i <= Me.ChkCC.Items.Count - 1 Then
                If Me.ChkCC.Items(i).Selected = True And Me.ChkCC.Items(i).Value <> "N" Then
                    Me.ChkFrom.Items.Add(Me.ChkCC.Items(i).Text)
                    Me.ChkCC.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next
    End Sub

    Protected Sub cmdCC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCC.Click
        For i = 0 To Me.ChkFrom.Items.Count - 1
            If i <= Me.ChkFrom.Items.Count - 1 Then
                If Me.ChkFrom.Items(i).Selected = True Then
                    Me.ChkCC.Items.Add(Me.ChkFrom.Items(i).Text)
                    Me.ChkFrom.Items.RemoveAt(i)
                    i = i - 1
                End If
            End If
        Next
    End Sub

    Protected Sub cmdAttachAssn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAttachAssn.Click
        If Me.cmdAttachAssn.Text = "Attach File" Then
            Me.LnkAssign.Visible = True
            strFileName = FlAttcAssn.PostedFile.FileName
            c = System.IO.Path.GetFileName(strFileName)
            'If CheckFileName(c, "a") = 1 Then
            '    Response.Write("<script>alert('File with this name already exists in Directory. Please Rename File and try again..')</script>")
            '    Exit Sub
            'End If
            Me.LnkAssign.Text = c

            obj.opencn()
            qry = "select max(convert(integer,right(task_no,len(task_no)-5)))+1 from JCT_OPS_Task_File_Dir "
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    Session("task") = "T1"
                Else
                    Session("task") = "T" & Trim(dr.Item(0))
                End If
            Else
                Session("task") = "T1"
            End If
            dr.Close()
            obj.closecn()
            obj.opencn()
            'Session("Task") = Session("Task") + 1
            qry = "insert into JCT_OPS_Task_File_Dir values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(Session("Task")) & "','" & Me.LnkAssign.Text & "','A',host_name(),getdate())"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            ''Dim fldname As String
            ''fldname = "testFolder"
            ''Dim nwFld As New DirectoryInfo(Server.MapPath("/AssignTask/" + fldname))
            ''If nwFld.Exists = False Then nwFld.Create()


            FlAttcAssn.PostedFile.SaveAs(Server.MapPath("~\EmpGateway\AssignTask") + Me.LnkAssign.Text)
            Me.LnkAssign.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\AssignTask\") & c
            Me.cmdAttachAssn.Text = "Remove File"
            Me.FlAttcAssn.Enabled = False
        ElseIf Me.cmdAttachAssn.Text = "Remove File" Then
            Me.LnkAssign.Visible = False
            System.IO.File.Delete(Server.MapPath("~\EmpGateway\AssignTask") + Me.LnkAssign.Text)
            obj.opencn()
            qry = "delete from JCT_OPS_Task_File_Dir where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkAssign.Text & "' and task_no='" & Session("Task") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            Me.cmdAttachAssn.Text = "Attach File"
            Me.LnkAssign.Text = ""
            Me.LnkAssign.NavigateUrl = ""
            Me.FlAttcAssn.Enabled = True
        End If

    End Sub

    Protected Sub cmdSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSubmit.Click
        Dim auth_flag As Char
        Dim task_no As String
        Dim ob As New Login
        Dim toVal, SubVal, bodyVal, fromVal, ccval As String
        Dim MailSmpt As New Mail.MailMessage

        ''If InStr(Me.txtReply.Text, "'") > 0 Then
        ''    Exit Sub
        ''End If
        ''If InStr(Me.txtSub.Text, "'") > 0 Then
        ''    Exit Sub
        ''End If
        ''If InStr(Me.txtJobDescr.Text, "'") > 0 Then
        ''    Exit Sub
        ''End If
        ''If InStr(Me.txtTaskRef.Text, "'") > 0 Then
        ''    Exit Sub
        ''End If
        obj.opencn()
        Dim Trans As SqlTransaction = obj.cn.BeginTransaction()
        Try
            If Me.ChkAuth.Checked = True Then
                auth_flag = "A"
            Else
                auth_flag = " "
            End If
            If Me.DrpSelection.Text = "Assign Task" Then
                If Trim(Me.txtJobDescr.Text) = "" Or Trim(Me.txtSub.Text) = "" Then
                    System.IO.File.Delete(Server.MapPath("~\EmpGateway\ReplyTask\") + Me.LnkReply.Text)
                    'System.IO.File.Delete("~/EmpGateway/ReplyTask/" + Me.LnkReply.Text)
                    obj.opencn()
                    qry = "delete from JCT_OPS_Task_File_Dir where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkReply.Text & "' and task_no='" & Session("Task") & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()
                    obj.closecn()
                    Response.Write("<script>alert('Please give Subject and Description.. Both are Compulsory..')</script>")
                    Exit Sub
                End If
                'obj.opencn()

                qry = "select max(convert(integer,right(task_no,len(task_no)-5)))+1 from jct_ops_task_log "
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                        task_no = 1
                    Else
                        task_no = dr.Item(0)
                    End If
                Else
                    task_no = 1
                End If
                dr.Close()
                'obj.closecn()
                Me.txtTaskNo.Text = "0809I" & task_no
                task_no = Me.txtTaskNo.Text
                'obj.opencn()

                Me.txtHistory.Text = Session("empname") & ":" & Now() & ":-" & Trim(Me.txtJobDescr.Text)
                qry = "insert into jct_ops_task_log (Company_code,Emp_Code,Task_No, Task_Type,Task_Priority, Area, SubArea, Log_SysDate,Task_Ref, Task_Ref_Date,Subject,Trans_Type,Tran_no,Job_Descr,Task_Status,Due_Date,Authorize,History, Status) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & task_no & "','" & Trim(Me.DrpTaskType.Text) & "','" & Trim(Me.DrpPriority.Text) & "','" & Trim(Me.DrpArea.Text) & "','" & Trim(Me.DrpSubArea.Text) & "',getdate(),'" & Replace(Me.txtTaskRef.Text, "'", "''") & "','" & Trim(Me.txtRefDate.SelectedDate) & "','" & Replace(Trim(Me.txtSub.Text), "'", "''") & "','" & Trim(Me.DrpTranType.Text) & "','" & Trim(Me.txtTransNo.Text) & "','" & Replace(Trim(Me.txtJobDescr.Text), "'", "''") & "','" & Trim(Me.DrpTaskStatus.Text) & "','" & Trim(Me.txtduedate.SelectedDate) & "','" & auth_flag & "','" & Replace(Trim(Me.txtHistory.Text), "'", "''") & "','')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()
                'obj.closecn()




                If Trim(Me.LnkAssign.Text) <> "LnkAssign" And Trim(Me.LnkAssign.Text) <> "" Then
                    Dim fldname As String
                    fldname = task_no
                    Dim nwFld As New DirectoryInfo(Server.MapPath("~\EmpGateway\AssignTask") + fldname)
                    If nwFld.Exists = False Then nwFld.Create()

                    File.Move(Server.MapPath("~\EmpGateway\AssignTask") & Me.LnkAssign.Text, Server.MapPath("~\EmpGateway\AssignTask") & fldname & "/" & Me.LnkAssign.Text)

                    'obj.opencn()
                    qry = "update JCT_OPS_Task_File_Dir set task_no='" & Trim(Me.txtTaskNo.Text) & "' where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkAssign.Text & "' and task_no='" & Session("Task") & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()
                    '  obj.closecn()

                    'FlAttcAssn.PostedFile.SaveAs("C:\Inetpub\wwwroot\testweb\AssignTask\" + Me.LnkAssign.Text)
                    'Me.LnkAssign.Text = c
                    'Me.LnkAssign.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & "C:\Inetpub\wwwroot\testweb\AssignTask\" & c

                End If

                For i = 0 To Me.ChkTo.Items.Count - 1
                    'obj.opencn()
                    qry = "select e_mailid,name from mistel where company_code='" & Session("Companycode") & "' and empcode=ltrim('" & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "')"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        If dr.Item(0) Is System.DBNull.Value Then
                        Else
                            If Trim(toVal) = "" Then
                                bodyVal = Trim(dr.Item(1))
                                toVal = Trim(dr.Item(0))
                            Else
                                toVal = toVal & ";" & Trim(dr.Item(0))
                                bodyVal = bodyVal & "," & Trim(dr.Item(1))
                            End If

                        End If
                        bodyVal = bodyVal & "(in `To`) "
                    End If
                    dr.Close()
                    'obj.closecn()
                    ' obj.opencn()
                    qry = "insert into  jct_ops_task_recepients (Company_code,Emp_Code,Task_No,Recp_Code,Flag,history) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & task_no & "',ltrim(' " & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "'),'T','')"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()
                    'obj.closecn()
                Next

                For i = 0 To Me.ChkCC.Items.Count - 1
                    'obj.opencn()
                    qry = "select e_mailid,name from mistel where company_code='" & Session("Companycode") & "' and empcode='" & Left(Me.ChkCC.Items(i).Text, InStr(Me.ChkCC.Items(i).Text, ":-") - 1) & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        bodyVal = bodyVal & " And "
                        dr.Read()
                        If dr.Item(0) Is System.DBNull.Value Then
                        Else

                            If Trim(ccval) = "" Then
                                bodyVal = bodyVal & Trim(dr.Item(1))
                                ccval = Trim(dr.Item(0))
                            Else
                                bodyVal = bodyVal & "," & Trim(dr.Item(1))
                                ccval = ccval & ";" & Trim(dr.Item(0))
                            End If
                        End If
                        bodyVal = bodyVal & " (in CC) "
                    End If
                    dr.Close()
                    'obj.closecn()

                    'obj.opencn()
                    qry = "insert into jct_ops_task_recepients (Company_code,Emp_Code,Task_No,Recp_Code,Flag,history) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & task_no & "','" & Left(Me.ChkCC.Items(i).Text, InStr(Me.ChkCC.Items(i).Text, ":-") - 1) & "','C','')"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()
                    ' obj.closecn()
                Next

                Response.Write("<script>alert('Task Logged Successfully!!')</script>")

                SubVal = Me.txtSub.Text
                'bodyVal = bodyVal & " have received a task from " & Session("empname") & " which says: " & Me.txtJobDescr.Text
                bodyVal = "You Have Got a Task from " & Session("empname") & " which says: " & Me.txtJobDescr.Text & vbCrLf & vbCrLf

            ElseIf Me.DrpSelection.Text = "Reply" Then
                If Trim(Me.txtReply.Text) = "" Then
                    Response.Write("<script>alert('Please Add ur Reply!!')</script>")
                    Me.txtReply.Focus()
                    Exit Sub
                End If
                SubVal = "Re:" & Me.txtSub.Text
                bodyVal = Session("empname") & " replied to Task assigned by "
                'obj.opencn()
                qry = "select e_mailid,name from mistel a, jct_ops_task_log b where a.company_code=b.company_code and a.company_code='" & Session("Companycode") & "' and a.empcode=b.emp_code and b.task_no='" & Trim(Me.txtTaskNo.Text) & "' and b.status=''"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                dr = cmd.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    If dr.Item(0) Is System.DBNull.Value Then
                    Else
                        If Trim(toVal) = "" Then
                            toVal = Trim(dr.Item(0))
                            bodyVal = bodyVal & Trim(dr.Item(1))
                        Else
                            toVal = toVal & ";" & Trim(dr.Item(0))
                            bodyVal = bodyVal & "," & Trim(dr.Item(1))
                        End If

                    End If
                End If
                dr.Close()

                '''''''''''''''''
                For i = 0 To Me.ChkTo.Items.Count - 1
                    'obj.opencn()
                    qry = "select e_mailid,name from mistel where company_code = '" & Session("Companycode") & "' and empcode=ltrim('" & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "')"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        If dr.Item(0) Is System.DBNull.Value Then
                        Else
                            If Trim(toVal) = "" Then
                                toVal = Trim(dr.Item(0))
                            Else
                                toVal = toVal & ";" & Trim(dr.Item(0))
                            End If

                        End If
                    End If
                    dr.Close()
                    'obj.closecn()
                Next

                For i = 0 To Me.ChkCC.Items.Count - 1
                    'obj.opencn()
                    qry = "select e_mailid,name from mistel where company_code='" & Session("Companycode") & "' and empcode='" & Left(Me.ChkCC.Items(i).Text, InStr(Me.ChkCC.Items(i).Text, ":-") - 1) & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        If dr.Item(0) Is System.DBNull.Value Then
                        Else

                            If Trim(ccval) = "" Then
                                ccval = Trim(dr.Item(0))
                            Else
                                ccval = ccval & ";" & Trim(dr.Item(0))
                            End If
                        End If
                    End If
                    dr.Close()
                    'obj.closecn()

                Next



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''
                bodyVal = bodyVal & " which says:- " & Trim(Me.txtReply.Text) & vbCrLf
                'obj.closecn()vbCrLF
                'Me.txtHistory.Text = Me.txtHistory.Text & Environment.NewLine & Session("empname") & ":-" & Trim(Me.DrpTaskStatus.Text) & "(" & Now() & "):" & Me.txtReply.Text
                Me.txtHistory.Text = Me.txtHistory.Text & vbCrLf & Session("empname") & ":-" & Trim(Me.DrpTaskStatus.Text) & "(" & Now() & "):" & Me.txtReply.Text

                If Trim(Me.LnkReply.Text) <> "" And Trim(Me.LnkReply.Text) <> "LnkReply" Then
                    Me.txtHistory.Text = Me.txtHistory.Text & Environment.NewLine & "Attachment:-" & Trim(Me.LnkReply.Text)
                End If

                ' obj.opencn()
                qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', history='" & Replace(Trim(Me.txtHistory.Text), "'", "''") & "' where company_code= '" & Session("Companycode") & "'and  task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()
                'obj.closecn()

                qry = "insert into  jct_ops_task_log_Detail (Company_code,Emp_Code,Task_No, Created_Dt,Task_Status,Reply) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(Me.txtTaskNo.Text) & "', getdate(),'" & Trim(Me.DrpTaskStatus.Text) & "','" & Replace(Trim(Me.txtReply.Text), "'", "''") & "')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                If Trim(Me.DrpTaskStatus.Text) = "Re Assigned" And Request.QueryString.Get("reply") = 1 Then

                    qry = "select max(convert(integer,right(task_no,len(task_no)-5)))+1 from jct_ops_task_log "
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        dr.Read()
                        If dr.Item(0) Is System.DBNull.Value Then
                            'task_no = 1
                            'Just to keep check
                            MsgBox("Not Possible")
                        Else
                            task_no = "0809I" & dr.Item(0)
                        End If
                    Else
                        'Just to keep check
                        MsgBox("Not Possible")
                    End If
                    dr.Close()
                    'obj.closecn()

                    qry = "insert into jct_ops_task_log (Company_code,Emp_Code,Task_No, Task_Type,Task_Priority, Area, SubArea, Log_SysDate,Task_Ref, Task_Ref_Date,Subject,Trans_Type,Tran_no,Job_Descr,Task_Status,Due_Date,Authorize,History, Status)  select Company_code,'" & Session("Empcode") & "','" & task_no & "', Task_Type,Task_Priority, Area, SubArea, getdate(),Task_No, Log_SysDate,Subject,Trans_Type,Tran_no,Job_Descr,'Deferred',Due_Date,Authorize,History, 'R' from jct_ops_task_log where task_no='" & Me.txtTaskNo.Text & "' and status=''"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    cmd.ExecuteNonQuery()

                    '''''''''''''''''''''''''''''''
                    If Trim(Me.LnkReply.Text) <> "LnkReply" And Trim(Me.LnkReply.Text) <> "" Then
                        'obj.opencn()we can add separate insert for this new task.. To be done later
                        qry = "update JCT_OPS_Task_File_Dir set task_no='" & task_no & "' where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkAssign.Text & "' and (task_no='" & Session("Task") & "' or task_no='" & Trim(Me.txtTaskNo.Text) & "')"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        '  obj.closecn()

                        'FlAttcAssn.PostedFile.SaveAs("C:\Inetpub\wwwroot\testweb\AssignTask\" + Me.LnkAssign.Text)
                        'Me.LnkAssign.Text = c
                        'Me.LnkAssign.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & "C:\Inetpub\wwwroot\testweb\AssignTask\" & c

                    End If

                    For i = 0 To Me.ChkTo.Items.Count - 1
                        'obj.opencn()
                        qry = "select e_mailid from mistel where company_code='" & Session("Companycode") & "' and empcode=ltrim('" & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "')"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            If dr.Item(0) Is System.DBNull.Value Then
                            Else
                                If Trim(toVal) = "" Then
                                    toVal = Trim(dr.Item(0))
                                Else
                                    toVal = toVal & ";" & Trim(dr.Item(0))
                                End If
                            End If

                        End If
                        dr.Close()
                        'obj.closecn()
                        ' obj.opencn()
                        qry = "insert into  jct_ops_task_recepients (Company_code,Emp_Code,Task_No,Recp_Code,Flag,history) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & task_no & "',ltrim(' " & Left(Me.ChkTo.Items(i).Text, InStr(Me.ChkTo.Items(i).Text, ":-") - 1) & "'),'T','')"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        'obj.closecn()
                    Next

                    For i = 0 To Me.ChkCC.Items.Count - 1
                        'obj.opencn()
                        qry = "select e_mailid from mistel where company_code = '" & Session("Companycode") & "' and empcode='" & Left(Me.ChkCC.Items(i).Text, InStr(Me.ChkCC.Items(i).Text, ":-") - 1) & "'"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        dr = cmd.ExecuteReader
                        If dr.HasRows = True Then
                            dr.Read()
                            If dr.Item(0) Is System.DBNull.Value Then
                            Else
                                If Trim(ccval) = "" Then
                                    ccval = Trim(dr.Item(0))
                                Else
                                    ccval = ccval & ";" & Trim(dr.Item(0))
                                End If
                            End If

                        End If
                        dr.Close()
                        'obj.closecn()

                        'obj.opencn()
                        qry = "insert into  jct_ops_task_recepients (Company_code,Emp_Code,Task_No,Recp_Code,Flag,history) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & task_no & "','" & Left(Me.ChkCC.Items(i).Text, InStr(Me.ChkCC.Items(i).Text, ":-") - 1) & "','C','')"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        ' obj.closecn()
                    Next


                    ''''''Files Transfer
                    'fromDir is the source folder and toDir is dest folder
                    Dim fromdir As New DirectoryInfo(Server.MapPath("~\EmpGateway\ReplyTask\") + Trim(Me.txtTaskNo.Text))
                    Dim todir As New DirectoryInfo(Server.MapPath("~\EmpGateway\ReplyTask\") + task_no)
                    If todir.Exists = False Then todir.Create()
                    Dim todirs, fromDirs As String
                    fromDirs = Server.MapPath("~\EmpGateway\ReplyTask\") + Trim(Me.txtTaskNo.Text)
                    todirs = Server.MapPath("~\EmpGateway\ReplyTask\") + task_no
                    Dim frm As New DirectoryInfo(fromDirs)
                    If frm.Exists = True Then
                        Dim f() As String = Directory.GetFiles(fromDirs)
                        For i As Integer = 0 To UBound(f)
                            File.Copy(f(i), todirs & "\" & fileNameWithoutThePath(f(i)))
                        Next

                        '********************
                        obj.opencn()
                        qry = "insert into JCT_OPS_Task_File_Dir values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(task_no) & "','" & Me.LnkReply.Text & "','R',host_name(),getdate())"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.ExecuteNonQuery()
                        obj.closecn()

                        ''''''''''''''''''''
                    End If
                    '''''   Response.Write("<script>alert('Task Logged Successfully!!')</script>")

                    SubVal = Me.txtSub.Text
                    bodyVal = "You have got a task from " & Session("Empname") & " which says: " & Me.txtReply.Text

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Response.Write("<script>alert('Task Reassigned Successfully!!')</script>")
                ElseIf Trim(Me.DrpTaskStatus.Text) = "Re Assigned" And Request.QueryString.Get("reply") = 2 Then
                    Trans.Rollback()
                    obj.closecn()
                    'System.IO.File.Delete("D:/WebApplications/EmpGateway/ReplyTask/" + Me.LnkReply.Text)
                    'System.IO.File.Delete("~/EmpGateway/ReplyTask/" + Me.LnkReply.Text)
                    obj.opencn()
                    qry = "delete from JCT_OPS_Task_File_Dir where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkReply.Text & "' and task_no='" & Session("Task") & "'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.ExecuteNonQuery()
                    obj.closecn()

                    Response.Write("<script>alert('You can't ReAssign this task.. If you are trying to close this then pls change task status also to 'Closed'!!')</script>")
                    Exit Sub
                ElseIf Request.QueryString.Get("reply") = 2 Then
                    If Me.ChkAuth.Checked = True Then
                        SubVal = "Close:" & Me.txtSub.Text
                        If Trim(Me.DrpTaskStatus.Text) = "Cancelled" Then
                            qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', authorize='Y', history='" & Me.txtHistory.Text & "', status='C' where company_code='" & Session("Companycode") & "' and task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                        Else
                            qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', authorize='Y', history='" & Me.txtHistory.Text & "' where company_code='" & Session("Companycode") & "' and task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                        End If

                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                        'Else
                        '    SubVal = "Re:" & Me.txtSub.Text
                        '    qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', history='" & Me.txtHistory.Text & "' where task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                    End If

                    If Trim(Me.DrpTaskStatus.Text) = "Cancelled" Then
                        qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', authorize='Y', history='" & Me.txtHistory.Text & "', status='C' where company_code='" & Session("Companycode") & "' and task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                        cmd = New SqlCommand(qry, obj.cn)
                        cmd.Transaction = Trans
                        cmd.ExecuteNonQuery()
                    End If
                    ''''''''''''
                    bodyVal = Session("empname") & " replied to Task assigned To "
                    'obj.opencn()
                    qry = "select e_mailid,name from mistel a, jct_ops_task_recepients b where a.company_code=b.company_code and a.company_code='" & Session("Companycode") & "' and a.empcode=b.recp_code and b.task_no='" & Trim(Me.txtTaskNo.Text) & "' and b.flag='T'"
                    cmd = New SqlCommand(qry, obj.cn)
                    cmd.Transaction = Trans
                    dr = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        toVal = ""

                        While dr.Read()
                            If dr.Item(0) Is System.DBNull.Value Then
                            Else
                                If Trim(toVal) = "" Then
                                    toVal = Trim(dr.Item(0))
                                    bodyVal = bodyVal & Trim(dr.Item(1))
                                Else
                                    toVal = toVal & ";" & Trim(dr.Item(0))
                                    bodyVal = bodyVal & "," & Trim(dr.Item(1))
                                End If

                            End If
                        End While
                    End If
                    dr.Close()
                    bodyVal = bodyVal & " which says:- " & Trim(Me.txtReply.Text) & vbCrLf

                    ''''''''''''''

                    'obj.opencn()


                    ' obj.closecn()
                    Response.Write("<script>alert('Reply Sent Successfully!!')</script>")
                Else
                    Response.Write("<script>alert('Reply Sent Successfully!!')</script>")
                End If



            ElseIf Me.DrpSelection.Text = "Close" Then
                Me.txtHistory.Text = Me.txtHistory.Text & Environment.NewLine & Trim(Session("empname")) & ":-" & Trim(Me.DrpTaskStatus.Text) & "(" & Now() & "):" & Me.txtReply.Text

                If Me.ChkAuth.Checked = True Then
                    SubVal = "Close:" & Me.txtSub.Text
                    'bodyVal = Me.txtReply.Text
                    qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', authorize='Y', history='" & Me.txtHistory.Text & "' where task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                Else
                    SubVal = "Re:" & Me.txtSub.Text
                    qry = "update jct_ops_task_log set task_status='" & Trim(Me.DrpTaskStatus.Text) & "', history='" & Me.txtHistory.Text & "' where task_no='" & Trim(Me.txtTaskNo.Text) & "'"
                End If

                'obj.opencn()

                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()
                ' obj.closecn()

                qry = "insert into  jct_ops_task_log_Detail (Company_code,Emp_Code,Task_No, Created_Dt,Task_Status,Reply) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(Me.txtTaskNo.Text) & "', getdate(),'" & Trim(Me.DrpTaskStatus.Text) & "','" & Trim(Me.txtReply.Text) & "')"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.Transaction = Trans
                cmd.ExecuteNonQuery()

                Response.Write("<script>alert('Reply Sent Successfully!!')</script>")
            End If
            Trans.Commit()
        Catch Exp As Exception
            Trans.Rollback()
            System.IO.File.Delete(Server.MapPath("~\EmpGateway\ReplyTask\") + Me.LnkReply.Text)
            'System.IO.File.Delete("~/EmpGateway/ReplyTask/" + Me.LnkReply.Text)
            obj.opencn()
            qry = "delete from JCT_OPS_Task_File_Dir where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkReply.Text & "' and task_no='" & Session("Task") & "'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.ExecuteNonQuery()
            obj.closecn()
            Exit Sub
        Finally
            obj.closecn()
        End Try

        With MailSmpt
            .To = toVal
            obj.opencn()
            qry = "select e_mailid from mistel where company_code='" & Session("Companycode") & "' and empcode=ltrim('" & Session("Empcode") & "')"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    .From = "dummy@jctltd.com"
                Else
                    .From = Trim(dr.Item(0))
                End If
            Else
                .From = "dummy@jctltd.com"
            End If
            obj.closecn()

            .Subject = SubVal
            .Bcc = "RBaksshi@jctltd.com"
            'Modify Person:- Kulwinder Date:- 5/May/2009
            'Added Disclaimer in body tag
            .Cc = ccval
            '.Body = bodyVal & "<br><br><br><br><br><br><br> DISCLAIMER: This email has been generated through Employee Gateway Package. <br>Kindly do not reply as you will not receive a response."
            .Body = bodyVal & vbCrLf & vbCrLf & vbCrLf & " DISCLAIMER: This email has been generated through Employee Gateway Package." & Environment.NewLine & "Kindly do not reply as you will not receive a response."
        End With

        Mail.SmtpMail.SmtpServer = "exchange2007"
        Mail.SmtpMail.Send(MailSmpt)
        MailSmpt = Nothing

        Response.Redirect("MyActions.aspx")

    End Sub

    Public Function fileNameWithoutThePath(ByVal b As String) As String
        Dim j As Int16

        j = Convert.ToInt16(b.LastIndexOf("\"))
        Return b.Substring(j + 1)

    End Function

    Protected Sub cmdAttachReply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAttachReply.Click

        Try

            If Me.cmdAttachReply.Text = "Attach File" Then
                Me.LnkReply.Visible = True
                strFileName = FlReply.PostedFile.FileName
                c = System.IO.Path.GetFileName(strFileName)
                If CheckFileName(c, "r") = 1 Then
                    Response.Write("<script>alert('File with this name already exists in Directory. Please Rename File and try again..')</script>")
                    Exit Sub
                End If
                Me.LnkReply.Text = c

                Session("task") = Me.txtTaskNo.Text

                Dim fldname As String
                fldname = Me.txtTaskNo.Text
                Dim nwFld As New DirectoryInfo(Server.MapPath("~\EmpGateway\ReplyTask\") + fldname)
                If nwFld.Exists = False Then nwFld.Create()
                obj.opencn()
                qry = "insert into JCT_OPS_Task_File_Dir values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Trim(Session("Task")) & "','" & Me.LnkReply.Text & "','R',host_name(),getdate())"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                obj.closecn()
                'FlAttcAssn.PostedFile.SaveAs("D:/WebApplications/EmpGateway/ReplyTask/" + Me.LnkReply.Text)
                'Me.LnkReply.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & "D:/WebApplications/EmpGateway/ReplyTask/" & c
                Me.cmdAttachReply.Text = "Remove File"
                Me.FlReply.Enabled = False
                FlReply.PostedFile.SaveAs(Server.MapPath("~\EmpGateway\ReplyTask\") + fldname + "/" + Me.LnkReply.Text)
                Me.LnkReply.NavigateUrl = "DownloadFile.aspx" & "?filepth=" & Server.MapPath("~\EmpGateway\ReplyTask\") & fldname & "/" & c

            ElseIf Me.cmdAttachReply.Text = "Remove File" Then
                Me.LnkReply.Visible = False
                System.IO.File.Delete(Server.MapPath("~\EmpGateway\ReplyTask\") + Me.txtTaskNo.Text + "/" + Me.LnkReply.Text)
                obj.opencn()
                qry = "delete from JCT_OPS_Task_File_Dir where company_code='" & Session("Companycode") & "' and emp_code='" & Session("Empcode") & "' and file_nm='" & Me.LnkReply.Text & "' and task_no='" & Session("Task") & "'"
                cmd = New SqlCommand(qry, obj.cn)
                cmd.ExecuteNonQuery()
                obj.closecn()
                Me.LnkReply.Text = ""
                Me.LnkReply.NavigateUrl = ""
                Me.cmdAttachReply.Text = "Attach File"
                Me.FlReply.Enabled = True
            End If
        Catch exp As Exception
            Response.Write(exp.ToString())
        End Try

    End Sub

    Protected Sub cmdReAssign_Click(ByVal sender As Object, ByVal e As System.EventArgs) ''Handles cmdReAssign.Click
        Dim toVal, SubVal, bodyVal, fromVal, ccval As String
        Dim MailSmpt As New Mail.MailMessage

        obj.opencn()
        Dim Trans As SqlTransaction = obj.cn.BeginTransaction()

        Try
            If Trim(Me.txtReply.Text) = "" Then
                Response.Write("<script>alert('Please Add some reply!!')</script>")
                Me.txtReply.Focus()
                Exit Sub
            End If
            SubVal = "Re:" & Me.txtSub.Text
            bodyVal = Me.txtReply.Text
            'obj.opencn()
            qry = "select e_mailid from mistel a, jct_log_task b where a.company_code=b.company_code and a.company_code = '" & session("Companycode") & "' and a.empcode=b.empcode and b.task_no='" & Trim(Me.txtTaskNo.Text) & "'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.Transaction = Trans
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                Else
                    toVal = Trim(dr.Item(0))
                End If
            End If
            dr.Close()
            'obj.closecn()
            Me.txtHistory.Text = Me.txtHistory.Text & Environment.NewLine & Session("empname") & ":-" & Trim(Me.DrpTaskStatus.Text) & "(" & Now() & "):" & Me.txtReply.Text

            ' obj.opencn()
            qry = "update jct_ops_task_log set task_status='Re Assigned', history='" & Me.txtHistory.Text & "' where task_no='" & Trim(Me.txtTaskNo.Text) & "'"
            cmd = New SqlCommand(qry, obj.cn)
            cmd.Transaction = Trans
            cmd.ExecuteNonQuery()
            'obj.closecn()
            Response.Write("<script>alert('Task Reassigned Successfully!!')</script>")
            Trans.Commit()
        Catch Exp As Exception
            Trans.Rollback()

            Response.Write(Exp.ToString())
            Exit Sub
        Finally
            obj.closecn()
        End Try
        With MailSmpt
            .To = toVal
            obj.opencn()
            qry = "select e_mailid from mistel where company_code='" & session("Companycode") & "' and empcode=ltrim('" & Session("Empcode") & "')"
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            If dr.HasRows = True Then
                dr.Read()
                If dr.Item(0) Is System.DBNull.Value Then
                    .From = "noreply@jctltd.com"
                Else
                    .From = Trim(dr.Item(0))
                End If
            Else
                .From = "noreply@jctltd.com"
            End If
            obj.closecn()
            .Subject = SubVal
            '.Bcc = "RBakshhi@jctltd.com"
            .Cc = ccval
            .Body = bodyVal
        End With
        Mail.SmtpMail.SmtpServer = "exchange2007"
        Mail.SmtpMail.Send(MailSmpt)
        MailSmpt = Nothing
    End Sub

    Protected Sub DrpTaskStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DrpTaskStatus.SelectedIndexChanged

        If Trim(Me.DrpSelection.Text) = "Reply" Then
            If Trim(Me.DrpTaskStatus.Text) = "Re Assigned" Then
                Me.cmdDel.Enabled = True
                Me.ChkFrom.Enabled = True
            ElseIf Trim(Me.DrpTaskStatus.Text) = "Cancelled" Then
                Me.cmdDel.Enabled = False
                Me.ChkFrom.Enabled = False
            Else
                Me.cmdDel.Enabled = False
                Me.ChkFrom.Enabled = False
            End If
        End If

    End Sub

    Protected Sub cmdSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSave.Click

        Dim strbody As String
        '   strbody = "<html> <body> <div> <b> </br> Subject: " & txtSub.Text & "<br> Detail: </b>" & txtJobDescr.Text & "<br><br> <b>Task History:</b> " & txtHistory.Text & "</div></body></html>"

        'Dim fileName As String = "MsWordSample.doc"

        'Response.AppendHeader("Content-Type", "application/msword")
        'Response.AppendHeader("Content-disposition", "attachment; filename=" + fileName)
        'Response.Write(strbody)
        strbody = "FusionApps / EmployeeGateway / EHelpDesk, Communication and Task Assignment" & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine
        strbody += "TaskNo: " & txtTaskNo.Text & Environment.NewLine
        strbody += "Subject: " & txtSub.Text & Environment.NewLine & " Detail:" & txtJobDescr.Text & Environment.NewLine & "Task History:" & Environment.NewLine & txtHistory.Text

        'Dim doc As Document = New Document
        'PdfWriter.GetInstance(doc, New FileStream(Request.PhysicalApplicationPath + "\1.pdf", FileMode.Create))
        'doc.Open()
        'doc.Add(New Paragraph(strbody))
        'doc.Close()
        'Response.Redirect("~/1.pdf")

    End Sub

End Class


