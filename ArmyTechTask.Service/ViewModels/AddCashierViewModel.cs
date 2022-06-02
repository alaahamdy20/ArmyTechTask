using System.ComponentModel.DataAnnotations;

namespace ArmyTechTask.Service.ViewModels;

public class AddCashierViewModel
{
    public int Id { get; set; }
    [Required]
    [Display(Name = "Name")]
    public string CashierName { get; set; }
    [Required]
    public int BranchId { get; set; }
}