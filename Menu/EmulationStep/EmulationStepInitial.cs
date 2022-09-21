using static Universal_Turing_Machine.EmulationState;
using static Universal_Turing_Machine.UTMCodeType;
using System;

namespace Universal_Turing_Machine {
    class EmulationStepInitial : EmulationStep {
        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {
            EmulationState nextEmulationState = lastEmulationState;
            if (lastEmulationState == INTRO) {
                Console.WriteLine("Please enter a valid option. Example: Enter \"1\" to select Addition.");
            }
            Console.WriteLine("To setup the emulated turing machine enter one of the following options:");
            Console.WriteLine("    [1] Addition");
            Console.WriteLine("    [2] Multiplication");
            Console.WriteLine("    (b) To go back to the main menu");
            Console.Write("Input a character (default [1]): ");
            string input = Console.ReadLine().ToLower();
            switch (input) {
                case "":
                case "1":
                    utmConfiguration.UTMCodeType = ADDITION;
                    nextEmulationState = VALUE_SELECTION;
                    break;
                case "2":
                    utmConfiguration.UTMCodeType = MULTIPLICATION;
                    nextEmulationState = VALUE_SELECTION; break;
                case "b": nextEmulationState = END; break;
                default: nextEmulationState = INTRO; break;
            }
            return nextEmulationState;     
        }
    }
}
