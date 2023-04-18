<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="WebAppEx.Editar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">

</head>
<body>

    <div class="container" style="display:flex; flex-direction:column; align-items:center; text-align:center; justify-content:center;">
        <div class="row justify-content-center">
            <div >
                <form id="form1" runat="server">
                    <div class="myCard card text-white bg-dark mb-3" style="min-width: 25rem;">
                        <div class="card-header">PROGRAMMERS</div>
                        <div class="card-body">
                            <h5 class="card-title">EDITAR</h5>
                            <p class="card-text">Ingresa el usuario correctamente para evitar conflictos !</p>


                            <div visible="false" id="mensaje" runat="server" class="alert alert-success" role="alert">
                                <asp:Label ID="mensajeSuccess" runat="server" Text=""></asp:Label>
                            </div>


                            <div visible="false" id="mensajeDos" runat="server" class="alert alert-warning" role="alert">
                                <asp:Label ID="mensajeError" runat="server" Text=""></asp:Label>
                            </div>

                            <div class="form-group">
                                <asp:Label ID="nombreLabel" runat="server" Text="Nombre"></asp:Label>
                                <asp:TextBox class="form-control" ID="nombreTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div visible="false" id="mensajeNombre" runat="server" class="alert alert-danger" role="alert">
                                El nombre ingresado no es válido. Debe tener hasta 15 letras sin espacios.

                            </div>
                            <div class="form-group">
                                <asp:Label ID="edadLabel" runat="server" Text="Edad"></asp:Label>
                                <asp:TextBox TextMode="Number" ID="edadTextBox" class="form-control" runat="server"></asp:TextBox>

                            </div>
                            <div visible="false" id="mensajeEdad" runat="server" class="alert alert-danger" role="alert">
                                La edad ingresada no es válida. Debe ser un número entero entre 18 y 45 años.                       
                            </div>
                            <div class="form-group">
                                <asp:Label ID="correoLabel" runat="server" Text="Correo"></asp:Label>
                                <asp:TextBox class="form-control" ID="correoTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div visible="false" id="mensajeCorreo" runat="server" class="alert alert-danger" role="alert">
                                El correo electrónico ingresado no es válido. Debe tener un formato de correo electrónico válido.
                            </div>
                             <div class="form-group">
                                <asp:Label ID="estadoLabel" runat="server" Text="Estado"></asp:Label>
                                <asp:TextBox class="form-control" ID="estadoTextBox" runat="server"></asp:TextBox>
                            </div>
                            <div visible="false" id="mensajeEstado" runat="server" class="alert alert-danger" role="alert">
                                La estado debe ser I o A.                       
                            </div>
                            <div class="d-flex justify-content-center">
                                <asp:Button ID="btnEnviar" class="btn btn-dark btn-sm mr-3" runat="server" Text="EDITAR" OnClick="btnEnviar_Click" />
                                <asp:Button ID="btnCancelar" class="btn btn-outline-danger btn-sm" runat="server" Text="CANCELAR" OnClick="btnCancelar_Click" />

                            </div>

                            
                        </div>
                        <asp:Label runat="server" ID="statusLabel" ForeColor="Red"></asp:Label>
                    </div>
            </div>
                </form>
            </div>
        </div>
   </div>
</body>
</html>
