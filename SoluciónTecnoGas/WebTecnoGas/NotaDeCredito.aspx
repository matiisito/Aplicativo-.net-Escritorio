﻿<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="NotaDeCredito.aspx.cs" Inherits="WebTecnoGas.Formulario_web19" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
</asp:Content>
<asp:Content ID="Content6" runat="server" 
    contentplaceholderid="ContentPlaceHolder1">
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:Label ID="lblBienvenida" runat="server" CssClass="membrete"></asp:Label>
                </td>
                <td align="right">
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
                CssClass="style2" Width="100%">
                <CurrentNodeStyle ForeColor="#333333" />
                <NodeStyle Font-Bold="True" ForeColor="#7C6F57" />
                <PathSeparatorStyle Font-Bold="True" ForeColor="#5D7B9D" />
                <RootNodeStyle Font-Bold="True" ForeColor="#5D7B9D" />
            </asp:SiteMapPath>
            </td>
            <td align="right">
                <asp:LinkButton ID="lbtnLogOut" runat="server" onclick="lbtnLogOut_Click" 
                    CssClass="textos">Salir de la sesión</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content8" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
                <table style="width: 100%;">
            <tr>
                <td>
                <asp:Button ID="btnVolver" runat="server" Text="Volver" 
                        PostBackUrl="~/Vender.aspx" CssClass="botones" />
                </td>
                <td align="right">
                <asp:Button ID="btnIrMóduloVenta" runat="server" Text="Ir a módulo de venta" 
                        PostBackUrl="~/Venta.aspx" CssClass="botones" />
                </td>
            </tr>
        </table>
    </asp:Content>



