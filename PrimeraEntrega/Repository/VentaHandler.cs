//using MiPrimerAPI3.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimeraEntrega
{
    public class VentaHandler : DbHandler
    {
        public List<Venta> GetVentas()
        {
            List<Venta> Ventas = new List<Venta>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionToMyServer))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM Venta", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                Venta venta = new Venta();

                                venta.Id = Convert.ToInt32(dataReader["Id"]);
                                venta.Comentarios = dataReader["Comentarios"].ToString();
                                Ventas.Add(venta);
                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return Ventas;
        }

    }
}
