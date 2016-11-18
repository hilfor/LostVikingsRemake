using UnityEngine;
using System.Collections;
using System;

public class IfNoButtonPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckNoInput();
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
