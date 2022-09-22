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
        public string MachineConfiguration { get { return machineConfiguration; } }
        private UTMCodeType utmCodeType;
        public UTMCodeType UTMCodeType {
            get { return utmCodeType; }
            set { utmCodeType = value; }
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
            set
            {
                secondValue = value;
                machineConfiguration = createMachineCodeString();      
            }
        }

        public UTMConfiguration() {
            clearConfiguration();
        }

        public void clearConfiguration() {
            machineConfiguration = "";
            utmCodeType = ADDITION;
            utmMode = STEP;
        }

        private string createMachineCodeString() {
            return $"{UTMCodePreconfiguration.Preconfiguration(utmCodeType)}111{firstValue}*{secondValue}";
        }
    }
}
