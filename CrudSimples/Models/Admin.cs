    // subclasse adm
    using System.Security.Cryptography;
namespace CrudSimples.Models{

public class Admin : Usuario 
{
    public Admin(int id, string name, string email, string senha, string tipo) : base(id, name, email, senha, tipo) { }
    
// metodo de permissoes do usuario adm

        public override void MostrarPermissoes()
    {
       Console.WriteLine($"Administrador {Name} possui permissoes avançadas: pode gerenciar usuarios.");
    }
}
}