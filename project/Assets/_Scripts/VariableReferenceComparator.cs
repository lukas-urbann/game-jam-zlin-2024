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
            if (baseValue == null)
                return;

            if (valueToCompareWith == baseValue.Value)
                OnMatch?.Invoke();
            else
                OnDifference?.Invoke();
        }
    }
}

