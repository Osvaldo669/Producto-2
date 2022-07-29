<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="CPU_Generico.aspx.cs" Inherits="Web_Presentation.views.Formularios.CPU_Generico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta el CPU Genérico</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Identificador de CPU"></asp:Label>
                                <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de CPU" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Identificador de tipo de CPU"></asp:Label>
                                <asp:TextBox ID="TextBox2" type="number" runat="server" placeholder="Identificador de tipo de CPU" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label3" runat="server" Text="Marca"></asp:Label>
                                <br />
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label4" runat="server" Text="Modelo"></asp:Label>
                                <asp:TextBox ID="TextBox4" runat="server" placeholder="Modelo" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label5" runat="server" Text="Descripción"></asp:Label>
                                <asp:TextBox ID="TextBox5" runat="server" placeholder="Descripción" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="Tipo RAM"></asp:Label>
                                <asp:TextBox ID="TextBox6" type="number" runat="server" placeholder="Tipo RAM" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label7" runat="server" Text="Identificador de Gabinete"></asp:Label>
                                <asp:TextBox ID="TextBox7" type="number" runat="server" placeholder="Identificador de Gabinete" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label8" runat="server" Text="Imagen"></asp:Label>
                                <asp:TextBox ID="TextBox8" runat="server" placeholder="Imagen" Width="725px"></asp:TextBox>
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
