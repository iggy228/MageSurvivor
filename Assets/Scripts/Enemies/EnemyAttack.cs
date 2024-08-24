using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage = 1;
    public float attackDelay = 0.3f;

    private Damagable player;
    private float currentAttackDelay = 0f;

    private void FixedUpdate()
    {
        if (currentAttackDelay <= 0)
        {
            Attack();
        }
        else
        {
            currentAttackDelay -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (player != null)
        {
            player.TakeDamage(damage);
            currentAttackDelay = attackDelay;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            player = collision.GetComponent<Damagable>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            player = null;
        }
    }
}
