using System;
using System.Text.RegularExpressions;

namespace main {
    public class Validation {

        //Regex 
        Regex alphanumeric = new Regex ("^[a-zA-Z0-9]*$");
        Regex letters = new Regex ("^[a-zA-Z]+$");
        Regex numbers = new Regex ("^[0-9]+$");

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
            if (int.TryParse (option, out int n)) {
                if (n >= 1 && n <= max) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        public bool IsValidAirlineCode (string AirlineCode) {
            if (alphanumeric.IsMatch (AirlineCode) && AirlineCode.Length == 2) {
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
            if (numbers.IsMatch (FlightNumber) && FlightNumber.Length == 4) {
                return true;
            } else {
                return false;
            }
        }

        public bool IsValidArrivalDepartureStation (string ArrivalStation) {
            if (alphanumeric.IsMatch (ArrivalStation) && ArrivalStation.Length == 3) {
                return true;
            } else {
                return false;
            }
        }

        public bool IsValidDepartureTime (string DepartureTime) {
            return TimeSpan.TryParse (DepartureTime, out var dummyOutput);
        }

        public bool IsValidArrivalTime (string ArrivalTime, string DepartureTime) {
            var tArrivalTime  = TimeSpan.Parse(ArrivalTime);
            var tDepartureTime = TimeSpan.Parse(DepartureTime);
            return tArrivalTime > tDepartureTime;
        }
    }
}