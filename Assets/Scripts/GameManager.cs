using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    PLAY, PAUSE, LEVEL_UP
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }

    private GameState state;
    public GameState State { get { return state; } }

    [SerializeField]
    private UIController controller;

    [SerializeField]
    private SpellDataSO spellData;

    [SerializeField]
    private LevelSystem playerLevelSystem;
    [SerializeField]
    private SpellInventory playerSpellInventory;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        state = GameState.PAUSE;
    }

    private void Start()
    {
        playerLevelSystem.OnLevelChanged += LevelUpPlayer;
        controller.PlayerLevelUpBoxUI.OnSpellPickedUp += (spell) =>
        {
            controller.HideLevelUpBox();
            Time.timeScale = 1f;
            playerSpellInventory.AddSpell(spell);
        };
    }

    public void LevelUpPlayer()
    {
        if (playerSpellInventory.FindEmptySlot() == -1)
        {
            return;
        }

        Time.timeScale = 0f;

        List<Spell> spellToShow = new(4);
        List<Spell> filter = new();

        for (int i = 0; i < playerSpellInventory.Spells.Length; i++)
        {
            filter.Add(playerSpellInventory.Spells[i]);
        }

        for (int i = 0; i < 4; i++)
        {
            Spell pickedSpell = spellData.PickRandomSpellFromData(filter.ToArray());
            filter.Add(pickedSpell);
            spellToShow.Add(pickedSpell);
        }
        controller.ShowLevelUpBox(spellToShow.ToArray());
    }
}
