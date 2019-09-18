using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPC_ProximityTrigger : MonoBehaviour
{
    public Action PlayerEnterNPC;
    public Action PlayerExitNPC;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerEnterNPC?.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerExitNPC?.Invoke();
        }
    }
}
