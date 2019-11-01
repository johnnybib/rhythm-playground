using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput
{
    public float horz;
    public float vert;

    public bool jumpPressed;
    public bool jumpHeld;
    public bool jumpReleased;

    public ControllerInput()
    {
    }

    public void GetInput()
    {
        horz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");
        jumpPressed = Input.GetButtonDown("Jump");
        jumpHeld = Input.GetButton("Jump");
        jumpReleased = Input.GetButtonUp("Jump");
    }
}
