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
                                <asp:Label ID="Label2" runat="server" Text="Identificador de tipo de CPU"></asp:Label>
                                <asp:DropDownList ID="tipo_DDL" runat="server" Height="35px" Width="100%"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label4" runat="server" Text="Modelo"></asp:Label>
                                <asp:TextBox ID="modelo_TB" runat="server" placeholder="Modelo" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label5" runat="server" Text="Descripción"></asp:Label>
                                <asp:TextBox ID="desc_TB" runat="server" placeholder="Descripción" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label6" runat="server" Text="Tipo RAM"></asp:Label>
                                <asp:DropDownList ID="ram_DDL" runat="server" Height="35px" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label7" runat="server" Text="Identificador de Gabinete"></asp:Label>
                                <asp:DropDownList ID="gabinete_DDL" runat="server" Height="35px" Width="100%"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label8" runat="server" Text="Imagen"></asp:Label>
                                <asp:FileUpload ID="imagen" Width="50%"  runat="server" />
                            </div>
                        </div>
                         <br />
                            <div class="form-row">
                                 <div class="alert alert-danger  d-flex align-items-center" runat="server" id="Alerta" role="alert">
                                      <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-exclamation-triangle-fill flex-shrink-0 me-2" viewBox="0 0 16 16" role="img" aria-label="Warning:">
                                        <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                                      </svg>
                                      <div>
                                        Datos Incorrectos
                                  </div>
                            </div> 
                        <br />
                        <asp:Button ID="guardar" OnClick="guardar_Click" runat="server" Text="Guardar" />
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
