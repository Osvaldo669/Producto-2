<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Gabinete.aspx.cs" Inherits="Web_Presentation.views.Formularios.Gabinete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta el Gabinete</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador del Gabinete</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador del Gabinete">
                </div>
            </div>
            <div class="form-group col-md-6">
                <label for="inlineFormInput">Modelo</label>
                <input type="text" class="form-control" id="GabiMode" placeholder="Modelo">
            </div>
                <div class="form-group col-md-6">
                    <label for="inputState">Marca Mouse</label>
                    <select id="inputState" class="form-control">
                        <option selected>Elegir</option>
                        <option>Corsair.</option>
                        <option>Cooler Master.</option>
                        <option>SilverStone.</option>
                        <option>NZXT.</option>
                        <option>Phanteks.</option>
                    </select>
                </div>
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Tipo forma</label>
                    <input type="text" class="form-control" id="inlineForm" placeholder="Tipo forma">
                </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
