﻿using UnityEngine;

namespace Claw.Utility.Extensions {
    public static class ArrayEx {
        
        public static T RandomElement<T>(this T[] list) {
            return list[Random.Range(0, list.Length)];
        }
    }
}