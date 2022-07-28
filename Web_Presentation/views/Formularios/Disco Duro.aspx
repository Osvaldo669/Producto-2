<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Disco Duro.aspx.cs" Inherits="Web_Presentation.views.Formularios.Disco_Duro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta el Disco duro</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador del Disco duro</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador del Disco duro">
                </div>
            </div>
            <div class="form-group col-md-6">
                <label for="inlineFormInput">Tipos de disco duro</label>
                <input type="text" class="form-control" id="TipoDisc" placeholder="Tipos de disco duro">
            </div>
            <div class="form-group col-md-6">
                <label for="inlineFormInput">Conector</label>
                <input type="text" class="form-control" id="inlineForm" placeholder="Conector">
            </div>
            <div class="form-group col-md-6">
                <label for="inlineFormInput">Capacidad de disco duro</label>
                <input type="text" class="form-control" id="capacidad" placeholder="Capacidad de disco duro">
            </div>
                <div class="form-group col-md-6">
                    <label for="inputState">Marcas de Discos duros</label>
                    <select id="inputState" class="form-control">
                        <option selected>Elegir</option>
                        <option>Seagate Barracuda.</option>
                        <option>Western Digital Blue.</option>
                        <option>Seagate Barracuda PRO.</option>
                        <option>Seagate FireCuda.</option>
                        <option>Western Digital Gold.</option>
                    </select>
                </div>
            <div class="form-group col-md-6">
                <label for="inlineFormInput">Extra</label>
                <input type="text" class="form-control" id="extra" placeholder="Extra">
            </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
