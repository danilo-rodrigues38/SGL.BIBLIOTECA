using Newtonsoft.Json;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class Acervo
    {
        string folder = "Gravadas";
        string fileName = "biblioteca.json";
        string path = "Gravadas\\biblioteca.json";
        string line;

        public List<Livro> Livros = new List<Livro>();

        public void AdicionarLivro ( )
        {
            try
            {
                Console.Clear ( );
                Console.WriteLine ( "CADASTRO DE LIVRO" );
                Console.WriteLine ( "-----------------\n" );

                var id = Livros.Count + 1;

                Console.Write ( "Digite o título: " );
                var titulo = Console.ReadLine();

                Console.Write ( "Digite o autor: " );
                var autor = Console.ReadLine();

                Console.Write ( "Digite o ISBN: " );
                var isbn = Console.ReadLine();

                Console.Write ( "Digite o ano de publicação do livro: " );
                Console.WriteLine ( "Formato: 1900, 12, 31" );
                var anoPublicacaoString = Console.ReadLine();
                var anoPublicaçãoRecebida = !string.IsNullOrEmpty(anoPublicacaoString) ? anoPublicacaoString : "1900, 1, 1";
                var anoPublicacao = DateTime.Parse(anoPublicaçãoRecebida);

                var livro = new Livro (id, titulo, autor, isbn, anoPublicacao);

                Livros.Add ( livro );

                GravarArquivo ( );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void ExibirLivros ( )
        {
            try
            {
                Console.Clear ( );
                Console.WriteLine ( "               Listagem de livros" );
                Console.WriteLine ( "               ------------------\n" );
                Console.WriteLine ( "Detalhes do Livro:" );

                foreach (var livro in Livros)
                {
                    if ( livro.Ativo == true)
                    {
                        livro.DetalheLivro ( );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void ExibirLivrosInativos ( )
        {
            try
            {
                Console.WriteLine ( "Detalhes do Livro:" );

                foreach (var livro in Livros)
                {
                    if (livro.Ativo == false)
                    {
                        livro.DetalheLivro ( );
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void LocalizarLivroTitulo ( )
        {
            Console.Clear ( );
            try
            {
                Console.Write ( "Digite o título do livro que deseja localizar: " );
                var tituloLivro = Console.ReadLine ( );

                var tituloLivroLocalizar = Livros.Where(l => l.Titulo.ToUpper().Contains(tituloLivro.ToUpper()) && l.Ativo);

                foreach (var livro in tituloLivroLocalizar)
                {
                    livro.DetalheLivro ( );
                }
            }
            catch (Exception ex) { Console.WriteLine ( $"Erro: {ex.Message}" ); }
        }

        public void LocalizarLivroAutor ( )
        {
            Console.Clear ( );
            try
            {
                Console.Write ( "Digite o nome do Autor para localizar os livros: " );

                var nomeAutor = Console.ReadLine ( );

                var autorLocalizado = Livros.Where(a => a.Autor.ToUpper().Contains(nomeAutor.ToUpper()) && a.Ativo);

                foreach (var livro in autorLocalizado)
                {
                    livro.DetalheLivro ( );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( ex.Message );
            }
        }

        public void DeletarLivro ( )
        {
            Console.Clear ( );
            Console.WriteLine ( "Excluir um livro" );
            Console.WriteLine ( "----------------\n" );
            Console.Write ( "Digite o id do livro para excluir: " );
            var idExcluir = int.Parse ( Console.ReadLine () );

            if (Livros.Any ( a => a.Id == idExcluir ))
            {
                Livros[ idExcluir - 1 ].Ativo = false ;
            }
            else
            {
                Console.WriteLine ( "Desculpe, não foi localizado um item com esse id." );
            }

            GravarArquivo ( );
        }

        public void AtivarLivro ( )
        {
            Console.Clear ( );

            try
            {
                Console.WriteLine ( "Ativar um livro" );
                Console.WriteLine ( "----------------\n" );

                ExibirLivrosInativos ( );

                Console.Write ( "Digite o id do livro para ativar: " );

                var idAtivar = int.Parse ( Console.ReadLine () );

                if (Livros.Any ( a => a.Id == idAtivar ))
                {
                    Livros [ idAtivar - 1 ].Ativo = true;
                }
                else
                {
                    Console.WriteLine ( "Desculpe, não foi localizado um item com esse id." );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( "ERRO: " + ex.Message );
            }

            GravarArquivo ( );
        }

        public void CriaArquivo ( )
        {
            DirectoryInfo di = new DirectoryInfo ( folder );

            if (!di.Exists)
            {
                Directory.CreateDirectory ( folder );
            }

            if (!File.Exists ( path ))
            {
                File.WriteAllText ( path, string.Empty );
            }
        }

        public void GravarArquivo ( )
        {
            try
            {
                CriaArquivo ( );

                string serializado = JsonConvert.SerializeObject ( Livros, Formatting.Indented );


                File.WriteAllText( path, serializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( "ERRO: " + ex.Message );
            }
        }

        public void LerArquivo ( )
        {
            Console.Clear ( );
            try
            {
                string deserializado = File.ReadAllText ( path );

                Livros = JsonConvert.DeserializeObject<List<Livro>> ( deserializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( "ERRO: " + ex.Message );
            }
        }
    }
}
