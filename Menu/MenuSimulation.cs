using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class MenuSimulation : MenuBase {
        public override MenuState Process(MenuState lastMenu) {
            base.Process(lastMenu);
            Console.WriteLine("Here is the Simulation menu.");
            Console.Write("Press any key to go back to the main menu: ");
            Console.ReadKey();
            return MenuState.MAIN;
        }
    }
}
