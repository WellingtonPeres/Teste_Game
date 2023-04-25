using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Stack : MonoBehaviour
{
    public static Stack instance;

    [Header("List of enemies in the stack")]
    [SerializeField] private List<GameObject> stackEnemies = new List<GameObject>();

    [Header("Settings for inertia effect")]
    [SerializeField] private float movementDelayFollow = 0.25f;
    [SerializeField] private float movementDelayOringin = 0.50f;

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> GetStackEnemies()
    {
        return stackEnemies;
    }

    public void AddStackEnemies(GameObject stackEnemy)
    {
        stackEnemies.Add(stackEnemy);
    }

    public void MoveListElements()
    {
        float distanceCubes = 0.4f;
        Vector3 newDistanceCubes = new Vector3(0, distanceCubes, 0);

        for (int i = 1; i < stackEnemies.Count; i++)
        {
            Vector3 position = stackEnemies[i].transform.localPosition;
            position = stackEnemies[i - 1].transform.localPosition;
            stackEnemies[i].transform.DOLocalMove(position + newDistanceCubes, movementDelayFollow);

            stackEnemies[i].transform.LookAt(stackEnemies[i - 1].transform.localPosition);
        }
    }

    public void MoveListOrigin()
    {
        float distanceCubes = 0.4f;
        Vector3 newDistanceCubes = new Vector3(0, distanceCubes, 0);

        for (int i = 1; i < stackEnemies.Count; i++)
        {
            Vector3 position = stackEnemies[i].transform.localPosition;
            position = stackEnemies[0].transform.localPosition;
            stackEnemies[i].transform.DOLocalMove(stackEnemies[i - 1].transform.localPosition + newDistanceCubes, movementDelayOringin);//

            Quaternion originalRotation = stackEnemies[i - 1].transform.rotation;
            stackEnemies[i].transform.DOLocalRotate(originalRotation.eulerAngles, movementDelayOringin);
        }
    }
}
