using UnityEngine;
using System.Collections;
using System;

public class PlayerFalls : IBTAction
{
    private float gravity;

    public bool Act(IContext context)
    {
        IWalker walker = ((IWalker)context.GetVariable("IWalker"));
        Vector2 direction = walker.GetMovementDirection();

        walker.MoveDown(direction.y + gravity);

        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
