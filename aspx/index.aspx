<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="LABORATORIO.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            INGRESE LA FECHA A CONSULTAR<asp:TextBox ID="txtFecha" runat="server" placeholder="aaaa-mm-dd"></asp:TextBox> <br /> <br />
            <asp:Button ID="cmdConsultar" runat="server" Text="CONSULTAR" Width="127px" /> 
            <br /> <hr />
        </div>

        <div id="Mensaje" runat="server">

        </div>

        <div id="dgv" runat="server">

        </div>

    </form>
</body>
</html>
