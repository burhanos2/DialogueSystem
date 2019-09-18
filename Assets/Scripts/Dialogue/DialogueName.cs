using UnityEngine.UI;
using UnityEngine;

public class DialogueName : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public void SetName(string aName, Color aColor)
    {
        text.text = aName;
        text.color = aColor;
    }
}
