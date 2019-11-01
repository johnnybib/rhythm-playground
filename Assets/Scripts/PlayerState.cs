using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{ 
    public virtual void HandleInput(PlayerController player, ControllerInput input) {}
    public virtual void Update(PlayerController player, ControllerInput input) {}

}
