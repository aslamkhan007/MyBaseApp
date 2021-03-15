Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel
<DataObjectAttribute()> _
Public Class ChemicalCost
    Dim obj As Connection = New Connection
    Dim obj1 As Functions = New Functions
    Private _ChemicalName As String
    Public Property Description() As String
        Get
            Return _ChemicalName
        End Get
        Set(ByVal value As String)
            _ChemicalName = value
        End Set
    End Property
    Private _ChemicalCode As String
    Public Property stock_no() As String
        Get
            Return _ChemicalCode

        End Get
        Set(ByVal value As String)
            _ChemicalCode = value
        End Set
    End Property

    Private _Variant1 As String
    Public Property variant_no() As String
        Get
            Return _Variant1
        End Get
        Set(ByVal value As String)
            _Variant1 = value
        End Set
    End Property
    Private _EffectiveFrom As String
    Public Property eff_from() As String
        Get
            Return _EffectiveFrom

        End Get
        Set(ByVal value As String)
            _EffectiveFrom = value
        End Set
    End Property
    Private _EffectiveTo As String
    Public Property eff_to() As String
        Get
            Return _EffectiveTo

        End Get
        Set(ByVal value As String)
            _EffectiveTo = value
        End Set
    End Property

    Private _Cost As Decimal
    Public Property std_rate_kg() As Decimal
        Get
            Return _Cost

        End Get
        Set(ByVal value As Decimal)
            _Cost = value
        End Set
    End Property
    Private _RevNo As Integer
    Public Property rev_no() As Integer
        Get
            Return _RevNo
        End Get
        Set(ByVal value As Integer)
            _RevNo = value
        End Set
    End Property
    Private _Remarks As String
    Public Property remark() As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetChemCost(ByVal Description As String) As DataSet
        Dim sql As String
        'sql = "select DevNo, ProcessCode as Process, RTrim(ItemCode) 'ItemCode', Variant as ItemVariant, Description, " & _
        '      "Rate, Quantity, UOM, Value from JCT_Sample_Process_Recipe where status = 'A' and devno = '" & devno & _
        '    "' and processcode = '" & process & "' and Recipe_Type ='" & Recipe_type & "' order by itemcode, itemvariant"

        ' sql = "exec production..Prod_Chem_Std_Cost_Select '" & stock_no & "','" & variant_no & "'"
        sql = "exec production..Prod_Chem_Std_Cost_Select '" & Description & "'"
        Dim ds As DataSet = obj1.FetchDS(sql)

        Return ds

    End Function
    Public Sub UpdateCost(ByVal ChemCost As ChemicalCost)
        Dim sm As SendMail = New SendMail
        Dim sql As String
        Dim tran As SqlTransaction
        tran = obj.Connection.BeginTransaction
        Try
            sql = "Select * from production..jct_process_std_cost_chem where stock_no='" & ChemCost.stock_no & "' and variant_no='" & ChemCost.variant_no & "' and eff_from  in (select Convert(datetime,convert(varchar(15),getdate(),103),103) )"
            If obj1.CheckRecordExistInTransaction(sql, tran, tran.Connection) = False Then
                sql = "update production..jct_process_std_cost_chem set eff_to=getdate() where stock_no = '" & ChemCost.stock_no & _
                                                "' and variant_no = '" & ChemCost.variant_no & "' and eff_to=Convert(datetime,'" & ChemCost.eff_to & "',103) and eff_from=Convert(datetime,'" & ChemCost.eff_from & "',103) "

                Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
                cmd.Transaction = tran
                cmd.ExecuteNonQuery()


                sql = "insert production..jct_process_std_cost_chem (created_dt, stock_no, variant_no, eff_from, " & _
                                              "eff_to,remark,rev_no,std_rate_kg)" & _
                                              "values(Convert(datetime,convert(varchar(15),getdate(),103),103),'" & ChemCost.stock_no & "','" & ChemCost.variant_no & "',Convert(datetime,convert(varchar(15),getdate(),103),103),Convert(datetime,convert(varchar(15),'" & ChemCost.eff_to & "',103),103),'" & ChemCost.remark & "'," & ChemCost.rev_no & "," & ChemCost.std_rate_kg & ")"
                cmd = New SqlCommand(sql, obj.Connection)
                cmd.Transaction = tran
                cmd.ExecuteNonQuery()
            Else
                sql = "update production..jct_process_std_cost_chem set std_rate_kg=" & ChemCost.std_rate_kg & ",eff_to=( select Convert(datetime,Convert(varchar(15),'" & ChemCost.eff_to & "',103),103) ),remark='" & ChemCost.remark & "' where stock_no = '" & ChemCost.stock_no & _
                                                               "' and variant_no = '" & ChemCost.variant_no & "' and  eff_from in ( select Convert(datetime,Convert(varchar(15),'" & ChemCost.eff_from & "',103),103) ) "

                Dim cmd As SqlCommand = New SqlCommand(sql, obj.Connection)
                cmd.Transaction = tran
                cmd.ExecuteNonQuery()
            End If
            tran.Commit()
            sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Cost Updation", "Cost of " & ChemCost.Description & " with stock no. - " & ChemCost.stock_no & " and variant - " & ChemCost.variant_no & " has been updated to " & ChemCost.std_rate_kg & "")
        Catch ex As Exception
            tran.Rollback()
            sm.SendMail("jatindutta@jctltd.com", "dummy@jctltd.com", "Cost Updation- Error", "Error occured  while updating Cost of " & ChemCost.Description & " with stock no. - " & ChemCost.stock_no & " and variant - " & ChemCost.variant_no & " and updated cost as : " & ChemCost.std_rate_kg & "")
            Throw ex
        End Try


    End Sub
End Class
