using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace Biblioteca.Objetos
{
    public class Producto
    {
        #region Atributos y Accesadores y Mutadores
        private int id_prod;
        public int Id_prod
        {
            get { return id_prod; }
            set { id_prod = value; }
        }

        private string nombre_prod;
        public string Nombre_prod
        {
            get { return nombre_prod; }
            set { nombre_prod = value; }
        }

        private int cantidad_prod;
        public int Cantidad_prod
        {
            get { return cantidad_prod; }
            set { cantidad_prod = value; }
        }

        private string descripcion_prod;
        public string Descripcion_prod
        {
            get { return descripcion_prod; }
            set { descripcion_prod = value; }
        }

        private char estatus_producto;
        public char Estatus_producto
        {
            get { return estatus_producto; }
            set { estatus_producto = value; }
        }

        private int precio_producto;
        public int Precio_producto
        {
            get { return precio_producto; }
            set { precio_producto = value; }
        }

        private int id_categoriaproducto;
        public int Id_categoriaproducto
        {
            get { return id_categoriaproducto; }
            set { id_categoriaproducto = value; }
        }
        #endregion

        #region Constructores
        public Producto()
        {
            Id_prod = 0;
            Nombre_prod = string.Empty;
            Cantidad_prod = 0;
            Descripcion_prod = String.Empty;
            Estatus_producto = 'F';
            Precio_producto = 0;
            Id_categoriaproducto = 0;
        }
        public Producto(int id_producto, string nombre_producto, int cantidad_producto, string descripcion_producto,
            char estatus_producto, int precio_producto, int id_categoriaproducto)
        {
            Init(id_producto, nombre_producto, cantidad_producto, descripcion_producto,
            estatus_producto, precio_producto, id_categoriaproducto);
        }
        private void Init(int id_producto, string nombre_producto, int cantidad_producto, string descripcion_producto,
            char estatus_producto, int precio_producto, int id_categoriaproducto)
        {
            Id_prod = id_producto;
            Nombre_prod = nombre_producto;
            Cantidad_prod = cantidad_producto;
            Descripcion_prod = descripcion_producto;
            Estatus_producto = estatus_producto;
            Precio_producto = precio_producto;
            Id_categoriaproducto = id_categoriaproducto;
        }
        #endregion

        public String[] ListarNombreProductoSQL()
        {
            try
            {
                string query = "SELECT ID_PRODUCTO ID, NOMBRE_PRODUCTO NOMBRE, COALESCE(DESCRIPCION_PRODUCTO, 'SIN DESCRIPCIÓN') DESCRIPCION"+
                                " FROM PRODUCTO WHERE ESTATUS_PRODUCTO = 'T' AND ID_CATEGORIAPRODUCTO <> 1";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "PRODUCTO");
                int registros = ds.Tables["PRODUCTO"].Rows.Count;
                String[] productos = new String[registros];
                for (int i = 0; i < registros; i++)
                {
                    productos[i] = ds.Tables["PRODUCTO"].Rows[i][0].ToString() + " - " +
                                   ds.Tables["PRODUCTO"].Rows[i][1].ToString() + " - " +
                                   ds.Tables["PRODUCTO"].Rows[i][2].ToString();
                }
                return productos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public String[] ListarNombreCombustibleSQL()
        {
            try
            {
                string query = "SELECT ID_PRODUCTO ID, NOMBRE_PRODUCTO NOMBRE, COALESCE(DESCRIPCION_PRODUCTO, 'SIN DESCRIPCIÓN') DESCRIPCION" +
                                " FROM PRODUCTO WHERE ESTATUS_PRODUCTO = 'T' AND ID_CATEGORIAPRODUCTO = 1";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "PRODUCTO");
                int registros = ds.Tables["PRODUCTO"].Rows.Count;
                String[] productos = new String[registros];
                for (int i = 0; i < registros; i++)
                {
                    productos[i] = ds.Tables["PRODUCTO"].Rows[i][0].ToString() + " - " +
                                   ds.Tables["PRODUCTO"].Rows[i][1].ToString() + " - " +
                                   ds.Tables["PRODUCTO"].Rows[i][2].ToString();
                }
                return productos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CrearProductoSQL(string nombre_producto, int cantidad_producto, string descripcion_producto,
            bool estatus_producto, int precio_producto, int id_categoriaproducto)
        {
            try
            {
                string query = "INSERT INTO PRODUCTO VALUES (PRODUCTO_SEQ.NEXTVAL, '"
                                                                + nombre_producto + "', "
                                                                + cantidad_producto + ", '"
                                                                + descripcion_producto + "', '"
                                                                + estatus_producto.ToString().Substring(0,1) +"', "
                                                                + precio_producto + ", "
                                                                + id_categoriaproducto + ")";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*
         * Rellena un dataset con la informacion de los productos con su categorias por nombre (Finalidad rellena GridView)
         */ 
        public DataSet ListarProductoSQL()
        {
            try
            {
                string query = "SELECT ID_PRODUCTO AS ID, NOMBRE_PRODUCTO AS PRODUCTO, CANTIDAD_PRODUCTO AS STOCK, "+
                                        "DESCRIPCION_PRODUCTO AS DESCRIPCION, ESTATUS_PRODUCTO AS ACTIVO, "+
                                        "PRECIO_PRODUCTO AS PRECIO, NOMBRE_CATEGORIAPRODUCTO AS CATEGORIA "+
                                        "FROM PRODUCTO P, CATEGORIA_PRODUCTO CP "+
                                        "WHERE P.ID_CATEGORIAPRODUCTO = CP.ID_CATEGORIAPRODUCTO ORDER BY NOMBRE_PRODUCTO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "PRODUCTO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;   
            }
        }

        public DataSet ListarIdNombreSQL()
        {
            try
            {
                string query = "SELECT ID_PRODUCTO, NOMBRE_PRODUCTO FROM PRODUCTO ORDER BY NOMBRE_PRODUCTO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "PRODUCTO");
                DataRow dr = ds.Tables[0].NewRow();
                dr[0] = "0";
                dr[1] = "SELECCIONE";
                ds.Tables[0].Rows.Add(dr);
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool EliminarProductoSQL(string id)
        {
            try
            {
                string query = "DELETE FROM PRODUCTO WHERE ID_PRODUCTO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string[] RetonaIdDescripcionPrecioProducto(string id)
        {
            try
            {
                string[] precio = new string[4];
                Conexion.Conecta co = new Conexion.Conecta();
                string query = "SELECT NOMBRE_PRODUCTO, COALESCE(DESCRIPCION_PRODUCTO, 'SIN DESCRIPCIÓN'), PRECIO_PRODUCTO, CANTIDAD_PRODUCTO FROM PRODUCTO WHERE ID_PRODUCTO = " + id;
                DataSet ds = co.AterrizaResultadoConsulta(query, "PRODUCTO");
                precio[0] = ds.Tables["PRODUCTO"].Rows[0][0].ToString();
                precio[1] = ds.Tables["PRODUCTO"].Rows[0][1].ToString();
                precio[2] = ds.Tables["PRODUCTO"].Rows[0][2].ToString();
                precio[3] = ds.Tables["PRODUCTO"].Rows[0][3].ToString();

                return precio;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private DataSet RetornaIdCategoria(string categoria)
        {
            try
            {
                Conexion.Conecta co = new Conexion.Conecta();
                string query = "SELECT * FROM CATEGORIA_PRODUCTO WHERE NOMBRE_CATEGORIAPRODUCTO = '" + categoria + "'";
                DataSet ds = co.AterrizaResultadoConsulta(query, "CATEGORIA_PRODUCTO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool ActualizarProductoSQL(string id,string nombre, string cantidad, string descripcion, char estatus,string precio, string categoria)
        {
            try
            {
                string idcategoria = RetornaIdCategoria(categoria).Tables[0].Rows[0]["ID_CATEGORIAPRODUCTO"].ToString();
                string query = "UPDATE PRODUCTO SET NOMBRE_PRODUCTO = '" + nombre + "', " +
                                "CANTIDAD_PRODUCTO = " + cantidad + ", " +
                                "DESCRIPCION_PRODUCTO = '" + descripcion + "', " +
                                "ESTATUS_PRODUCTO = '" + estatus + "', " +
                                "PRECIO_PRODUCTO = " + precio + ", " +
                                "ID_CATEGORIAPRODUCTO = " + idcategoria +
                                " WHERE ID_PRODUCTO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Producto CreaProducto(string id)
        {
            try
            {
                string query = "SELECT * FROM PRODUCTO WHERE ID_PRODUCTO = " + id ;
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "PRODUCTO");
                Producto p = new Producto();
                p.Id_prod = int.Parse(ds.Tables[0].Rows[0]["ID_PRODUCTO"].ToString());
                p.Nombre_prod = ds.Tables[0].Rows[0]["NOMBRE_PRODUCTO"].ToString();
                p.Cantidad_prod = int.Parse(ds.Tables[0].Rows[0]["CANTIDAD_PRODUCTO"].ToString());
                p.Descripcion_prod = ds.Tables[0].Rows[0]["DESCRIPCION_PRODUCTO"].ToString();
                p.Estatus_producto = char.Parse(ds.Tables[0].Rows[0]["ESTATUS_PRODUCTO"].ToString());
                p.Precio_producto = int.Parse(ds.Tables[0].Rows[0]["PRECIO_PRODUCTO"].ToString());
                p.Id_categoriaproducto = int.Parse(ds.Tables[0].Rows[0]["ID_CATEGORIAPRODUCTO"].ToString());

                return p;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
