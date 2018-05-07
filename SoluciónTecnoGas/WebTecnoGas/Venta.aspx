<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="Venta.aspx.cs" Inherits="WebTecnoGas.Formulario_web110" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script type="text/javascript">
           $(document).ready(function () {
               $("#<%=txtCantidad.ClientID%>").change(function () {
                   var precio = $("#<%=txtPrecio.ClientID%>").val();
                   var cant = $("#<%=txtCantidad.ClientID%>").val();
                   var resultado = parseInt(precio) * parseInt(cant);
                   if (!resultado) {
                       $("#<%=txtTotal.ClientID%>").text(" ");
                   }
                   else {
                       $("#<%=txtTotal.ClientID%>").val(resultado);
                   }
               });
           });
    </script>
       <style type="text/css">
           .style1
           {
               width: 501px;
           }
           .style2
           {
               width: 385px;
           }
           .style3
           {
               width: 86px;
           }
           .style4
           {
               font-size: 14px;
               font-family: Calibri;
               text-decoration: none;
               width: 738px;
           }
       </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
    <table align="center">
        <tr>
            <td align="right" class="textos">
                Cliente</td>
            <td class="textos">
                <asp:TextBox ID="txtNombre" runat="server" width="177px" CssClass="style2" 
                    height="22px" Enabled="False"></asp:TextBox>
                <asp:AutoCompleteExtender ID="txtNombre_AutoCompleteExtender" runat="server"
                Enabled="True" ServiceMethod="GetCompletionListClientes"
                    TargetControlID="txtNombre" UseContextKey="True" CompletionInterval="500"
                    MinimumPrefixLength="0">
                </asp:AutoCompleteExtender>
                <asp:RadioButton ID="rdoCliente" runat="server" GroupName="Cliente" AutoPostBack="true"
                    Text="Cliente con giro comercial" 
                    oncheckedchanged="rdoCliente_CheckedChanged" />
                <asp:RadioButton ID="rdoNoCliente" runat="server" GroupName="Cliente" 
                    oncheckedchanged="rdoNoCliente_CheckedChanged" Text="Público" 
                    AutoPostBack="true" Checked="True" />
            </td>
        </tr>
        </table>
        <hr />
    <table class="center">
        <tr>
            <td align="right" class="textos">
                &nbsp;</td>
            <td class="textos">
                <asp:TextBox ID="txtId" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtNomProd" Visible="false" runat="server"></asp:TextBox>
                <asp:TextBox ID="txtDescri" Visible="False" runat="server"></asp:TextBox>
            </td>
            <td class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Producto
            </td>
            <td class="textos">
                <asp:TextBox ID="txtCombustibles" runat="server" width="500px" 
                    AutoPostBack="True" height="22px" ontextchanged="txtCombustibles_TextChanged" 
                    Visible="False"></asp:TextBox>
                <asp:AutoCompleteExtender ID="txtCombustibles_AutoCompleteExtender" runat="server" 
                    Enabled="True" ServiceMethod="GetCompletionListCombustibles"
                    TargetControlID="txtCombustibles" UseContextKey="True" CompletionInterval="500"
                    MinimumPrefixLength="0" CompletionSetCount="100">
                </asp:AutoCompleteExtender>
                <asp:TextBox ID="txtProducto" runat="server" width="500px" AutoPostBack="True" 
                    ontextchanged="txtProducto_TextChanged" height="22px"></asp:TextBox>
                <asp:AutoCompleteExtender ID="txtProducto_AutoCompleteExtender" runat="server" 
                    Enabled="True" ServiceMethod="GetCompletionListProductos"
                    TargetControlID="txtProducto" UseContextKey="True" CompletionInterval="500"
                    MinimumPrefixLength="0" CompletionSetCount="100">
                </asp:AutoCompleteExtender>
                <asp:RadioButton ID="rdoCombustibles" runat="server" CssClass="textos" 
                    GroupName="Combustible" Text="Combustibles" 
                    oncheckedchanged="rdoCombustibles_CheckedChanged" AutoPostBack="True" />
                <asp:RadioButton ID="rdoOtros" runat="server" CssClass="textos" 
                    GroupName="Combustible" Text="Otros productos" Checked="True" 
                    oncheckedchanged="rdoOtros_CheckedChanged" AutoPostBack="True" />
            </td>
            <td class="textos">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar producto" 
                    onclick="btnAgregar_Click" CssClass="botones" ValidationGroup="Agregar" />
            </td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                <asp:Label ID="lblPatente" runat="server" CssClass="textos" Text="Patente" 
                    Visible="False"></asp:Label>
            </td>
            <td class="textos">
                <asp:TextBox ID="txtPatente" runat="server" height="22px" MaxLength="6" 
                    Visible="False" width="70px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPatente" runat="server" 
                    ControlToValidate="txtPatente" CssClass="textos" Display="Dynamic" 
                    Enabled="False" ErrorMessage="Falta la patente" SetFocusOnError="True" 
                    ValidationGroup="Agregar" Visible="False"></asp:RequiredFieldValidator>
            </td>
            <td class="textos">
                <asp:Button ID="btnCancelar" runat="server" CssClass="botones" 
                    onclick="btnCancelar_Click" Text="Cancelar venta" Visible="False" />
            </td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Precio
            </td>
            <td class="textos">
                <asp:TextBox ID="txtPrecio" runat="server" Enabled="False" Width="70px" 
                    height="22px"></asp:TextBox>
            </td>
            <td class="textos">
                <asp:Button ID="btnGuardar" runat="server" onclick="btnGuardar_Click" 
                    Text="Guardar cambios" Visible="False" width="149px" CssClass="botones" />
            </td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Cantidad</td>
            <td class="textos">
                <asp:TextBox ID="txtCantidad" runat="server" height="22px" width="70px" 
                    Enabled="False"></asp:TextBox>
                <asp:NumericUpDownExtender ID="txtCantidad_NumericUpDownExtender" 
                    runat="server" Enabled="False" Maximum="1.7976931348623157E+308" Minimum="1" 
                    RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" 
                    TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtCantidad" 
                    Width="50">
                </asp:NumericUpDownExtender>
            </td>
            <td class="textos">
                &nbsp;
            </td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Total</td>
            <td class="textos">
                <asp:TextBox ID="txtTotal" runat="server" width="70px" Enabled="False"></asp:TextBox>
            </td>
            <td align="right" class="textos">
                Total venta</td>
            <td class="textos">
                <asp:Label ID="lblTotal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                <asp:Label ID="lblStock" runat="server" CssClass="textos" Text="Stock" 
                    Visible="False"></asp:Label>
            </td>
            <td class="textos">
                <asp:TextBox ID="txtStock" runat="server" width="70px" Enabled="False" 
                    Visible="False"></asp:TextBox>
            </td>
            <td align="right" class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="textos">
                <asp:Label ID="lblObservacion" runat="server" CssClass="textos" Text="Observación" 
                    Visible="False"></asp:Label>
            </td>
            <td class="textos">
                <asp:TextBox ID="txtObservacion" runat="server" MaxLength="255" Rows="2" 
                    TextMode="MultiLine" Visible="False" Width="500px"></asp:TextBox>
            </td>
            <td align="right" class="textos">
                &nbsp;</td>
            <td class="textos">
                &nbsp;</td>
        </tr>
    </table>
    <br/>
    <table class="center">
    <tr>
    <td>
    <asp:GridView ID="gvVentaCombustible" runat="server" BorderStyle="None" 
        BorderWidth="1px" CellPadding="2" GridLines="Vertical" 
        BackColor="White" BorderColor="#CCCCCC" ForeColor="Black" 
        AutoGenerateColumns="false" DataKeyNames="ID" style="text-align: left"
        CssClass="textos" onrowcommand="gvVentaCombustible_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Seleccionar" ImageUrl="~/Imagenes/Selecionar.png"
                    CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID"  HeaderText="ID" Visible="true"/>
            <asp:BoundField DataField="PATENTE"  HeaderText="PATENTE" Visible="true"/>
            <asp:BoundField DataField="PRODUCTO"  HeaderText="PRODUCTO" Visible="true"/>
            <asp:BoundField DataField="DESCRIPCION"  HeaderText="DESCRIPCION" Visible="true"/>
            <asp:BoundField DataField="CANTIDAD"  HeaderText="CANTIDAD" Visible="true"/>
            <asp:BoundField DataField="PRECIO"  HeaderText="PRECIO" Visible="true"/>
            <asp:BoundField DataField="TOTAL"  HeaderText="TOTAL" Visible="true"/>
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
    <td>
        <asp:GridView ID="gvVenta" runat="server" BorderStyle="None" 
        BorderWidth="1px" CellPadding="2" GridLines="Vertical" 
        BackColor="White" BorderColor="#CCCCCC" ForeColor="Black" 
        AutoGenerateColumns="false" DataKeyNames="ID" style="text-align: left" 
            onrowcommand="gvVenta_RowCommand" CssClass="textos">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Seleccionar" ImageUrl="~/Imagenes/Selecionar.png"
                    CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID"  HeaderText="ID" Visible="true"/>
            <asp:BoundField DataField="PRODUCTO"  HeaderText="PRODUCTO" Visible="true"/>
            <asp:BoundField DataField="DESCRIPCION"  HeaderText="DESCRIPCION" Visible="true"/>
            <asp:BoundField DataField="CANTIDAD"  HeaderText="CANTIDAD" Visible="true"/>
            <asp:BoundField DataField="PRECIO"  HeaderText="PRECIO" Visible="true"/>
            <asp:BoundField DataField="TOTAL"  HeaderText="TOTAL" Visible="true"/>
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
<asp:Content ID="Content5" runat="server" 
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
            <tr>
                <td>
                    <asp:Label ID="lblEstatusCaja" runat="server" CssClass="membrete"></asp:Label>
                </td>
                <td align="right">
                    <asp:Label ID="lblCajero" runat="server" CssClass="membrete" Visible="False"></asp:Label>
                    <asp:Button ID="btnLiberar" runat="server" CssClass="botones" 
                        Text="Liberar el terminal" Visible="False" onclick="btnLiberar_Click" />
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
            <td align="right">
                <asp:LinkButton ID="lbtnLogOut" runat="server" onclick="lbtnLogOut_Click" 
                    CssClass="textos">Salir de la sesión</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>



<asp:Content ID="Content7" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                <asp:Button ID="btnVolver" runat="server" Text="Volver" 
                        PostBackUrl="~/Vender.aspx" CssClass="botones" />
                </td>
                <td style="text-align:center;" class="style3">
                    <asp:Button ID="btnPagar" runat="server" CssClass="botonesMenu" Text="Pagar" 
                        onclick="btnPagar_Click" Visible="False" />
                </td>
                <td align="right">
                <asp:Button ID="btnIrNotaDeCredito" runat="server" Text="Ir a nota de crédito" 
                        PostBackUrl="~/NotaDeCredito.aspx" CssClass="botones" />
                </td>
            </tr>
        </table>
    </asp:Content>










