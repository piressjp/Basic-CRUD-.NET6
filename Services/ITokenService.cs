using Todo.Models;

namespace Todo.Services;
public interface ITokenService
{
    string GenerateToken(UserModel user);
}

