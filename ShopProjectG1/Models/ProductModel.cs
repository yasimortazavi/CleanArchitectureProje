using Devsharp.Framework;
using System.ComponentModel.DataAnnotations;

namespace ShopProjectG1.Models
{
    public class ProductModel: BaseEntityModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Display(Name ="نام محصول")]
        [MaxLength(10,ErrorMessage ="")]
        public string ProductName { get; set; }

        [Range(10,100, ErrorMessage ="")]
        public int Price { get; set; }
    }
}
