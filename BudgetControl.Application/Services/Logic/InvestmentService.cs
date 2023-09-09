using AutoMapper;
using BudgetControl.Application.DTO;
using BudgetControl.Application.Services.Interfaces;
using BudgetControl.Domain.Entities;
using BudgetControl.Application.Repository.Interfaces;

namespace BudgetControl.Application.Services.Logic;

public class InvestmentService : IInvestmentService
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	public InvestmentService(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	public async Task<bool> AddAsync(InvestmentDTO investmentDTO)
	{
		var investment = _mapper.Map<Investments>(investmentDTO);
		investment.ChangedAt = DateTime.Now;
		investment.CreatedAt = DateTime.Now;

		var addedInvestment = await _unitOfWork.investmentRepository.CreateAsync(investment);
		return addedInvestment;
	}

	public async Task<bool> EditAsync(Investments investment)
	{
		var wasSaved = await _unitOfWork.investmentRepository.Update(investment);
		return wasSaved;
	}

	public async Task<List<InvestmentDTO>> GetAllAsync()
	{
		var investments = await _unitOfWork.investmentRepository.GetAllAsync();
		var investmentsDTO = new List<InvestmentDTO>();

		investments.ForEach(inv => investmentsDTO.Add(_mapper.Map<InvestmentDTO>(inv)));

		return investmentsDTO;
	}

	public async Task<Investments?> GetByID(int id)
	{
		var investments = await _unitOfWork.investmentRepository.GetAllAsync();
		var investment = investments.Find(inv => inv.Id == id);

		return investment;
	}

	public async Task<bool> RemoveAsync(Investments investment)
	{
		var remove = await _unitOfWork.investmentRepository.DeleteAsync(investment);
		return remove;
	}
}
