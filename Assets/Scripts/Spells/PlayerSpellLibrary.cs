using UnityEngine;

[CreateAssetMenu(fileName = "Player Library Spell")]
public class PlayerLibrarySpell : ScriptableObject
{
    public Spell spell;
    public SpellUpgrade[] spellUpgrades;

    public int upgradeLevel = 0;
}
