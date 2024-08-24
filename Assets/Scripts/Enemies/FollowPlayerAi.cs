using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Enemy))]
public class FollowPlayerAi : MonoBehaviour
{
    public float speed;

    public Rigidbody2D rb;
    private Enemy enemy;

    [Min(0), SerializeField]
    private float detectionStutterTime = 0f;
    private float currentDetectionStutterTime;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {

        if (currentDetectionStutterTime > 0f)
        {
            currentDetectionStutterTime -= Time.fixedDeltaTime;
        }
        else
        {
            Move();
        }
    }

    public void Move()
    {
        if (enemy.PlayerTransform != null)
        {
            rb.velocity = (enemy.PlayerTransform.position - transform.position).normalized * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
