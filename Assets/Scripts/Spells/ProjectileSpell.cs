using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Projectile spell")]
public class ProjectileSpell : Spell
{
    [Header("Projectile properties")]
    public ProjectileSpellStats projectileStats;

    public GameObject projectilePrefab;

    public override void Cast(Transform casterTransform)
    {
        GameObject projectile = Instantiate(projectilePrefab, casterTransform.position, casterTransform.rotation);

        projectile.GetComponent<Projectile>().SetProjectile(projectileStats);

        if (projectile.TryGetComponent(out Collider2D collider))
        {
            collider.excludeLayers = LayerMask.GetMask(LayerMask.LayerToName(casterTransform.gameObject.layer));
        }
    }
}
