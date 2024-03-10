using System.Collections;
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
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);
        }
    }
}
