using UnityEngine;

/// <summary>
/// Spell that makes orbit around player with rotating certain projectile prefab
/// </summary>
[CreateAssetMenu(menuName = "Spells/Projectile Orbit")]
public class ProjectileOrbitSpell : Spell
{
    [Header("Orbit spell properties")]
    public GameObject orbit;
    public float speed;
    public float lifetime;
    public float radius;

    [Header("Orbit spell projectile properties")]
    public Damage damage;
    public int projectileAmount;
    public GameObject projectilePrefab;

    public override void Cast(Transform casterTransform)
    {
        ProjectileOrbit newOrbit = Instantiate(orbit, casterTransform.position, casterTransform.rotation, casterTransform.transform).GetComponent<ProjectileOrbit>();

        newOrbit.SetProjectileOrbit(speed, lifetime, projectileAmount, projectilePrefab, radius);
        newOrbit.SetProjectiles(casterTransform, damage);
    }
}
