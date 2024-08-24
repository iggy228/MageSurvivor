using System;
using UnityEngine;

[Serializable]
public class StatusEffect
{
    public GameEffectEnum type;

    /// <summary>
    /// Duration of effect on current gameobject.
    /// Recommended to always recover duration of the effect than stacking it
    /// </summary>
    [SerializeField]
    private float duration;
    public float Duration
    {
        get => duration;
        set
        {
            if (value < 0f)
            {
                duration = 0f;
                return;
            }
            duration = value;
        }
    }

    [SerializeField]
    private float interval = 1f;
    public float Interval { get => interval; }

    private float currentInterval = 0f;
    public float CurrentInterval { get => currentInterval; }

    public int modifierValue = 5;

    // events
    public Action OnExpired;

    public StatusEffect()
    {
        type = GameEffectEnum.NONE;
        Duration = 0f;
    }

    public StatusEffect(GameEffectEnum type, float duration)
    {
        this.type = type;
        Duration = duration;
    }

    public void ApplyEffect(GameObject gameObject)
    {
        if (gameObject.TryGetComponent(out Damagable damagable))
        {
            switch (type)
            {
                case GameEffectEnum.BURN:
                    damagable.TakeDamage(new Damage(
                        modifierValue,
                        DamagaTypeEnum.FIRE
                    ));
                    break;
                case GameEffectEnum.POISON:
                    damagable.TakeDamage(new Damage(
                        modifierValue,
                        DamagaTypeEnum.POISION
                    ));
                    break;
                case GameEffectEnum.SHOCK:
                    damagable.TakeDamage(new Damage(
                        modifierValue,
                        DamagaTypeEnum.ELECTRIC
                    ));
                    break;
                default:
                    damagable.TakeDamage(new Damage(
                        modifierValue
                    ));
                    break;
            }
            currentInterval = 0f;
        }
    }

    public void TickDuration(float timeValue)
    {
        Duration -= timeValue;
        currentInterval += timeValue;
        if (Duration <= 0f)
        {
            OnExpired?.Invoke();
        }
    }

    public StatusEffect Clone() => new(type, duration);
}
