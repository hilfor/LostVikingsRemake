using UnityEngine;
using System.Collections;
using System;

public class PlayerFalls : IBTAction
{
    public bool Act(IContext context)
    {
        IWalker walker = ((IWalker)context.GetVariable("IWalker"));
        walker.FallDown();

        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
