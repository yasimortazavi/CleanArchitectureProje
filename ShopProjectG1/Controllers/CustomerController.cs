using Devsharp.Core.Domian;
using Devsharp.Data;
using Devsharp.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopProjectG1.Controllers
{
 
    public class CustomerController : DevsharpController
    {
        ApplicationDbContext  DbContext = null;
        //ClassA classA = null;
        #region Field
        private readonly MyInterface _myInterface = null;
        #endregion
        public CustomerController(MyInterface myInterface)
        {
            DbContext = new ApplicationDbContext();
            this._myInterface =  myInterface;
            //classA = new ClassA();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return Ok("salam Customer");
        }

        [HttpPost]
        public IActionResult Register()
        {
           var result = _myInterface.Calc(10,20);

            //Customer customer = new Customer();
            //DbContext.Add(customer); 
            //DbContext.Update(customer);
            return Ok(result);
        }
    }
}
