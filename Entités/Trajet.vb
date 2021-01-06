Public Class Trajet


    Private _Ref As String
    Private _Position_Depart As String
    Private _Position_Arrivee As String

    Public Sub New(Ref As String, Position_Depart As String, Position_Arrivee As String)
        _Ref = Ref
        _Position_Depart = Position_Depart
        _Position_Arrivee = Position_Arrivee
    End Sub

    Public Property Ref As String
        Get
            Return _Ref
        End Get
        Set(value As String)
            _Ref = value
        End Set
    End Property

    Public Property Position_Depart As String
        Get
            Return _Position_Depart
        End Get
        Set(value As String)
            _Position_Depart = value
        End Set
    End Property

    Public Property Position_Arrivee As String
        Get
            Return _Position_Arrivee
        End Get
        Set(value As String)
            _Position_Arrivee = value
        End Set
    End Property
End Class
