Imports System.Data
Imports System.Data.SqlClient
Partial Class Final
    Inherits System.Web.UI.Page
    Dim Cmd As New SqlCommand
    Dim SqlPass, Qry, Cust As String
    Dim ObjFun As Functions = New Functions
    Public AutoStr As String
    Dim ShpConStr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("shpConnectionString").ConnectionString
    Dim Obj As Connection = New Connection(ShpConStr)
    Dim AId As Integer, I As Integer, Tot As String
    Dim Fun As Functions

    Public Sub BindData()

        



        SqlPass = "SELECT   CONVERT(VARCHAR(11),MonthDate,103) AS MonthDate ,			INS_RTD ,	OUTS_RTD ,	DODPer_RTD ,	INS_PA ,	OUTS_PA ,	DODPer_PA ,INS_PP ,	OUTS_PP ,	DODPer_PP ,	INS_ICP ,	OUTS_ICP ,	DODPer_ICP ,INS_WIP ,	OUTS_WIP ,	DODPer_WIP ,	INS_PFWIP ,	OUTS_PFWIP ,	DODPer_PFWIP ,	INS_FAB ,	OUTS_FAB ,	DODPer_FAB FROM FinalPackStarttoEnd "

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
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                Dr.Close()
            End If


        Catch ex As Exception

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
        If Not IsPostBack Then
            BindData()
        End If


    End Sub



    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As GridViewRowEventArgs)

        If e.Row.RowType = DataControlRowType.Header Then

            Dim HeaderGrid As GridView = DirectCast(sender, GridView)
            Dim HeaderGridRow As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert)

            Dim HeaderCell As New TableCell()

            HeaderCell = New TableCell()
            HeaderCell.Text = " "
            HeaderCell.ColumnSpan = 1
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.Gray
            'HeaderCell.BorderWidth = 2
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "READY TO DISPATCH"
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.ToolTip = "IN -> When Sale Order's Packing Complete , When marketing People put the comments RTD  OUT -> Dispatch Against Sale order "


            HeaderCell.BorderWidth = 4
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "PENDING AUTH."
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.BorderWidth = 4
            HeaderCell.ToolTip = "IN -> When marketing People put the comments Except RTD  OUT ->  When marketing People put the comments RTD  "
            HeaderGridRow.Cells.Add(HeaderCell)


            HeaderCell = New TableCell()
            HeaderCell.Text = "PARTIALLY PACKING"
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.BorderWidth = 4
            HeaderCell.ToolTip = "IN -> When SaleOrder will come in part of monthly plan   OUT ->  When sale Order's packing will complete "
            HeaderGridRow.Cells.Add(HeaderCell)


            HeaderCell = New TableCell()
            HeaderCell.Text = "INCOMPLETE PACKING"
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.BorderWidth = 4
            HeaderCell.Height = 25
            HeaderCell.ToolTip = "IN -> Those SaleOrder which are still Packed (Qty not Completed) Rest of meters is also not part of monthly plan  OUT ->  When sale Order's will come in the part of monthly plan"
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "GREY FABRIC WIP"
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.BorderWidth = 4
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "PROCESS FABRIC WIP"
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.BorderWidth = 4
            HeaderGridRow.Cells.Add(HeaderCell)

            HeaderCell = New TableCell()
            HeaderCell.Text = "FINISH FABRIC WIP"
            HeaderCell.ColumnSpan = 3
            HeaderCell.BackColor = Drawing.Color.Gray
            HeaderCell.BorderColor = Drawing.Color.Black
            HeaderCell.ForeColor = Drawing.Color.White
            HeaderCell.HorizontalAlign = HorizontalAlign.Center
            HeaderCell.BorderWidth = 4
            HeaderGridRow.Cells.Add(HeaderCell)

            GridView1.Controls(0).Controls.AddAt(0, HeaderGridRow)
        End If

    End Sub






End Class