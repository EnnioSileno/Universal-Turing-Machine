using static Universal_Turing_Machine.UTMCodeType;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class UTMCodePreconfiguration {

        public static string Preconfiguration(UTMCodeType type) {
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
