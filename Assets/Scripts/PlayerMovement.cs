using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 0.5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = dir * speed;
    }
}
