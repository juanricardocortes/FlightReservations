using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class FlightReservationsController {
        // singleton
        private static FlightReservationsController ControllerInstance = null;
        public static FlightReservationsController GetInstance {
            get {
                if (ControllerInstance == null) {
                    ControllerInstance = new FlightReservationsController ();
                }
                return ControllerInstance;
            }
        }

        // controller methods
        public void GetReservationsMenuInput (string input) {
            if (Validation.GetInstance.IsValidNumberInput (input, 3)) {
                if (input == "1") {
                    Views.GetInstance.DisplayReserveFlightFormA ();
                } else if (input == "2") {
                    Views.GetInstance.DisplayFlightReservations(FlightReservationsServices.GetInstance.GetFlightReservations());
                } else if (input == "3") {
                    Views.GetInstance.DisplaySearchByReservationByPNRForm();
                }
            } else {
                Views.GetInstance.DisplayMainMenu ();
            }
        }
        public void GetChooseReservationInput (FlightModel Flight, ReservationModel Reservation) {
            Views.GetInstance.DisplayReserveFlightFormB (FlightReservationsServices.GetInstance.ReserveFlight(Reservation, Flight));
        }
        public void GetReservationsFormAInput (ReservationModel Reservation) {
            if (FlightReservationsServices.GetInstance.FlightExists (Reservation)) {
                Views.GetInstance.DisplayMatchingFlights (Reservation, FlightReservationsServices.GetInstance.GetMatchingFlights (Reservation));
            } else {
                Views.GetInstance.DisplayReservationMenu ();
            }
        }
        public void GetPassenger (ReservationModel Reservation) {
            Views.GetInstance.DisplaySingleReservation(FlightReservationsServices.GetInstance.AddReservation (Reservation));
        }
        public void GetSearchByPNRInput (string PNR) {
            Views.GetInstance.DisplaySingleReservation(FlightReservationsServices.GetInstance.SearchFlightReservationByPNR(PNR));
        }
    }
}