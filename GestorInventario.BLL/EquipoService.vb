Imports GestorInventario.DAL
Imports GestorInventario.Entidades

Public Class EquipoService
    Public Function ObtenerTodos() As List(Of Equipo)
        Using ctx As New InventarioContext()
            Return ctx.Equipos.ToList()
        End Using
    End Function

    Public Function Crear(equipo As Equipo) As Boolean
        Using ctx As New InventarioContext()
            If ctx.Equipos.Any(Function(e) e.Serial = equipo.Serial) Then
                Throw New Exception("El serial ya existe.")
            End If

            Dim totalUsuario = ctx.Equipos.Count(Function(e) e.UsuarioACargo = equipo.UsuarioACargo)
            If totalUsuario >= 2 Then
                Throw New Exception("El usuario ya tiene 2 equipos asignados.")
            End If

            ctx.Equipos.Add(equipo)
            ctx.SaveChanges()
            Return True
        End Using
    End Function

    Public Function Editar(equipo As Equipo) As Boolean
        Using ctx As New InventarioContext()
            Dim original = ctx.Equipos.Find(equipo.Id)
            If original Is Nothing Then Return False

            original.Nombre = equipo.Nombre
            original.Tipo = equipo.Tipo
            original.Serial = equipo.Serial
            original.DepartamentoId = equipo.DepartamentoId
            original.FechaIngreso = equipo.FechaIngreso
            original.Activo = equipo.Activo
            original.UsuarioACargo = equipo.UsuarioACargo

            ctx.SaveChanges()
            Return True
        End Using
    End Function

    Public Function Desactivar(id As Integer) As Boolean
        Using ctx As New InventarioContext()
            Dim equipo = ctx.Equipos.Find(id)
            If equipo Is Nothing Then Return False

            equipo.Activo = False
            ctx.SaveChanges()
            Return True
        End Using
    End Function
End Class
