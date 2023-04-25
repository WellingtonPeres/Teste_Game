using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceJoint3D : MonoBehaviour
{
    [Header("Settings for inertia effect")]
    [SerializeField] private Rigidbody connectedRigidbody;
    [SerializeField] private bool determineDistanceOnStart = true;
    [SerializeField] private float distance;
    [SerializeField] private float spring = 0.1f;
    [SerializeField] private float damper = 5f;

    protected Rigidbody myRigidbody;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Physics.gravity = new Vector3(0, 9.81f, 0);

        if (determineDistanceOnStart)
        {
            distance = Vector3.Distance(myRigidbody.position, connectedRigidbody.position);
        }
    }

    private void FixedUpdate()
    {
        var connection = myRigidbody.position - connectedRigidbody.position;
        var distanceDiscrepancy = distance - connection.magnitude;

        myRigidbody.position += distanceDiscrepancy * connection.normalized;

        var velocityTarget = connection + (myRigidbody.velocity + Physics.gravity * spring);
        var projectOnConnection = Vector3.Project(velocityTarget, connection);
        myRigidbody.velocity = (velocityTarget - projectOnConnection) / (1 + damper * Time.fixedDeltaTime);
    }
}
