Imports System.Data.SqlClient

Public Class Formulario_web1
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        'listarMusicos()
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
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
    'Public Sub listarMusicos()
    '    Dim sentenciaBuscar As String = ""
    '    Dim cnxBuscar As New SqlConnection(cadena)
    '    Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
    '    'cmdBuscar.Parameters.AddWithValue("@Cliente", Session("cliente").ToString.Split("#")(0))
    '    Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
    '    Dim dt As New DataTable
    '    adaptadorBuscar.Fill(dt)
    '    gvMusicos.DataSource = dt
    '    gvMusicos.DataBind()
    'End Sub
    Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
        LimpiarCampos()
    End Sub

    Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
        MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select Musicos.id,Musicos.nombre,Musicos.apellidos,Musicos.direccion,Musicos.ciudad,Musicos.coche,Musicos.disponibilidad,Musicos.categoriamusico,Instrumentos.instrumento from Musicos join CategoriaMusico on Musicos.categoriamusico=CategoriaMusico.id join Instrumentos on CategoriaMusico.instrumento=Instrumentos.id"
        If ddlBuscar.SelectedValue = 1 Then
            sentenciaBuscar = sentenciaBuscar + "where nombre like '%" & tbBuscar.Text & "%'"
        End If
        If ddlBuscar.SelectedValue = 2 Then
            sentenciaBuscar = sentenciaBuscar + "where coche like '%" & tbBuscar.Text & "%'"
        End If
        If ddlBuscar.SelectedValue = 3 Then
            sentenciaBuscar = sentenciaBuscar + "where disponibilidad like '%" & tbBuscar.Text & "%'"
        End If
        If ddlBuscar.SelectedValue = 4 Then
            sentenciaBuscar = sentenciaBuscar + "where categoriamusico like '%" & tbBuscar.Text & "%'"
        End If

        Dim cnxBuscar As New SqlConnection(cadena)
        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
        cmdBuscar.Parameters.AddWithValue("@Cliente", Session("cliente").ToString.Split("#")(0))
        Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
        Dim dt As New DataTable
        adaptadorBuscar.Fill(dt)
        gvMusicos.DataSource = dt
        gvMusicos.DataBind()
        LimpiarCampos()
    End Sub
End Class