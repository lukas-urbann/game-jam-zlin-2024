using UnityEngine;

namespace Game
{
    public class LinkableCameraFollow : MonoBehaviour, ILinkable
    {
        private Transform LinkedTransform;
        public float smoothTime = 0.3F;
        public Vector3 cameraOffset = new(0, 3, -10);
        private Vector3 velocity = Vector3.zero;

        public void SaveLinkReference(GameObject masterObject)
        {
            LinkedTransform = masterObject.transform;
        }

        void Update()
        {
            if (!LinkedTransform) return;

            Vector3 targetPosition = LinkedTransform.transform.TransformPoint(cameraOffset);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
