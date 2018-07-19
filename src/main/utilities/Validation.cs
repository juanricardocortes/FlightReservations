using System;
using System.Text.RegularExpressions;
using FlightReservationLibrary;

namespace main {
    public class Validation {

        //Regex 
        Regex alphanumeric = new Regex ("^[A-Z0-9]*$");
        Regex letters = new Regex ("^[a-zA-Z]+$");
        Regex numbers = new Regex ("^[0-9]+$");
        Regex time = new Regex("^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$");
        Regex date = new Regex("^([0]\\d|[1][0-2])\\/([0-2]\\d|[3][0-1])\\/([2][01]|[1][6-9])\\d{2}(\\s([0-1]\\d|[2][0-3])(\\:[0-5]\\d){1,2})?$");

        // Singleton
        private static Validation ValidationInstance = null;
        public static Validation GetInstance {
            get {
                if (ValidationInstance == null) {
                    ValidationInstance = new Validation ();
                }
                return ValidationInstance;
            }
        }
        private Validation () { }

        // Validation Methods
        public bool IsValidNumberInput (string option, int max) {
            try {
                if (int.TryParse (option, out int n)) {
                    if (n >= 1 && n <= max) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } catch (Exception) {
                return false;
            }
        }
        public bool IsValidAirlineCode (string AirlineCode) {
            const int AirlinCodeLength = 2;
            if (alphanumeric.IsMatch (AirlineCode) && AirlineCode.Length == AirlinCodeLength) {
                if (numbers.IsMatch (AirlineCode[0].ToString ())) {
                    if (numbers.IsMatch (AirlineCode[1].ToString ())) {
                        return false;
                    } else {
                        return true;
                    }
                } else {
                    return true;
                }
            } else {
                return false;
            }
        }
        public bool IsValidFlightNumber (string FlightNumber) {
            const int FlightNumberLength = 4;
            if (numbers.IsMatch (FlightNumber) && FlightNumber.Length == FlightNumberLength) {
                return true;
            } else {
                return false;
            }
        }
        public bool IsValidName (string Name) {
            if (Name.Length <= 64 && letters.IsMatch (Name)) {
                return true;
            } else {
                return false;
            }
        }
        public bool IsValidArrivalDepartureStation (string Station) {
            const int StationLength = 3;
            if (alphanumeric.IsMatch (Station) && Station.Length == StationLength) {
                return true;
            } else {
                return false;
            }
        }
        public bool IsValidDepartureTime (string DepartureTime) {
            return time.IsMatch(DepartureTime);
        }
        public bool IsValidArrivalTime (string ArrivalTime, string DepartureTime) {
            var tArrivalTime = TimeSpan.Parse (ArrivalTime);
            var tDepartureTime = TimeSpan.Parse (DepartureTime);
            return (tArrivalTime > tDepartureTime) && time.IsMatch(ArrivalTime);
        }
        public bool IsNotPastDate (string FlightDate) {
            try {
                DateTime parsedDate = DateTime.Parse (FlightDate);
                return (parsedDate > DateTime.Now) && date.IsMatch(FlightDate);
            } catch (Exception) {
                return false;
            }
        }
        public bool IsNotFutureDate (string Birthday) {
            try {
                DateTime parsedDate = DateTime.Parse (Birthday);
                return (parsedDate < DateTime.Now) && date.IsMatch(Birthday);
            } catch (Exception) {
                return false;
            }
        }
    }
}