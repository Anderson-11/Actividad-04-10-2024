using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public  class ProductoRepository
    {

        public List<Productos> ObtenerTodo()
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string Query = @"SELECT [idProducto]
                                          ,[Nombre]
                                          ,[Precio]
                                          ,[Stock]
                                          ,[Descripcion]
                                          ,[Marca]
                                          ,[Proveedor]
                                      FROM [dbo].[Productos]";

                var cliente = conexion.Query<Productos>(Query).ToList();
                return cliente;
            }
        }

        public Productos GetById(string id)
        {

            using (var conexion = DataBase.GetSqlConnection())
            {

                string Query_Select_for_Id = @"
                                                SELECT [idProducto]
                                                      ,[Nombre]
                                                      ,[Precio]
                                                      ,[Stock]
                                                      ,[Descripcion]
                                                      ,[Marca]
                                                      ,[Proveedor]
                                                  FROM [dbo].[Productos] WHERE idProducto = @idProducto";

                var productos = conexion.QueryFirstOrDefault<Productos>(Query_Select_for_Id, new { idProducto = id });
                return productos;
            }

        }

        public int UpdateProducts(Productos productos)
        {
            using (var conexion = DataBase.GetSqlConnection())
            {
                string query_Update_Producto = @"UPDATE [dbo].[Productos]
                                         SET [Nombre] = @Nombre,
                                             [Precio] = @Precio,
                                             [Stock] = @Stock,
                                             [Descripcion] = @Descripcion,
                                             [Marca] = @Marca,
                                             [Proveedor] = @Proveedor
                                         WHERE idProducto = @IdProducto"; // Condición para identificar el producto

                var actualizadas =
                    conexion.Execute(query_Update_Producto, new
                    {
                        Nombre = productos.Nombre,
                        Precio = productos.Precio,
                        Stock = productos.Stock,
                        Descripcion = productos.Descripcion,
                        Marca = productos.Marca,
                        Proveedor = productos.Proveedor,
                        IdProducto = productos.IdProducto
                    });
                
                return actualizadas;
            }
        }
    }
}
