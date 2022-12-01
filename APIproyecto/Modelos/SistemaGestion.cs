using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace APIproyecto.Modelos
{
    public class SistemaGestion
    {
        private string cadenaConexion = "Server=sql.bsite.net\\MSSQL2016;Database=marcosarri95_SistemaGestion;User Id=marcosarri95_SistemaGestion;Password=carp+91218;";

        public SistemaGestion()
        {
        }

        public List<Usuario> ConsultaUsuarios()
        {


            var listaUsuario = new List<Usuario>();

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("Select * from Usuario", connection))
                    {
                        connection.Open();

                        var parametros = new SqlParameter();

                        using (SqlDataReader datos = cmd.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                while (datos.Read())
                                {
                                    Usuario user = new Usuario();
                                    user.ID = Convert.ToInt32(datos["Id"]);
                                    user.Nombre = datos["Nombre"].ToString();
                                    user.Apellido = datos["Apellido"].ToString();
                                    user.NombreUsuario = datos["NombreUsuario"].ToString();
                                    user.Contrasenia = datos["Contraseña"].ToString();
                                    user.Email = datos["Mail"].ToString();
                                    listaUsuario.Add(user);


                                }
                            }
                        }
                    }
                    Console.WriteLine("Cerrando Conexión");
                    connection.Close();

                    return listaUsuario;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            return listaUsuario;
        }

        public List<Producto> ConsultaProductos()
        {


            List<Producto> listaProducto = new List<Producto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("Select * from Producto", connection))
                    {
                        connection.Open();

                        var parametros = new SqlParameter();

                        using (SqlDataReader datos = cmd.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                while (datos.Read())
                                {
                                    Producto producto = new Producto();
                                    producto.ID = Convert.ToInt32(datos["Id"]);
                                    producto.Descripcion = datos["Descripciones"].ToString();
                                    producto.Costo = Convert.ToInt64(datos["Costo"]);
                                    producto.PrecioVenta = Convert.ToInt64(datos["PrecioVenta"]);
                                    producto.Stock = Convert.ToInt32(datos["Stock"]);
                                    producto.IDUsuario = Convert.ToInt32(datos["IdUsuario"]);
                                    listaProducto.Add(producto);


                                }
                            }
                        }
                    }
                    Console.WriteLine("Cerrando Conexión");
                    connection.Close();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            return listaProducto;

        }

        public List<ProductoVendido> ConsultaProductoVendido()
        {
            List<ProductoVendido> listaProductoV = new List<ProductoVendido>();

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("Select * from ProductoVendido", connection))
                    {
                        connection.Open();

                        var parametros = new SqlParameter();

                        using (SqlDataReader datos = cmd.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                while (datos.Read())
                                {
                                    ProductoVendido productov = new ProductoVendido();
                                    productov.ID = Convert.ToInt32(datos["Id"]);
                                    productov.Stock = Convert.ToInt32(datos["Stock"]);
                                    productov.IDproducto = Convert.ToInt32(datos["IdProducto"]);
                                    productov.IDVenta = Convert.ToInt32(datos["IdVenta"]);
                                    listaProductoV.Add(productov);


                                }
                            }
                        }
                    }
                    Console.WriteLine("Cerrando Conexión");
                    connection.Close();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            return listaProductoV;
        }

        public List<Venta> ConsultaVenta()
        {
            List<Venta> listaVenta = new List<Venta>();

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("Select * from Venta", connection))
                    {
                        connection.Open();

                        var parametros = new SqlParameter();

                        using (SqlDataReader datos = cmd.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                while (datos.Read())
                                {
                                    Venta v = new Venta();
                                    v.ID = Convert.ToInt32(datos["Id"]);
                                    v.Comentarios = datos["Comentarios"].ToString();
                                    v.IDUsuario = Convert.ToInt32(datos["IdUsuario"]);
                                    listaVenta.Add(v);


                                }
                            }
                        }
                    }
                    Console.WriteLine("Cerrando Conexión");
                    connection.Close();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            return listaVenta;
        }

        public List<inicio> InicioSesion()
        {
            List<inicio> listaSesion = new List<inicio>();

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("Select NombreUsuario, Contraseña from Usuario", connection))
                    {
                        connection.Open();

                        var parametros = new SqlParameter();

                        using (SqlDataReader datos = cmd.ExecuteReader())
                        {
                            if (datos.HasRows)
                            {
                                while (datos.Read())
                                {
                                    inicio user = new inicio();
                                    user.NombreUser = datos["NombreUsuario"].ToString();
                                    user.pass = datos["Contraseña"].ToString();
                                    listaSesion.Add(user);


                                }
                            }
                        }
                    }
                    Console.WriteLine("Cerrando Conexión");
                    connection.Close();


                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);


            }
            return listaSesion;
        }

    }
}
