namespace MinimalAPITest.Model;

public interface ITodoItemRepository
{
    TodoItem GetById(int id);
    List<TodoItem> GetAll();
    void Add(TodoItem item);
}
