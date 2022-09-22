using static Universal_Turing_Machine.EmulationState;
using static Universal_Turing_Machine.UTMMachineCodeType;
using System;

namespace Universal_Turing_Machine {
    class EmulationStepValueSelection : EmulationStep {

        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {
            EmulationState nextEmulationState = lastEmulationState;

            if (lastEmulationState == VALUE_SELECTION) {
                Console.WriteLine("Please enter a valid value. Enter a positive Integer e.g 4.");
            }

            //First Input
            Console.WriteLine($"Enter (b) to go back to the TM-configuration selection or");
            Console.Write($"enter the {(utmConfiguration.UTMCodeType == ADDITION ? "first summand" : "multiplier")}: ");
            string input = Console.ReadLine().ToLower();
            if (input == "b") {
                return INTRO;
            } else if (isValidValue(input)) {
                utmConfiguration.FirstValue = Int32.Parse(input);
            } else {
                return VALUE_SELECTION;
            }

            //Second Input
            Console.Write($"Enter the {(utmConfiguration.UTMCodeType == ADDITION ? "second summand" : "multiplicand")}: ");
            input = Console.ReadLine().ToLower();
            if (input == "b") {
                return INTRO;
            } else if (isValidValue(input)) {
                utmConfiguration.SecondValue = Int32.Parse(input);
                nextEmulationState = MODE_SELECTION;
            } else {
                return VALUE_SELECTION;
            }
            return nextEmulationState;
        }
        private bool isValidValue(string input) {
            int intInput = 0;
            return Int32.TryParse(input, out intInput) && intInput >= 0;
        }
    }
}
