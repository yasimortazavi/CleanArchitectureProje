using Devsharp.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopProjectG1.Controllers
{
 
    public class CustomerController : DevsharpController
    {

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok("salam Customer");
        }
    }
}
