using UnityEngine;
using System.Collections;
using System;

public class IfClimbingWasEnabled : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((ICharacter)context.GetVariable("ICharacter")).GetState().CanClimb;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
