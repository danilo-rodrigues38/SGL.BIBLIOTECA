using Newtonsoft.Json;

namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class EmprestimoManager
    {
        List<Livro> livros = new List<Livro>();
        List<Usuario> usuarios = new List<Usuario>();

        string pathLivros = "Gravadas\\biblioteca.json";
        string pathUsuarios = "Gravadas\\usuario.json";
        string pathEmprestimos = "Gravadas\\Emprestimo.json";

        public void RecebeTodosLivros()
        {
            string deserializado = File.ReadAllText(pathLivros);

            livros = JsonConvert.DeserializeObject<List<Livro>> (deserializado);
        }

        public void RecebeTodosUsuarios()
        {
            string deserializado = File.ReadAllText(pathUsuarios);

            usuarios = JsonConvert.DeserializeObject<List<Usuario>>(deserializado);
        }
    }
}