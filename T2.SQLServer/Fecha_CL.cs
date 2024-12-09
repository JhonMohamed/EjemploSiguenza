using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;

namespace T2.SQLServer
{
    public class Fecha_CL
    {
        private string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Anio> MostrarFecha()
        {
            SqlConnection conectionsql = new SqlConnection(cadena);
            conectionsql.Open();

            SqlCommand smd = new SqlCommand("select fec_via from Viajes", conectionsql);
            smd.CommandType = CommandType.Text;

            SqlDataReader reader = smd.ExecuteReader();

            List<Anio> listAnio = new List<Anio>();
            while (reader.Read())
            {
                Anio anio = new Anio()
                {
                    Fecha = reader.GetDateTime(0)
                };
                listAnio.Add(anio);
            }

            reader.Close();
            conectionsql.Close();
            return listAnio;
        }
    }
}
