using UnityEngine;
using UnityEngine.UI;

public class LevelsBoxGridItemUI : MonoBehaviour
{
    [SerializeField]
    private Image fillingBox;

    public bool Filled { get => fillingBox.enabled; }

    // Start is called before the first frame update
    void Start()
    {
        fillingBox.enabled = false;
    }

    public void SetFilled(bool filled)
    {
        fillingBox.enabled = filled;
    }
}
