using System.Collections.Generic;
using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class ListEx {

        public static T RandomElement<T>(this List<T> list) {
            return list[Random.Range(0, list.Count)];
        }
        
        /// <summary>Returns the last element of the list.</summary>
        public static T GetLast<T>(this List<T> list) {
            return list[list.Count - 1];
        }
    }
}