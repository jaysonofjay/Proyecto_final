using System.Security;

namespace PrimeraEntrega
{
    public class ProbarObjetos
    {
        static void Main(string[] args)
        {
            /*  Ejemplo de login valido  usuario:[tcasazza]  password:[SoyTobiasCasazza]  */
            Console.WriteLine("\t\t | SISTEMA DE GESTION |  \n\n");
            Console.WriteLine("\t\t\t  1. Login. \n");
            Console.WriteLine("\t\t\t  2. Exit. \n");
            int option = Convert.ToInt32(Console.ReadLine());
            if (option == 1)
            {
                //UsuarioHandler usuarioHandler = new UsuarioHandler();
                int login_limit = 3; 
                for (int i = 1; i <= 3; i++)
                {
                    Console.Clear();
                    // call UserLogin metod from  UsuariosHandler
                    Console.WriteLine("\n  Enter User Name:");
                    string user_name = Console.ReadLine();

                    Console.WriteLine("\n");
                    SecureString pass = MaskInputString();
                    string user_pw = new System.Net.NetworkCredential(String.Empty, pass).Password;

                    bool passwordValidation = UsuarioHandler.LoginUser(user_name, user_pw);
                    if (passwordValidation)
                    {
                    loop:
                        Console.Clear();    
                        Console.WriteLine("\t\t\t WELCOME ");

                        // imprimir metodos 
                        Console.WriteLine("\t  Este es el menu de seleccion para probar los metodos implementados en ADO.NET \n");
                        Console.WriteLine("\t  1. Traer Usuarios. \n");
                        Console.WriteLine("\t  2. Traer Productos. \n");
                        Console.WriteLine("\t  3. Traer ProductosVendidos. \n");
                        Console.WriteLine("\t  4. Traer Ventas. \n");
                        Console.WriteLine("\t  0. Exit. \n");
                        int seleccion = Convert.ToInt32(Console.ReadLine());
                        
                        while(seleccion != 0)
                        {
                            
                            if (seleccion == 1) {

                                Console.WriteLine("Todos los Usuarios: \n");
                                UsuarioHandler usuarioHandler = new UsuarioHandler();
                                usuarioHandler.GetUsuarios().ForEach(x => Console.WriteLine($"{x.Id}, {x.NombreUsuario}, {x.Mail}"));
                                Console.WriteLine("\n");
                                Console.WriteLine("Desea continuar? (Y/N) \n");
                                char continua = Convert.ToChar(Console.ReadLine());
                                if (continua == 'N' || continua == 'n') { seleccion = 0; } else { goto loop;}



                            }

                            if (seleccion == 2)
                            {
                                Console.WriteLine("Todos los productos: \n");
                                ProductoHandler productoHandler = new ProductoHandler();
                                productoHandler.GetProductos().ForEach(x => Console.WriteLine($"{x.Id}, {x.Stock}, {x.PrecioVenta}, {x.Descripciones}"));
                                Console.WriteLine("\n");
                                Console.WriteLine("Desea continuar? (Y/N) \n");
                                char continua = Convert.ToChar(Console.ReadLine());
                                if (continua == 'N' || continua == 'n') { seleccion = 0; } else { goto loop; }

                            }
                            
                            if (seleccion == 3)
                            {
                                Console.WriteLine("Todos los Productos Vendidos: \n");
                                ProductosVendidosHandler productosVendidosHandler = new ProductosVendidosHandler();
                                productosVendidosHandler.GetProductosVendidos().ForEach(x => Console.WriteLine($"{x.Id}, {x.Stock}, {x.IdProducto}, {x.IdVenta}"));
                                Console.WriteLine("Desea continuar? (Y/N) \n");
                                char continua = Convert.ToChar(Console.ReadLine());
                                if (continua == 'N' || continua == 'n') { seleccion = 0; } else { goto loop; }

                            }

                            if (seleccion == 4)
                            {
                                Console.WriteLine("Todas los Ventas: \n");
                                VentaHandler ventaHandler = new VentaHandler();
                                ventaHandler.GetVentas().ForEach(x => Console.WriteLine($"{x.Id}, {x.Comentarios}"));
                                Console.WriteLine("Desea continuar? (Y/N) \n");
                                char continua = Convert.ToChar(Console.ReadLine());
                                if (continua == 'N' || continua == 'n') { seleccion = 0; } else { goto loop; }

                            }

                        }
                        // Console app
                        Console.WriteLine("\n\n Bye Bye!");
                        System.Environment.Exit(1);


                    }
                    else {
                        Console.WriteLine($"\t\t\t Password incorrecto! te quedan {login_limit - i} intentos");
                        int sleepTime = 3000; // in mills
                        Task.Delay(sleepTime).Wait();

                    }
                }

                // Console app
                System.Environment.Exit(1);
            }
            else
            {
                // Console app
                System.Environment.Exit(1);

            }





            //Console.WriteLine("Todos las Ventas: \n");
            //VentaHandler ventaHandler = new VentaHandler();
            //ventaHandler.GetVentas();
            //Console.WriteLine("\n");

            //Console.WriteLine("Todos los Productos Vendidos: \n");
            //ProductosVendidosHandler productosVendidos = new ProductosVendidosHandler();
            //productosVendidos.GetProductosVendidos();
            //Console.WriteLine("\n");


            


        }



        private static SecureString MaskInputString()
        {
            Console.WriteLine("Password: ");
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    pass.RemoveAt(pass.Length - 1);
                    Console.Write("\b \b");
                }

            }
            while (keyInfo.Key != ConsoleKey.Enter);
            return pass;


        }
    }
}