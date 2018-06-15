
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_musico_MusicoTrabajos
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        listarMusicos()
    End Sub

    Public Sub listarMusicos()
        ''cambiar a los usuarios
        Dim sentenciaBuscar As String = "select * from Trabajo where completo=0 and Trabajo.id not in (select Trabajo.id from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo where MusicoTrabajos.idMusicos=@idMusicos)"
        Dim cnxBuscar As New SqlConnection(cadena)
        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
        cmdBuscar.Parameters.AddWithValue("@idMusicos", Session("dUsuario").Rows(0).item(0))
        Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
        Dim dt As New DataTable
        adaptadorBuscar.Fill(dt)
        gvMusicos.DataSource = dt
        gvMusicos.DataBind()
    End Sub

    Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "insert into MusicoTrabajos(idMusicos,idTrabajo) values(@idMusicos,@idTrabajo)"
        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
        cmdInsert.Parameters.AddWithValue("@idMusicos", Session("dUsuario").Rows(0).item(0))
        cmdInsert.Parameters.AddWithValue("@idTrabajo", gvMusicos.SelectedDataKey.Value)
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

            Response.Redirect("~/Contenidos/musico/MusicoTrabajos.aspx")
        End Try

    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select * from Trabajo where completo=0 and Trabajo.id not in (select Trabajo.id from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo where MusicoTrabajos.idMusicos=@idMusicos)"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select * from Trabajo where completo=0 and Trabajo.id not in (select Trabajo.id from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo where MusicoTrabajos.idMusicos=@idMusicos) and nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select * from Trabajo where completo=0 and Trabajo.id not in (select Trabajo.id from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo where MusicoTrabajos.idMusicos=@idMusicos) and ciudad like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select * from Trabajo where completo=0 and Trabajo.id not in (select Trabajo.id from Trabajo join MusicoTrabajos on Trabajo.id=MusicoTrabajos.idTrabajo where MusicoTrabajos.idMusicos=@idMusicos) and completo = " & tbBuscar.Text & ""
            End If
            Dim cnxBuscar As New SqlConnection(cadena)
            Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
            cmdBuscar.Parameters.AddWithValue("@idMusicos", Session("dUsuario").Rows(0).item(0))
            Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
            Dim dt As New DataTable
            adaptadorBuscar.Fill(dt)
            gvMusicos.DataSource = dt
            gvMusicos.DataBind()
        End If

    End Sub
    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Response.Redirect("~/Contenidos/musico/Trabajos.aspx")
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
