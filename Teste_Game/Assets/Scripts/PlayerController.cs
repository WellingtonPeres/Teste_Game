using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private GameObject collisorDamage;

    private Vector2 move;

    private Animator animator;

    [SerializeField] private List<GameObject> catchPoints;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void LookRotationDirectionMove(Vector3 movementDirection)
    {
        float ratio = 0.09f;
        if (movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), ratio);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        if (context.performed)// Transformar em Método
        {
            animator.SetTrigger("Punch");// Transformar em const
            collisorDamage.SetActive(true);
        }
        else
        {
            collisorDamage.SetActive(false);
        }
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        LookRotationDirectionMove(movement);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }
    }

    public void AddEnemysInList(GameObject enemy)
    {
        catchPoints.Add(enemy);
    }    
}
