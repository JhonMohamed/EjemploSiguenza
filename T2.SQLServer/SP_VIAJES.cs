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
    public class SP_VIAJES
    {
        private readonly string cadena = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;

        public List<Viajes> ListarViajes()
        {
            var conexionsql = new SqlConnection(cadena);
            conexionsql.Open();

            var cmd = new SqlCommand("sp_ListarViajes", conexionsql);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader reader = cmd.ExecuteReader();

            List<Viajes> lista = new List<Viajes>();
            while (reader.Read())
            {
                Viajes viajes = new Viajes()
                {
                    NumeroViaje = reader.IsDBNull(0) ? null : reader.GetString(0),
                    nro_pla = reader.IsDBNull(1) ? null : reader.GetString(1),
                    DescripcionRuta = reader.IsDBNull(2) ? null : reader.GetString(2),
                    HoraSalida = reader.IsDBNull(3) ? null : reader.GetString(3),
                    FechaViaje = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4),
                    CostoViaje = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                    NombreChofer = reader.IsDBNull(6) ? null : reader.GetString(6)
                };
                lista.Add(viajes);
            }

            reader.Close();
            conexionsql.Close();
            return lista;
        }

        public void SP_Editar_Viajes(string NumeroViaje, int? NumeroBus, string nro_pla, string CodigoChofer,
            string HoraSalida, decimal? CostoViaje, DateTime? FechaViaje)
        {
            using (var conexionSql = new SqlConnection(cadena))
            {
                conexionSql.Open();
                using (var cmd = new SqlCommand("sp_ActualizarViaje", conexionSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nro_via", NumeroViaje);
                    cmd.Parameters.AddWithValue("@nro_bus", (object)NumeroBus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cod_rut", (object)nro_pla ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cod_chof", (object)CodigoChofer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@hrs_sal", (object)HoraSalida ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fec_via", (object)FechaViaje ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo_via", (object)CostoViaje ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                conexionSql.Close();
            }
        }

        public void Details_LP(string NumeroViaje, int? NumeroBus, string nro_pla, string CodigoChofer,
            string HoraSalida, decimal? CostoViaje, DateTime? FechaViaje)
        {
            using (var conexionSql = new SqlConnection(cadena))
            {
                conexionSql.Open();
                using (var cmd = new SqlCommand("sp_ActualizarViaje", conexionSql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nro_via", NumeroViaje);
                    cmd.Parameters.AddWithValue("@nro_bus", (object)NumeroBus ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cod_rut", (object)nro_pla ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cod_chof", (object)CodigoChofer ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@hrs_sal", (object)HoraSalida ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@fec_via", (object)FechaViaje ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@costo_via", (object)CostoViaje ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }

                conexionSql.Close();
            }
        }
        public void sp_EliminarViaje(string NumeroViaje)
        {
            var conexionSql = new SqlConnection(cadena);
            conexionSql.Open();

            var cmd = new SqlCommand("sp_EliminarViaje", conexionSql);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nro_via", NumeroViaje);
            cmd.ExecuteNonQuery();
            conexionSql.Close();
        }
    }
}