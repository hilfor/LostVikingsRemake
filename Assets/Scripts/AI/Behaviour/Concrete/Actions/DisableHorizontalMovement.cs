using UnityEngine;
using System.Collections;
using System;

public class DisableHorizontalMovement : IBTAction {
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetState().CanMoveHorizontally = false;
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
