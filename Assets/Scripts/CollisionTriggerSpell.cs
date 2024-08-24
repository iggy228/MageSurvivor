using UnityEngine;

public class CollisionTriggerSpell : MonoBehaviour
{
    [SerializeField]
    private Spell spell;

    public void SetSpell(Spell spell)
    {
        this.spell = spell;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spell.Cast(transform);
    }
}
