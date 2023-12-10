using Lab13C.Models;
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public CustomersCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public List<Customer> GetInvoicesByFilter([FromBody] Customer filter) {

            var response = _context.Customers
                .Where(x => (x.FirstName == filter.FirstName)
                         && ( x.LastName == filter.LastName))
                .OrderByDescending(x => x.LastName)
                .ToList();

            return response;
        }

        [HttpPost]
        public void Insert(CustomerRequestV1 request)
        {
            Customer model = new Customer();
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            model.DocumentNumber = request.DocumentNumber;
            model.Active = true;
            _context.Customers.Add(model);
            _context.SaveChanges();// confirmacion o commit
        }

        [HttpPost]
        public void DeleteCustomer(CustomerRequestV2 request)
        {
            var model = _context.Customers.Find(request.CustomerID);
            _context.Entry(model).State = EntityState.Modified;
            model.Active = false;
            _context.SaveChanges();
        }

        [HttpPost]
        public void UpdateNumberDoc(CustomerRequestV3 request)
        {
            var model = _context.Customers.Find(request.CustomerID);
            _context.Entry(model).State = EntityState.Modified;
            model.DocumentNumber = request.DocumentNumber;

            _context.SaveChanges();// confirmacion o commit
        }
    }
}
