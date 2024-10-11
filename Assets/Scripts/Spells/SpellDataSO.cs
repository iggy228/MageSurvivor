using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Spell Data")]
public class SpellDataSO : ScriptableObject
{
    public Spell[] spells;

    public Spell PickRandomSpellFromData(Spell[] filter)
    {
        List<Spell> spellToPickup = new();

        for (int i = 0; i < spells.Length; i++)
        {
            bool isInFilter = false;
            for (int j = 0; j < filter.Length; j++)
            {
                if (filter[j] != null && spells[i].spellName.Equals(filter[j].spellName))
                {
                    isInFilter = true;
                    break;
                }
            }
            if (!isInFilter)
            {
                spellToPickup.Add(spells[i]);
            }
        }

        if (spellToPickup.Count > 0)
        {
            int rndIndex = Random.Range(0, spellToPickup.Count);

            return spellToPickup[rndIndex];
        }

        return null;
    }
}
