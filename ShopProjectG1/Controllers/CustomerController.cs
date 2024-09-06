using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopProjectG1.Controllers
{
 
    public class CustomerController : DevsharpController
    {

        #region Field
        private readonly IRepository<Customer> _repositoryCustomer;
        #endregion
        public CustomerController(IRepository<Customer> repositoryCustomer)
        {
           this._repositoryCustomer = repositoryCustomer;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok("salam Customer");
        }

        [HttpPost]
        public IActionResult Register()
        {
            _repositoryCustomer.Insert(new Customer() { });
            return Ok();
        }
    }
}
