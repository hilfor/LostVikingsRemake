using UnityEngine;
using System.Collections;
using System;

public class IfLeftButtonPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.LEFT);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
