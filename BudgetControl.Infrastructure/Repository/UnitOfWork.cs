using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;

public class UnitOfwork : IUnitOfWork
{
	public ICategoryRepository categoryRepository => throw new NotImplementedException();

	public IExpensesRepository expensesRepository => throw new NotImplementedException();

	public IIncomeRepository incomeRepository => throw new NotImplementedException();

	public IInvestmentRepository investmentRepository => throw new NotImplementedException();
}

