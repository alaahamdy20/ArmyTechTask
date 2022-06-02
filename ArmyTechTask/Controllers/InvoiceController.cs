using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArmyTechTask.Domain.Entities;
using ArmyTechTask.repository.Data;
using ArmyTechTask.Service.Branch;
using ArmyTechTask.Service.Cashier;
using ArmyTechTask.Service.ViewModels;

namespace ArmyTechTask.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ArmyTechTaskContext _context;
        private readonly IInvoiceService _invoiceService;
        private readonly IBranchService _branchService;
        private readonly ICashierService _cashierService;

        public InvoiceController(ArmyTechTaskContext context, IInvoiceService invoiceService,IBranchService branchService, ICashierService cashierService)

        {
            _context = context;
            _invoiceService = invoiceService;
            _branchService = branchService;
            _cashierService = cashierService;
        }
        public IActionResult Index()
        {
            return View(_invoiceService.GetAllInvoices());
        }
        
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.InvoiceHeaders == null)
            {
                return NotFound();
            }

            var invoiceHeader =_invoiceService.GetInvoice(id.Value);
            
            if (invoiceHeader == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_branchService.GetAll(), "Id", "BranchName", invoiceHeader.BranchId);
            ViewData["CashierId"] = new SelectList(_cashierService.GetAllCashiers(), "Id", "CashierName", invoiceHeader.CashierId);
            return View(invoiceHeader);
        }

        
        [HttpPost]
        public async Task<IActionResult> Edit(long id,[FromBody]InvoiceViewModdel invoiceHeader)
        {
            if (id != invoiceHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _invoiceService.UpdateInvoice(invoiceHeader);
                return View(invoiceHeader);
            }
            ViewData["BranchId"] = new SelectList(_branchService.GetAll(), "Id", "Id", invoiceHeader.BranchId);
            ViewData["CashierId"] = new SelectList(_cashierService.GetAllCashiers(), "Id", "Id", invoiceHeader.CashierId);
            return View(invoiceHeader);
        }

        

        private bool InvoiceHeaderExists(long id)
        {
          return _invoiceService.InvoiceHeaderExists(id);
        }
    }
}
