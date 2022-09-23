using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.IdentityModels;

namespace EntityLayer.EntityModels
{
    [Table("Orders")]
    public class Order : BaseModel<int>
    {
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Sipariş numarası 8 haneli olmalıdır!")]
        public string CONumber { get; set; } // Sipariş numarası

        public string AppUserId { get; set; }
        public bool IsCompleted { get; set; }

        //Todo ilişki
        [ForeignKey("AppUserId")]
        public virtual AppUser Customer { get; set; }
        public virtual List<OrderDetail> OrderDetailList { get; set; }

    }
}
