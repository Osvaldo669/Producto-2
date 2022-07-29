<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="ComputadoraFinal.aspx.cs" Inherits="Web_Presentation.views.Formularios.ComputadoraFinal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta la computadora</h5>
            <div class="card-body">
                <div class="justify-content-center">
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
                                <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label11" runat="server" Text="imagen1"></asp:Label>
                                <asp:Image ID="Image1" runat="server" />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label12" runat="server" Text="imagen2"></asp:Label>
                                <asp:Image ID="Image2" runat="server" />
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label13" runat="server" Text="imagen3"></asp:Label>
                                <asp:Image ID="Image3" runat="server" />
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
