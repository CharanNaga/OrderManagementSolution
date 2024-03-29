﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ServiceContracts.DTO
{
    public class OrderItemResponse
    {
        public Guid OrderItemID { get; set; }

        public Guid OrderID { get; set; }

        public string? ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
    public static class OrderItemExtensions
    {
        public static OrderItemResponse ToOrderItemResponse(this OrderItem orderItem)
        {
            return new OrderItemResponse()
            {
                OrderItemID = orderItem.OrderItemID,
                OrderID = orderItem.OrderID,
                ProductName = orderItem.ProductName,
                Quantity = orderItem.Quantity,
                UnitPrice = orderItem.UnitPrice,
                TotalPrice = orderItem.Quantity * orderItem.UnitPrice
            };
        }
        public static List<OrderItemResponse> ToOrderItemResponseList(this List<OrderItem> orderItems)
        {
            var orderItemResponses = new List<OrderItemResponse>();
            foreach (var orderItem in orderItems)
            {
                orderItemResponses.Add(orderItem.ToOrderItemResponse());
            }
            return orderItemResponses;
        }
    }
}
