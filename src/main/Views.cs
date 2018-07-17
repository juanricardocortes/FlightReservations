using System;
using System.Collections.Generic;
using FlightReservationLibrary;

namespace main {
    public class Views {

        static void Main (string[] args) {
            MainMenuController.GetInstance.InitializeConnections ();
            List<FlightModel> ListOfFlights = MainMenuServices.ListOfFlights;
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
            MainMenuController.GetInstance.GetMainMenuInput (Console.ReadLine ());
        }
        public void DisplayMaintenanceMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Add flight");
            Console.WriteLine ("[2] Search Flight");
            Console.Write ("Choose one of the options: ");
            MainMenuController.GetInstance.GetMaintainanceMenuInput (Console.ReadLine ());
        }
        public void DisplayAddFlightForm () {
            FlightModel Flight = new FlightModel ();
            Console.Clear ();

            while (true) {
                Console.Write ("\nEnter airline code: ");
                Flight.strAirlineCode = Console.ReadLine ();
                if (Validation.GetInstance.IsValidAirlineCode (Flight.strAirlineCode)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid airline code");
                }
            }

            while (true) {
                Console.Write ("\nEnter flight number: ");
                Flight.strFlightNumber = Console.ReadLine ();
                if (Validation.GetInstance.IsValidFlightNumber (Flight.strFlightNumber)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid flight number");
                }
            }

            while (true) {
                Console.Write ("\nEnter arrival station: ");
                Flight.strArrivalStation = Console.ReadLine ();
                if (Validation.GetInstance.IsValidArrivalDepartureStation (Flight.strArrivalStation)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid arrival station");
                }
            }

            while (true) {
                Console.Write ("\nEnter departure station: ");
                Flight.strDepartureStation = Console.ReadLine ();
                if (Validation.GetInstance.IsValidArrivalDepartureStation (Flight.strDepartureStation)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid departure station");
                }
            }

            while (true) {
                Console.Write ("\nEnter scheduled time of departure: ");
                Flight.strSTD = Console.ReadLine ();
                if (Validation.GetInstance.IsValidDepartureTime (Flight.strSTD)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid departure time");
                }
            }

            while (true) {
                Console.Write ("\nEnter scheduled time of arrival: ");
                Flight.strSTA = Console.ReadLine ();
                if (Validation.GetInstance.IsValidArrivalTime (Flight.strSTA, Flight.strSTD)) {
                    break;
                } else {
                    Console.WriteLine ("*Invalid arrival time");
                }
            }

            FlightMaintenanceController.GetInstance.GetAddFlightForm (Flight);

        }
        public void DisplaySearchFlightMenu () {
            Console.Clear ();
            Console.WriteLine ("[1] Search by flight number");
            Console.WriteLine ("[2] Search by airline code");
            Console.WriteLine ("[3] Search by origin/destination");
            Console.Write ("Choose one of the options: ");
            FlightMaintenanceController.GetInstance.GetSearchFlightMenuInput (Console.ReadLine ());
        }
        public void DisplaySearchFlightByFNForm () {
            Console.Clear ();
            Console.Write ("\nEnter flight number: ");
            FlightMaintenanceController.GetInstance.GetSearchFlightByFNInput (Console.ReadLine ());
        }
        public void DisplaySearchFlightByACForm () {
            Console.Clear ();
            Console.Write ("\nEnter airline code: ");
            FlightMaintenanceController.GetInstance.GetSearchFlightByACInput (Console.ReadLine ());
        }
        public void DisplaySearchFlightByODForm () {
            Console.Clear ();
            Console.Write ("\nEnter origin: ");
            string origin = Console.ReadLine ();
            Console.Write ("\nEnter destination: ");
            string destination = Console.ReadLine ();
            FlightMaintenanceController.GetInstance.GetSearchFlightByODInput (origin, destination);
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
            FlightReservationsController.GetInstance.GetReservationsMenuInput (Console.ReadLine ());
        }
        public void DisplayReserveFlightFormA () {
            Console.Clear ();
            ReservationModel Reservation = new ReservationModel ();

            while (true) {
                Console.Write ("\nEnter airline code: ");
                Reservation.strAirlineCode = Console.ReadLine ();
                if (Validation.GetInstance.IsValidAirlineCode (Reservation.strAirlineCode)) {
                    break;
                } else {
                    Console.Write ("\n*Invalid airline code.");
                }
            }

            while (true) {
                Console.Write ("\nEnter flight number: ");
                Reservation.strFlightNumber = Console.ReadLine ();
                if (Validation.GetInstance.IsValidFlightNumber (Reservation.strFlightNumber)) {
                    break;
                } else {
                    Console.Write ("\n*Invalid flight number.");
                }
            }

            FlightReservationsController.GetInstance.GetReservationsFormAInput (Reservation);
        }
        public void DisplayMatchingFlights (ReservationModel Reservation, List<FlightModel> MatchingFlights) {
            Console.Clear ();
            if (MatchingFlights.Count > 0) {
                int Counter = 1;
                foreach (FlightModel Flight in MatchingFlights) {
                    Console.WriteLine ("[{0}]", Counter);
                    Console.WriteLine ("Airline Code: {0}", Flight.strAirlineCode);
                    Console.WriteLine ("Flight Number: {0}", Flight.strFlightNumber);
                    Console.WriteLine ("Arrival Station: {0}", Flight.strArrivalStation);
                    Console.WriteLine ("Departure Station: {0}", Flight.strDepartureStation);
                    Console.WriteLine ("Scheduled Time of Arrival: {0}", Flight.strSTA);
                    Console.WriteLine ("Scheduled Time of Departure: {0}", Flight.strSTD);
                    Console.WriteLine ("-----------------------------------------------");
                    Counter++;
                }
                string FlightIndex;
                while (true) {
                    Console.WriteLine ("Choose a flight to book: ");
                    FlightIndex = Console.ReadLine ();
                    if (Validation.GetInstance.IsValidNumberInput (FlightIndex, MatchingFlights.Count)) {
                        break;
                    } else {
                        Console.WriteLine ("*Invalid input");
                    }
                }
                FlightReservationsController.GetInstance.GetChooseReservationInput (MatchingFlights[Convert.ToInt32 (FlightIndex) - 1], Reservation);
            } else {
                Console.WriteLine ("No flights found!");
            }

        }
        public void DisplayReserveFlightFormB (ReservationModel Reservation) {
            Console.Clear ();
            while (true) {
                Console.Write ("\nEnter flight date: ");
                Reservation.strFlightDate = Console.ReadLine ();
                if (Validation.GetInstance.IsNotPastDate (Reservation.strFlightDate)) {
                    break;
                } else {
                    Console.Write ("\n*Invalid date.");
                }
            }
            while (true) {
                Console.Write ("\nEnter number of passengers: ");
                string NumberOfPassengers = Console.ReadLine ();
                if (Validation.GetInstance.IsValidNumberInput (NumberOfPassengers, 5)) {
                    for (int i = 1; i <= Convert.ToInt32 (NumberOfPassengers); i++) {
                        while (true) {
                            Console.Write ("\nEnter first name for passenger {0}: ", i);
                            Reservation.strFirstName = Console.ReadLine ();
                            if (Validation.GetInstance.IsValidName (Reservation.strFirstName)) {
                                break;
                            } else {
                                Console.Write ("\n*Invalid first name.");
                            }
                        }
                        while (true) {
                            Console.Write ("\nEnter last name for passenger {0}: ", i);
                            Reservation.strLastName = Console.ReadLine ();
                            if (Validation.GetInstance.IsValidName (Reservation.strLastName)) {
                                break;
                            } else {
                                Console.Write ("\n*Invalid last name.");
                            }
                        }
                        while (true) {
                            Console.Write ("\nEnter birthday for passenger {0}: ", i);
                            Reservation.strBirthday = Console.ReadLine ();
                            if (Validation.GetInstance.IsNotFutureDate (Reservation.strBirthday)) {
                                break;
                            } else {
                                Console.Write ("\n*Invalid birthday.");
                            }
                        }
                        FlightReservationsController.GetInstance.GetPassenger (Reservation);
                    }
                    break;
                } else {
                    Console.Write ("\nInvalid number of passengers");
                }
            }
        }
        public void DisplayFlightReservations (List<ReservationModel> FlightReservations) {
            Console.Clear ();
            if (FlightReservations.Count > 0) {
                foreach (ReservationModel Reservation in FlightReservations) {
                    Console.WriteLine ("--------------------------------------------");
                    Console.WriteLine ("Reservation Details");
                    Console.WriteLine ("Airline Code: {0}", Reservation.strAirlineCode);
                    Console.WriteLine ("Flight Number: {0}", Reservation.strFlightNumber);
                    Console.WriteLine ("Arrival Station: {0}", Reservation.strArrivalStation);
                    Console.WriteLine ("Departure Station: {0}", Reservation.strDepartureStation);
                    Console.WriteLine ("Scheduled Time of Arrival: {0}", Reservation.strSTA);
                    Console.WriteLine ("Scheduled Time of Departure: {0}", Reservation.strSTD);
                    Console.WriteLine ("Flight Date: {0}", Reservation.strFlightDate);
                    Console.WriteLine ("PNR: {0}", Reservation.strPNR);
                    Console.WriteLine ("First Name: {0}", Reservation.strFirstName);
                    Console.WriteLine ("Last Name: {0}", Reservation.strLastName);
                    Console.WriteLine ("Birthday: {0}", Reservation.strBirthday);
                    Console.WriteLine ("Age: {0}", Reservation.strAge);
                    Console.WriteLine ("--------------------------------------------");
                }
            } else {
                Console.WriteLine ("No flights found!");
            }
        }

        public void DisplayReservedPassengerDetails (ReservationModel Reservation) {
            Console.WriteLine ("--------------------------------------------");
            Console.WriteLine ("Reservation Details");
            Console.WriteLine ("Airline Code: {0}", Reservation.strAirlineCode);
            Console.WriteLine ("Flight Number: {0}", Reservation.strFlightNumber);
            Console.WriteLine ("Arrival Station: {0}", Reservation.strArrivalStation);
            Console.WriteLine ("Departure Station: {0}", Reservation.strDepartureStation);
            Console.WriteLine ("Scheduled Time of Arrival: {0}", Reservation.strSTA);
            Console.WriteLine ("Scheduled Time of Departure: {0}", Reservation.strSTD);
            Console.WriteLine ("Flight Date: {0}", Reservation.strFlightDate);
            Console.WriteLine ("PNR: {0}", Reservation.strPNR);
            Console.WriteLine ("First Name: {0}", Reservation.strFirstName);
            Console.WriteLine ("Last Name: {0}", Reservation.strLastName);
            Console.WriteLine ("Birthday: {0}", Reservation.strBirthday);
            Console.WriteLine ("Age: {0}", Reservation.strAge);
            Console.WriteLine ("--------------------------------------------");
            Console.WriteLine ("Press enter to continue.......");
            Console.ReadLine ();
        }
    }
}