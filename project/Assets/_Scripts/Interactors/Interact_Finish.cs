using Game.Controller;
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

        public void Interact()
        {
            SceneManagement.MoveToScene(NewSceneName);
        }

        public void InteractHighlight() => highlightObject.SetActive(!highlightObject.activeSelf);
    }
}
