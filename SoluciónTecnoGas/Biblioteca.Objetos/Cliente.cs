using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Biblioteca.Conexion;

namespace Biblioteca.Objetos
{
    public class Cliente
    {
        #region Atributos, Constructores, Accesadores y Mutadores 
        private string id;
        private string rut;
        private string nombre;
        private string direccion;
        private string email;
        private string telefono;
        private string giro;

        public string Giro
        {
            get { return giro; }
            set { giro = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Rut
        {
            get { return rut; }
            set { rut = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private void Init(string id, string rut, string nombre, string direccion, string email, string telefono, string giro)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
            Direccion = direccion;
            Email = email;
            Telefono = telefono;
            Giro = giro;
        }

        public Cliente()
        {
            Id = string.Empty;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            Telefono = string.Empty;
            Giro = string.Empty;
        }

        public Cliente(string id, string rut, string nombre, string direccion, string email, string telefono, string giro)
        {
            Init(id,rut,nombre,direccion,email,telefono,giro);
        }
        #endregion

        public String[] ListarNombreClienteSQL()
        {
            try
            {
                string query = "SELECT CLI.NOMBRE_CLIENTE NOMBRE FROM  CLIENTE CLI, CONTRATO CONT "+
                                "WHERE CLI.ID_CLIENTE = CONT.ID_CLIENTE AND CONT.ESTATUS_CONTRATO = 'T'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CLIENTE");
                int registros = ds.Tables["CLIENTE"].Rows.Count;
                String[] productos = new String[registros];
                for (int i = 0; i < registros; i++)
                {
                    productos[i] = ds.Tables["CLIENTE"].Rows[i][0].ToString();
                }
                return productos;
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
                string query = "SELECT ID_CLIENTE, NOMBRE_CLIENTE FROM CLIENTE WHERE ID_CLIENTE <> 1 ORDER BY NOMBRE_CLIENTE ";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CLIENTE");
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

        public DataSet ListarClienteSQL()
        {
            try
            {
                string query = "SELECT ID_CLIENTE AS ID, RUT_CLIENTE AS RUT, NOMBRE_CLIENTE AS NOMBRE, DIRECCION_CLIENTE AS DIRECCION, "+
                                "EMAIL_CLIENTE AS EMAIL, FONO_CLIENTE AS TELEFONO, GIRO_CLIENTE AS GIRO "+
                                "FROM CLIENTE WHERE ID_CLIENTE <> 1 ORDER BY NOMBRE_CLIENTE ";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CLIENTE");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CrearClienteSQL(string rut, string nombre, string direccion, string email, string telefono, string giro)
        {
            try
            {
                string query = "INSERT INTO CLIENTE VALUES (CLIENTE_SEQ.NEXTVAL, '" + rut + "', " +
                                                            "'" + nombre + "', '" + direccion + "', " +
                                                            "'" + email + "', '" + telefono + "', " +
                                                            "'" + giro + "')";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarClienteSQL(string id)
        {
            try
            {
                string query = "DELETE FROM CLIENTE WHERE ID_CLIENTE = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarClienteSQL(string id, string rut, string nombre, string direccion, string email, string telefono, string giro)
        {
            try
            {
                string query = "UPDATE CLIENTE SET RUT_CLIENTE = '" + rut + "', " +
                                                    "NOMBRE_CLIENTE = '" + nombre + "', " +
                                                    "DIRECCION_CLIENTE = '" + direccion + "', " +
                                                    "EMAIL_CLIENTE = '" + email + "', " +
                                                    "FONO_CLIENTE = '" + telefono + "', " +
                                                    "GIRO_CLIENTE = '" + giro + "' " +
                                                    "WHERE ID_CLIENTE = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Cliente RetornaCliente(string id)
        {
            try
            {
                string query = "SELECT * FROM CLIENTE WHERE ID_CLIENTE = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CLIENTE");
                Cliente c = new Cliente();
                c.Id = ds.Tables[0].Rows[0]["ID_CLIENTE"].ToString();
                c.Rut = ds.Tables[0].Rows[0]["RUT_CLIENTE"].ToString();
                c.Nombre = ds.Tables[0].Rows[0]["NOMBRE_CLIENTE"].ToString();
                c.Direccion = ds.Tables[0].Rows[0]["DIRECCION_CLIENTE"].ToString();
                c.Email = ds.Tables[0].Rows[0]["EMAIL_CLIENTE"].ToString();
                c.Telefono = ds.Tables[0].Rows[0]["FONO_CLIENTE"].ToString();
                c.Giro = ds.Tables[0].Rows[0]["GIRO_CLIENTE"].ToString();

                return c;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string EncuentraIdCliente(string nombre)
        {
            try
            {
                string id = string.Empty;
                string query = "SELECT ID_CLIENTE FROM CLIENTE WHERE NOMBRE_CLIENTE = '" + nombre + "'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CLIENTE");
                id = ds.Tables[0].Rows[0][0].ToString();

                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
