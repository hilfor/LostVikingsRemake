using UnityEngine;
using System.Collections;
using System;

public class MovePlayerRight : IBTAction
{

    public bool Act(IContext context)
    {
        IWalker walker = ((IWalker)context.GetVariable("IWalker"));
        FacingDirection facingDirection = walker.GetFacingDirection();
        if (facingDirection == FacingDirection.LEFT)
        {
            walker.ChangeDirection(FacingDirection.RIGHT);
        }
        walker.MoveRight(walker.GetWalkerSpeed());
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
