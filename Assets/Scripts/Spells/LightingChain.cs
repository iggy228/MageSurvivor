using UnityEngine;

public class LightingChain : MonoBehaviour
{
    public float minSegmentLength = 0.3f;
    public float deflectionScale = 1f;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void MakeLightingChain(Vector2 from, Vector2 to)
    {
        Vector2 dir = to - from;
        lineRenderer.positionCount = (int)(dir.magnitude / minSegmentLength) + 1;

        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            if (i + 1 == lineRenderer.positionCount)
            {
                lineRenderer.SetPosition(i, to);
            }
            else if (i == 0)
            {
                lineRenderer.SetPosition(i, from);
            }
            else
            {
                Vector2 rotatedDir = new(-dir.normalized.y, dir.normalized.x);
                float rn = Random.Range(-1, 1);
                Vector2 deflection = deflectionScale * rn * rotatedDir;
                lineRenderer.SetPosition(i, from + (dir / lineRenderer.positionCount * i + deflection));
            }
        }
    }
}
