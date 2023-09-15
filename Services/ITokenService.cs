using Todo.Models;

namespace Todo.Services;
public interface ITokenService
{
    string GenerateToken(string CPF);
}

