using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const string PUNCH = "Punch";

    private PlayerMovement playerMovement;
    private PlayerPunch playerPunch;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerPunch = GetComponentInChildren<PlayerPunch>();
    }

    private void Update()
    {
        playerMovement.MovePlayer();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        playerMovement.SetMove(context.ReadValue<Vector2>());
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerMovement.SetAnimatorPunch(PUNCH, true);
            playerPunch.SetTriggerCollider(true);
        }
        else
        {
            playerPunch.SetTriggerCollider(false);
        }
    }
}
