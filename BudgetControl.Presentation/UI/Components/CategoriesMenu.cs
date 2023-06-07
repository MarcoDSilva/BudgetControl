using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Presentation.Shared.Components;
using BudgetControl.Presentation.Shared.Enums;
using Spectre.Console;

namespace BudgetControl.Presentation.UI.Components;

public class CategoriesMenu : DrawComponents
{
	private readonly ICategoryService _categoryService;

	public CategoriesMenu(ICategoryService category)
	{
		_categoryService = category;
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
		Question("Category to add");

		var categoryName = AnsiConsole.Ask<string>("What is the [green]name[/] of the category?");

		var category = new CategoryDTO()
		{
			Name = categoryName,
			ChangedAt = DateTime.Now,
			CreatedAt = DateTime.Now
		};

		bool wasAdded = await _categoryService.AddAsync(category);

		AnsiConsole.WriteLine(wasAdded ? "sucessfully added" : "something super wrong happened");
	}

	private async Task GetCategories()
	{
		var categories = await _categoryService.GetAllAsync();

		if (categories?.Count > 0)
		{
			var tableCategories = new Table();
			tableCategories.Border = TableBorder.SimpleHeavy;
			tableCategories.Expand();

			tableCategories.Title = new TableTitle("[yellow]Categories[/]");

			tableCategories.AddColumn(new TableColumn("Name"));
			tableCategories.AddColumn(new TableColumn("Added Date").Centered());


			categories.ForEach(category =>
			{
				tableCategories.AddRow(category.Name, category.CreatedAt.ToString());
			});

			AnsiConsole.Write(tableCategories);
		}
	}

	private async Task DeleteCategory()
	{
		Question("Category to remove?");

		var categoryID = GetID("What is the ID of the category you want to remove?");
		var category = await ValidateId(categoryID);

		if (category is null)
			return;

		var result = await _categoryService.RemoveAsync(category);

		AnsiConsole.WriteLine(result ? "sucessfully removed" : "something super wrong happened");
	}

	private async Task EditCategory()
	{
		Question("Category to edit.");

		var categoryID = GetID("What is the ID of the category you want to remove?");
		var category = await ValidateId(categoryID);

		if (category is null)
			return;

		DrawCategory(category);

		var categoryToEdit = EditCategoryField(category);
		var wasEdited = await _categoryService.EditAsync(categoryToEdit);

		AnsiConsole.WriteLine(wasEdited ? "sucessfully edited" : "something super wrong happened");
	}

	private async Task<Category?> ValidateId(int id)
	{
		var category = await _categoryService.GetByID(id);

		if (category is null)
		{
			AnsiConsole.WriteLine("Category not found");
			return null;
		}

		return category;
	}

	private void DrawCategory(Category category)
	{
		var tableCategories = new Table();
		tableCategories.Border = TableBorder.SimpleHeavy;
		tableCategories.Expand();

		tableCategories.Title = new TableTitle("[yellow]Categories[/]");

		tableCategories.AddColumn(new TableColumn("1 - Name"));

		tableCategories.AddRow(category.Name.ToString());

		tableCategories.Caption = new TableTitle($"This is the category you want to edit.");
		AnsiConsole.Write(tableCategories);
	}

	private Category EditCategoryField(Category category)
	{
		var fieldToEdit = FieldToEdit();

		switch (fieldToEdit)
		{
			case 1:
				category.Name = AnsiConsole.Ask<string>("What is the [green]name[/] of the category?");
				break;
			default:
				break;
		}

		return category;
	}
}
