using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities
{
    public class OrderItem
    {
        [Key]
        public Guid OrderItemID { get; set; }

        [Required(ErrorMessage ="Order ID can't be blank")]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage = "Product Name can't be blank")]
        [StringLength(50, ErrorMessage = "Product Name must not exceed 50 characters")]
        public string? ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Unit Price must be a positive number.")]
        [Column(TypeName = "decimal")]
        public decimal UnitPrice { get; set; }

        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal")]
        public decimal TotalPrice { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Order? Order { get; set; }
    }
}
