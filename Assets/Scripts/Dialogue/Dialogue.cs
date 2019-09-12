using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private Dialogue_Trigger trig;
    [SerializeField]
    private SimpleMovement movement;

    public static Action stopMovement;
    public static Action startMovement;

    private void Awake()
    {
        trig.dialogueStart += DialogueStartRoutine;
    }

    void DialogueStartRoutine()
    {
        stopMovement?.Invoke();

    }
}
