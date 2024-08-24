using UnityEngine;

[CreateAssetMenu(menuName = "Spells/Explosion")]
public class ExplosionSpell : Spell
{
    [Header("Explosion properties")]
    public Damage damage;

    public bool casterFriendly = false;
    public GameObject explosionPrefab;

    [Min(0f)]
    public float radiusScale = 1f;

    public override void Cast(Transform casterTransform)
    {
        GameObject explosion = Instantiate(explosionPrefab, casterTransform.position, casterTransform.rotation);

        explosion.GetComponent<Explosion>().SetExplosion(damage, radiusScale);
    }
}
