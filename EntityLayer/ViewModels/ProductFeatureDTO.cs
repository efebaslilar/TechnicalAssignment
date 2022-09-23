using EntityLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class ProductFeatureDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }
        public string ProductFeatureName { get; set; }

    
        public virtual ProductDTO Product { get; set; }
    }
}
