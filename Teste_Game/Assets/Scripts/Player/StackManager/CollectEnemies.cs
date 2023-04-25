using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollectEnemies : MonoBehaviour
{
    [Header("All Informations About Stack")]
    [SerializeField] private GameObject bodyEnemyPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform pointBodyEnemyStack;
    [SerializeField] private int numLayerEnemy;

    private Collider myCollider;

    private int currentStack = 0;

    public int CurrentStack { get => currentStack; }

    private void Awake()
    {
        myCollider = GetComponent<Collider>();
    }

    public void OnStack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            myCollider.enabled = true;
        }
        else
        {
            myCollider.enabled = false;
        }
    }

    public void SetCurrentStack(int value)
    {
        currentStack = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == numLayerEnemy && other.gameObject.GetComponentInParent<EnemyRagdoll>().IsDead)
        {
            if (currentStack < gameManager.CurrentLimitStack)
            {
                DisableEnemyInScene(other);

                currentStack++;

                if (currentStack > Stack.instance.GetStackEnemies().Count)
                {
                    CriateNewObjectInListStack();
                }
                else
                {
                    ActiveObjectInStack();
                }
            }
        }
    }

    private void CriateNewObjectInListStack()
    {
        float distanceCubes = 1.4f;
        var referenceListStackEnemies = Stack.instance.GetStackEnemies();

        GameObject newCube = Instantiate(
            bodyEnemyPrefab,
            referenceListStackEnemies[referenceListStackEnemies.Count - 1].transform.position + new Vector3(0, distanceCubes, 0),
            referenceListStackEnemies[referenceListStackEnemies.Count - 1].transform.rotation);
        Stack.instance.AddStackEnemies(newCube);
        newCube.SetActive(true);
    }

    private void ActiveObjectInStack()
    {
        for (int i = 0; i < currentStack; i++)
        {
            Stack.instance.GetStackEnemies()[i].gameObject.SetActive(true);
        }
    }

    private void DisableEnemyInScene(Collider collider)
    {
        collider.gameObject.GetComponentInParent<EnemyRagdoll>().gameObject.SetActive(false);
    }
}
