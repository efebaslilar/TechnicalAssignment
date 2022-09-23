using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EntityModels
{
    [Table("Brands")]
    public class Brand:BaseModel<int>
    {
        public string BrandName { get; set; }

        public virtual List<Brand> Brands { get; set; }
    }
}
