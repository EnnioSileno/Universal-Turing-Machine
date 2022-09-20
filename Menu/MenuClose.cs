using static Universal_Turing_Machine.ProgramStatus;
using System;

namespace Universal_Turing_Machine {
    class MenuClose : Menu {
        public ProgramStatus Process(ProgramStatus current) {
            Console.WriteLine("\n");
            Console.WriteLine("***************************************");
            Console.WriteLine("Universal Turing Machine C# has stopped");
            Console.WriteLine("***************************************");
            return STOPPED;
        }
    }
}
