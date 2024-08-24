using UnityEngine;
using UnityEngine.Events;

public class SpellInventory : MonoBehaviour
{
    private SpellSlot[] spells = new SpellSlot[4];
    public SpellSlot[] Spells { get => spells; }
    public int SpellSlotsCount { get => spells.Length; }

    private int? selectedSpellSlotIndex = null;
    public SpellSlot SelectedSpell
    {
        get
        {
            if (selectedSpellSlotIndex == null)
            {
                return null;
            }
            return spells[(int)selectedSpellSlotIndex];
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
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i] = new SpellSlot();
        }
    }

    private void Start()
    {
        for (int i = 0; i < startingSpell.Length; i++)
        {
            if (startingSpell[i] != null)
            {
                spells[i] = startingSpell[i];
                OnSpellSlotsUpdated.Invoke(spells);
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
        for (int i = 0; i < spells.Length; i++)
        {
            spells[i]?.Execute(Time.fixedDeltaTime);
        }
    }

    public void SelectWeaponOnPosition(int index)
    {
        OnSelectedSpellSlotChanged?.Invoke(selectedSpellSlotIndex, index);
        selectedSpellSlotIndex = index;
    }

    public int FindEmptySlot()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            if (spells[i].IsEmpty)
            {
                return i;
            }
        }
        return -1;
    }
}
