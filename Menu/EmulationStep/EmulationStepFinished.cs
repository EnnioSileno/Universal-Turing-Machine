using static Universal_Turing_Machine.EmulationState;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class EmulationStepFinished : EmulationStep {
        private UniversalTuringMachine universalTuringMachine = UniversalTuringMachine.Instance();
        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {
            Console.WriteLine(universalTuringMachine.PrintResult());
            Console.WriteLine(universalTuringMachine);
            Console.WriteLine();
            Console.WriteLine("Press any key to go back to the main menu.");
            Console.ReadKey();
            return END;
        }
    }
}
