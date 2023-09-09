using BudgetControl.Application.Repository.Interfaces;

namespace BudgetControl.Application.Repository;

public class Validations : IValidations
{
	public Task<bool> DoesDbExist(string classPath)
	{
		//if (string.IsNullOrEmpty(classPath)) throw new Exception("Invalid classPath");

		//var isDbCreated = File.Exists(string.Concat(classPath, "\\BudgetControl.db"));
		throw new NotImplementedException();

	}
}
