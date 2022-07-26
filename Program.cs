// Titulo agregado
namespace Bordando_app
{

    public class Usuario
    {
        private int codigo;
        private string nombre;
        private string apellido;
        private string nombre_usuario;
        private string email;

        public Usuario()
        {
            codigo = 0;
            nombre = String.Empty;
            apellido = String.Empty;
            nombre_usuario = String.Empty;
            email = String.Empty;
        }

        public Usuario(int codigo, string nombre, string apellido, string nombre_usuario, string email)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.nombre_usuario = nombre_usuario;
            this.email = email;
        }


        static void Main(string[] args)
        {
            //Matriz ma = new Matriz();
            Usuario usuario = new Usuario();
            Console.WriteLine("Enter user code: \n");
            usuario.codigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(usuario.codigo);

        }

    }

    public class Tutorial
    {
        private string url;
        private string titulo;
        private string categoria;
        private string nombre_clase;
        private int nivel;

        public Tutorial()
        {
            url = String.Empty;
            titulo = String.Empty;
            categoria = String.Empty;
            nombre_clase = String.Empty;
            nivel = 0;
        }   

        public Tutorial(string url, string titulo, string categoria, string nombre_clase, int nivel)
        {
            this.url = url;
            this.titulo = titulo;
            this.categoria = categoria;
            this.nombre_clase = nombre_clase;
            this.nivel = nivel;
        }
    }

    public class Inventario
    {
        private int codigo;
        private int cantidad;
        private string nombre;
        private string marca;
        private string categoria;

        public Inventario()
        {
            codigo = 0;
            cantidad = 0;
            nombre = String.Empty;
            marca = String.Empty;
            categoria = String.Empty;
        }

        public Inventario(int codigo, int cantidad, string nombre, string marca, string categoria)
        {
            this.codigo = codigo;
            this.cantidad = cantidad;
            this.nombre = nombre;
            this.marca = marca;
            this.categoria = categoria;
        }
    }

    public class Proyectos
    {
        private string fecha;
        private string nivel;
        private string nombre;
        private string material;
        private string estatus;

        public Proyectos()
        {
            fecha = String.Empty;
            nivel = String.Empty;
            nombre = String.Empty;  
            material = String.Empty;
            estatus = String.Empty; 
        }

        public Proyectos(string fecha, string nivel, string nombre, string material, string estatus)
        {
            this.fecha = fecha;
            this.nivel = nivel;
            this.nombre = nombre;
            this.material = material;
            this.estatus = estatus;
        }
    }

    public class ProbarCosas
    { 


    }

    
    

}
