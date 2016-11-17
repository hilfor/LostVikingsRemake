using UnityEngine;
using System.Collections;
using System;

public class IfDownArrowPressed : IBTCondition
{
    public bool ConditionPassed(IContext context)
    {
        return Input.GetKey(KeyCode.DownArrow);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
