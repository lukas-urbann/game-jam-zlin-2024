using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controller
{
    /// <summary>
    /// Can move the player through game scenes.
    /// </summary>
    public class SceneManagement : MonoBehaviour
    {
        public static SceneManagement Instance {  get; private set; }

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        public static void MoveToScene(string newRoomName)
        {
            SceneManager.LoadScene(newRoomName, LoadSceneMode.Single);
        }
    }
}
