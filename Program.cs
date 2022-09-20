using static Universal_Turing_Machine.ProgramStatus;
using System;


namespace Universal_Turing_Machine {

    class Program {

        static void Main(string[] args) {
            ProgramStatus nextProgramStatus = INIT;
            ProgramStatus lastProgramStatus = INIT;
         
            do {
                switch (nextProgramStatus) {
                    case INIT:
                    case MAIN:
                        lastProgramStatus = nextProgramStatus;
                        nextProgramStatus = new MenuMain().Process(lastProgramStatus);
                        break;
                    case ABOUT:
                        lastProgramStatus = nextProgramStatus;
                        nextProgramStatus = new MenuAbout().Process(lastProgramStatus);
                        break;
                    case CLOSING:
                        lastProgramStatus = nextProgramStatus;
                        nextProgramStatus = new MenuClose().Process(lastProgramStatus);
                        break;
                    case SIMULATION:
                        lastProgramStatus = nextProgramStatus;
                        nextProgramStatus = new MenuSimulation().Process(lastProgramStatus);
                        break;
                    default:
                        Console.WriteLine("Something bad happened - going back to the main menu");
                        nextProgramStatus = MAIN;
                        break;
                }     
            } while (nextProgramStatus != STOPPED);
        }
    }
}
