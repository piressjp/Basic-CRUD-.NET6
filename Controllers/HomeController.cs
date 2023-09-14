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
    [HttpGet]
    [Route("/")]
    public IActionResult Get([FromServices] AppDbContext context)
        => Ok(context.Todos.AsNoTracking().ToList());
    

    [HttpGet]
    [Route("/{id:int}")]
    public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var todo = context.Todos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    [Route("/")]
    public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
    {
        context.Todos.Add(todo);
        context.SaveChanges();
        return Created($"/{todo.ID}", todo);
    }

    [HttpPut]
    [Route("/{id:int}")]
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

    [HttpDelete]
    [Route("/{id:int}")]
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
