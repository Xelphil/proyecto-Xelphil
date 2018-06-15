
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_administrador_Usuarios
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
        MsgBox(Session("modifica").ToString)
        If Session("modifica").ToString = False Then
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "insert into Asignacion(idRol,idMusico) values(@idRol,@idMusico)"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@idRol", ddlrol.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@idMusico", ddlusuario.SelectedValue)
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

                Response.Redirect("~/Contenidos/administrador/Usuarios.aspx")
            End Try
        Else
            MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "update Asignacion set idRol=@idRol,idMusico=@idMusico where idRol=@idRolAntiguo and idMusico=@idMusicoAntiguo"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@idRol", ddlrol.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@idMusico", ddlusuario.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@idRolAntiguo", gvMusicos.SelectedRow.Cells(2).Text)
            cmdInsert.Parameters.AddWithValue("@idMusicoAntiguo", gvMusicos.SelectedRow.Cells(4).Text)
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
                Response.Redirect("~/Contenidos/administrador/Usuarios.aspx")
            End Try
        End If
    End Sub
    Protected Sub LimpiarCampos()
        ddlrol.SelectedIndex = -1

        ddlusuario.SelectedIndex = -1
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "SELECT Roles.Rol, Asignacion.idRol, Musicos.usuario, Asignacion.idMusico FROM Asignacion INNER JOIN Musicos ON Asignacion.idMusico = Musicos.idMusico INNER JOIN Roles ON Asignacion.idRol = Roles.idRol"
        Dim cnxBuscar As New SqlConnection(cadena)
        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
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
        btModificar.Enabled = True
        btBorrar.Enabled = True
        btCrear.Enabled = False

        Dim idCliente = gvMusicos.SelectedDataKey.Value
        Dim sentenciaCliente As String = "select * from Asignacion where idRol=@idRol and idMusico=@idMusico"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@idRol", gvMusicos.SelectedRow.Cells(2).Text)
        cmdCliente.Parameters.AddWithValue("@idMusico", gvMusicos.SelectedRow.Cells(4).Text)
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)

        ddlrol.SelectedIndex = -1
        ddlrol.SelectedValue = fila("idRol")

        ddlusuario.SelectedIndex = -1
        ddlusuario.SelectedValue = fila("idMusico")

    End Sub

    Protected Sub btBorrar_Click(sender As Object, e As EventArgs) Handles btBorrar.Click
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "delete from Asignacion where idRol=@idRol and idMusico=@idMusico"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@idRol", gvMusicos.SelectedRow.Cells(2).Text)
        cmdInsert.Parameters.AddWithValue("@idMusico", gvMusicos.SelectedRow.Cells(4).Text)
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
            Response.Redirect("~/Contenidos/administrador/Usuarios.aspx")
        End Try
    End Sub

    Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click
        Session("modifica") = True
        pnDatos.Enabled = True
        MsgBox(Session("modifica").ToString)
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
