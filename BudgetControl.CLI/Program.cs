using BudgetControl.Presentation.UI.Components;
using Spectre.Console;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BudgetControl.Application;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;

internal class Program
{
	private static void Main(string[] args)
	{
		// to setup configurations like appsettings and so on
		var config = new ConfigurationBuilder();


		// to setup DI
		var services = new ServiceCollection();
		services.AddServicesDI();

		// running the program
		var main = new MainMenu();

		string selected = main.StartSelection();
		main.CallSelectedMenu(selected);
	}
}