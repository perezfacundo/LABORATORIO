Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class conexion
    Protected conn As New SqlConnection
    Event ErrorConexion(descripcion As String)

    Public Function fConectar(Optional CadenaConexion = Nothing)
        Dim cadena As String = ""

        If cadena = Nothing Then
            cadena = ConfigurationManager.ConnectionStrings("Laboratorio_Ies21ConnectionString").ConnectionString
        Else
            cadena = CadenaConexion
        End If
        Try
            conn = New SqlConnection(cadena)
            conn.Open()
            Return True
        Catch ex As Exception
            RaiseEvent ErrorConexion(ex.Message)
            Return False
        End Try
    End Function

    Public Function fDesconectar()
        Dim res As Boolean = True
        Try
            If conn.State = ConnectionState.Open Then
                conn.Close()
                res = True
            Else
                res = False
            End If
        Catch ex As Exception
            RaiseEvent ErrorConexion(ex.Message)
        End Try
        Return res
    End Function
End Class
