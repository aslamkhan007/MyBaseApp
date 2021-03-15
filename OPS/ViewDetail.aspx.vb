Imports System.Data
Imports System.Data.SqlClient
Partial Class OPS_ViewDetail
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    'Dim ObjXl As GridViewExportUtil = New GridViewExportUtil
    Dim Qry As String

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Label1.Text = Request.QueryString("Hdr").ToString & "---Detail"
        'Qry = "Exec " & Request.QueryString("proc").ToString & "'<<All>>','<<All>>','a00131',0,'" & Session("Empcode") & "'"

        'this.DropDownListTitle.SelectedIndex =
        '                DropDownListTitle.Items.IndexOf(DropDownListTitle.Items.FindByText(objContactItem.Title));
       

        Qry = "Exec " & Request.QueryString("proc").ToString & "  '" & Request.QueryString("OrdNo").ToString & "','" & Request.QueryString("CustCode").ToString & "','" & Request.QueryString("SalePerson").ToString & "',0,'" & Session("Empcode") & "', '" & Request.QueryString("SaleTeam").ToString & "'"

        ObjFun.FillGrid(Qry, GrdDetail)
        If Not IsPostBack Then

            Qry = " Select '' as [team_code],'' as [team_description] Union  SELECT rtrim(team_code),rtrim(team_description) FROM MISERP.SOM.DBO.jct_team_mASter(nolock)  ORDER BY team_code   "
            ObjFun.FillList(ddlSalesTeam, Qry)
            If ddlSalesTeam.SelectedItem.Text = "" Then

                Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(nolock) WHERE group_TYPE='SALESP' AND status ='o'"
                ObjFun.FillList(ddlSalesPerson, Qry)

            Else

                ddlSalesPerson.Items.Clear()
                Qry = "Select '' as [sale_person_code] ,'' as [group_desc] union SELECT DISTINCT RTRIM(a.sale_person_code),RTRIM(b.group_desc) FROM MISERP.SOM.DBO.jct_team_saleperson_mapping a(nolock)  INNER JOIN MISERP.SOM.dbo.miserp.som.dbo.m_cust_group b(nolock) ON b.group_no = a.sale_person_code WHERE  a.status='O' and group_type='SalesP' and    team_code = '" + ddlSalesTeam.SelectedItem.Text + "'"
                ObjFun.FillList(ddlSalesPerson, Qry)
            End If

            Dim OrdNo As String, CustCode As String, SaleTeam As String, SalePerson As String
            'Dim HiddenField2 As HiddenField = New HiddenField
            'HiddenField2.Value = 0
            'HiddenField2 = CType(e.Item.FindControl("HiddenField2"), HiddenField)
            OrdNo = Request.QueryString("OrdNo").ToString
            CustCode = Request.QueryString("CustCode").ToString
            SaleTeam = Request.QueryString("SaleTeam").ToString
            SalePerson = Request.QueryString("SalePerson").ToString

            If OrdNo = "-All-" Then
                txtOrderNo.Text = ""
            Else
                txtOrderNo.Text = OrdNo
            End If

            If CustCode = "-All-" Then
                txtCustomer.Text = ""
            Else
                CustCode = Right(CustCode, Len(CustCode) - InStr(CustCode, "~"))
                txtCustomer.Text = CustCode
            End If




            If SaleTeam = "-All-" Then
                ddlSalesTeam.SelectedItem.Text = ""
            Else
                ddlSalesTeam.SelectedIndex = ddlSalesTeam.Items.IndexOf(ddlSalesTeam.Items.FindByText(SaleTeam))
                ddlSalesTeam_SelectedIndexChanged(sender, e)
                ' ddlSalesTeam.SelectedItem.Value = SaleTeam
            End If
            If SalePerson = "-All-" Then
                ddlSalesPerson.SelectedItem.Text = ""
            Else
                ddlSalesPerson.SelectedIndex = ddlSalesPerson.Items.IndexOf(ddlSalesPerson.Items.FindByValue(SalePerson))
                'ddlSalesPerson.SelectedItem.Value = SalePerson
            End If

        End If
       
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

    Protected Sub GrdDetail_PageIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdDetail.PageIndexChanging
        ' e.NewPageIndex=
        GrdDetail.PageIndex = e.NewPageIndex
        Qry = "Exec " & Request.QueryString("proc").ToString & "  '" & Request.QueryString("OrdNo").ToString & "','" & Request.QueryString("CustCode").ToString & "','" & Request.QueryString("SalePerson").ToString & "',0,'" & Session("Empcode") & "', '" & Request.QueryString("SaleTeam").ToString & "'"
        ObjFun.FillGrid(Qry, GrdDetail)
    End Sub

    Protected Sub CmdXl_Click(sender As Object, e As System.EventArgs) Handles CmdXl.Click
        GridViewExportUtil.Export(Label1.Text & ".xls", GrdDetail)
    End Sub

    Protected Sub lnkFetch_Click(sender As Object, e As System.EventArgs) Handles lnkFetch.Click
        Dim OrdNo As String, CustCode As String, SaleTeam As String, SalePerson As String
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

        Qry = "Exec " & Request.QueryString("proc").ToString & "   '" & OrdNo & "','" & CustCode & "','" & SalePerson & "',0,'" & Session("Empcode") & "','" & SaleTeam & "'"
        ''" & Request.QueryString("OrdNo").ToString & "','" & Request.QueryString("CustCode").ToString & "','" & Request.QueryString("SalePerson").ToString & "',0,'" & Session("Empcode") & "', '" & Request.QueryString("SaleTeam").ToString & "'"

        ObjFun.FillGrid(Qry, GrdDetail)
    End Sub
End Class
