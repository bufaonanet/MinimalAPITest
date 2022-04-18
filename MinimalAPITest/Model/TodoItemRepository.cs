namespace MinimalAPITest.Model;

public class TodoItemRepository : ITodoItemRepository
{
    private List<TodoItem> _todoItems;

    public TodoItemRepository()
    {
        _todoItems = new List<TodoItem>()
        {
            new TodoItem() { Id = 1, Title = "Primeira tarefa",Descrition = "Teste descrição"},
            new TodoItem() { Id = 2, Title = "Segunda tarefa",Descrition = "Teste descrição"},
            new TodoItem() { Id = 3, Title = "Terceira tarefa",Descrition = "Teste descrição"},
            new TodoItem() { Id = 4, Title = "Quarta tarefa",Descrition = "Teste descrição"},
        };
    }

    public void Add(TodoItem item)
    {
        int nextId = _todoItems.Max(x => x.Id);
        item.Id = nextId + 1;
        _todoItems.Add(item);
    }

    public List<TodoItem> GetAll()
    {
        return _todoItems;
    }

    public TodoItem GetById(int id)
    {
        return _todoItems.FirstOrDefault(x => x.Id == id);
    }
}
