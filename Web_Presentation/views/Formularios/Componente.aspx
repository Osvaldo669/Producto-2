<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Componente.aspx.cs" Inherits="Web_Presentation.views.Formularios.Componente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h4>Inserta el componente</h4>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Identificador de componente"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de componente" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="Componente"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Componente" Width="725px"></asp:TextBox>
                </div>
            </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Extra"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Extra" Width="725px"></asp:TextBox>
                </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
