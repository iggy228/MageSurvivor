using System;

[Serializable]
public class PlayerSpell
{
    private bool locked = true;
    public bool Locked { get => locked; }

    private Spell spell;
    public Spell Spell { get => spell; }

    private int level = 0;
    public int Level { get => level; }

    public PlayerSpell(Spell spell, int level = 0, bool locked = true)
    {
        this.spell = spell;
        this.locked = locked;
        this.level = level;
    }

    public void AddLevel()
    {
        level++;
    }

    public void UnlockSpell()
    {
        locked = false;
    }
}
