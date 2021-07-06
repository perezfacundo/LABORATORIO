Public Class actualizarOrden
    Inherits System.Web.UI.Page

    Dim objMantenimiento As New mantenimiento
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim orden As Integer = Request.QueryString("orden")
        Dim fecha As String = Request.QueryString("fecha")
        Dim paciente As String = Request.QueryString("paciente")
        objMantenimiento.fActualizar(orden)

        Dim url As String = "index.aspx" & "?act=1&" & "orden=" & orden & "&fecha=" & fecha & "&paciente=" & paciente
        Response.Redirect(url)
    End Sub
End Class