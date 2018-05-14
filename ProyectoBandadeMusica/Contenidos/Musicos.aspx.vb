Imports System.Data.SqlClient

Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        listarMusicos()
        btModificar.Enabled = False
        btBorrar.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click

        Dim cnxComprobacion As New SqlConnection(cadena)
        Dim sentenciaComprobacion As String = "select COUNT(id) from Musicos where id=@id"
        Dim cmdComprobacion As New SqlCommand(sentenciaComprobacion, cnxComprobacion)
        cmdComprobacion.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
        Dim opcion As Integer
        Try
            cnxComprobacion.Open()
            If cnxComprobacion.State = Data.ConnectionState.Open Then
                opcion = cmdComprobacion.ExecuteScalar()
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            cnxComprobacion.Close()
            cnxComprobacion.Dispose()
        End Try
        If opcion = 0 Then
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
        Else
            'update
            '
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
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id"
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
    End Sub

    Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
        'MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
        btModificar.Enabled = True
        btBorrar.Enabled = True
        btCrear.Enabled = False

        Dim idCliente = gvMusicos.SelectedDataKey.Value
        Dim sentenciaCliente As String = "select * from Musicos where id=@id"
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

        'Almaceno los datos de Cliente.
        'Session("cliente") = idCliente & "#" & fila("RazonSocial").ToString & "#" & fila("NombreComercial").ToString & "#" & fila("TipoIdSede") & "#" & fila("TipoIdSoporte") & "#" & fila("TipoIdDepartamento") & "#" & fila("TipoIdEquipo") & "#" & fila("TipoIdTrabajadores")

    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.coche = " & tbBuscar.Text & ""
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.disponibilidad = " & tbBuscar.Text & ""
            End If
            If ddlBuscar.SelectedValue = 4 Then
                sentenciaBuscar = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id where Musicos.categoriamusico = " & tbBuscar.Text & ""
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
        'Dim cnxDelete As New SqlConnection(cadena)
        'Dim sentenciaDelete As String = "delete from Clientes where idCliente = @idCliente and Consultora = @Consultora"
        'Dim cmdDelete As New SqlCommand(sentenciaDelete, cnxDelete)
        'cmdDelete.Parameters.AddWithValue("@idCliente", lbCodigo.Text)
        'cmdDelete.Parameters.AddWithValue("@Consultora", Session("idConsultora"))
        'Try
        '    cnxDelete.Open()
        '    If cnxDelete.State = Data.ConnectionState.Open Then
        '        eliminarSedes(lbCodigo.Text)
        '        eliminarTrabajadores(lbCodigo.Text)
        '        eliminarUsuariosRel(lbCodigo.Text)
        '        Dim nfinsert = cmdDelete.ExecuteNonQuery()
        '        If nfinsert > 0 Then
        '            '-------------------------
        '            Dim cnxNotificacion As New SqlConnection(cadena)
        '            Dim sentenciaNotificacion As String = "insert into NotificacionesClientes(Cliente,Consultora,Descripcion,Fecha,Leido) values (@Cliente,@Consultora,@Descripcion,@Fecha,@Leido)"
        '            Dim cmdNotificacion As New SqlCommand(sentenciaNotificacion, cnxNotificacion)
        '            cmdNotificacion.Parameters.AddWithValue("@Cliente", tbCodigo.Text)
        '            cmdNotificacion.Parameters.AddWithValue("@Consultora", Session("IdConsultora"))
        '            cmdNotificacion.Parameters.AddWithValue("@Descripcion", DescripciondelCambio)
        '            cmdNotificacion.Parameters.AddWithValue("@Fecha", DateTime.Now)
        '            cmdNotificacion.Parameters.AddWithValue("@Leido", False)
        '            Try
        '                cnxNotificacion.Open()
        '                If cnxNotificacion.State = Data.ConnectionState.Open Then
        '                    cmdNotificacion.ExecuteNonQuery()
        '                    cmdNotificacion.Parameters.Clear()
        '                End If
        '            Catch ex As Exception
        '                Throw New Exception(ex.Message)
        '            Finally
        '                cnxNotificacion.Close()
        '                cnxNotificacion.Dispose()
        '            End Try
        '            '------------------------------
        '        End If
        '        listarClientes()
        '        LimpiarCampos()
        '        lbCodigo.Text = ""
        '        lbRazon.Text = ""
        '        lbNombreCom.Text = ""
        '        Session("cliente") = Nothing
        '        btNuevo.Enabled = True
        '    End If
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'Finally
        '    cnxDelete.Close()
        '    cnxDelete.Dispose()
        'End Try
    End Sub

    Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click

    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        pnDatos.Enabled = True
        LimpiarCampos()
    End Sub
End Class