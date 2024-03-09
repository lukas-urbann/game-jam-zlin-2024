using UnityEngine;

namespace Game.Interactors
{
    public class Interact_Teleport : MonoBehaviour, IInteractable, ILinkable
    {
        [SerializeField] GameObject highlightObject;
        public Transform PositionToTeleport;
        private GameObject LinkedObject;

        public void Interact()
        {
            if (!LinkedObject) return;
            LinkedObject.transform.position = PositionToTeleport.transform.position;
        }
        public void SaveLinkReference(GameObject masterObject) => LinkedObject = masterObject;
        public void InteractHighlight() => highlightObject.SetActive(!highlightObject.activeSelf);
    }
}
