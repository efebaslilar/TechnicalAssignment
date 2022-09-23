using EntityLayer.EntityModels;
using EntityLayer.IdentityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.ViewModels
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsDeleted { get; set; }

        [StringLength(8, MinimumLength = 8, ErrorMessage = "Sipariş numarası 8 haneli olmalıdır!")]
        public string CONumber { get; set; } // Sipariş numarası

        public string AppUserId { get; set; }
        public bool IsCompleted { get; set; }

        public virtual AppUser Customer { get; set; }
        public virtual List<OrderDetailDTO> OrderDetailList { get; set; }
    }
}
