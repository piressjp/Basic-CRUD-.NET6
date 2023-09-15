using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace user.Controllers;

[ApiController]
[Authorize]
public class HomeController : ControllerBase
{
    [HttpGet("v1/all")]
    public IActionResult Get([FromServices] AppDbContext context)
        => Ok(context.Users.AsNoTracking().ToList());
    

    [HttpGet("v1/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var user = context.Users.AsNoTracking().FirstOrDefault(x => x.ID == id);
        if (user == null)
            return NoContent();

        return Ok(user);
    }

    [HttpPost("v1")]
    public IActionResult Post([FromBody] UserModel user, [FromServices] AppDbContext context)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return Created($"/{user.ID}", user);
    }

    [HttpPut]
    [Route("v1/{id:int}")]
    public IActionResult Put([FromRoute] int id ,[FromServices] AppDbContext context, string telefone)
    {
        var item = context.Users.FirstOrDefault(x => x.ID == id);
        if(item == null)
            return NoContent();

        item.Telefone = telefone;

        context.Users.Update(item);
        context.SaveChanges();
        
        return Ok(item);
    }

    [HttpDelete]
    [Route("v1/{id:int}")]
    public IActionResult Delete([FromRoute] int id ,[FromServices] AppDbContext context)
    {
        var item = context.Users.FirstOrDefault(x => x.ID == id);
        if (item == null)
            return NoContent();

        context.Users.Remove(item);
        context.SaveChanges();

        return Ok("Deletado com sucesso");
    }
}
