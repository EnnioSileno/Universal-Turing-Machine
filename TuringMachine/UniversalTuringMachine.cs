using static Universal_Turing_Machine.UTMHeadMovement;

using System;
using System.Collections.Generic;
using System.Collections;

namespace Universal_Turing_Machine {
    class UniversalTuringMachine {
        private static readonly int INITIAL_STATE = 1;
        private static readonly int END_STATE = 2;

        private static readonly int NUMBER_OF_TAPES = 3;
        private static readonly int TAPE_ONE = 0;
        private static readonly int TAPE_TWO = 1;
        private static readonly int TAPE_THREE = 2;

        private readonly Dictionary<int, UTMHeadMovement> headMovementValues = new Dictionary<int, UTMHeadMovement>();
        private readonly List<TransitionFunction> transitionFunctions = new List<TransitionFunction>();
        private readonly Dictionary<int, char> turingAlphabetValues = new Dictionary<int, char>();
        private readonly Dictionary<int, Tape> tapes = new Dictionary<int, Tape>();

        private int currentState = INITIAL_STATE;
        private int stepsDone = 0;

        public UniversalTuringMachine(Dictionary<int, char> turingAlphabetValues) {
            this.turingAlphabetValues = turingAlphabetValues;
            initalizeHeadMovementValues();
            initalizeTapes();
        }

        private void initalizeTapes() {
            headMovementValues[0] = LEFT;
            headMovementValues[1] = RIGHT;
            headMovementValues[2] = NEUTRAL;
        }

        private void initalizeHeadMovementValues() {
            tapes[TAPE_ONE] = new Tape(TAPE_ONE);
            tapes[TAPE_TWO] = new Tape(TAPE_TWO);
            tapes[TAPE_THREE] = new Tape(TAPE_THREE);
        }

        public void start(UTMConfiguration configuration) {
            UTMRuntimeMode mode = configuration.UTMRuntimeMode;
            int IndexOfTMCodeEnd = configuration.MachineConfiguration.IndexOf("111");
            string machineConfiguration = configuration.MachineConfiguration.Substring(0, IndexOfTMCodeEnd);
            Console.WriteLine("Decode transition functions");
            generateTransitionFuncitons(machineConfiguration);
            Console.WriteLine("Created transition functions ");

            runConfiguration(configuration.MachineConfiguration.Substring(IndexOfTMCodeEnd + 3), mode);
        }

        private void generateTransitionFuncitons(string machineConfiguration) {
            string[] encodedTransitionFuncitons = machineConfiguration.Split("11");
            Array.ForEach<string>(encodedTransitionFuncitons, encodedFunction =>
                                    transitionFunctions.Add(new TransitionFunction(turingAlphabetValues,
                                    headMovementValues, NUMBER_OF_TAPES, encodedFunction)));
        }

        private void runConfiguration(string v, UTMRuntimeMode mode) {
            throw new NotImplementedException();
        }
    }
}
