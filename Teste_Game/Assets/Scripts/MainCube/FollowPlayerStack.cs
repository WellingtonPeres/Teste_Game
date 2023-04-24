using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerStack : MonoBehaviour
{
    [Header("Point reference that the cubes should follow")]
    [SerializeField] private Transform pointBodyEnemyStack;

    private void Update()
    {
        transform.LookAt(pointBodyEnemyStack);
        transform.position = pointBodyEnemyStack.position;
    }
}
