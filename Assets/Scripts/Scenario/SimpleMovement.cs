using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private bool movementSwitch = true;

    public void DisableMovement()
    { movementSwitch = false; }
    public void EnableMovement()
    { movementSwitch = true; }

    private void Awake()
    {
        Dialogue.stopMovement += DisableMovement;
        Dialogue.startMovement += EnableMovement;
    }

    void LateUpdate()
    {
        if (movementSwitch == true)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0f, Input.GetAxis("Vertical") * Time.deltaTime * 10);
        }
    }
}
