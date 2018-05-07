using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Biblioteca.Objetos
{
    public class Venta
    {
        private string id;
        private string fechaHora;
        private string patente;
        private string total;
        private char comercial;
        private char pagada;
        private char anulada;
        private string observacion;
        private string cliente;
        private string usuario;
        private string notaCredito;

        public string NotaCredito
        {
            get { return notaCredito; }
            set { notaCredito = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        public string Observacion
        {
            get { return observacion; }
            set { observacion = value; }
        }

        public char Anulada
        {
            get { return anulada; }
            set { anulada = value; }
        }

        public char Pagada
        {
            get { return pagada; }
            set { pagada = value; }
        }

        public char Comercial
        {
            get { return comercial; }
            set { comercial = value; }
        }

        public string Total
        {
            get { return total; }
            set { total = value; }
        }

        public string Patente
        {
            get { return patente; }
            set { patente = value; }
        }

        public string FechaHora
        {
            get { return fechaHora; }
            set { fechaHora = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private void Init(string id, string fecha, string patente, string total, char comercial, char pagada,
            char anulada, string observacion, string cliente, string usuario, string notacredito)
        {
            Id = id;
            FechaHora = fecha;
            Patente = patente;
            Total = total;
            Comercial = comercial;
            Pagada = pagada;
            Anulada = anulada;
            Observacion = observacion;
            Cliente = cliente;
            Usuario = usuario;
            NotaCredito = notacredito;
        }

        public Venta()
        {
            Id = string.Empty;
            FechaHora = string.Empty;
            Patente = string.Empty;
            Total = string.Empty;
            Comercial = ' ';
            Pagada = ' ';
            Anulada = ' ';
            Observacion = string.Empty;
            Cliente = string.Empty;
            Usuario = string.Empty;
            NotaCredito = string.Empty;
        }

        public Venta(string id, string fecha, string patente, string total, char comercial, char pagada,
            char anulada, string observacion, string cliente, string usuario, string notacredito)
        {
            Init(id,fecha,patente,total,comercial,pagada, anulada,observacion,cliente,usuario,notacredito);
        }

        public bool CrearVentaSQL(string fecha, string patente, string total, char comercial, char pagada,
            char anulada, string observacion, string cliente, string usuario, string notacredito)
        {
            try
            {
                string query = "INSERT INTO VENTA VALUES (VENTA_SEQ.NEXTVAL,TO_DATE('"+ fecha +"','DD-MM-YYYY HH24:MI:SS'), '"+ patente +"', "+
                    total +", '"+comercial+"', '"+pagada+"', '"+anulada+"', '"+observacion+"', "+cliente+", "+usuario+", "+notacredito+")";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string EncuentraIdVenta(string fecha, string usuario)
        {
            try
            {
                string id = string.Empty;
                string query = "SELECT ID_VENTA FROM VENTA WHERE ID_USUARIO = "+ usuario +" AND FECHAHORA_VENTA = TO_DATE('"+ fecha +"','DD-MM-YYYY HH24:MI:SS')";
                Conexion.Conecta co = new Conexion.Conecta();
                DataSet ds = co.AterrizaResultadoConsulta(query, "VENTA");
                id = ds.Tables[0].Rows[0][0].ToString();

                return id;
            }
            catch (Exception ex)
            {
                return null; 
            }
        }

        public bool CrearDetalleVentaSQL(string id, string cantidad, string valor, string prod)
        {
            try
            {
                string query = "INSERT INTO DETALLE VALUES ("+ id +", "+ cantidad +", "+ valor +", "+ prod +")";
                Conexion.Conecta co = new Conexion.Conecta();
                co.EjecutarComando(query);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
