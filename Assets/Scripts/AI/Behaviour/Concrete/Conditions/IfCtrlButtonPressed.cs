using UnityEngine;
using System.Collections;
using System;

public class IfCtrlButtonPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.SPECIAL_ACTION1);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
