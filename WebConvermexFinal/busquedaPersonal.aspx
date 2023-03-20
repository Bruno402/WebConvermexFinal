<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="busquedaPersonal.aspx.cs" Inherits="WebConvermexFinal.busquedaPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/cssAdminRegistro.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="todos-elementos">
        <div class="formulario">
            <h2 class="form-titulo">BUSQUEDA DE EMPLEADOS</h2>
            <div class="contenedor-form">
                <asp:TextBox ID="TextBox1" class="input-100 inputs" runat="server" placeholder="Escribe el nombre a buscar"></asp:TextBox>
                <asp:Button ID="btnBuscarPersonal" class="btnCliente" runat="server" Text="Buscar Personal" OnClick="btnBuscarPersonal_Click"/>
                <input id="txtNombre" class="input-100 inputs" runat="server" placeholder="Nombre" readonly/>
                <input id="TxtApellidoP" class="input-100 inputs" runat="server" placeholder="Apellido Paterno" readonly/>
                <input id="TxtApellidoM" class="input-100 inputs" runat="server" placeholder="Apellido Materno" readonly/>
                <input id="txtEdad" class="input-100 inputs" runat="server" placeholder="Edad" readonly/>
                <input id="txtDireccion" class="input-100 inputs" runat="server" placeholder="Direccion" readonly/>
                <input id="txtFecha" class="input-48 inputs" runat="server" placeholder="Fecha de nacimiento" readonly/>
                <input id="txtNumTe" class="input-48 inputs" runat="server" placeholder="Numero de telefono" readonly/>
                <input id="txtCurp" class="input-48 inputs" runat="server" placeholder="CURP" readonly/>
                <input id="txtRfc" class="input-48 inputs" runat="server" placeholder="RFC" readonly/>
                <input id="txtNss" class="input-48 inputs" runat="server" placeholder="NSS" readonly/>
                <input id="txtFechaIn" class="input-48 inputs" runat="server" placeholder="Fecha de ingreso" readonly/>
                <input id="txtCapacitacion" class="input-100 inputs" runat="server" placeholder="Capacitacion" readonly/>
                <input id="txtIdioma" class="input-100 inputs" runat="server" placeholder="Idiomas" readonly/>
                <input id="txtSalario" class="input-100 inputs" runat="server" placeholder="Salario" readonly/>
                <input id="txtEstado" class="input-48 inputs" runat="server" placeholder="Estado Civil" readonly/>
                <input id="txtTipoSan" class="input-48 inputs" runat="server" placeholder="Tipo de sangre" readonly/>
                <input id="txtNivAca" class="input-48 inputs" runat="server" placeholder="Nivel Academico" readonly/>
            </div>
        </div>
    </div>
</asp:Content>
