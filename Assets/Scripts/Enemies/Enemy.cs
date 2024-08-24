using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform playerTransform;
    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }
}
