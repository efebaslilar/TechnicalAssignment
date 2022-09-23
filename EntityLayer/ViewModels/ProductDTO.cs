using EntityLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }

        public int BrandId { get; set; }

        public virtual BrandDTO Brand { get; set; }
    }
}
