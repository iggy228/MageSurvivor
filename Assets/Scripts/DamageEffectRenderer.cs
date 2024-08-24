using System.Collections;
using UnityEngine;

public class DamageEffectRenderer : MonoBehaviour
{
    [field: SerializeField]
    public Damagable Damagable { get; set; }

    [field: SerializeField]
    public SpriteRenderer SpriteRenderer { get; set; }

    [SerializeField]
    private float effectTime = 0.1f;

    private void OnEnable()
    {
        Damagable.OnDamageApplied += ApplyDamageEffect;
    }

    private void OnDisable()
    {
        Damagable.OnDamageApplied -= ApplyDamageEffect;
    }

    public void ApplyDamageEffect(Damage damage)
    {
        StartCoroutine(ApplyColorOnSprite());
    }

    private IEnumerator ApplyColorOnSprite()
    {
        SpriteRenderer.color = Color.red;
        yield return new WaitForSeconds(effectTime);
        SpriteRenderer.color = Color.white;
    }
}
