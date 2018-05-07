<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="Mantenedores.aspx.cs" Inherits="WebTecnoGas.Formulario_web113" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
    <table class="center">
        <tr>
            <td style="text-align: center;">
                <asp:LinkButton ID="lbtnProducto" CssClass="botonesMenu" runat="server" 
                    PostBackUrl="~/Producto.aspx">Producto</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height:25px;">
                </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <asp:LinkButton ID="lbtnCategoriaProducto" CssClass="botonesMenu" runat="server" 
                    PostBackUrl="~/CategoriaProducto.aspx">Categoria producto</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td style="height:25px;">
                </td>
        </tr>
        <tr>
            <td style="text-align: center;">
                <asp:LinkButton ID="lbtnUsuario" CssClass="botonesMenu" runat="server" 
                    PostBackUrl="~/Usuario.aspx">Usuario</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td style="height:25px;">
                </td>
        </tr>
        <tr>
            <td style="text-align: center;">
            <asp:LinkButton ID="lbtnCliente" CssClass="botonesMenu" runat="server" 
                    PostBackUrl="~/Cliente.aspx">Cliente</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td style="height:25px;">
                </td>
        </tr>
        <tr>
            <td style="text-align: center;">
            <asp:LinkButton ID="lbtnContrato" CssClass="botonesMenu" runat="server" 
                    PostBackUrl="~/Contrato.aspx">Contrato</asp:LinkButton>
                </td>
        </tr>
        <tr>
            <td style="height:25px;">
                </td>
        </tr>
        <tr>
            <td style="text-align: center;">
            <asp:LinkButton ID="lbtnTerminal" CssClass="botonesMenu" runat="server" 
                    PostBackUrl="~/Terminal.aspx">Terminal</asp:LinkButton>
                </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="lblBienvenida" runat="server" CssClass="membrete"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:Label ID="lblCargo" runat="server" CssClass="membrete"></asp:Label>
                </td>
            </tr>
        </table>
    </asp:Content>

<asp:Content ID="Content7" runat="server" contentplaceholderid="cphDiv2">
    <table style="width:100%;">
        <tr>
            <td>
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" BorderStyle="None" 
                Font-Size="12px" Font-Names="Calibri" PathSeparator=" === " 
                CssClass="textos" Width="100%">
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
            </asp:SiteMapPath>
            </td>
            <td style="text-align: right">
                <asp:LinkButton ID="lbtnLogOut" runat="server" onclick="lbtnLogOut_Click" 
                    CssClass="textos">Salir de la sesión</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content8" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
        <asp:Button ID="btnVolver" runat="server" Text="Volver" 
        PostBackUrl="~/Menu.aspx" CssClass="botones" />
    </asp:Content>



