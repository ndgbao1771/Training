﻿using Training.Model.Shared;

namespace Training.Model.Entities
{
    public class OrderDetail : DomainEntity<int>
    {
        public OrderDetail(int orderId, int bookId, DateTime dateGiveExpect, DateTime dateGiveCurrent) 
        {
            OrderId = orderId;
            BookId = bookId;
            DateGiveExpect = dateGiveExpect;
            DateGiveCurrent = dateGiveCurrent;
        }
        public DateTime DateGiveExpect { get; set; }
        public DateTime DateGiveCurrent { get; set; }

        public int OrderId { get; set; }
        public Order order { get; set; }

        public int BookId { get; set; }
        public Book book { get; set; }

    }
}