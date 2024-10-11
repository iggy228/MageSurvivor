using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpellUpgradeListItemUI : MonoBehaviour
{
    [SerializeField]
    private PlayerSpell playerSpell;

    [Header("UI")]
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI title;
    [SerializeField]
    private TextMeshProUGUI upgradeDescription;

    // Start is called before the first frame update
    void Start()
    {
        SetUI();
    }

    private void SetUI()
    {
        if (playerSpell == null)
        {
            gameObject.SetActive(false);
            return;
        }
        icon.sprite = playerSpell.Spell.icon;
        title.text = playerSpell.Spell.spellName;
        upgradeDescription.text = playerSpell.Spell.description;
    }
}
