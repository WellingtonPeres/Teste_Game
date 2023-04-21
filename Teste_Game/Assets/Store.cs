using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private int numberLayerPlayer;

    private int currentMoney = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == numberLayerPlayer)
        {
            //foreach

            currentMoney += 10; //ScriptableObject --> += ao valor do mostro morto
            gameController.SetMoneyText(currentMoney);
            Debug.Log("vender");
        }
    }
}
