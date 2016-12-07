using UnityEngine;
using System.Collections;
using System;

public class ShootRaycastDown : IBTAction
{
    public bool Act(IContext context)
    {
        Vector2 walkerPosition = ((IWalker)context.GetVariable("IWalker")).GetWalkerPosition();
        RaycastHit2D hit = Physics2D.Raycast(walkerPosition, Vector2.down, 10f);

        return hit.collider != null;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
