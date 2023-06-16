using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Application.Services.Logic;
using BudgetControl.Domain.Common;
using BudgetControl.Domain.Entities;
using BudgetControl.Presentation.Shared.Components;
using BudgetControl.Presentation.Shared.Enums;
using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class SubCategoriesMenu : DrawComponents
{
	private readonly ISubCategoryService _subCategoryService;

	public SubCategoriesMenu(ISubCategoryService subCategoryService)
	{
		_subCategoryService = subCategoryService;
	}

	public async Task Selection(string menuName)
	{
		switch (menuName)
		{
			case nameof(Options.Add):
				await AddCategory();
				break;
			case nameof(Options.Edit):
				await EditCategory();
				break;
			case nameof(Options.Delete):
				await DeleteCategory();
				break;
			case nameof(Options.View):
				await GetCategories();
				break;
			default: throw new ArgumentException("Option not available");
		}
	}

	private async Task AddCategory()
	{
		Question("Sub-Category to add");

		var subCategoryName = AnsiConsole.Ask<string>("What is the [green]name[/] of the subcategory?");
		var subCategoryCode = AnsiConsole.Ask<int>("What is the main [green]category ID[/]?");

		var subCategory = new SubCategoryDTO()
		{
			Name = subCategoryName,
			CategoryId = subCategoryCode,
			ChangedAt = DateTime.Now,
			CreatedAt = DateTime.Now
		};

		bool wasAdded = await _subCategoryService.AddAsync(subCategory);

		AnsiConsole.WriteLine(wasAdded ? "sucessfully added" : "something super wrong happened");
	}

	private async Task GetCategories()
	{
		var subCategories = await _subCategoryService.GetAllAsync();

		if (subCategories?.Count > 0)
		{
			var tableSubCategories = new Table();
			tableSubCategories.Border = TableBorder.SimpleHeavy;
			tableSubCategories.Expand();

			tableSubCategories.Title = new TableTitle("[yellow]Sub-Categories[/]");

			tableSubCategories.AddColumn(new TableColumn("Name"));
			tableSubCategories.AddColumn(new TableColumn("Main Category"));
			tableSubCategories.AddColumn(new TableColumn("Added Date").Centered());

			subCategories.ForEach(subCategory =>
			{
				tableSubCategories.AddRow(
					subCategory.Name,
					subCategory.CategoryId.ToString(),
					subCategory.CreatedAt.ToString());
			});

			AnsiConsole.Write(tableSubCategories);
		}
	}

	private async Task DeleteCategory()
	{
		Question("Sub-Category to remove?");

		var subCategoryID = GetID("What is the ID of the sub-category you want to remove?");
		var subCategory = await ValidateId(subCategoryID);

		if (subCategory is null)
			return;

		var result = await _subCategoryService.RemoveAsync(subCategory);

		AnsiConsole.WriteLine(result ? "sucessfully removed" : "something super wrong happened");
	}

	private async Task EditCategory()
	{
		Question("Sub-Category to edit.");

		var subCategoryID = GetID("What is the ID of the category you want to remove?");
		var subCategory = await ValidateId(subCategoryID);

		if (subCategory is null)
			return;

		DrawSubCategory(subCategory);

		var subCategoryToEdit = EditCategoryField(subCategory);
		var wasEdited = await _subCategoryService.EditAsync(subCategoryToEdit);

		AnsiConsole.WriteLine(wasEdited ? "sucessfully edited" : "something super wrong happened");
	}

	private async Task<SubCategory?> ValidateId(int id)
	{
		var subCategory = await _subCategoryService.GetByID(id);

		if (subCategory is null)
		{
			AnsiConsole.WriteLine("Sub-Category not found");
			return null;
		}

		return subCategory;
	}

	private void DrawSubCategory(SubCategory category)
	{
		var tableCategories = new Table();
		tableCategories.Border = TableBorder.SimpleHeavy;
		tableCategories.Expand();

		tableCategories.Title = new TableTitle("[yellow]Sub-Categories[/]");

		tableCategories.AddColumn(new TableColumn("1 - Name"));
		tableCategories.AddColumn(new TableColumn("2 - Category ID"));

		tableCategories.AddRow(category.Name.ToString());
		tableCategories.AddRow(category.CategoryId.ToString());

		tableCategories.Caption = new TableTitle($"This is the sub-category you want to edit.");
		AnsiConsole.Write(tableCategories);
	}

	private SubCategory EditCategoryField(SubCategory subCategory)
	{
		var fieldToEdit = FieldToEdit();

		switch (fieldToEdit)
		{
			case 1:
				subCategory.Name = AnsiConsole.Ask<string>("What is the [green]name[/] of the category?");
				break;
			case 2:
				subCategory.CategoryId = AnsiConsole.Ask<int>("What is the [green]ID[/] of the main Category?");
				break;
			default:
				break;
		}

		return subCategory;
	}

}
