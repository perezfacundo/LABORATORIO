Imports System.Data.SqlClient

Public Class mantenimiento
    Inherits conexion
    Event ErrorMantenimiento(descripcion As String)
    Dim query As String = ""
    Dim stringHTML = ""

    Public Function fConsultarOrdenes(fecha As String)
        Dim orden As String = ""
        Dim paciente As String = ""
        Dim retiro As Boolean = 0

        query = "SELECT O.orden as orden, P.nombre as nombre, O.retiro as retiro	
                                FROM ordenes O
                             INNER JOIN Pacientes P on O.paciente = P.paciente
                            WHERE O.fecha =" & fecha

        Try
            fConectar()
            Dim cmd As New SqlCommand(query, conn)
            cmd.CommandType = CommandType.Text
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As DataTable = New DataTable()
            dt.Load(dr)

            stringHTML = "<table border=1><tbody><tr><th> ORDEN </th><th> PACIENTE </th><th> RESULTADO </th><th> DETALLE </th></tr>"

            For Each row As DataRow In dt.Rows
                orden = CStr(row("orden"))
                paciente = CStr(row("nombre"))
                retiro = row("retiro")
                stringHTML = stringHTML & "<tr>"
                stringHTML = stringHTML & "<td>" & orden & "</td>"
                stringHTML = stringHTML & "<td>" & paciente & "</td>"

                If retiro = False Then
                    stringHTML = stringHTML & "<td>" & "<a href=""actualizarOrden.aspx?paciente=" & paciente & "&fecha=" & fecha & "&orden=" & orden & """>RETIRAR</a>" & "</td>"
                Else
                    stringHTML = stringHTML & "<td>" & "<p>RETIRADO</p>" & "</td>"
                End If

                stringHTML = stringHTML & "<td>" & "<a href=""verPracticas.aspx?paciente=" & paciente & "&fecha=" & fecha & "&orden=" & orden & """>VISUALIZAR</a>" & "</td>"
                stringHTML = stringHTML & "</tr>"

            Next

            stringHTML = stringHTML & "</tbody></table>"
            Return stringHTML

        Catch ex As Exception
            RaiseEvent ErrorMantenimiento(ex.Message)
            Return Nothing
        Finally
            fDesconectar()
        End Try

    End Function

    Public Sub fActualizar(orden As String)
        query = "UPDATE ordenes SET retiro = 1 WHERE orden =" & orden

        Try
            fConectar()
            Dim cmd As New SqlCommand(query, conn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            RaiseEvent ErrorMantenimiento(ex.Message)

        Finally
            fDesconectar()
        End Try

    End Sub

    Public Function fConsultarPracticas(fecha As String, orden As String)

        Dim practica As String = ""
        Dim descripcion As String = ""

        query = "SELECT P.practica, N.nombre
	                FROM practicas P
		                INNER JOIN Nomenclador N ON P.practica = N.practica
	                WHERE P.orden =" & orden

        'Probar traer el nombre del paciente

        Try
            fConectar()
            Dim cmd As New SqlCommand(query, conn)
            cmd.CommandType = CommandType.Text
            Dim dr As SqlDataReader = cmd.ExecuteReader()
            Dim dt As DataTable = New DataTable()

            dt.Load(dr)

            stringHTML = "<table border=1><tbody><tr><th> PRACTICA </th><th> DESCRIPCION </th></tr>"

            For Each row As DataRow In dt.Rows
                practica = CStr(row("practica"))
                descripcion = CStr(row("nombre"))
                stringHTML = stringHTML & "<tr>"
                stringHTML = stringHTML & "<td>" & practica & "</td>"
                stringHTML = stringHTML & "<td>" & descripcion & "</td>"
                stringHTML = stringHTML & "</tr>"
            Next

            stringHTML = stringHTML & "</tbody></table><br/><hr/><br/>"
            stringHTML = stringHTML & "<a href=""index.aspx?fecha=" & fecha & "&orden=" & orden & """>VOLVER AL INICIO</a>"

            Return stringHTML

        Catch ex As Exception
            RaiseEvent ErrorMantenimiento(ex.Message)
            Return Nothing
        Finally
            fDesconectar()
        End Try

    End Function
End Class