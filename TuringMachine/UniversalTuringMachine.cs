using static Universal_Turing_Machine.UTMHeadMovement;
using static Universal_Turing_Machine.UTMRuntimeMode;

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

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

        public UniversalTuringMachine() {
            initalizeTuringAlphabet();
            initalizeHeadMovementValues();
            initalizeTapes();
        }

        private void initalizeTuringAlphabet() {
            turingAlphabetValues[0] = '0';
            turingAlphabetValues[1] = '1';
            turingAlphabetValues[2] = '_';
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
            resetConfiguration();
        }

        private void generateTransitionFuncitons(string machineConfiguration) {
            string[] encodedTransitionFuncitons = machineConfiguration.Split("11");
            Array.ForEach<string>(encodedTransitionFuncitons, encodedFunction =>
                                    transitionFunctions.Add(new TransitionFunction(turingAlphabetValues,
                                    headMovementValues, NUMBER_OF_TAPES, encodedFunction)));
        }

        private void runConfiguration(string word, UTMRuntimeMode mode) {
            //Fill tape
            initalizeWord(word);
            //start tm
            //q1 is starting state, q2 endstate
            bool running = true;
            while (running) {
                    printOutStatus(mode);
                if (currentState == END_STATE) {
                    Console.WriteLine("end running");
                    running = false;
                } else {
                    executeTransitionFunction();
                }
            }
            int result = 0;
            for (int i = tapes[TAPE_THREE].HeadPosition; i >= 0; i--) {
                if (tapes[TAPE_THREE].GetElement(i) == '0') result++;
            }
            if (mode == STEP) {
                Console.WriteLine("*****");
            }
            Console.WriteLine($"The result is: {result}");
            printOutStatus(STEP);
        }

        private void initalizeWord(string word) {
            //check word if valid numbers
            Console.WriteLine($"initalizeWord {word}");
            string pattern = "^(0|[1-9][0-9]*)\\*(0|[1-9][0-9]*)$";
            Match match = Regex.Match(word, pattern);
            if (!match.Success) throw new ArgumentException($"Not a valid word: {word}");
            int firstValue = Int32.Parse(match.Groups[1].Value);
            int secondValue = Int32.Parse(match.Groups[2].Value);
            for (int i = 0; i < firstValue; i++) {
                tapes[TAPE_ONE].AddElement('0');
            }
            tapes[TAPE_ONE].AddElement('1');
            for (int i = 0; i < secondValue; i++) {
                tapes[TAPE_ONE].AddElement('0');
            }
        }

        private void executeTransitionFunction() {
            TransitionFunction funcToExecute = nextTransitionFunciton();
            writeNewSymbols(funcToExecute);
            moveTapeHeadPositions(funcToExecute);
            currentState = funcToExecute.NextState;
            stepsDone++;
        }

        private TransitionFunction nextTransitionFunciton() {
            //select possible transition funcitons
            List<TransitionFunction> possibleTransitions = new List<TransitionFunction>();
            foreach(TransitionFunction transition in transitionFunctions) {
                if (currentState == transition.CurrentState) possibleTransitions.Add(transition);
            }
            //find correct transition function
            TransitionFunction transitionToExecute = null;
            foreach (TransitionFunction transition in possibleTransitions) {
                if (isCorrectTransition(transition)) {
                    transitionToExecute = transition;
                    break;
                }
            }
            if (transitionToExecute == null) throw new ArgumentException("No calculation Step found - Bad configuration");
            return transitionToExecute;
        }

        private bool isCorrectTransition(TransitionFunction transition) {
            return tapes[TAPE_ONE].GetElementOfHeadPosition() == transition.ReadSymbol(TAPE_ONE) &&
                tapes[TAPE_TWO].GetElementOfHeadPosition() == transition.ReadSymbol(TAPE_TWO) &&
                tapes[TAPE_THREE].GetElementOfHeadPosition() == transition.ReadSymbol(TAPE_THREE);
        }

        private void writeNewSymbols(TransitionFunction transition) {
            foreach (int key in tapes.Keys) {
                tapes[key].ReplaceElementAtHeadPosiiton(transition.WriteSymbol(key));
            }
        }

        private void moveTapeHeadPositions(TransitionFunction transition) {
            foreach (int key in tapes.Keys) {
                tapes[key].MoveHeadPosition(transition.HeadMovement(key));
            }
        }

        private void resetConfiguration() {
            transitionFunctions.Clear();
            foreach(Tape tape in tapes.Values) {
                tape.Reset();
            }
            currentState = INITIAL_STATE;
            stepsDone = 0;
        }

        private void printOutStatus(UTMRuntimeMode mode) {
            if (mode == STEP) {
                Console.WriteLine("*****");
                Console.WriteLine($"Steps done: {stepsDone}");
                Console.WriteLine($"Current state: {currentState}");
            }
            foreach (Tape tape in tapes.Values) {
                tape.PrintStatus(mode);
            }
        }

        
    }
}
