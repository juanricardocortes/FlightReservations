using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class FlightMaintenanceServices {

        // singleton
        private static FlightMaintenanceServices ServicesInstance = null;
        public static FlightMaintenanceServices GetInstance {
            get {
                if (ServicesInstance == null) {
                    ServicesInstance = new FlightMaintenanceServices ();
                }
                return ServicesInstance;
            }
        }
        private FlightMaintenanceServices () { }

        // service methods
        public void AddFlight (FlightModel flight) {
            if (FlightMaintenance.GetInstance.IsUniqueFlight (flight, MainMenuServices.ListOfFlights)) {
                FlightMaintenance.GetInstance.AddFlight (flight);
            }
        }

        public List<FlightModel> SearchFlight (string FilterBy, string SearchBy) {
            return FlightMaintenance.GetInstance.SearchFlight (FilterBy, MainMenuServices.ListOfFlights, SearchBy);
        }
    }
}