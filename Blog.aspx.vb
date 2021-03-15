Imports System.Data.SqlClient
Partial Class Blog
    Inherits System.Web.UI.Page
    Dim obj As New Connection
    Dim ob As New CostModule
    Dim qry As String
    Dim dr As SqlDataReader

    Dim fromad, Subj, Body As String
    'Const RATING1_MIN As Integer = 1
    'Const RATING1_MAX As Integer = 5
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("AuthBlog") Is Nothing Or Request.QueryString("AuthBlog") = "" Then
            Else
                qry = "update JCT_Fap_Blog_Master set AuthBy='R-03339', AuthDate=getdate(), status='A', visits=visits+1 where blogno=" & Request.QueryString("AuthBlog")
                InsertRecord(qry)
            End If
            'Session("Empcode") = "N-02632"

            If Request.QueryString("AuthCmnt") Is Nothing Or Request.QueryString("AuthCmnt") = "" Then
            Else
                qry = "update JCT_Fap_Blog_Comment set AuthBy='R-03339', AuthDate=getdate(), status='A' where CommentNo=" & Request.QueryString("AuthCmnt")
                InsertRecord(qry)
            End If
            
        End If
        GetBlogPostings()
        GetLatestBlog()
    End Sub
    Public Sub GetLatestBlog()
        If Request.QueryString("TransNo") Is Nothing Or Request.QueryString("TransNo") = "" Then
            qry = "select top 1 BlogNo, convert(varchar(15),CreatedOn,106) as OnDate, Topic, Keywords, Description, case AnonFlag when 'N' then fullname else 'Anonymous' end as BlogBy, Visits, Comments, TransNo from JCT_Fap_Blog_Master a inner join jct_epor_master_employee b on a.empcode=b.emp_code where b.status='a' and getdate() between eff_from and eff_to and a.status='a' order by TransNo desc "
        Else
            qry = "select BlogNo, convert(varchar(15),CreatedOn,106) as OnDate, Topic, Keywords, Description, case AnonFlag when 'N' then fullname else 'Anonymous' end as BlogBy, Visits, Comments,transno from JCT_Fap_Blog_Master a inner join jct_epor_master_employee b on a.empcode=b.emp_code where b.status='a' and getdate() between eff_from and eff_to and a.status='a' and Transno=" & Request.QueryString("TransNo")
        End If
        Dr = obj.FetchReader(qry)
        If Dr.HasRows = True Then
            Dr.Read()
            LblBlog.Text = dr(0)
            LblPostedOn.Text = dr(1)
            lblArticle.Text = Replace(dr(4), "/r/n", "<br>")
            LblHeading.Text = dr(2)
            LblPostBy.Text = dr(5)
            lblHits.Text = dr(6)
            lblComments.Text = dr(7)
            LtlTrans.Text = dr(8)
        End If
        Dr.Close()
        obj.ConClose()
        If LblBlog.Text <> "" Then
            'Display Rating
            qry = "select isnull(sum(rating)/count(*),0),count(*) from  JCT_Fap_Blog_Rating where blogno=" & LblBlog.Text & " group by blogno"
            dr = obj.FetchReader(qry)
            If dr.HasRows = True Then
                dr.Read()
                Me.Rating2.CurrentRating = dr(0)
                lblRating.Text = dr(1)
            End If
            dr.Close()

            'Incrementing Visits
            qry = "update JCT_Fap_Blog_Master set visits=visits+1 where Transno=" & LtlTrans.Text
            InsertRecord(qry)
            vwcmnts()
           
        End If
    End Sub
    Public Sub vwcmnts()
        'View Comments
        qry = "select convert(varchar(15),a.CreatedOn,106) as [On],case AnonFlag when 'N' then fullname else 'Anonymous' end as [By], Comment from JCT_Fap_Blog_Comment a inner join jct_epor_master_employee b on a.empcode=b.emp_code where b.status='a' and getdate() between eff_from and eff_to and blogno= " & LblBlog.Text
        dlsCmnt.DataSource = ob.FetchDS(qry)
        dlsCmnt.DataBind()
    End Sub
    Public Sub GetBlogPostings()
        qry = "select Topic, 'Blog.aspx?TransNo=' + convert(varchar(7),TransNo) as PostUrl, Keywords from JCT_Fap_Blog_Master where status='A' order by TransNo desc"
        dlsLeft.DataSource = ob.FetchDS(qry)
        dlsLeft.DataBind()
    End Sub
    'Public Sub Evaluate_Rating1(ByVal value As Integer)
    '    lblRating.Text = EvaluateRating(value, Rating1.MaxRating, RATING1_MIN, RATING1_MAX)
    'End Sub
    'Public Shared Function EvaluateRating(ByVal value As Integer, ByVal maximalValue As Integer, ByVal minimumRange As Integer, ByVal maximumRange As Integer) As Double

    '    Dim stepDelta As Integer = IIf(minimumRange = 0, 1, 0)

    '    Dim delta As Double = (maximumRange - minimumRange) / (maximalValue - 1)

    '    Dim result As Double = delta * value - delta * stepDelta

    '    Return FormatResult(result)

    'End Function
    'Public Shared Function FormatResult(ByVal value As Double) As String
    '    Return String.Format("{0:g}", value)
    'End Function

    Protected Sub LnkPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) 'Handles LnkPost.Click 'Handles LnkPost.Click
        Dim HostIP As String = Request.ServerVariables("REMOTE_ADDR")
        Dim effTill As Date
        Dim BlogNo As Integer
        If txtEffTill.Text = "" Then
            effTill = "12/31/3000"
        Else
            effTill = txtEffTill.Text
        End If

        qry = "select sr_no from production..common_serial_master where frmname='Blog' and sr_type='Blog'"
        dr = obj.FetchReader(qry)
        If Dr.HasRows = True Then
            Dr.Read()
            If Dr(0) Is System.DBNull.Value Then
                BlogNo = 0
            Else
                BlogNo = Dr(0)
            End If
        Else
            BlogNo = 0
        End If
        Dr.Close()
        obj.ConClose()

        If BlogNo = 0 Then
            qry = "insert into production..common_serial_master values('Blog',1,'','Blog')"
        Else
            qry = "update production..common_serial_master set sr_no= sr_no+1 where frmname='Blog' and sr_type='Blog'"
        End If
        InsertRecord(qry)

        qry = "INSERT INTO JCT_Fap_Blog_Master(CompanyCode,EmpCode,HostIP,CreatedOn, EffectiveTill,BlogNo,Topic,Keywords,Description ,AnonFlag,visits,comments,status) VALUES('" & Session("Companycode") & "','" & Session("Empcode") & "','" & HostIP & "', GETDATE() , '" & effTill & "'," & BlogNo + 1 & ",'" & Replace(txtCrTitle.Text, "'", "''") & "','" & Replace(txtCrKeywrds.Text, "'", "''") & "','" & Replace(Replace(Replace(txtCrDetail.Text, "'", "''"), "\r", "<br>"), "\n", "<br>") & "','" & DDLIdentity.SelectedValue & "',0,0,'')"
        If InsertRecord(qry) = True Then
            'If DDLIdentity.SelectedValue = "Y" Then
            'fromad = "dummy@jctltd.com"
            'Else
            qry = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
            Dr = obj.FetchReader(qry)
            If Dr.HasRows = True Then
                Dr.Read()
                If Dr(0) Is System.DBNull.Value Then
                    fromad = "dummy@jctltd.com"
                Else
                    fromad = Dr(0)
                End If
            Else
                fromad = "dummy@jctltd.com"
            End If
            Dr.Close()
            obj.ConClose()
            ' End If
            Subj = "New BlogPost for Authorization"
            Body = "Title:" & Me.txtCrTitle.Text & Environment.NewLine & "Brief:" & Me.txtCrKeywrds.Text & Environment.NewLine & "Detail: " & Me.txtCrDetail.Text
            Body += Environment.NewLine & "Click on Link to Authorize: http://misdev/fusionapps/Blog.aspx?AuthBlog=" & BlogNo + 1
            SendMail(fromad, "", "rbaksshi@jctltd.com", "neha.srivastava@jctltd.com", Subj, Body)
        End If
    End Sub

    Protected Sub SendMail(ByVal fromAd As String, ByVal toAd As String, ByVal CCAd As String, ByVal BCCAd As String, ByVal Subject As String, ByVal Body As String)
        Dim Client As New Net.Mail.SmtpClient
        Dim Message As New Net.Mail.MailMessage
        'Message.IsBodyHtml = True

        If Trim(toAd) <> "" Then
            Message.To.Add(toAd)
        End If

        If Trim(CCAd) <> "" Then
            Message.CC.Add(CCAd)
        End If

        If Trim(BCCAd) <> "" Then
            Message.Bcc.Add(BCCAd)
        End If
        Message.Subject = Subject
        Message.Body = Body

        Dim From As New Net.Mail.MailAddress(fromAd)
        Message.From = From

        Client.Host = "EXCHANGE2003"
        Client.Port = 25
        Client.Send(Message)
    End Sub

    Protected Sub LnkSubmitCmnt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LnkSubmitCmnt.Click 'Handles LnkSubmitCmnt.Click 'Handles LnkSubmitCmnt.Click
        Dim HostIP As String = Request.ServerVariables("REMOTE_ADDR")
        qry = "INSERT INTO JCT_Fap_Blog_Comment(CompanyCode,EmpCode,HostIP,CreatedOn, BlogNo,TransNo,Comment,AnonFlag,status) VALUES('" & Session("Companycode") & "','" & Session("Empcode") & "','" & HostIP & "', GETDATE() , " & LblBlog.Text & "," & LtlTrans.Text & ",'" & Replace(txtCmntAdd.Text, "'", "''") & "','" & DDLCmtIdentity.SelectedValue & "','')"
        If InsertRecord(qry) = True Then
            qry = "update JCT_Fap_Blog_Master set comments=comments+1 where Transno=" & LtlTrans.Text
            If InsertRecord(qry) = True Then
                qry = "select e_mailid from mistel where empcode='" & Session("Empcode") & "'"
                dr = obj.FetchReader(qry)
                If dr.HasRows = True Then
                    dr.Read()
                    If dr(0) Is System.DBNull.Value Then
                        fromad = "dummy@jctltd.com"
                    Else
                        fromad = dr(0)
                    End If
                Else
                    fromad = "dummy@jctltd.com"
                End If
                dr.Close()
                obj.ConClose()

                qry = "select max(commentno) from JCT_Fap_Blog_Comment where blogno=" & LblBlog.Text & " and transno=" & LtlTrans.Text & " and empcode='" & Session("Empcode") & "'"
                dr = obj.FetchReader(qry)
                If dr.HasRows = True Then
                    dr.Read()
                    Subj = "Comment against Blog for Authorization"
                    Body = "Blog : " & LblHeading.Text & Environment.NewLine
                    Body += "Comment : " & txtCmntAdd.Text & Environment.NewLine
                    Body += "Click on Link to Authorize: http://misdev/fusionapps/Blog.aspx?AuthCmnt=" & dr(0)
                    SendMail(fromad, "rbaksshi@jctltd.com", "", "neha.srivastava@jctltd.com", Subj, Body)
                End If
                dr.Close()
            End If
        End If
        vwcmnts()
    End Sub

    Protected Sub Rating1_Changed(ByVal sender As Object, ByVal e As AjaxControlToolkit.RatingEventArgs) Handles Rating1.Changed
        Dim HostIP As String = Request.ServerVariables("REMOTE_ADDR")
        qry = "select * from JCT_Fap_Blog_Rating where empcode='" & Session("Empcode") & "' and blogno=" & LblBlog.Text
        dr = obj.FetchReader(qry)
        If dr.HasRows = True Then
            qry = "update JCT_Fap_Blog_Rating set transno=" & LtlTrans.Text & ", rating=" & Rating1.CurrentRating & " where empcode='" & Session("Empcode") & "' and blogno=" & LblBlog.Text
        Else
            qry = "insert into JCT_Fap_Blog_Rating (CompanyCode, EmpCode, HostIP, CreatedOn, BlogNo, Transno, Rating) values ('" & Session("Companycode") & "','" & Session("Empcode") & "','" & HostIP & "', GETDATE() , " & LblBlog.Text & "," & LtlTrans.Text & "," & Rating1.CurrentRating & ")"
        End If
        dr.Close()
        InsertRecord(qry)
    End Sub

    
End Class
