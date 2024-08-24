using UnityEngine;

public enum CastType
{
    NORMAL,
    CHARGE
}

public abstract class Spell : ScriptableObject
{
    [Header("Base spell properties")]
    public string spellName;
    public string description;
    public Sprite icon;

    /// <summary>
    /// Determine if spell uses also variable duration, charge time
    /// </summary>
    public CastType castType;

    public float castDelay;
    public float duration;
    public float chargeTime;

    /// <summary>
    /// variable for using in weapon generator. How often
    /// </summary>
    public int weight;
    public int spellCost;

    public abstract void Cast(Transform casterTransform);
}
