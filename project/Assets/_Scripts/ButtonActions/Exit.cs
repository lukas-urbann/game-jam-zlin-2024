using UnityEngine;

namespace Game.ButtonActions
{
    /// <summary>
    /// Generic exit button script. Can exit the game, wow.
    /// </summary>
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
