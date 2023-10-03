using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Todo.Models;

[Table("Users")]
public class UserModel
{
    public int ID { get; set; }

    public string Nome { get; set; }

    public string CPF { get; set; }

    public string Telefone { get; set; }

    public DateTime DT_Nascimento { get; set; }

    public DateTime DT_Criacao { get; set; }
}
