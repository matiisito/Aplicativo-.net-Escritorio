using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.NetworkInformation;

namespace Biblioteca.Objetos
{
    public class Terminal
    {
        #region Atributos, accesadores y mutadores
        private string id;
        private string mac;
        private char estatus;
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public char Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public string Mac
        {
            get { return mac; }
            set { mac = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private void Init(string id, string mac, char estatus, string usuario)
        {
            Id = id;
            Mac = mac;
            Estatus = estatus;
            Usuario = usuario;
        }

        public Terminal(string id, string mac, char estatus, string usuario)
        {
            Init(id,mac,estatus,usuario);
        }

        public Terminal()
        {
            Id = string.Empty;
            Mac = string.Empty;
            Estatus = ' ';
            Usuario = string.Empty;
        }
        #endregion

        public bool CrearTerminalSQL(string mac, char estatus, string usuario)
        {
            try
            {
                string query = "INSERT INTO TERMINAL VALUES (TERMINAL_SEQ.NEXTVAL, '"
                                                            + mac + "', '"
                                                            + estatus + "', "
                                                            + usuario + ")";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminarTerminalSQL(string id)
        {
            try
            {
                string query = "DELETE FROM TERMINAL WHERE ID_TERMINAL = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizarTerminalSQL(string id, string mac, char estatus, string usuario)
        {
            try
            {
                string query = "UPDATE TERMINAL SET MAC_TERMINAL = '" + mac + "', " +
                                "ESTATUS_TERMINAL = '" + estatus + "', " +
                                "ID_USUARIO = " + usuario +
                                " WHERE ID_TERMINAL= " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet ListarIdNombreSQL()
        {
            try
            {
                string query = "SELECT ID_TERMINAL, MAC_TERMINAL FROM TERMINAL";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");
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

        public DataSet ListarCamposGridView()
        {
            try
            {
                string query = "SELECT T.ID_TERMINAL AS ID, T.MAC_TERMINAL AS MAC, T.ESTATUS_TERMINAL AS ESTATUS, US.NOMBRE_USUARIO AS USUARIO"+
                                " FROM TERMINAL T, USUARIO US WHERE T.ID_USUARIO = US.ID_USUARIO AND T.ID_TERMINAL <> 1";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string NombreCajero(string mac)
        {
            try
            {
                string nombre = string.Empty;
                string query = "SELECT US.NOMBRE_USUARIO AS USUARIO" +
                                " FROM TERMINAL T, USUARIO US WHERE T.ID_USUARIO = US.ID_USUARIO AND T.MAC_TERMINAL = '"+ mac  +"'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");
                nombre = ds.Tables[0].Rows[0][0].ToString();

                return nombre;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Terminal RetornaTerminal(string id)
        {
            try
            {
                string query = "SELECT * FROM TERMINAL WHERE ID_TERMINAL = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");
                Terminal t = new Terminal();
                t.Id = ds.Tables[0].Rows[0]["ID_TERMINAL"].ToString();
                t.Mac = ds.Tables[0].Rows[0]["MAC_TERMINAL"].ToString();
                t.Estatus = char.Parse(ds.Tables[0].Rows[0]["ESTATUS_TERMINAL"].ToString());
                t.Usuario = ds.Tables[0].Rows[0]["ID_USUARIO"].ToString();

                return t;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string ObtenerDireccionMAC()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String mac = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (mac == String.Empty)// only return MAC Address from first card  
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    mac = adapter.GetPhysicalAddress().ToString();
                }
            }

            return mac.Substring(0, 2) + ":" + mac.Substring(2, 2) + ":" + mac.Substring(4, 2) + ":" + mac.Substring(6, 2) + ":" + mac.Substring(8, 2) + ":" + mac.Substring(10, 2);
        }

        public bool CoincidenUsuarioTerminal(string id_usuario, string mac)
        {
            try
            {
                string query = "SELECT * FROM TERMINAL WHERE ID_USUARIO = " + id_usuario +" AND MAC_TERMINAL = '"+mac+"'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");

                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TerminalLibre(string mac)
        {
            try
            {
                string query = "SELECT * FROM TERMINAL WHERE MAC_TERMINAL = '" + mac + "'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");

                if (ds.Tables[0].Rows[0][2].ToString().Equals("F") && ds.Tables[0].Rows[0][3].ToString().Equals("1"))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CajaAbierta(string mac)
        {
            try
            {
                string query = "SELECT * FROM TERMINAL WHERE MAC_TERMINAL = '" + mac + "'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");

                if (ds.Tables[0].Rows[0][2].ToString().Equals("T"))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string RetornaId(string mac)
        {
            try
            {
                string id = string.Empty;
                string query = "SELECT * FROM TERMINAL WHERE MAC_TERMINAL = '" + mac + "'";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "TERMINAL");
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
