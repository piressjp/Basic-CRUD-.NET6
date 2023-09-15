using Microsoft.AspNetCore.Mvc;
using Todo.DTO.Response;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers;
public class GenerateTokenController : Controller
{
    [HttpPost("v1/generate-token")]
    public async Task<IActionResult> GenerateToken([FromServices] ITokenService tokenService,
        [FromBody] UserModel user)
    {
        var token = tokenService.GenerateToken(user);
        return Ok(new TokenResponse { AccessToken = token });
    }
}
