<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Actualizacion.aspx.cs" Inherits="Web_Presentation.views.Actualizaciones.Actualizacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:5%">
        <div class="card alert alert-secondary">
          <h5 class="card-header">Buscar Computadora(Actualizaciones)</h5>
          <div class="card-body">
            <h6 class="card-title">Introduzca el numero de inventario:
            </h6>
            <p class="card-text">
                <asp:TextBox ID="Buscar_Computadora_textbox" runat="server"></asp:TextBox>
            </p>
              <div class="alert alert-danger  d-flex align-items-center" runat="server" id="Alerta" role="alert">
                  <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="currentColor" class="bi bi-exclamation-triangle-fill flex-shrink-0 me-2" viewBox="0 0 16 16" role="img" aria-label="Warning:">
                    <path d="M8.982 1.566a1.13 1.13 0 0 0-1.96 0L.165 13.233c-.457.778.091 1.767.98 1.767h13.713c.889 0 1.438-.99.98-1.767L8.982 1.566zM8 5c.535 0 .954.462.9.995l-.35 3.507a.552.552 0 0 1-1.1 0L7.1 5.995A.905.905 0 0 1 8 5zm.002 6a1 1 0 1 1 0 2 1 1 0 0 1 0-2z"/>
                  </svg>
                  <div>
                    Llene correctamente el textbox
                  </div>
               </div>
            <asp:Button ID="BuscarComputadora_Btn" OnClick="BuscarComputadora_Btn_Click" runat="server" CssClass=" btn btn-success" Text="Buscar" />

          </div>
        </div>
    </div>
    <div class="container" runat="server" style="margin-bottom:10%" id="informacionPC">
        <div class="row text-center">
            <h3>Actualizaciones</h3>
        </div>
        <div class="row text-center">
            <div class="col">
                <h4><asp:Label ID="Label1" runat="server" Text=""></asp:Label></h4>
            </div>
            <div class="col">
                <h6><asp:Label ID="Label2" runat="server" Text=""></asp:Label></h6>
            </div>
        </div>
        <div class="row content-center">
            <img runat="server" id="imagen_PC" class="img-fluid rounded-start" alt="...">
        </div>
        <div class="row ">
                <asp:GridView ID="GridView1" AutoGenerateColumns="false" class="table" runat="server">
                    <Columns>
                        <asp:BoundField DataField="N° de Serie" HeaderText="N° de Serie" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                    </Columns>
                </asp:GridView>
        </div>
    </div>
</asp:Content>
