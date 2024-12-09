using BibliotecaLivros.Models;

class Program 
{
    static void Main(string[] args)
    {
        var biblioteca = new Biblioteca();

        biblioteca.AdicionarLivro(new Livro("LOTR", "Tolkien"));

        foreach (var livro in biblioteca.ListarLivros())
        {
            Console.WriteLine($"Titulo : {livro.Titulo}, autor: {livro.Autor}");
        }
    }
}