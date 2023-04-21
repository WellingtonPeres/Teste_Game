using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    public static EnemyRagdoll instace;

    [SerializeField] private int numberLayerPunch;
    private int money = 0;

    private Rigidbody[] ragdollRigidBodies;

    private Animator animator;
    private CapsuleCollider capsuleCollider;

    private bool isDead = false;
    

    public bool IsDead { get => isDead; }

    void Awake()
    {
        instace = this;

        ragdollRigidBodies = GetComponentsInChildren<Rigidbody>();

        animator = GetComponentInChildren<Animator>();
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

    private void EnableRagdoll()
    {
        foreach (Rigidbody rigidbody in ragdollRigidBodies)
        {
            rigidbody.isKinematic = false;
        }
        capsuleCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == numberLayerPunch)
        {
            animator.enabled = false;
            isDead = true;
            EnableRagdoll();
            Debug.Log("Bateu" + " e " + "morri é: " + IsDead);
        }
    }
}
