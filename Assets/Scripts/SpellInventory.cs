using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// TODO Refactor for supporting dynamic length
public class SpellInventory : MonoBehaviour
{
    private SpellSlot[] spellSlots = new SpellSlot[4];
    public SpellSlot[] SpellsSlots { get => spellSlots; }

    /// <summary>
    /// Return all spells in inventory
    /// </summary>
    public Spell[] Spells
    {
        get
        {
            List<Spell> spells = new();

            foreach (SpellSlot spellSlot in spellSlots)
            {
                if (spellSlot.spell != null)
                {
                    spells.Add(spellSlot.spell);
                }
            }

            return spells.ToArray();
        }
    }

    public int SpellSlotsCount { get => spellSlots.Length; }

    private int? selectedSpellSlotIndex = null;
    public SpellSlot SelectedSpell
    {
        get
        {
            if (selectedSpellSlotIndex == null)
            {
                return null;
            }
            return spellSlots[(int)selectedSpellSlotIndex];
        }
    }

    // unity only
    public SpellSlot[] startingSpell = new SpellSlot[4];

    /// <summary>
    /// Send event about changed selected slot first value in old index, second value is new index
    /// </summary>
    public UnityEvent<int?, int?> OnSelectedSpellSlotChanged;
    public UnityEvent<SpellSlot[]> OnSpellSlotsUpdated;

    private void Awake()
    {
        for (int i = 0; i < spellSlots.Length; i++)
        {
            spellSlots[i] = new SpellSlot();
        }
    }

    private void Start()
    {
        for (int i = 0; i < startingSpell.Length; i++)
        {
            if (startingSpell[i] != null)
            {
                spellSlots[i] = startingSpell[i];
                OnSpellSlotsUpdated.Invoke(spellSlots);
            }
        }
    }

    private void Update()
    {


        if (Input.GetAxisRaw("Weapon1") > 0.1f)
        {
            SelectWeaponOnPosition(0);
        }
        if (Input.GetAxisRaw("Weapon2") > 0.1f)
        {
            SelectWeaponOnPosition(1);
        }
        if (Input.GetAxisRaw("Weapon3") > 0.1f)
        {
            SelectWeaponOnPosition(2);
        }
        if (Input.GetAxisRaw("Weapon4") > 0.1f)
        {
            SelectWeaponOnPosition(3);
        }
    }

    void FixedUpdate()
    {
        // tick all spells
        for (int i = 0; i < spellSlots.Length; i++)
        {
            spellSlots[i]?.Execute(Time.fixedDeltaTime);
        }
    }

    public void SelectWeaponOnPosition(int index)
    {
        OnSelectedSpellSlotChanged?.Invoke(selectedSpellSlotIndex, index);
        selectedSpellSlotIndex = index;
    }

    public int FindEmptySlot()
    {
        for (int i = 0; i < spellSlots.Length; i++)
        {
            if (spellSlots[i].IsEmpty)
            {
                return i;
            }
        }
        return -1;
    }

    public bool AddSpell(Spell spell)
    {
        int slotIndex = FindEmptySlot();
        if (slotIndex != -1)
        {
            spellSlots[slotIndex].spell = spell;
            OnSpellSlotsUpdated?.Invoke(spellSlots);
            return true;
        }
        return false;
    }
}
