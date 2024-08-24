using System;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Damagable : MonoBehaviour
{
    private HealthSystem healthSystem;
    public HealthSystem HealthSystem { get => healthSystem; }

    private StatusEffectManager statusEffectManager;
    public StatusEffectManager StatusEffectManager { get => statusEffectManager; }

    // events
    public event Action<Damage> OnDamageApplied;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        if (TryGetComponent(out StatusEffectManager component))
        {
            statusEffectManager = component;
        }
    }

    public void TakeDamage(int damage)
    {
        TakeDamage(new Damage(damage, DamagaTypeEnum.NORMAL));
    }

    public void TakeDamage(Damage damage)
    {
        healthSystem.TakeDamage(damage.amount);

        if (statusEffectManager != null && damage.statusEffect.type != GameEffectEnum.NONE)
        {
            statusEffectManager.Add(damage.statusEffect);
        }

        OnDamageApplied?.Invoke(damage);
    }
}
