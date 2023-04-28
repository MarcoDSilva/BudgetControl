namespace BudgetControl.Application.DTO;

public class ExpensesDTO
{
	public DateTime TransactionDate { get; set; }
	public string Category { get; set; }
	public string SubCategory { get; set; }
	public decimal Value { get; set; }
	public string Description { get; set; }
}
