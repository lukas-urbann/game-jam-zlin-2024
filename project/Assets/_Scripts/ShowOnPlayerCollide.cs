using Game;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Destroyer))]
public class ShowOnPlayerCollide : MonoBehaviour
{
    public UnityEvent toDo;

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            toDo?.Invoke();
            GetComponent<Destroyer>().DestroySelf();
        }
    }
}
