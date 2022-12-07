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

        //Agregado

        public int AgregaProducto(Producto producto)
        {

            try
            {
                int retorno = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES (@desc,@costo,@preciov,@stock,@iduser);", connection))
                    {
                        connection.Open();

                        cmd.Parameters.Add(new SqlParameter("desc", SqlDbType.VarChar) { Value = producto.Descripcion });
                        cmd.Parameters.Add(new SqlParameter("costo", SqlDbType.VarChar) { Value = producto.Costo });
                        cmd.Parameters.Add(new SqlParameter("preciov", SqlDbType.VarChar) { Value = producto.PrecioVenta });
                        cmd.Parameters.Add(new SqlParameter("stock", SqlDbType.VarChar) { Value = producto.Stock });
                        cmd.Parameters.Add(new SqlParameter("iduser", SqlDbType.VarChar) { Value = producto.IDUsuario });

                        retorno = cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                        //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                        //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // Console.WriteLine("Cerrando Conexión");

                    connection.Close();

                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }

        }

        public int AgregaUsuario(Usuario usuario)
        {

            try
            {
                int retorno = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES (@nombre,@apellido,@nuser,@pass,@mail);", connection))
                    {
                        connection.Open();
                        cmd.Parameters.Add(new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                        cmd.Parameters.Add(new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                        cmd.Parameters.Add(new SqlParameter("nuser", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                        cmd.Parameters.Add(new SqlParameter("pass", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                        cmd.Parameters.Add(new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Email });

                        retorno = cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                        //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                        //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // Console.WriteLine("Cerrando Conexión");

                    connection.Close();

                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }

        }

        //Eliminado
        public int EliminaUsuario(int id)
        {

            try
            {
                int retorno = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("DELETE FROM Usuario WHERE Id = @id ", connection))
                    {
                        connection.Open();

                        cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int) { Value = id });
                        retorno = cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                        //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                        //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // Console.WriteLine("Cerrando Conexión");

                    connection.Close();

                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }

        }

        public int EliminaProducto(int id)
        {

            try
            {
                int retorno = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    connection.Open();

                    using (var cmd = new SqlCommand("DELETE FROM ProductoVendido WHERE IdProducto = @id ", connection))
                    {

                        cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int) { Value = id });
                        retorno += cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                                                          //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                                                          //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    using (var cmd = new SqlCommand("DELETE FROM Producto WHERE Id = @id ", connection))
                    {

                        cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int) { Value = id });
                        retorno += cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                                                          //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                                                          //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    connection.Close();

                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }

        }

        //Modificacion
        public int ModificaUsuario(Usuario usuario)
        {

            try
            {
                int retorno = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("UPDATE Usuario SET Nombre=@nombre, Apellido=@apellido, NombreUsuario=@nuser, Contraseña=@pass, Mail=@mail WHERE Id = @id ", connection))
                    {
                        connection.Open();

                        cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int) { Value = usuario.ID });
                        cmd.Parameters.Add(new SqlParameter("pass", SqlDbType.VarChar) { Value = usuario.Contrasenia });
                        cmd.Parameters.Add(new SqlParameter("nuser", SqlDbType.VarChar) { Value = usuario.NombreUsuario });
                        cmd.Parameters.Add(new SqlParameter("nombre", SqlDbType.VarChar) { Value = usuario.Nombre });
                        cmd.Parameters.Add(new SqlParameter("apellido", SqlDbType.VarChar) { Value = usuario.Apellido });
                        cmd.Parameters.Add(new SqlParameter("mail", SqlDbType.VarChar) { Value = usuario.Email });
                        retorno = cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                        //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                        //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // Console.WriteLine("Cerrando Conexión");

                    connection.Close();

                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }

        }

        public int ModificaProducto(Producto producto)
        {

            try
            {
                int retorno = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    using (var cmd = new SqlCommand("UPDATE Producto SET Descripciones = @desc, Costo=@costo, PrecioVenta=@preciov, Stock=@stock, IdUsuario = @iduser WHERE Id = @id ", connection))
                    {
                        connection.Open();

                        cmd.Parameters.Add(new SqlParameter("desc", SqlDbType.VarChar) { Value = producto.Descripcion });
                        cmd.Parameters.Add(new SqlParameter("costo", SqlDbType.Int ){ Value = producto.Costo });
                        cmd.Parameters.Add(new SqlParameter("preciov", SqlDbType.Int) { Value = producto.PrecioVenta });
                        cmd.Parameters.Add(new SqlParameter("stock", SqlDbType.Int) { Value = producto.Stock });
                        cmd.Parameters.Add(new SqlParameter("iduser", SqlDbType.Int) { Value = producto.IDUsuario });
                        cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int) { Value = producto.ID });
                        
                        retorno = cmd.ExecuteNonQuery(); //Se utiliza cuando no se devuelve ningun valor DE LA BASE DE DATOS
                        //cmd.ExecuteScalar();//Se utiliza cuando se necesita devolver un valor
                        //retorno = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    // Console.WriteLine("Cerrando Conexión");

                    connection.Close();

                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }

        }

        public int cargaVenta(List<ProductoVendido> productov, int idUser)
        {
            try
            {
                int retorno = 0;
                int stock = 0;
                int ultimoID = 0;
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    Console.WriteLine("Abriendo Conexión");

                    connection.Open();
                    


                    
                    foreach (ProductoVendido product in productov)
                    {
                        //primero verificamos que tengamos stock para efectuar la carga del producto vendido
                        using (var cmd = new SqlCommand("SELECT Stock FROM Producto WHERE Id=@id", connection))
                        {
                            var parametro = new SqlParameter();
                            parametro.ParameterName = "id";
                            parametro.SqlDbType = SqlDbType.Int;
                            parametro.Value = product.IDproducto;
                            cmd.Parameters.Add(parametro);

                            using (SqlDataReader datos = cmd.ExecuteReader())
                            {
                                if (datos.HasRows)
                                {
                                    while (datos.Read())
                                    {
                                        stock = Convert.ToInt32(datos["Stock"]);
                                        //Console.WriteLine("El stock es {0}", stock);
                                    }
                                }
                            }
                        }

                        if (stock < product.Stock)
                        {
                            return 0;
                        }

                        //EN CASO DE QUE ESTÉ EL STOCK DISPONIBLE, PROCEDEMOS A CARGAR EN LA TABLA DE VENTAS

                        using (var cmd = new SqlCommand("INSERT INTO Venta(Comentarios, IdUsuario) VALUES (@comentarios, @idUser); SELECT @@IDENTITY", connection))
                        {
                            Venta venta = new Venta();
                            venta.IDUsuario = idUser;
                            venta.Comentarios = "";
                            venta.ID = product.IDVenta;
                            //cmd.Parameters.Add(new SqlParameter("id", SqlDbType.VarChar) { Value = venta.ID });
                            cmd.Parameters.Add(new SqlParameter("comentarios", SqlDbType.VarChar) { Value = venta.Comentarios });
                            cmd.Parameters.Add(new SqlParameter("idUser", SqlDbType.Int) { Value = venta.IDUsuario });
                            //retorno = cmd.ExecuteNonQuery(); 
                            ultimoID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        //LUEGO PROCEDEMOS A INSERTAR EN LA TABLA PRODUCTO VENDIDO

                        using (var cmd = new SqlCommand("INSERT INTO ProductoVendido(Stock, IdProducto, IdVenta) VALUES (@stock,@idprod,@idventa)", connection))
                        {
                            product.IDVenta = ultimoID;
                            cmd.Parameters.Add(new SqlParameter("stock", SqlDbType.Int) { Value = product.Stock });
                            cmd.Parameters.Add(new SqlParameter("idprod", SqlDbType.Int) { Value = product.IDproducto });
                            cmd.Parameters.Add(new SqlParameter("idventa", SqlDbType.Int) { Value = product.IDVenta });
                            retorno = cmd.ExecuteNonQuery();
                        }

                        //POR ULTIMO ACTUALIZAMOS EL STOCK DE LA TABLA PRODUCTO

                        using (var cmd = new SqlCommand("UPDATE Producto SET Stock = @nstock WHERE Id = @id", connection))
                        {
                            cmd.Parameters.Add(new SqlParameter("id", SqlDbType.Int) { Value = product.IDproducto });
                            cmd.Parameters.Add(new SqlParameter("nstock", SqlDbType.Int) { Value = stock - product.Stock });
                            retorno = cmd.ExecuteNonQuery();
                        }



                    }


                    Console.WriteLine("Cerrando Conexión");
                    connection.Close();


                }

                return retorno;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;

            }
        }

    }
}


