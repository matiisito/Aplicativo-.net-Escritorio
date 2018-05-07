<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="Terminal.aspx.cs" Inherits="WebTecnoGas.Formulario_web17" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
<table class="center">
        <tr>
            <td align="right" class="textos">
                &nbsp;</td>
            <td class="textos">
                <asp:TextBox ID="txtId" Visible="false" runat="server"></asp:TextBox>
            </td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Dirección MAC</td>
            <td class="textos">
                <asp:TextBox ID="txtMac" runat="server" style="height: 22px" width="177px" 
                    ToolTip="XX:XX:XX:XX:XX:XX (Formato)" CssClass="textboxes" MaxLength="17"></asp:TextBox>
                <asp:Button ID="btnMac" runat="server" Text="Captar MAC" CssClass="botones" 
                    onclick="btnMac_Click" />
            </td>
            <td class="textos">
                <asp:RegularExpressionValidator ID="revMac" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtMac" CssClass="style2" Display="Dynamic" 
                    ErrorMessage="Ej: 00:50:BF:38:BA:0F" SetFocusOnError="True" 
                    ValidationExpression="^([0-9a-fA-F][0-9a-fA-F]:){5}([0-9a-fA-F][0-9a-fA-F])$" 
                    Width="152px"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvMac" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtMac" CssClass="style2" Display="Dynamic" 
                    ErrorMessage="Campo requerido" SetFocusOnError="True" 
                    ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
            </td>
            <td class="textos">
                Opciones</td>
            <td class="textos">
                <asp:Button ID="btnIngresar" runat="server" 
                    Text="Ingresar" width="88px" CssClass="botones" BackColor="#335576" 
                    BorderStyle="Outset" ForeColor="White" 
                    onclick="btnIngresar_Click" ValidationGroup="Ingresar" />
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Estatus</td>
            <td class="textos">
                <asp:RadioButton ID="rdoActivo" runat="server" Text="Activo" Checked="True" 
                    CssClass="style2" GroupName="Estatus" />
                <asp:RadioButton ID="rdoInactivo" runat="server" Text="Inactivo" 
                    CssClass="style2" GroupName="Estatus" />
            </td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                    CssClass="botones" BackColor="#335576" ForeColor="White" 
                    BorderStyle="Outset" width="88px" onclick="btnActualizar_Click" 
                    Visible="False" />
            </td>
            </tr>
            <tr>
            <td align="right" class="textos">Usuario</td>
            <td class="textos">
                <asp:DropDownList ID="ddlUsuario" runat="server" width="177px" 
                    CssClass="textboxes">
                </asp:DropDownList>
                </td>
                <td class="textos">
                <asp:LinkButton ID="lbLimpiarProductos" runat="server" 
                    onclick="lbLimpiarProductos_Click">Limpiar controles</asp:LinkButton>
                </td>
                <td class="textos">
                    &nbsp;</td>
                <td class="textos">
                </td>
            </tr>
    </table>
    <br />
    <table class="center">
    <tr>
    <td>
    <asp:GridView ID="gvTerminal" runat="server" BorderStyle="None" 
        BorderWidth="1px" CellPadding="2" GridLines="Vertical" 
        BackColor="White" BorderColor="#CCCCCC" ForeColor="Black" 
        AutoGenerateColumns="false" DataKeyNames="ID" style="text-align: left" 
            onrowcommand="gvTerminal_RowCommand" CssClass="textos" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Seleccionar" ImageUrl="~/Imagenes/Selecionar.png"
                    CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID"  HeaderText="ID" Visible="false"/>
            <asp:BoundField DataField="MAC"  HeaderText="MAC" Visible="true"/>
            <asp:BoundField DataField="ESTATUS"  HeaderText="ESTATUS" Visible="true"/>
            <asp:BoundField DataField="USUARIO"  HeaderText="USUARIO" Visible="true"/>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Eliminar" ImageUrl="~/Imagenes/Eliminar.png"
                    CommandName="Eliminar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#335576" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
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
        <asp:Button ID="btnVolver" runat="server" Text="Volver" 
        PostBackUrl="~/Mantenedores.aspx" CssClass="botones" />
    </asp:Content>



