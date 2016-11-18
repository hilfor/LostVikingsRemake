using UnityEngine;
using System.Collections;
using System;

public class RestrictPlayerDownMovement : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetState().CanMoveDown = false;
        return true;

    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
