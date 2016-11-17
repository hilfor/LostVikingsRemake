using UnityEngine;
using System.Collections;
using System;

public class IfClimbingDirectionIsDown : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        throw new NotImplementedException();
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
