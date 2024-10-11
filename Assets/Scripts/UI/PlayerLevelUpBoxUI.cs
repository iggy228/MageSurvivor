using System;
using UnityEngine;

public class PlayerLevelUpBoxUI : MonoBehaviour
{
    [SerializeField, Min(0)]
    private int rowCount;

    public GameObject spellRowUIPrefab;
    [SerializeField]
    private Transform spellRowParent;

    private SpellRowUI[] spellRows;

    public event Action<Spell> OnSpellPickedUp;

    void Awake()
    {
        spellRows = new SpellRowUI[rowCount];

        for (int i = 0; i < rowCount; i++)
        {
            spellRows[i] = Instantiate(spellRowUIPrefab, spellRowParent.transform).GetComponent<SpellRowUI>();
            spellRows[i].SetUI(null);
            spellRows[i].OnRowSelected += SelectSpell;
        }
    }

    public void SetSpellRowsUI(Spell[] spells)
    {
        for (int i = 0; i < rowCount; i++)
        {
            if (i < spells.Length)
            {
                spellRows[i].SetUI(spells[i]);
            }
            else
            {
                spellRows[i].SetUI(null);
            }
        }
    }

    private void OnValidate()
    {
        if (rowCount > 4)
        {
            rowCount = 4;
        }
    }

    public void SelectSpell(Spell spell)
    {
        if (spell != null)
        {
            OnSpellPickedUp?.Invoke(spell);
        }
    }
}
