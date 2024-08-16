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

        public int Id { get; set; }
        public Usuario UsuarioId { get; set; }
        public List<Livro> LivroList { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolução { get; set; }
    }
}
