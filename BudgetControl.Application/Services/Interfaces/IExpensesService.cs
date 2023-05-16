using BudgetControl.Application.DTO;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application.Services.Interfaces;

public interface IExpensesService
{
	Task<List<ExpensesDTO>> GetExpenses();
	Task<bool> AddAsync(ExpensesDTO expensesDTO);
	Task<bool> RemoveAsync(Expenses expense);
	Task<bool> EditAsync(ExpensesDTO expensesDTO);
	Task<Expenses?> GetExpenseByID(int id);
}
