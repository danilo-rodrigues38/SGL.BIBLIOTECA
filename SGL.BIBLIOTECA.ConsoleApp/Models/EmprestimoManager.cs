using Newtonsoft.Json;
using System.Collections.Immutable;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class EmprestimoManager
    {
        readonly string folder = "Gravadas";
        readonly string pathLivros = "Gravadas\\biblioteca.json";
        readonly string pathUsuarios = "Gravadas\\usuario.json";
        readonly string pathEmprestimos = "Gravadas\\emprestimo.json";

        List<Livro> livros = [];
        List<Usuario> usuarios = [];
        List<Emprestimo> emprestimos = [];

        public void RecebeTodosLivros ( )
        {
            string deserializado = File.ReadAllText(pathLivros);

            livros = JsonConvert.DeserializeObject<List<Livro>> ( deserializado );
        }

        public void RecebeTodosUsuarios ( )
        {
            string deserializado = File.ReadAllText(pathUsuarios);

            usuarios = JsonConvert.DeserializeObject<List<Usuario>> ( deserializado );
        }

        public void EmprestarLivro ( )
        {
            try
            {
                var livroList = new List<Livro>();

                var id = emprestimos.Count + 1;

                #region Localizar Usuario

                Console.Write ( "Digite o nome do usuario: " );
                var nomeUsuario = Console.ReadLine ( );

                var usuariosLocalizados = usuarios.Where(u => u.Nome.Contains ( nomeUsuario, StringComparison.CurrentCultureIgnoreCase ) && u.Ativo);

                foreach (var usuarioLocalizado in usuariosLocalizados)
                {
                    usuarioLocalizado.DetalheUsuario ( );
                }

                Console.Write ( "\nAgora, digite o id do usuario: " );
                var usuarioIdLocalizar = int.Parse(Console.ReadLine ( ));

                var usuarioId = usuarios.Find ( i => i.Id == usuarioIdLocalizar );

                #endregion

                #region Localizar Livros

                var resp = true;

                do
                {
                    Console.Write ( "\nAgora digite o nome do livro que deseja: " );
                    var livroescolhido = Console.ReadLine ( );

                    var livrosAchados = livros.Where ( a => a.Titulo.Contains ( livroescolhido, StringComparison.CurrentCultureIgnoreCase ) && a.Ativo );

                    foreach (var livrolocalizado in livrosAchados)
                    {
                        livrolocalizado.DetalheLivro ( );
                    }

                    Console.Write ( "\nAgora, digite o id do livro: " );
                    var livroId = int.Parse(Console.ReadLine ( ));

                    var adicionarLivro = livros.Find ( l => l.Id == livroId );

                    if (livroList.Count < 3 )
                    {
                        livroList.Add ( adicionarLivro );
                    }
                    else
                    {
                        Console.WriteLine ( "\nLimite máximo de empréstimos por pessoa, é limitado a três livros." );
                        Console.WriteLine ( "\nTecle ENTER para sair." );
                        Console.ReadLine ();

                        GravarArquivo ( id, usuarioId, livroList );

                        return;
                    }

                    #endregion


                    Console.WriteLine ( "\nQuer procurar mais algum livro? [ Sim ou Nao ]" );
                    var resposta = Console.ReadLine ( ).ToLower ( );

                    if (resposta == "n" || resposta == "nao" || resposta == "n�o")
                    {
                        resp = false;
                    }

                } while (resp);

                GravarArquivo ( id, usuarioId, livroList );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void ListarTodosEmprestimos ( )
        {
            Console.WriteLine ( "Listagem dos usuário com empréstimos ativos.\n" );

            foreach (var emprestimo in emprestimos)
            {
                var i = 1;
                Console.WriteLine ( $"\nEmpréstimo: Id nº {emprestimo.Id}" );
                Console.WriteLine ( $"--------------------\n" );
                Console.WriteLine ( $"     Usuário: {emprestimo.UsuarioId.Nome}" );

                foreach (var nomeLivro in emprestimo.LivroList)
                {
                    Console.WriteLine ( $"          Livro {i}: {nomeLivro.Titulo}" );
                    i++;
                }
            }

            Console.ReadKey ( );
            
        }

        public void DevolverLivro ( )
        {
            try
            {
                Console.Write ( "Digite o id do empréstimo: " );
                var idEmprestimo = int.Parse ( Console.ReadLine ( ) );

                emprestimos.RemoveAll ( i => i.Id == idEmprestimo );

                SalvarArquivo ( );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void CriarArquivo ( )
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo ( folder );

                if (!di.Exists)
                {
                    Directory.CreateDirectory ( folder );
                }

                if (!File.Exists ( pathEmprestimos ))
                {
                    File.WriteAllText ( pathEmprestimos, string.Empty );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void GravarArquivo ( int id, Usuario usuarioId, List<Livro> livroList )
        {
            try
            {
                CriarArquivo ( );

                var emprestimo = new Emprestimo ( id, usuarioId, livroList );

                emprestimos.Add ( emprestimo );

                string serializado = JsonConvert.SerializeObject ( emprestimos, Formatting.Indented );

                File.WriteAllText ( pathEmprestimos, serializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void SalvarArquivo ( )
        {
            try
            {
                string serializado = JsonConvert.SerializeObject ( emprestimos, Formatting.Indented );

                File.WriteAllText ( pathEmprestimos, serializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }

        public void LerArquivo ( )
        {
            try
            {
                string deserializado = File.ReadAllText ( pathEmprestimos );

                emprestimos = JsonConvert.DeserializeObject<List<Emprestimo>> ( deserializado );
            }
            catch (Exception ex)
            {
                Console.WriteLine ( $"Erro: {ex.Message}" );
            }
        }
    }
}