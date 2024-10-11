using UnityEngine;
using UnityEngine.UI;

public class PlayerSpellsUI : MonoBehaviour
{
    [SerializeField]
    private GridLayoutGroup gridLayout;
    [SerializeField]
    private PlayerSpellData spellLibrary;
    [SerializeField]
    private GameObject playerSpellGridItemPrefab;

    private PlayerSpellGridItemUI[] playerSpellItemUIArr;

    private void Start()
    {
        SetPlayerSpellGrid();
        spellLibrary.OnPlayerSpellsChanged += (_) => SetPlayerSpellGrid();
    }

    private void SetPlayerSpellGrid()
    {
        playerSpellItemUIArr = new PlayerSpellGridItemUI[spellLibrary.PlayerSpells.Length];
        for (int i = 0; i < spellLibrary.PlayerSpells.Length; i++)
        {
            playerSpellItemUIArr[i] = Instantiate(playerSpellGridItemPrefab, gridLayout.transform).GetComponent<PlayerSpellGridItemUI>();

            playerSpellItemUIArr[i].SetPlayerSpell(spellLibrary.PlayerSpells[i]);
        }
    }
}
