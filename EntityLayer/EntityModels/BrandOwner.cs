using EntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EntityModels
{
    [Table("BrandOwners")]
    public class BrandOwner :BaseModel<int>
    {
        public int BrandId { get; set; }
        public string AppUserId { get; set; }


        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }
    }
}
