using Game;
using Game.Controller;
using Game.Systems;
using UnityEngine;

/// <summary>
/// We can restart the game, yay. 
/// </summary>
[RequireComponent(typeof(CustomEventRaiser))]
public class RealitySwitchHotkey : MonoBehaviour, ILinkable
{
    InventoryHolder inventory;
    public ItemType beer;
    private static RealitySwitchHotkey instance;
    bool canSwitch = true;

    public void ChangeSwitch(bool val)
    {
        canSwitch = val;
    }

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

        if (Input.GetKeyDown(KeyCode.F) && canSwitch)
            Switch();
    }

    public void Switch()
    {
        GetComponent<CustomEventRaiser>().InvokeEvent();
        inventory.RemoveFromInventory(beer);
    }

    public void SaveLinkReference(GameObject masterObject)
    {
        inventory = masterObject.GetComponent<InventoryHolder>();
    }
}
