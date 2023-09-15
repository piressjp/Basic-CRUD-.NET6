using Microsoft.AspNetCore.Mvc;
using Todo.DTO.Response;
using Todo.Models;
using Todo.Services;

namespace Todo.Controllers;
public class GenerateTokenController : Controller
{
    [HttpPost("v1/token")]
    public async Task<IActionResult> GenerateToken([FromServices] ITokenService tokenService,
        [FromBody] string CPF)
    {
        var token = tokenService.GenerateToken(CPF);
        return Ok(new TokenResponse { AccessToken = token });
    }
}
