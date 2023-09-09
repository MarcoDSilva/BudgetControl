namespace BudgetControl.Application.Repository.Interfaces;

public interface IUnitOfWork
{
    ICategoryRepository categoryRepository { get; }
    ISubCategoryRepository subCategoryRepository { get; }
    IExpensesRepository expensesRepository { get; }
    IIncomeRepository incomeRepository { get; }
    IInvestmentRepository investmentRepository { get; }

}
