Imports System
Imports System.Data.SqlClient
Imports System.Data
Partial Class OPS_SampleRequest
    Inherits System.Web.UI.Page
    Dim objFun As Functions = New Functions
    Dim obj As Connection = New Connection
    Dim qry As String
    Dim dr As SqlDataReader
    Dim cmd As SqlCommand = New SqlCommand
    Dim con As SqlConnection = New SqlConnection
    Dim dt As DataTable = New DataTable

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            qry = "SELECT  '' as group_desc, '' as group_no Union Select rtrim(group_no),rtrim(group_desc) FROM miserp.som.dbo.m_cust_group(Nolock) WHERE group_TYPE='SALESP' AND status ='o'"
            objFun.FillList(ddlSalesPerson, qry)

            dt.Columns.Add("SrNo")
            dt.Columns.Add("Sort")
            dt.Columns.Add("Shade")
            Dt.Columns.Add("Qty")
            dt.Columns.Add("ApproxValue")
            ViewState.Add("data", dt)


            dt = CType(ViewState("data"), DataTable)
            Dim drow = dt.NewRow()

            Dim dtr As DataTableReader = New DataTableReader(dt)
            dtr.Read()
            dt.Rows.Add(drow)
            'ViewState.Add("data", dt)

            grdItems.DataSource = dt
            grdItems.DataBind()


        End If
    End Sub

    Protected Sub txtCustomer_TextChanged(sender As Object, e As System.EventArgs) Handles txtCustomer.TextChanged
        Dim CustCode As String = ""
        If Len(txtCustomer.Text) > 0 Then
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
            qry = "SELECT address_id FROM miserp.som.dbo.m_cust_address WHERE cust_no='" & CustCode & "'"
            objFun.FillList(ddlAddress, qry)
            ddlAddress_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Protected Sub ddlAddress_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlAddress.SelectedIndexChanged
        Dim CustCode As String = ""
        If Len(txtCustomer.Text) > 0 Then
            CustCode = Right(txtCustomer.Text, Len(txtCustomer.Text) - InStr(txtCustomer.Text, "~")) 'txtCustomer.Text
            qry = "SELECT  address_1 AS AddressLine1,address_2  AS AddressLine2 ,address_3  AS AddressLine3 ,city AS City,state AS State ,country AS Country ,zip_no AS ZipNo ,phone_no AS PhoneNo ,telex_no AS TelexNo ,fax_no AS FaxNo FROM miserp.som.dbo.m_cust_address WHERE cust_no='" & CustCode & "' and address_id=" & ddlAddress.SelectedItem.Value
            objFun.FillGrid(qry, grdAddressDetail)
        End If
    End Sub
    Protected Sub imgAddRow_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs)
        Dim Scrpt As String

        Try
            'ViewState("Old") = ViewState("data")
            Dim ImgAdd As ImageButton = CType(sender, ImageButton)
            Dt = CType(ViewState("data"), DataTable)
            Dim drow = Dt.NewRow()

            Dim dtr As DataTableReader = New DataTableReader(Dt)
            dtr.Read()
            drow("SrNo") = dtr("SrNo")
            drow("Sort") = dtr("Sort")
            drow("Shade") = dtr("Shade")
            drow("Shade") = dtr("Qty")
            drow("ApproxValue") = dtr("ApproxValue")
            dt.Rows.Add(drow)
            'ViewState.Add("data", ViewState("Old"))
            ViewState.Add("data", Dt)

            grdItems.DataSource = dt
            grdItems.DataBind()

        Catch ex As Exception

            Scrpt = "alert('No Row available.')"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "ServerControlScript", Scrpt, True)
        End Try
    End Sub

    
    Protected Sub grdItems_RowDeleting(sender As Object, e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles grdItems.RowDeleting
        Dim row As Int16 = e.RowIndex
        Dim dt As DataTable = CType(ViewState("data"), DataTable)
        dt.Rows.RemoveAt(row)
        grdItems.DataSource = dt
        grdItems.DataBind()
        ViewState("data") = dt

    End Sub
End Class
