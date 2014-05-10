Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.FormCollection
Imports System.ComponentModel
Imports System.ComponentModel.DesignerAttribute
Imports System.Windows.Forms.Design
Imports System.Windows.Forms

'<AttributeUsage(AttributeTargets.Class Or _
'    AttributeTargets.Method)> Class DeveloperInfoAttribute
'Inherits Form
'
'Private _Description As String
'Private _name As String
'Private _lastChanged As String
'
'Public ReadOnly Property Notes() As String
'    Get
'        Return _Description
'    End Get
'End Property
'
'Public ReadOnly Property Author() As String
'    Get
'        Return _name
'    End Get
'End Property
'
'Public Property LastChanged() As String
'    Get
'        Return _lastChanged
'    End Get
'    Set(ByVal Value As String)
'        _lastChanged = Value
'    End Set
'End Property
'
'Sub New(ByVal author As String, ByVal notes As String)
'    _name = author
'    _Description = notes
'End Sub
'
'End Class

<AttributeUsage(AttributeTargets.Class Or _
    AttributeTargets.Method)> Public Class Form1
    '    Public Class Form1
    'declare variable's 
    Dim x, y As Integer
    Dim newpoint As New Point

    Dim _hexagon As String

    'declare custom properties
    Public Property Hexagon() As String
        Get
            Return _hexagon
        End Get
        Set(ByVal Value As String)
            _hexagon = Value
        End Set
    End Property

    Sub HexForm(Htype As Integer)
        'Dim windowRegion As Region
        Dim regionPoints(5) As Point
        Dim regionTypes(5) As Byte
        Dim v As Integer = CInt(Me.Width / 2 * Math.Sin(30 * Math.PI / 180))
        Select Case Htype
            Case 0
                'pointy hexagon form
                regionPoints(0) = New Point(Me.Width \ 2, 0)
                regionPoints(1) = New Point(Me.Width, v)
                regionPoints(2) = New Point(Me.Width, Me.Height - v)
                regionPoints(3) = New Point(Me.Width \ 2, Me.Height)
                regionPoints(4) = New Point(0, Me.Height - v)
                regionPoints(5) = New Point(0, v)
            Case 1
                'flat hexagon form
                regionPoints(0) = New Point(Me.Width - v, 0)
                regionPoints(1) = New Point(Me.Width, Me.Height / 2)
                regionPoints(2) = New Point(Me.Width - v, Me.Height)
                regionPoints(3) = New Point(v, Me.Height)
                regionPoints(4) = New Point(0, Me.Height / 2)
                regionPoints(5) = New Point(v, 0)
        End Select
        Dim Cnt As Long
        For Cnt = 0 To 5
            regionTypes(Cnt) = PathPointType.Line
        Next Cnt
        Dim regionPath As New GraphicsPath(regionPoints, regionTypes)
        Me.Region = New Region(regionPath)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        HexForm(1)
    End Sub

    Private Sub Form1_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        HexForm(1)
    End Sub

    Private Sub Form1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        'on mousedown event 
        'sets the coordinates 
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub Form1_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'on mousemove event 
        'checks if it is the left button of the mouse 
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'sets the positions 
            newpoint = Control.MousePosition
            newpoint.X -= (x)
            newpoint.Y -= (y)
            'gives it the new location 
            Me.Location = newpoint
        End If
    End Sub

    Sub AddMyCustomProperty()
        'PropertyGrid.ControlCollection.
        'Me.Controls.Add(PropertyGrid.PropertyTabCollection)

    End Sub
End Class
