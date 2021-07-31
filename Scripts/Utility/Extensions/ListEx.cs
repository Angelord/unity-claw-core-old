using System.Collections.Generic;
using UnityEngine;

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
    }
}