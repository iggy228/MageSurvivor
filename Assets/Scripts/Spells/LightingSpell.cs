using UnityEngine;

public class LightingSpell : MonoBehaviour
{
    public int damage = 5;
    public float castDelay = 5f;
    public float lightingDuration = 0.25f;

    public LayerMask enemyLayerMask;

    private float currentCastDelay = 0f;
    private float currentLightingDuration = 0f;

    public LightingChain lightingChain;
    private bool fireSpell = false;

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            fireSpell = true;
        }
        else
        {
            fireSpell = false;
        }
    }

    private void FixedUpdate()
    {
        if (currentCastDelay > 0)
        {
            currentCastDelay -= Time.fixedDeltaTime;
        }
        if (currentCastDelay <= 0 && fireSpell)
        {
            LightingAttack();
            currentCastDelay = castDelay;
        }


        if (currentLightingDuration <= 0)
        {
            lightingChain.gameObject.SetActive(false);
        }
        else
        {
            currentLightingDuration -= Time.fixedDeltaTime;
        }
    }
    public void LightingAttack()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lightingChain.MakeLightingChain(transform.position, mousePos);
        lightingChain.gameObject.SetActive(true);
        currentLightingDuration = lightingDuration;

        Collider2D collider = Physics2D.OverlapCircle(mousePos, 2f, enemyLayerMask);
        if (collider != null)
        {
            collider.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }
}
