using static Universal_Turing_Machine.ProgramStatus;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class MenuAbout : Menu {
        public ProgramStatus Process(ProgramStatus current) {
            Console.WriteLine("Here is the About menu.");
            return MAIN;
        }
    }
}
