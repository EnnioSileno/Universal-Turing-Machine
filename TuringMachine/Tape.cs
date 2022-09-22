using static Universal_Turing_Machine.UTMHeadMovement;
using static Universal_Turing_Machine.UTMRuntimeMode;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class Tape {
        private static readonly int TAPE_OVERLOAD = 15;

        private readonly List<char> tape = new List<char>();
        private int headPosition = 0;
        private int tapeNumber;

        public int HeadPosition { get { return headPosition; } }
        public Tape(int tapeNumber) {
            this.tapeNumber = tapeNumber;
        }

        public void AddElement(char element) {
            tape.Add(element);
        }

        public char GetElementOfHeadPosition() {
            return tape[HeadPosition]; 
        }
        public char GetElement(int index) {
            return tape[index];
        }

        public void ReplaceElementAtHeadPosiiton(char element) {
            tape[HeadPosition] = element;
        }

        public void MoveHeadPosition(UTMHeadMovement headMovement) {
            switch (headMovement) {
                case LEFT: headPosition--; break;
                case RIGHT: headPosition++; break;
                case NEUTRAL: break;
            }
        }

        public void Reset() {
            headPosition = 0;
            tape.Clear();        
        }

        public void PrintStatus(UTMRuntimeMode mode) {
            while (headPosition - TAPE_OVERLOAD < 0) {
                tape[0] = '_';
            }
            /*while (headPosition + TAPE_OVERLOAD > tape.Count - 1) {
                tape.Add('_');
            }*/
            if (mode == STEP) {
                Console.WriteLine("...");
                Console.WriteLine($"Index Read/write-head: {headPosition}                               ^");
            }
        }
    }
}
