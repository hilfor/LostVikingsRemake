using UnityEngine;
using System.Collections;
using System;

public class IfUpArrowPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.UP);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
