using BudgetControl.Application.Services.Interfaces;

namespace BudgetControl.Presentation.UI.Components;

public class CategoriesMenu
{
	private readonly ICategoryService _categoryService;

    public CategoriesMenu(ICategoryService category)
    {
        _categoryService = category;
    }
}
