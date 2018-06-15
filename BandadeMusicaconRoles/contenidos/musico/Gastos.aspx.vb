
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_musico_Gastos
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        listarMusicos()
        btCrear.Enabled = True
        tbmusicocongasto.Text = Session("dUsuario").Rows(0).item(0)
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "insert into Gastos(NombredelGasto,descripcion,Fecha,pagado,trabajo,musicocongasto) values(@NombredelGasto,@descripcion,@Fecha,@pagado,@trabajo,@musicocongasto)"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@NombredelGasto", tbNombre.Text)
        cmdInsert.Parameters.AddWithValue("@descripcion", tbdescripcion.Text)
        cmdInsert.Parameters.AddWithValue("@Fecha", clFecha.SelectedDate)
        cmdInsert.Parameters.AddWithValue("@pagado", cbpagado.Checked)
        cmdInsert.Parameters.AddWithValue("@trabajo", ddlTrabajo.SelectedValue)
        cmdInsert.Parameters.AddWithValue("@musicocongasto", Session("dUsuario").Rows(0).item(0))
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

            Response.Redirect("~/Contenidos/musico/Gastos.aspx")
        End Try
    End Sub
    Protected Sub LimpiarCampos()
        tbNombre.Text = ""
        tbdescripcion.Text = ""
        clFecha.SelectedDate = clFecha.TodaysDate
        cbpagado.Checked = False
        ddlTrabajo.SelectedIndex = -1
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select * from Gastos where musicocongasto=@musicocongasto"
        Dim cnxBuscar As New SqlConnection(cadena)
        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
        cmdBuscar.Parameters.AddWithValue("@musicocongasto", Session("dUsuario").Rows(0).item(0))
        Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
        Dim dt As New DataTable
        adaptadorBuscar.Fill(dt)
        gvMusicos.DataSource = dt
        gvMusicos.DataBind()
    End Sub
    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        LimpiarCampos()
        btCrear.Enabled = True
    End Sub

    Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
        btCrear.Enabled = False

        Dim idCliente = gvMusicos.SelectedDataKey.Value
        Dim sentenciaCliente As String = "select * from Gastos where id=@id"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)

        tbNombre.Text = fila("NombredelGasto").ToString
        tbdescripcion.Text = fila("descripcion").ToString
        clFecha.SelectedDate = fila("Fecha").ToString
        cbpagado.Checked = fila("pagado")
        ddlTrabajo.SelectedIndex = -1
        ddlTrabajo.SelectedValue = fila("trabajo")
    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select * from Gastos where musicocongasto=@musicocongasto"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select * from Gastos where NombredelGasto like '%" & tbBuscar.Text & "%' and musicocongasto=@musicocongasto"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select * from Gastos where trabajo = " & tbBuscar.Text & " and musicocongasto=@musicocongasto"
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select * from Gastos where pagado = " & tbBuscar.Text & " and musicocongasto=@musicocongasto"
            End If
            Dim cnxBuscar As New SqlConnection(cadena)
            Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
            cmdBuscar.Parameters.AddWithValue("@musicocongasto", Session("dUsuario").Rows(0).item(0))
            Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
            Dim dt As New DataTable
            adaptadorBuscar.Fill(dt)
            gvMusicos.DataSource = dt
            gvMusicos.DataBind()
            LimpiarCampos()
        End If

    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        pnDatos.Enabled = True
        LimpiarCampos()
        Session("modifica") = False
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
