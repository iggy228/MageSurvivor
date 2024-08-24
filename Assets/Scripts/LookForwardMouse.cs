using UnityEngine;

public class LookForwardMouse : MonoBehaviour
{
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (mousePos - (Vector2)transform.position).normalized;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.right);
        Gizmos.DrawCube(transform.right, Vector2.one * 0.1f);
    }
}
