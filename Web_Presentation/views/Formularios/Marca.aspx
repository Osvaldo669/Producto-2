﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Marca.aspx.cs" Inherits="Web_Presentation.views.Formularios.Marca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta la Marca</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Identificador de la marca"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Inserta el Identificador de la marca " Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label2" runat="server" Text="Tipos de disco duro"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label3" runat="server" Text="Componente"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="725px"></asp:DropDownList>
            </div>
                <div class="form-group col-md-6">
                <asp:Label ID="Label5" runat="server" Text="Extra"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" placeholder="Inserta extra" Width="725px"></asp:TextBox>
            </div>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        </form>
    </div>
</asp:Content>
