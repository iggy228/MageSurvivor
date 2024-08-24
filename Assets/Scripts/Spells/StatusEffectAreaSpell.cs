using UnityEngine;

[CreateAssetMenu(fileName = "Status Effect Area spell", menuName = "Spells/Status Effect Area Spell")]
public class StatusEffectAreaSpell : Spell
{
    public StatusEffect statusEffect;
    public float lifetime;
    public float size;
    public float applyStatusEffectInterval = 1f;

    public bool casterFriendly;
    public GameObject statusEfffectArea;

    public override void Cast(Transform casterTransform)
    {
        throw new System.NotImplementedException();
    }
}
