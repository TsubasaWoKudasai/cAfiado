using System.Security.Cryptography;

namespace CrudSimples.Models

{
    public class Cadastro
    {
    private readonly string caminhoArquivo = @"G:\codarrrrr\CSharp\CrudSimples\Data\usuarios.txt";

        // Construtor para definir o caminho do arquivo de dados
        public Cadastro(string caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

         private string GerarHashSenha(string senha)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

        // Método para cadastrar um novo usuário
        public void CadastrarUsuario(Usuario usuario)
        {
            
            if (VerificarEmailExistente(usuario.Email))
            {
                Console.WriteLine("Este email já está cadastrado.");
                return;
            }

            

            string hashSenha = GerarHashSenha(usuario.Senha);
            

            // Adiciona o usuário ao arquivo
            string linha = $"{usuario.Id},{usuario.Name},{usuario.Email},{hashSenha},{usuario.Tipo}";
            File.AppendAllText(caminhoArquivo, linha + Environment.NewLine);
            Console.WriteLine("Usuário cadastrado com sucesso!");
        }

        // Método para carregar todos os usuários do arquivo
    public List<Usuario> CarregarUsuarios()
    {
    if (!File.Exists(caminhoArquivo)) 
    {
        File.Create(caminhoArquivo).Close();  // Cria o arquivo se não existir
        return new List<Usuario>();
    }

    return File.ReadAllLines(caminhoArquivo)
        .Select(linha => linha.Split(','))
        .Where(dados => dados.Length == 5) // Garante que a linha tenha 5 campos
        .Select(dados => new Usuario(int.Parse(dados[0]), dados[1], dados[2], dados[3], dados[4]))
        .ToList();
    }

        // Método para verificar se um email já está cadastrado
        public bool VerificarEmailExistente(string email)
        {
            return CarregarUsuarios().Any(usuario => usuario != null && usuario.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }

        // Método para exibir todos os usuários cadastrados
        public void ExibirUsuarios()
        {
            var usuarios = CarregarUsuarios();
            if (!usuarios.Any())
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
                return;
            }

            foreach (var usuario in usuarios)
            {
             if (usuario != null)  // Verifica se o usuário não é nulo
            {
            Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Name}, Email: {usuario.Email}, Tipo: {usuario.Tipo}");
            usuario.MostrarPermissoes();
            }
            }

        }

               public bool RemoverUsuario(string email)
                {
                var usuarios = CarregarUsuarios();
                var usuarioARemover = usuarios.FirstOrDefault(u => u.Email == email);

                if (usuarioARemover != null)
                {
                    usuarios.Remove(usuarioARemover);
                    AtualizarArquivoUsuarios(usuarios);
                    return true;
                }

                return false;
                }

            public void AtualizarArquivoUsuarios(List<Usuario> usuarios)
            {
                var linhas = usuarios.Select(u => $"{u.Id},{u.Name},{u.Email},{u.Senha},{u.Tipo}");
                File.WriteAllLines(caminhoArquivo, linhas);
        }
    }
}
