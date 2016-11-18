using UnityEngine;
using System.Collections;
using System;

public class MoveThePlayerDownTheLadder : IBTAction
{
    public bool Act(IContext context)
    {
        IWalker walker = (IWalker)context.GetVariable("IWalker");
        walker.MoveDown(walker.GetWalkerSpeed());
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
