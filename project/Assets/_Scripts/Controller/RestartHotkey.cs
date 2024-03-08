using Game.Controller;
using UnityEngine;

/// <summary>
/// We can restart the game, yay. 
/// </summary>
public class RestartHotkey : MonoBehaviour
{
    private static RestartHotkey instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }    
    }

    private void Start()
    {
        if (SceneManagement.InMenu)
            enabled = false;
        else
            enabled = true;
    }

    private void Update()
    {
        if (!enabled) return; //I don't trust unity

        if (Input.GetKeyDown(KeyCode.R))
            SceneManagement.RestartCurrentScene();
    }
}
