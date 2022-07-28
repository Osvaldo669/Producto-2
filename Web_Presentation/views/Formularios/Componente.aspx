<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Componente.aspx.cs" Inherits="Web_Presentation.views.Formularios.Componente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta el componente</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador de componente</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador de componente">
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Componente</label>
                    <input type="text" class="form-control" id="compu" placeholder="Componente">
                </div>
            </div>
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Extra</label>
                    <input type="text" class="form-control" id="inlineForm" placeholder="Extra">
                </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
