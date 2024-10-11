using UnityEngine;

/// <summary>
/// Spell that contain projectile that will trigger another spell upon collision
/// </summary>
[CreateAssetMenu(menuName = "Spells/Projectile with trigger")]
public class ProjectileWithCollisionTriggerSpell : ProjectileSpell
{
    [Header("Trigger properties")]
    public Spell triggerSpell;

    public override void Cast(Transform casterTransform)
    {
        GameObject projectile = Instantiate(projectilePrefab, casterTransform.position, casterTransform.rotation);

        projectile.GetComponent<Projectile>().SetProjectile(projectileStats);

        if (projectile.TryGetComponent(out Collider2D collider))
        {
            collider.excludeLayers = LayerMask.GetMask(LayerMask.LayerToName(casterTransform.gameObject.layer));
        }

        if (projectile.TryGetComponent(out CollisionTriggerSpell component))
        {
            component.SetSpell(triggerSpell);
        }
    }
}
