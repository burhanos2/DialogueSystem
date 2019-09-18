using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TextEffect : MonoBehaviour
{
    public Text _text;
    public float textSpeed { get; set; }
    private float savedSpeed;

    [SerializeField]
    private KeyCode dialogueSkipButton;


   public IEnumerator TypingEffect(string aText, float aSpeed, Action callback)
    {
        savedSpeed = aSpeed;
        textSpeed = aSpeed;
        foreach (char character in aText.ToCharArray())
        {
            _text.text += character;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
        callback();
    }

    public void EmptyText()
    {
        _text.text = "";
    }

    public void ChangeColor(Color aColor)
    {
        _text.color = aColor;
    }

    private void Update()
    {
        if (Input.GetKeyDown(dialogueSkipButton))
        {
            textSpeed = 0f;
        }
        if (Input.GetKeyUp(dialogueSkipButton))
        {
            textSpeed = savedSpeed;
        }
    }
}
