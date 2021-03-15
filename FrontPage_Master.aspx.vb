Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Partial Class FrontPage_Master
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection
    Dim cmd As New SqlCommand
    Dim SQLPASS, url As String
    Dim Obj2 As Functions = New Functions
    Dim Obj As Connection = New Connection
    Public CstModule As New CostModule
    'Dim comp_code As String = "JCT00LTD"
    Dim MaxRows As Integer
    Dim Dr As SqlDataReader
    Dim Ds As New DataSet
    Dim POPUP, scrpt_str As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'If (Session("Empcode") <> "") Then
            'Else
            '    Response.Redirect("~/login.aspx")
            'End If
            TextDisableMode()
            LoadGrid_parent()
            LoadGrid_DocType()
        End If
        If Me.TxtIconImage.Text = "" Then
            Me.Image2.ImageUrl = "\FusionApps\Image\No_Image.gif"
        End If
    End Sub
    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        '-----------------------------------------
        If cmdAdd.Text = "Save" Then

            If Me.CheckBox1.Checked = True Then

                POPUP = "Yes"

            Else
                Popup = "No"
            End If
            SQLPASS = "Select ItemCode from jct_fap_item_master1 where  ItemCode='" & Me.txtItemCode.Text & "'"
            If Obj2.SelectRecord(SQLPASS) = True Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record Already Exists.."
                FMsg.Display()
            Else
                SQLPASS = "insert into jct_fap_item_master1(CompanyCode,UserCode,ItemCode,SDescription,LDescription,IconImage,ItemCategory,Sequence,EffFrom,EffTo,CreatedDt,Url,ParentItemCode,POPUP,STATUS,Document_Type) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.TxtIconImage.Text & "','" & Me.ddlItemcateg.SelectedItem.Text & "','" & Me.txtSeq.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "',getdate(),'" & Me.txtDocumentIconImage.Text & "','" & Me.txtPItemCode.Text & "','" & POPUP & "','A','" & (Me.TxtDocType.Text) & "')"
                If Obj2.InsertRecord(SQLPASS) = False Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Transaction not Commited"
                    FMsg.Display()
                Else

                    FMsg.CssClass = "errormsg"
                    LoadGrid_parent()
                    LoadGrid_DocType()
                    FMsg.Message = "Records Added Succesfully"
                    FMsg.Display()
                    Obj2.CheckAddEnableDisable(cmdAdd, cmdEdit, cmdDelete, cmdClose, cmdDelete)
                    Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
                    TextBoxBlank()
                    TextDisableMode()
                    LoadGrid()
                End If
            End If
        ElseIf cmdAdd.Text = "Add" Then
            TextBoxBlank()
            Obj2.CheckAddEnableDisable(cmdAdd, cmdEdit, cmdDelete, cmdClose, cmdDelete)
            Obj2.ButtonValidationEnable(cmdAdd, cmdEdit, cmdDelete)
            TextEnableMode()
        End If
        '-----------------------------------------
    End Sub
    Public Sub TextBoxBlank()
        Me.txtItemCode.Text = ""
        Me.txtPItemCode.Text = ""
        Me.txtSDesc.Text = ""
        Me.txtLDesc.Text = ""
        Me.TxtIconImage.Text = ""
        Me.txtSeq.Text = ""
        Me.txtEffFrom.Text = ""
        Me.txtEffTo.Text = ""
        Me.txtDocumentIconImage.Text = ""
        Me.TxtDocType.Text = ""
        Me.Image2.ImageUrl = "\FusionApps\Image\No_Image.gif"
    End Sub
    Public Sub TextEnableMode()
        Me.txtItemCode.Enabled = True
        Me.txtPItemCode.Enabled = True
        Me.txtSDesc.Enabled = True
        Me.txtLDesc.Enabled = True
        Me.TxtIconImage.Enabled = True
        Me.txtSeq.Enabled = True
        Me.txtEffFrom.Enabled = True
        Me.txtEffTo.Enabled = True
        Me.txtDocumentIconImage.Enabled = True
        Me.TxtDocType.Enabled = True
        Me.ddlItemcateg.Enabled = True
        Me.CheckBox1.Enabled = True
        Me.FileUpload1.Enabled = True
        Me.FileUpload2.Enabled = True
    End Sub
    Public Sub TextDisableMode()
        Me.txtItemCode.Enabled = False
        Me.txtPItemCode.Enabled = False
        Me.txtSDesc.Enabled = False
        Me.txtLDesc.Enabled = False
        Me.TxtIconImage.Enabled = False
        Me.txtSeq.Enabled = False
        Me.txtEffFrom.Enabled = False
        Me.txtEffTo.Enabled = False
        Me.txtDocumentIconImage.Enabled = False
        Me.TxtDocType.Enabled = False
        Me.ddlItemcateg.Enabled = False
        Me.CheckBox1.Enabled = False
        Me.FileUpload1.Enabled = False
        Me.FileUpload2.Enabled = False
    End Sub
    Protected Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        If cmdEdit.Text = "Update" Then
            If Me.CheckBox1.Checked = True Then

                POPUP = "Yes"

            Else
                POPUP = "No"
            End If
            SQLPASS = "UPDATE jct_fap_item_master1 SET Status='U',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "'"
            If Obj2.UpdateRecord(SQLPASS) = False Then

                FMsg.CssClass = "errormsg"
                FMsg.Message = "Update Transaction not Commited"
                FMsg.Display()
            Else
                SQLPASS = "insert into jct_fap_item_master1(CompanyCode,UserCode,ItemCode,SDescription,LDescription,IconImage,ItemCategory,Sequence,EffFrom,EffTo,CreatedDt,Url,ParentItemCode,popup,STATUS,Document_Type) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.TxtIconImage.Text & "','" & Me.ddlItemcateg.SelectedItem.Text & "','" & Me.txtSeq.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "',getdate(),'" & Me.txtDocumentIconImage.Text & "','" & Me.txtPItemCode.Text & "','" & POPUP & "','A','" & (Me.TxtDocType.Text) & "')"
                If Obj2.InsertRecord(SQLPASS) = True Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Updated Record Succesfully"
                    LoadGrid_parent()
                    LoadGrid_DocType()
                    FMsg.Display()
                    Obj2.CheckEditEnableDisable(cmdEdit, cmdAdd, cmdDelete, cmdClose, cmdDelete)
                    Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
                    TextBoxBlank()
                    TextDisableMode()
                    LoadGrid()
                Else
                    Obj2.ButtonValidationEnable(cmdAdd, cmdEdit, cmdDelete)

                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Update Transaction not Commited"
                    FMsg.Display()
                    'SQLPASS = "UPDATE jct_fap_item_master1 SET Status='U',CreatedDt=getdate() where ItemCode='" & Me.txtItemCode.Text & "'"
                    'Obj2.UpdateRecord(SQLPASS)
                    'Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
                End If
            End If
        ElseIf cmdEdit.Text = "Edit" Then
            Obj2.CheckEditEnableDisable(cmdEdit, cmdAdd, cmdDelete, cmdClose, cmdEdit)
            Obj2.ButtonValidationEnable(cmdAdd, cmdEdit, cmdDelete)
            TextEnableMode()
            Me.txtItemCode.Enabled = False
        End If
    End Sub

    Protected Sub cmdClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        If cmdClose.Text = "Close" Then
            Response.Redirect("Default.aspx")
        Else
            If Trim(Me.TxtIconImage.Text) <> "" And Me.cmdAdd.Text = "Save" Then
                System.IO.File.Delete("\FusionApps\" + Trim(Me.TxtIconImage.Text))
            End If
            If Me.TxtDocType.Text <> "" And Me.cmdAdd.Text = "Save" And Me.txtDocumentIconImage.Text <> "" Then
                System.IO.File.Delete("\FusionApps\" & Trim(Me.txtDocumentIconImage.Text))
            End If
            Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
            Obj2.CheckCloseEnableDisable(cmdClose, cmdAdd, cmdEdit, cmdDelete, cmdEdit)
            TextDisableMode()
            TextBoxBlank()

        End If
    End Sub
    Protected Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
        TextEnableMode()
        If Trim(Me.txtItemCode.Text) <> "" Then
            SQLPASS = "UPDATE jct_fap_item_master1 SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "'"
            If Obj2.UpdateRecord(SQLPASS) = False Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Deleted Transaction not Commited"
                FMsg.Display()
            Else
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record DeActived Succesfully"
                FMsg.Display()
                Obj2.CheckDeActiveEnableDisable(cmdDelete, cmdAdd, cmdEdit, cmdClose)
                Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
                TextBoxBlank()
                TextDisableMode()
                LoadGrid()
            End If
        Else
            FMsg.CssClass = "errormsg"
            FMsg.Message = "Item Code required"
            FMsg.Display()
        End If

    End Sub

    'Protected Sub ddlItemcateg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemcateg.SelectedIndexChanged
    '    If Me.ddlItemcateg.SelectedValue = "Frame" Then
    '        Me.txtItemCode.Enabled = True
    '        Me.txtPItemCode.Enabled = False
    '        Me.txtSDesc.Enabled = True
    '        Me.txtLDesc.Enabled = True
    '        Me.txtIconImage.Enabled = True
    '        Me.txtSeq.Enabled = True
    '        Me.txtEffFrom.Enabled = True
    '        Me.txtEffTo.Enabled = True
    '        Me.txtCrDt.Enabled = True
    '        Me.txtURL.Enabled = True
    '    Else
    '        Me.txtItemCode.Enabled = True
    '        Me.txtPItemCode.Enabled = True
    '        Me.txtSDesc.Enabled = True
    '        Me.txtLDesc.Enabled = True
    '        Me.txtIconImage.Enabled = True
    '        Me.txtSeq.Enabled = True
    '        Me.txtEffFrom.Enabled = True
    '        Me.txtEffTo.Enabled = True
    '        Me.txtCrDt.Enabled = True
    '        Me.txtURL.Enabled = True
    'End If

    'End Sub
    Protected Sub btnlnk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdsearch.Click
        LoadGrid()
    End Sub
    Protected Sub LoadGrid()
        SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ICONIMAGE,ITEMCATEGORY,SEQUENCE,URL,PARENTITEMCODE,POPUP,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],Document_Type as [Document Type]  from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        Obj2.FillGrid(SQLPASS, GrdHelp)
    End Sub
    Protected Sub LoadGrid_parent()
        SQLPASS = "SELECT  PARENTITEMCODE,[Code]=ITEMCODE, [Short Desc]=SDESCRIPTION from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        Obj2.FillGrid(SQLPASS, GridView1)
    End Sub
    Protected Sub LoadGrid_DocType()
        SQLPASS = "SELECT distinct Document_Type as [Document Type] from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        Obj2.FillGrid(SQLPASS, GrdDocType)
    End Sub
    Protected Sub grdHelp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdHelp.SelectedIndexChanged
        Me.PopupExp.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())
        '----------------------------------------------
        txtItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
        txtSDesc.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
        txtLDesc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")
        TxtIconImage.Text = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
        ddlItemcateg.SelectedValue = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")

        txtSeq.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
        txtDocumentIconImage.Text = Replace(GrdHelp.SelectedRow.Cells(7).Text.ToString, "&nbsp;", "")
        txtPItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")
        If Replace(GrdHelp.SelectedRow.Cells(9).Text.ToString, "&nbsp;", "").ToString = "Yes" Then
            Me.CheckBox1.Checked = True
        Else
            Me.CheckBox1.Checked = False
        End If
        txtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(10).Text.ToString, "&nbsp;", "")
        txtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(11).Text.ToString, "&nbsp;", "")
        Me.Image2.ImageUrl = "\FusionApps\" + Trim(Me.TxtIconImage.Text)
        TxtDocType.Text = Replace(GrdHelp.SelectedRow.Cells(13).Text.ToString, "&nbsp;", "")
    End Sub
    Protected Sub Grdhelp_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdHelp.RowDataBound
        If e.Row.RowType <> DataControlRowType.DataRow Then
            Exit Sub
        End If
        e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("LinkButton3"), String.Empty))
    End Sub
    Protected Sub GrdHelp_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdHelp.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow And (e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate) Then
            'e.Row.Attributes.Add("onmouseover", e.Row.Cells(0).Text)
            e.Row.Attributes.Add("onmouseover", "this.className='highlightrow'")
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'")
            e.Row.TabIndex = -1
            e.Row.Attributes("onclick") = String.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex)
            e.Row.Attributes("onkeydown") = "javascript:return SelectSibling(event);"
            e.Row.Attributes("onselectstart") = "javascript:return false;"
        End If
    End Sub

    Protected Sub CmdFirst_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdFirst.Click
        If MaxRows <= 0 Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ICONIMAGE,ITEMCATEGORY,SEQUENCE,URL,PARENTITEMCODE,POPUP,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],document_type   from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
            AdapterRecord(SQLPASS, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = 0
        Navigation(0)
        CmdFirst.Enabled = False
        CmdNext.Enabled = True
        CmdPrevious.Enabled = True
        CmdLast.Enabled = True
        Me.GrdHelp.SelectedIndex = 0
    End Sub
    Protected Sub CmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdNext.Click
        If MaxRows <= 0 Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ICONIMAGE,ITEMCATEGORY,SEQUENCE,URL,PARENTITEMCODE,POPUP,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],document_type  from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
            AdapterRecord(SQLPASS, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = ViewState("Count") + 1

        If ViewState("Count") < MaxRows - 1 And ViewState("Count") <> MaxRows Then
            CmdPrevious.Enabled = True
            CmdFirst.Enabled = True
        Else
            CmdNext.Enabled = False
            CmdLast.Enabled = False
            CmdFirst.Enabled = True
            CmdPrevious.Enabled = True
        End If
        Navigation(ViewState("Count"))
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.SelectedIndex + 1
    End Sub

    Protected Sub CmdPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrevious.Click
        If MaxRows <= 0 Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ICONIMAGE,ITEMCATEGORY,SEQUENCE,URL,PARENTITEMCODE,POPUP,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],document_type  from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
            AdapterRecord(SQLPASS, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        ViewState("Count") = ViewState("Count") - 1

        If ViewState("Count") < MaxRows - 1 And ViewState("Count") <> 0 Then
            CmdNext.Enabled = True
            CmdLast.Enabled = True
        Else
            CmdPrevious.Enabled = False
            CmdFirst.Enabled = False
            CmdNext.Enabled = True
            CmdLast.Enabled = True
        End If

        Navigation(ViewState("Count"))
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.SelectedIndex - 1
    End Sub
    Protected Sub CmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdLast.Click
        If MaxRows <= 0 Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ICONIMAGE,ITEMCATEGORY,SEQUENCE,URL,PARENTITEMCODE,POPUP,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],document_type   from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
            AdapterRecord(SQLPASS, CmdFirst, CmdNext, CmdPrevious, CmdLast)
        End If
        Navigation(MaxRows - 1)
        ViewState("Count") = MaxRows - 1
        CmdLast.Enabled = False
        CmdNext.Enabled = False
        CmdPrevious.Enabled = True
        CmdFirst.Enabled = True
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.Rows.Count() - 1
    End Sub
    Protected Sub Navigation(ByVal i As Integer)
        Try
            txtItemCode.Text = Ds.Tables(0).Rows(i).Item(0)
            txtSDesc.Text = Ds.Tables(0).Rows(i).Item(1)
            txtLDesc.Text = Ds.Tables(0).Rows(i).Item(2)
            TxtIconImage.Text = Ds.Tables(0).Rows(i).Item(3)
            ddlItemcateg.SelectedValue = Ds.Tables(0).Rows(i).Item(4)
            txtSeq.Text = Ds.Tables(0).Rows(i).Item(5)
            txtDocumentIconImage.Text = Ds.Tables(0).Rows(i).Item(6)
            txtPItemCode.Text = Ds.Tables(0).Rows(i).Item(7)
            If Ds.Tables(0).Rows(i).Item(8).ToString = "Yes" Then
                Me.CheckBox1.Checked = True
            Else
                Me.CheckBox1.Checked = False
            End If
            txtEffFrom.Text = Ds.Tables(0).Rows(i).Item(9)
            txtEffTo.Text = Ds.Tables(0).Rows(i).Item(10)
            TxtDocType.Text = Ds.Tables(0).Rows(i).Item(12)
        Catch ex As Exception
        Finally
            'Dr.Close()

        End Try
        Me.Image2.ImageUrl = "\FusionApps\" + Trim(Me.TxtIconImage.Text)
    End Sub
    Public Function AdapterRecord(ByVal Sqlpass As String, ByVal CmdFirst As LinkButton, ByVal CmdNext As LinkButton, ByVal CmdPrev As LinkButton, ByVal CmdLast As LinkButton) As Integer
        Dim Dr As SqlDataReader = Obj.FetchReader(Sqlpass)
        Dim Da As SqlDataAdapter = New SqlDataAdapter(Sqlpass, Obj.Connection())
        Dr.Close()
        Ds.Clear()
        Da.Fill(Ds)
        MaxRows = Ds.Tables(0).Rows.Count
        If Ds.Tables(0).Rows.Count = 1 Then
            CmdNext.Enabled = False
            CmdPrev.Enabled = False
            CmdFirst.Enabled = False
            CmdLast.Enabled = False
            MaxRows = 1
        End If
        Dr.Close()
    End Function
    'Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
    '    If Me.ddlItemcateg.SelectedItem.Text = "Frame" Then
    '        CstModule.ErrvalidatorEnable(Err1)
    '        CstModule.ErrvalidatorEnable(Err2)
    '        CstModule.ErrvalidatorEnable(Err3)
    '        CstModule.ErrvalidatorEnable(Err4)
    '        'CstModule.ErrvalidatorEnable(Err5)
    '        CstModule.ErrvalidatorEnable(Err6)
    '        CstModule.ErrvalidatorEnable(Err7)
    '        CstModule.ErrvalidatorEnable(Err8)
    '        CstModule.ErrvalidatorEnable(Err9)
    '        CstModule.ErrvalidatorEnable(Err10)
    '    Else
    '        CstModule.ErrvalidatorEnable(Err1)
    '        CstModule.ErrvalidatorEnable(Err2)
    '        CstModule.ErrvalidatorEnable(Err3)
    '        CstModule.ErrvalidatorEnable(Err4)
    '        CstModule.ErrvalidatorEnable(Err5)
    '        CstModule.ErrvalidatorEnable(Err6)
    '        CstModule.ErrvalidatorEnable(Err7)
    '        CstModule.ErrvalidatorEnable(Err8)
    '        CstModule.ErrvalidatorEnable(Err9)
    '        CstModule.ErrvalidatorEnable(Err10)
    '    End If
    'End Sub

    Protected Sub CmdUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdUpload.Click
        If FileUpload1.HasFile Then
            Dim ext As String
            Dim st As String = StrReverse(FileUpload1.FileName)
            ext = StrReverse(st.Substring(0, 3))
            'If ext <> "jpg" Then
            '    Exit Sub
            'End If

            FileUpload1.PostedFile.SaveAs("D:\WebApplications\FusionApps\Image\" + FileUpload1.FileName)
            Me.TxtIconImage.Text = "Image\" + FileUpload1.FileName
            Me.Image2.ImageUrl = "\FusionApps\" + Trim(Me.TxtIconImage.Text)
            FMsg.Message = "Image Uploaded"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
        End If

    End Sub
    Protected Sub CmdUpload0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdUpload0.Click
        If FileUpload2.HasFile Then
            If Me.TxtDocType.Text = "" Then
                FMsg.Message = "Please Define Document Type"
                FMsg.CssClass = "errormsg"
                FMsg.Display()
                SetFocus(TxtDocType)
                Exit Sub
            End If
            Dim ext As String
            Dim st As String = StrReverse(FileUpload2.FileName)
            ext = StrReverse(st.Substring(0, 3))
            Dim storepath As String = "\FusionApps\Docs\" & Trim(Me.TxtDocType.Text)
            If Not Directory.Exists(storepath) Then
                Directory.CreateDirectory(storepath)
            End If
            FileUpload2.PostedFile.SaveAs("\FusionApps\Docs\" & Trim(Me.TxtDocType.Text) & "\" & FileUpload2.FileName)
            Me.txtDocumentIconImage.Text = "Docs\" & Trim(Me.TxtDocType.Text) & "\" & FileUpload2.FileName
            FMsg.Message = "Image Uploaded"
            FMsg.CssClass = "errormsg"
            FMsg.Display()
        End If
    End Sub
    'Private Sub Get_url()
    '    If Me.CheckBoxList1.Items(0).Selected = True Then
    '        url=<a href="javascript:void(0)" onclick = "window.open('EmpGateway/Order/Holidays2010.jpg')">Holiday Calendar 2010</a><br/><a href="javascript:void(0)" onclick = "window.open('EmpGateway/Order/Amendment in Service Rules-Retirement of Employees.jpg')">Amendmen
    '    Else
    '    End If
    'End Sub
    Protected Sub txtDocumentIconImage_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDocumentIconImage.TextChanged
    End Sub
    Protected Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow And (e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate) Then
            'e.Row.Attributes.Add("onmouseover", e.Row.Cells(0).Text)
            e.Row.Attributes.Add("onmouseover", "this.className='highlightrow'")
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'")
            e.Row.TabIndex = -1
            e.Row.Attributes("onclick") = String.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex)
            e.Row.Attributes("onkeydown") = "javascript:return SelectSibling(event);"
            e.Row.Attributes("onselectstart") = "javascript:return false;"
        End If
    End Sub

    Protected Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType <> DataControlRowType.DataRow Then
            Exit Sub
        End If
        e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("LinkButton4"), String.Empty))
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        txtPItemCode.Text = Replace(GridView1.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
    End Sub

    Protected Sub GrdDocType_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdDocType.RowCreated
        If e.Row.RowType = DataControlRowType.DataRow And (e.Row.RowState = DataControlRowState.Normal Or e.Row.RowState = DataControlRowState.Alternate) Then
            'e.Row.Attributes.Add("onmouseover", e.Row.Cells(0).Text)
            e.Row.Attributes.Add("onmouseover", "this.className='highlightrow'")
            e.Row.Attributes.Add("onmouseout", "this.className='normalrow'")
            e.Row.TabIndex = -1
            e.Row.Attributes("onclick") = String.Format("javascript:SelectRow(this, {0});", e.Row.RowIndex)
            e.Row.Attributes("onkeydown") = "javascript:return SelectSibling(event);"
            e.Row.Attributes("onselectstart") = "javascript:return false;"
        End If
    End Sub

    Protected Sub GrdDocType_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GrdDocType.RowDataBound
        If e.Row.RowType <> DataControlRowType.DataRow Then
            Exit Sub
        End If
        e.Row.Attributes.Add("OnClick", Me.Page.ClientScript.GetPostBackEventReference(e.Row.Cells(0).FindControl("LinkButton5"), String.Empty))
    End Sub
    Protected Sub GrdDocType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdDocType.SelectedIndexChanged
        TxtDocType.Text = Replace(GrdDocType.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
    End Sub
End Class
