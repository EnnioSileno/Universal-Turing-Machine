using static Universal_Turing_Machine.EmulationState;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class EmulationStepRunning : EmulationStep {
        
        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {
            UniversalTuringMachine universalTuringMachine = new UniversalTuringMachine();
            universalTuringMachine.start(utmConfiguration);
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            return END;
        }
    }
}
