using ArmyTechTask.Domain.Entities;

namespace ArmyTechTask.Service.ViewModels;

public class InvoiceViewModdel
{
    public InvoiceViewModdel()
    {
        InvoiceDetails = new HashSet<InvoiceDetailViewModel>();
    }

    public long Id { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime Invoicedate { get; set; }
    public int? CashierId { get; set; }
    public int BranchId { get; set; }

    public virtual Domain.Entities.Branch? Branch { get; set; }
    public virtual Domain.Entities.Cashier? Cashier { get; set; }
    public  ICollection<InvoiceDetailViewModel> InvoiceDetails { get; set; }
    
    
}

public class InvoiceDetailViewModel
{
    public long Id { get; set; }
    public string ItemName { get; set; } = null!;
    public double ItemCount { get; set; }
    public double ItemPrice { get; set; }
}