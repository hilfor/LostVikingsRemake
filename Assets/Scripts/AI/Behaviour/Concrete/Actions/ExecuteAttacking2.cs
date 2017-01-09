using UnityEngine;
using System.Collections;
using System;

public class ExecuteAttacking2 : IBTAction
{

    public bool Act(IContext context)
    {
        ((IPlayer)context.GetVariable("IPlayer")).ExecuteAction2();
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
