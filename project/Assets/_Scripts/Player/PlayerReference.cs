using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PlayerReference : MonoBehaviour
    {
        public static PlayerReference Instance;
        public GameObject Player;
        public GameObject PlayerNormal;
        public GameObject PlayerDrunk;

        private void Awake()
        {
            Instance = this;
        }

        private void OnEnable()
        {
            Instance = this;
        }
    }
}
