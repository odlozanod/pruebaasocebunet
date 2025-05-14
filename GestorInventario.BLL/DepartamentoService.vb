Imports GestorInventario.DAL
Imports GestorInventario.Entidades

Public Class DepartamentoService
    Public Function ObtenerTodos() As List(Of Departamento)
        Using ctx As New InventarioContext()
            Return ctx.Departamentos.ToList()
        End Using
    End Function

    Public Function Crear(nombre As String) As Boolean
        Using ctx As New InventarioContext()
            ctx.Departamentos.Add(New Departamento With {.Nombre = nombre})
            ctx.SaveChanges()
            Return True
        End Using
    End Function

    Public Function Eliminar(id As Integer) As Boolean
        Using ctx As New InventarioContext()
            Dim dep = ctx.Departamentos.Find(id)
            If dep Is Nothing Then Return False

            ctx.Departamentos.Remove(dep)
            ctx.SaveChanges()
            Return True
        End Using
    End Function
End Class
