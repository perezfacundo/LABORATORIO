Public Class index
    Inherits System.Web.UI.Page

    Dim objMantenimiento As New mantenimiento

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("act") = 1 Then
            Mensaje.InnerText = "El informe del paciente " & Request.QueryString("paciente") & " ha sido retirado."
        End If

        Dim stringHTML As String = objMantenimiento.fConsultarOrdenes(Request.QueryString("fecha"))
        dgv.InnerHtml = stringHTML

    End Sub

    Protected Sub cmdConsultar_Click(sender As Object, e As EventArgs) Handles cmdConsultar.Click
        Dim fecha As String = "'" & txtFecha.Text & "'"
        Dim stringHTML As String = objMantenimiento.fConsultarOrdenes(fecha)
        dgv.InnerHtml = stringHTML
    End Sub

End Class