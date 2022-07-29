<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Gabinete.aspx.cs" Inherits="Web_Presentation.views.Formularios.Gabinete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta el Gabinete</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Identificador de Gabinete"></asp:Label>
                                <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Inserta el Identificador de Gabinete" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label2" runat="server" Text="Modelo"></asp:Label>
                            <br />
                            <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label3" runat="server" Text="Marca Mouse"></asp:Label>
                            <br />
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label4" runat="server" Text="Tipo forma"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" placeholder="Inserta el Tipo forma" Width="725px"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" CssClass=" btn btn-success" Text="Guardar" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
