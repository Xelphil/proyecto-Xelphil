Imports System.Data.SqlClient

Public Class Formulario_web7
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"
    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("usuario") Is Nothing Then
            MsgBox(Session("usuario").ToString.Count)
            'Response.Redirect("~/Login.aspx")
        Else
            Dim idUsuario = CType(Session("usuario"), DataTable).Rows(0)(0)
            Dim nombreUsuario = CType(Session("usuario"), DataTable).Rows(0)(1)
            Dim passusuario = CType(Session("usuario"), DataTable).Rows(0)(2)
            Dim admin = CType(Session("usuario"), DataTable).Rows(0)(3)
            Dim idmusicoasociado = CType(Session("usuario"), DataTable).Rows(0)(4)
            ''MsgBox(idUsuario & "--" & nombreUsuario & "--" & administrador & "--" & cliente & "--" & consultora)
            'lbUsuario.Text = "Bienvenido, " & nombreUsuario
            If admin = True Then
                Session("rolAdmin") = True
                Session("DatosUsuario") = idUsuario & "#" & nombreUsuario & "#" & passusuario & "#" & idmusicoasociado
                'elementoUsuario.Visible = True
                'elementoUsuarioConsultora.Visible = True
                'elementoAcceso.Visible = True
                'elementoExterna.Visible = True
                'elementoClausula.Visible = True
                'lbDatos.Visible = False
            End If
            If admin = False Then
                Session("rolAdmin") = False
                Session("DatosUsuario") = idUsuario & "#" & nombreUsuario & "#" & passusuario & "#" & idmusicoasociado
                'obtenerConsultora(idUsuario)
                'Dim sentencia As String = "select COUNT(*) from NotificacionesConsultora where Consultora=@Consultora and Leido=0"
                'Dim ok = TienesMensajes(sentencia)

                'If ok = True Then
                '    btnuenot.BackColor = Drawing.Color.Coral
                'End If

                'frame.Src = "~/cliente.aspx"
                'elementoConsultora.Visible = False
                'elementoUsuarioConsultora.Visible = True
                'elementoExterna.Visible = True
                'elementoClausula.Visible = True
            End If
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
End Class