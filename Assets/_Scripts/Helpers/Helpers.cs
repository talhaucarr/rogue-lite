using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class Helpers
    {
        private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
        
        public static WaitForSeconds GetWaitForSeconds(float seconds)
        {
            if (WaitDictionary.TryGetValue(seconds, out var wait)) return wait;

            WaitDictionary[seconds] = new WaitForSeconds(seconds);
            return WaitDictionary[seconds];
        }
    }
}