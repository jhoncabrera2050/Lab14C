using Lab13C.Models;
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab13C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoicesCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpGet]
       public List<Invoice> GetInvoices() {
            var response = _context.Invoices.ToList();

            return response;
        }


        [HttpPost]
        public void Insert(InvoiceRequestV1 request)
        {
            Invoice model = new Invoice();

            model.CustomerID = request.CustomerID;
            model.Date = request.Date;
            model.InvoiceNumber = request.InvoiceNumber;
            model.Total = request.Total;
            model.Active = true;

            _context.Invoices.Add(model);
            _context.SaveChanges();// confirmacion o commit
        }
    }
}
