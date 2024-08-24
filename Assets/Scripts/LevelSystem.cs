using System;
using UnityEngine;

/// <summary>
/// Singleton for managing player leveling up
/// </summary>
public class LevelSystem : MonoBehaviour
{
    public static LevelSystem Instance { get; private set; }

    [SerializeField]
    private int level = 0;
    public int Level { get => level; }

    [SerializeField]
    private int experience = 0;
    public int Experience { get => experience; }

    private int experienceToNextLevel = 100;
    public int ExperienceToNextLevel { get => experienceToNextLevel; }

    [Header("Leveling up values")]
    [SerializeField]
    private int startExperienceToNextLevel = 100;
    [Range(0f, 1f)]
    public float percentageExperienceRise = 0.05f;

    public event Action OnExperienceChanged;
    public event Action OnLevelChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        experienceToNextLevel = startExperienceToNextLevel;
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
            experienceToNextLevel += (int)(startExperienceToNextLevel * Math.Pow(1 + percentageExperienceRise, level));

            OnLevelChanged.Invoke();
        }
        OnExperienceChanged?.Invoke();
    }
}
