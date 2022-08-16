
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PrimeraEntrega
{
    public class ProductosVendidosHandler : DbHandler
    {
        public List<ProductoVendido> GetProductosVendidos()
        {
            List<ProductoVendido> ProductosVendidos = new List<ProductoVendido>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionToMyServer))
            {
                using (SqlCommand sqlCommand = new SqlCommand(
                    "SELECT * FROM ProductoVendido", sqlConnection))
                {
                    sqlConnection.Open();

                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        // Me aseguro que haya filas que leer
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                ProductoVendido productoVendido = new ProductoVendido();

                                productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                                productoVendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);
                                ProductosVendidos.Add(productoVendido);

                            }
                        }
                    }

                    sqlConnection.Close();
                }
            }

            return ProductosVendidos;
        }


    }
}
