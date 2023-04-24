using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Setting for follow player")]
    [SerializeField] private Transform playerTarget;
    [SerializeField] private Vector3 positionFollowPlayer;

    void Update()
    {
        transform.position = playerTarget.position + positionFollowPlayer;
    }
}
