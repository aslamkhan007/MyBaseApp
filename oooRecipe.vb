Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.ComponentModel

<DataObjectAttribute()> _
Public Class RecipeDyeChem

    Dim ob As New Functions
    Dim cn As New Connection
    Private _ItemCode As String
    Public Property ItemCode() As String
        Get
            Return _ItemCode
        End Get
        Set(ByVal value As String)
            _ItemCode = value
        End Set
    End Property

    Private _Variant As String
    Public Property ItemVariant() As Integer
        Get
            Return _Variant
        End Get
        Set(ByVal value As Integer)
            _Variant = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _Rate As String
    Public Property Rate() As Double
        Get
            Return _Rate
        End Get
        Set(ByVal value As Double)
            _Rate = value
        End Set
    End Property

    Private _UOM As String
    Public Property UOM() As String
        Get
            Return _UOM
        End Get
        Set(ByVal value As String)
            _UOM = value
        End Set
    End Property

    Private _Qty As String
    Public Property Quantity() As Double
        Get
            Return _Qty
        End Get
        Set(ByVal value As Double)
            _Qty = value
        End Set
    End Property

    Private _Value As String
    Public Property Value() As Double
        Get
            Return _Value
        End Get
        Set(ByVal value As Double)
            _Value = value
        End Set
    End Property

    Private _DevNo As String
    Public Property DevNo() As String
        Get
            Return _DevNo
        End Get
        Set(ByVal value As String)
            _DevNo = value
        End Set
    End Property

    Private _Process As String
    Public Property Process() As String
        Get
            Return _Process
        End Get
        Set(ByVal value As String)
            _Process = value
        End Set
    End Property

    Private _CreatedDate As String
    Public Property CreatedDate() As String
        Get
            Return _CreatedDate
        End Get
        Set(ByVal value As String)
            _CreatedDate = value
        End Set
    End Property

    Private _CompCode As String
    Public Property CompCode() As String
        Get
            Return _CompCode
        End Get
        Set(ByVal value As String)
            _CompCode = value
        End Set
    End Property

    Private _UserCode As String
    Public Property UserCode() As String
        Get
            Return _UserCode
        End Get
        Set(ByVal value As String)
            _UserCode = value
        End Set
    End Property

    Private newPropertyValue As String
    Public Property NewProperty() As String
        Get
            Return newPropertyValue
        End Get
        Set(ByVal value As String)
            newPropertyValue = value
        End Set
    End Property

    Private _Recipe_type As String
    Public Property Recipe_type() As String
        Get
            Return _Recipe_type
        End Get
        Set(ByVal value As String)
            _Recipe_type = value
        End Set
    End Property

    <DataObjectMethodAttribute(DataObjectMethodType.Select, True)> _
    Public Function GetRecipe(ByVal devno As String, ByVal process As String, ByVal Recipe_type As String) As DataSet

        Dim sql As String
        sql = "select DevNo, ProcessCode as Process, RTrim(ItemCode) 'ItemCode', Variant as ItemVariant, Description, " & _
              "Rate, Quantity, UOM, Value from JCT_Sample_Process_Recipe where status = 'A' and devno = '" & devno & _
            "' and processcode = '" & process & "' and Recipe_Type ='" & Recipe_type & "' order by itemcode, itemvariant"

        Dim ds As DataSet = ob.FetchDS(sql)
        Return ds

    End Function

    Public Sub DeleteDyeChem(ByVal dyechem As RecipeDyeChem)
        Dim sql As String
        sql = "update JCT_Sample_Process_Recipe set status = 'D' where devno = '" & dyechem.DevNo & _
                                "' and processcode = '" & dyechem.Process & "' and ItemCode = '" & dyechem.ItemCode & _
                                "' and variant = " & dyechem.ItemVariant

        ob.UpdateRecord(sql)

    End Sub

    'Public Sub UpdateDyeChem(ByVal compcode As String, ByVal usercode As String, ByVal devno As String, ByVal process As String, _
    '                         ByVal ItemCode As String, ByVal ItemVariant As Integer, ByVal Description As String, ByVal Rate As Double, ByVal Quantity As Double, _
    '                         ByVal UOM As String, ByVal Value As Double)

    Public Sub UpdateDyeChem(ByVal dyechem As RecipeDyeChem)

        Dim sql As String
        Dim tran As SqlTransaction
        tran = cn.Connection.BeginTransaction
        Try
            sql = "update JCT_Sample_Process_Recipe set status = 'D' where devno = '" & dyechem.DevNo & _
                                            "' and processcode = '" & dyechem.Process & "' and status='A' and ItemCode = '" & dyechem.ItemCode & _
                                            "' and variant = " & dyechem.ItemVariant

            Dim cmd As SqlCommand = New SqlCommand(sql, cn.Connection)
            cmd.Transaction = tran
            cmd.ExecuteNonQuery()

            sql = "select pickup from jct_sample_process_trans where devno = '" & dyechem.DevNo & "' and process = '" & dyechem.Process & "' and status='A'"

            Dim pickup As Double = ob.FetchValue(sql)
            'dyechem.Value = dyechem.Quantity * dyechem.Rate / 1000
            If dyechem.UOM = "GPL" And Left(dyechem.ItemCode, 1) = "C" Then
                dyechem.Value = (pickup * dyechem.Quantity * dyechem.Rate) / (1000 * 100)
            ElseIf dyechem.UOM = "%" Then
                dyechem.Value = (dyechem.Quantity * dyechem.Rate) / 100
            End If

            sql = "insert JCT_Sample_Process_Recipe (CompanyCode, UserCode, CreatedDate, CreatedBy, " & _
                                "DevNo,ProcessCode,ItemCode,Variant,DESCRIPTION,Rate,Quantity,UOM,VALUE,Status)" & _
                                "values('" & dyechem.CompCode & "','" & dyechem.UserCode & "',getdate()," & _
                                "'','" & dyechem.DevNo & "','" & dyechem.Process & _
                                "','" & dyechem.ItemCode & "'," & dyechem.ItemVariant & ",'" & dyechem.Description & _
                                "'," & dyechem.Rate & "," & dyechem.Quantity & ",'" & dyechem.UOM & "'," & dyechem.Value & ",'A')"

            cmd = New SqlCommand(sql, cn.Connection)
            cmd.Transaction = tran
            cmd.ExecuteNonQuery()
            tran.Commit()
        Catch ex As Exception
            tran.Rollback()
            Throw ex
        End Try

    End Sub

End Class
