using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public override void HandleInput(PlayerController player, ControllerInput input)
    {
        if(Mathf.Abs(input.horz) > 0 || Mathf.Abs(input.vert) > 0)
        {
            // float camY = player.cameraTransform.eulerAngles.y;
            // Vector3 rot = new Vector3(0, camY, 0);
            // Quaternion rotation = Quaternion.Euler(rot);
            // player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rotation, 180);

            Vector3 move = new Vector3(input.horz, 0, input.vert);
            player.transform.Translate(move * Time.deltaTime * player.movementSpeed, player.cameraTransform);

            Vector3 rotatedMove = player.transform.rotation * move;
            if (rotatedMove != Vector3.zero)
            {
                Vector3 newDir = Vector3.RotateTowards(player.transform.forward, rotatedMove, player.turnSpeed * Time.deltaTime, 0.0f);

                // Move our position a step closer to the target
                player.transform.rotation = Quaternion.LookRotation(newDir);
            }
        }
    }

    public override void Update(PlayerController player, ControllerInput input)
    {

    }
}
