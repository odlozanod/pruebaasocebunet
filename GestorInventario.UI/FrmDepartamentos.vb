Imports GestorInventario.BLL
Imports GestorInventario.Entidades

Public Class FrmDepartamentos

    Dim servicio As New DepartamentoService

    Private Sub FrmDepartamentos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefrescarLista()
    End Sub

    Private Sub RefrescarLista()
        dgvDepartamentos.DataSource = servicio.ObtenerTodos()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtNombreDep.Text <> "" Then
            servicio.Crear(txtNombreDep.Text)
            txtNombreDep.Clear()
            RefrescarLista()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvDepartamentos.SelectedRows.Count > 0 Then
            Dim id As Integer = CInt(dgvDepartamentos.SelectedRows(0).Cells("Id").Value)
            servicio.Eliminar(id)
            RefrescarLista()
        End If
    End Sub
End Class
