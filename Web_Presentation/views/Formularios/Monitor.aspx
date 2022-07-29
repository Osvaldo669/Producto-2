<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Monitor.aspx.cs" Inherits="Web_Presentation.views.Formularios.Monitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-success">
            <h5 class="card-header">Inserta el monitor</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Identificador Monitor"></asp:Label>
                                <asp:TextBox ID="TextBox1" type="number" runat="server" placeholder="Inserta el Identificador Monitor" Width="725px"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label2" runat="server" Text="Marca monitor"></asp:Label>
                                <br />
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label3" runat="server" Text="Conector"></asp:Label>
                            <asp:TextBox ID="TextBox2" type="number" runat="server" placeholder="Inserta el conector" Width="725px"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <asp:Label ID="Label4" runat="server" Text="Tamaño"></asp:Label>
                            <br />
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="35px" Width="725px"></asp:DropDownList>
                        </div>
                        <br />
                        <asp:Button ID="Button1" runat="server" CssClass=" btn btn-success" Text="Guardar" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
