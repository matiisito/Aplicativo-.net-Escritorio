using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Biblioteca.Objetos
{
    public class Usuario
    {

        #region Constructores, accesadores y mutadores
        public Usuario()
        {
            Id = string.Empty;
            Rut = string.Empty;
            Nombre = string.Empty;
            Clave = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty;
            EsCajero = ' ';
            EsAdmin = ' ';
            EsJefeOperaciones = ' ';

        }

        public Usuario(string id, string rut, string nombre, string clave,
                            string direccion, string email, char cajero, char admin, char esjo)
        {
            Init(id,rut,nombre,clave,direccion,email,cajero,admin,esjo);
        }

        private void Init(string id, string rut, string nombre, string clave,
                            string direccion, string email, char cajero, char admin, char esjo)
        {
            Id = id;
            Rut = rut;
            Nombre = nombre;
            Clave = clave;
            Direccion = direccion;
            Email = email;
            EsCajero = cajero;
            EsAdmin = admin;
            esJefeOperaciones = esjo;
        }

        private string id;
        private string rut;
        private string nombre;
        private string clave;
        private string direccion;
        private string email;
        private char esCajero;
        private char esAdmin;
        private char esJefeOperaciones;

        public char EsJefeOperaciones
        {
            get { return esJefeOperaciones; }
            set { esJefeOperaciones = value; }
        }

        public char EsAdmin
        {
            get { return esAdmin; }
            set { esAdmin = value; }
        }

        public char EsCajero
        {
            get { return esCajero; }
            set { esCajero = value; }
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

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
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
        #endregion

        /*
         * Lista todos los nombre de los usuario (Ocupado en LogIn y en Mantenerdor de usuarios)
         */
        public String[] ListarNombreUsuarioSQL()
        {
            try
            {                
                string query = "SELECT NOMBRE_USUARIO FROM USUARIO ORDER BY NOMBRE_USUARIO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
                int registros = ds.Tables[0].Rows.Count;
                String[] usuarios = new String[registros];
                for (int i = 0; i < registros; i++)
                {
                    usuarios[i] = ds.Tables[0].Rows[i][0].ToString();
                }
                return usuarios;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*
         * Devuelve un registro si el nombre de usuario y clave coinciden
         */
        public DataSet CoincideUsuarioSQL(string nom, string clave)
        {
            try
            {
                string query = "SELECT * FROM USUARIO " +
                                 "WHERE NOMBRE_USUARIO = '" + nom + "' AND CLAVE_USUARIO = '" + clave + "'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*
         * Lista a todos los usuario por id y nombre (Es usado por el drop down list del mantedor de usuario)
         */
        public DataSet ListarIdNombreSQL()
        {
            try
            {
                string query = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO ORDER BY NOMBRE_USUARIO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
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

        public DataSet ListarIdNombreCajeroSQL()
        {
            try
            {
                string query = "SELECT ID_USUARIO, NOMBRE_USUARIO FROM USUARIO WHERE ESCAJERO_USUARIO = 'T' ORDER BY NOMBRE_USUARIO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /*
         * Lista a los usuario con alias en sus cabeceras de columnas y rellena al data grid view del mantenedor de usuario
         */
        public DataSet ListarUsuarioSQL()
        {
            try
            {
                string query = "SELECT ID_USUARIO AS ID, NOMBRE_USUARIO AS NOMBRE,"+
                                " RUT_USUARIO AS RUT,"+
                                " CLAVE_USUARIO AS CLAVE,"+
                                " DIRECCION_USUARIO AS DIRECCION,"+
                                " EMAIL_USUARIO AS Email,"+
                                " ESCAJERO_USUARIO AS CAJERO,"+
                                " ESADMIN_USUARIO AS ADMIN,"+
                                " ESJO_USUARIO AS JEFEOP"+
                                " FROM USUARIO WHERE ID_USUARIO <> 1 ORDER BY NOMBRE_USUARIO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CrearUsuarioSQL(string rut_usuario, string nombre_usuario, string clave_usuario,
            string direccion_usuario, string email_usuario, bool escajero_usuario, bool esadmin_usuario, bool esjo_usuario)
        {
            try
            {
                string query = "INSERT INTO USUARIO VALUES (USUARIO_SEQ.NEXTVAL, '"
                                                                + rut_usuario + "', '"
                                                                + nombre_usuario + "', '"
                                                                + clave_usuario + "', '"
                                                                + direccion_usuario +"', '"
                                                                + email_usuario +"', '"
                                                                + escajero_usuario.ToString().Substring(0, 1) + "', '"
                                                                + esadmin_usuario.ToString().Substring(0, 1) + "', '"
                                                                + esjo_usuario.ToString().Substring(0, 1) + "')";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarUsuarioSQL(string id)
        {
            try
            {
                string query = "DELETE FROM USUARIO WHERE ID_USUARIO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarUsuarioSQL(string id, string rut, string nom, string clave, string direccion,
                                        string email, char cajero, char admin, char jefeoperacion)
        {
            try
            {
                string query = "UPDATE USUARIO SET RUT_USUARIO = '" + rut + "', " +
                                "NOMBRE_USUARIO = '" + nom + "', " +
                                "CLAVE_USUARIO = '" + clave + "', " +
                                "DIRECCION_USUARIO = '" + direccion + "', " +
                                "EMAIL_USUARIO = '" + email + "', " +
                                "ESCAJERO_USUARIO = '" + cajero + "', " +
                                "ESADMIN_USUARIO = '" + admin + "', " +
                                "ESJO_USUARIO = '" + jefeoperacion + "' "+
                                "WHERE ID_USUARIO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Usuario RetornaUsuario(string id)
        {
            try
            {
                string query = "SELECT * FROM USUARIO WHERE ID_USUARIO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
                Usuario u = new Usuario();
                u.Id = ds.Tables[0].Rows[0]["ID_USUARIO"].ToString();
                u.Rut = ds.Tables[0].Rows[0]["RUT_USUARIO"].ToString();
                u.Nombre = ds.Tables[0].Rows[0]["NOMBRE_USUARIO"].ToString();
                u.Clave = ds.Tables[0].Rows[0]["CLAVE_USUARIO"].ToString();
                u.Direccion = ds.Tables[0].Rows[0]["DIRECCION_USUARIO"].ToString();
                u.Email = ds.Tables[0].Rows[0]["EMAIL_USUARIO"].ToString();
                u.EsCajero = char.Parse(ds.Tables[0].Rows[0]["ESCAJERO_USUARIO"].ToString());
                u.EsAdmin = char.Parse(ds.Tables[0].Rows[0]["ESADMIN_USUARIO"].ToString());
                u.EsJefeOperaciones = char.Parse(ds.Tables[0].Rows[0]["ESJO_USUARIO"].ToString());

                return u;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string EncuentraIdUsuario(string nombre)
        {
            try
            {
                string id = string.Empty;
                string query = "SELECT ID_USUARIO FROM USUARIO WHERE NOMBRE_USUARIO = '"+ nombre +"'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "USUARIO");
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
