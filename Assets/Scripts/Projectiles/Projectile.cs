using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private ProjectileSpellStats stats;

    private Rigidbody2D rb;
    private float speed;

    public void SetProjectile(ProjectileSpellStats stats)
    {
        this.stats = stats;
        speed = stats.speed;
    }

    private void Start()
    {
        // useless comment that for some reason i need so this script work (dont ask me why i dont know it either)
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, stats.lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
        if (stats.accelarationRate != 1f)
        {
            // multiple speed with accelaration per fixed update
            speed *= (stats.accelarationRate - 1) * Time.fixedDeltaTime + 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.TryGetComponent<Damagable>(out var healthSystem))
        {
            healthSystem.TakeDamage(stats.damage);
            if (!stats.piercing)
            {
                Destroy(gameObject);
            }
            return;
        }
    }
}
