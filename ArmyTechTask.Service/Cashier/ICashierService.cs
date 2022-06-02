using ArmyTechTask.Service.ViewModels;

namespace ArmyTechTask.Service.Cashier
{
    public interface ICashierService
    {
        List<Domain.Entities.Cashier> GetAllCashiers();
        Domain.Entities.Cashier GetById(int id);
        void Add(AddCashierViewModel cashier);
        void Update(AddCashierViewModel cashier);
        void Delete(int id);
        bool CashierExists(int id);
    
    }
}

