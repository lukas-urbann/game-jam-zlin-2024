using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    public class InteractDetector : MonoBehaviour
    {
        public List<IInteractable> InteractablesInSight = new();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactable.InteractHighlight();
                if (!interactable.TouchInteraction) InteractablesInSight.Add(interactable);
            }
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out IInteractable interactable))
            {
                if (!interactable.TouchInteraction) interactable.InteractHighlight();
                if (!interactable.TouchInteraction) InteractablesInSight.Remove(interactable);
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (InteractablesInSight.Count <= 0) return;
                InteractablesInSight.ForEach(interactable =>
                {
                    interactable.Interact();
                });
            }
        }
    }
}
