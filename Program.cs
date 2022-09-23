using System;
using System.Text.RegularExpressions;

namespace Universal_Turing_Machine {

    class Program {

        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
    /*
            string toTest = "0*23*0123";
            string pattern = "0|[1-9][0-9]*";//"^[0-9]+[0-9]*\\*[0-9]+[0-9]*$"
            MatchCollection match = Regex.Matches(toTest, pattern);

            Console.WriteLine(match.Count);
            Console.WriteLine(string.Join(", ", match));*/



            MenuController menuController = new MenuController();
            menuController.start();
        }
    }
}
