using System;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour
{
   public KeyCode dialogueInitiationKey;
    public Action dialogueStart;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        { 
             if (Input.GetKeyDown(dialogueInitiationKey))
             {
             dialogueStart?.Invoke();
             }
        }
    }
}
