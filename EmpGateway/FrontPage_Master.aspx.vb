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
            If (Session("Empcode") <> "") Then
            Else
                Response.Redirect("~/login.aspx")
            End If
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
                POPUP = "No"
            End If

            If Me.txtPItemCode.Text = "" Then
                txtPItemCode.Text = Nothing
            End If

            If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
                SQLPASS = "Select ItemCode from jct_fap_shared_area where  ItemCode='" & Me.txtItemCode.Text & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 "
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                SQLPASS = "Select ItemCode from jct_fap_My_Area_Master1 where  ItemCode='" & Me.txtItemCode.Text & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 "
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
                SQLPASS = "Select ItemCode from jct_fap_tech_news where  ItemCode='" & Me.txtItemCode.Text & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 "
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
                SQLPASS = "Select ItemCode from jct_fap_notice_board where  ItemCode='" & Me.txtItemCode.Text & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 "
            Else
                SQLPASS = "Select ItemCode from jct_fap_item_master1 where  ItemCode='" & Me.txtItemCode.Text & "' and status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0 "
            End If

            If Obj2.SelectRecord(SQLPASS) = True Then
                FMsg.CssClass = "errormsg"
                FMsg.Message = "Record Already Exists.."
                FMsg.Display()
            Else
                If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
                    SQLPASS = "insert into jct_fap_shared_area(CompanyCode,UserCode,ItemCode,SDescription,LDescription,itemcat,ParentItem,URL,createddt,efffrom,effto,STATUS,doc_type) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.ddlItemcateg.SelectedValue & "','" & Me.txtPItemCode.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','','" & Me.TxtDocType.Text & "')"
                ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                    SQLPASS = "insert into jct_fap_My_Area_Master1(CompanyCode,UserCode,ItemCode,SDescription,LDescription,itemcat,ParentItem,IconImageURL,PageUrl,createddt,efffrom,effto,STATUS) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.ddlItemcateg.SelectedValue & "','" & Me.txtPItemCode.Text & "','" & Me.TxtIconImage.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','')"
                ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
                    SQLPASS = "insert into jct_fap_tech_news(CompanyCode,UserCode,ItemCode,SDescription,LDescription,ParentItem,Url,createddt,efffrom,effto,STATUS) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.txtPItemCode.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','')"
                ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
                    SQLPASS = "insert into jct_fap_notice_board(CompanyCode,UserCode,ItemCode,SDescription,LDescription,ParentItem,Url,createddt,efffrom,effto,STATUS) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.txtPItemCode.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','')"
                Else
                    SQLPASS = "insert into jct_fap_item_master1(CompanyCode,UserCode,ItemCode,SDescription,LDescription,IconImage,ItemCategory,Sequence,EffFrom,EffTo,CreatedDt,Url,ParentItemCode,POPUP,STATUS,Document_Type) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.TxtIconImage.Text & "','" & Me.ddlItemcateg.SelectedItem.Text & "','" & Me.txtSeq.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtPItemCode.Text & "','" & POPUP & "','A','" & (Me.TxtDocType.Text) & "')"
                End If

                If Obj2.InsertRecord(SQLPASS) = False Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Transaction not Commited"
                    FMsg.Display()
                Else

                    FMsg.CssClass = "errormsg"
                    LoadGrid_parent()
                    LoadGrid_DocType()
                    FMsg.Message = "Record Added Succesfully"
                    FMsg.Display()
                    Obj2.CheckAddEnableDisable(cmdAdd, cmdEdit, cmdDelete, cmdClose, cmdDelete)
                    Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
                    LoadGrid()
                    TextBoxBlank()
                    TextDisableMode()
                End If
            End If
        ElseIf cmdAdd.Text = "Add" Then
            TextBoxBlank()
            Obj2.CheckAddEnableDisable(cmdAdd, cmdEdit, cmdDelete, cmdClose, cmdDelete)
            Obj2.ButtonValidationEnable(cmdAdd, cmdEdit, cmdDelete)
            TextEnableMode()
            Me.txtItemCode.Focus()
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
        Me.txtEffFrom.Text = Now.Date()
        Me.txtEffTo.Text = "01/01/9999"
        Me.txtCreatedDate.Text = Now.Date()
        Me.txtDocumentIconImage.Text = ""
        '  Me.TxtDocType.Text = ""
        Me.Image2.ImageUrl = "\FusionApps\Image\No_Image.gif"
        If Me.GrdHelp.Rows.Count > 0 Then
            Me.GrdHelp.SelectedIndex = -1
        End If
        If Me.GridView1.Rows.Count > 0 Then
            Me.GridView1.SelectedIndex = -1
        End If
        If Me.GrdDocType.Rows.Count > 0 Then
            Me.GrdDocType.SelectedIndex = -1
        End If
        Me.HyperLink1.NavigateUrl = Nothing
    End Sub
    Public Sub TextEnableMode()
        If Me.cmdAdd.Text = "Save" Then
            Me.txtItemCode.Enabled = True
        Else
            Me.txtItemCode.Enabled = False
        End If
        Me.txtPItemCode.Enabled = True
        Me.txtSDesc.Enabled = True
        Me.txtLDesc.Enabled = True
        Me.txtCreatedDate.Enabled = True
        Me.txtEffFrom.Enabled = True
        Me.txtEffTo.Enabled = True
        Me.txtDocumentIconImage.Enabled = True
        Me.TxtDocType.Enabled = True
        Me.ddlItemcateg.Enabled = True
        If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Or Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Or Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
            Me.FileUpload1.Enabled = False
            Me.TxtIconImage.Enabled = False
            Me.txtSeq.Enabled = False
            Me.CheckBox1.Enabled = False
            Me.FileUpload2.Enabled = True
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
            Me.FileUpload2.Enabled = False
            Me.FileUpload1.Enabled = True
            Me.TxtIconImage.Enabled = True
            Me.txtSeq.Enabled = False
            Me.CheckBox1.Enabled = False
            Me.TxtDocType.Enabled = False

        Else
            Me.FileUpload1.Enabled = True
            Me.TxtIconImage.Enabled = True
            Me.txtSeq.Enabled = True
            Me.CheckBox1.Enabled = True
            Me.TxtDocType.Enabled = True
            Me.FileUpload2.Enabled = True
            Me.txtDocumentIconImage.Enabled = True
        End If

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
        Me.CheckBox1.Enabled = False
        Me.FileUpload1.Enabled = False
        Me.FileUpload2.Enabled = False
        Me.txtCreatedDate.Enabled = False
    End Sub
    Protected Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click

        If cmdEdit.Text = "Update" Then
            If Me.txtPItemCode.Text = "" Then
                txtPItemCode.Text = Nothing
            End If
            If Me.CheckBox1.Checked = True Then
                POPUP = "Yes"
            Else
                POPUP = "No"
            End If
            If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
                SQLPASS = "UPDATE jct_fap_shared_area SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                SQLPASS = "UPDATE jct_fap_My_Area_Master1 SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
                SQLPASS = "UPDATE jct_fap_tech_news SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
                SQLPASS = "UPDATE jct_fap_notice_board SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            Else
                SQLPASS = "UPDATE jct_fap_item_master1 SET Status='U',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            End If

            If Obj2.UpdateRecord(SQLPASS) = False Then

                FMsg.CssClass = "errormsg"
                FMsg.Message = "Update Transaction not Commited"
                FMsg.Display()
            Else
                If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
                    SQLPASS = "insert into jct_fap_shared_area(CompanyCode,UserCode,ItemCode,SDescription,LDescription,itemcat,ParentItem,URL,createddt,efffrom,effto,STATUS,doc_type) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.ddlItemcateg.SelectedValue & "','" & txtPItemCode.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','','" & Me.TxtDocType.Text & "')"
                ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                    SQLPASS = "insert into jct_fap_My_Area_Master1(CompanyCode,UserCode,ItemCode,SDescription,LDescription,itemcat,ParentItem,IconImageURL,PageUrl,createddt,efffrom,effto,STATUS) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.ddlItemcateg.SelectedValue & "','" & Me.txtPItemCode.Text & "','" & Me.TxtIconImage.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','')"
                ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
                    SQLPASS = "insert into jct_fap_tech_news(CompanyCode,UserCode,ItemCode,SDescription,LDescription,ParentItem,Url,createddt,efffrom,effto,STATUS) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.txtPItemCode.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','')"
                ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
                    SQLPASS = "insert into jct_fap_notice_board(CompanyCode,UserCode,ItemCode,SDescription,LDescription,ParentItem,Url,createddt,efffrom,effto,STATUS) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.txtPItemCode.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','')"
                Else
                    SQLPASS = "insert into jct_fap_item_master1(CompanyCode,UserCode,ItemCode,SDescription,LDescription,IconImage,ItemCategory,Sequence,EffFrom,EffTo,CreatedDt,Url,ParentItemCode,popup,STATUS,Document_Type) values('" & Session("Companycode") & "','" & Session("Empcode") & "','" & Me.txtItemCode.Text & "','" & Me.txtSDesc.Text & "','" & Me.txtLDesc.Text & "','" & Me.TxtIconImage.Text & "','" & Me.ddlItemcateg.SelectedItem.Text & "','" & Me.txtSeq.Text & "','" & Me.txtEffFrom.Text & "','" & Me.txtEffTo.Text & "','" & Me.txtCreatedDate.Text & "','" & Me.txtDocumentIconImage.Text & "','" & Me.txtPItemCode.Text & "','" & POPUP & "','A','" & (Me.TxtDocType.Text) & "')"
                End If

                If Obj2.InsertRecord(SQLPASS) = True Then
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Record Updated Succesfully"
                    LoadGrid_parent()
                    LoadGrid_DocType()
                    FMsg.Display()
                    Obj2.CheckEditEnableDisable(cmdEdit, cmdAdd, cmdDelete, cmdClose, cmdDelete)
                    Obj2.ButtonValidationDisable(cmdAdd, cmdEdit, cmdDelete)
                    LoadGrid()
                    TextBoxBlank()
                    TextDisableMode()
                Else
                    Obj2.ButtonValidationEnable(cmdAdd, cmdEdit, cmdDelete)
                    FMsg.CssClass = "errormsg"
                    FMsg.Message = "Update Transaction not Commited !!!"
                    FMsg.Display()
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
            If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
                SQLPASS = "UPDATE jct_fap_shared_area SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                SQLPASS = "UPDATE jct_fap_My_Area_Master1 SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
                SQLPASS = "UPDATE jct_fap_tech_news SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
                SQLPASS = "UPDATE jct_fap_notice_board SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' and status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            Else
                SQLPASS = "UPDATE jct_fap_item_master1 SET Status='D',CreatedDt=getdate() where ItemCode='" & Trim(Me.txtItemCode.Text) & "' and status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
            End If

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
        If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ITEMCAT,PARENTITEM,URL,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],[Doc Type]=Doc_type from jctdev..jct_fap_shared_area WHERE status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 and itemcat='" & Me.ddlItemcateg.SelectedValue & "' order by CREATEDDT,PARENTITEM   "
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ITEMCAT,PARENTITEM,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],IconImageUrl,PageUrl from jctdev..jct_fap_My_Area_Master1 WHERE status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 and itemcat='" & Me.ddlItemcateg.SelectedValue & "' order by CREATEDDT,PARENTITEM  "
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,PARENTITEM,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],Url from jctdev..jct_fap_tech_news WHERE status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 order by CREATEDDT,PARENTITEM "
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,PARENTITEM,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],Url from jctdev..jct_fap_notice_board WHERE status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0 order by CREATEDDT,PARENTITEM "
        Else
            SQLPASS = "SELECT    [Code]=ITEMCODE, [Short Desc]=SDESCRIPTION,[Long Desc]=LDESCRIPTION ,ICONIMAGE,ITEMCATEGORY,SEQUENCE,URL,PARENTITEMCODE,POPUP,CONVERT(VARCHAR(11),EFFFROM,101)as [Eff. From],CONVERT(VARCHAR(11),EffTo,101) as [Eff. To],convert(varchar(11),CREATEDDT,101) as [Created Date],Document_Type as [Document Type]  from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0  and itemcategory='" & Me.ddlItemcateg.SelectedValue & "' order by CREATEDDT,PARENTITEMCODE  "
        End If

        Obj2.FillGrid(SQLPASS, GrdHelp)
    End Sub
    Protected Sub LoadGrid_parent()
        If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
            SQLPASS = "select distinct[Item Code]= itemcode,[Short Desc]=SDESCRIPTION from jct_fap_shared_area where status='' and itemcat='" & Me.ddlItemcateg.SelectedValue & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
            SQLPASS = "select distinct [Item Code]=itemcode,[Short Desc]=SDESCRIPTION from jct_fap_My_Area_Master1 where status='' and itemcat='" & Me.ddlItemcateg.SelectedValue & "' AND DateDiff(DD,GETDATE(),EFFTO)>=0"
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
            SQLPASS = "SELECT  distinct [[Item Code]=ITEMCODE, [Short Desc]=SDESCRIPTION from jctdev..jct_fap_tech_news WHERE status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
            SQLPASS = "SELECT  distinct [Item Code]=ITEMCODE, [Short Desc]=SDESCRIPTION from jctdev..jct_fap_notice_board WHERE status='' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        Else
            SQLPASS = "SELECT  distinct [Item Code]=ITEMCODE, [Short Desc]=SDESCRIPTION from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        End If

        Obj2.FillGrid(SQLPASS, GridView1)
    End Sub
    Protected Sub LoadGrid_DocType()
        SQLPASS = "select 'NoticeBoard' as [Document Type]  union select 'TechnicalNewsletters' as [Document Type]  union select 'GeneralArea' as [Document Type]  union select 'MedicalTips' as [Document Type]  union SELECT distinct Document_Type as [Document Type] from jctdev..jct_fap_item_master1 WHERE status='A' AND DateDiff(DD,GETDATE(),EFFTO)>=0   "
        Obj2.FillGrid(SQLPASS, GrdDocType)
    End Sub
    Protected Sub grdHelp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdHelp.SelectedIndexChanged
        If Me.GrdHelp.Rows.Count > 0 Then

            If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Or Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
                Me.PopupExp.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())

                '----------------------------------------------
                txtItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
                txtSDesc.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
                txtLDesc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")

                ddlItemcateg.SelectedValue = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
                txtPItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")
                txtDocumentIconImage.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")

                txtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(7).Text.ToString, "&nbsp;", "")
                txtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")
                txtCreatedDate.Text = Replace(GrdHelp.SelectedRow.Cells(9).Text.ToString, "&nbsp;", "")
                TxtDocType.Text = Replace(GrdHelp.SelectedRow.Cells(10).Text.ToString, "&nbsp;", "")
                If Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "") = "" Then
                    Me.HyperLink1.NavigateUrl = ""
                Else
                    If InStr(Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", ""), "test2k") > 0 Then
                        Me.HyperLink1.NavigateUrl = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
                    Else
                        Me.HyperLink1.NavigateUrl = "~\" & Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
                    End If

                End If


            ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Or Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then

                Me.PopupExp.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())

                '----------------------------------------------
                txtItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
                txtSDesc.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
                txtLDesc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")
                txtPItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
                txtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")
                txtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
                txtCreatedDate.Text = Replace(GrdHelp.SelectedRow.Cells(7).Text.ToString, "&nbsp;", "")
                Me.txtDocumentIconImage.Text = Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")

                If Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "") = "" Then
                    Me.HyperLink1.NavigateUrl = ""
                Else
                    If InStr(Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", ""), "test2k") > 0 Then
                        Me.HyperLink1.NavigateUrl = Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")
                    Else
                        Me.HyperLink1.NavigateUrl = "~\" & Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")
                    End If

                End If
               
            ElseIf Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                Me.PopupExp.Commit(GrdHelp.SelectedRow.Cells(1).Text.ToString())

                '----------------------------------------------
                txtItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(1).Text.ToString, "&nbsp;", "")
                txtSDesc.Text = Replace(GrdHelp.SelectedRow.Cells(2).Text.ToString, "&nbsp;", "")
                txtLDesc.Text = Replace(GrdHelp.SelectedRow.Cells(3).Text.ToString, "&nbsp;", "")

                ddlItemcateg.SelectedValue = Replace(GrdHelp.SelectedRow.Cells(4).Text.ToString, "&nbsp;", "")
                txtPItemCode.Text = Replace(GrdHelp.SelectedRow.Cells(5).Text.ToString, "&nbsp;", "")

                txtEffFrom.Text = Replace(GrdHelp.SelectedRow.Cells(6).Text.ToString, "&nbsp;", "")
                txtEffTo.Text = Replace(GrdHelp.SelectedRow.Cells(7).Text.ToString, "&nbsp;", "")
                txtCreatedDate.Text = Replace(GrdHelp.SelectedRow.Cells(9).Text.ToString, "&nbsp;", "")
                Me.TxtIconImage.Text = Replace(GrdHelp.SelectedRow.Cells(8).Text.ToString, "&nbsp;", "")
                Me.txtDocumentIconImage.Text = Replace(GrdHelp.SelectedRow.Cells(10).Text.ToString, "&nbsp;", "")
                Me.Image2.ImageUrl = "\FusionApps\" + Trim(Me.TxtIconImage.Text)

            Else

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
                txtCreatedDate.Text = Replace(GrdHelp.SelectedRow.Cells(12).Text.ToString, "&nbsp;", "")
                TxtDocType.Text = Replace(GrdHelp.SelectedRow.Cells(13).Text.ToString, "&nbsp;", "")

            End If
        End If
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
        Me.GrdHelp.SelectedIndex = 0
        Me.Grdhelp_SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub CmdNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdNext.Click
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.SelectedIndex + 1
        If Me.GrdHelp.SelectedIndex = Me.GrdHelp.Rows.Count() Then
            Me.GrdHelp.SelectedIndex = 0
        End If
        Me.Grdhelp_SelectedIndexChanged(sender, e)
    End Sub

    Protected Sub CmdPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrevious.Click
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.SelectedIndex - 1
        If Me.GrdHelp.SelectedIndex < 0 Then
            Me.GrdHelp.SelectedIndex = Me.GrdHelp.Rows.Count() - 1
        End If
        Me.Grdhelp_SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub CmdLast_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdLast.Click
        Me.GrdHelp.SelectedIndex = Me.GrdHelp.Rows.Count() - 1
        Me.Grdhelp_SelectedIndexChanged(sender, e)
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
            If Me.ddlItemcateg.SelectedItem.Text = "My Area" Then
                FileUpload1.PostedFile.SaveAs("D:\WebApplications\FusionApps\Image\Buttons_Tabs\" + FileUpload1.FileName)
                Me.TxtIconImage.Text = "Image\Buttons_Tabs\" + FileUpload1.FileName
            Else
                FileUpload1.PostedFile.SaveAs("D:\WebApplications\FusionApps\Image\" + FileUpload1.FileName)
                Me.TxtIconImage.Text = "Image\" + FileUpload1.FileName
            End If

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
            Dim storepath As String = "D:\WebApplications\FusionApps\Docs\" & Trim(Me.TxtDocType.Text)
            If Not Directory.Exists(storepath) Then
                Directory.CreateDirectory(storepath)
            End If
            FileUpload2.PostedFile.SaveAs("D:\WebApplications\FusionApps\Docs\" & Trim(Me.TxtDocType.Text) & "\" & FileUpload2.FileName)
            Me.txtDocumentIconImage.Text = "Docs\" & Trim(Me.TxtDocType.Text) & "\" & FileUpload2.FileName
            FMsg.CssClass = "addmsg"
            FMsg.Message = "Image Uploaded"
            FMsg.Display()
            Me.HyperLink1.NavigateUrl = "~\" & Me.txtDocumentIconImage.Text

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
    Protected Sub ddlItemcateg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemcateg.SelectedIndexChanged
        LoadGrid_parent()
        LoadGrid_DocType()
        If Me.cmdAdd.Text = "Save" Or Me.cmdEdit.Text = "Update" Then
            TextEnableMode()
        End If
        LoadGrid()
        TextBoxBlank()
        If Me.ddlItemcateg.SelectedItem.Text = "Medical Tips" Then
            Me.txtdoctype.text = "MedicalTips"
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "General Tips" Then
            Me.TxtDocType.Text = "GeneralArea"
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "Technical News Letter" Then
            Me.TxtDocType.Text = "TechnicalNewsLetters"
        ElseIf Me.ddlItemcateg.SelectedItem.Text = "Notice Board" Then
            Me.TxtDocType.Text = "NoticeBoard"
        Else
            Me.TxtDocType.Text = ""
        End If
        Me.txtItemCode.Focus()
    End Sub
End Class
