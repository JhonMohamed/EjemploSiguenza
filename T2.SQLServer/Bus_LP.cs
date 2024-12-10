using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;

namespace T2.SQLServer
{
    public class Bus_LP
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Bus> ListarBuses()
        {
            SqlConnection sqlConnection = new SqlConnection(cadena);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select nro_bus,nro_pla from Bus", sqlConnection);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Bus> lista = new List<Bus>();
            while (reader.Read())
            {
                Bus bus = new Bus()
                {
                    nro_bus = reader.GetInt32(0),
                    nro_pla = reader.GetString(1)

                };
                lista.Add(bus);
            }
            reader.Close();
            sqlConnection.Close();
            return lista;
        }
    }
}

