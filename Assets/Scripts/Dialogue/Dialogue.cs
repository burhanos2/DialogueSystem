using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private Dialogue_Trigger trig;

    public Action dialogueStop;

    private void Awake()
    {
        trig.dialogueStart += DialogueStartRoutine;
    }

    void DialogueStartRoutine()
    {
        Time.timeScale = 0;

        //
        PlayDialogue();
    }

    void DialogueEndRoutine()
    {

        //
        Time.timeScale = 1;
    }

    private void PlayDialogue()
    {

    }
}
