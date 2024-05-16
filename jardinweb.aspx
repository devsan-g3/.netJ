<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="jardinweb.aspx.cs" Inherits="Jardines.jardinweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Panel ID="PanelRegistro" runat="server" Visible="False">
                <h1> Registrar Jardin</h1>
                <div class="row">
                    <asp:Label ID="Label1" runat="server" Text="Id Jardin"></asp:Label>
                    <asp:TextBox ID="txtIdJardin" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="row">
    <asp:Label ID="Label2" runat="server" Text="Nombre"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="row">
    <asp:Label ID="Label3" runat="server" Text="Dirección"></asp:Label>
    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
</div>
<div class="row">
    <asp:Label ID="Label4" runat="server" Text="Estado"></asp:Label>
    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
        <asp:ListItem>Aprobado</asp:ListItem>
        <asp:ListItem>En Tramite</asp:ListItem>
        <asp:ListItem>Negado</asp:ListItem>
    </asp:DropDownList>
</div>
                <asp:Label ID="lblMensaje" runat="server" Text="" Font-Size="Medium" ForeColor="#0033CC"></asp:Label>
                <div class="row">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success" OnClick="btnRegistrar_Click" />
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-primary" OnClick="btnEditar_Click" Visible="False" />
                </div>

            </asp:Panel>
            <asp:Panel ID="PanelConsulta" runat="server">
                <h1>Lista de Jardines</h1>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
                <asp:GridView ID="gdvJardines" runat="server" CssClass="table" AutoGenerateColumns="False" OnRowCommand="gdvJardines_RowCommand">

                    <Columns>
                        <asp:BoundField DataField="idJardin" HeaderText="Id Jardin" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton ID="imgBtnEditar" runat="server"  ImageUrl="~/img/edit_1347.png" Width="25px" CommandName="Editar" />
                                <asp:ImageButton ID="inmBtnEliminar" runat="server"  ImageUrl="~/img/delete_4219.png" Width="25px" CommandName="Eliminar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
