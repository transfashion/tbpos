Public Class BitmapData

    Private _Dots As BitArray
    Private _Height As Integer
    Private _Width As Integer

    Public Property Dots() As BitArray
        Get
            Return Me._Dots
        End Get
        Set(ByVal value As BitArray)
            Me._Dots = value
        End Set
    End Property

    Public Property Height() As Integer
        Get
            Return Me._Height
        End Get
        Set(ByVal value As Integer)
            Me._Height = value
        End Set
    End Property

    Public Property Width() As Integer
        Get
            Return Me._Width
        End Get
        Set(ByVal value As Integer)
            Me._Width = value
        End Set
    End Property



End Class
