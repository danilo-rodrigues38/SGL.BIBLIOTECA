using Newtonsoft.Json;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class EmprestimoManager
    {
        List<Livro> livros = new List<Livro>();
        List<Usuario> usuarios = new List<Usuario>();
        List<Emprestimo> emprestimos = new List<Emprestimo>();

        string folder = "Gravadas";
        string fileName = "emprestimo.json";
        string pathLivros = "Gravadas\\biblioteca.json";
        string pathUsuarios = "Gravadas\\usuario.json";
        string pathEmprestimos = "Gravadas\\emprestimo.json";

        public void RecebeTodosLivros()
        {
            string deserializado = File.ReadAllText(pathLivros);

            livros = JsonConvert.DeserializeObject<List<Livro>>(deserializado);
        }

        public void RecebeTodosUsuarios()
        {
            string deserializado = File.ReadAllText(pathUsuarios);

            usuarios = JsonConvert.DeserializeObject<List<Usuario>>(deserializado);
        }

        public void EmprestarLivro()
        {
            try
            {
                var livroList = new List<Livro>();

                var id = emprestimos.Count + 1;

                #region Localizar Usu�rio

                Console.Write("Digite o nome do usu�ro: ");
                var nomeUsuario = Console.ReadLine();

                var usuariosLocalizados = usuarios.Where(u => u.Nome.ToUpper().Contains(nomeUsuario.ToUpper()) && u.Ativo);

                foreach (var usuarioLocalizado in usuariosLocalizados)
                {
                    usuarioLocalizado.DetalheUsuario();
                }

                Console.Write("\nAgora, digite o id do usuario: ");
                var usuarioIdLocalizar = int.Parse(Console.ReadLine());

                var usuarioId = usuarios.Find(i => i.Id == usuarioIdLocalizar);

                #endregion

                #region Localizar Livros

                var resp = true;

                do
                {
                    Console.Write("\nAgora digite o nome do livro que deseja: ");
                    var livroescolhido = Console.ReadLine();

                    var livrosAchados = livros.Where(a => a.Titulo.ToUpper().Contains(livroescolhido.ToUpper()) && a.Ativo);

                    foreach (var livrolocalizado in livrosAchados)
                    {
                        livrolocalizado.DetalheLivro();
                    }

                    Console.Write("\nAgora, digite o id do livro: ");
                    var livroId = int.Parse(Console.ReadLine());

                    var adicionarLivro = livros.Find(l => l.Id == livroId);

                    livroList.Add(adicionarLivro);

                    #endregion


                    Console.WriteLine("\nQuer procurar mais algum livro? [ Sim ou N�o ]");
                    var resposta = Console.ReadLine().ToLower();

                    if (resposta == "n" || resposta == "nao" || resposta == "n�o")
                    {
                        resp = false;
                    }

                } while (resp);

                var emprestimo = new Emprestimo(id, usuarioId, livroList);

                emprestimos.Add(emprestimo);

                GravarArquivo();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void DevolverLivro()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        public void CriarArquivo()
        {
            try
            {
                DirectoryInfo di = new DirectoryInfo(folder);

                if (!di.Exists)
                {
                    Directory.CreateDirectory(folder);
                }

                if (!File.Exists(pathEmprestimos))
                {
                    File.WriteAllText(pathEmprestimos, string.Empty);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.ToString()}");
            }
        }

        public void GravarArquivo()
        {
            try
            {
                CriarArquivo();

                string serializado = JsonConvert.SerializeObject(emprestimos, Formatting.Indented);

                File.WriteAllText(pathEmprestimos, serializado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.ToString()}");
            }
        }
    }
}