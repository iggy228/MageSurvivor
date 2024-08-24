using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Projectile spell")]
public class ProjectileSpell : Spell
{
    [Header("Projectile properties")]
    public Damage damage;
    public float lifetime;

    /// <summary>
    /// is projectile destroy automatically after hitting enemy
    /// </summary>
    public bool piercing = false;

    // base lifetime of spell
    [Header("Speed properties")]
    public float speed;
    /// <summary>
    /// tell projectile if they should accelarate overtime or decelerate
    /// if value is less than 1 projectile will slown down overtime
    /// if value is 1 it will fly in constant speed
    /// if value is more than 1 projectile will fly faster overtime 
    /// </summary>
    [Min(0f)]
    public float accelarationRate = 1f;

    public GameObject projectilePrefab;

    public override void Cast(Transform casterTransform)
    {
        GameObject projectile = Instantiate(projectilePrefab, casterTransform.position, casterTransform.rotation);

        projectile.GetComponent<Projectile>().SetProjectile(damage, speed, accelarationRate, lifetime, piercing);

        if (casterTransform.TryGetComponent(out Collider2D collider) && projectile.TryGetComponent(out Collider2D collider2))
        {
            Physics2D.IgnoreCollision(collider, collider2);
        }
    }
}
