using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PositionReseter : MonoBehaviour
    {
        public Vector3 StartPosition;
        
        private void Awake()
        {
            StartPosition = transform.position;
        }

        private void OnEnable()
        {
            if (StartPosition != null)
            {
                ResetPosition();
            }
        }

        public void ResetPosition()
        {
            gameObject.transform.position = StartPosition;
        }
    }
}
