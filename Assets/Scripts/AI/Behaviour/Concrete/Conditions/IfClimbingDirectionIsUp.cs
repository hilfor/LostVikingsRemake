using UnityEngine;
using System.Collections;
using System;

public class IfClimbingDirectionIsUp : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((ICharacter)context.GetVariable("ICharacter")).GetState().ClimbingDirection == ClimbingDirections.UP;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
