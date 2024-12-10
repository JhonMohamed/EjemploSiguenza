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
    public class SP_Ruta
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Ruta> ListarRutas()
        {
            var conexionsql = new SqlConnection(cadena);
            conexionsql.Open();

            var cmd = new SqlCommand("select cod_rut,des_rut from Rutas", conexionsql);
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = cmd.ExecuteReader();
            List<Ruta> lista = new List<Ruta>();
            while (reader.Read())
            {
                Ruta ruta = new Ruta()
                {
                    CodRuta = reader.GetString(0),
                    Destino = reader.GetString(1)
                };
                lista.Add(ruta);
            }

            conexionsql.Close();
            reader.Close();
            return lista;

        }
    }
}
