using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.EntityModels
{
    [Table("OrderDetails")]
    public class OrderDetail : BaseModel<int>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public bool IsCompleted { get; set; }
        //Todo ilişkiler
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [ForeignKey("BookId")]
        public virtual Product Product { get; set; }
    }
}
