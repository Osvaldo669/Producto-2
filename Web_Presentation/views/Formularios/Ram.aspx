<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Ram.aspx.cs" Inherits="Web_Presentation.views.Formularios.Ram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h4>Inserta la memoria RAM</h4>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Identificador de la memoria RAM"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de tipo de RAM" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="Capacidad"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Capacidad" Width="725px"></asp:TextBox>
                </div>
            </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Velocidad"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Velocidad" Width="725px"></asp:TextBox>
                </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label4" runat="server" Text="tipo RAM"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" placeholder="tipo RAM" Width="725px"></asp:TextBox>
                </div>
            </div>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        </form>
    </div>
</asp:Content>
