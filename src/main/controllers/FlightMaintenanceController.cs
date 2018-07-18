using System;
using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class FlightMaintenanceController {

        // singleton
        private static FlightMaintenanceController ControllerInstance = null;
        public static FlightMaintenanceController GetInstance {
            get {
                if (ControllerInstance == null) {
                    ControllerInstance = new FlightMaintenanceController ();
                }
                return ControllerInstance;
            }
        }
        private FlightMaintenanceController () { }
       
        // controller methods
        public void GetAddFlightForm (FlightModel flight) {
            FlightMaintenanceServices.GetInstance.AddFlight (flight);
            MainMenuServices.GetInstance.GetAllFlights ();
        }
        public void GetSearchFlightMenuInput (string input) {
            if (Validation.GetInstance.IsValidNumberInput (input, 3)) {
                if (input == "1") {
                    Views.GetInstance.DisplaySearchFlightByFNForm ();
                } else if (input == "2") {
                    Views.GetInstance.DisplaySearchFlightByACForm ();
                } else if (input == "3") {
                    Views.GetInstance.DisplaySearchFlightByODForm ();
                }
            } else {
                Views.GetInstance.DisplaySearchFlightMenu ();
            }
        }
        public void GetSearchFlightByFNInput (string FlightNumber) {
            if (Validation.GetInstance.IsValidFlightNumber (FlightNumber)) {
                Views.GetInstance.DisplayFilteredFlights (FlightMaintenanceServices.GetInstance.SearchFlight (FlightNumber, "FlightNumber"));
            } else {
                Views.GetInstance.DisplaySearchFlightByFNForm ();
            }
        }
        public void GetSearchFlightByACInput (string AirlineCode) {
            if (Validation.GetInstance.IsValidAirlineCode (AirlineCode)) {
                Views.GetInstance.DisplayFilteredFlights (FlightMaintenanceServices.GetInstance.SearchFlight (AirlineCode, "AirlineCode"));
            } else {
                Views.GetInstance.DisplaySearchFlightByACForm ();
            }
        }
        public void GetSearchFlightByODInput (string Origin, string Destination) {
            if (Validation.GetInstance.IsValidArrivalDepartureStation (Origin) && Validation.GetInstance.IsValidArrivalDepartureStation (Destination)) {
                Views.GetInstance.DisplayFilteredFlights (FlightMaintenanceServices.GetInstance.SearchFlight (Origin + Destination, "OriginDestination"));
            } else {
                Views.GetInstance.DisplaySearchFlightByODForm ();
            }
        }
    }
}