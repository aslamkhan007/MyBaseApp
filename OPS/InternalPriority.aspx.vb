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
Partial Class OPS_InternalPriority
    Inherits System.Web.UI.Page
    Dim ObjFun As Functions = New Functions
    Dim Obj As Connection = New Connection
    Dim Qry As String
    Dim Dr As SqlDataReader
    Dim Cmd As SqlCommand = New SqlCommand
    Dim Con As SqlConnection = New SqlConnection

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            ObjFun.FillList(ddlSalesPerson, Qry)
            'Qry = "SELECT DISTINCT yearmonth,yearmonth FROM JCT_OPS_MONTHLY_PLANNING ORDER BY yearmonth desc"
            'ObjFun.FillList(ddlOrderScheduling, Qry)
            Qry = "Select '' as Location,'' union  SELECT DISTINCT LOCATION,Location FROM JCT_OPS_MONTHLY_PLANNING order by  location"
            ObjFun.FillList(ddlPlant, Qry)
        End If
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As System.EventArgs) Handles LinkButton1.Click
        Dim CustCode As String, SalePerson As String, PlantType As String
        If txtCustomer.Text = "" Then
            CustCode = ""
        Else
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
        End If
        If ddlSalesPerson.SelectedItem.Text = "" Then
            SalePerson = ""
        Else
            SalePerson = Trim(ddlSalesPerson.SelectedItem.Value)
        End If
        If ddlPlant.SelectedItem.Text = "" Then
            PlantType = ""
        Else
            PlantType = Trim(ddlPlant.SelectedItem.Value)
        End If
        Qry = "Exec Jct_Ops_Internal_Priority '','','" & CustCode & "','" & SalePerson & "','','" & PlantType & "','" & txtEff_From.Text & "','" & txtEff_To.Text & "','" & Request.ServerVariables("REMOTE_ADDR") & "','" & ddlOrderBy.SelectedItem.Text & "' "
        ' Qry = "Select * from Tbl112"
        ObjFun.FillGrid(Qry, GridView2)
    End Sub
End Class
