using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxValue(int maxHealth)
    {
        slider.maxValue = maxHealth;
    }

    public void SetValue(int health)
    {
        slider.value = health;
    }

    public void SetValue(float health)
    {
        slider.value = Mathf.Ceil(health);
    }
}
