Imports Microsoft.VisualBasic

Public Class Overview
    Public Property department_description() As String
        Get
            Return m_department
        End Get
        Set(ByVal value As String)
            m_department = value
        End Set
    End Property
    Private m_department As String
    Public Property meter_location() As String
        Get
            Return m_meterlocation
        End Get
        Set(ByVal value As String)
            m_meterlocation = value
        End Set
    End Property
    Private m_meterlocation As String
    Public Property month_Name() As String
        Get
            Return m_month
        End Get
        Set(ByVal value As String)
            m_month = value
        End Set
    End Property
    Private m_month As String
    Public Property subdepartment_code() As String
        Get
            Return m_subdepartmentcode
        End Get
        Set(ByVal value As String)
            m_subdepartmentcode = value
        End Set
    End Property
    Private m_subdepartmentcode As String
    Public Property subdepartment_description() As String
        Get
            Return m_subdepartment
        End Get
        Set(ByVal value As String)
            m_subdepartment = value
        End Set
    End Property
    Private m_subdepartment As String
    Public Property meter_code() As String
        Get
            Return m_metercode
        End Get
        Set(ByVal value As String)
            m_metercode = value
        End Set
    End Property
    Private m_metercode As String
    Public Property unit_consumed() As Double
        Get
            Return m_unitconsumed
        End Get
        Set(ByVal value As Double)
            m_unitconsumed = value
        End Set
    End Property
    Private m_unitconsumed As Double
    Public Property unit_of_mesure() As String
        Get
            Return m_uom
        End Get
        Set(ByVal value As String)
            m_uom = value
        End Set
    End Property
    Private m_uom As String
End Class
