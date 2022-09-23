using EntityLayer.EntityModels;
using EntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class BrandOwnerDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int BrandId { get; set; }
        public string AppUserId { get; set; }


        public virtual Brand Brand { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
