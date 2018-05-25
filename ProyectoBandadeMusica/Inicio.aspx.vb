Imports System.Data.SqlClient

Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CType(oLogin.FindControl("UserName"), TextBox).Attributes.Add("placeholder", "Usuario")
        CType(oLogin.FindControl("Password"), TextBox).Attributes.Add("placeholder", "Contraseña")
    End Sub

    Private Sub oLogin_Authenticate(sender As Object, e As AuthenticateEventArgs) Handles oLogin.Authenticate
        Session("usuario") = okUsuario(oLogin.UserName, oLogin.Password)
        'MsgBox(Session("usuario").Rows.Count)
        If Session("usuario").Rows.Count = 1 Then
            ' Response.Redirect("~/Contenidos/Principal.aspx")
            FormsAuthentication.RedirectFromLoginPage(oLogin.UserName, False)
        End If
    End Sub
    Public Function okUsuario(ByVal usuario As String, ByVal contraseña As String)
        Dim dt As New DataTable
        Dim cnx As New SqlConnection("Data Source=(local);Initial Catalog=BandaDeMusica;Integrated Security=SSPI;")
        Dim sentencia As String = "select * from Usuarios where usuario = @NombreUsuario and contraseña = @Password"
        Dim cmd As New SqlCommand(sentencia, cnx)
        cmd.Parameters.AddWithValue("@NombreUsuario", usuario)
        Dim wrapper As New EncriptarPass("")
        ' Dim password = wrapper.EncryptData(contraseña)
        'cmd.Parameters.AddWithValue("@Password", password)
        cmd.Parameters.AddWithValue("@Password", contraseña)
        Try
            Dim adt As New SqlDataAdapter(cmd)
            adt.Fill(dt)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return dt
    End Function

    Protected Sub btVisitante_Click(sender As Object, e As EventArgs) Handles btVisitante.Click
        Session("visitante") = True
        'introducir datos
    End Sub
End Class