using Devsharp.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopProjectG1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopProjectG1.Controllers
{

    public class ProductController : DevsharpController
    {

        public static List<ProductModel> Products = new List<ProductModel>();
        

        public ProductController() 
        {
            if (!Products.Any())
            { 
                Products.Add(new ProductModel()
                {
                    ID = 1,
                    Price = 1000,
                    ProductName = "Mobile",
                
                });
            }
        
        }

        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            return Ok(Products);
        }

        [HttpGet("Find/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Find(int id)
        {
            var product = Products.FirstOrDefault(x => x.ID == id);

            if(product == null)
            {
                return NotFound();
            }


            return Ok(product);
        }

        [HttpPost]
        public IActionResult Register([FromForm]ProductModel model)
        {
            //if (!ModelState.IsValid)
            //{ 
            //    return BadRequest(ModelState);
            //}
            if (model.ID == 0)
            {
                model.ID = Products.Max(x => x.ID) + 1;
                Products.Add(model);

                return CreatedAtAction("Find", new {id = model.ID} , model);
            }

            var product = Products.FirstOrDefault(x => x.ID == model.ID);
            if (product == null)
            {
                return NotFound();
            }

            product.Price = model.Price;
            product.ProductName = model.ProductName;

            return NoContent();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public IActionResult Delete(int id) 
        {
            var product = Products.FirstOrDefault(x => x.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            Products.Remove(product);
            return Ok();
        }

    }
}
