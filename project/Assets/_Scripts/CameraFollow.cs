using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public ObjectReference targetReference;
        public float smoothTime = 0.3F;
        public Vector3 cameraOffset = new Vector3(0, 3, -5);
        private Vector3 velocity = Vector3.zero;

        void Update()
        {
            Vector3 targetPosition = target.TransformPoint(cameraOffset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
