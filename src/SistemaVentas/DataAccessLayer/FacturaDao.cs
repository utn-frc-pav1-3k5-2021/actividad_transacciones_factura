using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVentas.Entities;

using System.Data;
using System.Data.SqlClient;

namespace SistemaVentas.DataAccessLayer
{
    class FacturaDao
    {
        internal bool Create(Factura factura)
        {
            var string_conexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=SistemaVentas;Integrated Security=true;";

            // Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”
            SqlConnection dbConnection = new SqlConnection();
            SqlTransaction dbTransaction = null;
            try
            {
                dbConnection.ConnectionString = string_conexion;
                dbConnection.Open();
                //Genero la transacción
                dbTransaction = dbConnection.BeginTransaction();

                //INSERT FACTURA
                SqlCommand insertFactura = new SqlCommand();
                insertFactura.Connection = dbConnection;
                insertFactura.CommandType = CommandType.Text;
                insertFactura.Transaction = dbTransaction;
                // Establece la instrucción a ejecutar
                insertFactura.CommandText = string.Concat("INSERT INTO [dbo].[Facturas] ",
                                            "           ([nro_factura]   ",
                                            "           ,[fecha]         ",
                                            "           ,[cliente]       ",
                                            "           ,[tipoFactura]   ",
                                            "           ,[subtotal]    ",
                                            "           ,[descuento]    ",
                                            "           ,[borrado])      ",
                                            "     VALUES                 ",
                                            "           (@nro_factura   ",
                                            "           ,@fecha          ",
                                            "           ,@cliente        ",
                                            "           ,@tipoFactura    ",
                                            "           ,@subtotal     ",
                                            "           ,@descuento     ",
                                            "           ,@borrado)       ");



                //Agregamos los parametros
                insertFactura.Parameters.AddWithValue("nro_factura", factura.NroFactura);
                insertFactura.Parameters.AddWithValue("fecha", factura.Fecha);
                insertFactura.Parameters.AddWithValue("cliente", factura.Cliente.IdCliente);
                insertFactura.Parameters.AddWithValue("tipoFactura", factura.TipoFactura.IdTipoFactura);
                insertFactura.Parameters.AddWithValue("subtotal", factura.SubTotal);
                insertFactura.Parameters.AddWithValue("descuento", factura.Descuento);
                insertFactura.Parameters.AddWithValue("borrado", false);

                insertFactura.ExecuteNonQuery();


                //ULTIMO ID FACTURA INSERTADO
                SqlCommand consultaIDFactura = new SqlCommand();
                consultaIDFactura.Connection = dbConnection;
                consultaIDFactura.CommandType = CommandType.Text;

                insertFactura.CommandText =  " SELECT @@IDENTITY";
                var newId = insertFactura.ExecuteScalar();
                factura.IdFactura = Convert.ToInt32(newId);


                //INSERT DETALLE FACTURA
                foreach (var itemFactura in factura.FacturaDetalle)
                {
                    //INSERT FACTURA
                    SqlCommand insertDetalle = new SqlCommand();
                    insertDetalle.Connection = dbConnection;
                    insertDetalle.CommandType = CommandType.Text;
                    insertDetalle.Transaction = dbTransaction;
                    // Establece la instrucción a ejecutar
                    insertDetalle.CommandText = string.Concat(" INSERT INTO [dbo].[FacturasDetalle] ",
                                                        "           ([id_factura]           ",
                                                        "           ,[id_producto]          ",
                                                        "           ,[precio_unitario]      ",
                                                        "           ,[cantidad]             ",
                                                        "           ,[borrado])             ",
                                                        "     VALUES                        ",
                                                        "           (@id_factura            ",
                                                        "           ,@id_producto           ",
                                                        "           ,@precio_unitario       ",
                                                        "           ,@cantidad              ",
                                                        "           ,@borrado)               ");

                    insertDetalle.Parameters.AddWithValue("id_factura", factura.IdFactura);
                    insertDetalle.Parameters.AddWithValue("id_producto", itemFactura.IdProducto);
                    insertDetalle.Parameters.AddWithValue("precio_unitario", itemFactura.PrecioUnitario);
                    insertDetalle.Parameters.AddWithValue("cantidad", itemFactura.Cantidad);
                    insertDetalle.Parameters.AddWithValue("borrado", false);

                    insertDetalle.ExecuteNonQuery();
                }

                dbTransaction.Commit();
            }
            catch (Exception ex)
            {
                dbTransaction.Rollback();
                throw ex;
            }
            return true;
        }
    }
}
