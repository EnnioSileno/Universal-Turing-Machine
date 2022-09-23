using static Universal_Turing_Machine.UTMMachineCodeType;
using static Universal_Turing_Machine.UTMHeadMovement;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class UTMCodePreconfiguration {
        public static readonly string TRANSITION_SEPARATOR = "11";
        public static readonly char VALUE_SEPARATOR = '1';
        public static readonly char VALUE = '0';

        public static string Preconfiguration(UTMMachineCodeType type) {
            return type == ADDITION ? getAddition() : getMultiplication();
        }

        private static string getAddition() {
            string turingCode = "";
            // δ : (q1, 0__) = (q1, __0, RNR)
            turingCode = encodeTransitionFunction(1, new char[] { '0', '_', '_' }, 1, new char[] { '_', '0', '_' },
                    new UTMHeadMovement[] { RIGHT, NEUTRAL, RIGHT });
            // δ : (q1, 1__) = (q3, ___, RNN)
            turingCode = encodeTransitionFunction(1, new char[] { '1', '_', '_' }, 3, new char[] { '_', '_', '_' },
                    new UTMHeadMovement[] { RIGHT, NEUTRAL, NEUTRAL });
            // δ : (q3, 0__) = (q3, __0, RNR)
            turingCode = encodeTransitionFunction(3, new char[] { '0', '_', '_' }, 3, new char[] { '_', '_', '0' },
                    new UTMHeadMovement[] { RIGHT, NEUTRAL, RIGHT });
            // δ : (q2, ___) = (q3, ___, NNN)
            turingCode = encodeTransitionFunction(2, new char[] { '_', '_', '_' }, 3, new char[] { '_', '_', '_' },
                    new UTMHeadMovement[] { NEUTRAL, NEUTRAL, NEUTRAL });
            turingCode += "1";
            return turingCode;
        }

        private static string getMultiplication() {
            string turingCode = "";
            //δ:(q1,0__)=(q1,_0_,RRN)
            turingCode = encodeTransitionFunction(1, new char[] { '0', '_', '_' }, 1, new char[] { '_', '0', '_' },
                    new UTMHeadMovement[] { RIGHT, RIGHT, NEUTRAL });
            //δ:(q1,1__)=(q3,___,RNN)
            turingCode += encodeTransitionFunction(1, new char[] { '1', '_', '_' }, 3, new char[] { '_', '_', '_' },
                    new UTMHeadMovement[] { RIGHT, NEUTRAL, NEUTRAL });
            //δ:(q3,0__)=(q4,0__,NLN)
            turingCode += encodeTransitionFunction(3, new char[] { '0', '_', '_' }, 4, new char[] { '0', '_', '_' },
                    new UTMHeadMovement[] { NEUTRAL, LEFT, NEUTRAL });
            //δ:(q4,00_)=(q4,00_,NLN)
            turingCode += encodeTransitionFunction(4, new char[] { '0', '0', '_' }, 4, new char[] { '0', '0', '_' },
                    new UTMHeadMovement[] { NEUTRAL, LEFT, NEUTRAL });
            //δ:(q4,0__)=(q5,0__,NRN)
            turingCode += encodeTransitionFunction(4, new char[] { '0', '_', '_' }, 5, new char[] { '0', '_', '_' },
                    new UTMHeadMovement[] { NEUTRAL, RIGHT, NEUTRAL });
            //δ:(q5,0__)=(q3,___,RNN)
            turingCode += encodeTransitionFunction(5, new char[] { '0', '_', '_' }, 3, new char[] { '_', '_', '_' },
                    new UTMHeadMovement[] { RIGHT, NEUTRAL, NEUTRAL });
            //δ:(q5,00_)=(q5,000,NRR)
            turingCode += encodeTransitionFunction(5, new char[] { '0', '0', '_' }, 5, new char[] { '0', '0', '0' },
                    new UTMHeadMovement[] { NEUTRAL, RIGHT, RIGHT });
            //δ:(q3,___)=(q2,___,NNN)
            turingCode += encodeTransitionFunction(3, new char[] { '_', '_', '_' }, 2, new char[] { '_', '_', '_' },
                   new UTMHeadMovement[] { NEUTRAL, NEUTRAL, NEUTRAL });

            turingCode += "1";//needing 3 one to seperate the machine code from the values;
            //turingCode += multiplication;    // values
            return turingCode;
        }

        //δ : Q × Γ^k → Q × Γ^k × D^k
        private static string encodeTransitionFunction(int currentState, char[] tupelRead, int nextState, 
                                                       char[] tupelWrite, UTMHeadMovement[] tupelHeadMovement) {
            StringBuilder builder = new StringBuilder();
            builder.Append(VALUE, currentState);
            builder.Append(VALUE_SEPARATOR);
            builder.Append(VALUE, encodeTupel(tupelRead));
            builder.Append(VALUE_SEPARATOR);
            builder.Append(VALUE, nextState);
            builder.Append(VALUE_SEPARATOR);
            builder.Append(VALUE, encodeTupel(tupelWrite));
            builder.Append(VALUE_SEPARATOR);
            builder.Append(VALUE, encodeHeandmovementTuple(tupelHeadMovement));
            builder.Append(TRANSITION_SEPARATOR);

            return builder.ToString();
        }

        private static int encodeTupel(char[] tupel) {
            int value = 0;
            for (int i = 0; i < tupel.Length; i++) {
                switch (tupel[i]) {
                    case '0': tupel[i] = '0'; break;
                    case '1': tupel[i] = '1'; break;
                    case '_': tupel[i] = '2'; break;
                }
            }
            value = Int32.Parse(char.ToString(tupel[0])) * 9 + //3^2
                Int32.Parse(char.ToString(tupel[1])) * 3 + //3^1
                Int32.Parse(char.ToString(tupel[2])) + 1; //3^0, +1 because 0 = '0', 1 = '00', ...
            return value;
        }

        private static int encodeHeandmovementTuple(UTMHeadMovement[] tupleHeadmovement) {
            return encodeHeadmovement(tupleHeadmovement[0]) * 9 +   // 3^2
                encodeHeadmovement(tupleHeadmovement[1]) * 3 +      // 3^1
                encodeHeadmovement(tupleHeadmovement[2]) + 1;       // 3^0 +1 because 0 = '0', 1 = '00', ...
        }

        private static int encodeHeadmovement(UTMHeadMovement headMovement) {
            int value = 0;
            switch (headMovement) {
                case LEFT: value = 0; break;
                case RIGHT: value = 1; break;
                case NEUTRAL: value = 2; break;
            }
            return value;
        }
    }
}
