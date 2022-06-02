using ArmyTechTask.repository.Interfaces;
using ArmyTechTask.Service.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Service.Cashier
{
    public class CashierService: ICashierService
    {
        private readonly IBaseRepository<Domain.Entities.Cashier> _cashierRepository;

        public CashierService(IBaseRepository<Domain.Entities.Cashier> cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }
        public  List<Domain.Entities.Cashier> GetAllCashiers()
        {
           
            return  _cashierRepository.Get().Include(c => c.Branch).ToList();
        }

        public Domain.Entities.Cashier GetById(int id)
        {
            return _cashierRepository.GetById(id);
        }

        public void Add(AddCashierViewModel cashier)
        {
            var newCashier = new Domain.Entities.Cashier()
            {
                CashierName = cashier.CashierName,
                BranchId = cashier.BranchId
            };
            _cashierRepository.Add(newCashier);
        }

        public void Update(AddCashierViewModel cashier)
        {
          
                var newCashier = new Domain.Entities.Cashier()
                {
                    Id = cashier.Id,
                    CashierName = cashier.CashierName,
                    BranchId = cashier.BranchId
                };
                _cashierRepository.Update(newCashier);
        }

        public void Delete(int id)
        {
           
            var cashier = _cashierRepository.GetById(id);
            if (cashier != null)
            {
                _cashierRepository.Delete(cashier);
            }
            
        }

        public bool CashierExists(int id)
        {
            return (_cashierRepository.Get()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

