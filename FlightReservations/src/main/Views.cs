using System;
using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class Views {
        Controllers controllers = new Controllers ();

        static void Main (string[] args) {
            Views view = new Views ();
            view.controllers.InitializeConnections ();
            List<FlightModel> ListOfFlights = Services.ListOfFlights;

            view.DisplayMainMenu ();
        }

        public void DisplayMainMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Flight Maintenance");
            Console.WriteLine ("[2] Flight Reservation");
            Console.Write ("Choose one of the options: ");
            controllers.GetMainMenuInput (Console.ReadLine ());
        }

        public void DisplayMaintenanceMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Add flight");
            Console.WriteLine ("[2] Search Flight");
            Console.Write ("Choose one of the options: ");
            controllers.GetMaintainanceMenuInput (Console.ReadLine ());
        }

        public void DisplayReservationMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Create a reservation");
            Console.WriteLine ("[2] List all reservations");
            Console.WriteLine ("[3] Search by PNR number");
            Console.Write ("Choose one of the options: ");
            controllers.GetReservationsMenuInput (Console.ReadLine ());
        }

        public void DisplayAddFlightForm () {
            Console.Clear ();
            Console.Write("\nEnter airline code");
        }

        public void DisplaySearchFlightMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Search by flight number");
            Console.WriteLine ("[2] Search by airline code");
            Console.WriteLine ("[3] Search by origin/destination");
            Console.Write ("Choose one of the options: ");
            controllers.GetReservationsMenuInput (Console.ReadLine ());
        }

        public void DisplaySearchFlightByFNForm () {

        }

        public void DispalySearchFlightByACForm () {

        }

        public void DisplaySearchFlightByODForm () {

        }

    }
}