Public Class ItemNotAllowedException
    Inherits System.ApplicationException

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class
