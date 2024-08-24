using System;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    [SerializeField]
    private List<StatusEffect> statusEffects = new();

    // events
    public event Action<StatusEffect> OnStatusEffectAdded;
    public event Action<StatusEffect> OnStatusEffectRemoved;

    private void FixedUpdate()
    {
        ApplyStatusEffects();
    }

    public void Add(StatusEffect statusEffect)
    {
        StatusEffect foundedEffect = statusEffects.Find((effect) => effect.type == statusEffect.type);

        if (foundedEffect == null)
        {
            statusEffects.Add(statusEffect.Clone());
            OnStatusEffectAdded?.Invoke(statusEffect);

            // remove when effect expired
            statusEffect.OnExpired = () => RemoveStatusEffect(statusEffect);

            return;
        }

        if (foundedEffect.Duration < statusEffect.Duration)
        {
            foundedEffect.Duration = statusEffect.Duration;
        }
    }

    public void ClearStatusEffects()
    {
        statusEffects.Clear();
    }

    public void RemoveStatusEffect(StatusEffect statusEffect)
    {
        statusEffects.Remove(statusEffect);
        OnStatusEffectRemoved?.Invoke(statusEffect);
    }

    public void ApplyStatusEffects()
    {
        for (int i = 0; i < statusEffects.Count; i++)
        {
            if (statusEffects[i] != null && statusEffects[i].CurrentInterval >= statusEffects[i].Interval)
            {
                statusEffects[i].ApplyEffect(gameObject);
            }
            else
            {
                statusEffects[i].TickDuration(Time.fixedDeltaTime);
            }
        }
    }
}
