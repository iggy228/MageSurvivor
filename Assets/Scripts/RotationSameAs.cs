using UnityEngine;

public class RotationSameAs : MonoBehaviour
{
    public Transform rotationTransform;

    private void FixedUpdate()
    {
        transform.rotation = rotationTransform.rotation;
    }
}
