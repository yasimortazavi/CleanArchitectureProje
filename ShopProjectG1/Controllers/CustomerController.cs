using Devsharp.Data;
using Devsharp.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Domain;

namespace ShopProjectG1.Controllers
{
 
    public class CustomerController : DevsharpController
    {
        ApplicationDbContext  DbContext = null;

        public CustomerController()
        {
            DbContext = new ApplicationDbContext();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok("salam Customer");
        }

        [HttpPost]
        public IActionResult Register([FromForm] CustomerController model)
        {
            Customer customer = new Customer();
            DbContext.Add(customer); 
            DbContext.Update(customer);
            return Ok();
        }
    }
}
