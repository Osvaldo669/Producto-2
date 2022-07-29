<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Teclado.aspx.cs" Inherits="Web_Presentation.views.Formularios.Teclado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta el teclado</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Identificador Teclado"></asp:Label>
                                <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador Teclado" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Marca Teclado"></asp:Label>
                                <br />
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label3" runat="server" Text="Conector"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Conector" Width="725px"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" CssClass=" btn btn-success" Text="Guardar" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
