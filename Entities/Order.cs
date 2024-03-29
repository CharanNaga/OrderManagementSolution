﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }

        [Required(ErrorMessage ="Order Number can't be blank")]
        [RegularExpression(@"^(?i)ORD_\d{4}_\d+$", ErrorMessage = "Order Number should begin with 'ORD' followed by an underscore (_) and a sequential number.")] 
        public string? OrderNumber { get; set; }

        [Required(ErrorMessage ="Customer Name can't be blank")]
        [StringLength(50,ErrorMessage ="Customer Name must not exceed 50 characters")]
        public string? CustomerName { get; set;}


        [Required(ErrorMessage ="Order Date can't be blank")]
        public DateTime OrderDate { get; set; }

        [Range(0,double.MaxValue,ErrorMessage ="Total Amount must be positive")]
        [Column(TypeName = "decimal")]
        public decimal TotalAmount { get; set; }

        //public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}