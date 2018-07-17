namespace main {
    public class MainMenuController {
        // singleton
        private static MainMenuController ControllerInstance = null;
        public static MainMenuController GetInstance {
            get {
                if (ControllerInstance == null) {
                    ControllerInstance = new MainMenuController ();
                }
                return ControllerInstance;
            }
        }

        // controller methods
        public void InitializeConnections () {
            MainMenuServices.GetInstance.GetData ();
        }
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
    }
}