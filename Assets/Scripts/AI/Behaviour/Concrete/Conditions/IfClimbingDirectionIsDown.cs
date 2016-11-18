using UnityEngine;
using System.Collections;
using System;

public class IfClimbingDirectionIsDown : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return ((ICharacter)context.GetVariable("ICharacter")).GetState().ClimbingDirection == ClimbingDirections.DOWN;
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
