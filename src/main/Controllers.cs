using System;
using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class Controllers {

        // Singleton
        private static Controllers ControllerInstance = null;
        public static Controllers GetInstance {
            get {
                if (ControllerInstance == null) {
                    ControllerInstance = new Controllers ();
                }
                return ControllerInstance;
            }
        }
        private Controllers () { }
        public void InitializeConnections () {
            Services.GetInstance.GetData ();
        }
        // Controller Methods
        public void GetMainMenuInput (string input) {
            if (Validation.GetInstance.IsValidNumberInput (input, 2)) {
                if (input == "1") {
                    Views.GetInstance.DisplayMaintenanceMenu ();
                } else if (input == "2") {
                    Views.GetInstance.DisplayReservationMenu ();
                }
            } else {
                Views.GetInstance.DisplayMainMenu ();
            }
        }
        public void GetMaintainanceMenuInput (string input) {
            if (Validation.GetInstance.IsValidNumberInput (input, 2)) {
                if (input == "1") {
                    Views.GetInstance.DisplayAddFlightForm ();
                } else if (input == "2") {
                    Views.GetInstance.DisplaySearchFlightMenu ();
                }
            } else {
                Views.GetInstance.DisplayMaintenanceMenu ();
            }
        }
        public void GetAddFlightForm (FlightModel flight) {
            Services.GetInstance.AddFlight (flight);
            Services.GetInstance.GetData ();
        }
        public void GetSearchFlightMenuInput (string input) {
            if (Validation.GetInstance.IsValidNumberInput (input, 3)) {
                if (input == "1") {
                    Views.GetInstance.DisplaySearchFlightByACForm ();
                } else if (input == "2") {
                    Views.GetInstance.DisplaySearchFlightByFNForm ();
                } else if (input == "3") {
                    Views.GetInstance.DisplaySearchFlightByODForm ();
                }
            } else {
                Views.GetInstance.DisplaySearchFlightMenu ();
            }
        }
        public void GetSearchFlightByFNInput (string FlightNumber) {
            if (Validation.GetInstance.IsValidFlightNumber (FlightNumber)) {
                Views.GetInstance.DisplayFilteredFlights (Services.GetInstance.SearchFlight (FlightNumber, "FlightNumber"));
            } else {
                Views.GetInstance.DisplaySearchFlightByFNForm ();
            }
        }
        public void GetSearchFlightByACInput (string AirlineCode) {
            if (Validation.GetInstance.IsValidAirlineCode (AirlineCode)) {
                Views.GetInstance.DisplayFilteredFlights (Services.GetInstance.SearchFlight (AirlineCode, "AirlineCode"));
            } else {
                Views.GetInstance.DisplaySearchFlightByACForm ();
            }
        }
        public void GetSearchFlightByODInput (string Origin, string Destination) {
            if (Validation.GetInstance.IsValidArrivalDepartureStation (Origin) && Validation.GetInstance.IsValidArrivalDepartureStation (Destination)) {
                Views.GetInstance.DisplayFilteredFlights (Services.GetInstance.SearchFlight (Origin + Destination, "OriginDestination"));
            } else {
                Views.GetInstance.DisplaySearchFlightByODForm ();
            }
        }
        public void GetReservationsMenuInput (string input) {
            if (Validation.GetInstance.IsValidNumberInput (input, 3)) {
                if (input == "1") {
                    Views.GetInstance.DisplayReserveFlightFormA ();
                } else if (input == "2") {

                } else if (input == "3") {

                }
            } else {
                Views.GetInstance.DisplayMainMenu ();
            }
        }

        public void GetReservationsFormAInput (ReservationModel Reservation) {
            if (Services.GetInstance.FlightExists (Reservation)) {
                
            } else {
                Views.GetInstance.DisplayReservationMenu ();
            }
        }
    }
}