using Game.Controller;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactors
{
    public class Interact_Finish : MonoBehaviour, IInteractable
    {
        [SerializeField] GameObject highlightObject;
        [SerializeField] string NewSceneName;

        [SerializeField] bool interactableSober = false;
        [SerializeField] bool interactableDrunk = false;
        public bool InteractableSober { get { return interactableSober; } set { interactableSober = value; } }
        public bool InteractableDrunk { get { return interactableDrunk; } set { interactableDrunk = value; } }
        public List<ItemType> RequiredItemsToInteract { get => null; }
        public ValueIdentifier CustomIdentifier { get { return realityIdentifier; } }
        public ValueIdentifier realityIdentifier;
        public bool touchInteraction = false;
        public bool TouchInteraction { get { return touchInteraction; } }

        public void Interact()
        {
            if (!interactableDrunk && !interactableSober) return;
            else if (!interactableSober && CustomIdentifier.Value == -1) return;
            else if (!interactableDrunk && CustomIdentifier.Value == 1) return;

            SceneManagement.MoveToScene(NewSceneName);
        }

        public void InteractHighlight() => highlightObject.SetActive(!highlightObject.activeSelf);
    }
}
