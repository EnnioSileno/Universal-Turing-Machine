using static Universal_Turing_Machine.MenuState;
using System;

namespace Universal_Turing_Machine {
    class MenuClose : Menu {
        public MenuState Process(MenuState lastMenu) {
            Console.Clear();
            Console.WriteLine("***************************************");
            Console.WriteLine("Universal Turing Machine C# has stopped");
            Console.WriteLine("***************************************");
            return STOPPED;
        }
    }
}
