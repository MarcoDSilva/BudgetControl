using BudgetControl.Domain.Entities;
using BudgetControl.Domain.Interfaces;

namespace BudgetControl.Infrastructure.Interfaces;

public interface ICategoryRepository : IOperations<Category>
{
}
