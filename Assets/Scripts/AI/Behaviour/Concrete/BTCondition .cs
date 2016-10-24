using UnityEngine;
using System.Collections;
using System;

public class BTCondition : IBTCondition
{
    private Func<IContext, bool> condition;

    public BTCondition(Func<IContext, bool> condition)
    {
        this.condition = condition;
    }

    public bool ConditionPassed(IContext context)
    {
        return condition.Invoke(context);
    }

    public bool Process(IContext context)
    {
        return ConditionPassed(context);
    }
}
