using BudgetControl.Infrastructure.Interfaces;

namespace BudgetControl.Infrastructure.Repository;

public class UnitOfwork : IUnitOfWork
{
	public ICategoryRepository categoryRepository { get; }
	public ISubCategoryRepository subCategoryRepository { get; }

	public IExpensesRepository expensesRepository { get; }

	public IIncomeRepository incomeRepository { get; }

	public IInvestmentRepository investmentRepository { get; }

	public UnitOfwork(
		ICategoryRepository categoryRepository,
		IExpensesRepository expensesRepository,
		IIncomeRepository incomeRepository,
		IInvestmentRepository investmentRepository,
		ISubCategoryRepository subCategoryRepository
		)
    {
        this.incomeRepository = incomeRepository;
		this.categoryRepository = categoryRepository;
		this.investmentRepository = investmentRepository;
		this.expensesRepository = expensesRepository;
		this.subCategoryRepository = subCategoryRepository;
    }
}

