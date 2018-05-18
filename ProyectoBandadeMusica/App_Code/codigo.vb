Imports System.Data
Imports System.Data.SqlClient
Public Class codigo

    Public Shared Function searchUsuario(ByVal usuario As String, ByVal clave As String) As Boolean
        Dim ok As Boolean = False
        Dim conexion As String = ConfigurationManager.ConnectionStrings("BandaDeMusicaConnectionString").ToString
        Dim cnx As New SqlConnection(conexion)
        Dim sentencia = "select top 1 id from Usuarios where usuario=@user and contraseña=@pass"
        Dim cmd As New SqlCommand(sentencia, cnx)
        cmd.Parameters.Add("@user", SqlDbType.NChar, 20).Value = usuario
        cmd.Parameters.Add("@pass", SqlDbType.NChar, 20).Value = clave
        Try
            cnx.Open()
            ok = cmd.ExecuteScalar ' Cualquier número distinto de cero se considera como True
        Catch ex As SystemException
        Finally
            cnx.Close()
            cnx.Dispose()
        End Try
        Return ok
    End Function

    Public Shared Sub Salir()
        FormsAuthentication.SignOut()
        FormsAuthentication.RedirectToLoginPage()
    End Sub

End Class
