using UnityEngine;

public class ProjectileOrbit : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifetime;

    [SerializeField]
    private int amount;
    [SerializeField]
    private OrbitProjectile[] orbitProjectiles;

    public void SetProjectileOrbit(float speed, float lifetime, int amount, GameObject projectileSpell, float radius)
    {
        this.speed = speed;
        this.lifetime = lifetime;
        this.amount = amount;

        OrbitProjectile[] orbitProjectiles = new OrbitProjectile[amount];
        for (int i = 0; i < amount; i++)
        {
            orbitProjectiles[i] = Instantiate(projectileSpell, transform.position, Quaternion.identity, transform).GetComponent<OrbitProjectile>();

            orbitProjectiles[i].transform.Rotate(0, 0, 360 / amount * i);
            orbitProjectiles[i].transform.Translate(Vector2.right * radius);
        }

        this.orbitProjectiles = orbitProjectiles;

        Destroy(gameObject, lifetime);
    }

    public void SetProjectiles(Transform casterTransform, Damage damage)
    {
        for (int i = 0; i < amount; i++)
        {
            orbitProjectiles[i].SetStaticProjectile(damage);

            if (orbitProjectiles[i].TryGetComponent(out Collider2D collider))
            {
                collider.excludeLayers = LayerMask.GetMask(LayerMask.LayerToName(casterTransform.gameObject.layer));
            }
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.fixedDeltaTime);
    }
}
