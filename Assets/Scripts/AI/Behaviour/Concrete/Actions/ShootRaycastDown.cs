using UnityEngine;
using System.Collections;
using System;

public class ShootRaycastDown : IBTAction
{
    public bool Act(IContext context)
    {
        Vector2 walkerPosition = ((IWalker)context.GetVariable("IWalker")).GetWalkerPosition();

        return Physics2D.Raycast(walkerPosition, Vector2.down);
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
