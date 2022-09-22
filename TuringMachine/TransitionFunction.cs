using static Universal_Turing_Machine.UTMHeadMovement;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class TransitionFunction {
        private static readonly string TUPEL_SEPERATOR = "1";
        private static readonly int CURRENT_STATE = 0;
        private static readonly int HEAD_MOVEMENT = 4;
        private static readonly int NEXT_STATE = 2;
        private static readonly int WRITE = 3;
        private static readonly int READ = 1;

        private readonly Dictionary<int, char> turingAlphabetValues;
        private readonly Dictionary<int, UTMHeadMovement> headMovementValues;
        private readonly int numberOfTapes;

        private int currentState;
        private int nextState;

        private UTMHeadMovement[] tupelHeadMovement;
        private char[] tupelWrite;
        private char[] tupelRead;


        public int CurrentState { get { return currentState; } }
        public int NextState { get { return nextState; } }

        public TransitionFunction(Dictionary<int, char> turingAlphabetValues,
                                Dictionary<int, UTMHeadMovement> headMovementValues,
                                int numberOfTapes,
                                string encodedFunction)
        {
            this.turingAlphabetValues = turingAlphabetValues;
            this.headMovementValues = headMovementValues;
            this.numberOfTapes = numberOfTapes;

            initializeArrays();
            decodeTransitionFunction(encodedFunction);
        }

        public char ReadSymbol(int tapeIndex) {
            return tupelRead[tapeIndex];
        }

        public char WriteSymbol(int tapeIndex) {
            return tupelWrite[tapeIndex];
        }

        public UTMHeadMovement HeadMovement(int tapeIndex) {
            return tupelHeadMovement[tapeIndex];
        }

        private void initializeArrays() {
            tupelHeadMovement = new UTMHeadMovement[numberOfTapes];
            tupelWrite = new char[numberOfTapes];
            tupelRead = new char[numberOfTapes];
        }

        private void decodeTransitionFunction(string encodedFunction) {
            string[] encodedTupels = encodedFunction.Split(TUPEL_SEPERATOR);
            if (encodedTupels.Length != 5) throw new ArgumentException("Invalid encoded Function");
            //decode current State
            currentState = encodedTupels[CURRENT_STATE].Length;
            //decode read value
            parseToTupel(tupelRead, turingAlphabetValues, encodedTupels[READ]);
            //decode next state
            nextState = encodedTupels[NEXT_STATE].Length;
            //decode write value
            parseToTupel(tupelWrite, turingAlphabetValues, encodedTupels[WRITE]);
            //decode head movement
            parseToTupel(tupelHeadMovement, headMovementValues, encodedTupels[HEAD_MOVEMENT]);
        }

        private void parseToTupel<T>(T[] tupelToSet, Dictionary<int, T> valuesOfTupel, string pattern) {
            int keyNumber = pattern.Length - 1;

            for (int tapeIndex = 0; tapeIndex < numberOfTapes; tapeIndex++) {
                for (int symbol = valuesOfTupel.Count - 1; symbol >= 0; symbol--) {
                    int interimValue = (int)(symbol * Math.Pow(valuesOfTupel.Count, (numberOfTapes - 1) - tapeIndex));

                    if (interimValue <= keyNumber) {
                        tupelToSet[tapeIndex] = valuesOfTupel[symbol];
                        keyNumber -= interimValue;
                        break;
                    }
                }
            }
        }
    }
}
