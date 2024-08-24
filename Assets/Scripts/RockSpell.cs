using UnityEngine;

public class RockSpell : MonoBehaviour
{
    public float castDelay = 7f;
    public float radius = 5f;

    private float currentCastDelay = 0f;

    public GameObject rockPrefab;

    private bool fireSpell = false;

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            fireSpell = true;
        }
        else
        {
            fireSpell = false;
        }
    }

    private void FixedUpdate()
    {
        if (currentCastDelay > 0)
        {
            currentCastDelay -= Time.fixedDeltaTime;
        }
        if (fireSpell && currentCastDelay <= 0)
        {
            Attack();
            currentCastDelay = castDelay;
        }
    }

    public void Attack()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Rock newBomb = Instantiate(rockPrefab, transform).GetComponent<Rock>();
        Vector2 mouseVector = mousePos - (Vector2)transform.position;

        if (mouseVector.magnitude > radius)
        {
            mouseVector = mouseVector.normalized * radius;
        }
        newBomb.SetVelocity(mouseVector.normalized * (mouseVector.magnitude / newBomb.throwTime));
    }
}
