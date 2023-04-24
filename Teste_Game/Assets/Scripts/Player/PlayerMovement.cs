using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Main reference cube for the other cubes")]
    [SerializeField] private FollowPlayerStack mainBodyEnemyPrefab;

    [Header("Player speed settings")]
    [SerializeField] private float speed;
        
    private Animator animator;

    private const string IS_RUN = "IsRun";

    private Vector2 move;

    public Vector2 Move { get => move; }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void LookRotationDirectionMove(Vector3 movementDirection)
    {
        float ratio = 0.09f;
        if (movementDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), ratio);
        }
    }    

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        LookRotationDirectionMove(movement);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            animator.SetBool(IS_RUN, true);
            Stack.instance.MoveListElements();
        }
        else
        {
            animator.SetBool(IS_RUN, false);
            Stack.instance.MoveListOrigin();
        }
    }

    public void SetMove(Vector2 setMove)
    {
        move = setMove;
    }

    public void SetAnimatorPunch(string nameAnimator, bool value)
    {
        animator.SetBool(nameAnimator, value);
    }
}
