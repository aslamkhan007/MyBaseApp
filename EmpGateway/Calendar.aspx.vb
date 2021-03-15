
Imports System.Data
Imports System.Data.SqlClient

Partial Class Default4
    Inherits System.Web.UI.Page
    Dim Obj As Connection = New Connection
    Dim SqlPass As String

    Public Sub BindData()
        Dim Sqlpass = "select Holidays  as [Holiday Name], Convert(varchar(15),Holiday_date,107) as [Holiday Date],Holiday_Day as [Holiday Day] from jctdev..jct_holiday_calender where DateDiff(DD,GETDATE(),EFF_TO)>=0 and status<>'d' and getdate() between eff_from and eff_to order by Holiday_date"
        'Dim Sqlpass = "select Ser_Num as [Serial Number] ,Holidays  as [Holiday Name], Convert(varchar(15),Holiday_date,107) as [Holiday Date],Holiday_Day as [Holiday Day] from jctdev..jct_holiday_calender where DateDiff(DD,GETDATE(),EFF_TO)>=0 and status<>'d'  order by ser_num"
        'Dim Sqlpass = "select  Holiday  as [Holiday Name], Convert(varchar(15),Hdate,107) as [Holiday Date], datename(dw, hdate) as [Holiday Day] from SAVIOR..HoliDay WHERE YEAR(HDATE)=year(getdate()) "
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())

        Try
            If Dr.HasRows = True Then
                Dr.Close()
                Dim ds As DataSet = New DataSet()
                ds.Clear()
                Da.Fill(ds)
                GridView1.DataSource = ds
                GridView1.DataBind()
                Dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Obj.ConClose()
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            'empcode = Session("empcode")
        Else
            Response.Redirect("~/login.aspx")
        End If
        If Not (Page.IsPostBack) Then
            BindData()
        End If
    End Sub
    
End Class
