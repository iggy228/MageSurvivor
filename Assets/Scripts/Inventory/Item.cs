using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    public Sprite image;
    public ItemType type;
}

public enum ItemType
{
    Spell,
    Weapon
}