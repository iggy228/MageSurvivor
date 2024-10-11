using UnityEngine;

public class LookForwardMouse : MonoBehaviour
{
    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.right = (mousePos - (Vector2)transform.position).normalized;
    }
}
