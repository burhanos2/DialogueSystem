using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    private Dialogue_Trigger trig;

    [SerializeField]
    private Canvas canvas;

    public Action dialogueStop;

    private void Awake()
    {
        canvas.enabled = false;
        trig.dialogueStart += DialogueStartRoutine;
    }

    void DialogueStartRoutine()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
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
