using UnityEngine;
using System.Collections;
using System;

public class StopFalling : IBTAction
{
    public bool Act(IContext context)
    {
        ((IWalker)context.GetVariable("IWalker")).StopFalling();
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
