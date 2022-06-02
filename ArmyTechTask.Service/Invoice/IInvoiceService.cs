using ArmyTechTask.Domain.Entities;
using ArmyTechTask.Service.ViewModels;

namespace ArmyTechTask.Service.Cashier;

public interface IInvoiceService
{
    
     InvoiceViewModdel GetInvoice(long id);
     List<InvoiceHeader> GetAllInvoices();
     void UpdateInvoice(InvoiceViewModdel invoice);
     bool InvoiceHeaderExists(long id);
}
    
