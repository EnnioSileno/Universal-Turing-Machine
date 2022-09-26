using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universal_Turing_Machine {
    static class ListExtensions {
        static public void AddRange<T>(this List<T> list, T element, int count) {
            for(int i = 0; i < count; i++) {
                list.Add(element);
            }
        }

        static public void ReplaceAt<T>(this List<T> list, int startIndex, IEnumerable<T> insertions) {
            foreach (T insertion in insertions) {
                list[startIndex] = insertion;
                startIndex++;
            }
        }
    }
}
