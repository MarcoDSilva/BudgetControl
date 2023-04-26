using BudgetControl.Domain.Common;

namespace BudgetControl.Domain.Domain.Entities;

public class Balance : BaseEntity
{
	public decimal InitialBalance { get; set; }
	public DateTime DateOfBudget { get; set; }
}
