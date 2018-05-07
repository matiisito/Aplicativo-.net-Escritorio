<%@ Page Title="" Language="C#" MasterPageFile="~/TecnoGasMP.Master" AutoEventWireup="true" CodeBehind="Contrato.aspx.cs" Inherits="WebTecnoGas.Formulario_web14" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphDiv3" runat="server">
    <table class="center">
        <tr>
            <td align="right" class="textos">
                Cliente</td>
            <td class="textos">
             <asp:TextBox ID="txtId" runat="server" Visible="False" width="199px"></asp:TextBox>
                <asp:DropDownList ID="ddlCliente" runat="server" width="199px" 
                    CssClass="textboxes">
                </asp:DropDownList>
            </td>
            <td class="textos">Opciones</td>
            <td class="style4">
                <asp:Button ID="btnIngresar" runat="server" 
                    Text="Ingresar" width="88px" CssClass="botones" BackColor="#335576" 
                    BorderStyle="Outset" ForeColor="White"
                    onclick="btnIngresar_Click" />
            </td>
        </tr>
        <tr>
            <td align="right" class="textos">
                Fecha</td>
            <td class="textos">
                <asp:Calendar ID="cFecha" runat="server" BackColor="White" 
                    BorderColor="#999999" CellPadding="4" DayNameFormat="Shortest" 
                    FirstDayOfWeek="Monday" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                    Height="180px" NextPrevFormat="ShortMonth" ShowGridLines="True" Width="200px" >
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                    <NextPrevStyle VerticalAlign="Bottom" />
                    <OtherMonthDayStyle ForeColor="#335576" />
                    <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" />
                    <TitleStyle BackColor="#335576" BorderColor="Black" Font-Bold="True" ForeColor="White" />
                    <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <WeekendDayStyle BackColor="#FFFFCC" />
                </asp:Calendar>
            </td>
            <td class="textos"></td>
            <td>
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" 
                    width="88px" CssClass="botones" BackColor="#335576" 
                    BorderStyle="Outset" ForeColor="White" onclick="btnActualizar_Click" 
                    Visible="False" />
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
                <asp:LinkButton ID="lbLimpiarUsuarios" runat="server" 
                    onclick="lbLimpiarUsuarios_Click">Limpiar controles</asp:LinkButton>
                </td>
            <td class="textos">
                &nbsp;</td>
        </tr>
    </table>
    <br />
    <table class="center">
    <tr>
    <td>
    <asp:GridView ID="gvContrato" runat="server" BorderStyle="None" 
        BorderWidth="1px" CellPadding="2" GridLines="Vertical" 
        BackColor="White" BorderColor="#CCCCCC" ForeColor="Black" 
        AutoGenerateColumns="false" DataKeyNames="ID" style="text-align: left" 
            onrowcommand="gvContrato_RowCommand" CssClass="textos">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton runat="server" ID="Seleccionar" ImageUrl="~/Imagenes/Selecionar.png"
                    CommandName="Seleccionar" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ID"  HeaderText="ID" Visible="false"/>
            <asp:BoundField DataField="CLIENTE"  HeaderText="CLIENTE" Visible="true"/>
            <asp:BoundField DataField="FECHA"  HeaderText="FECHA" Visible="true"/>
            <asp:BoundField DataField="ESTATUS"  HeaderText="ESTATUS" Visible="true"/>
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
        <asp:Button ID="btnVolver" runat="server" Text="Volver" 
        PostBackUrl="~/Mantenedores.aspx" CssClass="botones" />
    </asp:Content>



