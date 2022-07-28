<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Modelo CPU.aspx.cs" Inherits="Web_Presentation.views.Formularios.Modelo_CPU" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h4>Inserta el Modelo de CPU</h4>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Identificador de modelo de CPU"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de modelo de CPU" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Modelo" Width="725px"></asp:TextBox>
                </div>
            </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Marca"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
