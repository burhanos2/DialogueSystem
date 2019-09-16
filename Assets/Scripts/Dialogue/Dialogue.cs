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

    [SerializeField]
    private TextEffect _textEffect;

    public Action dialogueStop;

    private IEnumerator enumerator;
    private string line = "";

    private void Awake()
    {
        canvas.enabled = false;
        trig.dialogueStart += OnDialogueStart;
    }

    void OnDialogueStart()
    {
        Time.timeScale = 0;
        canvas.enabled = true;

        //
        SayLine(0.1f, "Testing playdialogue call");
    }

    void DialogueEndRoutine()
    {

        //
        Time.timeScale = 1;
    }

    private void SayLine(float aSpeed, string aLine)
    {
        _textEffect.EmptyText();
        _textEffect.textSpeed =  aSpeed;
        line = aLine;

        enumerator = _textEffect.TypingEffect(line);
        StartCoroutine(enumerator);
    }
}
