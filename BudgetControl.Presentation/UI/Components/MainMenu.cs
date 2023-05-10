﻿using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using BudgetControl.Presentation.Shared.Enums;
using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class MainMenu
{
	private readonly IExpensesService _expensesService;
	public enum Selections
	{
		Summary,
		Expenses,
		Income,
		Investments,
		Categories,
		SubCategories
	};

	public MainMenu()
	{
	}

	public MainMenu(IExpensesService expensesService)
	{
		_expensesService = expensesService;
	}

	public string StartSelection()
	{
		string selection = AnsiConsole.Prompt(
				new SelectionPrompt<string>()
				.Title("Welcome To BudgetControl!")
				.PageSize(6)
				.AddChoices(new[]
				{
					nameof(Selections.Summary),
					nameof(Selections.Expenses),
					nameof(Selections.Income),
					nameof(Selections.Investments),
					nameof(Selections.Categories),
					nameof(Selections.SubCategories)
				})
			);

		return selection;
	}

	public async Task CallSelectedMenu(string selection)
	{
		// validate if db exists
		// if not, first runs migration to create
		// if exists, checks balance
		// if no balance, asks to create a balance (or starts at 0)
		// this can be only done once, with a global flag or something

		// then we go for the real menu
		await PickSelectedMenu(selection);
	}

	private async Task PickSelectedMenu(string selection)
	{
		switch (selection)
		{
			case nameof(Selections.Summary):
				Summary summary = new();
				summary.Render();
				break;
			case nameof(Selections.Expenses):
				await CallExpenses();
				break;
			case nameof(Selections.Income):
				await CallIncome();
				break;
			case nameof(Selections.Categories):
				await CallCategories();
				break;
			case nameof(Selections.SubCategories):
				await CallSubCategories();				
				break;
			default:
				throw new ArgumentException("");
		}
	}

	private static string GetOptions(string selectedMenu)
	{
		string option = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title($"What do you want to do on the {selectedMenu} menu?")
				.AddChoices(new[]
				{
					nameof(Options.Add),
					nameof(Options.Edit),
					nameof(Options.Delete),
					nameof(Options.View)
				})
			);

		return option;
	}

	private async Task CallExpenses()
	{
		string selected = GetOptions(nameof(Selections.Expenses));
		var expenses = new ExpensesMenu(_expensesService);

		await expenses.Selection(selected);
	}

	private async Task CallIncome()
	{
		//var income = new IncomeMenu(_incomeService);
		//await income.GetOptions();
	}
	private async Task CallCategories()
	{
		//var category = new CategoriesMenu(_categoryService);
		//await category.GetOptions();
	}

	private async Task CallSubCategories()
	{
		//var subCategory = new SubCategoriesMenu(_subCategoryService);
		//await subCategory.GetOptions();
	}
}
