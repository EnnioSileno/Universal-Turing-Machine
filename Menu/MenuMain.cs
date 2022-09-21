using static Universal_Turing_Machine.MenuState;
using System;

namespace Universal_Turing_Machine {
    class MenuMain : MenuBase {
        public override MenuState Process(MenuState lastMenu) {
            base.Process(lastMenu);

            if (lastMenu == MAIN) {
                Console.WriteLine("Please enter a valid character. Example: Enter \"a\" to get to the About menu.");
            }
            Console.WriteLine("Your options are: (a) about  |  (s) start  |  (e) exit ");
            Console.Write("Input a character (default (s): ");
            string input = Console.ReadLine().ToLower();
            switch (input) {
                case "a": return ABOUT;
                case "":
                case "s": return SIMULATION;
                case "e": return CLOSING;
                default: return MAIN;
            }
        }
    }
}
