using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class EmulationStepOverview : EmulationStep {
        public override EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration) {
            Console.Write("Press any key to continue: ");
            Console.ReadKey();
            return EmulationState.END;
        }
    }
}
