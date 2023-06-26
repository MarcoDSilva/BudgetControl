using BudgetControl.Application.DTO;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application.Services.Interfaces;

public interface IInvestmentService
{
	Task<List<InvestmentDTO>> GetAllAsync();
	Task<bool> AddAsync(InvestmentDTO investment);
	Task<bool> RemoveAsync(Investments investment);
	Task<bool> EditAsync(Investments investment);
	Task<Investments?> GetByID(int id);
}
