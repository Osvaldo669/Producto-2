<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="Web_Presentation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click"/><asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <asp:GridView runat="server" ID="GridView1"></asp:GridView>
        </div>
        <div>
            <asp:Button ID="Button2" runat="server" Text="eliminar" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>

