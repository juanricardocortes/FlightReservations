using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class Services {

        // Singleton
        private static Services ServicesInstance = null;
        public static Services GetInstance {
            get {
                if (ServicesInstance == null) {
                    ServicesInstance = new Services ();
                }
                return ServicesInstance;
            }
        }
        private Services () { }

        // Service Methods
        public static List<FlightModel> ListOfFlights;

        public void GetData () {
            ListOfFlights = FlightMaintenance.GetInstance.GetAllFlights ();
        }

        public void AddFlight (FlightModel flight) {
            FlightMaintenance.GetInstance.AddFlight (flight);
        }

        public List<FlightModel> SearchFlight (string FilterBy, string SearchBy) {
            return FlightMaintenance.GetInstance.SearchFlight (FilterBy, Services.ListOfFlights, SearchBy);
        }

        public bool FlightExists (ReservationModel Reservation) {
            return FlightMaintenance.GetInstance.FlightExists (Reservation, Services.ListOfFlights);
        }
    }
}