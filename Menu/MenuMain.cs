using static Universal_Turing_Machine.ProgramStatus;
using System;

namespace Universal_Turing_Machine {
    class MenuMain : Menu {
        public ProgramStatus Process(ProgramStatus current) {
            ProgramStatus menuType = MAIN;
            string input = "";

            if (current != MAIN) printTitle();
            Console.WriteLine("Your options are: (a) about  |  (s) start  |  (e) exit ");
                Console.Write("Input a character: ");
                input = Console.ReadLine().ToLower();
                switch (input) {
                    case "a": menuType = ABOUT; break;
                    case "s": menuType = SIMULATION; break;
                    case "e": menuType = CLOSING; break;
                    default:
                        Console.WriteLine("Please enter a valid character. Example: Enter \"a\" to get to the About menu.");
                        break;
                }
            return menuType;
        }

        private void printTitle() {
            Console.WriteLine("\n");
            Console.WriteLine("***************************************");
            Console.WriteLine("Universal Turing Machine C#");
            Console.WriteLine("***************************************");
            Console.WriteLine("\n");
        }
    }
}
