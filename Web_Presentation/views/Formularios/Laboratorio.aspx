<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Laboratorio.aspx.cs" Inherits="Web_Presentation.views.Formularios.Laboratorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container" style="margin-top:3%">
        <h4>Inserta el nombre de laboratorio</h4>
        <form>
             <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Nombre de laboratorio"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="text" runat="server" placeholder="Nombre de laboratorio" Width="725px"></asp:TextBox>
                </div>
            </div>   
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Guardar" />
        </form>
    </div>
</asp:Content>
