namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class Livro
    {
        public Livro ( int id, string titulo, string autor, string isbn, DateTime dataPublicacao )
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Isbn = isbn;
            DataPublicacao = dataPublicacao;
            Ativo = true;
        }

        public int Id { get; protected set; }
        public string Titulo { get; protected set; }
        public string Autor { get; protected set; }
        public string Isbn { get; protected set; }
        public DateTime DataPublicacao { get; protected set; }
        public bool Ativo { get; set; }

        public void DetalheLivro ( )
        {
            Console.WriteLine ( "" );
            Console.WriteLine ( $"Id: {Id}" );
            Console.WriteLine ( $"Título: {Titulo}" );
            Console.WriteLine ( $"Autor: {Autor}" );
            Console.WriteLine ( $"ISBN: {Isbn}" );
            Console.WriteLine ( $"Ano de Publicação: {DataPublicacao.ToShortDateString ( )}" );
        }
    }
}
