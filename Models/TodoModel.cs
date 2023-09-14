namespace Todo.Models;
public class TodoModel
{
    public int ID { get; set; }

    public string Title { get; set; }

    public bool Done { get; set; }

    public DateTime CreatedAt { get; set; }
}
