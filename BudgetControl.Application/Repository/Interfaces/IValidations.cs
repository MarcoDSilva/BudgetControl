namespace BudgetControl.Application.Repository.Interfaces;

public interface IValidations
{
    Task<bool> DoesDbExist(string databaseName);
}
