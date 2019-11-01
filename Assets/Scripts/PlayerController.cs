using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerBody;
    public Transform cameraTransform;
    private PlayerState state;
    private ControllerInput input;

    public float movementSpeed = 5;
    public float turnSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        cameraTransform = GameObject.FindWithTag("MainCamera").transform;
        input = new ControllerInput();
        state = new IdleState();

    }
    void Update()
    {
        input.GetInput();
        state.HandleInput(this, input);
        state.Update(this, input);
    }
}
