using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class VariableReferenceComparator : MonoBehaviour
    {
        public VariableReference baseValue;
        public float valueToCompareWith;

        public UnityEvent OnMatch;
        public UnityEvent OnDifference;

        public void Compare()
        {
            StartCoroutine(DelayedCompare());
        }

        public IEnumerator DelayedCompare()
        {
            yield return new WaitForEndOfFrame();

            if (baseValue == null)
                yield break;

            if (valueToCompareWith == baseValue.Value)
                OnMatch?.Invoke();
            else
                OnDifference?.Invoke();
        }
    }
}

