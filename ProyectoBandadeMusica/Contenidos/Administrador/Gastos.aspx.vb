Imports System.Data.SqlClient

Public Class Formulario_web15
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
                MsgBox("user")
                pnBuscador.Visible = False
                btCrear.Visible = False
                btModificar.Enabled = True
                btBorrar.Visible = False
                MsgBox(Session("DatosUsuario"))
                Dim idCliente = Session("DatosUsuario").ToString.Split("#")(3)
                Dim sentenciaCliente As String = "select * from Gastos where id=@id"
                Dim cnxCliente As New SqlConnection(cadena)
                Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
                cmdCliente.Parameters.AddWithValue("@id", idCliente)
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
                ddlmusicocongasto.SelectedIndex = -1
                ddlmusicocongasto.SelectedValue = fila("musicocongasto")
            End If
        End If

        pnDatos.Enabled = False
        listarMusicos()
        btCrear.Enabled = True
        btBorrar.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        MsgBox(Session("modifica").ToString)
        If Session("modifica").ToString = False Then
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "insert into Gastos(NombredelGasto,descripcion,Fecha,pagado,trabajo,musicocongasto) values(@NombredelGasto,@descripcion,@Fecha,@pagado,@trabajo,@musicocongasto)"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@NombredelGasto", tbNombre.Text)
            cmdInsert.Parameters.AddWithValue("@descripcion", tbdescripcion.Text)
            cmdInsert.Parameters.AddWithValue("@Fecha", clFecha.SelectedDate)
            cmdInsert.Parameters.AddWithValue("@pagado", cbpagado.Checked)
            cmdInsert.Parameters.AddWithValue("@trabajo", ddlTrabajo.SelectedValue)
            cmdInsert.Parameters.AddWithValue("@musicocongasto", ddlmusicocongasto.SelectedValue)
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

                Response.Redirect("~/Contenidos/Gastos.aspx")
            End Try
        Else
            If Session("rolAdmin") = True Then
                MsgBox("admin")
                MsgBox(Session("DatosUsuario"))
                MsgBox(Session("modifica").ToString)
                MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
                Dim cnxInsert As New SqlConnection(cadena)
                Dim sentenciaInsert As String = "update Gastos set NombredelGasto=@NombredelGasto,descripcion=@descripcion,Fecha=@Fecha,pagado=@pagado,trabajo=@trabajo,musicocongasto=@musicocongasto where id=@id"
                Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
                cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
                cmdInsert.Parameters.AddWithValue("@NombredelGasto", tbNombre.Text)
                cmdInsert.Parameters.AddWithValue("@descripcion", tbdescripcion.Text)
                cmdInsert.Parameters.AddWithValue("@Fecha", clFecha.SelectedDate)
                cmdInsert.Parameters.AddWithValue("@pagado", cbpagado.Checked)
                cmdInsert.Parameters.AddWithValue("@trabajo", ddlTrabajo.SelectedValue)
                cmdInsert.Parameters.AddWithValue("@musicocongasto", ddlmusicocongasto.SelectedValue)
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
                    Response.Redirect("~/Contenidos/Gastos.aspx")
                End Try
            Else
                MsgBox(Session("modifica").ToString)
                'MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
                Dim cnxInsert As New SqlConnection(cadena)
                Dim sentenciaInsert As String = "update Gastos set NombredelGasto=@NombredelGasto,descripcion=@descripcion,Fecha=@Fecha,pagado=@pagado,trabajo=@trabajo,musicocongasto=@musicocongasto where id=@id"
                Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
                cmdInsert.Parameters.AddWithValue("@id", Session("DatosUsuario").ToString.Split("#")(3))
                cmdInsert.Parameters.AddWithValue("@NombredelGasto", tbNombre.Text)
                cmdInsert.Parameters.AddWithValue("@descripcion", tbdescripcion.Text)
                cmdInsert.Parameters.AddWithValue("@Fecha", clFecha.SelectedDate)
                cmdInsert.Parameters.AddWithValue("@pagado", cbpagado.Checked)
                cmdInsert.Parameters.AddWithValue("@trabajo", ddlTrabajo.SelectedValue)
                cmdInsert.Parameters.AddWithValue("@musicocongasto", ddlmusicocongasto.SelectedValue)
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
                    Response.Redirect("~/Contenidos/Gastos.aspx")
                End Try
            End If
            'update

        End If
    End Sub
    Protected Sub LimpiarCampos()
        tbNombre.Text = ""
        tbdescripcion.Text = ""
        clFecha.SelectedDate = clFecha.TodaysDate
        cbpagado.Checked = False
        ddlmusicocongasto.SelectedIndex = -1
        ddlTrabajo.SelectedIndex = -1
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select * from Gastos"
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
        ddlmusicocongasto.SelectedIndex = -1
        ddlmusicocongasto.SelectedValue = fila("musicocongasto")

    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select * from Gastos"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select * from Gastos where NombredelGasto like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select * from Gastos where Fecha = " & tbBuscar.Text & ""
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select * from Gastos where pagado = " & tbBuscar.Text & ""
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
        Dim sentenciaInsert As String = "delete from Gastos where id=@id"
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
            Response.Redirect("~/Contenidos/Gastos.aspx")
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
End Class