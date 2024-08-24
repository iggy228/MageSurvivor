using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Explosion : MonoBehaviour
{
    [SerializeField]
    private Damage damage;

    private Collider2D triggerCollider;

    public void SetExplosion(Damage damage, float scale)
    {
        this.damage = damage;
        transform.localScale = new Vector3(scale, scale, 1f);
        triggerCollider.enabled = true;
        Destroy(gameObject, 0.1f);
    }

    private void Awake()
    {
        triggerCollider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Damagable component))
        {
            component.TakeDamage(damage);

        }
    }
}
