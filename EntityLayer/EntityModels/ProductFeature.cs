using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EntityModels
{
    [Table("ProductFeatures")]
    public class ProductFeature:BaseModel<int>
    {
        public int ProductId { get; set; }
        public string ProductFeatureName { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
