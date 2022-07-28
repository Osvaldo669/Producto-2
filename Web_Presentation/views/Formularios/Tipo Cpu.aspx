<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Tipo Cpu.aspx.cs" Inherits="Web_Presentation.views.Formularios.Tipo_Cpu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="margin-top:3%">
        <h4>Inserta el tipo de CPU</h4>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Identificador de tipo de CPU"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de tipo de CPU" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Tipo" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label3" runat="server" Text="Familia"></asp:Label>
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Familia" Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label4" runat="server" Text="Velocidad"></asp:Label>
                    <asp:TextBox ID="TextBox4" runat="server" placeholder="Velocidad" Width="725px"></asp:TextBox>
                </div>
            </div>
                <div class="form-group col-md-6">
                    <asp:Label ID="Label5" runat="server" Text="Extra"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" placeholder="Extra" Width="725px"></asp:TextBox>
                </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label6" runat="server" Text="Identificador de modelo de CPU"></asp:Label>
                    <asp:TextBox ID="TextBox6" type="number" runat="server" placeholder="Identificador de modelo de CPU" Width="725px"></asp:TextBox>
                </div>
            </div>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        </form>
    </div>
</asp:Content>
