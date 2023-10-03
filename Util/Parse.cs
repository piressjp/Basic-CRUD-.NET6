using Todo.DTO;
using Todo.Models;

namespace Todo.Util
{
    public class Parse
    {
        public UserModel ToModel(CreateUserRequest user)
        {
            UserModel model = new()
            {
                Nome = user.Name,
                CPF = user.CPF,
                Telefone = user.Telefone,
                DT_Nascimento = user.DT_Nascimento,
                DT_Criacao = DateTime.Now
            };

            return model;
        }
    }
}
