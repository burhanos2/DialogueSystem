using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour
{
    public Text _text;

   private IEnumerator TypingEffect(string aText)
    {
        foreach (char character in aText.ToCharArray())
        {
            _text.text += character;
             yield return null;
        }
    }
}
