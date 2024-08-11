namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class Usuario
    {
        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Ativo = true;
        }

        public int Id { get; set; }
        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public bool Ativo { get; set; }

        public void DetalheUsuario ( )
        {
            Console.WriteLine ( "" );
            Console.WriteLine ( $"Id: {Id}" );
            Console.WriteLine ( $"Título: {Nome}" );
            Console.WriteLine ( $"Autor: {Email}" );
        }
    }
}
