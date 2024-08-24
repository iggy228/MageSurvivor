using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector2 velocity = Vector2.zero;
    public float fakeMaxHeight = 0.5f;
    public float throwTime = 0.5f;
    public int damage = 5;
    public float radius = 0.5f;
    public LayerMask overlapMask;

    public GameObject rockObject;

    private float currentThrowTime = 0f;

    private readonly float sinStart = Mathf.PI / 8;
    private readonly float sinLength = Mathf.PI - Mathf.PI / 8;

    private void Update()
    {
        if (currentThrowTime < throwTime)
        {
            currentThrowTime += Time.deltaTime;
        }
        else
        {
            Explode();
        }
    }

    void FixedUpdate()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;

        float sinValueInTime = Mathf.InverseLerp(0, throwTime, currentThrowTime) * sinLength;
        rockObject.transform.localPosition = new Vector3(0, Mathf.Sin(sinStart + sinValueInTime), 0);
    }

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;
    }

    public void Explode()
    {

        Collider2D overlapObject = Physics2D.OverlapCircle(transform.position, radius, overlapMask);

        if (overlapObject != null && !overlapObject.isTrigger)
        {
            overlapObject.GetComponent<HealthSystem>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
