Imports System.Data
Imports System.Data.SqlClient
Imports System
Imports System.Configuration
Imports System.Collections
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Threading
Partial Class SalesAnalysisSystem_OrdersPanel
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Qry As String

    Protected Sub CmdFetch_Click(sender As Object, e As System.EventArgs) Handles CmdFetch.Click
        Qry = "SELECT SECTION_Name,ProcedureUsed,CASE WHEN a.id=b.ID THEN b.User_Seq ELSE a.Default_Seq END AS Seq,CASE WHEN a.id = b.ID THEN b.No_of_Records ELSE 10 END AS No_Of_Records FROM  Jct_Ops_OrderPanel_Sections a LEFT OUTER JOIN Jct_OPS_OrdersPanel_Config b ON a.ID = b.ID and b.userCode='" & Session("Empcode") & "' and a.status=b.status   WHERE  a.status='A' and a.ID<>5 order by Seq"
        DataList1.DataSource = ObjFun.FetchDS(Qry)
        DataList1.DataBind()
    End Sub

    Protected Sub DataList1_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.DataListItemEventArgs) Handles DataList1.ItemDataBound
        ' CType(e.Item.FindControl("CollapsiblePanelExtender1"), AjaxControlToolkit.CollapsiblePanelExtender).ClientState = False
        Dim OrdNo As String, CustCode As String, SaleTeam As String, SalePerson As String
        Dim HiddenField2 As HiddenField = New HiddenField
        HiddenField2.Value = 0
        HiddenField2 = CType(e.Item.FindControl("HiddenField2"), HiddenField)
        OrdNo = "0"
        CustCode = ""
        SaleTeam = ""
        SalePerson = ""

        If txtOrderNo.Text = "" Then
            OrdNo = "-All-"
        Else
            OrdNo = txtOrderNo.Text
        End If

        If txtCustomer.Text = "" Then
            CustCode = "-All-"
        Else
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
        End If

        If ddlSalesPerson.SelectedItem.Text = "" Then
            SalePerson = "-All-"
        Else
            SalePerson = Trim(ddlSalesPerson.SelectedItem.Value)
        End If


        If ddlSalesTeam.SelectedItem.Text = "" Then
            SaleTeam = "-All-"
        Else
            SaleTeam = Trim(ddlSalesTeam.SelectedItem.Value)
        End If

        Qry = "exec " & CType(e.Item.FindControl("HiddenField1"), HiddenField).Value & " '" & OrdNo & "','" & CustCode & "','" & SalePerson & "','" & HiddenField2.Value & "','" & Session("Empcode") & "','" & SaleTeam & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "'"
        Dim Grd As GridView = New GridView
        Grd = CType(e.Item.FindControl("GrdDetail"), GridView)
        ObjFun.FillGrid(Qry, Grd)

        Dim Cmd As LinkButton = New LinkButton
        Dim Proc As String
        Dim Hdr As String
        Proc = ""
        Hdr = ""
        Proc = CType(e.Item.FindControl("HiddenField1"), HiddenField).Value
        Cmd = CType(e.Item.FindControl("CmdViewMore"), LinkButton)
        Hdr = CType(e.Item.FindControl("LblHeader"), Label).Text

        Cmd.PostBackUrl = "ViewDetail.aspx?Proc=" & Proc & "&Hdr=" & Hdr & "&OrdNo=" & OrdNo & "&Custcode=" & CustCode & "&SalePerson=" & SalePerson & "&SaleTeam=" & SaleTeam
    End Sub

    'Protected Sub btnPageLoad_Click(sender As Object, e As System.EventArgs) Handles btnPageLoad.Click
    '    div1.Visible = False
    '    hdnLoaded.Value = "true" '//Setting a hidden variable will help avoiding a loop of postback triggered from client side script.
    '    divLoading.Visible = False '// Make the loading message invisible

    '    '  lblMessage.Visible = True
    'End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Qry = " Select '' as [team_code],'' as [team_description] Union  SELECT rtrim(team_code),rtrim(team_description) FROM MISERP.SOM.DBO.jct_team_mASter  ORDER BY team_code   "
            ObjFun.FillList(ddlSalesTeam, Qry)
            If ddlSalesTeam.SelectedItem.Text = "" Then

                Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
                ObjFun.FillList(ddlSalesPerson, Qry)

            Else

                ddlSalesPerson.Items.Clear()
                Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT rtrim(a.sale_person_code),rtrim(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
                ObjFun.FillList(ddlSalesPerson, Qry)
            End If
            txtEff_From.Text = DateAdd(DateInterval.Day, -(Now.Date.Day - 1), Now.Date) 'Now.Date.Day
            txtEff_To.Text = Now.Date
            CmdFetch_Click(sender, e)
        End If
    End Sub

    Protected Sub DataList1_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DataList1.SelectedIndexChanged

    End Sub

  
    Protected Sub ddlSalesTeam_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlSalesTeam.SelectedIndexChanged
        If ddlSalesTeam.SelectedItem.Text = "" Then

            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as group_no, '' as group_desc Union SELECT RTRIM(group_no),RTRIM(group_desc) FROM miserp.som.dbo.m_cust_group WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        Else
            ddlSalesPerson.Items.Clear()
            Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT RTRIM(a.sale_person_code),RTRIM(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a  INNER JOIN MISERP.SOM.dbo.m_cust_group b ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
            ObjFun.FillList(ddlSalesPerson, Qry)
        End If
    End Sub
End Class
