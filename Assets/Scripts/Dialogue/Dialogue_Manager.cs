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

    [SerializeField]
    private DialogueName dialogueName;
    
    #endregion

    //Variables
    public Action dialogueStop;
    public Action dialogueInactive;

    private IEnumerator enumerator;
    private bool textActive = false;
    private bool dialogueActive = false;

    private string line = "";
    private int dialogueIndex = 0;
    private float _speed;

    private NPCData npcData;

    private void Awake()
    {
        canvas.enabled = false;
        trig.dialogueStart += OnDialogueStart;
        dialogueInactive += OnDialogueInactive;
        dialogueStop += OnDialogueEnd;
    }

    private void SayLine(string aLine)
    {
        textActive = true;
        _textEffect.EmptyText();
        _textEffect.textSpeed = _speed;
        line = aLine;

        enumerator = _textEffect.TypingEffect(line, _speed, dialogueInactive);
        StartCoroutine(enumerator);
    }

    //Dialogue start and Dialogue end functions
    #region dialogueStartandEnd

    void OnDialogueStart()
    {
        npcData = jsonData.npcData;

        Color newColor = new Color(npcData.colorRed, npcData.colorGreen, npcData.colorBlue, 255f);
        _textEffect.ChangeColor(newColor);
        dialogueName.SetName(npcData.name, newColor);

        dialogueActive = true;
        Time.timeScale = 0;
        canvas.enabled = true;
        _speed = npcData.textSpeed;
    }

    void OnDialogueInactive()
    {
        textActive = false;
    }

    void OnDialogueEnd()
    {
        dialogueActive = false;
        _textEffect.EmptyText();
        canvas.enabled = false;
        Time.timeScale = 1;
        dialogueIndex = 0;
    }

    #endregion

    //Dialogue Logic
    #region dialogueLogic

    private void Next()
    {
        SayLine(npcData.dialogueLines[dialogueIndex]);
        dialogueIndex++;
    }

    private void CheckDialogue()
    {
            if (IsIndexInRange())
            {
                Next();
            }
            else
            {
                dialogueStop();
            }
    }

    private bool IsIndexInRange()
    {
        return dialogueIndex < npcData.dialogueLines.Count;
    }

    #endregion

    private void Update()
    {
        if (dialogueActive && !textActive && Input.GetKeyDown(dialogueButton))
        {
            CheckDialogue();
        }
    }
}
