namespace Todo.Models;
public class UserModel
{
    public int ID { get; set; }

    public string Name { get; set; }

    public string CPF { get; set; }

    public string Telefone { get; set; }

    public DateTime DT_Nascimento { get; set; }

    public DateTime CreatedAt { get; set; }
}
