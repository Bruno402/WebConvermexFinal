<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="altaPersonal.aspx.cs" Inherits="WebConvermexFinal.altaPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/cssAdminRegistro.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="todos-elementos">
        <div class="formulario">
            <h2 class="form-titulo">REGISTRA AL EMPLEADO</h2>
            <div class="contenedor-form">
                <asp:TextBox ID="TxtNombre" class="input-48 inputs" runat="server" placeholder="Nombre" MaxLength="20"></asp:TextBox>
                <asp:TextBox ID="TxtApellidoP" class="input-48 inputs" runat="server" placeholder="Apellido Paterno" MaxLength="20"></asp:TextBox>
                <asp:TextBox ID="TxtApellidoM" class="input-48 inputs" runat="server" placeholder="Apellido Materno" MaxLength="20"></asp:TextBox>
                <asp:TextBox ID="txtEdad" class="input-48 inputs" runat="server" placeholder="Edad" MaxLength="3"></asp:TextBox>
                <asp:TextBox ID="txtDireccion" class="input-100 inputs" runat="server" placeholder="Direccion" MaxLength="100"></asp:TextBox>
                <label id="lblFecha" class="input-48 inputs" runat="server" type="text">Fecha De Nacimiento</label>
                <input id="txtFecha" class="input-48 inputs" runat="server" placeholder="Fecha de nacimiento" type="date"/>
                <asp:TextBox ID="txtNumTe" class="input-48 inputs" runat="server" placeholder="Numero de telefono" MaxLength="30"></asp:TextBox>
                <asp:TextBox ID="txtCurp" class="input-48 inputs" runat="server" placeholder="CURP" MaxLength="18"></asp:TextBox>
                <asp:TextBox ID="txtRfc" class="input-48 inputs" runat="server" placeholder="RFC" MaxLength="12"></asp:TextBox>
                <asp:TextBox ID="txtNss" class="input-48 inputs" runat="server" placeholder="NSS" MaxLength="11"></asp:TextBox>
                <label id="lblFechaIn" class="input-48 inputs" runat="server" type="text">Fecha De Ingreso</label>
                <input id="txtFechaIn" class="input-48 inputs" runat="server" placeholder="Fecha de Ingreso" type="date"/>
                <asp:TextBox ID="txtCapacitacion" class="input-100 inputs" runat="server" placeholder="Capacitacion" MaxLength="100"></asp:TextBox>
                <asp:TextBox ID="txtIdioma" class="input-100 inputs" runat="server" placeholder="Idiomas" MaxLength="100"></asp:TextBox>
                <asp:TextBox ID="txtSalario" class="input-100 inputs" runat="server" placeholder="Salario" MaxLength="100"></asp:TextBox>
                <asp:Label ID="lbldrop" class="input-48 inputs" runat="server" Text="SELECCIONA UN ESTADO CIVIL:"></asp:Label>
                <asp:DropDownList ID="ddlEstadoCivil" class="input-48 inputs" runat="server" ></asp:DropDownList>
                <asp:Label ID="lblTipoSangre" class="input-48 inputs" runat="server" Text="SELECCIONA UN TIPO DE SANGRE:"></asp:Label>
                <asp:DropDownList ID="ddlTipoSangre" class="input-48 inputs" runat="server" ></asp:DropDownList>
                <asp:Label ID="lblAcademico" class="input-48 inputs" runat="server" Text="SELECCIONA UN NIVEL ACADEMICO:"></asp:Label>
                <asp:DropDownList ID="ddlNivelAcademico" class="input-48 inputs" runat="server" ></asp:DropDownList>
                <asp:Button ID="btnAgregarPersonal" class="btnCliente" runat="server" Text="Agregar Personal" OnClick="btnAgregarPersonal_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
