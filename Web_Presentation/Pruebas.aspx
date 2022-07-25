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

            <%--<asp:Label ID="Label3" runat="server" Text="Id_mouse"></asp:Label>
            <asp:TextBox ID="id_mouse" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="f_marcamouse"></asp:Label>
            <asp:TextBox ID="marcamouse" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="conector"></asp:Label>
            <asp:TextBox ID="conector" runat="server"></asp:TextBox>
            <br />--%>
            <input id="id_mouse" class="input" type="number" runat="server" placeholder="Id_mouse"  />
            <br />
            <input id="marcamouse" class="input" type="text" runat="server" placeholder="Marca Mouse"  />
            <br />
            <input id="conector" class="input" type="text" runat="server" placeholder="Conector"  />
            <asp:Button ID="Button2" runat="server" Text="Insertar" OnClick="Button2_Click" />
        </div>
    </form>
</body>
</html>

