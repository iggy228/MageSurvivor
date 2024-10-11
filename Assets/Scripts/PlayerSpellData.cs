using System;
using UnityEngine;

public class PlayerSpellData : MonoBehaviour
{
    [SerializeField]
    private SpellDataSO spellsData;

    private PlayerSpell[] playerSpells;
    public PlayerSpell[] PlayerSpells { get => playerSpells; }

    public event Action<PlayerSpell[]> OnPlayerSpellsChanged;

    private void Awake()
    {
        playerSpells = new PlayerSpell[spellsData.spells.Length];
    }

    private void Start()
    {
        for (int i = 0; i < spellsData.spells.Length; i++)
        {
            playerSpells[i] = new PlayerSpell(spellsData.spells[i]);
        }
        OnPlayerSpellsChanged?.Invoke(playerSpells);
    }
}
