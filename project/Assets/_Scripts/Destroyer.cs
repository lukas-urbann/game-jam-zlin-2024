using System.Collections;
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
            StartCoroutine(DestroySelfRoutine());
        }

        private IEnumerator DestroySelfRoutine()
        {
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }
    }
}
