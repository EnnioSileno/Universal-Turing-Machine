using static Universal_Turing_Machine.EmulationState;
using static Universal_Turing_Machine.UTMRuntimeMode;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class EmulationStepRunning : EmulationStep {
        UniversalTuringMachine universalTuringMachine = UniversalTuringMachine.Instance();

        public override EmulationState Process(EmulationState comingFromEmulationState, UTMConfiguration utmConfiguration) {

            EmulationState nextState = comingFromEmulationState;
            switch (comingFromEmulationState) {
                case OVERVIEW:
                    universalTuringMachine.RunNewConfiguration(utmConfiguration);
                    nextState = RUNNING;
                    break;
                case RUNNING:
                    char input = ' ';
                    if (utmConfiguration.UTMRuntimeMode == STEP) {
                        Console.WriteLine(universalTuringMachine);
                        Console.WriteLine("Your options are: (b) to go back one transition  |  (e) to go to the end  |  any other key to continue");
                        Console.Write("Your input: ");
                        input = Console.ReadKey().KeyChar;
                        switch (input) {
                            case 'b':
                                universalTuringMachine.GoBackOneTransition();
                                nextState = RUNNING;
                                break;
                            case 'e':
                                utmConfiguration.UTMRuntimeMode = CONTINUOUS;
                                break;
                            default:
                                break;
                        }
                    }
                    if(input != 'b') nextState = universalTuringMachine.executeNextTransition();
                    break;
                case FINNISHED:
                    nextState = END;
                    
                    break;
                default:
                    break;
            }
            return nextState;
        }
    }
}
