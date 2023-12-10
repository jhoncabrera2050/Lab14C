
using Lab13C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.ProjectModel;
using Lab13C.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab13C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductCustomController : ControllerBase
    {
        private readonly InvoiceContext _context;
        public ProductCustomController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(ProductRequestV1 request) 
        {
            Product model = new Product();
            model.Price = (float)request.Price;
            model.Name = request.Name;
            model.Active = true;
            _context.Products.Add(model);
            _context.SaveChanges();// confirmacion o commit
        }

        [HttpPost]
        public void UpdatePrice(ProductRequestV2 request)
        {
            var model = _context.Products.Find(request.ProductoID);
            _context.Entry(model).State = EntityState.Modified;
            model.Price = (float)request.Price;

            _context.SaveChanges();// confirmacion o commit
        }

        [HttpPost]
        public void DeleteProduct(ProductRequestV3 request)
        {
            var model = _context.Products.Find(request.ProductoID);
            _context.Entry(model).State = EntityState.Modified;
            model.Active = false;
            _context.SaveChanges();
        }
    }
}
