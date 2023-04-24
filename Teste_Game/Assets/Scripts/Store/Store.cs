using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [Header("Reference to get money for level up")]
    [SerializeField] private GameManager gameManager;
    [SerializeField] private CollectEnemies collectEnemies;
    [SerializeField] private int numberLayerPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == numberLayerPlayer)
        {
            var countEnemyStack = other.gameObject.GetComponentInChildren<CollectEnemies>();
            if (countEnemyStack.CurrentStack != 0)
            {
                int totalMoney = gameManager.CurrentMoneyPerBodyEnemyInStack * countEnemyStack.CurrentStack;

                gameManager.SetAccumulateMoney(totalMoney);
                gameManager.SetMoneyText("R$ ", gameManager.AccumulateMoney);

                collectEnemies.SetCurrentStack(0);
            }

            foreach (GameObject enemies in Stack.instance.GetStackEnemies())
            {
                enemies.SetActive(false);
            }
        }
    }
}
