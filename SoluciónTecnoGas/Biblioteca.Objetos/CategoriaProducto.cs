using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Biblioteca.Objetos
{
    public class CategoriaProducto
    {
        #region Atributos, Constructores y Accesadores - Mutadores
        private string id;
        private string nombre;
        private char estatus;

        public char Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private void Init(string id, string nombre, char estatus)
        {
            Id = id;
            Nombre = nombre;
            Estatus = estatus;
        }

        public CategoriaProducto()
        {
            Id = string.Empty;
            Nombre = string.Empty;
            Estatus = 'F';
        }

        public CategoriaProducto(string id, string nombre, char estatus)
        {
            Init(id,nombre,estatus);
        }
        #endregion

        public DataSet ListarIdNombreSQL()
        {
            try
            {
                string query = "SELECT ID_CATEGORIAPRODUCTO, NOMBRE_CATEGORIAPRODUCTO FROM CATEGORIA_PRODUCTO ORDER BY NOMBRE_CATEGORIAPRODUCTO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CATEGORIA_PRODUCTO");
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

        public DataSet ListarCamposSQL()
        {
            try
            {
                string query = "SELECT ID_CATEGORIAPRODUCTO AS ID, NOMBRE_CATEGORIAPRODUCTO AS NOMBRE, ESTATUS_CATEGORIAPRODUCTO AS ESTATUS FROM CATEGORIA_PRODUCTO ORDER BY NOMBRE_CATEGORIAPRODUCTO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CATEGORIA_PRODUCTO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CrearCategoriaProductoSQL(string nombre, char estatus)
        {
            try
            {
                string query = "INSERT INTO CATEGORIA_PRODUCTO VALUES (CATEGORIA_PRODUCTO_SEQ.NEXTVAL, '" + nombre +"', "+
                                                                "'" + estatus + "')";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarCategoriaProductoSQL(string id)
        {
            try
            {
                string query = "DELETE FROM CATEGORIA_PRODUCTO WHERE ID_CATEGORIAPRODUCTO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarCategoriaProductoSQL(string id, string nombre, char estatus)
        {
            try
            {
                string query = "UPDATE CATEGORIA_PRODUCTO SET NOMBRE_CATEGORIAPRODUCTO = '" + nombre + "', " +
                                                                "ESTATUS_CATEGORIAPRODUCTO = '" + estatus + "' " +
                                                                "WHERE ID_CATEGORIAPRODUCTO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CategoriaProducto RetornaCategoria(string id)
        {
            try
            {
                string query = "SELECT * FROM CATEGORIA_PRODUCTO WHERE ID_CATEGORIAPRODUCTO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CATEGORIA_PRODUCTO");
                CategoriaProducto cp = new CategoriaProducto();
                cp.Id = ds.Tables[0].Rows[0]["ID_CATEGORIAPRODUCTO"].ToString();
                cp.Nombre = ds.Tables[0].Rows[0]["NOMBRE_CATEGORIAPRODUCTO"].ToString();
                cp.Estatus = char.Parse(ds.Tables[0].Rows[0]["ESTATUS_CATEGORIAPRODUCTO"].ToString());

                return cp;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
