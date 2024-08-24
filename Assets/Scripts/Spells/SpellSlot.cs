using System;

public enum SpellState
{
    READY, ACTIVE, COOLDOWN, CHARGE
}

[Serializable]
public class SpellSlot
{
    public Spell spell;
    public bool IsEmpty { get => spell == null; }

    private float castDelay = 0f;
    private float chargeTime = 0f;
    private float duration = 0f;

    private int upgradeLevel = 0;

    private SpellState state = SpellState.READY;
    public SpellState State { get => state; }

    public Action<Spell> OnSpellReady;

    public SpellSlot()
    {
        spell = null;
        castDelay = 0f;
        chargeTime = 0f;
        duration = 0f;
        upgradeLevel = 0;
        state = SpellState.READY;
    }

    public SpellSlot(Spell data)
    {
        spell = data;
        castDelay = 0f;
        chargeTime = 0f;
        duration = 0f;
        upgradeLevel = 0;
        state = SpellState.READY;
    }

    public void Execute(float deltaTime)
    {
        if (spell == null)
        {
            return;
        }

        // both type has this state with same behaviour
        if (state == SpellState.COOLDOWN)
        {
            if (castDelay > 0f)
            {
                castDelay -= deltaTime;
                return;
            }
            state = SpellState.READY;
        }

        if (spell.castType == CastType.CHARGE)
        {
            if (state == SpellState.CHARGE)
            {
                if (chargeTime >= 0f)
                {
                    chargeTime -= deltaTime;
                    return;
                }
                state = SpellState.ACTIVE;
                duration = spell.duration;
            }
            if (state == SpellState.ACTIVE)
            {
                if (duration >= 0f)
                {
                    duration -= deltaTime;
                    return;
                }
                state = SpellState.COOLDOWN;
                castDelay = spell.castDelay;
            }
        }
    }

    // return gameobject to cast
    public void TryCastSpell(Caster caster)
    {
        if (state == SpellState.READY)
        {
            switch (spell.castType)
            {
                case CastType.NORMAL:
                    castDelay = spell.castDelay;
                    state = SpellState.COOLDOWN;
                    spell.Cast(caster.CastPoint);
                    break;
                case CastType.CHARGE:
                    chargeTime = spell.chargeTime;
                    state = SpellState.CHARGE;
                    break;
            }
        }
        if (state == SpellState.ACTIVE)
        {
            spell.Cast(caster.CastPoint);
        }
    }

    public void CancelCasting()
    {
        if (state == SpellState.CHARGE)
        {
            state = SpellState.READY;
            chargeTime = 0f;
        }
        if (state == SpellState.ACTIVE)
        {
            state = SpellState.COOLDOWN;
            duration = 0f;
            castDelay = spell.castDelay;
        }
    }

    public void AddSpellLevel()
    {
        upgradeLevel++;
    }
}
