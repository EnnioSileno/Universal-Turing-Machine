using static Universal_Turing_Machine.UTMHeadMovement;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;
using System.Linq;

namespace Universal_Turing_Machine {
    class UniversalTuringMachine {
        private static readonly int INITIAL_STATE = 1;
        private static readonly int END_STATE = 2;

        private static readonly int NUMBER_OF_TAPES = 3;
        private static readonly int TAPE_ONE = 0;
        private static readonly int TAPE_TWO = 1;
        private static readonly int TAPE_THREE = 2;

        private static UniversalTuringMachine universalTuringMachine;

        private readonly Dictionary<int, UTMHeadMovement> headMovementValues = new Dictionary<int, UTMHeadMovement>();
        private readonly List<TransitionFunction> transitionFunctions = new List<TransitionFunction>();
        private readonly Dictionary<int, char> turingAlphabetValues = new Dictionary<int, char>();
        private readonly Stack<utmStep> history = new Stack<utmStep>();
        private Dictionary<int, Tape> tapes = new Dictionary<int, Tape>();
        private int currentState = INITIAL_STATE;
        private int stepsDone = 0;

        private struct utmStep {
            public Dictionary<int, Tape> tapes;
            public int currentState;
        }

        public static UniversalTuringMachine Instance() {
            if (universalTuringMachine == null) {
                universalTuringMachine = new UniversalTuringMachine();
            }
            return universalTuringMachine;
        }

        private UniversalTuringMachine() {
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
            tapes[TAPE_ONE] = new Tape();
            tapes[TAPE_TWO] = new Tape();
            tapes[TAPE_THREE] = new Tape();
        }

        public void RunNewConfiguration(UTMConfiguration utmConfiguration) {
            resetConfiguration();
            loadConfiguration(utmConfiguration);
        }

        public EmulationState executeNextTransition() {
            if (currentState == END_STATE) {
                return EmulationState.FINNISHED;
            }
            executeTransitionFunction();
            return EmulationState.RUNNING;
        }

        public void GoBackOneTransition() {
            if(history.Count != 0) {
                stepsDone--;
                utmStep lastStep = history.Pop();
                tapes = lastStep.tapes;
                currentState = lastStep.currentState;
            }
        }

        public string PrintResult() {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"***************************************");
            builder.AppendLine($"Turing machine has finished");
            builder.AppendLine($"Result: {calculateResult()}");
            builder.AppendLine($"Steps done: {stepsDone}");
            builder.AppendLine($"***************************************");
            return builder.ToString();
        }

        private void loadConfiguration(UTMConfiguration configuration) {
            int IndexOfTMCodeEnd = configuration.MachineConfiguration.IndexOf("111");
            string machineConfiguration = configuration.MachineConfiguration.Substring(0, IndexOfTMCodeEnd);
            generateTransitionFuncitons(machineConfiguration);
            string encodedWord = configuration.MachineConfiguration.Substring(IndexOfTMCodeEnd + 3);
            initalizeWord(encodedWord);
        }

        private void generateTransitionFuncitons(string machineConfiguration) {
            string[] encodedTransitionFuncitons = machineConfiguration.Split("11");
            Array.ForEach<string>(encodedTransitionFuncitons, encodedFunction =>
                                    transitionFunctions.Add(new TransitionFunction(turingAlphabetValues,
                                    headMovementValues, NUMBER_OF_TAPES, encodedFunction)));
        }

        private int calculateResult() {
            int result = 0;
            for (int i = tapes[TAPE_THREE].HeadPosition; i >= 0; i--) {
                if (tapes[TAPE_THREE].GetElement(i) == '0') result++;
            }
            return result;
        }

        private void initalizeWord(string word) {
            //check word if valid numbers
            Console.WriteLine($"initalizeWord {word}");
            string pattern = "^(0|[1-9][0-9]*)\\*(0|[1-9][0-9]*)$";
            List<char> wordSequence = new List<char>();
            Match match = Regex.Match(word, pattern);
            if (!match.Success) throw new ArgumentException($"Not a valid word: {word}");
            int[] values = new int[match.Groups.Count - 1];
            for (int i = 1; i < match.Groups.Count; i++) {
                values[i - 1] = Int32.Parse(match.Groups[i].Value);
            }
            for(int i = 0; i < values.Length; i++) {
                wordSequence.AddRange('0', values[i]);
                if(i + 1 != values.Length) wordSequence.Add('1');
            }      
            tapes[TAPE_ONE].LoadWord(wordSequence);
        }

        private void executeTransitionFunction() {
            utmStep lastStep;
            lastStep.tapes = tapes.ToDictionary(
                                entry => entry.Key,
                                entry => (Tape)entry.Value.Clone());
            lastStep.currentState = currentState;
            history.Push(lastStep);
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
            history.Clear();
            foreach (Tape tape in tapes.Values) {
                tape.Reset();
            }
            currentState = INITIAL_STATE;
            stepsDone = 0;
        }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Tape states:");
            builder.AppendLine(tapes[TAPE_ONE].ToString());
            builder.AppendLine(tapes[TAPE_TWO].ToString());
            builder.AppendLine(tapes[TAPE_THREE].ToString());
            return builder.ToString();
        }

    }
}
