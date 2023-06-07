using BudgetControl.Application.DTO;
using BudgetControl.Domain.Common;

namespace BudgetControl.Application.Services.Interfaces;

public interface ISubCategoryService
{
	Task<List<SubCategoryDTO>> GetAllAsync();
	Task<bool> AddAsync(SubCategoryDTO subCategoryDTO);
	Task<bool> RemoveAsync(SubCategory subCategory);
	Task<bool> EditAsync(SubCategory subCategory);
	Task<SubCategory?> GetByID(int id);
}
