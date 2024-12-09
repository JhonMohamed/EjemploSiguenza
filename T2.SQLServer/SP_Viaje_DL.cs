using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using T2.Entity;

namespace T2.MainModel
{
    public class SP_Viaje_DL
    {
        private string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Viaje> ListaViaje(string chofer = null, int? anio = null)
        {
            SqlConnection conexionsql = new SqlConnection(cadena);
            conexionsql.Open();

            SqlCommand cxn = new SqlCommand("sp_ListarViajesPorChoferYAno", conexionsql);
            cxn.Parameters.AddWithValue("@codChofer", (object)chofer ?? DBNull.Value);
            cxn.Parameters.AddWithValue("@anio", (object)anio ?? DBNull.Value);
            cxn.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cxn.ExecuteReader();

            List<Viaje> lista = new List<Viaje>();
            while (reader.Read())
            {
                Viaje viaje = new Viaje()
                {
                    NroVia = reader.GetString(0),
                    FecVia = reader.GetInt32(1),
                    HrsSal = reader.GetString(2),
                    CodRut = reader.GetString(3),
                    DesRut = reader.GetString(4),
                    CostoVia = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5)
                };
                lista.Add(viaje);
            }

            reader.Close();
            conexionsql.Close();
            return lista;


            }

        //public List<Viaje> FiltrarViaje(string chofer = null, int? anio = null)
        //{
        //    SqlConnection conexionsql = new SqlConnection(cadena);
        //    conexionsql.Open();

        //    SqlCommand cmdViaje = new SqlCommand("sp_ListarViajesPorChoferYAno", conexionsql);
        //    cmdViaje.Parameters.AddWithValue("@codChofer", chofer);
        //    cmdViaje.Parameters.AddWithValue("@anio", anio.HasValue ? (object)anio.Value : DBNull.Value);
        //    cmdViaje.CommandType = CommandType.StoredProcedure;

        //    SqlDataReader readerInfo = cmdViaje.ExecuteReader();

        //    List<Viaje> ListViaje = new List<Viaje>();
        //    Viaje viajeInfo;
        //    while (readerInfo.Read())
        //    {
        //        viajeInfo = new Viaje()
        //        {
        //            NroVia = readerInfo.GetString(0),
        //            FecVia = readerInfo.GetDateTime(1),
        //            HrsSal = readerInfo.GetString(2),
        //            CodRut = readerInfo.GetString(3),
        //            DesRut = readerInfo.GetString(4),
        //            CostoVia = readerInfo.IsDBNull(5) ? 0 : readerInfo.GetDecimal(5)
        //        };
        //        ListViaje.Add(viajeInfo);
        //    }
        //    readerInfo.Close();
        //    conexionsql.Close();
        //    return ListViaje;
        //}

    }
}
