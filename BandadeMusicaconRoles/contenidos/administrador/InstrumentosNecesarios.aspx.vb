﻿
Imports System.Data
Imports System.Data.SqlClient

Partial Class contenidos_administrador_InstrumentosNecesarios
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnDatos.Enabled = False
        listarMusicos()
        btCrear.Enabled = True
        btModificar.Enabled = False
        btBorrar.Enabled = False
        tbCodCat.Text = Session("IdCategoriaTrabajo")
    End Sub

    Protected Sub btGuardar_Click(sender As Object, e As EventArgs) Handles btGuardar.Click
        If Session("modifica").ToString = False Then
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "insert into InstrumentosNecesarios(idcategoriatrabajo,cantidad,tipoinstrumento) values(@idcategoriatrabajo,@cantidad,@tipoinstrumento)"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@idcategoriatrabajo", tbCodCat.Text)
            cmdInsert.Parameters.AddWithValue("@cantidad", tbCantidadInstrumentos.Text)
            cmdInsert.Parameters.AddWithValue("@tipoinstrumento", ddlTipoIntru.SelectedValue)
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

                Response.Redirect("~/Contenidos/administrador/InstrumentosNecesarios.aspx")
            End Try
        Else
            Dim cnxInsert As New SqlConnection(cadena)
            Dim sentenciaInsert As String = "update InstrumentosNecesarios set idcategoriatrabajo=@idcategoriatrabajo,cantidad=@cantidad,tipoinstrumento=@tipoinstrumento where id=@id"
            Dim cmdInsert As New SqlCommand(sentenciaInsert, cnxInsert)
            cmdInsert.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value.ToString)
            cmdInsert.Parameters.AddWithValue("@idcategoriatrabajo", tbCodCat.Text)
            cmdInsert.Parameters.AddWithValue("@cantidad", tbCantidadInstrumentos.Text)
            cmdInsert.Parameters.AddWithValue("@tipoinstrumento", ddlTipoIntru.SelectedValue)
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
                Response.Redirect("~/Contenidos/administrador/InstrumentosNecesarios.aspx")
            End Try
        End If
    End Sub
    Protected Sub LimpiarCampos()
        tbCodCat.Text = ""
        tbCantidadInstrumentos.Text = ""
        ddlTipoIntru.SelectedIndex = -1
    End Sub
    Public Sub listarMusicos()
        Dim sentenciaBuscar As String = "select InstrumentosNecesarios.id,InstrumentosNecesarios.idcategoriatrabajo,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where idcategoriatrabajo=@id"
        Dim cnxBuscar As New SqlConnection(cadena)
        Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
        cmdBuscar.Parameters.AddWithValue("@id", Session("IdCategoriaTrabajo"))
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
        Dim sentenciaCliente As String = "select InstrumentosNecesarios.id,InstrumentosNecesarios.idcategoriatrabajo,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where InstrumentosNecesarios.idcategoriatrabajo=@idcategoria and InstrumentosNecesarios.id=@id"
        Dim cnxCliente As New SqlConnection(cadena)
        Dim cmdCliente As New SqlCommand(sentenciaCliente, cnxCliente)
        cmdCliente.Parameters.AddWithValue("@idcategoria", tbCodCat.Text)
        cmdCliente.Parameters.AddWithValue("@id", gvMusicos.SelectedDataKey.Value)
        Dim adaptadorCliente As New SqlDataAdapter(cmdCliente)
        Dim dt As New DataTable
        adaptadorCliente.Fill(dt)
        Dim fila As DataRow = dt.Rows(0)
        tbCodCat.Text = fila("idcategoriatrabajo").ToString
        tbCantidadInstrumentos.Text = fila("cantidad").ToString
        ddlTipoIntru.SelectedIndex = -1
        ddlTipoIntru.Items.FindByText(fila("instrumento").ToString).Selected = True
    End Sub

    Protected Sub btBorrar_Click(sender As Object, e As EventArgs) Handles btBorrar.Click
        Dim cnxInsert As New SqlConnection(cadena)
        Dim sentenciaInsert As String = "delete from InstrumentosNecesarios where id=@id"
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
            Response.Redirect("~/Contenidos/administrador/InstrumentosNecesarios.aspx")
        End Try
    End Sub

    Protected Sub btModificar_Click(sender As Object, e As EventArgs) Handles btModificar.Click
        Session("modifica") = True
        pnDatos.Enabled = True
        btCrear.Enabled = False
    End Sub

    Protected Sub btCrear_Click(sender As Object, e As EventArgs) Handles btCrear.Click
        btModificar.Enabled = False
        btBorrar.Enabled = False
        pnDatos.Enabled = True
        LimpiarCampos()
        Session("modifica") = False
        tbCodCat.Text = Session("IdCategoriaTrabajo")
    End Sub

    Protected Sub btBusqueda_Click(sender As Object, e As EventArgs) Handles btBusqueda.Click
        Dim sentenciaBuscar As String = "select InstrumentosNecesarios.id,InstrumentosNecesarios.idcategoriatrabajo,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where idcategoriatrabajo=@id"
        If Not tbBuscar.Text = Nothing Then
            If ddlBuscar.SelectedValue = 1 Then
                sentenciaBuscar = "select CategoriaTrabajo.id,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where idcategoriatrabajo=@id and CategoriaTrabajo.nombre like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 2 Then
                sentenciaBuscar = "select CategoriaTrabajo.id,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where idcategoriatrabajo=@id and CategoriaTrabajo.precio like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 3 Then
                sentenciaBuscar = "select CategoriaTrabajo.id,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where idcategoriatrabajo=@id and InstrumentosNecesarios.cantidad like '%" & tbBuscar.Text & "%'"
            End If
            If ddlBuscar.SelectedValue = 4 Then
                sentenciaBuscar = "select CategoriaTrabajo.id,CategoriaTrabajo.nombre,CategoriaTrabajo.precio,InstrumentosNecesarios.cantidad,Instrumentos.instrumento from CategoriaTrabajo join InstrumentosNecesarios on CategoriaTrabajo.id=InstrumentosNecesarios.idcategoriatrabajo join Instrumentos on InstrumentosNecesarios.tipoinstrumento=Instrumentos.id where idcategoriatrabajo=@id and Instrumentos.instrumento like '%" & tbBuscar.Text & "%'"
            End If
            Dim cnxBuscar As New SqlConnection(cadena)
            Dim cmdBuscar As New SqlCommand(sentenciaBuscar, cnxBuscar)
            cmdBuscar.Parameters.AddWithValue("@id", tbCodCat.Text)
            Dim adaptadorBuscar As New SqlDataAdapter(cmdBuscar)
            Dim dt As New DataTable
            adaptadorBuscar.Fill(dt)
            gvMusicos.DataSource = dt
            gvMusicos.DataBind()
            LimpiarCampos()
        End If
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
