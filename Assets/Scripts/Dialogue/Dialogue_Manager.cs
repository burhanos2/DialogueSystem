using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dialogue_Manager : MonoBehaviour
{
    //Classes/Modules
    #region ClassesModules

    [SerializeField]
    private Dialogue_Trigger trig;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private TextEffect _textEffect;

    [SerializeField]
    private string jsonPath;

    [SerializeField]
    private KeyCode dialogueButton;

    #endregion

    //Variables
    public Action dialogueStop;
    private IEnumerator enumerator;
    private string line = "";

    private bool dialogueEnded = false;
    private int dialogueIndex;
    private List<string> dialogueLines;



    private void Awake()
    {
        canvas.enabled = false;
        trig.dialogueStart += OnDialogueStart;
    }

    private void SayLine(float aSpeed, string aLine)
    {
        _textEffect.EmptyText();
        _textEffect.textSpeed = aSpeed;
        line = aLine;

        enumerator = _textEffect.TypingEffect(line);
        StartCoroutine(enumerator);
    }

    //Dialogue start and Dialogue end functions
    #region dialogueStartandEnd

    void OnDialogueStart()
    {
        Time.timeScale = 0;
        canvas.enabled = true;

        //
        SayLine(0.1f, "Testing playdialogue call");
    }

    void OnDialogueEnd()
    {

        //
        _textEffect.EmptyText();
        canvas.enabled = false;
        Time.timeScale = 1;
    }

    #endregion

    //Dialogue Management
    #region dialogueManagement

    void Open()
    { }
    void Close()
    { }
    
    #endregion

    private void Update()
    {
        if(Input.GetKey(dialogueButton) && dialogueEnded)
        { OnDialogueEnd(); }
    }
}
