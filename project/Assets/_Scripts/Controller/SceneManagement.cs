using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controller
{
    /// <summary>
    /// Can move the player through game scenes. Provides game restarts.
    /// </summary>
    public class SceneManagement : MonoBehaviour
    {
        public static SceneManagement Instance { get; private set; }
        public static string CurrentScene => SceneManager.GetActiveScene().name;

        private void Awake()
        {
            if (!Instance)
                Instance = this;
            else
                Destroy(this);
        }

        //DON'T RENAME THE MENU SCENE FOR THE LOVE OF GOD
        public static bool InMenu => CurrentScene == "Menu";
        public static void MoveToScene(string newRoomName) => SceneManager.LoadScene(newRoomName, LoadSceneMode.Single);
        public static void RestartCurrentScene() => SceneManager.LoadScene(CurrentScene);
    }
}
