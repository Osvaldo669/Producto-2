<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Mouse.aspx.cs" Inherits="Web_Presentation.views.Formularios.Mouse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador del Mouse</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador del Mouse">
                </div>
            </div>
                <div class="form-group col-md-6">
                    <label for="inputState">Marca Mouse</label>
                    <select id="inputState" class="form-control">
                        <option selected>Elegir</option>
                        <option>Logitech G502 Hero.</option>
                        <option>Steel Series Sensei 310.</option>
                        <option>Logitech G305 Lightspeed. </option>
                        <option>Razer Deathadder V2.</option>
                        <option>Corsair M65.</option>
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
