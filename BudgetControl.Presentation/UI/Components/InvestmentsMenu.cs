using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using BudgetControl.Presentation.Shared.Components;
using BudgetControl.Presentation.Shared.Enums;

namespace BudgetControl.Presentation.UI.Components;

public class InvestmentsMenu : DrawComponents
{
	private readonly IInvestmentService _investmentService;

	public InvestmentsMenu(InvestmentService investment)
	{
		_investmentService = investment;
	}

	public async Task Selection(string menuName)
	{
		switch (menuName)
		{
			case nameof(Options.Add):
				await AddInvestment();
				break;
			case nameof(Options.Edit):
				await EditInvestment();
				break;
			case nameof(Options.Delete):
				await DeleteInvestment();
				break;
			case nameof(Options.View):
				await GetInvestments();
				break;
			default: throw new ArgumentException("Option not available");
		}
	}

	private Task GetInvestments()
	{
		throw new NotImplementedException();
	}
	private Task AddInvestment()
	{
		throw new NotImplementedException();
	}

	private Task EditInvestment()
	{
		throw new NotImplementedException();
	}

	private Task DeleteInvestment()
	{
		throw new NotImplementedException();
	}

}
