using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Portal.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime TimeCreated { get; set; }
        public int TotalPrice { get; set; }
        public OrderState State { get; set; }

    }

    public enum OrderState
    {
        New = 1,
        Proccessing = 2,
        Confirmed = 3,
        Sending = 4,
        Delivered = 5,
        Done = 6
    }

    public class OrderItem
    {
        public Guid OrderId { get; set; }
        public int ProductId { get; set; }

        public int Count { get; set; }
        public int Price { get; set; }

        [NotMapped]
        public int SubTotal { get { return Count * Price; } }
    }
}
