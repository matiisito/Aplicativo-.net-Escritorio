using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using System.Data;

namespace Biblioteca.Conexion
{
    public class Conecta
    {
        private OracleConnection conexion;

        public OracleConnection Conexion
        {
            get 
            {
                if (conexion == null)
                {
                    conexion = new OracleConnection();
                    conexion.ConnectionString = "Data Source=Mati-Pc:1521/XE;User Id=mati;Password=mati;";
                    conexion.Open();                  
                }
                return conexion;
            }
        }
        
        public void DesconectaOracle()
        {
            Conexion.Close();
        }
        
        public int EjecutarComando(string query)
        {
            try
            {
                OracleCommand cmd = new OracleCommand(query, Conexion);
                cmd.ExecuteNonQuery();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                DesconectaOracle();
            }
        }

        public DataSet AterrizaResultadoConsulta(string quey,string tabla)
        {
            try
            {                
                OracleDataAdapter oda = new OracleDataAdapter(quey, Conexion);
                DataSet ds = new DataSet();
                oda.Fill(ds,tabla);

                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                DesconectaOracle();
            }
        }
    }
}
