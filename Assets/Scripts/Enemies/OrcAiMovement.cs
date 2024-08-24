using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Enemy))]
public class OrcAiMovement : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    [SerializeField]
    private Animator animator;


    [SerializeField]
    private bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        canMove = true;
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 playerDir = enemy.PlayerTransform.position - transform.position;
            if (playerDir.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

            rb.velocity = playerDir.normalized * speed;
        }
    }

    public void DisableMovement()
    {
        canMove = false;
        rb.velocity = Vector2.zero;

        animator.SetBool("walking", false);
    }

    public void EnableMovement()
    {
        canMove = true;
        animator.SetBool("walking", true);
    }
}
