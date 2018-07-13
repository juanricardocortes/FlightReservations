namespace main {
    public class Validation {
        public bool ValidateNumberInput (string option, int max) {
            if (int.TryParse(option, out int n)){
                if (n >= 1 && n <= max) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }

        }
    }
}