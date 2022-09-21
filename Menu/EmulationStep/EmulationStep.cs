using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    abstract class EmulationStep {
        public abstract EmulationState Process(EmulationState lastEmulationState, UTMConfiguration utmConfiguration);
    }
}
