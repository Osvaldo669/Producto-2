<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Teclado.aspx.cs" Inherits="Web_Presentation.views.Formularios.Teclado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta el teclado</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador del Teclado</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador del Teclado">
                </div>
            </div>
                <div class="form-group col-md-6">
                    <label for="inputState">Marca Teclado</label>
                    <select id="inputState" class="form-control">
                        <option selected>Elegir</option>
                        <option>Gear4music.</option>
                        <option>Casio.</option>
                        <option>Korg.</option>
                        <option>Roland.</option>
                        <option>Yamaha.</option>
                    </select>
                </div>
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Conector</label>
                    <input type="text" class="form-control" id="inlineForm" placeholder="Conector">
                </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
