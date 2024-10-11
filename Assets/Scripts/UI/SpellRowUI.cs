using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpellRowUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Border variables")]
    public Image border;
    public Sprite inactiveBorderSprite;
    public Sprite activeBorderSprite;

    [Header("Text variables")]
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public SpellSlotUI spellSlot;

    public event Action<Spell> OnRowSelected;

    private Spell spell;

    public void SetUI(Spell spell)
    {
        this.spell = spell;

        if (spell != null)
        {
            titleText.text = spell.spellName;
            descriptionText.text = spell.description;
            spellSlot.SetIcon(spell.icon);
        }
        else
        {
            titleText.text = "";
            descriptionText.text = "";
            spellSlot.SetIcon(null);
        }
    }

    public void OnRowClicked()
    {
        OnRowSelected?.Invoke(spell);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        border.sprite = activeBorderSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        border.sprite = inactiveBorderSprite;
    }
}
