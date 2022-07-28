<%@ Page Title="" Language="C#" MasterPageFile="~/views/inventario.Master" AutoEventWireup="true" CodeBehind="Monitor.aspx.cs" Inherits="Web_Presentation.views.Formularios.Monitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top:3%">
        <h5>Inserta el Monitor</h5>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Identificador del Monitor</label>
                    <input type="number" class="form-control" id="inlineFormInput" placeholder="Identificador del Monitor">
                </div>
            </div>
                <div class="form-group col-md-6">
                    <label for="inputState">Marca Monitor</label>
                    <select id="inputState" class="form-control">
                        <option selected>Elegir</option>
                        <option>Asus</option>
                        <option>Acer</option>
                        <option>Benq</option>
                        <option>AOC</option>
                        <option>Samsung</option>
                    </select>
                </div>
                <div class="form-group col-md-6">
                    <label for="inlineFormInput">Conector</label>
                    <input type="text" class="form-control" id="conectormonitor" placeholder="Conector">
                </div>
               <div class="form-group col-md-6">
                    <label for="inlineFormInput">Tamaño</label>
                    <input type="text" class="form-control" id="tamañoCone" placeholder="Tamaño">
                </div>
            <br/>
            <button type="submit" class="btn btn-primary">Guardar</button>
        </form>
    </div>
</asp:Content>
