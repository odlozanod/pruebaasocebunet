Public Class FrmPrincipal

    Private Sub FrmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Podrías mostrar resumen acá
    End Sub

    Private Sub btnEquipos_Click(sender As Object, e As EventArgs) Handles btnEquipos.Click
        Dim f As New FrmEquipos
        f.ShowDialog()
    End Sub

    Private Sub btnDepartamentos_Click(sender As Object, e As EventArgs) Handles btnDepartamentos.Click
        Dim f As New FrmDepartamentos
        f.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class
