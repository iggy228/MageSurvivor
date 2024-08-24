using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OrcAttack : MonoBehaviour
{
    private Collider2D attackCollider;
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float attackDelay = 2f;
    private float currentAttackDelay = 0f;

    [SerializeField]
    private float startAttackDelay = 1f;

    public LayerMask attackLayerMask;

    [SerializeField]
    private Damage damage;

    private bool canAttack = false;

    public UnityEvent OnAttackStart;
    public UnityEvent OnAttackEnd;

    void Awake()
    {
        attackCollider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        if (canAttack && currentAttackDelay <= 0f)
        {
            StartCoroutine(Attack());
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
            canAttack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Tags.Player))
        {
            canAttack = false;
        }
    }

    private IEnumerator Attack()
    {
        currentAttackDelay = attackDelay;

        animator.SetBool("attack", true);
        OnAttackStart.Invoke();
        yield return new WaitForSeconds(startAttackDelay);

        Collider2D[] colliders = Physics2D.OverlapAreaAll(attackCollider.bounds.min, attackCollider.bounds.max, attackLayerMask);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].TryGetComponent(out Damagable damagable))
            {
                damagable.TakeDamage(damage);
            }
        }

        animator.SetBool("attack", false);
        OnAttackEnd.Invoke();
    }
}
