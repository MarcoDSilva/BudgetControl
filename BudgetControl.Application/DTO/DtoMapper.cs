using AutoMapper;
using BudgetControl.Domain.Entities;

namespace BudgetControl.Application.DTO;

public class DtoMapper : Profile
{
    public DtoMapper()
    {
        CreateMap<Expenses, ExpensesDTO>();
        //CreateMap<ExpensesDTO, Expenses>();
	}
}
