using UnityEngine;
using System.Collections;
using System;

public class IfRightButtonPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.RIGHT);

    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
