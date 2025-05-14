Imports GestorInventario.BLL
Imports GestorInventario.Entidades

Public Class FrmEquipos

    Dim servicio As New EquipoService
    Dim deptoService As New DepartamentoService

    Private Sub FrmEquipos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarComboDepartamentos()
        CargarComboTipos()
        RefrescarLista()
    End Sub

    Private Sub CargarComboDepartamentos()
        Dim deps = deptoService.ObtenerTodos()
        cmbDepartamento.DataSource = deps
        cmbDepartamento.DisplayMember = "Nombre"
        cmbDepartamento.ValueMember = "Id"
    End Sub

    Private Sub CargarComboTipos()
        cmbTipo.Items.AddRange(New String() {"PC", "Laptop", "Impresora", "Scanner", "Otro"})
        cmbTipo.SelectedIndex = 0
    End Sub

    Private Sub RefrescarLista()
        dgvEquipos.DataSource = servicio.ObtenerTodos()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim nuevo As New Equipo With {
                .Nombre = txtNombre.Text,
                .Tipo = cmbTipo.Text,
                .Serial = txtSerial.Text,
                .DepartamentoId = CInt(cmbDepartamento.SelectedValue),
                .FechaIngreso = dtpFecha.Value,
                .Activo = chkActivo.Checked,
                .UsuarioACargo = txtUsuario.Text
            }

            servicio.Crear(nuevo)
            MessageBox.Show("Equipo guardado.")
            RefrescarLista()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Agrega más botones según tus operaciones (editar, desactivar, etc.)
End Class
