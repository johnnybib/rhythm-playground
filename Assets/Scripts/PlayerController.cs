using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody;
    private Transform camera;
    private CharacterController controller;
    private Transform groundChecker;

    private Vector3 vel;
    private bool isGrounded;
    private int ground;

    [SerializeField]
    private float MoveSpeed = 10.0f;//units per second
    [SerializeField]
    private float TurnSpeed = 10.0f;//rad per second
    [SerializeField]
    private float GroundDistance = 1.1f;


    [SerializeField]
    private float Health = 100.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        camera = GameObject.FindWithTag("MainCamera").transform.parent;
        controller = GetComponent<CharacterController>();
        vel = Vector3.zero;
        groundChecker = transform.Find("Ground Checker");
        ground = 1 << LayerMask.NameToLayer("Ground");
    }
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        Move(inputX, inputZ);
        UpdateGravity();
    }
    public void Move(float inputX, float inputZ)
    {
        Vector3 moveH = Vector3.right * inputX;
        Vector3 moveV = Vector3.forward * inputZ;
        Vector3 move = moveH + moveV;

        Vector3 moveLocal = transform.InverseTransformDirection(move);
        Debug.DrawRay(transform.position, moveLocal, Color.red, 1);
        controller.Move(moveLocal * MoveSpeed * Time.deltaTime);
        // if (rotatedMove != Vector3.zero)
        // {
        //     Vector3 newDir = Vector3.RotateTowards(camera.forward, rotatedMove, TurnSpeed * Time.deltaTime, 0.0f);

        //     // Move our position a step closer to the target
        //     transform.rotation = Quaternion.LookRotation(newDir);
        // }
    }

    public void UpdateGravity()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, GroundDistance, ground, QueryTriggerInteraction.Ignore);
        if (isGrounded && vel.y < 0)
        {
            vel.y = 0f;
        }
        else
        {
            vel.y += Physics.gravity.y * Time.deltaTime;
            controller.Move(vel * Time.deltaTime);
        }
    }
}
