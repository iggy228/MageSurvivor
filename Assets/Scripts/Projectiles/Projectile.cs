using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField]
    private Damage damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float accelarationRate;
    [SerializeField]
    private float lifetime;

    private bool piercing;

    private Rigidbody2D rb;

    public void SetProjectile(Damage damage, float speed, float accelarationRate, float lifetime, bool piercing)
    {
        this.damage = damage;
        this.speed = speed;
        this.accelarationRate = accelarationRate;
        this.lifetime = lifetime;
        this.piercing = piercing;
    }

    private void Start()
    {
        // useless comment that for some reason i need so this script work (dont ask me why i dont know it either)
        rb = GetComponent<Rigidbody2D>();

        Destroy(gameObject, lifetime);
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
        if (accelarationRate != 1f)
        {
            // multiple speed with accelaration per fixed update
            speed *= (accelarationRate - 1) * Time.fixedDeltaTime + 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Damagable>(out var healthSystem))
        {
            healthSystem.TakeDamage(damage);
            if (!piercing)
            {
                Destroy(gameObject);
            }
        }
    }
}
