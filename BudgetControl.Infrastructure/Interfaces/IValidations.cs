namespace BudgetControl.Infrastructure.Interfaces;

public interface IValidations
{
	Task<bool> DoesDbExist(string databaseName);
}
