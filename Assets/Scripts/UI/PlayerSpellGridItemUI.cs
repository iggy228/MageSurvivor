using UnityEngine;
using UnityEngine.UI;

public class PlayerSpellGridItemUI : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private GameObject levelBoxItemPrefab;

    private PlayerSpell playerSpell;
    public PlayerSpell PlayerSpell { get => playerSpell; }

    public void SetPlayerSpell(PlayerSpell spell)
    {
        playerSpell = spell;
        icon.sprite = spell.Spell.icon;
    }
}
