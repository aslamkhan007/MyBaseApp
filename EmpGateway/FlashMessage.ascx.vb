'Written by Neil C. Meredith (9/10/2007)

Partial Class FlashMessage
    Inherits System.Web.UI.UserControl

    Dim _Interval As String = 4000
    Dim _FadeInDuration As Integer = 500
    Dim _FadeInSteps As Integer = 20
    Dim _FadeOutDuration As Integer = 500
    Dim _FadeOutSteps As Integer = 20
    Dim _InsertJavascript As Boolean = True

#Region "Properties"
    ''' <summary>
    ''' Override the default css class
    ''' </summary>
    Public Property CssClass() As String
        Get
            Return lblMessage.CssClass
        End Get
        Set(ByVal value As String)
            lblMessage.CssClass = value
        End Set
    End Property

    ''' <summary>
    ''' The message to display
    ''' </summary>
    Public Property Message() As String
        Get
            Return lblMessage.Text
        End Get
        Set(ByVal value As String)
            lblMessage.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Time in milliseconds to display the message
    ''' </summary>
    Public Property Interval() As Integer
        Get
            Return _Interval
        End Get
        Set(ByVal value As Integer)
            _Interval = value
        End Set
    End Property

    Public Property FadeInDuration() As Integer
        Get
            Return _FadeInDuration
        End Get
        Set(ByVal value As Integer)
            _FadeInDuration = value
        End Set
    End Property
    Public Property text() As String
        Get
            Return Me.lblMessage.Text
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Property meaasage_to_display() As String
        Get
            Return Me.lblMessage.Text
        End Get
        Set(ByVal value As String)
            Me.lblMessage.Text = value
        End Set
    End Property
    Public Property height() As Integer
        Get

        End Get
        Set(ByVal value As Integer)

        End Set
    End Property

    Public Property FadeInSteps() As Integer
        Get
            Return _FadeInSteps
        End Get
        Set(ByVal value As Integer)
            _FadeInSteps = value
        End Set
    End Property


    Public Property FadeOutDuration() As Integer
        Get
            Return _FadeOutDuration
        End Get
        Set(ByVal value As Integer)
            _FadeOutDuration = value
        End Set


    End Property
 

    Public Property FadeOutSteps() As Integer
        Get
            Return _FadeOutSteps
        End Get
        Set(ByVal value As Integer)
            _FadeOutSteps = value
        End Set
    End Property

    Public Enum PropertiesEnum
        Item1
        Item2
        tem3

    End Enum
    Public Property PropertyTest() As PropertiesEnum

        Get
            'Dim intValue As Integer = CInt(ViewState("PropertyTest"))

        End Get
        Set(ByVal value As PropertiesEnum)
            'ViewState("PropertyTest") = value
        End Set
    End Property

   

#End Region

#Region "Methods"

    Public Sub Display()

        'Set the duration, steps, etc. for the javascript fade in and fade out   
        Dim js As String = "fadeIn('" & lblMessage.ClientID & _
            "', " & FadeInSteps & _
            ", " & FadeInDuration & _
            ", " & Interval & _
            ", " & FadeOutSteps & _
            ", " & FadeOutDuration & ");"


        'Find the script manager on the page, and the update panel the FlashMessage control
        'is nested in

        Dim sm As ScriptManager = ScriptManager.GetCurrent(Page)
        Dim up As UpdatePanel = GetParentOfType(lblMessage, GetType(UpdatePanel))


        If Not IsNothing(sm) And Not IsNothing(up) Then
            'The user control is nested in an update panel, register the javascript with the script manager and
            'attach it to the update panel in order to fire it after the async postback
            If sm.IsInAsyncPostBack = True Then
                ScriptManager.RegisterClientScriptBlock(up, GetType(UpdatePanel), "jscript1", js, True)
            End If
        Else
            'The user control is not in an update panel (or there is no script manager on the page), 
            'so register the javascript for a normal postback
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "jscript1", js, True)
        End If

    End Sub


    ''' <summary>
    ''' Return the parent control of the given root control, as long as it matches the entered type
    ''' </summary>
    Private Function GetParentOfType(ByVal root As Control, ByVal Type As System.Type) As Control
        Dim Parent As Control = root.Parent
        If IsNothing(Parent) Then
            Return Nothing
        End If
        If Parent.GetType.ToString = Type.ToString Then
            Return root.Parent
        End If
        Dim p As Control = GetParentOfType(Parent, Type)
        If Not p Is Nothing Then
            Return p
        End If
        Return Nothing
    End Function

#End Region

End Class
