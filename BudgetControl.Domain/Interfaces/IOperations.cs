namespace BudgetControl.Domain.Interfaces;

public interface IOperations<T> where T : class
{
    Task<bool> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
    Task<List<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> GetByNameAsync(string name);

}
