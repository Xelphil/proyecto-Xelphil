Imports System.Data.SqlClient

Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "insert into Musicos(nombre,apellidos,direccion,ciudad,coche,disponibilidad,categoriamusico) values(@nombre,@apellidos,@direccion,@ciudad,@coche,@disponibilidad,@categoriamusico)"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
        cmdInsert.Parameters.AddWithValue("@apellidos", tbApellidos.Text)
        cmdInsert.Parameters.AddWithValue("@direccion", tbDireccion.Text)
        cmdInsert.Parameters.AddWithValue("@ciudad", tbCiudad.Text)
        cmdInsert.Parameters.AddWithValue("@coche", cbCoche.Checked)
        cmdInsert.Parameters.AddWithValue("@disponibilidad", cbDisponibilidad.Checked)
        cmdInsert.Parameters.AddWithValue("@categoriamusico", ddlCategoriaMusico.SelectedValue)
        Try
            cnxInsert.Open()
            If cnxInsert.State = Data.ConnectionState.Open Then
                cmdInsert.ExecuteNonQuery()
                cmdInsert.Parameters.Clear()
                LimpiarCampos()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cnxInsert.Close()
            cnxInsert.Dispose()
        End Try
    End Sub
    Protected Sub LimpiarCampos()
        tbNombre.Text = ""
        tbApellidos.Text = ""
        tbCiudad.Text = ""
        tbDireccion.Text = ""

        cbCoche.Checked = False
        cbDisponibilidad.Checked = False

        ddlCategoriaMusico.SelectedIndex = -1
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        LimpiarCampos()
    End Sub
End Class