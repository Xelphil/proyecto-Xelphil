
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_administrador_MusicoTrabajos
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        listarMusicos()
        btBorrar.Enabled = False
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "insert into MusicoTrabajos(idMusicos,idTrabajo) values(@idMusicos,@idTrabajo)"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@idMusicos", ddlMusico.SelectedValue)
        cmdInsert.Parameters.AddWithValue("@idTrabajo", ddltrabajo.SelectedValue)

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

            Response.Redirect("~/Contenidos/administrador/MusicoTrabajos.aspx")
        End Try
    End Sub
    Protected Sub LimpiarCampos()
        ddlMusico.SelectedIndex = -1

        ddltrabajo.SelectedIndex = -1
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select Trabajo.nombre,Trabajo.descripcion,Trabajo.fecha,MusicoTrabajos.idTrabajo,Musicos.nombre,Musicos.apellidos,MusicoTrabajos.idMusicos from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo join Musicos on MusicoTrabajos.idMusicos=Musicos.idMusico"
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
        btBorrar.Enabled = False
    End Sub

    Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
        'MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
        btBorrar.Enabled = True

        Dim idCliente = gvMusicos.SelectedDataKey.Value
        Dim sentenciaCliente As String = "select Trabajo.nombre,Trabajo.descripcion,Trabajo.fecha,MusicoTrabajos.idTrabajo,Musicos.nombre,Musicos.apellidos,MusicoTrabajos.idMusicos from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo join Musicos on MusicoTrabajos.idMusicos=Musicos.idMusico where idTrabajo=@id"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)

        ddlMusico.SelectedIndex = -1
        ddlMusico.SelectedValue = fila("idMusicos")

        ddltrabajo.SelectedIndex = -1
        ddltrabajo.SelectedValue = fila("idTrabajo")

    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select Trabajo.nombre,Trabajo.descripcion,Trabajo.fecha,MusicoTrabajos.idTrabajo,Musicos.nombre,Musicos.apellidos,MusicoTrabajos.idMusicos from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo join Musicos on MusicoTrabajos.idMusicos=Musicos.idMusico"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select Trabajo.nombre,Trabajo.descripcion,Trabajo.fecha,MusicoTrabajos.idTrabajo,Musicos.nombre,Musicos.apellidos,MusicoTrabajos.idMusicos from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo join Musicos on MusicoTrabajos.idMusicos=Musicos.idMusico where Trabajo.nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select Trabajo.nombre,Trabajo.descripcion,Trabajo.fecha,MusicoTrabajos.idTrabajo,Musicos.nombre,Musicos.apellidos,MusicoTrabajos.idMusicos from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo join Musicos on MusicoTrabajos.idMusicos=Musicos.idMusico where Musico.nombre like '%" & tbBuscar.Text & "%'"
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
        Dim sentenciaInsert As String = "delete from MusicoTrabajos where idMusicos=@idMusicos and idTrabajo=@idTrabajo"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        MsgBox("Musico:" & gvMusicos.SelectedRow.Cells(7).Text.ToString)
        cmdInsert.Parameters.AddWithValue("@idMusicos", gvMusicos.SelectedRow.Cells(7).Text.ToString)
        MsgBox("Trabajo:" & gvMusicos.SelectedDataKey.Value)
        cmdInsert.Parameters.AddWithValue("@idTrabajos", gvMusicos.SelectedDataKey.Value)
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
            Response.Redirect("~/Contenidos/administrador/MusicoTrabajos.aspx")
        End Try
    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        btBorrar.Enabled = False
        pnDatos.Enabled = True
        LimpiarCampos()
    End Sub
    Protected Sub btMusicoTrabajos_Click(sender As Object, e As EventArgs) Handles btMusicoTrabajos.Click
        Response.Redirect("~/Contenidos/administrador/Trabajos.aspx")
    End Sub
End Class
