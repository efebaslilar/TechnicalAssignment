using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EntityModels
{
    [Table("ProductFeatureInformations")]
    public class ProductFeatureInformation:BaseModel<int>
    {
        public int ProductFeatureId { get; set; }
        public string ProductFeatureInformationName { get; set; }

        public decimal DiscountAmount { get; set; }

        [ForeignKey("ProductFeatureId")]

        public virtual ProductFeature ProductFeature { get; set; }

    }
}
