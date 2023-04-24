using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    private Collider collisorDamage;

    private void Awake()
    {
        collisorDamage = GetComponent<Collider>();
    }

    public void SetTriggerCollider(bool value)
    {
        collisorDamage.enabled = value;
    }
}
