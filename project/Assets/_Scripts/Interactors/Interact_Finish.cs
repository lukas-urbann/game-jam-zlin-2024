using Game.Controller;
using UnityEngine;

namespace Game.Interactors
{
    public class Interact_Finish : MonoBehaviour, IInteractable
    {
        [SerializeField] GameObject highlightObject;
        [SerializeField] string NewSceneName;

        public bool SoberInteraction = true;
        public bool DrunkInteraction = false;


        public void Interact()
        {
            SceneManagement.MoveToScene(NewSceneName);
        }

        public void InteractHighlight() => highlightObject.SetActive(!highlightObject.activeSelf);
    }
}
