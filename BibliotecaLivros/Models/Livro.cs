namespace BibliotecaLivros.Models;

public class Livro(string Titulo, string Autor)
{
    public string? Titulo { get; set; } = Titulo;
    public string? Autor { get; set; } = Autor;
}