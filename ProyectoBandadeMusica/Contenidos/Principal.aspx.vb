Imports System.Data.SqlClient

Public Class Formulario_web7
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("usuario") Is Nothing Then
            'MsgBox(Session("usuario").ToString.Count)
            Response.Redirect("~/Inicio.aspx")
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

            End If
            If admin = False Then
                Session("rolAdmin") = False
                Session("DatosUsuario") = idUsuario & "#" & nombreUsuario & "#" & passusuario & "#" & idmusicoasociado
            End If
        End If
    End Sub
End Class