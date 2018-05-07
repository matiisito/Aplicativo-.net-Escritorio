using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Biblioteca.Objetos
{
    public class Contrato
    {
        #region Atributos, Constructores, Accesadores y Mutadores
        private string id;
        private string cliente;
        private DateTime fechaContrato;
        private char estatus;

        public char Estatus
        {
            get { return estatus; }
            set { estatus = value; }
        }

        public DateTime FechaContrato
        {
            get { return fechaContrato; }
            set { fechaContrato = value; }
        }

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private void Init(string id, string cliente, DateTime fecha, char estatus)
        {
            Id = id;
            Cliente = cliente;
            FechaContrato = fecha;
            Estatus = estatus;
        }

        public Contrato()
        {
            Id = string.Empty;
            Cliente = string.Empty;
            FechaContrato = DateTime.MinValue;
            Estatus = 'F';
        }

        public Contrato(string id, string cliente, DateTime fecha, char estatus)
        {
            Init(id, cliente, fecha, estatus);
        }
        #endregion

        public bool CrearContratoSQL(string fecha, string estatus, string cliente)
        {
            try
            {
                string query = "INSERT INTO CONTRATO VALUES (CONTRATO_SEQ.NEXTVAL, TO_DATE('" + fecha + "','DD-MM-YYYY'), '" +
                                                             estatus + "', " + cliente + ")";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EliminaContratoSQL(string id)
        {
            try
            {
                string query = "DELETE FROM CONTRATO WHERE ID_CONTRATO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ActualizaContratoSQL(string id, string fecha, string estatus, string cliente)
        {
            try
            {
                string query = "UPDATE CONTRATO SET FECHA_CONTRATO = TO_DATE('" + fecha + "','DD-MM-YYYY'), " +
                                                    "ESTATUS_CONTRATO = '" + estatus + "', " +
                                                    "ID_CLIENTE = " + cliente + " WHERE ID_CONTRATO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataSet ListarCamposSQL()
        {
            try
            {
                string query = "SELECT ID_CONTRATO ID, CLI.NOMBRE_CLIENTE CLIENTE, FECHA_CONTRATO FECHA, ESTATUS_CONTRATO ESTATUS "+
                                "FROM CLIENTE CLI, CONTRATO CONT WHERE CONT.ID_CLIENTE = CLI.ID_CLIENTE";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CONTRATO");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataSet ListarIdContratoSQL()
        {
            try
            {
                string query = "SELECT ID_CONTRATO FROM CONTRATO";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CONTRATO");
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

        public Contrato RetornaContrato(string id)
        {
            try
            {
                string query = "SELECT * FROM CONTRATO WHERE ID_CONTRATO = " + id;
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "CONTRATO");
                Contrato c = new Contrato();
                c.Id = ds.Tables[0].Rows[0]["ID_CONTRATO"].ToString();
                c.FechaContrato = DateTime.Parse(ds.Tables[0].Rows[0]["FECHA_CONTRATO"].ToString());
                c.Estatus = char.Parse(ds.Tables[0].Rows[0]["ESTATUS_CONTRATO"].ToString());
                c.Cliente = ds.Tables[0].Rows[0]["ID_CLIENTE"].ToString();

                return c;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
