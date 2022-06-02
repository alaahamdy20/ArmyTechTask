using ArmyTechTask.Domain.Entities;

namespace ArmyTechTask.Service.ViewModels;

public class CashierViewModdel
{
    public string CashierName { get; set; } = null!;
    public int BranchId { get; set; }

    public virtual Domain.Entities.Branch Branch { get; set; } = null!;
    
    
}