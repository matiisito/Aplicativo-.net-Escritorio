<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="WebTecnoGas.Formulario_web1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
    <table class="center">
        <tr>
            <td class="textos">
                Usuario</td>
            <td class="textos">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
                <asp:TextBox ID="txtUsuario" runat="server" width="200px" CssClass="textboxes"></asp:TextBox>
                <asp:AutoCompleteExtender ID="txtUsuario_AutoCompleteExtender" runat="server" 
                    Enabled="True" ServiceMethod="GetCompletionList"
                    TargetControlID="txtUsuario" UseContextKey="True" CompletionInterval="500" 
                    MinimumPrefixLength="0">
                </asp:AutoCompleteExtender>
            </td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="textos">
                Contraseña</td>
            <td class="textos">
                <asp:TextBox ID="txtContraseña" runat="server" width="200px" 
                    TextMode="Password" MaxLength="6" CssClass="textboxes"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" 
                    ControlToValidate="txtContraseña" Display="Dynamic" 
                    ErrorMessage="Su contraseña por favor" SetFocusOnError="True" 
                    BorderStyle="Outset" CssClass="style2" Width="176px" 
                    ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right;" class="textos">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" 
                    onclick="btnIngresar_Click" width="88px" CssClass="botones" BackColor="#335576" 
                    BorderStyle="Outset" ForeColor="White" ValidationGroup="Ingresar"/>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" 
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
<asp:Content ID="Content6" runat="server" contentplaceholderid="cphDiv2">
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
            <td style="text-align: right;">
                <asp:LinkButton ID="lbtnLogOut" runat="server" CssClass="textos">Salir de la sesión</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>


<asp:Content ID="Content7" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <asp:Button ID="btnVolver" runat="server" Text="Volver" 
    CssClass="botones" />
</asp:Content>