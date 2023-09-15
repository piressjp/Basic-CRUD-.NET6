using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.EntityFrameworkCore;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

[ApiController]
[Route("v1")]

public class HomeController : ControllerBase
{
    /// <summary>
    /// Returns all existing users.
    /// </summary>
    [HttpGet]
    [Route("/users-created")]
    /// pega tds os usuarios existentes do banco
    public IActionResult Get([FromServices] AppDbContext context)
        => Ok(context.Todos.AsNoTracking().ToList());

    /// <summary>
    /// Returns an existing user by their ID.
    /// </summary>
    [HttpGet]
    [Route("/users-created{id:int}")]
    /// pega os usuarios existentes do banco por id
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var todo = context.Todos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    /// <summary>
    /// A new user has been registered.
    /// </summary>
    [HttpPost]
    [Route("/add-newUser")]
    /// adicionar um novo usuarios do banco
    public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
        return Created($"/{todo.ID}", todo);
    }

    /// <summary>
    /// Change the registered user's phone number.
    /// </summary>
    [HttpPut]
    [Route("update-phone/{id:int}")]
    /// atualiza info's de um usuario existente no banco de acordo com id
    public IActionResult Put([FromRoute] int id ,[FromServices] AppDbContext context, [FromBody] TodoModel todo)
    {
        var item = context.Todos.FirstOrDefault(x => x.ID == id);
        if(item == null)
            return NotFound(todo);

        item.Title = todo.Title;
        item.Done = todo.Done;
        context.Todos.Update(item);
        context.SaveChanges();
        
        return Ok(item);
    }

    /// <summary>
    /// Deletes a bank user by their ID.
    /// </summary>
    [HttpDelete]
    [Route("/delete-user{id:int}")]
    /// deleta um usuarios do banco pelo seu correspondente id
    public IActionResult Delete([FromRoute] int id ,[FromServices] AppDbContext context)
    {
   
        var item = context.Todos.FirstOrDefault(x => x.ID == id);
        if (item == null)
            return NotFound(item);

        context.Todos.Remove(item);
        context.SaveChanges();

        return Ok("Deletado com sucesso");
    }
}
