using UnityEngine;

public class AutobusMovement : MonoBehaviour
{
    public Transform targetPoint;
    public float speed = 5f;

    void Update()
    {
        {
            Debug.LogWarning("No target point assigned to the car!");
            return;
        }

        Vector3 direction = targetPoint.position - transform.position;
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            enabled = false;
        }
    }
}