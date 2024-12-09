using CrudSimples.Models;

class Program
{
    static void Main()
    {
        // Configurar o caminho do arquivo
        string caminhoArquivo = Path.Combine("Data", "usuarios.txt");

        // Garantir que o diretório existe
        string diretorio = Path.GetDirectoryName(caminhoArquivo)!;
        if (!Directory.Exists(diretorio))
        {
            Directory.CreateDirectory(diretorio);
        }

        // Instanciar a classe Cadastro
        var cadastro = new Cadastro(caminhoArquivo);

        // Instanciar a classe Gerenciamento com a dependência de Cadastro
        var gerenciamento = new Gerenciamento(cadastro);

        // Chamar o menu de gerenciamento
        gerenciamento.Menu();
    }
}
