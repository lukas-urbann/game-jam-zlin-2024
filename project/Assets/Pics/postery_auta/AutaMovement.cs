using UnityEngine;

public class AutaMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 5f;

    private bool movingToEnd = true;

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    System.Collections.IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (movingToEnd)
            {
                while (transform.position != endPoint.position)
                {

                    transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
                    yield return null;
                }
                movingToEnd = false;
            }
            else
            {

                yield return new WaitForSeconds(Random.Range(1f, 5f));

                transform.position = startPoint.position;
                movingToEnd = true;
            }
        }
    }
}