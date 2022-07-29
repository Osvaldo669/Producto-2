<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Tipo_Ram.aspx.cs" Inherits="Web_Presentation.views.Formularios.Tipo_Ram" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta el tipo de RAM</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Identificador de tipo de RAM"></asp:Label>
                                <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Identificador de tipo de RAM" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Tipo"></asp:Label>
                                <asp:TextBox ID="TextBox2" runat="server" placeholder="Tipo" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label3" runat="server" Text="Extra"></asp:Label>
                            <asp:TextBox ID="TextBox3" runat="server" placeholder="Extra" Width="725px"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Guardar" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
