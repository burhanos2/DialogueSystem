using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    void LateUpdate()
    {
            transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 10, 0f, Input.GetAxis("Vertical") * Time.deltaTime * 10);
    }
}
