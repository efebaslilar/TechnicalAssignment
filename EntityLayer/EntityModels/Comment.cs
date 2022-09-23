using EntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EntityModels
{
    [Table("Comments")]
    public class Comment:BaseModel<int>
    {
        public string AppUserId { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        [ForeignKey("AppUserId")]
        public virtual AppUser AppUser { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
