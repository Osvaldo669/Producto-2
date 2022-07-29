<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Disco_Duro.aspx.cs" Inherits="Web_Presentation.views.Formularios.Disco_Duro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta el Disco duro</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <asp:Label ID="Label1" runat="server" Text="Identificador Disco duro"></asp:Label>
                    <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Inserta el Identificador Disco duro " Width="725px"></asp:TextBox>
                </div>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label2" runat="server" Text="Tipos de disco duro"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <asp:Label ID="Label3" runat="server" Text="Conector"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="725px"></asp:DropDownList>
            </div>
            <div class="form-group col-md-6">
                <label for="inlineFormInput">Capacidad de disco duro</label>
                <input type="text" class="form-control" id="capacidad" placeholder="Capacidad de disco duro">
            </div>
                <div class="form-group col-md-6">
                <asp:Label ID="Label4" runat="server" Text="Marcas de discos duros"></asp:Label>
                <br />
                <asp:DropDownList ID="DropDownList3" runat="server" Height="35px" Width="725px"></asp:DropDownList>
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
