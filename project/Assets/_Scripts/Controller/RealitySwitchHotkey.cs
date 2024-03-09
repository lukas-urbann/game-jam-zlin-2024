using Game;
using Game.Controller;
using UnityEngine;

/// <summary>
/// We can restart the game, yay. 
/// </summary>
[RequireComponent(typeof(CustomEventRaiser))]
public class RealitySwitchHotkey : MonoBehaviour
{
    private static RealitySwitchHotkey instance;

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

        if (Input.GetKeyDown(KeyCode.F))
            GetComponent<CustomEventRaiser>().InvokeEvent();
    }
}
