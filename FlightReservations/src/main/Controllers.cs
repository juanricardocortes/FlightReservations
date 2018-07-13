using System;

namespace main {
    public class Controllers {
        Services service = new Services ();
        Validation validate = new Validation ();
        Views view = new Views ();
        public void InitializeConnections () {
            service.GetData ();
        }

        public void GetMainMenuInput (string input) {
            if (validate.ValidateNumberInput (input, 2)) {
                if (input == "1") {
                    view.DisplayMaintenanceMenu ();
                } else if (input == "2") {
                    view.DisplayReservationMenu ();
                }
            } else {
                view.DisplayMainMenu ();
            }
        }

        public void GetMaintainanceMenuInput (string input) {
            if (validate.ValidateNumberInput (input, 2)) {
                if (input == "1") {

                } else if (input == "2") {

                }
            } else {
                view.DisplayMainMenu ();
            }
        }

        public void GetReservationsMenuInput (string input) {
            if (validate.ValidateNumberInput (input, 3)) {
                if (input == "1") {

                } else if (input == "2") {

                }
            } else {
                view.DisplayMainMenu ();
            }
        }
    }
}