using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    interface Menu {
        public MenuState Process(MenuState lastMenu);
    }
}
