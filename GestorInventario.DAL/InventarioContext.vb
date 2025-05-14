Imports System.Data.Entity
Imports GestorInventario.Entidades

Public Class InventarioContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ConexionInventario")
    End Sub

    Public Property Equipos As DbSet(Of Equipo)
    Public Property Departamentos As DbSet(Of Departamento)
End Class
