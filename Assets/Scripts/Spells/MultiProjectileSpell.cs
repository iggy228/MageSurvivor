
using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Multi Projectile Spell")]
public class MultiProjectileSpell : ProjectileSpell
{
    [Header("Multi projectile spell properties")]
    // spread between projectiles
    [Min(1)]
    public int amount;
    public float spread;

    public override void Cast(Transform casterTransform)
    {
        float curSpread = 0f;
        if (amount % 2 == 0)
        {
            curSpread = spread / 2;
        }

        for (int i = 0; i < amount; i++)
        {
            Quaternion projectileRotation = Quaternion.Euler(0f, 0f, curSpread + casterTransform.rotation.eulerAngles.z);

            GameObject projectile = Instantiate(projectilePrefab, casterTransform.position, projectileRotation);

            projectile.GetComponent<Projectile>().SetProjectile(projectileStats);

            if (projectile.TryGetComponent(out Collider2D collider))
            {
                collider.excludeLayers = LayerMask.GetMask(LayerMask.LayerToName(casterTransform.gameObject.layer));
            }

            if (amount % 2 == 0)
            {
                if (i == amount / 2 - 1)
                {
                    curSpread = -curSpread;
                }
                else
                {
                    curSpread += spread;
                }
            }
            else
            {
                if (i == amount / 2)
                {
                    curSpread = -curSpread;
                }
                else
                {
                    curSpread += spread;
                }
            }
        }
    }
}
