using UnityEngine;
using System.Collections;
using System;

public class IfShiftButtonPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.SPECIAL_ACTION2);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
