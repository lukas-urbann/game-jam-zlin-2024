using Game.Controller;
using UnityEngine;

/// <summary>
/// We can restart the game, yay. 
/// </summary>
public class ExitHotkey : MonoBehaviour
{
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

        if (Input.GetKeyDown(KeyCode.Escape))
            GetComponent<Game.ButtonActions.Exit>().Activate();
    }
}
