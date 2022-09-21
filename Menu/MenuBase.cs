using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    abstract class MenuBase : Menu {
        public virtual MenuState Process(MenuState lastMenu) {
            printHeader();
            return lastMenu;
        }

        private void printHeader() {
            Console.Clear();
            Console.WriteLine("***************************************");
            Console.WriteLine("Universal Turing Machine C#");
            Console.WriteLine("***************************************");
            Console.WriteLine("\n");
        }
    }
}
