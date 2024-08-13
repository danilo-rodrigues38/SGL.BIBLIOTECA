namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class UsuarioManager
    {
        List<Usuario> usuarios = new List<Usuario>();

        public void AdicionarUsuario()
        {
            Console.Clear();
            Console.WriteLine("          CADASTRO DE USUÁRIO          ");
            Console.WriteLine("---------------------------------------\n");

            var id = usuarios.Count + 1;

            Console.Write("Digite o nome completo: ");
            var nome = Console.ReadLine();

            Console.Write("Digite o e-mail: ");
            var email = Console.ReadLine();

            var usuario = new Usuario(id, nome, email);

            usuarios.Add(usuario);
        }

        public void ListarUsuario()
        {
            Console.Clear();
            Console.WriteLine("            LISTA DE USUÁRIO           ");
            Console.WriteLine("---------------------------------------\n");

            foreach (var usuario in usuarios)
            {
                usuario.DetalheUsuario();
            }
        }
    }
}