
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_administrador_Trabajos
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        listarMusicos()
        btCrear.Enabled = True
        btBorrar.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        MsgBox(Session("modifica").ToString)
        If Session("modifica").ToString = False Then
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "insert into Trabajo(nombre,fecha,lugar,ciudad,direccion,descripcion,categoriatrabajo,completo) values(@nombre,@fecha,@lugar,@ciudad,@direccion,@descripcion,@categoriatrabajo,@completo)"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
            cmdInsert.Parameters.AddWithValue("@fecha", clFecha.SelectedDate)
            cmdInsert.Parameters.AddWithValue("@lugar", tbLugar.Text)
            cmdInsert.Parameters.AddWithValue("@ciudad", tbCiudad.Text)
            cmdInsert.Parameters.AddWithValue("@direccion", tbDireccion.Text)
            cmdInsert.Parameters.AddWithValue("@descripcion", tbDescripcion.Text)
            cmdInsert.Parameters.AddWithValue("@categoriatrabajo", ddlcategoriatrabajo.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@completo", cbCompleto.Checked)
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

                Response.Redirect("~/Contenidos/administrador/Trabajos.aspx")
            End Try
        Else
            MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
                Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "update Trabajo set nombre=@nombre,fecha=@fecha,lugar=@lugar,ciudad=@ciudad,direccion=@direccion,descripcion=@descripcion,categoriatrabajo=@categoriatrabajo,completo=@completo where id=@id"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
                cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
            cmdInsert.Parameters.AddWithValue("@nombre", tbNombre.Text)
            cmdInsert.Parameters.AddWithValue("@fecha", clFecha.SelectedDate)
            cmdInsert.Parameters.AddWithValue("@lugar", tbLugar.Text)
            cmdInsert.Parameters.AddWithValue("@ciudad", tbCiudad.Text)
            cmdInsert.Parameters.AddWithValue("@direccion", tbDireccion.Text)
            cmdInsert.Parameters.AddWithValue("@descripcion", tbDescripcion.Text)
            cmdInsert.Parameters.AddWithValue("@categoriatrabajo", ddlcategoriatrabajo.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@completo", cbCompleto.Checked)
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
                Response.Redirect("~/Contenidos/administrador/Trabajos.aspx")
            End Try
            End If
    End Sub
    Protected Sub LimpiarCampos()
        tbNombre.Text = ""
        tbLugar.Text = ""
        tbCiudad.Text = ""
        tbDireccion.Text = ""
        tbDescripcion.Text = ""

        clFecha.SelectedDate = clFecha.TodaysDate

        cbCompleto.Checked = False

        ddlcategoriatrabajo.SelectedIndex = -1
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select * from Trabajo"
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
        Dim sentenciaCliente As String = "select * from Trabajo where id=@id"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)

        tbNombre.Text = fila("nombre").ToString
        clFecha.SelectedDate = fila("fecha").ToString
        tbLugar.Text = fila("lugar").ToString
        tbCiudad.Text = fila("ciudad").ToString
        tbDireccion.Text = fila("direccion").ToString
        tbDescripcion.Text = fila("descripcion").ToString
        cbCompleto.Checked = fila("completo")
        ddlcategoriatrabajo.SelectedIndex = -1
        ddlcategoriatrabajo.SelectedValue = fila("categoriatrabajo")

    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select * from Trabajo"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select * from Trabajo where nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select * from Trabajo where ciudad like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select * from Trabajo where completo = " & tbBuscar.Text & ""
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
        Dim sentenciaInsert As String = "delete from Musicos where id=@id"
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
            Response.Redirect("~/Contenidos/administrador/Trabajos.aspx")
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
    Protected Sub btMusicoTrabajos_Click(sender As Object, e As EventArgs) Handles btMusicoTrabajos.Click
        Response.Redirect("~/Contenidos/administrador/MusicoTrabajos.aspx")
    End Sub
End Class
