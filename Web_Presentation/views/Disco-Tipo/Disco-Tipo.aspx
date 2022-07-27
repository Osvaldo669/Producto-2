<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Disco-Tipo.aspx.cs" Inherits="Web_Presentation.views.Disco_Tipo.Disco_Tipo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:5%">
        <div class="card alert alert-secondary">
          <h5 class="card-header">Filtrar por Tipo de disco duro y ubicacion</h5>
          <div class="card-body">
            <h6 class="card-title">
                    Seleccione un laboratorio de la siguiente lista: 
            </h6>
            <p class="card-text">
               Lista de Laboratorios: <asp:DropDownList ID="Laboratorios"  runat="server"></asp:DropDownList>
               Tipos de Disco: <asp:DropDownList ID="Tipos_Discos"  runat="server"></asp:DropDownList>
            </p>
              <div class="alert alert-danger  d-flex align-items-center" runat="server" id="Alerta" role="alert">
                  <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-exclamation-triangle-fill flex-shrink-0 me-2" viewBox="0 0 16 16" role="img" aria-label="Warning:">
                    <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                  </svg>
                  <div>
                    Seleccione datos correctamente!!!
                  </div>
               </div>
            <asp:Button ID="Buscar" OnClick="Buscar_Click" runat="server" CssClass=" btn btn-success" Text="Buscar" />

          </div>
        </div>
        <div class="container">
            <div class="row ">
                <asp:GridView ID="GridView1" class="table" runat="server"></asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
