
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_administrador_Musicos
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        listarMusicos()
        btCrear.Enabled = True
        btModificar.Enabled = False
        btBorrar.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        'MsgBox(Session("modifica").ToString)
        If Session("modifica").ToString = False Then
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "insert into Musicos(nombre,apellidos,direccion,ciudad,coche,disponibilidad,categoriamusico,usuario,password) values(@nombre,@apellidos,@direccion,@ciudad,@coche,@disponibilidad,@categoriamusico,@usuario,@contraseña)"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
            cmdInsert.Parameters.AddWithValue("@apellidos", tbApellidos.Text)
            cmdInsert.Parameters.AddWithValue("@direccion", tbDireccion.Text)
            cmdInsert.Parameters.AddWithValue("@ciudad", tbCiudad.Text)
            cmdInsert.Parameters.AddWithValue("@coche", cbCoche.Checked)
            cmdInsert.Parameters.AddWithValue("@disponibilidad", cbDisponibilidad.Checked)
            cmdInsert.Parameters.AddWithValue("@categoriamusico", ddlCategoriaMusico.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@usuario", tbUsuario.Text)
            cmdInsert.Parameters.AddWithValue("@contraseña", tbPass2.Text)
            Try
                cnxInsert.Open()
                If cnxInsert.State = Data.ConnectionState.Open Then
                    cmdInsert.ExecuteNonQuery()
                    cmdInsert.Parameters.Clear()
                    LimpiarCampos()
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
                MsgBox(ex.Message)
            Finally
                cnxInsert.Close()
                cnxInsert.Dispose()

                Response.Redirect("~/contenidos/administrador/Musicos.aspx")
            End Try
        Else
            ' MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "update Musicos set nombre=@nombre,apellidos=@apellidos,direccion=@direccion,ciudad=@ciudad,coche=@coche,disponibilidad=@disponibilidad,categoriamusico=@categoriamusico,usuario=@usuario,password=@contraseña where idMusico=@id"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
                cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
                cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
                cmdInsert.Parameters.AddWithValue("@apellidos", tbApellidos.Text)
                cmdInsert.Parameters.AddWithValue("@direccion", tbDireccion.Text)
                cmdInsert.Parameters.AddWithValue("@ciudad", tbCiudad.Text)
                cmdInsert.Parameters.AddWithValue("@coche", cbCoche.Checked)
                cmdInsert.Parameters.AddWithValue("@disponibilidad", cbDisponibilidad.Checked)
            cmdInsert.Parameters.AddWithValue("@categoriamusico", ddlCategoriaMusico.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@usuario", tbUsuario.Text)
            cmdInsert.Parameters.AddWithValue("@contraseña", tbPass2.Text)
            Try
                    cnxInsert.Open()
                    If cnxInsert.State = Data.ConnectionState.Open Then
                        cmdInsert.ExecuteNonQuery()
                        cmdInsert.Parameters.Clear()

                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                Finally
                    cnxInsert.Close()
                    cnxInsert.Dispose()
                    Response.Redirect("~/contenidos/administrador/Musicos.aspx")
                End Try
            End If
    End Sub
    Protected Sub LimpiarCampos()
        tbNombre.Text = ""
        tbApellidos.Text = ""
        tbCiudad.Text = ""
        tbDireccion.Text = ""

        cbCoche.Checked = False
        cbDisponibilidad.Checked = False

        ddlCategoriaMusico.SelectedIndex = -1

        tbUsuario.Text = ""
        tbPass1.Text = ""
        tbPass2.Text = ""
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select Musicos.idMusico,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id"
        Dim cnxBuscar As New SqlConnection(cadena)
        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
        'cmdBuscar.Parameters.AddWithValue("@Cliente", Session("cliente").ToString.Split("#")(0))
        Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
        Dim dt As New DataTable
        adaptadorBuscar.Fill(dt)
        gvMusicos.DataSource = dt
        gvMusicos.DataBind()
    End Sub
    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        LimpiarCampos()
        btCrear.Enabled = True
        btBorrar.Enabled = False
        btModificar.Enabled = False
    End Sub

    Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
        'MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
        btModificar.Enabled = True
        btBorrar.Enabled = True
        btCrear.Enabled = False

        Dim idCliente = gvMusicos.SelectedDataKey.Value
        Dim sentenciaCliente As String = "select * from Musicos where idMusico=@id"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
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
    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select Musicos.idMusico,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select Musicos.idMusico,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.coche = " & tbBuscar.Text & ""
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select Musicos.idMusico,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.disponibilidad = " & tbBuscar.Text & ""
            End If
            If ddlBuscar.SelectedValue = 4 Then
                sentenciaBuscar = "select Musicos.idMusico,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.categoriamusico = " & tbBuscar.Text & ""
            End If
            Dim cnxBuscar As New SqlConnection(cadena)
            Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
            Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
            Dim dt As New DataTable
            adaptadorBuscar.Fill(dt)
            gvMusicos.DataSource = dt
            gvMusicos.DataBind()
            LimpiarCampos()
        End If

    End Sub

    Protected Sub btBorrar_Click(sender As Object, e As EventArgs) Handles btBorrar.Click
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "delete from Musicos where idMusico=@id"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
        Try
            cnxInsert.Open()
            If cnxInsert.State = Data.ConnectionState.Open Then
                cmdInsert.ExecuteNonQuery()
                cmdInsert.Parameters.Clear()

            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cnxInsert.Close()
            cnxInsert.Dispose()
            LimpiarCampos()
            Response.Redirect("~/contenidos/administrador/Musicos.aspx")
        End Try
    End Sub

    Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click
        Session("modifica") = True
        pnDatos.Enabled = True
        'MsgBox(Session("modifica").ToString)
    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        btModificar.Enabled = False
        btBorrar.Enabled = False
        pnDatos.Enabled = True
        LimpiarCampos()
        Session("modifica") = False
    End Sub

    Protected Sub btMusicos_Click(sender As Object, e As EventArgs) Handles btMusicos.Click
        Response.Redirect("~/Contenidos/administrador/Musicos.aspx")
    End Sub

    Protected Sub btInstrumentos_Click(sender As Object, e As EventArgs) Handles btInstrumentos.Click
        Response.Redirect("~/Contenidos/administrador/Instrumentos.aspx")
    End Sub

    Protected Sub btCatMus_Click(sender As Object, e As EventArgs) Handles btCatMus.Click
        Response.Redirect("~/Contenidos/administrador/CategoriaMusico.aspx")
    End Sub

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        codigo.salir(Context.User.Identity.Name)
    End Sub

    Protected Sub btCatTrab_Click(sender As Object, e As EventArgs) Handles btCatTrab.Click
        Response.Redirect("~/Contenidos/administrador/CategoriaTrabajo.aspx")
    End Sub

    Protected Sub btTrabajos_Click(sender As Object, e As EventArgs) Handles btTrabajos.Click
        Response.Redirect("~/Contenidos/administrador/Trabajos.aspx")
    End Sub

    Protected Sub btGastos_Click(sender As Object, e As EventArgs) Handles btGastos.Click
        Response.Redirect("~/Contenidos/administrador/Gastos.aspx")
    End Sub

    Protected Sub btUsuarios_Click(sender As Object, e As EventArgs) Handles btUsuarios.Click
        Response.Redirect("~/Contenidos/administrador/Usuarios.aspx")
    End Sub
End Class
