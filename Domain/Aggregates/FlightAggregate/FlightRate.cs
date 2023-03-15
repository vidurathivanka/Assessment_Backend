using Domain.Common;
using Domain.SeedWork;

namespace Domain.Aggregates.FlightAggregate
{
    public class FlightRate : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Price Price { get; private set; }
        public int Available { get; private set; }
        public System.Guid FlightId { get; private set; }
    protected FlightRate()
        {
        }

        public FlightRate(string name, Price price, int available)
        {
            Name = name;
            Price = price;
            Available = available;
        }

        public void ChangePrice(decimal value, Currency currency)
        {
            Price = new(value, currency);
        }

        public void ReduceAvailability(int quantity)
        {
            Available -= quantity;
        }
        public void MutateAvailability(int quantity)
        {
            Available += quantity;
        }
    }
}