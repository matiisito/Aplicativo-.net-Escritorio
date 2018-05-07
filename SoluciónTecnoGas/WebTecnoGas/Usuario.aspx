<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="WebTecnoGas.Formulario_web16" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
    <table class="center">
        <tr>
            <td align="right" class="textos">
                &nbsp;</td>
            <td class="textos">
                <asp:TextBox ID="txtId" runat="server" Visible="False"></asp:TextBox>
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
                Nombre</td>
            <td class="textos">
                <asp:TextBox ID="txtNombre" runat="server" Width="177px" CssClass="textboxes" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtNombre" Display="Dynamic" 
                    ErrorMessage="Falta un nombre" SetFocusOnError="True" Width="115px" 
                    ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNombre" runat="server" 
                    BorderStyle="Outset" ControlToValidate="txtNombre" 
                    Display="Dynamic" ErrorMessage="Caracteres no permitidos" 
                    ValidationExpression="^[a-zA-Z_áÁéÉíÍóÓúÚñÑ\s]*$" Width="166px"></asp:RegularExpressionValidator>
            </td>
            <td class="textos">
                Opciones</td>
            <td class="style26">
                <asp:Button ID="btnIngresar" runat="server" 
                    Text="Ingresar" onclick="btnIngresar_Click" width="88px" 
                    CssClass="botones" BackColor="#335576" 
                    BorderStyle="Outset" ForeColor="White" ValidationGroup="Ingresar" />
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Rut</td>
            <td class="textos">
                <asp:TextBox ID="txtRut" runat="server" Height="23px" Width="135px" 
                    CssClass="textboxes" MaxLength="10"></asp:TextBox><b class="style2">-</b>
                <asp:TextBox ID="txtDv" runat="server" Height="22px" Width="32px" 
                    CssClass="textboxes" MaxLength="1"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvRut" runat="server" 
                    ErrorMessage="Falta ingresar rut" BorderStyle="Outset" 
                    ControlToValidate="txtRut" CssClass="style2" Display="Dynamic"
                    SetFocusOnError="True" Width="115px" ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
                <asp:RequiredFieldValidator ID="rfvDv" runat="server" 
                    ErrorMessage="Falta ingresar digito verificador" BorderStyle="Outset" 
                    ControlToValidate="txtDv" CssClass="style2" Display="Dynamic"
                    SetFocusOnError="True" Width="210px" ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revRut" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtRut" CssClass="style2" Display="Dynamic" 
                    ErrorMessage="Ej: 18.012.895" SetFocusOnError="True" ToolTip="Ej: 18.012.895" 
                    ValidationExpression="^\d{1,2}[.]\d{3}[.]\d{3}$"></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="revDv" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtDv" CssClass="style2" Display="Dynamic" 
                    ErrorMessage="Ej: k - K o 1-9" SetFocusOnError="True" ToolTip="Ej: k - K o 1-9" 
                    ValidationExpression="^[0-9kK]{1}$"></asp:RegularExpressionValidator>
            </td>
            <td class="textos">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                    onclick="btnActualizar_Click" CssClass="botones" BackColor="#335576" ForeColor="White" 
                    BorderStyle="Outset" width="88px" Visible="False" />
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Clave</td>
            <td class="textos">
                <asp:TextBox ID="txtClave" runat="server" width="177px" CssClass="textboxes" 
                    MaxLength="6"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvClave" runat="server" 
                    ErrorMessage="Falta ingresar clave" BorderStyle="Outset" 
                    ControlToValidate="txtClave" CssClass="style2" Display="Dynamic"
                    SetFocusOnError="True" Width="130px" ValidationGroup="Ingresar"></asp:RequiredFieldValidator></td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Dirección</td>
            <td class="textos">
                <asp:TextBox ID="txtDireccion" runat="server" width="177px" CssClass="textboxes" 
                    MaxLength="150" Rows="3" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" 
                    ErrorMessage="Falta ingresar direccion" BorderStyle="Outset" 
                    ControlToValidate="txtDireccion" CssClass="style2" Display="Dynamic"
                    SetFocusOnError="True" Width="170px" ValidationGroup="Ingresar"></asp:RequiredFieldValidator></td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Email</td>
            <td class="textos">
                <asp:TextBox ID="txtEmail" runat="server" width="177px" CssClass="textboxes" 
                    MaxLength="50"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" 
                    ErrorMessage="Falta ingresar email" BorderStyle="Outset" 
                    ControlToValidate="txtEmail" CssClass="style2" Display="Dynamic"
                    SetFocusOnError="True" Width="130px" ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                    BorderStyle="Outset" ControlToValidate="txtEmail" CssClass="style2" 
                    Display="Dynamic" ErrorMessage="Ej: camila@fyn.cl" SetFocusOnError="True" 
                    
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    Width="150px"></asp:RegularExpressionValidator>
            </td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Privilegios</td>
            <td class="textos">
                <asp:RadioButton ID="rdoCajero" runat="server" Text="Cajero" 
                    CssClass="style2" Checked="True" GroupName="Privilegios" />
                <asp:RadioButton ID="rdoAdministrador" runat="server" Text="Administrador" 
                    CssClass="style2" GroupName="Privilegios" />
                <asp:RadioButton ID="rdoEsJo" runat="server" Text="Jefe de operaciones" 
                    CssClass="style2" GroupName="Privilegios" />
            </td>
            <td class="textos">
                <asp:LinkButton ID="lbLimpiarUsuarios" runat="server" 
                    onclick="lbLimpiarUsuarios_Click">Limpiar controles</asp:LinkButton>
                </td>
            <td class="textos">
                </td>
            <td class="textos">
                </td>
        </tr>
    </table>
    <br />
    <table class="center">
    <tr>
    <td class="textos">
    <asp:GridView ID="gvUsuario" runat="server" BorderStyle="None" 
        BorderWidth="1px" CellPadding="2" GridLines="Vertical" 
        BackColor="White" BorderColor="#CCCCCC" ForeColor="Black" 
        AutoGenerateColumns="false" DataKeyNames="ID" style="text-align: left" 
            onrowcommand="gvUsuario_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Seleccionar" ImageUrl="~/Imagenes/Selecionar.png"
                    CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID"  HeaderText="ID" Visible="false"/>
            <asp:BoundField DataField="NOMBRE"  HeaderText="NOMBRE" Visible="true"/>
            <asp:BoundField DataField="RUT"  HeaderText="RUT" Visible="true"/>
            <asp:BoundField DataField="CLAVE"  HeaderText="CLAVE" Visible="true"/>
            <asp:BoundField DataField="DIRECCION"  HeaderText="DIRECCION" Visible="true"/>
            <asp:BoundField DataField="EMAIL"  HeaderText="EMAIL" Visible="true"/>
            <asp:BoundField DataField="CAJERO" HeaderText = "CAJERO"  Visible="true"/>
            <asp:BoundField DataField="ADMIN" HeaderText = "ADMIN"  Visible="true"/>
            <asp:BoundField DataField="JEFEOP" HeaderText = "JEFEOP"  Visible="true"/>
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



