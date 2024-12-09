using System.Security.Cryptography;

namespace CrudSimples.Models
{
    public class Login
    {
        private const string arquivoUsuarios = @"G:\codarrrrr\CSharp\CrudSimples\Data\usuarios.txt";

        // Realiza login verificando email e senha
        public Usuario? RelizarLogin(string email, string senha)
        {
            // Se o arquivo de usuários não existir, retorna erro
            if (!File.Exists(arquivoUsuarios))
            {
                Console.WriteLine("Arquivo de usuários não encontrado.");
                return null;
            }

            // Procura o usuário pelo email de forma mais eficiente
            var usuarioEncontrado = File.ReadLines(arquivoUsuarios)
                                         .FirstOrDefault(u => u.Split(',')[2] == email); // A busca agora é pelo email, que é a 3ª coluna

            // Se o usuário não for encontrado, retorna erro
            if (usuarioEncontrado == null)
            {
                Console.WriteLine("Usuário não encontrado.");
                return null;
            }

            // Extrai o hash da senha armazenada e realiza a verificação
            var dados = usuarioEncontrado.Split(',');
            var hashSenhaArmazenada = dados[3]; // A senha é o 4º valor no arquivo

             if (!VerificarSenha(senha, hashSenhaArmazenada))
            {
                Console.WriteLine("Senha incorreta.");
                return null;
            }
             return new Usuario(
                int.Parse(dados[0]), // ID
                dados[1],            // Nome
                dados[2],            // Email
                dados[3],            // Senha
                dados[4]             // Tipo (comum, admin)
            );
        }
        
        // Gera o hash da senha utilizando o algoritmo SHA256
        static string GerarHashSenha(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        // Verifica se a senha fornecida corresponde ao hash armazenado
        private bool VerificarSenha(string senha, string hashSenhaArmazenada)
        {
            var hashSenhaFornecida = GerarHashSenha(senha);
            return hashSenhaFornecida == hashSenhaArmazenada;
        }
    }
}
