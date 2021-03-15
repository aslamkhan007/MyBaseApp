Imports System.Data.SqlClient
Imports System.Data
Imports Telerik.Web.UI
Partial Class EmpGateway_Default_asset
    Inherits System.Web.UI.Page
    Dim empcode As String
    Dim i, cnt As Integer
    Public obj As New HelpDeskClass
    Public qry As String
    Public dr As SqlDataReader
    Public cmd As New SqlCommand

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        If (Session("empcode").ToString <> "") Then
            empcode = Session("empcode")
            'Session("Empcode") = "S-13823" Or
            If Session("Empcode") = "K-02064" Or Session("Empcode") = "S-13823" Or Session("Empcode") = "A-00098" Then
                BtnGet.Visible = True
                txtEmpName.Visible = True
                Labelhead.Visible = False
            End If

        Else
            Response.Redirect("~/login.aspx")
        End If

        If Not IsPostBack Then


            Dim sql As String = ("SELECT  TOP 1 item_id  FROM dbo.jct_asset_item_details WHERE  usercode= '" & Session("EmpCode") & "' AND status='A' and   (acceptance_by_email is not null OR  acceptance_by_email ='A' ) and module_usedby='MIS'")
            Dim cmd As New SqlCommand(sql, obj.cn)
            obj.cn.Open()
            cmd.CommandType = CommandType.Text
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()

                    Dim script2 As String = "alert('No more Assets available to Accept!');"
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)

                End While

            End If
            dr.Close()
            obj.cn.Close()


        End If
    End Sub

    Protected Sub BtnGet_Click(sender As Object, e As System.EventArgs) Handles BtnGet.Click
        Panel2.Visible = True
        grdDetailprinter.Visible = True

        Try



            Dim empcodeserc As String
            empcodeserc = txtEmpName.Text.Split("|")(1).ToString()

            Dim sql As String = ("SELECT item_id FROM ( SELECT ROW_NUMBER() OVER (ORDER BY item_id ASC) AS RowNumber,* FROM jct_asset_item_details WHERE Usercode='" & empcodeserc.Trim().ToString() & "'AND status='A' AND module_usedby='MIS') AS foo WHERE RowNumber = 1")
            Dim cmd As New SqlCommand(sql, obj.cn)
            obj.cn.Open()
            cmd.CommandType = CommandType.Text
            Dim dr As SqlDataReader = cmd.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    Dim requestID As String = dr(0).ToString()

                    ViewState("ItemID") = dr(0).ToString()

                End While
            Else
                Panel2.Visible = False
                Return


            End If
            dr.Close()
            obj.cn.Close()

            sql = ("SELECT item_id FROM ( SELECT ROW_NUMBER() OVER (ORDER BY item_id ASC) AS RowNumber,* FROM jct_asset_item_details WHERE Usercode='" & empcodeserc.Trim().ToString() & "'AND status='A' AND module_usedby='MIS') AS foo WHERE RowNumber = 2")
            cmd = New SqlCommand(sql, obj.cn)
            obj.cn.Open()
            cmd.CommandType = CommandType.Text
            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                lnknext.Visible = True
                lnkprev.Visible = True
                lnkexit.Visible = True

            End If


            dr.Close()
            obj.cn.Close()


            sql = ("SELECT jctSR_NO FROM dbo.jct_asset_item_details WHERE item_id= '" & ViewState("ItemID") & "' AND status='A' and module_usedby='MIS'")
            cmd = New SqlCommand(sql, obj.cn)
            obj.cn.Open()
            cmd.CommandType = CommandType.Text

            dr = cmd.ExecuteReader()

            If dr.HasRows Then
                While dr.Read()
                    Dim jctsr_no As String = dr(0).ToString()
                    lblsrno.Text = dr(0).ToString()

                    ViewState("jctsr_no") = dr(0).ToString()
                End While
            End If
            dr.Close()
            obj.cn.Close()
            sql = "jct_asset_item_detail_print"
            cmd = New SqlCommand(sql, obj.cn)
            obj.cn.Open()
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState("ItemID")

            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()

                    lblcomptype.Text = dr("computer_type").ToString()
                    lblCurrentDate.Text = dr("Dated").ToString()
                    lblissuedto.Text = dr("IssueTo").ToString()
                    lbldept.Text = dr("Department").ToString()
                    'lblsrno.Text = dr["jctSR_NO"].ToString();

                    lblmodelno.Text = dr("ModelNo").ToString()

                End While
            End If

            dr.Close()
            obj.cn.Close()


            sql = "jct_asset_item_detail_print2"
            cmd = New SqlCommand(sql, obj.cn)
            obj.cn.Open()

            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState("ItemID")


            dr = cmd.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()

                    'lblDop.Text = dr["DOP"].ToString();
                    'lblipaddress.Text = dr["IP_address"].ToString();

                    lblitemname.Text = dr("item_name").ToString()

                End While
            End If
            dr.Close()
            obj.cn.Close()



            BindDataList()
            printerConfig()

        Catch ex As Exception
            Dim script2 As String = "alert('Enter valid name or some data missing !!');"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", script2, True)
        End Try

    End Sub

    Public Sub BindDataList()

        Dim cmd As New SqlCommand("SELECT  DISTINCT c.item_name,c.asset_id   FROM jct_asset_item_details  a  JOIN  jct_asset_type_item_detail b ON a.item_id=b.request_id  JOIN jct_asset_master c ON b.asset_id=c.asset_id  WHERE a.jctSR_NO=  '" & ViewState("jctsr_no") & "' AND a.status='a' and a.module_usedby='MIS' ", obj.cn)
        cmd.CommandType = CommandType.Text
        Dim ds As New DataSet()
        Dim da As New SqlDataAdapter(cmd)
        da.Fill(ds)
        DataList2.DataSource = ds
        DataList2.DataBind()


    End Sub
    Private Sub printerConfig()
        Dim qry As String = "SELECT  asset_type AS [TYPE], printer_type  AS [Components] , model   AS [Description] FROM dbo.jct_asset_printer_scanner_network WHERE module_usedby='MIS'AND status='A' AND jct_machine_ID= '" & ViewState("jctsr_no") & "' "
        Dim cmd As New SqlCommand(qry, obj.cn)
        cmd.CommandType = CommandType.Text
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        grdDetailprinter.DataSource = ds.Tables(0)
        grdDetailprinter.DataBind()

    End Sub

    Protected Sub DataList2_ItemDataBound1(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList2.ItemDataBound
        If e.Item.ItemType = ListItemType.Item OrElse e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim gv As GridView = DirectCast(e.Item.FindControl("GridView1"), GridView)
            Dim lbh As Label = DirectCast(e.Item.FindControl("Labelhead"), Label)

            Dim asset_id As Integer = CInt(DataList2.DataKeys(e.Item.ItemIndex))
            If gv IsNot Nothing Then

                Dim qry As String = "  SELECT  a.asset_type_name AS [Components], a.item_desc AS [Description]   FROM dbo.jct_asset_type_item_detail  a JOIN  dbo.jct_asset_item_details b  ON b.item_id=a.request_id   JOIN  dbo.jct_asset_master c ON a.asset_id=c.asset_id   WHERE   b.status='A' AND jctSR_NO= '" & ViewState("jctsr_no") & "' AND c.asset_id='" & asset_id & "'"
                Dim cmd As New SqlCommand(qry, obj.cn)
                cmd.CommandType = CommandType.Text
                Dim da As New SqlDataAdapter(cmd)
                Dim ds As New DataSet()
                da.Fill(ds)
                gv.DataSource = ds.Tables(0)

                gv.DataBind()

            End If
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(sender As Object, e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdDetailprinter.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then

            e.Row.Cells(0).Width = New Unit("200px")
            e.Row.Cells(1).Width = New Unit("400px")
        End If
    End Sub

    Protected Sub lnknext_Click(sender As Object, e As System.EventArgs) Handles lnknext.Click
        Dim empcodeserc As String
        empcodeserc = txtEmpName.Text.Split("|")(1).ToString()

        Dim sql As String = ("SELECT item_id FROM ( SELECT ROW_NUMBER() OVER (ORDER BY item_id ASC) AS RowNumber,* FROM jct_asset_item_details WHERE Usercode='" & empcodeserc.Trim().ToString() & "'AND status='A' AND module_usedby='MIS') AS foo WHERE RowNumber = 2")
        Dim cmd As New SqlCommand(sql, obj.cn)
        obj.cn.Open()
        cmd.CommandType = CommandType.Text
        Dim dr As SqlDataReader = cmd.ExecuteReader()

        If dr.HasRows Then
            While dr.Read()
                Dim requestID As String = dr(0).ToString()

                ViewState("ItemID") = dr(0).ToString()

            End While

        End If
        dr.Close()
        obj.cn.Close()
        sql = ("SELECT jctSR_NO FROM dbo.jct_asset_item_details WHERE item_id= '" & ViewState("ItemID") & "' AND status='A' and module_usedby='MIS'")
        cmd = New SqlCommand(sql, obj.cn)
        obj.cn.Open()
        cmd.CommandType = CommandType.Text

        dr = cmd.ExecuteReader()

        If dr.HasRows Then
            While dr.Read()
                Dim jctsr_no As String = dr(0).ToString()
                lblsrno.Text = dr(0).ToString()

                ViewState("jctsr_no") = dr(0).ToString()
            End While
        End If
        dr.Close()
        obj.cn.Close()
        sql = "jct_asset_item_detail_print"
        cmd = New SqlCommand(sql, obj.cn)
        obj.cn.Open()
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState("ItemID")

        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()

                lblcomptype.Text = dr("computer_type").ToString()
                lblCurrentDate.Text = dr("Dated").ToString()
                lblissuedto.Text = dr("IssueTo").ToString()
                lbldept.Text = dr("Department").ToString()
                'lblsrno.Text = dr["jctSR_NO"].ToString();

                lblmodelno.Text = dr("ModelNo").ToString()

            End While
        End If

        dr.Close()
        obj.cn.Close()


        sql = "jct_asset_item_detail_print2"
        cmd = New SqlCommand(sql, obj.cn)
        obj.cn.Open()

        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@requestID", SqlDbType.VarChar, 50).Value = ViewState("ItemID")


        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            While dr.Read()

                'lblDop.Text = dr["DOP"].ToString();
                'lblipaddress.Text = dr["IP_address"].ToString();

                lblitemname.Text = dr("item_name").ToString()

            End While
        End If
        dr.Close()
        obj.cn.Close()



        BindDataList()
        printerConfig()
    End Sub

    Protected Sub lnkprev_Click(sender As Object, e As System.EventArgs) Handles lnkprev.Click
        BtnGet_Click(sender, e)

    End Sub

    Protected Sub lnkexit_Click(sender As Object, e As System.EventArgs) Handles lnkexit.Click
        Response.Redirect("~/login.aspx")
    End Sub
End Class