<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="ComputadoraFinal.aspx.cs" Inherits="Web_Presentation.views.Formularios.ComputadoraFinal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h4>Inserta la computadora</h4>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Numero de inventario"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Numero de inventario" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="Numero de CPU"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Numero de CPU" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Identificador de CPU Genérico"></asp:Label>
                    <asp:TextBox ID="TextBox3" type="number" runat="server" placeholder="Identificador de CPU Genérico" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label4" runat="server" Text="Numero de CPU"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" placeholder="Numero de CPU" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Labe5" runat="server" Text="Identificador de teclado"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" placeholder="Identificador de teclado" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label6" runat="server" Text="Numero de Monitor"></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" placeholder="Numero de Monitor" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label7" runat="server" Text="Identificador de Monitor"></asp:Label>
                    <asp:TextBox ID="TextBox7" type="number" runat="server" placeholder="Identificador de Monitor" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label8" runat="server" Text="Numero de Mouse"></asp:Label>
                    <asp:TextBox ID="TextBox8" runat="server" placeholder="Numero de Mouse" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label9" runat="server" Text="Identificador de Mouse"></asp:Label>
                    <asp:TextBox ID="TextBox9" type="number" runat="server" placeholder="Identificador de Mouse" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label10" runat="server" Text="Estado"></asp:Label>
                    <asp:TextBox ID="TextBox10" runat="server" placeholder="Estado" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label11" runat="server" Text="imagen1"></asp:Label>
                    <asp:TextBox ID="TextBox11" runat="server" placeholder="imagen1" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label12" runat="server" Text="imagen2"></asp:Label>
                    <asp:TextBox ID="TextBox12" runat="server" placeholder="imagen2" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label13" runat="server" Text="imagen3"></asp:Label>
                    <asp:TextBox ID="TextBox13" runat="server" placeholder="imagen3" Width="725px"></asp:TextBox>
                </div>
            </div>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        </form>
    </div>
</asp:Content>
