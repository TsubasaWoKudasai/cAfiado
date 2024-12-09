namespace CrudSimples.Models{
public static class Utils
{
    // Gera o próximo ID com base no maior ID existente
    public static int GerarNovoId()
    {
        string caminhoArquivo = @"G:\codarrrrr\CSharp\CrudSimples\Data\usuarios.txt";
        int novoId = 1;

        if (File.Exists(caminhoArquivo))
        {
            var linhas = File.ReadAllLines(caminhoArquivo);
            if (linhas.Length > 0)
            {
                novoId = linhas.Max(linha => int.Parse(linha.Split(',')[0])) + 1; // Extrai o maior ID e adiciona 1
            }
        }

        return novoId;
    }
}
}