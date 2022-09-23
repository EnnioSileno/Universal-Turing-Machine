using System;

namespace Universal_Turing_Machine {

    class Program {

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            MenuController menuController = new MenuController();
            menuController.start();
        }
    }
}
