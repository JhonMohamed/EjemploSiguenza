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
    public class Chofer_DL
    {
        private string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Chofer> MostrarChofer()
        {
            SqlConnection conectionsql = new SqlConnection(cadena);
            conectionsql.Open();

            SqlCommand smd = new SqlCommand("select cod_chof,nom_chof  from Chofer", conectionsql);
            smd.CommandType = CommandType.Text;

            SqlDataReader reader = smd.ExecuteReader();

            List<Chofer> listChofer = new List<Chofer>();
            while (reader.Read())
            {
                Chofer chofer = new Chofer()
                {
                    CodChofer = reader.GetString(0),
                    Nom_chofer = reader.GetString(1)
                };
                listChofer.Add(chofer);
            }
            reader.Close();
            conectionsql.Close();
            return listChofer;

        }

    }
   
}
