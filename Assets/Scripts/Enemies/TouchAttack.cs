using UnityEngine;

public class TouchAttack : MonoBehaviour
{
    [SerializeField]
    private Damage damage;

    // delay after attacking 
    [SerializeField, Min(0)]
    private float attackDelay = 0.5f;
    private float currentAttackDelay = 0f;

    private Damagable damagableObject;

    private void FixedUpdate()
    {
        if (currentAttackDelay <= 0f)
        {
            Attack();
        }
        if (currentAttackDelay > 0f)
        {
            currentAttackDelay -= Time.fixedDeltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            collision.TryGetComponent(out damagableObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            damagableObject = null;
        }
    }

    public void Attack()
    {
        if (damagableObject != null)
        {
            damagableObject.TakeDamage(damage);
            currentAttackDelay = attackDelay;
        }
    }
}
