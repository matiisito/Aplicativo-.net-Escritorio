<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="Producto.aspx.cs" Inherits="WebTecnoGas.Formulario_web11" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
    <table class="center">
        <tr>
            <td align="right" class="textos">
                Nombre</td>
            <td class="textos">
                <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
                <asp:TextBox ID="txtNombre" runat="server" style="height: 22px" width="177px" 
                    CssClass="textboxes" MaxLength="100"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtNombre" Display="Dynamic" ErrorMessage="Falta un nombre" 
                    SetFocusOnError="True" CssClass="style2" Height="19px" Width="118px" 
                    ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
            </td>
            <td class="textos">
                Opciones</td>
            <td class="textos">
            <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
                    Text="Ingresar" width="88px" CssClass="botones" BackColor="#335576" 
                    BorderStyle="Outset" ForeColor="White" ValidationGroup="Ingresar" />
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Cantidad</td>
            <td class="textos">
                <asp:TextBox ID="txtCantidad" runat="server" style="height: 22px" width="177px" 
                    CssClass="textboxes"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvCantidad" runat="server" 
                    BorderStyle="Outset" ControlToValidate="txtCantidad" Display="Dynamic" 
                    ErrorMessage="Falta cantidad" SetFocusOnError="True" CssClass="style2" 
                    Width="99px" ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCantidad" runat="server" 
                    BorderStyle="Outset" ControlToValidate="txtCantidad" CssClass="style2" 
                    Display="Dynamic" ErrorMessage="Ej: 50" SetFocusOnError="True" 
                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            </td>
            <td class="textos">
                &nbsp;</td>
                <td class="textos">
                    <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                    CssClass="botones" BackColor="#335576" ForeColor="White" 
                    BorderStyle="Outset" width="88px" onclick="btnActualizar_Click" 
                        Visible="False"/>
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Descripción</td>
                <td class="textos">
                <asp:TextBox ID="txtDescripcion" runat="server" width="177px" MaxLength="255" 
                        TextMode="MultiLine" ToolTip="Ingreso opcional" CssClass="textboxes" 
                        EnableViewState="False" Rows="5"></asp:TextBox>
                </td>
            <td class="textos">&nbsp;</td>
            <td class="textos"></td>
            <td class="textos">
                &nbsp;</td>
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
            <td class="textos"></td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Precio</td>
            <td class="textos">
                <asp:TextBox ID="txtPrecio" runat="server" width="177px" CssClass="textboxes"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:RequiredFieldValidator ID="rfvPrecio" runat="server" BorderStyle="Outset" 
                    ControlToValidate="txtPrecio" Display="Dynamic" ErrorMessage="Falta precio" 
                    SetFocusOnError="True" CssClass="style2" ValidationGroup="Ingresar"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revPrecio" runat="server" 
                    BorderStyle="Outset" ControlToValidate="txtPrecio" CssClass="style2" 
                    Display="Dynamic" ErrorMessage="Ej: 1000" SetFocusOnError="True" 
                    ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Categoria</td>
            <td class="textos">
                <asp:DropDownList ID="ddlCategoria" runat="server" width="177px" 
                    CssClass="textboxes">
                </asp:DropDownList>
            </td>
            <td class="textos">
                <asp:LinkButton ID="lbLimpiarProductos" runat="server" 
                    onclick="lbLimpiarProductos_Click">Limpiar controles</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br>
    <table class="center">
    <tr>
    <td>
    <asp:GridView ID="gvProducto" runat="server" BorderStyle="None" 
        BorderWidth="1px" CellPadding="2" GridLines="Vertical" 
        BackColor="White" BorderColor="#CCCCCC" ForeColor="Black" 
        AutoGenerateColumns="false" DataKeyNames="ID" style="text-align: left" 
            AllowSorting="True" onrowcommand="gvProducto_RowCommand" 
            CssClass="textos" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Seleccionar" ImageUrl="~/Imagenes/Selecionar.png"
                    CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID"  HeaderText="ID" Visible="false"/>
            <asp:BoundField DataField="PRODUCTO"  HeaderText="PRODUCTO" Visible="true"/>
            <asp:BoundField DataField="STOCK"  HeaderText="STOCK" Visible="true"/>
            <asp:BoundField DataField="DESCRIPCION"  HeaderText="DESCRIPCION" Visible="true"/>
            <asp:BoundField DataField="ACTIVO"  HeaderText="ACTIVO" Visible="true"/>
            <asp:BoundField DataField="PRECIO"  HeaderText="PRECIO" Visible="true"/>
            <asp:BoundField DataField="CATEGORIA" HeaderText = "CATEGORIA"  Visible="true"/>
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
    <br>
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
        PostBackUrl="~/Mantenedores.aspx" style="width: 53px" CssClass="botones" />
    </asp:Content>



