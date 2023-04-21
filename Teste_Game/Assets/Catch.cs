using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Catch : MonoBehaviour
{
    [SerializeField] private int numberLayerEnemy;

    [SerializeField] private Transform catchPoint;

    private BoxCollider boxCollider;
    private PlayerController playerController;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        playerController = GetComponentInParent<PlayerController>();
    }

    public void OnCatch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            boxCollider.enabled = true;
            Debug.Log("Pegar");
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == numberLayerEnemy && EnemyRagdoll.instace.IsDead)
        {
            EnemyRagdoll.instace.DisableRagdoll();

            other.enabled = false;
            other.gameObject.transform.position = catchPoint.position;
            other.gameObject.transform.parent = catchPoint;

            playerController.AddEnemysInList(other.gameObject);
        }
    }
}
