using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class MainMenuServices {
        public static List<FlightModel> ListOfFlights;
        public static List<ReservationModel> ListOfReservations;
        // singleton
        private static MainMenuServices ServicesInstance = null;
        public static MainMenuServices GetInstance {
            get {
                if (ServicesInstance == null) {
                    ServicesInstance = new MainMenuServices ();
                }
                return ServicesInstance;
            }
        }

        // service methods
        public void GetData () {
            ListOfFlights = FlightMaintenance.GetInstance.GetAllFlights ();
            ListOfReservations = FlightReservations.GetInstance.GetFlightReservations();
        }

    }
}