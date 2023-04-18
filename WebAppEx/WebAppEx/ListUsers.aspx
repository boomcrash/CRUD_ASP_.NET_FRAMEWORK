<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListUsers.aspx.cs" Inherits="WebAppEx.ListUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="~/Content/ListUsers/css/StyleSheet1.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css" integrity="sha384-xOolHFLEh07PJGoPkLv1IbcEPTNtaed2xpHsD9ESMhqIYd0nLMwNLD69Npy4HI+N" crossorigin="anonymous">
</head>
<body>
    <div class="container" style="display: flex; flex-direction: column; align-items: center; text-align: center; justify-content: center;">
        <div class="row justify-content-center">
            <div>
                <form id="form1" runat="server">
                    <div class="myCard card text-white bg-dark mb-3" style="min-width: 45rem;">
                        <div class="card-header">PROGRAMMERS</div>
                        <div class="card-body" style="min-width: 45rem;">
                            <asp:GridView ID="gridPersonas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" OnSelectedIndexChanged="gridPersonas_SelectedIndexChanged" OnRowDeleting="gridPersonas_RowDeleting" OnRowEditing="gridPersonas_RowEditing">
                                <HeaderStyle BackColor="red" ForeColor="white" />
                                <Columns>
                                    <asp:BoundField ItemStyle-BackColor="white" ItemStyle-ForeColor="Black" DataField="idPersona" HeaderText="idUsuario" />
                                    <asp:BoundField ItemStyle-BackColor="white" ItemStyle-ForeColor="Black" DataField="Nombre" HeaderText="Nombre" />
                                    <asp:BoundField ItemStyle-BackColor="white" ItemStyle-ForeColor="Black" DataField="Edad" HeaderText="Edad" />
                                    <asp:BoundField ItemStyle-BackColor="white" ItemStyle-ForeColor="Black" DataField="Correo" HeaderText="Correo" />
                                    <asp:BoundField ItemStyle-BackColor="white" ItemStyle-ForeColor="Black" DataField="Estado" HeaderText="Estado" />

                                    <asp:ButtonField  CommandName="Edit" Text="Editar" ButtonType="Button" HeaderText="Editar" />
                                    <asp:ButtonField CommandName="Delete" Text="Eliminar" ButtonType="Button" HeaderText="Eliminar" />
                                </Columns>
                            </asp:GridView>
                            <asp:Button ID="Button1" class="btn btn-outline-warning btn-sm" runat="server" Text="REGISTRAR" OnClick="btnRegistrar_Click" />
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

</body>
</html>
