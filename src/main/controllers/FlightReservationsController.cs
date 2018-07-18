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
        public void GetReservationsFormBInput(List<ReservationModel> FlightReservations) {
            Views.GetInstance.DisplayConfirmReservations(FlightReservationsServices.GetInstance.GetAgeOfPassengers(FlightReservations));
        }
        public void GetReservationConfirmation (string input, List<ReservationModel> FlightReservations) {
            if(input == "y" || input == "Y") {
                Views.GetInstance.DisplayFlightReservations(FlightReservationsServices.GetInstance.AddFlightReservations(FlightReservations));
            } 
        }
        public void GetSearchByPNRInput (string PNR) {
            Views.GetInstance.DisplayFlightReservations(FlightReservationsServices.GetInstance.SearchFlightReservationByPNR(PNR));
        }
    }
}