using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class Services {
        public static List<FlightModel> ListOfFlights;

        public void GetData () {
            Maintenance maintenance = new Maintenance ();
            ListOfFlights = maintenance.GetAllFlights ();
        }
    }
}