using static Universal_Turing_Machine.EmulationState;
using static Universal_Turing_Machine.UTMRuntimeMode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class EmulationStepModeSelection : EmulationStep {

        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {
            EmulationState nextEmulationState = lastEmulationState;
            if (lastEmulationState == MODE_SELECTION) {
                Console.WriteLine("Please enter a valid option. Example: Enter \"1\" to select Addition.");
            }
            Console.WriteLine("To setup the emulated turing machine enter one of the following options:");
            Console.WriteLine("    [1] Step by Step");
            Console.WriteLine("    [2] Continuous");
            Console.WriteLine("    (b) To go back to the last configuration step");
            Console.Write("Input a character (default [1]): ");
            string input = Console.ReadLine().ToLower();
            switch (input) {
                case "":
                case "1":
                    utmConfiguration.UTMRuntimeMode = STEP;
                    nextEmulationState = OVERVIEW;
                    break;
                case "2":
                    utmConfiguration.UTMRuntimeMode = CONTINUOUS;
                    nextEmulationState = OVERVIEW; break;
                case "b": nextEmulationState = VALUE_SELECTION; break;
                default: nextEmulationState = INTRO; break;
            }
            return nextEmulationState;
        }
    }
}
