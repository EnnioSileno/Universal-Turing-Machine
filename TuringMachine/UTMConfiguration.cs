using static Universal_Turing_Machine.UTMCodeType;
using static Universal_Turing_Machine.UTMRuntimeMode;
using static Universal_Turing_Machine.EmulationState;

using System;

namespace Universal_Turing_Machine {

    enum UTMCodeType {
        ADDITION,
        MULTIPLICATION
    }

    enum UTMRuntimeMode {
        STEP,
        CONTINUOUS
    }

    class UTMConfiguration {

        private string machineConfiguration;
        private UTMCodeType utmCodeType;
        public UTMCodeType UTMCodeType {
            get { return utmCodeType; }
            set {
                utmCodeType = value;
                switch (value) {
                    case ADDITION:
                        machineConfiguration = UTMCodePreconfiguration.GetAddition();
                        break;
                    case MULTIPLICATION:
                        machineConfiguration = UTMCodePreconfiguration.GetMultiplication();
                        break;
                    default:
                        throw new ArgumentException($"There is no machine configuration for {value} preconfigured.");
                }
            }
        }
        private UTMRuntimeMode utmMode;
        public UTMRuntimeMode UTMRuntimeMode {
            get { return utmMode; }
            set { utmMode = value; }
        }

        private int firstValue;
        public int FirstValue
        {
            get { return firstValue; }
            set { firstValue = value; }
        }
        private int secondValue;
        public int SecondValue {
            get { return secondValue; }
            set { secondValue = value; }
        }

        public UTMConfiguration() {
            clearConfiguration();
        }

        public void clearConfiguration() {
            machineConfiguration = "";
            utmCodeType = ADDITION;
            utmMode = STEP;
        }

        public void printConfiguration(EmulationState emulationState) {
            if (emulationState >= VALUE_SELECTION) {
                Console.WriteLine("* Chosen Preconfiguration");
                Console.WriteLine($"* {(utmCodeType == ADDITION ? "->" : "  ")} [1] Addition");
                Console.WriteLine($"* {(utmCodeType == MULTIPLICATION ? "->" : "  ")} [2] Multiplication");
                Console.WriteLine($"{(emulationState != VALUE_SELECTION ? "*" :  "")}");
            } if (emulationState >= MODE_SELECTION) {
                Console.WriteLine($"* The {(utmCodeType == ADDITION ? "first summand" : "multiplier")}: {firstValue}");
                Console.WriteLine($"* The {(utmCodeType == ADDITION ? "second summand" : "multiplicand")}: {secondValue}");
                Console.WriteLine($"{(emulationState != MODE_SELECTION ? "*" : "")}\n");
            } if (emulationState >= OVERVIEW) {
                Console.WriteLine("* Chosen Runtime Mode");
                Console.WriteLine($"*   {(utmMode == STEP ? "->" : "  ")} [1] Step");
                Console.WriteLine($"*   {(utmMode == CONTINUOUS ? "->" : "  ")} [2] Continuous");
                Console.WriteLine("\n");
            }
        }
    }
}
