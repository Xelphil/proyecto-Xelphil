Imports System.Data.SqlClient

Public Class Formulario_web14
    Inherits System.Web.UI.Page
    Dim cadena As String = "Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;"

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("usuario") Is Nothing Then
            Response.Redirect("~/Inicio.aspx")
        Else
            If Session("rolAdmin") = True Then
                MsgBox("admin")
                MsgBox(Session("DatosUsuario"))
            Else
                'MsgBox("user")
                Response.Redirect("~/Contenidos/Principal.aspx")
            End If
        End If
        'pnDatos.Enabled = False
        'listarMusicos()
        'btCrear.Enabled = True
        'btModificar.Enabled = False
        'btBorrar.Enabled = False
    End Sub
End Class