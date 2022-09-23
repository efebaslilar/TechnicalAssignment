using EntityLayer.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class ProductFeatureInformationDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public int ProductFeatureId { get; set; }
        public string ProductFeatureInformationName { get; set; }

        public decimal DiscountAmount { get; set; }


        public virtual ProductFeatureDTO ProductFeature { get; set; }
    }
}
