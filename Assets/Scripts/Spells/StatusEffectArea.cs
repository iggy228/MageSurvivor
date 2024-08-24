using System.Collections.Generic;
using UnityEngine;

public class StatusEffectArea : MonoBehaviour
{
    public StatusEffectAreaSpell spell;

    private readonly List<StatusEffectManager> statusEffectManagers = new();

    private float currentInterval = 0f;

    private void Start()
    {
        transform.localScale = new Vector3(spell.size, spell.size, 1f);
        Destroy(gameObject, spell.lifetime);
    }

    private void FixedUpdate()
    {
        if (currentInterval <= 0f)
        {
            TryApplyStatusEffect();
        }
        else
        {
            currentInterval -= Time.fixedDeltaTime;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out StatusEffectManager statusEffectManager))
        {
            statusEffectManagers.Add(statusEffectManager);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out StatusEffectManager statusEffectManager))
        {
            statusEffectManagers.Remove(statusEffectManager);
        }
    }

    private void TryApplyStatusEffect()
    {
        if (statusEffectManagers.Count == 0)
        {
            return;
        }

        for (int i = 0; i < statusEffectManagers.Count; i++)
        {
            statusEffectManagers[i].Add(spell.statusEffect);
        }
        currentInterval = spell.applyStatusEffectInterval;
    }
}
