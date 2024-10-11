using System;
using UnityEngine;

[Serializable]
public class ProjectileSpellStats
{
    public Damage damage;
    public float lifetime;

    public bool piercing = false;

    public float speed;
    /// <summary>
    /// tell projectile if they should accelarate overtime or decelerate
    /// if value is less than 1 projectile will slown down overtime
    /// if value is 1 it will fly in constant speed
    /// if value is more than 1 projectile will fly faster overtime 
    /// </summary>
    [Min(0f)]
    public float accelarationRate = 1f;

    public ProjectileSpellStats(Damage damage, float lifetime, bool piercing, float speed, float accelarationRate)
    {
        this.damage = damage;
        this.lifetime = lifetime;
        this.piercing = piercing;
        this.speed = speed;
        this.accelarationRate = accelarationRate;
    }
}
