namespace SGL.BIBLIOTECA.ConsoleApp.Models
{
    public class Emprestimo
    {
        public Emprestimo(int id, Usuario usuarioId, List<Livro> livroList)
        {
            Id = id;
            UsuarioId = usuarioId;
            LivroList = livroList;
            DataEmprestimo = DateTime.Now;
            DataDevolução = DateTime.Today.AddDays(15);
        }

        public int Id { get; protected set; }
        public Usuario UsuarioId { get; protected set; }
        public List<Livro> LivroList { get; protected set; }
        public DateTime DataEmprestimo { get; protected set; }
        public DateTime DataDevolução { get; protected set; }
    }
}
