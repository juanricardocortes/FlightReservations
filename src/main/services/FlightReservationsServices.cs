using System.Collections.Generic;
using FlightReservationLibrary;
namespace main {
    public class FlightReservationsServices {
        // singleton
        private static FlightReservationsServices ServicesInstance = null;
        public static FlightReservationsServices GetInstance {
            get {
                if (ServicesInstance == null) {
                    ServicesInstance = new FlightReservationsServices ();
                }
                return ServicesInstance;
            }
        }

        // service methods
        public bool FlightExists (ReservationModel Reservation) {
            return FlightReservations.GetInstance.FlightExists (Reservation, MainMenuServices.ListOfFlights);
        }
        public List<FlightModel> GetMatchingFlights (ReservationModel Reservation) {
            return FlightReservations.GetInstance.GetMatchingFlights(MainMenuServices.ListOfFlights, Reservation);
        }
        public ReservationModel ReserveFlight (ReservationModel Reservation, FlightModel Flight) {
            return FlightReservations.GetInstance.ReserveFlight(Reservation, Flight);
        }
        public ReservationModel AddReservation (ReservationModel Reservation) {
            return FlightReservations.GetInstance.AddReservation(Reservation);
        }
        public List<ReservationModel> GetFlightReservations () {
            return FlightReservations.GetInstance.GetFlightReservations();
        }
        public ReservationModel SearchFlightReservationByPNR (string PNR) {
            return FlightReservations.GetInstance.SearchByPNR(PNR, MainMenuServices.ListOfReservations);
        }
    }
}