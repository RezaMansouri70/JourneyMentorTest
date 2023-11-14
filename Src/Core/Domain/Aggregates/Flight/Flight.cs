using Domain.Interfaces;
using Domain.Interfaces.Entity;
using Domain.ValueObjects;

namespace Domain.DomainClass
{
    public class Flight : Entity, IAggregateRoot
    {
        public Flight()
        {
        }
        public Flight(DateOnly flight_date, string flight_status, string airportname)
        {
            this.flight_date = flight_date;
            this.flight_status = flight_status;
            this.airportname = new Name(airportname);

        }

        public int Id { get; set; }
        public DateOnly flight_date { get; private set; }
        public string flight_status { get; private set; }
        public Name airportname { get; private set; }

    }
}
