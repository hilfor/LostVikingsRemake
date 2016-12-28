using UnityEngine;
using System.Collections;
using System;

public class IfDownArrowPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        if (((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.DOWN))
        {
            return true;
        }
        return false;
        //return ((IPlayer)context.GetVariable("IPlayer")).GetInputState().CheckPressedOrTriggered(InputAction.DOWN);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
