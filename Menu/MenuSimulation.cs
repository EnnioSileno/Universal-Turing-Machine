using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class MenuSimulation : Menu {
        public ProgramStatus Process(ProgramStatus current) {
            Console.WriteLine("Here is the Simulation menu.");
            return ProgramStatus.MAIN;
        }
    }
}
