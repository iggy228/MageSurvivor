using UnityEngine;

public class OrbitProjectile : MonoBehaviour
{
    [SerializeField]
    private Damage damage;
    [SerializeField]
    private bool piercing = true;

    public void SetStaticProjectile(Damage damage, bool piercing = true)
    {
        this.damage = damage;
        this.piercing = piercing;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damagable damagable))
        {
            damagable.TakeDamage(damage);

            if (!piercing)
            {
                Destroy(gameObject);
            }
        }
    }
}
