Imports System.Data
Imports System.Data.SqlClient
Partial Class Default_New
    Inherits System.Web.UI.Page

    'Shared selectedMenuItem1 As String = 0

    'Dim constr As String = System.Web.Configuration.WebConfigurationManager.ConnectionStrings("misjctdev").ConnectionString
    Dim WithEvents dl1 As DataList = New DataList
    'Dim WithEvents mnu As Menu = New Menu
    Dim sql As String
    'Dim WithEvents mnu1 As Menu = New Menu

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            CType(Master.FindControl("lblUser"), Label).Text = IIf(Session("Empname") = "", "JCTians", Session("Empname"))
            Dim ob As CostModule = New CostModule()

            '--Save user hit on application
            RegAppHit(Session("Companycode"), Session("Empcode"), "FusionApps", Request.UserHostAddress)

            '--Fetch Data to fill Page Data in Frames
            'Dim sql As String = "select 'News' 'data' union select 'JCT Links' 'data' union select 'Coming Up' 'data' union select 'Office Orders' 'data'"

            Dim sql_left_frame As String = "jct_fap_main_page_frames 'o'"
            Dim sql_right_frame As String = "jct_fap_main_page_frames 'e'"

            'Dim da As SqlDataAdapter = New SqlDataAdapter(sql, cn)
            'Dim ds As DataSet = New DataSet()
            'da.Fill(ds)

            'Try
            DataList2.DataSource = ob.FetchDS(sql_left_frame).Tables(0)
            DataList2.DataBind()
            DataList4.DataSource = ob.FetchDS(sql_right_frame).Tables(0)
            DataList4.DataBind()
            'Catch

            'End Try

        End If
        CType(Master.FindControl("lnkHome"), LinkButton).Visible = False
        GenerateMarqueeContent("JCT00LTD")

    End Sub

    Protected Sub DataList2_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList2.ItemDataBound

        'fillChildMenuAndDataList("dlChild", "Menu1", e)
        Dim ob As CostModule = New CostModule

        Try
            Dim item As String = CType(e.Item.FindControl("hiddenfield1"), HiddenField).Value
            'Dim sql As String = "select 'News' 'text' union select 'JCT Links' 'text' union select 'Coming Up' 'text'"

            'To Fetch Menu Items

            sql = "select itemcode 'value', sdescription 'text', ldescription 'desc' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D' order by sequence"
            Dim ds As DataSet = New DataSet()
            ds = ob.FetchDS(sql)
            ds.DataSetName = "Menus"
            ds.Tables(0).TableName = "Menu"
            Dim m1 As Menu = CType(e.Item.FindControl("Menu1"), Menu)

            'To Fill Menu Items
            Dim xmlds1 As XmlDataSource = New XmlDataSource
            xmlds1.ID = "xmlds1"
            xmlds1.EnableCaching = False
            xmlds1.TransformFile = "FrameMenuTrans.xslt"
            xmlds1.Data = ds.GetXml()
            ds.Dispose()
            xmlds1.XPath = "MenuItems/MenuItem"
            'ds.WriteXml("Samplexmlfile.xml")
            m1.DataSource = xmlds1
            m1.DataBind()
            m1.Items(0).Selected = True
            item = m1.Items(0).Value

            sql = "select itemcode 'value', sdescription 'text', url, iconimage, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D'"

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'Dim dl1 As DataList = CType(e.Item.FindControl("DataList3"), DataList)
                dl1 = CType(e.Item.FindControl("dlChild"), DataList)
                dl1.DataSource = FetchRecords(sql)
                dl1.DataBind()
            End If
            'mnu = CType(e.Item.FindControl("Menu1"), Menu)

            Dim img As Image = CType(e.Item.FindControl("Image1"), Image)
            sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
            img.ImageUrl = FetchValue(sql).ToString

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub DataList4_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList4.ItemDataBound

        'fillChildMenuAndDataList("dlChild", "Menu1", e)
        Dim ob As CostModule = New CostModule
        Try
            Dim item As String = CType(e.Item.FindControl("hiddenfield2"), HiddenField).Value

            'To Fetch Menu Items

            sql = "select itemcode 'value', sdescription 'text', url, iconimage, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D' order by sequence"

            Dim ds As DataSet = New DataSet()
            ds = ob.FetchDS(sql)
            ds.DataSetName = "Menus"
            ds.Tables(0).TableName = "Menu"

            Dim m1 As Menu = CType(e.Item.FindControl("Menu2"), Menu)

            'To Fill Menu Items

            Dim xmlds1 As XmlDataSource = New XmlDataSource
            xmlds1.ID = "xmlds1"
            xmlds1.EnableCaching = False
            xmlds1.TransformFile = "FrameMenuTrans.xslt"
            xmlds1.Data = ds.GetXml()
            ds.Dispose()
            xmlds1.XPath = "MenuItems/MenuItem"
            'ds.WriteXml("Samplexmlfile.xml")
            m1.DataSource = xmlds1
            m1.DataBind()
            m1.Items(0).Selected = True
            item = m1.Items(0).Value

            sql = "select itemcode 'value', sdescription 'text', url, iconimage, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D'"

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
                'Dim dl1 As DataList = CType(e.Item.FindControl("DataList3"), DataList)
                dl1 = CType(e.Item.FindControl("dlChild2"), DataList)
                dl1.DataSource = FetchRecords(sql)
                dl1.DataBind()
            End If
            'mnu = CType(e.Item.FindControl("Menu1"), Menu)

            Dim img As Image = CType(e.Item.FindControl("Image2"), Image)
            sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
            img.ImageUrl = FetchValue(sql).ToString

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub Menu1_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs) Handles Menu1.MenuItemClick
        Dim item As String = e.Item.Value
        'selectedMenuItem1 = e.Item.Value
        Dim ob As Functions = New Functions

        Dim sql As String = "select itemcode 'value', sdescription 'text', url, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D'"

        Dim dl As DataList = CType(sender, Menu).Parent.FindControl("dlChild")

        dl.DataSource = ob.FetchRecords(sql)
        dl.DataBind()

        Dim img As Image = CType(sender, Menu).Parent.FindControl("Image1")
        sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
        img.ImageUrl = IIf(FetchValue(sql) Is DBNull.Value, "", FetchValue(sql).ToString)
        e.Item.Selected = True

    End Sub

    Protected Sub Menu2_MenuItemClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MenuEventArgs)
        Dim item As String = e.Item.Value
        'selectedMenuItem1 = e.Item.Value
        Dim ob As Functions = New Functions
        Dim sql As String = "select itemcode 'value', sdescription 'text', url, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D'"

        Dim dl As DataList = CType(sender, Menu).Parent.FindControl("dlChild2")

        dl.DataSource = ob.FetchRecords(sql)
        dl.DataBind()

        Dim img As Image = CType(sender, Menu).Parent.FindControl("Image2")
        sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
        img.ImageUrl = IIf(FetchValue(sql) Is DBNull.Value, "", FetchValue(sql).ToString)
        e.Item.Selected = True

    End Sub

    Protected Sub fillChildMenuAndDataList(ByVal DatalistName As String, ByVal MenuName As String, ByVal e As System.Web.UI.WebControls.DataListItemEventArgs)
        Try
            Dim item As String = CType(e.Item.FindControl("hiddenfield1"), HiddenField).Value
            Dim ob As Functions = New Functions
            'To Fetch Menu Items

            sql = "select itemcode 'value', sdescription 'text', ldescription 'desc' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D'"

            Dim ds As DataSet = ob.FetchDS(sql)
            ds.DataSetName = "Menus"
            ds.Tables(0).TableName = "Menu"

            Dim m1 As Menu = CType(e.Item.FindControl(MenuName), Menu)

            'To Fill Menu Items

            Dim xmlds1 As XmlDataSource = New XmlDataSource
            xmlds1.ID = "xmlds1"
            xmlds1.EnableCaching = False
            xmlds1.TransformFile = "FrameMenuTrans.xslt"
            xmlds1.Data = ds.GetXml()
            ds.Dispose()
            xmlds1.XPath = "MenuItems/MenuItem"
            m1.DataSource = xmlds1
            m1.DataBind()

            item = m1.Items(0).Value

            sql = "select itemcode 'value', sdescription 'text', url, iconimage, ldescription 'desc', effFrom 'date' from jct_fap_item_master where parentitemcode = '" & item & "' and status <> 'D'"

            If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then

                dl1 = CType(e.Item.FindControl(DatalistName), DataList)
                dl1.DataSource = FetchRecords(sql)
                dl1.DataBind()
            End If
            'mnu = CType(e.Item.FindControl("Menu1"), Menu)

            Dim img As Image = CType(e.Item.FindControl("Image1"), Image)
            sql = "select iconimage from jct_fap_item_master where itemcode = '" & item & "'"
            img.ImageUrl = FetchValue(sql).ToString

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub DataList4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles oDataList4.SelectedIndexChanged

    End Sub

    Protected Sub Menu2_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        'DirectCast(sender, Menu).Items(selectedMenuItem1).Selected = True

    End Sub

    Protected Sub GenerateMarqueeContent(ByVal CompanyCode As String)
        Dim obj As New HelpDeskClass
        Dim qry As String
        Dim dr As SqlDataReader
        Dim cmd As New SqlCommand

        Dim marquee As New Literal()
        Dim mytext, mytext1, monthyear, txt As String
        mytext = ""
        mytext1 = ""
        monthyear = ""
        txt = ""

        obj.opencn()
        qry = "select replace(FileName,' ','&nbsp'),FileExt,transaction_no,replace(Department,' ','&nbsp'),replace(description,' ','%20'), replace(headline,' ','&nbsp') from jct_empg_News where headline is not null and getdate() between news_start_date and news_start_date + 15 and getdate() between news_start_date and news_end_date"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()

                '-----------------------for few times hitesh
                'txt = txt & "&nbsp&nbsp<a style =""color:White"" href=""PhotoGallery.aspx?Transaction=100008&Flag=P"">" & dr.Item(5) & "</a>&nbsp~~"
                txt = txt & "&nbsp&nbsp<a style =""color:White"" href=""PhotoGallery.aspx?Transaction=100008&Flag=P"">News Text</a>&nbsp~~"
                '-----------------------------
                'txt = txt & "&nbsp&nbsp<a href=NewsDetail.aspx?description=" & dr.Item(4) & "&Transac=" & dr.Item(2) & "&path=News\" & dr.Item(3) & "\Ext\" & dr.Item(0) & dr.Item(1) & """>" & dr.Item(5) & "</a>&nbsp&nbsp"
            End While
        End If
        dr.Close()
        obj.closecn()

        obj.opencn()
        qry = "JCT_Emp_Marquee_All '" & CompanyCode & "'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If monthyear <> dr.Item(1) Then

                    If Trim(mytext1) <> "" Then
                        mytext1 = mytext1 & " has been transferred in your Bank A/c for the month of  " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ". Allowance Of " & dr.Item(0)
                    Else
                        mytext1 = mytext1 & "~~ Allowance of " & dr.Item(0)
                    End If
                    monthyear = dr.Item(1)
                Else
                    mytext1 = mytext1 & " , " & dr.Item(0)
                End If
            End While
            mytext1 = mytext1 & " has been transferred in your Bank A/c for the month of  " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ".~~"
        End If
        dr.Close()
        obj.closecn()
        monthyear = ""
        obj.opencn()
        qry = "JCT_Emp_Marquee'" & CompanyCode & "'"
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        If dr.HasRows = True Then
            While dr.Read()
                If monthyear <> dr.Item(1) Then
                    If Trim(mytext) <> "" Then
                        mytext = mytext & " has been transferred for the month of " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ". Salary Of " & dr.Item(0)
                    Else
                        mytext = mytext & "~~ Salary Of " & dr.Item(0)
                    End If
                    monthyear = dr.Item(1)
                Else
                    mytext = mytext & " , " & dr.Item(0)
                End If
            End While
            mytext = mytext & " has been transferred for the month of " & MonthName(Right(monthyear, 2)) & " " & Left(monthyear, 4) & ".~~"
        End If
        dr.Close()
        obj.closecn()
        mytext = mytext1 + mytext
        obj.opencn()
        qry = "select b.shortdesc, a.fullname from jct_epor_master_employee a, JCT_EPOR_MASTER_SALUATION b  where a.salute=b.salt_code and a.active_flag='y' and month(dob) =month(getdate()) and day(dob)=day(getdate())  and a.status='a' and b.status='a' and getdate() between a.eff_from and a.eff_to "
        cmd = New SqlCommand(qry, obj.cn)
        dr = cmd.ExecuteReader
        Dim bday As String

        If dr.HasRows = True Then
            While dr.Read()
                If Trim(bday) = "" Then
                    bday = " ~~ JCT Family Sends Heartiest Greetings To " & dr.Item(0) & " " & dr.Item(1)
                Else
                    bday = bday & ", " & dr.Item(0) & " " & dr.Item(1)
                End If
            End While
            bday = bday & " On BirthDay!! ~~"
        End If
        dr.Close()
        obj.closecn()

        Dim news As String = ""
        Dim update As String = ""
        update = update & " ~~ Please find ""Health Tips"" updated daily at around 12:00 pm under ""News"" Section. ~~ "
        update = update & " ~~ JCT T20 Cricket League - Updates available at ""Notice Board"". ~~ "
        mytext = news & bday & mytext & update & "~~ Please keep your Contact Detail up to date in Employee Gateway -> JCT Family -> JCTians ~~"

        mytext = "<DIV style = filter:shadow(color:black,strength:2,direction:135);><nobr>" & mytext & "</nobr></DIV>"
        Page.ClientScript.RegisterClientScriptBlock(Me.GetType(), "m", "marqueecontent='" & mytext & "'", True)

    End Sub

End Class
