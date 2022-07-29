<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Actualizacion.aspx.cs" Inherits="Web_Presentation.views.Formularios.Actualizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta la actualización</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Identificador de actualización"></asp:Label>
                                <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de actualización" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Numero de inventario"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="Numero de inventario" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Numero de serie"></asp:Label>
                                <asp:TextBox ID="TextBox3" runat="server" placeholder="Numero de serie" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label4" runat="server" Text="Descripción"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" placeholder="Descripción" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label5" runat="server" Text="Fecha"></asp:Label>
                                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                            </div>
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Guardar" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
