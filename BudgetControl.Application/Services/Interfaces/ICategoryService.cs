using BudgetControl.Application.DTO;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application.Services.Interfaces;

public interface ICategoryService
{
	Task<List<CategoryDTO>> GetAllAsync();
	Task<bool> AddAsync(CategoryDTO categoryDTO);
	Task<bool> RemoveAsync(Category category);
	Task<bool> EditAsync(Category category);
	Task<Category?> GetByID(int id);
}
