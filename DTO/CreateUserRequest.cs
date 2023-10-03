namespace Todo.DTO
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public DateTime DT_Nascimento { get; set; }

    }
}
