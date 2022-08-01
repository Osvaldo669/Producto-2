﻿<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Laboratorio.aspx.cs" Inherits="Web_Presentation.views.Formularios.Laboratorio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 3%">
        <div class="card alert alert-danger">
            <h5 class="card-header">Inserta el nombre de laboratorio</h5>
            <div class="card-body">
                <div class="justify-content-center">
                    <form>
                       <h4><asp:Label ID="Especial" runat="server" Text=""> </asp:Label></h4>
                        <div class="form-row">
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label1" runat="server" Text="Nombre de laboratorio"></asp:Label>
                                <asp:TextBox ID="laboratorio_text" CssClass="form-control" type="text" runat="server" placeholder="Nombre de laboratorio" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                            <div class="form-row">
                                 <div class="alert alert-danger  d-flex align-items-center" runat="server" id="Alerta" role="alert">
                                      <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-exclamation-triangle-fill flex-shrink-0 me-2" viewBox="0 0 16 16" role="img" aria-label="Warning:">
                                        <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                                      </svg>
                                      <div>
                                        Datos Incompletos
                                  </div>
                            </div>
                        <br />
                        <asp:Button ID="guardar" CssClass="btn btn-success" OnClick="guardar_Click" runat="server" Text="Guardar" />
                                <div class="form-row" runat="server">
                            <h5>Actualizar Item</h5>
                            <div class="form-group col-md-6">
                                <asp:Label ID="Label14" runat="server" Text="Seleccione un ID: "></asp:Label>
                                <asp:DropDownList ID="actualizar" CssClass="btn btn-dark dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="actualizar_SelectedIndexChanged" Width="100%" runat="server"></asp:DropDownList>
                                <br />
                                <div class="row" style="margin-top:3%">
                                    <asp:Button ID="actualizar_datos" CssClass="btn-warning btn" OnClick="actualizar_datos_Click" runat="server" Text="Actualizar Datos" />
                                </div>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
