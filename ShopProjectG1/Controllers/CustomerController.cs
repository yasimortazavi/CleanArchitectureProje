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
        private readonly IApplcationDbContext _applcationDbContext;
        #endregion
        public CustomerController(IApplcationDbContext applcationDbContext)
        {
           this._applcationDbContext = applcationDbContext;
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok("salam Customer");
        }

        [HttpPost]
        public IActionResult Register()
        {
           
            return Ok();
        }
    }
}
