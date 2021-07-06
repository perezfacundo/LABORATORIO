Public Class verPracticas
    Inherits System.Web.UI.Page

    Dim objMantenimiento As New mantenimiento
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        paciente.InnerText = Request.QueryString("paciente")
        Dim fecha As String = Request.QueryString("fecha")
        Dim orden = Request.QueryString("orden")
        Dim stringHTML As String = objMantenimiento.fConsultarPracticas(fecha, orden)

        dgv.InnerHtml = stringHTML
    End Sub

End Class