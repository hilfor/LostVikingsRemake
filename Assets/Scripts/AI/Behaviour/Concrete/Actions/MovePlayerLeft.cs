using UnityEngine;
using System.Collections;
using System;

public class MovePlayerLeft : IBTAction
{
    public bool Act(IContext context)
    {
        IWalker walker = ((IWalker)context.GetVariable("IWalker"));
        FacingDirection facingDirection = walker.GetFacingDirection();
        if (facingDirection == FacingDirection.RIGHT)
        {
            walker.ChangeDirection(FacingDirection.LEFT);
        }
        walker.MoveLeft(walker.GetWalkerSpeed());
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
