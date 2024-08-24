using UnityEngine;

public class Caster : MonoBehaviour
{
    [SerializeField]
    private SpellInventory spellInventory;

    [SerializeField]
    private Transform castPoint;
    public Transform CastPoint { get => castPoint; }

    private bool oldCastingVal;
    private bool casting;

    [SerializeField]
    private Collider2D m_collider;
    public Collider2D Collider { get => m_collider; }

    private void Start()
    {
        m_collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        oldCastingVal = casting;
        casting = Input.GetAxis("Fire1") > 0.1f;
    }

    private void FixedUpdate()
    {
        if (casting)
        {
            CastSelectedSpell();
        }
        if (oldCastingVal && !casting)
        {

        }
    }

    public void CastSelectedSpell()
    {
        if (spellInventory.SelectedSpell == null)
        {
            return;
        }

        spellInventory.SelectedSpell.TryCastSpell(this);
    }
}
