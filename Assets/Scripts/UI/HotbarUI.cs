using UnityEngine;
using UnityEngine.UI;

public class HotbarUI : MonoBehaviour
{
    public GridLayoutGroup weaponGridLayout;
    public GameObject weaponSlotUI;

    [SerializeField]
    private SpellInventory spellInventory;

    private SpellSlotUI[] spellSlotsUI;

    private void Awake()
    {
        spellSlotsUI = new SpellSlotUI[spellInventory.SpellSlotsCount];
        for (int i = 0; i < spellInventory.SpellSlotsCount; i++)
        {
            spellSlotsUI[i] = Instantiate(weaponSlotUI, weaponGridLayout.transform).GetComponent<SpellSlotUI>();
        }
    }

    private void Start()
    {
        spellInventory.OnSpellSlotsUpdated.AddListener(SetWeaponSlots);
        spellInventory.OnSelectedSpellSlotChanged.AddListener(SetActiveSpellSlot);

        SetWeaponSlots(spellInventory.Spells);
    }

    public void SetWeaponSlots(SpellSlot[] spells)
    {
        for (int i = 0; i < spellSlotsUI.Length; i++)
        {
            if (!spells[i].IsEmpty)
            {
                spellSlotsUI[i].SetWeaponIconSprite(spells[i].spell.icon);
            }
            else
            {
                spellSlotsUI[i].SetWeaponIconSprite(null);
            }
        }
    }

    public void SetActiveSpellSlot(int? oldIndex, int? newIndex)
    {
        if (oldIndex != null)
        {
            spellSlotsUI[(int)oldIndex].Active = false;
        }
        if (newIndex != null)
        {
            spellSlotsUI[(int)newIndex].Active = true;
        }
    }
}
