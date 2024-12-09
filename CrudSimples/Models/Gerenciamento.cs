namespace CrudSimples.Models
{
    public class Gerenciamento
    {
        private readonly Cadastro _cadastro;

        public Gerenciamento(Cadastro cadastro)
        {
            _cadastro = cadastro;
        }


        // Método para cadastrar um novo usuário
        public void CadastrarUsuario()
        {
            Console.WriteLine("=== Cadastro de Novo Usuário ===");

            int id = Utils.GerarNovoId();

            Console.Write("Digite o nome do usuário: ");
            string name = Console.ReadLine()!;

            Console.Write("Digite o email do usuário: ");
            string email = Console.ReadLine()!;

            Console.Write("Digite a senha do usuário: ");
            string senha = Console.ReadLine()!;

            Console.Write("Digite o tipo do usuário: ");
            string tipo = Console.ReadLine()!;

            var usuario = new Usuario(id, name, email, senha, tipo);

            _cadastro.CadastrarUsuario(usuario);
        }

        // Método para exibir todos os usuários cadastrados
        public void ExibirUsuarios()
        {
            Console.WriteLine("=== Usuários Cadastrados ===");
            _cadastro.ExibirUsuarios();
        }

        // Método para procurar usuários por email
        public void ProcurarUsuarioPorEmail()
        {
            Console.WriteLine("=== Procurar Usuário por Email ===");
            Console.Write("Digite o email do usuário: ");
            string email = Console.ReadLine()!;

            var usuarios = _cadastro.CarregarUsuarios();
            var usuarioEncontrado = usuarios.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (usuarioEncontrado != null)
            {
                Console.WriteLine($"Usuário encontrado: {usuarioEncontrado.Name} (ID: {usuarioEncontrado.Id})");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }

        // Exibe o menu de usuario logado, sendo admin ou comum
        public void ExibirMenu(Usuario usuarioLogado)
        {
            Console.Clear();
            Console.WriteLine($"Bem-vindo, {usuarioLogado.Name}!");

            // Definindo as opções e suas exibições amigáveis
            Dictionary<string, string> opcoesExibicao = new Dictionary<string, string>
            {
                { "1", "Remover usuário" },
                { "2", "Deslogar" }
            };

            // Exibindo as opções
            ExibirOpcoes(opcoesExibicao);

            // Usando o dicionário de ações para mapear as opções numéricas
            Dictionary<string, Action> opcoes = new Dictionary<string, Action>
            {
                { "1", () => {
                    Console.WriteLine("Digite o email do usuário que deseja remover:");
                    string email = Console.ReadLine()!;
                    if (_cadastro.RemoverUsuario(email))
                        Console.WriteLine("Usuário removido com sucesso.");
                    else
                        Console.WriteLine("Usuário não encontrado.");
                        }},
                        { "2", Deslogar }
            };

            // Escolhendo a opção do usuário
            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine()!;

            // Executando a ação correspondente à escolha
            if (opcoes.TryGetValue(escolha, out Action? acao))
            {
                Console.Clear();
                acao.Invoke();  // Executa a ação associada à opção
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
        }

        static void ExibirOpcoes(Dictionary<string, string> opcoesExibicao)
        {
            foreach (var opcao in opcoesExibicao)
            {
                Console.WriteLine($"{opcao.Key} - {opcao.Value}");
            }
        }

        static void Deslogar()
        {
            Console.WriteLine("Você foi deslogado com sucesso.");
            // Retorne ao menu inicial ou finalize a aplicação
        }

        // Método para iniciar o menu de gerenciamento
        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n=== Menu de Gerenciamento ===");
                Console.WriteLine("1. Cadastrar Novo Usuário");
                Console.WriteLine("2. Exibir Todos os Usuários");
                Console.WriteLine("3. Procurar Usuário por Email");
                Console.WriteLine("4. Realizar Login");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                while (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Digite um número inteiro:");
                }

                switch (opcao)
                {
                    case 1:
                        CadastrarUsuario();
                        break;
                    case 2:
                        ExibirUsuarios();
                        break;
                    case 3:
                        ProcurarUsuarioPorEmail();
                        break;
                    case 4:
                        Console.WriteLine("=== Login ===");

                        Console.WriteLine("Digite o e-mail:");
                        string email = Console.ReadLine()!;
                        Console.WriteLine("Digite a senha:");
                        string senha = Console.ReadLine()!;

                        var login = new Login();
                        var usuarioLogado = login.RelizarLogin(email, senha);
                        
                        if (usuarioLogado != null)
                        {
                            Console.WriteLine($"Bem-vindo, {usuarioLogado.Name}! Seu tipo de usuário é: {usuarioLogado.Tipo}");
                            ExibirMenu(usuarioLogado);
                        }
                        else
                        {
                        Console.WriteLine("Login inválido! Verifique suas credenciais.");
                        }
                        break;
                    case 0:
                        Console.WriteLine("Saindo do sistema...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            } while (opcao != 0);
        }
    }
}
