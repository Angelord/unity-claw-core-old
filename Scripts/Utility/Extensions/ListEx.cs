using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Claw.Utility.Extensions {
    public static class ListEx {
        public static bool IsValidIndex<T>(this List<T> list, int index) {
            return index >= 0 && index < list.Count;
        }

        public static T RandomElement<T>(this List<T> list) {
            return list[Random.Range(0, list.Count)];
        }

        /// <summary>Returns the last element of the list.</summary>
        public static T GetLast<T>(this List<T> list) {
            return list[list.Count - 1];
        }

        /// <summary> Removes and returns the last elements of the list. </summary>
        public static T Pop<T>(this List<T> list) {
            T result = list[list.Count - 1];

            list.RemoveAt(list.Count - 1);

            return result;
        }

        /// <summary>
        /// Inserts the item in a sorted sequence, returning the index at which it was inserted;
        /// </summary>
        public static int AddSorted<T>(this List<T> list, T item, IComparer<T> comparer) {
            if (list.Count == 0) {
                list.Add(item);
                return 0;
            }

            if (comparer.Compare(list[list.Count - 1], item) <= 0) {
                list.Add(item);
                return list.Count - 1;
            }

            if (comparer.Compare(list[0], item) >= 0) {
                list.Insert(0, item);
                return 0;
            }

            int index = list.BinarySearch(item, comparer);
            if (index < 0)
                index = ~index;
            list.Insert(index, item);

            return index;
        }
    }
}