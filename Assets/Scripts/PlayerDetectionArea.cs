using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlayerDetectionArea : MonoBehaviour
{
    public UnityEvent<Transform> OnPlayerEntered;
    public UnityEvent<Transform> OnPlayerLeaved;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            OnPlayerEntered.Invoke(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            OnPlayerLeaved.Invoke(collision.transform);
        }
    }
}
