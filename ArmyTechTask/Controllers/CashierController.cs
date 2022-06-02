using ArmyTechTask.Domain.Entities;
using ArmyTechTask.repository.Data;
using ArmyTechTask.Service.Branch;
using ArmyTechTask.Service.Cashier;
using ArmyTechTask.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArmyTechTask.Controllers;

public class CashierController : Controller
{
    private readonly ICashierService _cashierService;
    private readonly IBranchService _branchService;

    public CashierController(ICashierService cashierService, IBranchService branchService)
    {
        _cashierService = cashierService;
        _branchService = branchService;
    }

    public IActionResult Index()
    {
        ViewBag.Branches = _branchService.GetAll();
        return View(_cashierService.GetAllCashiers());
    }

    [HttpPost]
    public async Task<IActionResult> Create(AddCashierViewModel model)
    {
        if (ModelState.IsValid)
        {
            _cashierService.Add(model);
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public IActionResult Edit(int id, AddCashierViewModel cashier)
    {
        if (id != cashier.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _cashierService.Update(cashier);
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        _cashierService.Delete(id);
        return RedirectToAction(nameof(Index));
    }

    private bool CashierExists(int id)
    {
        return _cashierService.CashierExists(id);
    }
}