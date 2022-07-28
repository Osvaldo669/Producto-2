<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Marca.aspx.cs" Inherits="Web_Presentation.views.Formularios.Marca" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta la Marca</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador de la Marca</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador de la Marca">
                </div>
            </div>
                <div class="form-group col-md-6">
                    <label for="inputState">Marca</label>
                    <select id="inputState" class="form-control">
                        <option selected>Elegir</option>
                        <option>...</option>
                    </select>
                </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Componente</label>
                    <input type="number" class="form-control" id="compu" placeholder="Componente">
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
