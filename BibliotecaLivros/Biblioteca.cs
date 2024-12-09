namespace BibliotecaLivros.Models
{
    public class Biblioteca
    {
        private readonly List<Livro> livros = new List<Livro>();

        public void AdicionarLivro (Livro livro)
        {
            livros.Add(livro);
        }

        public List<Livro> ListarLivros()
        {
            return livros;
        }
    }
}