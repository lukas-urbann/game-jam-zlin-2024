using UnityEngine;

namespace Game.ButtonActions
{
    public class Exit : MonoBehaviour, IButton
    {
        [SerializeField] bool exitToDesktop = false;

        public void Activate()
        {
            if (exitToDesktop)
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif
                Application.Quit(0);
            }

            Controller.SceneManagement.MoveToScene("Menu");
        }
    }
}
