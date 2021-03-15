Imports System.Data.SqlClient
Imports System.Data
Partial Class CustomerFeedback
    Inherits System.Web.UI.Page
    Public cmd As New SqlCommand
    Public obj As New HelpDeskClass
    Public qry As String, empname As String
    Public dr As SqlDataReader
    Dim Obj1 As Connection = New Connection
    Dim SqlPass As String, empcode As String

    Protected Sub txtFindName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFindName.TextChanged
        If Trim(txtFindName.Text) <> "" And Trim(txtCustCode.Text) = "" Then
            '    txtCustCode.Text = ""
            'qry = "select Cust_no,Cust_Name from som..m_customer where cust_name like '%" & Trim(txtFindName.Text) & "%' order by cust_name"
            qry = "select Cust_no,Cust_Name from miserp.som.dbo.m_customer where cust_name like '%" & Trim(txtFindName.Text) & "%' order by cust_name"
            Call GetNames()
        ElseIf Trim(txtFindName.Text) <> "" And Trim(txtCustCode.Text) <> "" Then
            '            qry = "select Cust_no,Cust_Name from som..m_customer where cust_name like '%" & Trim(txtFindName.Text) & "%' order by cust_name"
            qry = "select Cust_no,Cust_Name from miserp.som.dbo..m_customer where cust_name like '%" & Trim(txtFindName.Text) & "%' order by cust_name"
            Call GetNames()
        ElseIf Trim(txtFindName.Text) <> "" Then
            LstName.Visible = False
        End If
    End Sub

    
    Protected Sub BtnGetNames_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGetNames.Click
        '  If Not IsPostBack Then
        If Trim(txtFindName.Text) <> "" Then
            txtCustCode.Text = ""
            Call GetNames()
        ElseIf Trim(txtCustCode.Text) <> "" Then
            If Trim(txtFindName.Text) = "" Then
                Call GetNames()
            Else
                txtFindName.Text = ""
                Call GetNames()
            End If
        Else
            LstName.Visible = False
        End If
    End Sub

    Protected Sub LstName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstName.SelectedIndexChanged
        txtFindName.Text = Left(LstName.SelectedValue, InStr(LstName.SelectedValue, "~~") - 1) 'LstName.SelectedValue
        txtCustCode.Text = Trim(Right(LstName.SelectedValue, Len(LstName.SelectedValue) - InStr(LstName.SelectedValue, "~~") - 1))
        txtHistory.Text = ""
        Call FillData()
    End Sub

    
    Public Sub GetNames()
        obj.opencn()
        Dim Qry1 As String
        Qry1 = "select Cust_no,Cust_Name from miserp.som.dbo..m_customer where cust_no='" & Trim(txtCustCode.Text) & "' order by cust_name"
        'qry = "select Cust_no,Cust_Name from som..m_customer where cust_name like '%" & Trim(txtFindName.Text) & "%' order by cust_name"
        cmd = New SqlCommand(Qry1, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                txtFindName.Text = dr(1)
                empname = dr(1)
                Exit Sub
            End While
        End If
        dr.Close()
        If empname = "" Then
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            LstName.Items.Clear()
            If dr.HasRows = True Then
                While dr.Read()
                    Trim(LstName.Items.Add(dr(1) & "~~" & dr(0)))
                End While
                LstName.Visible = True
            End If
            dr.Close()
        End If
        obj.closecn()
    End Sub

    Protected Sub txtCustCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustCode.TextChanged
        'If Not IsPostBack Then
        If Trim(txtCustCode.Text) <> "" And Trim(txtFindName.Text = "") Then
            qry = "select Cust_no,Cust_Name from miserp.som.dbo..m_customer where cust_no like '%" & Trim(txtCustCode.Text) & "%' order by cust_no"
            Call GetNames()
            LstName.Visible = True
        ElseIf Trim(txtCustCode.Text) <> "" And Trim(txtFindName.Text <> "") Then
            qry = "select Cust_no,Cust_Name from miserp.som.dbo..m_customer where cust_no like '%" & Trim(txtCustCode.Text) & "%' order by cust_no"
            Call GetNames()
        ElseIf Trim(txtCustCode.Text) = "" And Trim(txtFindName.Text = "") Then
            LstName.Visible = False
        End If
        'End If
    End Sub

    Protected Sub BtnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnApply.Click
        Dim Check As Integer, FeedbackNo As Integer
        Check = fill()
        If Check = 1 Then Exit Sub
        obj.opencn()
        qry = "select max(FeedbackNo) from jct_emp_Feedback"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            dr.Read()
            If dr.Item(0) Is System.DBNull.Value Then
                FeedbackNo = 1
            Else
                FeedbackNo = dr(0) + 1
            End If
        Else
            FeedbackNo = 1
        End If
        dr.Close()
        obj.closecn()
        obj.opencn()
        qry = "insert into JCT_Emp_Feedback(Company_Code,Emp_Code,Cust_Code,ComentDate,Coments,FeeDBackNo,status) values ('JCT00LTD','" & Session("Empcode") & "','" & Trim(txtCustCode.Text) & "',getdate(),'" & Replace(txtComent.Text, "'", "''") & "'," & FeedbackNo & ",'')"
        cmd = New SqlCommand(qry, obj.cn)
        cmd.ExecuteNonQuery()
        Response.Write("<script>alert('Thanks For Your Coments !!')</script>")
        obj.closecn()
        FillData()
        Reset()
    End Sub
    Private Sub Reset()
        Me.txtFindName.Text = ""
        Me.txtCustCode.Text = ""
        Me.txtComent.Text = ""
        Me.LstName.Items.Clear()
        Me.LstName.Visible = False
    End Sub
    Public Function fill()
        If (Session("empcode").ToString = "") Then
            Response.Redirect("login.aspx")
        End If
        If Trim(Me.txtFindName.Text) = "" Then
            Response.Write("<script>alert('Please Enter/Select Customer Name or Part of Name To Search !!')</script>")
            Me.txtFindName.Focus()
            fill = 1
            Exit Function
        End If
        If Trim(Me.txtCustCode.Text) = "" Then
            Response.Write("<script>alert('Please Enter/Select A Valid Customer Code !!')</script>")
            Me.txtCustCode.Focus()
            fill = 1
            Exit Function
        End If
        If Trim(Me.txtComent.Text) = "" Then
            Response.Write("<script>alert('Please Give Coments !!')</script>")
            Me.txtComent.Focus()
            fill = 1
            Exit Function
        End If
    End Function
    Public Sub FillData()
        Try
            'qry = "select b.empname EmployeeName,a.ComentDate,a.Coments from jct_emp_feedback a,jct_empMast_Base b where a.emp_code=b.empcode and a.Cust_Code='" & Trim(Right(LstName.SelectedValue, Len(LstName.SelectedValue) - InStr(LstName.SelectedValue, "~~") - 1)) & "' order by a.cust_code"

            qry = "select b.empname EmployeeName,a.ComentDate,a.Coments from jct_emp_feedback a,jct_empMast_Base b where a.emp_code=b.empcode and a.Cust_Code='" & txtCustCode.Text & "' order by a.comentdate"
            obj.opencn()
            cmd = New SqlCommand(qry, obj.cn)
            dr = cmd.ExecuteReader
            txtHistory.Text = ""
            If dr.HasRows = True Then
                While dr.Read()
                    'txtHistory.Text = txtHistory.Text & "EmpName : " & dr(0) & " Date :  " & dr(1) & "  Coment : " & dr(2) & Environment.NewLine & "---------------------------------------------------------------------------------------------------------------------" & Environment.NewLine
                    txtHistory.Text = txtHistory.Text & " " & dr(0) & "  :  " & dr(1) & "  : " & dr(2) & Environment.NewLine
                End While
            End If
            dr.Close()
            obj.closecn()
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        Call FillData()
    End Sub

    Protected Sub LstName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstName.TextChanged
        txtFindName.Text = Left(LstName.SelectedValue, InStr(LstName.SelectedValue, "~~") - 1) 'LstName.SelectedValue
        'txtCustCode.Text = Trim(Right(txtFindName.Text, Len(txtFindName.Text) - InStr(txtFindName.Text, "~~") - 1))
        txtCustCode.Text = Trim(Right(LstName.SelectedValue, Len(LstName.SelectedValue) - InStr(LstName.SelectedValue, "~~") - 1))
        Call FillData()
    End Sub
End Class
