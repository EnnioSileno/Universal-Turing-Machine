using static Universal_Turing_Machine.EmulationState;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class EmulationStepOverview : EmulationStep {
        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {

            if (lastEmulationState == OVERVIEW) {
                Console.WriteLine("Please enter a valid option. Example: Enter \"1\" to select Addition.");
            }
            Console.WriteLine("Your options are:\n(s) to start  | (q) to see the machine string  |  (b) to go back to the Mode Selection   |  (a) to abort");
            Console.Write("Enter you input (default (s)): ");
            string input = Console.ReadLine();
            Console.WriteLine("\n");
            switch (input) {
                case "":
                case "s": return RUNNING;
                case "a": return INTRO;
                case "b": return MODE_SELECTION;
                case "q":
                    Console.WriteLine(utmConfiguration.MachineConfiguration);
                    break;
                default: return OVERVIEW;
            }
            Console.WriteLine("\n");
            Console.WriteLine("Your options are:\n(s) to start  |  (b) to go back to the Mode Selection   |  (a) to abort");
            Console.Write("Enter you input (default (s)): ");
            input = Console.ReadLine();
            switch (input) {
                case "":
                case "s": return RUNNING;
                case "a": return INTRO;
                case "b": return MODE_SELECTION;
                default: return OVERVIEW;
            }
        }
    }
}
