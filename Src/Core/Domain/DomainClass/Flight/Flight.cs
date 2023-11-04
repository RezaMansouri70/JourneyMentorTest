using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainClass
{
    public class Flight
    {
        public Flight()
        {
        }
        public Flight(DateOnly flight_date, string flight_status, string airportname)
        {
            this.flight_date = flight_date;
            this.flight_status = flight_status;
            this.airportname = airportname;

        }

        public int Id { get; set; }
        public DateOnly flight_date { get; private set; }
        public string flight_status { get; private set; }
        public string airportname { get; private set; }
       
    }
}
