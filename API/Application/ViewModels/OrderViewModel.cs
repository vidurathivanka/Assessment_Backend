using System;

namespace API.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid CustomerId { get; private set; }

        public Guid FlightId { get; private set; }
        public Guid FlightRateId { get; private set; } 
        public Int16 Status { get; private set; }
        public int Quantity { get; private set; }
        public decimal Amount { get; private set; }
        public decimal Total { get; private set; }

        public void SetTotal()
        {
            Total = Amount * Quantity;
        }
    }
}
