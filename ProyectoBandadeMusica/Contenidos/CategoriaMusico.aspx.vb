Imports System.Data.SqlClient

Public Class Formulario_web3
    Inherits System.Web.UI.Page
    'Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    pnDatos.Enabled = False
    '    listarMusicos()
    '    btCrear.Enabled = True
    '    btModificar.Enabled = False
    '    btBorrar.Enabled = False
    'End Sub

    'Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
    '    If Session("modifica").ToString = False Then
    '        Dim cnxInsert As New SqlConnection(cadena)
    '        Dim sentenciaInsert As String = "insert into CategoriaMusico(sueldo,instrumento) values(@sueldo,@instrumento)"
    '        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
    '        cmdInsert.Parameters.AddWithValue("@sueldo", tbNombre.Text)
    '        cmdInsert.Parameters.AddWithValue("@instrumento", ddlCategoriaMusico.SelectedValue)
    '        Try
    '            cnxInsert.Open()
    '            If cnxInsert.State = Data.ConnectionState.Open Then
    '                cmdInsert.ExecuteNonQuery()
    '                cmdInsert.Parameters.Clear()
    '                LimpiarCampos()
    '            End If
    '        Catch ex As Exception
    '            Throw New Exception(ex.Message)
    '        Finally
    '            cnxInsert.Close()
    '            cnxInsert.Dispose()

    '            Response.Redirect("~/Contenidos/CategoriaMusico.aspx")
    '        End Try
    '    Else
    '        'update
    '        MsgBox(Session("modifica").ToString)
    '        MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
    '        Dim cnxInsert As New SqlConnection(cadena)
    '        Dim sentenciaInsert As String = "update CategoriaMusico set sueldo=@sueldo,instrumento=@instrumento where id=@id"
    '        Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
    '        cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
    '        cmdInsert.Parameters.AddWithValue("@sueldo", tbNombre.Text)
    '        cmdInsert.Parameters.AddWithValue("@instrumento", ddlCategoriaMusico.SelectedValue)
    '        Try
    '            cnxInsert.Open()
    '            If cnxInsert.State = Data.ConnectionState.Open Then
    '                cmdInsert.ExecuteNonQuery()
    '                cmdInsert.Parameters.Clear()

    '            End If
    '        Catch ex As Exception
    '            Throw New Exception(ex.Message)
    '        Finally
    '            cnxInsert.Close()
    '            cnxInsert.Dispose()
    '            Response.Redirect("~/Contenidos/CategoriaMusico.aspx")
    '        End Try
    '    End If
    'End Sub
    'Protected Sub LimpiarCampos()
    '    tbNombre.Text = ""

    '    ddlCategoriaMusico.SelectedIndex = -1
    'End Sub
    'Public Sub listarMusicos()
    '    Dim sentenciaBuscar As String = "SELECT CategoriaMusico.id, CategoriaMusico.sueldo, CategoriaMusico.instrumento, Instrumentos.instrumento AS Expr1 FROM CategoriaMusico INNER JOIN Instrumentos ON CategoriaMusico.instrumento = Instrumentos.id"
    '    Dim cnxBuscar As New SqlConnection(cadena)
    '    Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
    '    'cmdBuscar.Parameters.AddWithValue("@Cliente", Session("cliente").ToString.Split("#")(0))
    '    Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
    '    Dim dt As New DataTable
    '    adaptadorBuscar.Fill(dt)
    '    gvMusicos.DataSource = dt
    '    gvMusicos.DataBind()
    'End Sub
    'Protected Sub btCancelar_Click(sender As Object, e As EventArgs) Handles btCancelar.Click
    '    LimpiarCampos()
    '    btCrear.Enabled = True
    '    btBorrar.Enabled = False
    '    btModificar.Enabled = False
    'End Sub

    'Protected Sub gvMusicos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvMusicos.SelectedIndexChanged
    '    'MsgBox(gvMusicos.SelectedDataKey.Value.ToString)
    '    btModificar.Enabled = True
    '    btBorrar.Enabled = True
    '    btCrear.Enabled = False

    '    Dim idCliente = gvMusicos.SelectedDataKey.Value
    '    Dim sentenciaCliente As String = "select * from CategoriaMusico where id=@id"
    '    Dim cnxCliente As New SqlConnection(cadena)
    '    Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
    '    cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
    '    Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
    '    Dim dt As New DataTable
    '    adaptadorCliente.Fill(dt)
    '    Dim fila As DataRow = dt.Rows(0)

    '    tbNombre.Text = fila("sueldo").ToString
    '    ddlCategoriaMusico.SelectedIndex = -1
    '    ddlCategoriaMusico.SelectedValue = fila("instrumento")

    'End Sub

    'Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
    '    Dim sentenciaBuscar As String = "SELECT CategoriaMusico.id, CategoriaMusico.sueldo, CategoriaMusico.instrumento, Instrumentos.instrumento AS Expr1 FROM CategoriaMusico INNER JOIN Instrumentos ON CategoriaMusico.instrumento = Instrumentos.id"
    '    If Not tbBuscar.Text = Nothing Then
    '        If ddlBuscar.SelectedValue = 1 Then
    '            sentenciaBuscar = "SELECT CategoriaMusico.id, CategoriaMusico.sueldo, CategoriaMusico.instrumento, Instrumentos.instrumento AS Expr1 FROM CategoriaMusico INNER JOIN Instrumentos ON CategoriaMusico.instrumento = Instrumentos.id where CategoriaMusico.sueldo like '%" & tbBuscar.Text & "%'"
    '        End If
    '        If ddlBuscar.SelectedValue = 2 Then
    '            sentenciaBuscar = "SELECT CategoriaMusico.id, CategoriaMusico.sueldo, CategoriaMusico.instrumento, Instrumentos.instrumento AS Expr1 FROM CategoriaMusico INNER JOIN Instrumentos ON CategoriaMusico.instrumento = Instrumentos.id where Instrumento.instrumento like '%" & tbBuscar.Text & "%'"
    '        End If
    '        Dim cnxBuscar As New SqlConnection(cadena)
    '        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
    '        Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
    '        Dim dt As New DataTable
    '        adaptadorBuscar.Fill(dt)
    '        gvMusicos.DataSource = dt
    '        gvMusicos.DataBind()
    '        LimpiarCampos()
    '    End If

    'End Sub

    'Protected Sub btBorrar_Click(sender As Object, e As EventArgs) Handles btBorrar.Click
    '    Dim cnxInsert As New SqlConnection(cadena)
    '    Dim sentenciaInsert As String = "delete from CategoriaMusico where id=@id"
    '    Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
    '    cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
    '    Try
    '        cnxInsert.Open()
    '        If cnxInsert.State = Data.ConnectionState.Open Then
    '            cmdInsert.ExecuteNonQuery()
    '            cmdInsert.Parameters.Clear()

    '        End If
    '    Catch ex As Exception
    '        Throw New Exception(ex.Message)
    '    Finally
    '        cnxInsert.Close()
    '        cnxInsert.Dispose()
    '        LimpiarCampos()
    '        Response.Redirect("~/Contenidos/CategoriaMusico.aspx")
    '    End Try
    'End Sub

    'Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click
    '    Session("modifica") = True
    '    pnDatos.Enabled = True
    '    MsgBox(Session("modifica").ToString)
    'End Sub

    'Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
    '    btModificar.Enabled = False
    '    btBorrar.Enabled = False
    '    pnDatos.Enabled = True
    '    LimpiarCampos()
    '    Session("modifica") = False
    'End Sub
End Class