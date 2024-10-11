using UnityEngine;

public class MainInventoryGroupUI : MonoBehaviour
{
    public void ToggleUI()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
