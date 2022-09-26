using static Universal_Turing_Machine.UTMHeadMovement;
using static Universal_Turing_Machine.UTMRuntimeMode;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    class Tape : ICloneable {
        private static readonly int TAPE_LENGTH = 31;

        private List<char> tape = new List<char>();
        private int headPosition;

        public int HeadPosition { get { return headPosition; } }
        public Tape() {
            Reset();
        }

        public void Reset() {
            tape.Clear();
            tape.AddRange('_', TAPE_LENGTH);
            headPosition = TAPE_LENGTH / 2;
        }

        public void LoadWord(List<char> word) {
            tape.ReplaceAt(headPosition, word);
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

        public override string ToString() {
            List<char> tempList = new List<char>();
            tempList.AddRange(' ', headPosition - 1);
            tempList.Add('v');
            tempList.AddRange(' ', TAPE_LENGTH - headPosition);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"      { String.Join(" ", tempList)}");
            builder.AppendLine($"...,{ String.Join(",", tape)},...");
            return builder.ToString();
        }

        public object Clone() {
            Tape tape = new Tape();
            tape.headPosition = this.headPosition;
            tape.tape = new List<char>(this.tape);
            return tape;
        }
    }
}
