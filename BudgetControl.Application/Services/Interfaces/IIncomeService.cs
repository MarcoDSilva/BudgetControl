using BudgetControl.Application.DTO;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application.Services.Interfaces;

public interface IIncomeService
{
	Task<List<IncomeDTO>> GetAllAsync();
	Task<bool> AddAsync(IncomeDTO incomeDTO);
	Task<bool> RemoveAsync(Income income);
	Task<bool> EditAsync(Income income);
	Task<Income?> GetByID(int id);
}
