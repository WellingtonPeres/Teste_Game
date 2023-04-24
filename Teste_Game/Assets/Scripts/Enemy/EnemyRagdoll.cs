using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [Header("Number Layer for identify player collision")]
    [SerializeField] private int numberLayerPunch;

    private Rigidbody[] ragdollRigidBodies;
    private Collider[] ColliderBodies;

    private Animator animator;
    private CapsuleCollider capsuleCollider;

    private bool isDead = false;

    public bool IsDead { get => isDead; }

    public void SetIsDead(bool value)
    {
        isDead = value;
    }

    void Awake()
    {
        ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();
        ColliderBodies = GetComponentsInChildren<Collider>();

        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        DisableRagdoll();
    }

    public void DisableRagdoll()
    {
        foreach (Rigidbody rigidbody in ragdollRigidBodies)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void EnableRagdoll()
    {
        foreach (Rigidbody rigidbody in ragdollRigidBodies)
        {
            rigidbody.isKinematic = false;
        }

        capsuleCollider.enabled = false;
    }

    public void DisableCollider()
    {
        foreach (Collider collider in ColliderBodies)
        {
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == numberLayerPunch)
        {
            animator.enabled = false;
            isDead = true;
            EnableRagdoll();
        }
    }    
}
