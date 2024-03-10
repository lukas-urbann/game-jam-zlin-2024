using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Interactors
{
    public class Interact_Teleport : MonoBehaviour, IInteractable, ILinkable
    {
        [SerializeField] GameObject highlightObject;
        public Transform PositionToTeleport;
        public GameObject LinkedObject;

        [SerializeField] bool interactableSober = false;
        [SerializeField] bool interactableDrunk = false;
        public bool InteractableSober { get { return interactableSober; } set { interactableSober = value; } }
        public bool InteractableDrunk { get { return interactableDrunk; } set { interactableDrunk = value; } }
        public List<ItemType> RequiredItemsToInteract { get => null; }
        public ValueIdentifier CustomIdentifier { get { return customIdentifier; } }
        public ValueIdentifier customIdentifier;
        public bool touchInteraction = false;
        public bool TouchInteraction { get { return touchInteraction; } }

        public bool canInteract = true;
        public bool disableOnStartAfterLink = false;

        public void Start()
        {
            if (disableOnStartAfterLink)
                StartCoroutine(DisableSelf());
        }

        private IEnumerator DisableSelf()
        {
            yield return new WaitForEndOfFrame();
            if (disableOnStartAfterLink )
            {
                gameObject.SetActive( false );
            }
        }

        public void Enable()
        {
            canInteract = true;
        }
        public void Disable()
        {
            canInteract = false;
        }

        public void Interact()
        {
            if (!interactableDrunk && !interactableSober) return;
            else if (!interactableSober && CustomIdentifier.Value == 1) return;
            else if (!interactableDrunk && CustomIdentifier.Value == -1) return;

            if (!canInteract) return;

            if (!LinkedObject) return;
            LinkedObject.transform.position = PositionToTeleport.transform.position;
        }
        public void SaveLinkReference(GameObject masterObject) => LinkedObject = masterObject;
        public void InteractHighlight()
        {
            if (!canInteract) return;
            highlightObject.SetActive(!highlightObject.activeSelf);
        }

        public void ReplaceLinkWithDrunkCharacter()
        {
            LinkedObject = PlayerReference.Instance.PlayerDrunk;
        }

        public void ReplaceLinkWithNormalCharacter()
        {
            LinkedObject = PlayerReference.Instance.PlayerNormal;
        }
    }
}
