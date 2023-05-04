namespace BudgetControl.Domain.Interfaces;

public interface IOperations<T> where T : class
{
    Task<bool> CreateAsync(T entity);
    void Update(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<List<T?>> GetByNameAsync(string name);

}
