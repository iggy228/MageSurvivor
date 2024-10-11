using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    private PlayerSpellsUI playerSpellsUI;
    [SerializeField]
    private PlayerLevelUpBoxUI playerLevelUpBoxUI;
    public PlayerLevelUpBoxUI PlayerLevelUpBoxUI { get { return playerLevelUpBoxUI; } }

    void Start()
    {
        playerSpellsUI.gameObject.SetActive(false);
        playerLevelUpBoxUI.gameObject.SetActive(false);

        playerLevelUpBoxUI.OnSpellPickedUp += (spell) => HideLevelUpBox();
    }

    void Update()
    {
        if (Input.GetButtonDown("Open/Close Spells"))
        {
            TogglePlayerSpellUI();
        }
    }

    public void TogglePlayerSpellUI()
    {
        playerSpellsUI.gameObject.SetActive(!playerSpellsUI.gameObject.activeSelf);
    }

    public void SetActivePlayerSpellUI(bool state)
    {
        playerSpellsUI.gameObject.SetActive(state);
    }

    public void ShowLevelUpBox(Spell[] spells)
    {
        playerLevelUpBoxUI.gameObject.SetActive(true);
        playerLevelUpBoxUI.SetSpellRowsUI(spells);
    }

    public void HideLevelUpBox()
    {
        playerLevelUpBoxUI.gameObject.SetActive(false);
    }
}
