using static Universal_Turing_Machine.MenuState;

using System;

namespace Universal_Turing_Machine {
    class MenuAbout : MenuBase {
        public override MenuState Process(MenuState lastMenu) {
            base.Process(lastMenu);

            Console.WriteLine("Universal Turing Machine C#, first written in Java, was one of my");
            Console.WriteLine("projects from my computer science studies, which I rewrote in C#.");
            Console.WriteLine("It emulates an universal turing machine. The addition and");
            Console.WriteLine("the multiplication are already preconfigured.");
            //" there is the possibility");
            //Console.WriteLine("to program your own Turing machine by entering a binary string.");
            Console.WriteLine("\n");
            Console.WriteLine("Below follows an example of the used Syntax of a TM");
            Console.WriteLine("*  A TM is expressed as a 7-tuple (Q, Γ, B, ∑, δ, q0, F) where:");
            Console.WriteLine("*    - Q: is a finite set of states");
            Console.WriteLine("*    - ∑: is the input alphabet");
            Console.WriteLine("*    - Γ: is the tape alphabet");
            Console.WriteLine("*    - δ: is a transition function which maps Q × Γ^k → Q × Γ^k × D^k.");
            Console.WriteLine("*    - q0: is the initial state");
            Console.WriteLine("*    - _: is blank symbol");
            Console.WriteLine("*    - F: is the set of final states.");
            Console.WriteLine("*");
            Console.WriteLine("*  A transition funciton δ of a TM using three tapes is defined as followed:");
            Console.WriteLine("*  δ : Q × Γ^k → Q × Γ^k × D^k");
            Console.WriteLine("*    - Q = state");
            Console.WriteLine("*    - Γ is element of {'0', '1', '_'}, Tape alphabet");
            Console.WriteLine("*    - D is element of {LEFT, RIGHT, NEUTRAL}, Head movement");
            Console.WriteLine("*    - k = number of tapes (here = 3)");
            Console.WriteLine("\n");
            Console.Write("Press any key to go back to the main menu: ");
            Console.ReadKey();
            return MAIN;
        }
    }
}
