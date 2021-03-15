Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI.DataVisualization.Charting

Partial Class frm_demage_report
    Inherits System.Web.UI.Page
    Dim sql As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand
    Dim obj As New Connection
    Dim obj2 As New Functions
    Dim sqlpass, sno2 As String
    Dim scrpt_str As String
    Dim Ash, sno1 As Integer
    Public CstModule As New CostModule
    Dim order_no, order_qty, location As String
    Dim sum As Decimal = 0
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.Redirect("UnderConstruction.aspx")
    End Sub
    Protected Sub cmdFetch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFetch.Click
        Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
        Dim cn As SqlConnection = New SqlConnection(constr)

        sqlpass = "exec jct_ops_grey_demage '" & txtEffecFrom.Text & "','" & txtEffecTo.Text & "','" & ddlwarehouse.SelectedValue & "', '" & ddlorigin.SelectedValue & "' "
        Dim cmd As SqlCommand = New SqlCommand(sqlpass, cn)
        cmd.CommandTimeout = 0
        cn.Open()
        cmd.ExecuteNonQuery()
        sqlpass = ""
        BindData1()

    End Sub

    Protected Sub cmdclose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdclose.Click
        Response.Redirect("default.aspx")
        Me.Visible = False
    End Sub

    Protected Sub grdGrid1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdGrid1.PageIndexChanging
        grdGrid1.PageIndex = e.NewPageIndex
        BindData1()
    End Sub

    Public Sub BindData1()
        Dim Sqlpass As String
        If (ddlwarehouse.SelectedItem.Text = "FCT" Or ddlwarehouse.SelectedItem.Text = "FSY") And ddlorigin.SelectedItem.Text = "PRP" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,warpline,sizing,Loosewarp,Looseweft,Knots from jct_ops_damege_hdr where folding_code in ('FCT','FSY') order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf (ddlwarehouse.SelectedItem.Text = "FCT" Or ddlwarehouse.SelectedItem.Text = "FSY") And ddlorigin.SelectedItem.Text = "SPG" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,Blackpatta,Contamination,DirtyWarp,DirtyWeft,Finewarp,fineweft,HardTwist,moir,neps,patti,readcut,ShedVariation,Slub,Slubcontamination,ThickWarp,ThickWeft,Thickplace,Threeply,WarpSlub,WarpStain,Weftslub,WrongPetern,YarnPatta,YARNPATTI,YarnVariation from jct_ops_damege_hdr where folding_code in ('FCT','FSY') order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf (ddlwarehouse.SelectedItem.Text = "FCT" Or ddlwarehouse.SelectedItem.Text = "FSY") And ddlorigin.SelectedItem.Text = "WVG" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,Bcover,BDCUT,BDF,Bdtorn,Blackstain,bordedtucking,border,borderopen,BrokenPick,BumpingMark,Cheera,Cracks,DesignCuts,DoubleEnds,DoublePicks,DropPicks,Estain,EmbryCut,EmilyTorn,Floats,fly,goli,gtm,Lashing,loops,MissingEnds,Monogram,oilstain,Paties,Phut,Phutki,riv,ShadePatti,ShadingFloat,ShuttleDrop,ShuttleFloats,Smash,Splycing,Stain,stm,swai,snarling,tcut,TampleMark,TampleTorn,TempleStain,ThickEndn,ThinkEnd,TightNess,torn,tops,WarpFloat,WrongDown,weftflot,WrongWeft,weftcut,ReedMark,looseweft,blackpatta,BMark,TEnd,TKing from jct_ops_damege_hdr where folding_code in ('FCT','FSY') order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf (ddlwarehouse.SelectedItem.Text = "FCT" Or ddlwarehouse.SelectedItem.Text = "FSY") And ddlorigin.SelectedItem.Text = "All" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,warpline,sizing,Loosewarp,Looseweft,Knots,Blackpatta,Contamination,DirtyWarp,DirtyWeft,Finewarp,fineweft,HardTwist,moir,neps,patti,readcut,ShedVariation,Slub,Slubcontamination,ThickWarp,ThickWeft,Thickplace,Threeply,WarpSlub,WarpStain,Weftslub,WrongPetern,YarnPatta,YARNPATTI,YarnVariation,Bcover,BDCUT,BDF,Bdtorn,Blackstain,bordedtucking,border,borderopen,BrokenPick,BumpingMark,Cheera,Cracks,DesignCuts,DoubleEnds,DoublePicks,DropPicks,Estain,EmbryCut,EmilyTorn,Floats,fly,goli,gtm,Lashing,loops,MissingEnds,Monogram,oilstain,Paties,Phut,Phutki,riv,ShadePatti,ShadingFloat,ShuttleDrop,ShuttleFloats,Smash,Splycing,Stain,stm,swai,snarling,tcut,TampleMark,TampleTorn,TempleStain,ThickEndn,ThinkEnd,TightNess,torn,tops,WarpFloat,WrongDown,weftflot,WrongWeft,weftcut,ReedMark,looseweft,blackpatta,BMark,TEnd,TKing from jct_ops_damege_hdr where folding_code in ('FCT','FSY') order by sort_no    "
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf ddlwarehouse.SelectedItem.Text = "GWT" And ddlorigin.SelectedItem.Text = "PRP" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,WarpStreaks from jct_ops_damege_hdr where folding_code = 'GWT' order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf ddlwarehouse.SelectedItem.Text = "GWT" And ddlorigin.SelectedItem.Text = "WVG" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,BrokenWarp,BadSelvedge,StainedWarp,Crack,Stmark,BrokenWeft,DoublePick,LoosePick,Snarling,WrongWeft,shortpick,WeftPatti,StainCloth,ReedMark,DesignCut,TempleMark,Crease,WarpPatta,OilStain from jct_ops_damege_hdr where folding_code = 'GWT' order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf ddlwarehouse.SelectedItem.Text = "GWT" And ddlorigin.SelectedItem.Text = "YRN" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,warpline,dirtyweft,UnevenWeft,UnevenWarp,weftpatta,FineWarp from jct_ops_damege_hdr where folding_code = 'GWT' order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        ElseIf ddlwarehouse.SelectedItem.Text = "GWT" And ddlorigin.SelectedItem.Text = "All" Then
            Sqlpass = "select folding_code,convert(varchar(10),doffing_date,103),piece_no,sort_no,orderno,mtrs,damage_mtrs,fresh_mtrs,WarpStreaks,BrokenWarp,BadSelvedge,StainedWarp,Crack,Stmark,BrokenWeft,DoublePick,LoosePick,Snarling,WrongWeft,shortpick,WeftPatti,StainCloth,ReedMark,DesignCut,TempleMark,Crease,WarpPatta,OilStain,warpline,dirtyweft,UnevenWeft,UnevenWarp,weftpatta,FineWarp from jct_ops_damege_hdr where folding_code = 'GWT' order by sort_no"
            obj2.FillGrid(Sqlpass, grdGrid1)
        End If
        '        obj2.FillGrid(Sqlpass, grdGrid1)
    End Sub
    Protected Sub cmdexcel1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdexcel1.Click
        GridViewExportUtil.Export("Grey_Damage.xls", Me.grdGrid1)
    End Sub

    'Protected Sub PopulateBarChart(ByVal sql As String, ByRef chart As Chart)
    '    Try
    '        chart.Series("Series1").ChartType = SeriesChartType.Column

    '        chart.Titles(0).Text = "Total Expenses"

    '        ' Set point width of the series
    '        chart.Series("Series1")("PointWidth") = "0.2"

    '        ' Set drawing style
    '        chart.Series("Series1")("DrawingStyle") = "Cylinder"


    '        chart.Series("Series1")("ShowMarkerLines") = "True"

    '        chart.Series("Series1").BorderWidth = 1

    '        chart.Series("Series1").MarkerStyle = MarkerStyle.None

    '        cmd = New SqlCommand(sql, obj.Connection)
    '        Dim SqlReader As SqlDataReader = cmd.ExecuteReader()
    '        Dim ds1 As DataSet = New DataSet
    '        ds1.Tables.Add()
    '        ds1.Load(SqlReader, LoadOption.OverwriteChanges, ds1.Tables(0))
    '        chart.DataSource = ds1

    '        chart.Series("Series1").XValueMember = ds1.Tables(0).Columns(1).Caption
    '        chart.Series("Series1").YValueMembers = ds1.Tables(0).Columns(0).Caption
    '        chart.DataBind()
    '    Catch ex As Exception
    '        MsgBox("Exception")
    '    Finally
    '        obj.ConClose()
    '    End Try

    'End Sub

    'Protected Sub lnkchart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkchart.Click
    '    pnlChart.Visible = True
    '    sql = " SELECT  sum(tot_exp) as total,empname FROM jct_ops_ta_bills where date between '" & txtEffecFrom.Text & "' AND '" & txtEffecTo.Text & "' and (location =  '" & ddllocation.Text & "' or '" & ddllocation.Text & "' = ' ') and (ccdescrp =  '" & ddlcostcenter.Text & "' or '" & ddlcostcenter.Text & "' = ' ') and (empname =  '" & ddlemployee.Text & "' or '" & ddlemployee.Text & "' = ' ') group by empname"
    '    PopulateBarChart(sql, Chart1)
    'End Sub
End Class

