using UnityEngine;
using UnityEngine.UI;

public class SpellSlotUI : MonoBehaviour
{
    public Image icon;
    public Image border;

    private bool active;
    public bool Active
    {
        get { return active; }
        set
        {
            active = value;
            if (active)
            {
                border.enabled = true;
            }
            else
            {
                border.enabled = false;
            }
        }
    }

    public void SetWeaponIconSprite(Sprite sprite)
    {
        icon.sprite = sprite;

        if (sprite == null)
        {
            icon.enabled = false;
        }
        else
        {
            icon.enabled = true;
        }
    }
}
