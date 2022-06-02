using ArmyTechTask.Domain.Entities;
using ArmyTechTask.repository.Interfaces;
using ArmyTechTask.Service.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ArmyTechTask.Service.Cashier;

public class InvoiceService : IInvoiceService
{
    private readonly IBaseRepository<InvoiceHeader> _invoiceHeaderRepository;
    private readonly IBaseRepository<InvoiceDetail> _invoiceDetailRepository;

    public InvoiceService(IBaseRepository<InvoiceHeader> invoiceHeaderRepository,
        IBaseRepository<InvoiceDetail> invoiceDetailRepository)

    {
        _invoiceHeaderRepository = invoiceHeaderRepository;
        _invoiceDetailRepository = invoiceDetailRepository;
    }

    public InvoiceViewModdel GetInvoice(long id)
    {
        return _invoiceHeaderRepository.Get().Include(i => i.InvoiceDetails)
            .Select(i => new InvoiceViewModdel()
            {
                Branch = i.Branch,
                Cashier = i.Cashier,
                InvoiceDetails = i.InvoiceDetails.Select(d => new InvoiceDetailViewModel()
                {
                    Id = d.Id,
                    ItemCount = d.ItemCount,
                    ItemName = d.ItemName,
                    ItemPrice = d.ItemPrice
                }).ToList(),
                Id = i.Id,
                Invoicedate = i.Invoicedate,
                BranchId = i.BranchId,
                CashierId = i.CashierId,
                CustomerName = i.CustomerName
            }).FirstOrDefault(i => i.Id == id);
    }

    public List<InvoiceHeader> GetAllInvoices()
    {
        return _invoiceHeaderRepository.Get().Include(i => i.Branch).Include(i => i.Cashier).Include(
            i => i.InvoiceDetails).ToList();
    }

    public void UpdateInvoice(InvoiceViewModdel invoiceHeader)
    {
        var newInvoice = new InvoiceHeader()
        {
            BranchId = invoiceHeader.BranchId,
            CashierId = invoiceHeader.CashierId,
            CustomerName = invoiceHeader.CustomerName,
            Invoicedate = invoiceHeader.Invoicedate,
            InvoiceDetails = invoiceHeader.InvoiceDetails.Select(i=>new InvoiceDetail()
            {
                Id = i.Id,
                ItemCount = i.ItemCount,
                ItemName = i.ItemName,
                ItemPrice = i.ItemPrice,
                InvoiceHeaderId = invoiceHeader.Id
            }).ToList()
            ,Id = invoiceHeader.Id
        };
                    
       _invoiceHeaderRepository.Update(newInvoice);
    }

    public bool InvoiceHeaderExists(long id)
    {
        return (_invoiceHeaderRepository.Get()?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}