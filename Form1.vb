Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.FormCollection
Imports System.ComponentModel
Imports System.ComponentModel.DesignerAttribute

Public Class Form1
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
End Class
