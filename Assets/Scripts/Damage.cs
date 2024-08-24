using System;

[Serializable]
public class Damage
{
    public int amount;
    public DamagaTypeEnum type;
    public StatusEffect statusEffect;

    public Damage(int amount, DamagaTypeEnum type, StatusEffect statusEffect)
    {
        this.amount = amount;
        this.type = type;
        this.statusEffect = statusEffect;
    }

    public Damage(int amount, DamagaTypeEnum type)
    {
        this.amount = amount;
        this.type = type;
        statusEffect = new StatusEffect();
    }

    public Damage(int amount)
    {
        this.amount = amount;
        type = DamagaTypeEnum.NORMAL;
        statusEffect = new StatusEffect();
    }

    public Damage Clone()
    {
        return new Damage(amount, type, statusEffect);
    }
}
