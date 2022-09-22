using static Universal_Turing_Machine.MenuState;
using static Universal_Turing_Machine.UTMCodeType;
using static Universal_Turing_Machine.UTMRuntimeMode;
using static Universal_Turing_Machine.EmulationState;

using System;
using System.Collections.Generic;

namespace Universal_Turing_Machine {
    class MenuEmulation : MenuBase {
        private Dictionary<EmulationState, EmulationStep> steps = new Dictionary<EmulationState, EmulationStep>();
        private UTMConfiguration utmConfiguration; 

        public MenuEmulation() {
            utmConfiguration = new UTMConfiguration();
            steps[INTRO] = new EmulationStepInitial();
            steps[VALUE_SELECTION] = new EmulationStepValueSelection();
            steps[MODE_SELECTION] = new EmulationStepModeSelection();
            steps[OVERVIEW] = new EmulationStepOverview();
        }

        public override MenuState Process(MenuState lastMenuState) {
            MenuState nextMenuState = lastMenuState;
            EmulationState currentEmulationState = INTRO;
            EmulationState nextEmulationState = INTRO;
            
            do {
                EmulationState lastEmulationState = currentEmulationState;
                currentEmulationState = nextEmulationState;

                printHeader(currentEmulationState);
                nextEmulationState = steps[currentEmulationState].Process(lastEmulationState, utmConfiguration);
            } while (nextEmulationState != END);
            return nextMenuState;
        }

        public void printHeader(EmulationState emulationState) {
            base.Process(EMULATION);
            Console.WriteLine($"Current emulation state: {emulationState}");
            if (emulationState >= VALUE_SELECTION) {
                Console.WriteLine("* Chosen Preconfiguration");
                Console.WriteLine($"* {(utmConfiguration.UTMCodeType == ADDITION ? "->" : "  ")} [1] Addition");
                Console.WriteLine($"* {(utmConfiguration.UTMCodeType == MULTIPLICATION ? "->" : "  ")} [2] Multiplication");
                Console.WriteLine($"{(emulationState != VALUE_SELECTION ? "*" : "")}");
            }
            if (emulationState >= MODE_SELECTION) {
                Console.WriteLine($"* The {(utmConfiguration.UTMCodeType == ADDITION ? "first summand" : "multiplier")}: {utmConfiguration.FirstValue}");
                Console.WriteLine($"* The {(utmConfiguration.UTMCodeType == ADDITION ? "second summand" : "multiplicand")}: {utmConfiguration.SecondValue}");
                Console.WriteLine($"{(emulationState != MODE_SELECTION ? "*" : "")}");
            }
            if (emulationState >= OVERVIEW) {
                Console.WriteLine("* Chosen Runtime Mode");
                Console.WriteLine($"*   {(utmConfiguration.UTMRuntimeMode == STEP ? "->" : "  ")} [1] Step");
                Console.WriteLine($"*   {(utmConfiguration.UTMRuntimeMode == CONTINUOUS ? "->" : "  ")} [2] Continuous");
                Console.WriteLine("\n");
            }
        }
    }
}
