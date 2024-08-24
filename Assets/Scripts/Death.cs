using UnityEngine;

public class Death : MonoBehaviour
{
    public AudioSource deathAudioSource;

    public Animator animator;
    public string animatorClipName;

    [SerializeField]
    private float destroyDelay = 0f;

    [SerializeField] int xp = 0;

    public void Die()
    {
        if (deathAudioSource != null)
        {
            deathAudioSource.Play();
        }
        if (animator != null && animatorClipName != null)
        {
            animator.Play(animatorClipName);
        }

        LevelSystem.Instance.AddExperience(xp);

        Destroy(gameObject, destroyDelay);
    }
}
