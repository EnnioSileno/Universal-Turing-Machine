using static Universal_Turing_Machine.UTMMachineCodeType;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class UTMCodePreconfiguration {

        public static string Preconfiguration(UTMMachineCodeType type) {
            return type == ADDITION ? getAddition() : getMultiplication();
        }

        private static string getAddition() {
            return "PLACEHOLDER_ADDITION";
        }

        private static string getMultiplication() {
            return "PLACEHOLDER_MULTIPLICATION";
        }
    }
}
