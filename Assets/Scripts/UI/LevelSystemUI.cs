using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystemUI : MonoBehaviour
{
    public TextMeshProUGUI levelText;

    public TextMeshProUGUI experienceText;
    public Slider experienceSlider;

    // Start is called before the first frame update
    void Start()
    {
        LevelSystem.Instance.OnExperienceChanged += UpdateUI;
        LevelSystem.Instance.OnLevelChanged += UpdateUI;
        UpdateUI();
    }

    public void UpdateUI()
    {
        experienceText.text = $"{LevelSystem.Instance.Experience}/{LevelSystem.Instance.ExperienceToNextLevel}";

        experienceSlider.value = LevelSystem.Instance.Experience;
        experienceSlider.maxValue = LevelSystem.Instance.ExperienceToNextLevel;

        levelText.text = $"Level {LevelSystem.Instance.Level}";
    }

    public void AddExperience(int amount)
    {
        LevelSystem.Instance.AddExperience(amount);
    }
}
