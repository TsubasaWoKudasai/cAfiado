// classe geral pra usuario 
using System.Security.Cryptography;
namespace CrudSimples.Models{

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Tipo {get; set; }

    public Usuario(int id, string name, string email, string senha, string tipo)
    {
        Id = id;
        Name = name;
        Email = email;
        Senha = senha;
        Tipo = tipo;
    }

// metodo de permissoes do usuario a ser sobrescrito
public virtual void MostrarPermissoes()
{
    if (Tipo.ToLower() == "admin")
    {
        Console.WriteLine($"Usuário {Name} possui permissões de administrador.");
    }
    else
    {
        Console.WriteLine($"Usuário {Name} possui permissões básicas.");
    }
}
}
}