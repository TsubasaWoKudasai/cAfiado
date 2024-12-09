//subclasse comum
using System.Security.Cryptography;
namespace CrudSimples.Models{

public class UsuarioComum : Usuario 
{
    public UsuarioComum (int id, string name, string email, string senha, string tipo) : base(id, name, email, senha, tipo) { }

// metodo de permissoes do usuario comum
    public override void MostrarPermissoes()
    {
        Console.WriteLine($"Usuario {Name} possui permissoes basicas so podendo acessar certos recursos");
    }
}
}