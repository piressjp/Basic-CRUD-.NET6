using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.DTO;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
[Authorize]
public class HomeController : ControllerBase
{
    /// <summary>
    /// Returns all existing users.
    /// </summary>
    [HttpGet]
    [Route("v1/users-created")]
    /// pega tds os usuarios existentes do banco
    public IActionResult Get([FromServices] AppDbContext context)
        => Ok(context.Users.AsNoTracking().ToList());

    /// <summary>
    /// Returns an existing user by their ID.
    /// </summary>
    [HttpGet ("v1/users-created{id:int}")]
    /// pega os usuarios existentes do banco por id
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var user = context.Users.AsNoTracking().FirstOrDefault(x => x.ID == id);
        if (user == null)
            return NoContent();

        return Ok(user);
    }

    /// <summary>
    /// A new user has been registered.
    /// </summary>
    [HttpPost ("v1/add-newUser")]
    /// adicionar um novo usuarios do banco
    public IActionResult Post([FromBody] UserModel user, [FromServices] AppDbContext context)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return Created($"/{user.ID}", user);
    }

    /// <summary>
    /// Change the registered user's phone number.
    /// </summary>
    [HttpPut ("v1/update-phone/{id:int}")]
    /// atualiza info's de um usuario existente no banco de acordo com id
    public IActionResult Put([FromRoute] int id ,[FromServices] AppDbContext context, [FromBody] UpdateTelefoneRequest telefone)
    {
        var item = context.Users.FirstOrDefault(x => x.ID == id);
        if(item == null)
            return NoContent();

        if (item.Telefone == telefone.ToString())
            return BadRequest(new ErrorResponse<UpdateTelefoneRequest>("O telefone está atualizado"));

        item.Telefone = telefone.Telefone;

        context.Users.Update(item);
        context.SaveChanges();
        
        return Ok(item);
    }

    /// <summary>
    /// Deletes a bank user by their ID.
    /// </summary>
    [HttpDelete("v1/delete-user{id:int}")]
    /// deleta um usuarios do banco pelo seu correspondente id
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
