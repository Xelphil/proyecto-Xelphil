Public Class Principal
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("usuario") Is Nothing Then
            Response.Redirect("~/Login.aspx")
        Else
            Dim idUsuario = CType(Session("usuario"), DataTable).Rows(0)(0)
            Dim nombreUsuario = CType(Session("usuario"), DataTable).Rows(0)(1)
            Dim administrador = CType(Session("usuario"), DataTable).Rows(0)(2)
            Dim cliente = CType(Session("usuario"), DataTable).Rows(0)(3)
            Dim consultora = CType(Session("usuario"), DataTable).Rows(0)(4)
            ''MsgBox(idUsuario & "--" & nombreUsuario & "--" & administrador & "--" & cliente & "--" & consultora)
            'lbUsuario.Text = "Bienvenido, " & nombreUsuario
            'If administrador = True Then
            '    Session("rolAdmin") = True
            '    elementoUsuario.Visible = True
            '    elementoUsuarioConsultora.Visible = True
            '    elementoAcceso.Visible = True
            '    elementoExterna.Visible = True
            '    elementoClausula.Visible = True
            '    lbDatos.Visible = False
            'End If
            'If consultora = True Then
            '    Session("rolConsultora") = True
            '    obtenerConsultora(idUsuario)
            '    Dim sentencia As String = "select COUNT(*) from NotificacionesConsultora where Consultora=@Consultora and Leido=0"
            '    Dim ok = TienesMensajes(sentencia)

            '    If ok = True Then
            '        btnuenot.BackColor = Drawing.Color.Coral
            '    End If

            '    frame.Src = "~/cliente.aspx"
            '    elementoConsultora.Visible = False
            '    elementoUsuarioConsultora.Visible = True
            '    elementoExterna.Visible = True
            '    elementoClausula.Visible = True
            'End If
            'If cliente = True Then
            '    Session("rolCliente") = True
            '    obtenerCliente(idUsuario)

            '    Dim sentencia As String = "select COUNT(*) from NotificacionesClientes where Cliente=@Cliente and Consultora=@Consultora and Leido=0"
            '    Dim ok = TienesMensajes(sentencia)

            '    If ok = True Then
            '        btnuenot.BackColor = Drawing.Color.Coral
            '    End If

            '    frame.Src = "~/sede.aspx"
            '    elementoConsultora.Visible = False
            '    elementoCliente.Visible = False
            'End If
        End If
    End Sub

    Protected Sub btMusicos_Click(sender As Object, e As EventArgs) Handles btMusicos.Click
        Response.Redirect("~/Contenidos/Musicos.aspx")
    End Sub

    Protected Sub btInstrumentos_Click(sender As Object, e As EventArgs) Handles btInstrumentos.Click
        Response.Redirect("~/Contenidos/Instrumentos.aspx")
    End Sub

    Protected Sub btCatMus_Click(sender As Object, e As EventArgs) Handles btCatMus.Click
        Response.Redirect("~/Contenidos/CategoriaMusico.aspx")
    End Sub

    Protected Sub btCerrarSesion_Click(sender As Object, e As EventArgs) Handles btCerrarSesion.Click
        Session("usuario") = Nothing
        Response.Redirect("~/Login.aspx")
    End Sub
End Class