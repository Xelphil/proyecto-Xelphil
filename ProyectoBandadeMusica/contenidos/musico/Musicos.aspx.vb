
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_musico_Musicos
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        btModificar.Enabled = True
        Dim sentenciaCliente As String = "select * from Musicos where idMusico=@idMusico"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@idMusico", Session("dUsuario").Rows(0).item(0))
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)

        tbNombre.Text = fila("nombre").ToString
        tbApellidos.Text = fila("apellidos").ToString
        tbCiudad.Text = fila("ciudad").ToString
        tbDireccion.Text = fila("direccion").ToString
        cbCoche.Checked = fila("coche")
        cbDisponibilidad.Checked = fila("disponibilidad")
        ddlCategoriaMusico.SelectedIndex = -1
        ddlCategoriaMusico.SelectedValue = fila("categoriamusico")
        tbUsuario.Text = fila("usuario").ToString
        tbPass1.Text = fila("password").ToString
        tbPass2.Text = fila("password").ToString
        pnDatos.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        MsgBox(Session("dUsuario").Rows(0).item(0))
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "update Musicos set nombre=@nombre,apellidos=@apellidos,direccion=@direccion,ciudad=@ciudad,coche=@coche,disponibilidad=@disponibilidad,categoriamusico=@categoriamusico,usuario=@usuario,password=@password where idMusico=@id"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@id", Session("dUsuario").Rows(0).item(0))
        cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
        cmdInsert.Parameters.AddWithValue("@apellidos", tbApellidos.Text)
        cmdInsert.Parameters.AddWithValue("@direccion", tbDireccion.Text)
        cmdInsert.Parameters.AddWithValue("@ciudad", tbCiudad.Text)
        cmdInsert.Parameters.AddWithValue("@coche", cbCoche.Checked)
        cmdInsert.Parameters.AddWithValue("@disponibilidad", cbDisponibilidad.Checked)
        cmdInsert.Parameters.AddWithValue("@categoriamusico", ddlCategoriaMusico.SelectedValue)
        cmdInsert.Parameters.AddWithValue("@usuario", tbUsuario.Text)
        cmdInsert.Parameters.AddWithValue("@password", tbPass2.Text)
        Try
            cnxInsert.Open()

            cmdInsert.ExecuteNonQuery()
            cmdInsert.Parameters.Clear()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cnxInsert.Close()
            cnxInsert.Dispose()
            Response.Redirect("~/Contenidos/musico/Musicos.aspx")
        End Try
    End Sub

    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        btModificar.Enabled = False
    End Sub
    Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click
        pnDatos.Enabled = True
    End Sub

    Protected Sub btMusicos_Click(sender As Object, e As EventArgs) Handles btMusicos.Click
        Response.Redirect("~/Contenidos/musico/Musicos.aspx")
    End Sub

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        codigo.salir(Context.User.Identity.Name)
    End Sub

    Protected Sub btTrabajos_Click(sender As Object, e As EventArgs) Handles btTrabajos.Click
        Response.Redirect("~/Contenidos/musico/Trabajos.aspx")
    End Sub

    Protected Sub btGastos_Click(sender As Object, e As EventArgs) Handles btGastos.Click
        Response.Redirect("~/Contenidos/musico/Gastos.aspx")
    End Sub
End Class
