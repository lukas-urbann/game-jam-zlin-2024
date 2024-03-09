using UnityEngine;

namespace Game
{
    public class Destroyer : MonoBehaviour
    {
        public void DestroyThis(GameObject go)
        {
            Destroy(go);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
