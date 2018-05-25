Imports System.Data.SqlClient

Public Class Formulario_web4
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") Is Nothing Then
            Response.Redirect("~/Inicio.aspx")
        Else
            If Session("rolAdmin") = True Then
                MsgBox("admin")
                MsgBox(Session("DatosUsuario"))
            Else
                'MsgBox("user")
                Response.Redirect("~/Contenidos/Principal.aspx")
            End If
        End If
        pnDatos.Enabled = False
        listarMusicos()
        btCrear.Enabled = True
        btModificar.Enabled = False
        btBorrar.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If Session("modifica").ToString = False Then
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "insert into CategoriaTrabajo(precio,nombre) values(@precio,@nombre)"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@precio", tbPrecio.Text)
            cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
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

                Response.Redirect("~/Contenidos/CategoriaTrabajo.aspx")
            End Try
        Else
            'update
            MsgBox(Session("modifica").ToString)
            MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "update CategoriaTrabajo set precio=@precio,nombre=@nombre where id=@id"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
            cmdInsert.Parameters.AddWithValue("@precio", tbPrecio.Text)
            cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
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
                Response.Redirect("~/Contenidos/CategoriaTrabajo.aspx")
            End Try
        End If
    End Sub
    Protected Sub LimpiarCampos()
        tbNombre.Text = ""
        tbPrecio.Text = ""
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select * from CategoriaTrabajo"
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
        Dim sentenciaCliente As String = "select * from CategoriaTrabajo where id=@id"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)
        tbPrecio.Text = fila("precio").ToString
        tbNombre.Text = fila("nombre").ToString
        Session("IdCategoriaTrabajo") = fila("id").ToString
        btInstrumentosNec.Enabled = True
    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select * from CategoriaTrabajo"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select * from CategoriaTrabajo where nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select * from CategoriaTrabajo where precio like '%" & tbBuscar.Text & "%'"
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
        Dim sentenciaInsert As String = "delete from CategoriaTrabajo where id=@id"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
        Try
            BorrarInstrumentosNecesarios(gvMusicos.SelectedDataKey.Value.ToString)
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
            Response.Redirect("~/Contenidos/CategoriaTrabajo.aspx")
        End Try
    End Sub

    Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click
        Session("modifica") = True
        pnDatos.Enabled = True
    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        btModificar.Enabled = False
        btBorrar.Enabled = False
        pnDatos.Enabled = True
        LimpiarCampos()
        Session("modifica") = False
    End Sub

    Protected Sub btInstrumentosNec_Click(sender As Object, e As EventArgs) Handles btInstrumentosNec.Click
        Response.Redirect("~/Contenidos/InstrumentosNecesarios.aspx")
    End Sub

    Public Sub BorrarInstrumentosNecesarios(ByVal id As Int32)
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "delete from InstrumentosNecesarios where idcategoriatrabajo=@id"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@id", id)
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
            Response.Redirect("~/Contenidos/InstrumentosNecesarios.aspx")
        End Try
    End Sub
End Class