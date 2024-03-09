using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class RealityManager : MonoBehaviour
    {
        [Header("set -1 for drunk and 1 for normal!")]
        public VariableReference realityValueReference;
        public CustomEvent RealitySwitchEvent;

        private void Start()
        {
            realityValueReference.Value = 0;
            RealitySwitchEvent.Raise();
        }

        /// <summary>
        /// Not a good idea, be we have no other choice for now.
        /// </summary>
        public void Switch()
        {
            Debug.Log("Reality switch invoked.");
            realityValueReference.Value = realityValueReference.Value == 1 ? -1 : 1;
        }
    }
}

