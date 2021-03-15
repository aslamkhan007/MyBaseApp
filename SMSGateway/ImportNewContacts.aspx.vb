Imports System.Data
Imports System.Data.SqlClient

Partial Class SMSGateway_ImportNewContacts
    Inherits System.Web.UI.Page
    Dim obj As New Functions
    Dim con As New Connection

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim arr As ArrayList = New ArrayList()
        For i As Integer = 65 To 65 + 25
            Dim a As Alpha = New Alpha
            a.Data = Chr(i)
            arr.Add(a)
        Next
        DataList1.DataSource = arr
        DataList1.DataBind()


        If grdContacts.Rows.Count > 0 Then

            For Each row As GridViewRow In grdContacts.Rows
                If row.RowType = DataControlRowType.DataRow AndAlso CType(row.FindControl("chkSelect"), CheckBox).Checked Then
                    row.CssClass = "GridRowGreen"
                ElseIf row.RowType = DataControlRowType.DataRow AndAlso Not CType(row.FindControl("chkSelect"), CheckBox).Checked Then
                    row.CssClass = "GridItem"
                End If
            Next
        End If

        If Not IsPostBack Then
            DropDownList1_SelectedIndexChanged(sender, Nothing)

        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlContactType.SelectedIndexChanged
        FillData("")
        'SqlSupplier.SelectCommand = "select top " + txtCount.Text + " Rtrim(vendor_code) as vendor_code, vendor_name, vendor_add1, vendor_add2, vendor_add3, City, State, Country, Phone_No, '' as Email, '' as DOB, '' as DOA from common..pur_company_vendor_master where vendor_code not in (select contactid from misdev.jctdev.dbo.jct_sms_contactmaster where status = 'A') order by vendor_name"

        ''SqlCustomer.SelectCommand = "select top " + txtCount.Text + " Cust_No, Address_1, Address_2, Address_3, City, State, Country, Zip_No, Phone_No from m_cust_address order by created_dt desc"
        'SqlCustomer.SelectCommand = "select top " + txtCount.Text + " a.Cust_No, b.Cust_Name, a.Address_1, a.Address_2, a.Address_3, a.City, a.State, a.Country, a.Phone_No,  '' as Email, '' as DOB, '' as DOA " & _
        '                            "from m_cust_address a INNER JOIN m_customer b ON a.cust_no = b.cust_no and a.Cust_No not in (select contactid from misdev.jctdev.dbo.jct_sms_contactmaster where status = 'A') order by b.Cust_Name"

        'SqlEmployee.SelectCommand = "Select top " + txtCount.Text + " CardNo, FullName, '' as Address_1, '' as Address_2, '' as Address_3, '' as City, '' as State, '' as Country, '' as Phone_No,  '' as Email,  Convert(varchar(12),DOB,106), Convert(varchar(12),Date_Of_Aniv,106) from jct_epor_master_employee where status <> 'D' and getdate() between eff_from and eff_to and cardno not in (select contactid from jct_sms_contactmaster where status = 'A') order by FullName"

        'GridView1.DataSourceID = ddlContactType.SelectedValue
        'GridView1.DataBind()

    End Sub

    Private Sub FillData(ByVal prefix As String)
        SqlSupplier.SelectCommand = "select top " + txtCount.Text + " Rtrim(vendor_code) as ContactID, vendor_name as ContactName, vendor_add1 as Address1, vendor_add2 as Address2, vendor_add3 as Address3, City, State, Country, Rtrim(Phone_No) as Phone_No, '' as Email, '' as DOB, '' as DOA " & _
                                    "from common..pur_company_vendor_master where vendor_code not in (select contactid from misdev.jctdev.dbo.jct_sms_contactmaster where status = 'A') and vendor_name like '" & prefix & "%' order by vendor_name"

        'SqlCustomer.SelectCommand = "select top " + txtCount.Text + " Cust_No, Address_1, Address_2, Address_3, City, State, Country, Zip_No, Phone_No from m_cust_address order by created_dt desc"
        SqlCustomer.SelectCommand = "select top " + txtCount.Text + " a.Cust_No as ContactID, b.Cust_Name as ContactName, a.Address_1 as Address1, a.Address_2 as Address2, a.Address_3 as Address3, a.City, a.State, a.Country, Rtrim(a.Phone_No) as Phone_No,  '' as Email, '' as DOB, '' as DOA " & _
                                    "from m_cust_address a INNER JOIN m_customer b ON a.cust_no = b.cust_no and a.Cust_No not in (select contactid from misdev.jctdev.dbo.jct_sms_contactmaster where status = 'A') where b.Cust_Name like '" & prefix & "%' order by b.Cust_Name"

        SqlEmployee.SelectCommand = "Select top " + txtCount.Text + " CardNo as ContactID, FullName as ContactName, '' as Address1, '' as Address2, '' as Address3, '' as City, '' as State, '' as Country, '' as Phone_No,  '' as Email,  Convert(varchar(12),DOB,106) as DOB, Convert(varchar(12),Date_Of_Aniv,106) as DOA from jct_epor_master_employee where status <> 'D' and getdate() between eff_from and eff_to and cardno not in (select contactid from jct_sms_contactmaster where status = 'A') and fullname like '" & prefix & "%' order by ContactName"

        grdContacts.DataSourceID = ddlContactType.SelectedValue
        grdContacts.DataBind()

    End Sub

    Protected Sub txtCount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCount.TextChanged
        'GridView1.DataSourceID = ddlContactType.SelectedValue
        'GridView1.DataBind()
        DropDownList1_SelectedIndexChanged(sender, Nothing)

    End Sub

    Protected Sub cmdImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImport.Click
        Dim sql As String = ""
        Dim phone, email As String
        con.ConOpen()
        Dim tran As SqlTransaction = con.Connection.BeginTransaction

        Try
            Dim dob, doa As String

            For Each row As GridViewRow In grdContacts.Rows
                'phone = IIf(CType(row.FindControl("txtPhoneNo"), TextBox).Text = "", "Null", CType(row.FindControl("txtPhoneNo"), TextBox).Text)
                'email = IIf(CType(row.FindControl("txtEmail"), TextBox).Text = "", "Null", CType(row.FindControl("txtEmail"), TextBox).Text)

                phone = CType(row.FindControl("txtPhoneNo"), TextBox).Text
                email = CType(row.FindControl("txtEmail"), TextBox).Text

                Dim chk As CheckBox = CType(row.FindControl("chkSelect"), CheckBox)
                Dim bool As Boolean = chk.Checked

                If IsDate(row.Cells(11).Text) Then
                    dob = "'" & row.Cells(11).Text & "'"
                Else
                    dob = "Null"
                End If

                If IsDate(row.Cells(12).Text) Then
                    doa = "'" & row.Cells(12).Text & "'"
                Else
                    doa = "Null"
                End If

                If bool = True Then
                    sql = "insert into jct_sms_contactmaster (ContactID, ContactName, ContactType, AddressLine1, AddressLine2, AddressLine3, City, State, Country, MobileNo, EmailAddress, DateofBirth, DateOfAniv, Status) " & _
                    "values(" & Nullify(row.Cells(1).Text) & ", " & Nullify(row.Cells(2).Text) & ", '" & ddlContactType.SelectedItem.Text & "', " & Nullify(row.Cells(3).Text) & ", " & Nullify(row.Cells(4).Text) & ", " & Nullify(row.Cells(5).Text) & ", " & Nullify(row.Cells(6).Text) & ", " & Nullify(row.Cells(7).Text) & ", " & Nullify(row.Cells(8).Text) & ", " & Nullify(phone) & ", " & Nullify(email) & ", " & dob & ", " & doa & ",'A')"
                    Dim cmd As New SqlCommand(sql, con.Connection)
                    cmd.Transaction = tran
                    cmd.ExecuteNonQuery()

                    'obj.InsertRecord(sql)
                End If
            Next
            tran.Commit()
            DropDownList1_SelectedIndexChanged(sender, Nothing)

        Catch ex As Exception
            tran.Rollback()
            obj.Alert(ex.Message)

        Finally
            con.ConClose()

        End Try

    End Sub

    Private Function Nullify(ByVal val As String) As String
        Dim null_str As String = "Null"
        If val = "&nbsp;" Or val = "" Then
            Return null_str
        Else
            Return "'" + val + "'"
        End If

    End Function

    Protected Sub DataList1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) Handles DataList1.ItemCommand
        Dim arg As String = e.CommandArgument.ToString()
        FillData(arg)

    End Sub

    Protected Sub grdContacts_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdContacts.RowDataBound

        If e.Row.RowType = DataControlRowType.DataRow Then

            'Dim pnt As TextBox = CType(e.Row.FindControl("txtPhoneNo"), TextBox)
            Dim pnl As Label = CType(e.Row.FindControl("lblPhoneNo"), Label)
            'Dim emt As TextBox = CType(e.Row.FindControl("txtEmail"), TextBox)
            Dim eml As Label = CType(e.Row.FindControl("lblEmail"), Label)

            pnl.Visible = False
            eml.Visible = False

            'If pnl.Text = "" Or pnl.Text = "&nbsp;" Then
            '    pnt.Visible = True
            '    pnl.Visible = False
            'Else
            '    pnt.Visible = False
            '    pnl.Visible = True
            'End If

            'If eml.Text = "" Or eml.Text = "&nbsp;" Then
            '    emt.Visible = True
            '    eml.Visible = False
            'Else
            '    emt.Visible = False
            '    eml.Visible = True
            'End If

        End If

    End Sub

End Class

Public Class Alpha

    Private _data As String

    Public Property Data() As String
        Get
            Return _data
        End Get
        Set(ByVal value As String)
            _data = value
        End Set
    End Property

End Class