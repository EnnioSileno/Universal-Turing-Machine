using static Universal_Turing_Machine.MenuState;

using System.Collections.Generic;
using System;


namespace Universal_Turing_Machine {
    class MenuController {
        private Dictionary<MenuState, Menu> menus = new Dictionary<MenuState, Menu>();

        public MenuController() {
            Menu menuMain = new MenuMain();
            menus[INIT] = menuMain;
            menus[MAIN] = menuMain;
            menus[ABOUT] = new MenuAbout();
            menus[SIMULATION] = new MenuSimulation();
            menus[CLOSING] = new MenuClose();
        }

        public void start() {
            MenuState currentState = INIT;
            MenuState nextState = INIT;
            
            do {
                MenuState lastState = currentState;
                currentState = nextState;
                nextState = menus[currentState].Process(lastState);
            } while (nextState != STOPPED);
        }
    }
}
