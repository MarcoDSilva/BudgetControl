namespace BudgetControl.Application.DTO;

public class InvestmentDTO
{
	public string Description { get; set; } = "";
	public decimal Value { get; set; }
	public DateTime TransactionDate { get; set; }
	public int CategoryId { get; set; }
	public int SubCategoryId { get; set; }
	public bool IsActive { get; set; }
	public decimal ExpectedReturn { get; set; }
}
