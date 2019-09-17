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
    private KeyCode dialogueButton;

    [SerializeField]
    private JsonData jsonData;
    
    #endregion

    //Variables
    public Action dialogueStop;
    private IEnumerator enumerator;
    private bool dialogueActive;

    private string line = "";
    private int dialogueIndex = 0;
    private float _speed;

    private void Awake()
    {
        canvas.enabled = false;
        trig.dialogueStart += OnDialogueStart;
    }

    private void SayLine(string aLine)
    {
        _textEffect.EmptyText();
        _textEffect.textSpeed = _speed;
        line = aLine;

        enumerator = _textEffect.TypingEffect(line, _speed);
        StartCoroutine(enumerator);
    }

    //Dialogue start and Dialogue end functions
    #region dialogueStartandEnd

    void OnDialogueStart()
    {
        dialogueActive = true;
        Time.timeScale = 0;
        canvas.enabled = true;
        _speed = jsonData.npcData.textSpeed;

        SayLine(jsonData.npcData.dialogueLines[0]);
    }

    void OnDialogueEnd()
    {
        _textEffect.EmptyText();
        canvas.enabled = false;
        Time.timeScale = 1;
        dialogueActive = false;
    }

    #endregion

    //Dialogue Management
    #region dialogueManagement

    void Open()
    { }
    void Close()
    { }

    #endregion

   
}
