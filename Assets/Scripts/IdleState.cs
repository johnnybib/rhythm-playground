using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundedState
{

    public override void HandleInput(PlayerController player, ControllerInput input)
    {
        //Do nothing
        
        //Pass to GroundedState
        base.HandleInput(player, input);
    }

    public override void Update(PlayerController player, ControllerInput input)
    {
        return;
    }
}
