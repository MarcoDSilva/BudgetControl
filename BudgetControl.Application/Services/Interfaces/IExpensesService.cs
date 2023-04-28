using BudgetControl.Application.DTO;

namespace BudgetControl.Application.Services.Interfaces;

public interface IExpensesService
{
	Task<List<ExpensesDTO>> GetExpenses(); 
}
