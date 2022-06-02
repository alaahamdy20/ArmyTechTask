using ArmyTechTask.repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Service.Branch
{
    public class BranchService: IBranchService
    {
        private readonly IBaseRepository<Domain.Entities.Branch> _branchRepository;

        public BranchService(IBaseRepository<Domain.Entities.Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public List<Domain.Entities.Branch> GetAll()
        {
            return _branchRepository.GetAll().ToList();
        }
    }
}

