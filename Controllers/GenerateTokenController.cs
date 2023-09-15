using Microsoft.AspNetCore.Mvc;
using Todo.DTO;
using Todo.Services;

namespace Todo.Controllers;
public class GenerateTokenController : Controller
{
    /// <summary>
    /// Generates a token to release access to use api routes.
    /// </summary>
    [HttpPost("v1/token")]
    public async Task<IActionResult> GenerateToken([FromServices] ITokenService tokenService,
        [FromBody] TokenRequest req)
    {
        var token = tokenService.GenerateToken(req.CPF);
        return Ok(new TokenResponse { AccessToken = token });
    }
}
