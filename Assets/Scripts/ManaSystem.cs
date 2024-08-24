using UnityEngine;
using UnityEngine.Events;

public class ManaSystem : MonoBehaviour
{
    [SerializeField]
    private int maxMana;
    public int MaxMana
    {
        get => maxMana;
        set
        {
            if (value <= 0)
            {
                Debug.LogError("Max mana cannot be less than 1");
                return;
            }
            maxMana = value;
            OnMaxManaChanged.Invoke(maxMana);
        }
    }

    private float mana;
    public float Mana
    {
        get => mana;
        set
        {
            if (value < 0)
            {
                Debug.LogError("Mana cannot be lower than 0");
                return;
            }
            if (value > maxMana)
            {
                Debug.LogError("Mana cannot be higher than MaxMana");
                return;
            }
            mana = value;
        }
    }

    public float regenerationPerSecond;

    public StatBar manaBar;

    public UnityEvent<float> OnManaChanged;
    public UnityEvent<int> OnMaxManaChanged;

    void Start()
    {
        mana = maxMana;

        if (manaBar != null)
        {
            manaBar.SetMaxValue(maxMana);
            manaBar.SetValue(mana);
        }
    }

    private void Update()
    {
        RegenMana(regenerationPerSecond * Time.deltaTime);
    }

    public void RegenMana(float amount)
    {
        if (mana < maxMana)
        {
            mana += amount;
            if (mana > maxMana)
            {
                mana = maxMana;
            }

            OnManaChanged.Invoke(mana);
            if (manaBar != null)
            {
                manaBar.SetValue(mana);
            }
        }
    }

    // return true if mana was taken successfully
    public bool TakeMana(float amount)
    {
        if (amount > mana)
        {
            return false;
        }
        mana -= amount;

        OnManaChanged.Invoke(mana);
        if (manaBar != null)
        {
            manaBar.SetValue(mana);
        }

        return true;
    }

    private void OnValidate()
    {
        if (maxMana <= 1)
        {
            maxMana = 1;
        }
        if (mana < 0)
        {
            mana = 0;
        }
        if (mana > maxMana)
        {
            mana = maxMana;
        }
    }
}
