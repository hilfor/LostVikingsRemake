using UnityEngine;
using System.Collections;
using System;

public class ClearPlayerState : IBTAction
{
    public bool Act(IContext context)
    {
        ((ICharacter)context.GetVariable("ICharacter")).GetState().Clear();
        return true;
    }

    public bool Process(IContext context)
    {
        return Act(context);
    }
}
