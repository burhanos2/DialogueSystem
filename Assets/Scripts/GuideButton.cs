using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideButton : MonoBehaviour
{
    [SerializeField]
    private NPC_ProximityTrigger triggerDel;

    [SerializeField]
    Renderer buttonImage;


    public void ShowButton()
    {
        buttonImage.enabled = true;
    }

    public void HideButton()
    {
        buttonImage.enabled = false;
    }

    private void Awake()
    {
        buttonImage.enabled = false;
        triggerDel.PlayerEnterNPC += ShowButton;
        triggerDel.PlayerExitNPC += HideButton;
        Dialogue.stopMovement += HideButton;
        Dialogue.startMovement += ShowButton;
    }
}
