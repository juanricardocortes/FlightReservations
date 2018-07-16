using System;
using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class Views {

        static void Main (string[] args) {
            Controllers.GetInstance.InitializeConnections ();
            List<FlightModel> ListOfFlights = Services.ListOfFlights;
            while (true) {
                Views.GetInstance.DisplayMainMenu ();
            }
        }

        // Singleton
        private static Views ViewInstance = null;
        public static Views GetInstance {
            get {
                if (ViewInstance == null) {
                    ViewInstance = new Views ();
                }
                return ViewInstance;
            }
        }
        private Views () { }

        // Display Methods
        public void DisplayMainMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Flight Maintenance");
            Console.WriteLine ("[2] Flight Reservation");
            Console.Write ("Choose one of the options: ");
            Controllers.GetInstance.GetMainMenuInput (Console.ReadLine ());
        }
        public void DisplayMaintenanceMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Add flight");
            Console.WriteLine ("[2] Search Flight");
            Console.Write ("Choose one of the options: ");
            Controllers.GetInstance.GetMaintainanceMenuInput (Console.ReadLine ());
        }
        public void DisplayAddFlightForm () {
            FlightModel flight = new FlightModel ();
            Console.Clear ();

            while (true) {
                Console.Write ("\nEnter airline code: ");
                flight.strAirlineCode = Console.ReadLine ();
                if (Validation.GetInstance.IsValidAirlineCode (flight.strAirlineCode)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid airline code");
                }
            }

            while (true) {
                Console.Write ("\nEnter flight number: ");
                flight.strFlightNumber = Console.ReadLine ();
                if (Validation.GetInstance.IsValidFlightNumber (flight.strFlightNumber)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid flight number");
                }
            }

            while (true) {
                Console.Write ("\nEnter arrival station: ");
                flight.strArrivalStation = Console.ReadLine ();
                if (Validation.GetInstance.IsValidArrivalDepartureStation (flight.strArrivalStation)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid arrival station");
                }
            }

            while (true) {
                Console.Write ("\nEnter departure station: ");
                flight.strDepartureStation = Console.ReadLine ();
                if (Validation.GetInstance.IsValidArrivalDepartureStation (flight.strDepartureStation)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid departure station");
                }
            }

            while (true) {
                Console.Write ("\nEnter scheduled time of departure: ");
                flight.strSTD = Console.ReadLine ();
                if (Validation.GetInstance.IsValidDepartureTime (flight.strSTD)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid departure time");
                }
            }

            while (true) {
                Console.Write ("\nEnter scheduled time of arrival: ");
                flight.strSTA = Console.ReadLine ();
                if (Validation.GetInstance.IsValidArrivalTime (flight.strSTA, flight.strSTD)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid arrival time");
                }
            }

            Controllers.GetInstance.GetAddFlightForm (flight);

        }
        public void DisplaySearchFlightMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Search by flight number");
            Console.WriteLine ("[2] Search by airline code");
            Console.WriteLine ("[3] Search by origin/destination");
            Console.Write ("Choose one of the options: ");
            Controllers.GetInstance.GetSearchFlightMenuInput (Console.ReadLine ());
        }
        public void DisplaySearchFlightByFNForm () {
            Console.Clear ();
            Console.Write ("\nEnter flight number: ");
            Controllers.GetInstance.GetSearchFlightByFNInput (Console.ReadLine ());
        }
        public void DisplaySearchFlightByACForm () {
            Console.Clear ();
            Console.Write ("\nEnter airline code: ");
            Controllers.GetInstance.GetSearchFlightByACInput (Console.ReadLine ());
        }
        public void DisplaySearchFlightByODForm () {
            Console.Clear ();
            Console.Write ("\nEnter origin: ");
            string origin = Console.ReadLine ();
            Console.Write ("\nEnter destination: ");
            string destination = Console.ReadLine ();
            Controllers.GetInstance.GetSearchFlightByODInput (origin, destination);
        }
        public void DisplayFilteredFlights (List<FlightModel> FilteredFlights) {
            Console.Clear ();
            if (FilteredFlights.Count > 0) {
                foreach (FlightModel Flight in FilteredFlights) {
                    Console.WriteLine ("Airline Code: {0}", Flight.strAirlineCode);
                    Console.WriteLine ("Flight Number: {0}", Flight.strFlightNumber);
                    Console.WriteLine ("Arrival Station: {0}", Flight.strArrivalStation);
                    Console.WriteLine ("Departure Station: {0}", Flight.strDepartureStation);
                    Console.WriteLine ("Scheduled Time of Arrival: {0}", Flight.strSTA);
                    Console.WriteLine ("Scheduled Time of Departure: {0}", Flight.strSTD);
                    Console.WriteLine ("-----------------------------------------------");
                }
            } else {
                Console.WriteLine ("No flights found!");
            }
        }
        public void DisplayReservationMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Create a reservation");
            Console.WriteLine ("[2] List all reservations");
            Console.WriteLine ("[3] Search by PNR number");
            Console.Write ("Choose one of the options: ");
            Controllers.GetInstance.GetReservationsMenuInput (Console.ReadLine ());
        }

    }
}