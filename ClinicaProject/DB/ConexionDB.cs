using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClinicaProject.DB
{
    class ConexionDB
    {

        public static string Cadena = "Data Source=FISICA\\MSSQLSERVER2014;Initial Catalog=Clinica;Integrated Security=True";
        public SqlConnection conectarbd = new SqlConnection();

        public ConexionDB ()
        {
            conectarbd.ConnectionString = Cadena;
        }

        public void AbrirConexion ()
        {
            conectarbd.Open();
        }

        public void CerrarConexion ()
        {
            conectarbd.Close();
        }

    }
}
